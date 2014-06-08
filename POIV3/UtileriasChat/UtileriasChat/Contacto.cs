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
            private String nombre;
            private IPAddress ip;
            private EstadoCliente estado;
            private DetalleEstado estadoChat;
        #endregion

        #region Propiedades
            public String Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }         
            public IPAddress Ip
            {
                get { return ip; }
                set { ip = value; }
            }
            public EstadoCliente Estado
            {
                get { return estado; }
                set { estado = value; }
            }
            public DetalleEstado EstadoChat
            {
                get { return estadoChat; }
                set { estadoChat = value; }
            }
        #endregion

        #region Constructores
            public Contacto()
            { }
            public Contacto(String username, IPAddress ip)
            {
                this.nombre = username;
                this.ip = ip;
            }
            public Contacto(String username, EstadoCliente state)
            {
                this.nombre = username;
                this.estado = state;
            }
            public Contacto(String username, EstadoCliente state, IPAddress ip)
            {
                this.nombre = username;
                this.estado = state;
                this.ip = ip;
            }
        #endregion

        #region Métodos
        override
            public String ToString()
            {
                return nombre + Environment.NewLine;
            }
        #endregion   
    }
    
}
