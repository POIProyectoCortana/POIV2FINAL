using System;
using System.Net;

namespace UtileriasChat
{
    public enum EstadoCliente
    {
        CONECTADO,
        DESCONECTADO
    }

    [Serializable]
    public class Contacto
    {
        #region Campos
            private String _username;
            private int _serverid;
            private IPAddress _ip;
            private EstadoCliente _estado;
        #endregion

        #region Propiedades
            public String Username
            {
                get { return _username; }
                set { _username = value; }
            }
            public int Serverid
            {
                get { return _serverid; }
                set { _serverid = value; }
            }
            public IPAddress Ip
            {
                get { return _ip; }
                set { _ip = value; }
            }
            public EstadoCliente Estado
            {
                get { return _estado; }
                set { _estado = value; }
            }
        #endregion

        #region Constructores
            public Contacto()
            { }
            public Contacto(String username, String serverId, IPAddress ip)
            {

            }
            public Contacto(String username, EstadoCliente estado)
            {
                _username = username;
                _estado = estado;
            }
            public Contacto(int serverId, String username, EstadoCliente estado)
            {
                _username = username;
                _estado = estado;
                _serverid = serverId;
            }
        #endregion

        #region Métodos
            public String ToFileString()
            {
                return _serverid.ToString() + "," + _username + Environment.NewLine;
            }
        #endregion   
    }
    
}
