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
            private static List<frm_Chat> _lConversaciones = new List<frm_Chat>();
            private static List<frm_Videollamada> _lVideollamada = new List<frm_Videollamada>();
            private static List<frm_ChatGrupal> _lConversacionesGrupales = new List<frm_ChatGrupal>();
            public static List<Sesion> _lGrupos= new List<Sesion>();
            public static List<Mensaje> _lMensajesRecibidos = new List<Mensaje>();
            public static List<Mensaje> _lMensajesAEnviar = new List<Mensaje>();
            public static int _buffer = 1024;
            public static List<Contacto> _contactos= new List<Contacto>();
            public Contacto _contacto;
            private IFormatter _serializador;
            public  static Contacto userContact;            
            int ultimoGrupo;
        #endregion

        #region Propiedades
            public string Nickname { get; set; }
            public int IdServer { get; set; }
            public static List<frm_Chat> Conversaciones
            {
                get { return frm_Principal._lConversaciones; }
                set { frm_Principal._lConversaciones = value; }
            }
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
                ultimoGrupo = 0;
                try
                {
                    _serverStream = _serverSocket.GetStream();
                    EnviarDatos(new Mensaje(TipoMensaje.SERVIDOR,DetalleServidor.CONEXION, null,U.ToString()));
                    Mensaje M = RecibirDatos();
                    _contacto = M.Destinatario;
                    this.Text = "Bienvenido " + _contacto.Username + " // ServerId: " + _contacto.Serverid.ToString();
                    userContact = new Contacto() { Ip = IPAddress.Parse(Red.GetThisMachineIP()), Username = U, Serverid = _contacto.Serverid };                    
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
            public static void QuitarVentanaGrupo(int grupoId)
            {
                 frm_ChatGrupal ventana = _lConversacionesGrupales.Find(
                    delegate(frm_ChatGrupal chat)
                    {
                        return chat.SesionId == grupoId;
                    }
                    );
                 if (ventana != null)
                 {
                     _lConversacionesGrupales.RemoveAt(_lConversacionesGrupales.IndexOf(ventana));
                 }
            }
            public static void QuitarVentana(string alias)
            {
                frm_Chat ventana = _lConversaciones.Find(
                   delegate(frm_Chat chat)
                   {
                       return chat.Nickname == alias;
                   }
                   );
                if (ventana != null)
                {
                    _lConversaciones.RemoveAt(_lConversaciones.IndexOf(ventana));
                }
            }
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
                    case DetalleServidor.LISTA_CONECTADOS:
                        if (mensaje.Contenido != "")
                        {
                            string[] conn = mensaje.Contenido.Split('|');
                            foreach (string c in conn)
                            {
                                _contactos.Add(new Contacto() { Username = c });
                            }
                            ActualizarContactos();
                        }
                        break;
                    case DetalleServidor.NUEVO_CONECTADO:
                        if (!(mensaje.Remitente.Username == this._contacto.Username))
                        {
                            _contactos.Add(mensaje.Remitente);
                            ActualizarContactos();
                        }
                        break;
                    case DetalleServidor.NUEVO_DESCONECTADO:
                        break;
                    case DetalleServidor.NUEVO_GRUPO:
                        string[] datos = mensaje.Contenido.Split('|');
                        ultimoGrupo = Int32.Parse(datos[1]);
                        Sesion grupo = new Sesion(ultimoGrupo, datos[0]);
                        frm_Principal._lGrupos.Add(grupo);
                        break;
                    case DetalleServidor.NUEVO_GRUPO_CONECTADO:
                        string[] integ = mensaje.Contenido.Split('|');
                        Sesion grupito = _lGrupos.Find(
                        delegate(Sesion grupos)
                        {
                            return grupos.SessionId == ultimoGrupo;
                        }
                        );
                        foreach (string usr in integ)
                        {
                            grupito.AgregarParticipante(usr);
                        }
                        ActualizarGrupos();
                        break;
                    case DetalleServidor.NUEVO_GRUPO_DESCONECTADO:
                        break;
                }
            }
            private void ProcesarChat(Mensaje mensaje)
            { 
                switch(mensaje.DetalleChat)
                {
                    case DetalleChat.TEXTO:
                        if (mensaje.Destinatario.Username.Equals(Red.Broadcast.Username))
                        {                            
                            this.rtb_ChatGeneral.PrintRTB(mensaje);
                        }
                        else
                        {
                            ActualizarConversacion(mensaje); 
                        }
                        break;
                    case DetalleChat.ZUMBIDO:
                        break;
                    case DetalleChat.TEXTO_GRUPAL:

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
            public  void EnviarDatos(Mensaje M)
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
            public void ActualizarConversacion(Mensaje mensaje)
            {
                frm_Chat ventana=Conversaciones.Find(
                    delegate(frm_Chat chat)
                    {
                        return chat.Nickname == mensaje.Remitente.Username;
                    }
                    );
                if (ventana == null)
                {
                    Conversaciones.Add(new frm_Chat(mensaje.Remitente.Username, this)
                    {
                        QRecibidos = { mensaje}
                    });
                }
                else
                {
                    ventana.QRecibidos.Add(mensaje); 
                }
            }
            public void ActualizarGrupos()
            {
                lstGrupos.Items.Clear();
                foreach(Sesion s in _lGrupos)
                {
                    lstGrupos.Items.Add(s.SessionAlias);                  
                }
            }
            public void EntregarChat(Mensaje msj)
            {}
            public void EntregarGrupos(Mensaje msj)
            {
                frm_ChatGrupal ventana = _lConversacionesGrupales.Find(
                    delegate(frm_ChatGrupal chat)
                    {
                        return chat.SesionId == msj.GrupoId;
                    }
                    );
                if (ventana == null)
                {
                    Sesion grupo = _lGrupos.Find(
                    delegate(Sesion grup)
                    {
                        return grup.SessionAlias == this.lstGrupos.SelectedItem.ToString();
                    }
                    );
                    if (grupo != null)
                    {
                        frm_ChatGrupal NuevaVentana = new frm_ChatGrupal(grupo);
                        _lConversacionesGrupales.Add(NuevaVentana);
                        ventana.LMensajes.Add(msj);
                        NuevaVentana.Show();
                    }
                }
                else
                {
                    ventana.LMensajes.Add(msj);
                }   
            }
        #endregion

        #region Eventos
            private void btn_ChatGeneral_Click(object sender, EventArgs e)
            {
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
                frm_Chat ventana = Conversaciones.Find(
                    delegate(frm_Chat chat)
                    {
                        return chat.Nickname == this.ltb_Conectados.SelectedItem.ToString();
                    }
                    );
                if (ventana == null)
                {
                    frm_Chat NuevaVentana = new frm_Chat(this.ltb_Conectados.SelectedItem.ToString(), this);
                    _lConversaciones.Add(NuevaVentana);
                    NuevaVentana.Show();
                }
                else
                {
                    ventana.Show();
                }   
            }
            private void frm_Principal_FormClosed(object sender, FormClosedEventArgs e)
            {
                Mensaje Logged = new Mensaje(TipoMensaje.SERVIDOR,DetalleServidor.DESCONEXION, Red.Broadcast, DateTime.Now.ToString());
                this.EnviarDatos(Logged);                
                tmr_Principal.Enabled = false;
                this._serverSocket.Close();
                this._padre.Show();
            }
            private void tmr_Principal_Tick(object sender, EventArgs e)
            {
                RecibirMensajes();
                EnviarMensajes();
                EntregarMensajesConversaciones();
            }
            private void lstGrupos_DoubleClick(object sender, EventArgs e)
            {
                if (lstGrupos.SelectedItem != null)
                {
                    frm_ChatGrupal ventana = _lConversacionesGrupales.Find(
                        delegate(frm_ChatGrupal chat)
                        {
                            return chat.SesionAlias == this.lstGrupos.SelectedItem.ToString();
                        }
                        );
                    if (ventana == null)
                    {

                        Sesion grupo = _lGrupos.Find(
                        delegate(Sesion grup)
                        {
                            return grup.SessionAlias == this.lstGrupos.SelectedItem.ToString();
                        }
                        );
                        if (grupo != null)
                        {
                            frm_ChatGrupal NuevaVentana = new frm_ChatGrupal(grupo);
                            _lConversacionesGrupales.Add(NuevaVentana);
                            NuevaVentana.Show();
                        }
                    }
                    else
                    {
                        ventana.Show();
                    }
                }
            }
            private void gruposToolStripMenuItem_Click(object sender, EventArgs e) 
            {
                new frm_crearGrupo().ShowDialog();
            }
            
            
        #endregion

            private void videollamadaToolStripMenuItem_Click(object sender, EventArgs e)
            {
                //SOLO ME FALTO AGREGAR PARA QUE SE LLAME LA VISTA
                frm_Videollamada NuevaVideollamada = new frm_Videollamada();
                //_lVideollamada.Add(NuevaVideollamada);
                NuevaVideollamada.Show();
            }

    }
}
