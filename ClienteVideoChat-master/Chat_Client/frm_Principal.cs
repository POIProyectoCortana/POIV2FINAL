using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using UtileriasChat;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Chat_Client
{
    public partial class frm_Principal : Form
    {
        #region Campos
            frm_Conectar _padre;
            public TcpClient _serverSocket;
            public NetworkStream _serverStream;
            public byte[] _datosFromServer;
            public byte[] _datosToServer;
            public static List<frm_Chat> _lConversaciones = new List<frm_Chat>();
            //public static Queue<Mensaje> _qMensajesRecibidos = new Queue<Mensaje>();
            public static List<Mensaje> _lMensajesRecibidos = new List<Mensaje>();
            //public static Queue<Mensaje> _qMensajesAEnviar = new Queue<Mensaje>();
            public static List<Mensaje> _lMensajesAEnviar = new List<Mensaje>();
            public static int _buffer = 1024;
             public static List<Contacto> _contactos= new List<Contacto>();
            private Contacto _contacto;
            private IFormatter _serializador;
        #endregion

        #region Propiedades
            public string Nickname { get; set; }
            public int IdServer { get; set; }
        #endregion

        #region Constructor
            public frm_Principal(TcpClient server,string U, string IP, string Port, frm_Conectar P)
            {
                _serverSocket = server;
                _padre = P;
                InitializeComponent();
                this.Nickname = U;
                _datosFromServer = new byte[_buffer];
                _serializador = new BinaryFormatter();
                try
                {
                    //_serverSocket = new TcpClient();
                    //_serverSocket.Connect(IPAddress.Parse(IP), Convert.ToInt32(Port));
                    _serverStream = _serverSocket.GetStream();
                    EnviarDatos(new Mensaje(TipoMensaje.SERVIDOR,DetalleServidor.CONEXION, null,U.ToString()));
                    Mensaje M = RecibirDatos();
                    _contacto = M.Destinatario;
                    this.Text = "Bienvenido " + _contacto.Username + " // ServerId: " + _contacto.Serverid.ToString();
                    
                    //Mensaje Logged = new Mensaje(Mensaje.TipoDeMensaje.ClientLoggedIn, this.Nickname, "ALL", this.Nickname, DateTime.Now);
                    EnviarDatos(new Mensaje(TipoMensaje.ESTADO,DetalleEstado.DISPONIBLE,this._contacto,Red.Broadcast,"Disponible"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK);
                    _padre.Show();
                    this.Close();
                }
            }
        #endregion

        #region Métodos
            private void ProcesarMensaje(Mensaje mensaje)
            {
                switch (mensaje.Tipo)
                {
                    case TipoMensaje.SERVIDOR:
                        ProcesarServidor(mensaje);
                        break;
                    case TipoMensaje.CHAT:
                        ProcesarChat(mensaje);
                        break;
                    case TipoMensaje.ESTADO:
                        ProcesarEstado(mensaje);
                        break;
                    case TipoMensaje.SOLICITUD:
                        ProcesarSolicitud(mensaje);
                        break;
                }
                
            }
            private void ProcesarServidor(Mensaje mensaje)
            {
                switch (mensaje.DetalleServidor)
                {
                    case DetalleServidor.NUEVO_CONECTADO:
                        _contactos.Add(mensaje.Remitente);
                        ActualizarContactos();
                        break;
                    case DetalleServidor.NUEVO_DESCONECTADO:
                        break;
                    case DetalleServidor.NUEVO_SESION:
                        break;
                    case DetalleServidor.NUEVO_SESION_CONECTADO:
                        break;
                    case DetalleServidor.NUEVO_SESION_DESCONECTADO:
                        break;
                }
            }
            private void ProcesarChat(Mensaje mensaje)
            { 
                switch(mensaje.DetalleChat)
                {
                    case DetalleChat.TEXTO:
                        break;
                    case DetalleChat.ZUMBIDO:
                        break;
                }
            }
            private void ProcesarSolicitud(Mensaje mensaje)
            {
                switch(mensaje.DetalleSolicitud)
                {
                    case DetalleSolicitud.ARCHIVO_CONECTAR:
                        break;
                    case DetalleSolicitud.ARCHIVO_DESCONECTAR:
                        break;
                    case DetalleSolicitud.ARCHIVO_OK:
                        break;
                    case DetalleSolicitud.VIDEO_CONECTAR:
                        break;
                    case DetalleSolicitud.VIDEO_DESCONECTAR:
                        break;
                    case DetalleSolicitud.VIDEO_OK:
                        break;

                }
            }
            private void ProcesarEstado(Mensaje mensaje)
            {               
            }
            private void EntregarMensajesConversaciones()
            {                
                while (_lMensajesRecibidos.Count > 0)
                {                    
                    Mensaje mensaje = _lMensajesRecibidos[0];
                    _lMensajesRecibidos.RemoveAt(0);
                    ProcesarMensaje(mensaje);
                }
            }
            private void RecibirMensajes()
            {
                try
                {
                    if (_serverStream.DataAvailable)
                    {
                        Mensaje mensaje = RecibirDatos();
                        _lMensajesRecibidos.Add(mensaje);
                        //_qMensajesRecibidos.Enqueue(M);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK);
                }
            }
            private void EnviarMensajes()
            {
                while (_lMensajesAEnviar.Count > 0)
                {
                    Mensaje mensaje = _lMensajesAEnviar[0];
                    _lMensajesAEnviar.RemoveAt(0);
                    EnviarDatos(mensaje);
                }
            }
            public void EnviarDatos(Mensaje M)
            {
                try
                {
                    _serializador.Serialize(_serverStream, M);
                    _serverStream.Flush();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK);
                    _padre.Show();
                    this.Close();
                }
            }
            public Mensaje RecibirDatos()
            {
                try
                {
                    return (Mensaje)_serializador.Deserialize(_serverStream);
                }
                catch(Exception ex)
                { 
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK);
                    return null;
                }
                //this._serverStream.Read(_datosFromServer, 0, _datosFromServer.Length);
                //Mensaje M = new Mensaje();
                //M.ParseBinaryToMessage(_datosFromServer);
                //this._serverStream.Flush();
                //Array.Clear(_datosFromServer, 0, _datosFromServer.Length);
                //return M;
            }
            private void ActualizarContactos()
            {
                ltb_Conectados.Items.Clear();
                foreach(Contacto C in _contactos)
                {
                    ltb_Conectados.Items.Add(C.Username+"/"+C.Estado.ToString());
                }
            }
        #endregion

        #region Eventos
            private void btn_ChatGeneral_Click(object sender, EventArgs e)
            {

                //Mensaje Msj = new Mensaje(Mensaje.TipoDeMensaje.Message, Nickname, "ALL", txt_ChatGeneral.Text, DateTime.Now);
                Mensaje Msj = new Mensaje(TipoMensaje.CHAT, DetalleChat.TEXTO, _contacto, Red.Broadcast, txt_ChatGeneral.Text);
                EnviarDatos(Msj);
                txt_ChatGeneral.Text = "";
                
            }
            private void frm_Principal_Load(object sender, EventArgs e)
            {
                rtb_ChatGeneral.Enabled = false;
                tmr_Principal.Enabled = true;
            }
            private void ltb_Conectados_DoubleClick(object sender, EventArgs e)
            {
                frm_Chat NuevaVentana = new frm_Chat(this.ltb_Conectados.SelectedItem.ToString(), this);
                NuevaVentana.Show();
                _lConversaciones.Add(NuevaVentana);
            }
            private void frm_Principal_FormClosed(object sender, FormClosedEventArgs e)
            {
                //Mensaje Logged = new Mensaje(Mensaje.TipoDeMensaje.ClientLoggedOut, this.Nickname, "ALL", this.Nickname, DateTime.Now);
                //Padre.EnviarDatos(Logged);
                //tmr_Principal.Enabled = false;
                //this.Padre.ClientSocket.Close();
                //this.Padre.Show();
            }
            private void tmr_Principal_Tick(object sender, EventArgs e)
            {
                RecibirMensajes();
                EnviarMensajes();
                EntregarMensajesConversaciones();
            }
        #endregion
    }
}
