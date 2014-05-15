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
        NUEVO_SESION,
        NUEVO_SESION_CONECTADO,
        NUEVO_SESION_DESCONECTADO,
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
           
            public static readonly string[,] EmoticonList =
            {
                {":)","Emoticons\\bored.bmp",""},
                {";)","Emoticons\\bored.bmp",""},
                {":p","Emoticons\\bored.bmp",""},
                {":D","Emoticons\\bored.bmp",""},
                {":3","Emoticons\\bored.bmp",""},
                {"XD","Emoticons\\bored.bmp",""},
                {"DX","Emoticons\\bored.bmp",""},
                {"X3","Emoticons\\bored.bmp",""},
                {"(Y)","Emoticons\\bored.bmp",""},
                {"(L)","Emoticons\\bored.bmp",""},
                {"\0/","Emoticons\\bored.bmp",""},
                {"DX","Emoticons\\bored.bmp",""},
                {"DX","Emoticons\\bored.bmp",""},
                {"DX","Emoticons\\bored.bmp",""}
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
