using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using UtileriasChat;

namespace Chat_Server
{
    public class Client
    {
        delegate void WriteLogCallback(Exception ex);
        delegate void DesconectarClienteCallback(int listIndex);
        #region Campos
        //private static int StreamBuffer = 1024;
        private TcpClient _clientSocket;
        private NetworkStream _networkStream;
        private Queue<Mensaje> _mensajeQueue;
        private List<Mensaje> _mensajeList;
        private Thread _chatThread;
        
        //private byte[] _datos;
        private byte[] _fixedDatos;
        private Mensaje _mensaje;
        private frm_ServerMain _parent;
        private IFormatter _serializador;
        private Contacto _contacto;
        private int listIndex;

        public int ListIndex
        {
            get { return listIndex; }
            set { listIndex = value; }
        }
        #endregion

        #region Propiedades
        public Queue<Mensaje> MensajeQueue
        {
            get { return _mensajeQueue; }
            set { _mensajeQueue = value; }
        }      
        public List<Mensaje> MensajeList
        {
            get { return _mensajeList; }
            set { _mensajeList = value; }
        }           
        public Contacto Contacto
        {
            get { return _contacto; }
            set { _contacto = value; }
        }
        #endregion

        #region Constructores
        public Client(frm_ServerMain Server,TcpClient Accepted,int id)
        {
            //INICIALIZA LA CLASE 
            //INICIA LA CONEXION DEL NETWORKSTREAM PARA EL ENVIO Y RECEPCION DE DATOS           
            _parent = Server;
            _clientSocket = Accepted;
            _networkStream = _clientSocket.GetStream();
            _fixedDatos = new byte[frm_ServerMain._bufferSize];            
            Mensaje Msj = new Mensaje();
            _mensajeQueue = new Queue<Mensaje>();
            _mensajeList = new List<Mensaje>();
            _serializador = new BinaryFormatter();
            _contacto = new Contacto();
            _contacto.Serverid = id;

        }
        #endregion

        #region Métodos
        public void Start()
        {
            try
            {
                _chatThread = new Thread(ChatService);
                _chatThread.Start();
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
        }
        public void GetDataFromClient()
        {
            try
            {
                Mensaje M = new Mensaje();
                M = (Mensaje)_serializador.Deserialize(_networkStream);
                if (M.Tipo == TipoMensaje.SERVIDOR && M.DetalleServidor == DetalleServidor.CONEXION)
                {
                    int ids = _contacto.Serverid;
                    _contacto.Username = M.Contenido;
                    _contacto.Serverid = ids;
                }
                Enviar(new Mensaje(TipoMensaje.SERVIDOR, DetalleServidor.CONEXION_OK, this._contacto, _contacto.Serverid.ToString()));
                Mensaje mensaje = new Mensaje(TipoMensaje.SERVIDOR, DetalleServidor.NUEVO_CONECTADO, Red.Broadcast, "");
                mensaje.Remitente = this.Contacto;
                Enviar(mensaje);                
            }
            catch(Exception ex)
            {
                //Para mostrar errores
                WriteLog(ex);
            }           
        }
        void Listening()
        {
            try
            {
                if (_networkStream.DataAvailable)
                {
                    _mensaje = RecibirDatos();
                    //frm_ServerMain._mensajeQueue.Enqueue(_mensaje);
                    frm_ServerMain._mensajeList.Add(_mensaje);
                }
            }
            catch (Exception ex)
            {
                 WriteLog(ex);
            }
        }            
        void Writening() 
        {
            try
            {
                if (_mensajeList.Count > 0)
                {
                    Enviar(_mensajeList[0]);
                    _mensajeList.RemoveAt(0);
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
        }
        void ChatService()
        {
            try
            {

                while (true)
                {
                    Listening();
                    Writening();
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
        }
        Mensaje RecibirDatos()
        {
            try
            {
                Mensaje mensaje = (Mensaje)_serializador.Deserialize(_networkStream);
                _networkStream.Flush();
                return mensaje;

            }
            catch (Exception ex)
            {
                 WriteLog(ex);
                return null;
            }
        }
        void Enviar(Mensaje mensaje)
        {
            try
            {
                if (_clientSocket.Connected)
                {
                    _serializador.Serialize(_networkStream, mensaje);
                    _networkStream.Flush();
                }
                else
                {
 
                }
                
            }
            catch (Exception ex)
            {
                this._clientSocket.Close();
                this._chatThread.Abort();
                DisconnectclientList();
                 WriteLog(ex);

            }
        }

        private void WriteLog(Exception ex)
        {
            if (_parent.txtLog.InvokeRequired)            
            {
                WriteLogCallback d = new WriteLogCallback(_parent.WriteLog);
                _parent.txtLog.Invoke(d,new object[] { ex });
            }
            else
            {
                _parent.WriteLog(ex);
            }                      
        }
        private void DisconnectclientList()
        {
            
                DesconectarClienteCallback d = new DesconectarClienteCallback(_parent.DesconectarClienteLista);
                d.Invoke(this.listIndex);
                //_parent.txtLog.Invoke(d, new object[] { ex });
              
        }

       
        #endregion
    }
}
