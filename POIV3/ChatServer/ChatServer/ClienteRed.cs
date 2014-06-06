using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using UtileriasChat;


namespace ChatServer
{
    public class ClienteRed
    {
        #region Campos

        delegate void WriteLogCallbackEx(Exception ex);
        delegate void WriteLogCallbackSt(string ex);

        private string usuario;       
        private TcpClient tcpClient;       
        private NetworkStream networkStream;      
        private List<Mensaje> colaMensajes;        
        private Thread hiloTcpClient;
        private frmPrincipal servidor;
        private IFormatter serializador;
        #endregion

        #region Propiedades
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public TcpClient TcpClient
        {
            get { return tcpClient; }
            set { tcpClient = value; }
        }
        public NetworkStream NetworkStream
        {
            get { return networkStream; }
            set { networkStream = value; }
        }
        public List<Mensaje> ColaMensajes
        {
            get { return colaMensajes; }
            set { colaMensajes = value; }
        }
        public Thread HiloTcpClient
        {
            get { return hiloTcpClient; }
            set { hiloTcpClient = value; }
        }
        #endregion

        #region Constructores
        public ClienteRed(frmPrincipal servidor,TcpClient tcpClient)
        {
            this.tcpClient = tcpClient;
            this.servidor = servidor;
            this.colaMensajes = new List<Mensaje>();
            serializador = new BinaryFormatter();
            networkStream = tcpClient.GetStream();
        }
        #endregion

        #region Metodos
        public Contacto GetClientData()
        {            
            dynamic data = ReadData();
            WriteData(servidor.ListaContactos);
            this.usuario = data.Nombre;
            Contacto datos = new Contacto() {  Estado=data.Estado, Ip=data.Ip, Nombre=data.Nombre};
            return datos;
        }
        public void Start()
        {
            try
            {
                hiloTcpClient = new Thread(Performance);
                hiloTcpClient.Start();
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
        }
        public void Performance()
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
        public void Listening()
        {
            try
            {
                while(networkStream.DataAvailable)
                {
                    servidor.ColaMensajes.Add((Mensaje)ReadData());
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }            
        }
        public void Writening()
        {
            try
            {
                while (colaMensajes.Count > 0)
                {
                    WriteData(colaMensajes[0]);
                    colaMensajes.RemoveAt(0);
                }
            }
            catch (Exception ex)
            {
                this.hiloTcpClient.Abort();
                WriteLog(ex);
            }
        }
        public void WriteData(object data)
        {
            try
            {
                if (tcpClient.Connected)
                {
                    serializador.Serialize(networkStream, data);
                    networkStream.Flush();
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
        }
        public object ReadData()
        {
            try
            {
                object data = new object();                
                data = serializador.Deserialize(networkStream);                
                networkStream.Flush();
                return data;
            }
            catch (Exception ex)
            {
                WriteLog(ex);
                return null;
            }   
        }
        public void WriteLog(Exception ex)
        {
            if (servidor.txtLog.InvokeRequired)
            {
                WriteLogCallbackEx d = new WriteLogCallbackEx(servidor.WriteLog);
                servidor.txtLog.Invoke(d, new object[] { ex });
            }
            else
            {
                servidor.WriteLog(ex);
            }  
        }
        public void WriteLog(string ex)
        {
            if (servidor.txtLog.InvokeRequired)
            {
                WriteLogCallbackSt d = new WriteLogCallbackSt(servidor.WriteLog);
                servidor.txtLog.Invoke(d, new object[] { ex });
            }
            else
            {
                servidor.WriteLog(ex);
            }
        }
        #endregion       
    }
}
