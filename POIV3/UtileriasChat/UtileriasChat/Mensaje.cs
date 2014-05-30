using System;
using System.Drawing;
using System.Windows.Forms;

namespace UtileriasChat
{
    public enum TipoMensaje
    {
        SOLICITUD,
        SERVIDOR,
        CHAT,        
        ESTADO        
    }
    public enum DetalleSolicitud
    {
        VIDEO_CONECTAR,
        VIDEO_DESCONECTAR,
        VIDEO_OK,
        ARCHIVO_CONECTAR,
        ARCHIVO_DESCONECTAR,
        ARCHIVO_OK
    }
    public enum DetalleChat
    {
        TEXTO,
        ZUMBIDO,
        TEXTO_GRUPAL,
        ZUMBIDO_GRUPAL
    }
    public enum DetalleEstado
    {
        DISPONIBLE,
        OCUPADO,
        AUSENTE
    }
    public enum DetalleServidor
    {
        NUEVO_CONECTADO,
        NUEVO_DESCONECTADO,
        NUEVO_GRUPO,
        NUEVO_GRUPO_CONECTADO,
        NUEVO_GRUPO_DESCONECTADO,
        CONEXION,
        CONEXION_OK,
        DESCONEXION,
        DESCONEXION_OK
    }

    [Serializable]
    public class Mensaje
    {
        #region Campos
        public static readonly string[,] EmoticonList =
            {
                {":angel:","\\Emoticons\\angel.bmp",""},
                {">.<","Emoticons\angry.bmp",""},
                {"</3","Emoticons\\breakheart.bmp",""},
                {":cat:","Emoticons\\cat.bmp",""},
                {":cellphone:","Emoticons\\cellphone.bmp",""},
                {":clown:","Emoticons\\clown.bmp",""},
                {":cold:","Emoticons\\cold.bmp",""},
                {"@.@","Emoticons\\confused.bmp",""},
                {":crazy:","Emoticons\\crazy.bmp",""},
                {"T-T","Emoticons\\cry.bmp",""},
                {":devil:","Emoticons\\devil.bmp",""},
                {":dog:","Emoticons\\dog.bmp",""},
                {"?.?","Emoticons\\doubt.bmp",""},
                {":em:","Emoticons\\embarrased.bmp",""},
                {":hug:","Emoticons\\friends.bmp",""},
                {":gift:","Emoticons\\gift.bmp",""},
                {"<3","Emoticons\\heart.bmp",""},
                {":hot:","Emoticons\\hot.bmp",""},
                {":idea:","Emoticons\\idea.bmp",""},
                {"o3o","Emoticons\\inlove.bmp",""},
                {":*","Emoticons\\kiss.bmp",""},
                {":moon:","Emoticons\\moon.bmp",""},
                {"(8)","Emoticons\\music.bmp",""},
                {":party:","Emoticons\\party.bmp",""},
                {":/","Emoticons\\pokerface.bmp",""},
                {":(","Emoticons\\sad.bmp",""},
                {":uff:","Emoticons\\safe.bmp",""},
                {":X","Emoticons\\shutup.bmp",""},
                {":throw:","Emoticons\\sick.bmp",""},
                {"zZ","Emoticons\\sleepy2.bmp",""},
                {"B/","Emoticons\\smart.bmp",""},
                {":D","Emoticons\\smile.bmp",""},
                {":)","Emoticons\\smile2.bmp",""},
                {":star:","Emoticons\\stars.bmp",""},
                {":p","Emoticons\\tongi.bmp",""},
                {"B)","Emoticons\\yei.bmp",""},
                {";)","Emoticons\\wink.bmp",""},
                {"(Y)","Emoticons\\yes.bmp",""},
            };
            private TipoMensaje tipoMensaje;
            private DetalleChat detalleChat;            
            private DetalleEstado detalleEstado;            
            private DetalleServidor detalleServidor;           
            private DetalleSolicitud detalleSolicitud;            
            private String remitente;            
            private String destinatario;            
            private String contenido;
            private Int32 grupoId;
            private bool encriptado;              
        #endregion
       
        #region Propiedades
        public TipoMensaje Tipo
        {
            get { return tipoMensaje; }
            set { tipoMensaje = value; }
        }
        public string Contenido
        {
            get { return contenido; }
            set { contenido = value; }
        }
        public string Destinatario
        {
            get { return destinatario; }
            set { destinatario = value; }
        }
        public DetalleSolicitud DetalleSolicitud
        {
            get { return detalleSolicitud; }
            set { detalleSolicitud = value; }
        }
        public string Remitente
        {
            get { return remitente; }
            set { remitente = value; }
        }
        public DetalleServidor DetalleServidor
        {
            get { return detalleServidor; }
            set { detalleServidor = value; }
        }
        public DetalleEstado DetalleEstado
        {
            get { return detalleEstado; }
            set { detalleEstado = value; }
        }
        public DetalleChat DetalleChat
        {
            get { return detalleChat; }
            set { detalleChat = value; }
        }    
        public int GrupoId
        {
            get { return grupoId; }
            set { grupoId = value; }
        }
        public bool Encriptado
        {
            get { return encriptado; }
            set { encriptado = value; }
        }
        #endregion

        #region Constructores
            public Mensaje()
            {           
            }
            public Mensaje(TipoMensaje tipo, DetalleChat detalle, String remitente, String destinatario, String contenido)
            {               
                this.tipoMensaje = tipo;
                this.detalleChat = detalle;
                this.remitente = remitente;
                this.destinatario = destinatario;
                this.contenido = contenido;
            }
            public Mensaje(TipoMensaje tipo, DetalleEstado detalle, String remitente, String destinatario, String contenido)
            {
                
                this.tipoMensaje = tipo;
                detalleEstado = detalle;
                this.remitente = remitente;
                this.destinatario = destinatario;
                this.contenido = contenido;
            }
            public Mensaje(TipoMensaje tipo, DetalleSolicitud detalle, String remitente, String destinatario, String contenido)
            {                
                this.tipoMensaje = tipo;
                detalleSolicitud = detalle;
                this.remitente = remitente;
                this.destinatario = destinatario;
                this.contenido = contenido;
            }
             public Mensaje(TipoMensaje tipo, DetalleServidor detalle, String destinatario, String contenido)
            {                
                this.tipoMensaje = tipo;
                this.detalleServidor = detalle;
                this.destinatario = destinatario;
                this.contenido = contenido;
            }
        #endregion

        #region Métodos           
        #endregion

    }

    
}
