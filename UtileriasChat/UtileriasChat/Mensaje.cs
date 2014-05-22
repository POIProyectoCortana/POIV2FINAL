using System;
using System.Drawing;
using System.Windows.Forms;

namespace UtileriasChat
{
    public enum TipoMensaje
    {
        NULL,
        SOLICITUD,
        SERVIDOR,
        CHAT,        
        ESTADO        
    }
    public enum DetalleSolicitud
    {
        NULL,
        VIDEO_CONECTAR,
        VIDEO_DESCONECTAR,
        VIDEO_OK,
        ARCHIVO_CONECTAR,
        ARCHIVO_DESCONECTAR,
        ARCHIVO_OK
    }
    public enum DetalleChat
    {
        NULL,
        TEXTO,
        ZUMBIDO,
        TEXTO_GRUPAL,
        ZUMBIDO_GRUPAL
    }
    public enum DetalleEstado
    {
        NULL,
        DISPONIBLE,
        OCUPADO,
        AUSENTE
    }
    public enum DetalleServidor
    {
        NULL,
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
            private TipoMensaje _tipo;
            private DetalleChat _detalleChat;            
            private DetalleEstado _detalleEstado;            
            private DetalleServidor _detalleServidor;           
            private DetalleSolicitud _detalleSolicitud;            
            private Contacto _remitente;            
            private Contacto _destinatario;            
            private String _contenido;
            private bool _esEncriptado;
            private int _grupoId;          
           
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
        #endregion

       
        #region Propiedades
        public TipoMensaje Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        public String Contenido
        {
            get { return _contenido; }
            set { _contenido = value; }
        }
        public Contacto Destinatario
        {
            get { return _destinatario; }
            set { _destinatario = value; }
        }
        public DetalleSolicitud DetalleSolicitud
        {
            get { return _detalleSolicitud; }
            set { _detalleSolicitud = value; }
        }
        public Contacto Remitente
        {
            get { return _remitente; }
            set { _remitente = value; }
        }
        public DetalleServidor DetalleServidor
        {
            get { return _detalleServidor; }
            set { _detalleServidor = value; }
        }
        public DetalleEstado DetalleEstado
        {
            get { return _detalleEstado; }
            set { _detalleEstado = value; }
        }
        public DetalleChat DetalleChat
        {
            get { return _detalleChat; }
            set { _detalleChat = value; }
        }
        public bool EsEncriptado
        {
            get { return _esEncriptado; }
            set { _esEncriptado = value; }
        }
        public int GrupoId
        {
            get { return _grupoId; }
            set { _grupoId = value; }
        }
        #endregion

        #region Constructores
            public Mensaje()
            {
                Inicializar();
               
            }
             public Mensaje(TipoMensaje tipo, DetalleChat detalle, Contacto remitente, Contacto destinatario, String contenido)
            {
                Inicializar();
                _tipo = tipo;
                _detalleChat = detalle;
                _remitente = remitente;
                _destinatario = destinatario;
                _contenido = contenido;
            }
             public Mensaje(TipoMensaje tipo, DetalleEstado detalle, Contacto remitente, Contacto destinatario, String contenido)
            {
                Inicializar();
                _tipo = tipo;
                _detalleEstado = detalle;
                _remitente = remitente;
                _destinatario = destinatario;
                _contenido = contenido;
            }
             public Mensaje(TipoMensaje tipo, DetalleSolicitud detalle, Contacto remitente, Contacto destinatario, String contenido)
            {
                Inicializar();
                _tipo = tipo;
                _detalleSolicitud = detalle;
                _remitente = remitente;
                _destinatario = destinatario;
                _contenido = contenido;
            }
             public Mensaje(TipoMensaje tipo, DetalleServidor detalle, Contacto destinatario, String contenido)
            {
                Inicializar();
                _tipo = tipo;
                _detalleServidor = detalle;
                _destinatario = destinatario;
                _contenido = contenido;
            }
        #endregion

        #region Métodos
             public static void PrintMessageWithEmoticon(System.Windows.Forms.RichTextBox rtb_cointainer, string msj)
             {

                 int TextAlreadyLength = rtb_cointainer.TextLength;
                 rtb_cointainer.AppendText(msj);
                 for (int i = 0; i < EmoticonList.Length / 3; i++)
                 {
                     int indexfound = 0;
                     int indexNext = 0;
                     int EmoticonLength = EmoticonList[i, 0].Length;
                     //bool found = true;
                     while (true)
                     {
                         indexfound = msj.IndexOf(EmoticonList[i, 0], indexNext);
                         if (indexfound >= 0)
                         {
                             Bitmap image = new Bitmap(EmoticonList[i, 1]);
                             System.Windows.Forms.Clipboard.SetDataObject(image);
                             rtb_cointainer.Select(indexfound + TextAlreadyLength, EmoticonLength);
                             rtb_cointainer.Paste();
                             indexNext += EmoticonLength;
                         }
                         else { break; }
                     }
                 }
             }
            private void Inicializar()
            {
                _contenido = "";
                _destinatario = null;
                _detalleChat = DetalleChat.NULL;
                _detalleEstado = DetalleEstado.NULL;
                _detalleServidor = DetalleServidor.NULL;
                _detalleSolicitud = DetalleSolicitud.NULL;
                _esEncriptado = false;
                _remitente = null;
                _tipo = TipoMensaje.NULL;
            }
           
        #endregion

    }

    
}
