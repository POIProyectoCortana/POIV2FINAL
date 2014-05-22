using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using UtileriasChat;
using System.IO;

namespace Chat_Server
{
    public partial class frm_ServerMain : Form
    {
        //delegate WriteLogCallback(Exception ex);
        #region Campos
        delegate void ClientCounterCallback();
        public int _idGenerator;
        private int _idSesionGenerator;
        private bool _encendido;
        private List<Client> _clientList;
        private TcpListener _serverListener;
        private byte[] _fixedDatos;
        IPAddress _serverAddress;
        public static int _bufferSize = 512;
        
        public static List<Mensaje> _mensajeList = new List<Mensaje>();
        public static List<Mensaje> _mensajeListPending = new List<Mensaje>();
        private static List<Sesion> _sesionList = new List<Sesion>(); 
        public static List<string> _usuarioArchivo = new List<string>();
        #endregion      

        #region Propiedades
       
        #endregion

        #region Constructores
        public frm_ServerMain()
        {
            _encendido = false;
            InitializeComponent();
            _serverAddress = IPAddress.Parse(Red.GetThisMachineIP());
            _serverListener = new TcpListener(_serverAddress, 1234);
            lbl_DataServer.Text = "IP: " + Red.GetThisMachineIP() + " \n Puerto: 1234";
            _clientList = new List<Client>();
            _fixedDatos = new byte[_bufferSize];
            _idGenerator = _idSesionGenerator= 1;
            _mensajeList.Clear();
            _mensajeListPending.Clear();
            _sesionList.Clear();
            _usuarioArchivo.Clear();
        }  
        #endregion

        #region Eventos
        private void btn_Iniciar_Click(object sender, EventArgs e)
        {
            if (!_encendido)
            {
                //AQUI ENCIENDE EL SERVIDOR
                try
                {
                    _serverListener.Start();
                    _encendido = !_encendido;
                    lbl_DEstado.Text = "Encendido";
                    lbl_DEstado.ForeColor = System.Drawing.Color.DarkGreen;
                    lbl_DEstado.BackColor = System.Drawing.Color.LightGreen;
                    btn_Iniciar.Text = "Detener";
                    tmr_Server.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK);
                }
            }
            else
            {
                //AQUI APAGA EL SERVIDOR
                try
                {
                    _serverListener.Stop();
                    _encendido = !_encendido;
                    lbl_DEstado.Text = "Apagado";
                    lbl_DEstado.ForeColor = System.Drawing.Color.DarkRed;
                    lbl_DEstado.BackColor = System.Drawing.Color.LightCoral;
                    btn_Iniciar.Text = "Iniciar";
                    tmr_Server.Enabled = false;
                    tmr_Server.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK);
                }
            }
        }
        private void tmr_Server_Tick(object sender, EventArgs e)
        {
            ListenerProcess();
            EntregarMensajes();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void frm_ServerMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Mensaje mensaje = new Mensaje(TipoMensaje.SERVIDOR, DetalleServidor.DESCONEXION_OK, Red.Broadcast, "END");           
            _mensajeList.Add(mensaje);
        }
        private void lbl_conectados_Click(object sender, EventArgs e)
        {

        }
        private void frm_ServerMain_Load(object sender, EventArgs e)
        {
            cargaIniciarlUsuarios();
        }
        #endregion

        #region Métodos
        public void ListenerProcess()
        {
            try
            {
                while (_serverListener.Pending())
                {
                    TcpClient NewTCPClient = _serverListener.AcceptTcpClient();
                    Client NewClient = new Client(this, NewTCPClient, _idGenerator);
                    NewClient.GetDataFromClient();
                    _clientList.Add(NewClient);
                    int Index = _clientList.IndexOf(NewClient);
                    _clientList[Index].ListIndex = Index;
                    _clientList[Index].Start();
                    if (_usuarioArchivo.Contains(_clientList[Index].Contacto.Username))
                    { _usuarioArchivo.Add(_clientList[Index].Contacto.Username); }
                    _clientList[Index].MensajeList = SendOfflineMessages(_clientList[Index].Contacto.Username);
                    lbl_conectados.Text = "Clientes conectados: " + _clientList.Count.ToString();
                    _idGenerator++;
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex);
               // this.txtLog.Text += DateTime.Now + "--" + ex.Message + "\n";
            }
        }               
        public void AddMsj(Mensaje mensaje)
        {
            _mensajeList.Add(mensaje);
        }
        public void EntregarMensajes()
        {
            try
            {
                while (_mensajeList.Count > 0)
                {
                    Mensaje Entregar = _mensajeList[0];
                    _mensajeList.RemoveAt(0);
                    switch(Entregar.Tipo)
                    {
                        case TipoMensaje.SERVIDOR:
                            switch (Entregar.DetalleServidor)
                            {
                                
                                case DetalleServidor.NUEVO_GRUPO:
                                    int id = 0;
                                    Mensaje Entregar2 = _mensajeList[0];
                                    _mensajeList.RemoveAt(0);
                                    if(Entregar.DetalleServidor== DetalleServidor.NUEVO_GRUPO && Entregar2.DetalleServidor==DetalleServidor.NUEVO_GRUPO_CONECTADO)
                                    {                                        
                                        id=GenerarGrupo(Entregar.Contenido,Entregar2.Contenido);
                                        Entregar.Contenido = Entregar.Contenido + "|" + id.ToString();
                                    }                                    
                                    //enviar a todos los destinatarios del grupo con el id de la sesion
                                    EntregarSesion(id, Entregar, Entregar2);
                                    break;
                            }
                            break;
                        case TipoMensaje.CHAT:
                            switch(Entregar.DetalleChat)
                            {
                                case DetalleChat.TEXTO_GRUPAL:
                                    break;
                                case DetalleChat.TEXTO:
                                case DetalleChat.ZUMBIDO:
                                    EntregarSesion(Entregar.GrupoId, Entregar, null);
                                    break;
                            }
                            break;
                    }
                    int Clientes = _clientList.Count;
                    if (Entregar.Destinatario.Username == "Broadcast")
                    {
                        foreach (Client C in _clientList)
                        {
                            if (Entregar.Destinatario.Username == "Broadcast" && C.Contacto.Estado == EstadoCliente.CONECTADO)
                            {
                                C.MensajeList.Add(Entregar);
                            }
                            else if (C.Contacto.Username == Entregar.Destinatario.Username)
                            {
                                if (C.Contacto.Estado == EstadoCliente.CONECTADO)
                                {
                                    C.MensajeList.Add(Entregar);
                                }
                                else
                                {
                                    _mensajeListPending.Add(Entregar);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex);                
            }
           
        }
        internal void WriteLog(Exception ex)
        {
            this.txtLog.Text += DateTime.Now + "--" + ex.Message + Environment.NewLine;
            //return null;
        }
        internal void DesconectarClienteLista(int listIndex)
        {
            _clientList.RemoveAt(listIndex);
            if (lbl_conectados.InvokeRequired)
            {
                ClientCounterCallback d = new ClientCounterCallback(ActualizarConteoConectados);
                lbl_conectados.Invoke(d);
            }
        }
        private void cargaIniciarlUsuarios()
        {
            try
            {
                string line = "";
                if (!File.Exists("Archivos\\usuarios.txt"))
                {
                    File.Create("Archivos\\usuarios.txt");
                }
                else
                {
                    StreamReader objReader = new StreamReader("Archivos\\usuarios.txt");
                    while (line != null)
                    {
                        line = objReader.ReadLine();
                        if (line != null)
                        {
                            if (!_usuarioArchivo.Contains(line))
                            {
                                _usuarioArchivo.Add(line);
                            }
                        }
                    }
                    objReader.Close(); 
                }
            }
            catch(Exception ex)
            {

            }
        }
        private List<Mensaje> SendOfflineMessages(string username)
        {
            List<Mensaje> ptes= new List<Mensaje>();
            foreach (Mensaje m in _mensajeListPending)
            {
                if(m.Destinatario.Username.Equals(username))
                {
                    ptes.Add(m);
                }
            }
            return ptes;
        }
        private void ActualizarConteoConectados()
        {
            lbl_conectados.Text = "Clientes conectados: " + _clientList.Count.ToString();
        }
        private int GenerarGrupo(string alias,string integrantes)
        {
            Sesion grupo = new Sesion(alias);
            string[] integ = integrantes.Split('|');
            foreach(string contacto in integ)
            {
                grupo.AgregarParticipante(contacto);
            }
            grupo.SessionId = _idSesionGenerator;
            _sesionList.Add(grupo);
            _idSesionGenerator++;
            return grupo.SessionId;
        }
        private void EntregarSesion(int sesionId,Mensaje msj1,Mensaje msj2)
        {
            Sesion grupo = _sesionList.Find(
                    delegate(Sesion grupos)
                    {
                        return grupos.SessionId == sesionId;
                    }
            ); 
            if(grupo != null)
            {
                foreach(string username in grupo.Integrantes)                
                {
                    Client cliente = _clientList.Find(
                            delegate(Client clientes)
                            {
                                return clientes.Contacto.Username == username;
                            }
                    );
                    if(cliente != null)
                    {
                        cliente.MensajeList.Add(msj1);
                        if (msj2 != null)
                        {
                            cliente.MensajeList.Add(msj2);
                        }
                    }                     
                }
            }
        }
        #endregion
    }   
}
