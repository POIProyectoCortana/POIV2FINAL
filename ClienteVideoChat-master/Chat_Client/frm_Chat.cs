using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using UtileriasChat;

namespace Chat_Client
{
    public partial class frm_Chat : Form
    {
        #region Campos
        private string nickname;
        private int id;
        public frm_Principal Padre;
        public List<Mensaje> QRecibidos;
        public string Contacto;
        private UtileriasChat.Contacto contactoChat;
        #endregion

        #region Propiedades
        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public Contacto ContactoChat
        {
            get { return contactoChat; }
            set { contactoChat = value; }
        }
        #endregion

        #region Constructores
        public frm_Chat(string C, frm_Principal P)
        {
            Padre = P;
            Contacto = C;
            InitializeComponent();
            this.Text = this.Text.ToString() + Contacto;
            QRecibidos = new List<Mensaje>();
            tmr_Conversacion.Enabled = true;
            contactoChat = new Contacto() { Username = C };
        }
        #endregion

        #region Metodos
        public void MostrarMensaje()
        {
            while (QRecibidos.Count > 0)
            {
                Mensaje M = QRecibidos[0];
                rtb_Contenido.PrintRTB(M);
                QRecibidos.RemoveAt(0);
            }
        }
        #endregion

        #region Eventos
        private void frm_Chat_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                string filename = Nickname + Contacto + DateTime.Now.Date.Year.ToString() + DateTime.Now.Date.Month.ToString() + DateTime.Now.Date.Day.ToString() + ".txt";
                string directory = "Conversaciones//";
                StreamWriter SW;
                frm_Principal.Conversaciones.Remove(this);
                if (File.Exists(directory + filename))
                {
                    SW = File.AppendText(directory + filename);
                }
                else
                {
                    SW = File.CreateText(directory + filename);
                }
                SW.Write(rtb_Contenido.Text);
                SW.Close();
            }
            catch (Exception)
            {

            }
            finally
            {
                frm_Principal.QuitarVentana(this.Nickname);
            }
        }
        private void tmr_Conversacion_Tick(object sender, EventArgs e)
        {
            MostrarMensaje();
        }
        private void btn_Enviar_Click(object sender, EventArgs e)
        {
            Mensaje Msj;
            Msj = new Mensaje()
            {
                Tipo = TipoMensaje.CHAT,
                DetalleChat = DetalleChat.TEXTO,
                Destinatario = ContactoChat,
                Contenido = txt_Contenido.Text,
                Remitente = frm_Principal.userContact
            };
            frm_Principal._lMensajesAEnviar.Add(Msj);
            rtb_Contenido.PrintRTB(Msj);
        }
        private void frm_Chat_Load(object sender, EventArgs e)
        {

        }
        #endregion      

        private void button3_Click(object sender, EventArgs e)
        {
            //axVideoChatSender1.VideoDevice = 0;
            //axVideoChatSender1.AudioDevice = 0;
            //axVideoChatSender1.VideoFormat = 0;
            //axVideoChatSender1.FrameRate = 16;
            //axVideoChatSender1.VideoBitrate = 128000;
            //axVideoChatSender1.AudioComplexity = 0;
            //axVideoChatSender1.AudioQuality = 8;
            //axVideoChatSender1.SendAudioStream = true;
            //axVideoChatSender1.SendVideoStream = true;

            //axVideoChatSender1.Connect("127.0.0.1", 1234);

            //axVideoChatReceiver1.ReceiveAudioStream = true;
            //axVideoChatReceiver1.ReceiveVideoStream = true;

            //axVideoChatReceiver1.Listen("127.0.0.1", 1234);
        }
        
        
        

       
       
        
        
    }
}
