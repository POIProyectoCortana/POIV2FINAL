using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UtileriasChat;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace ChatClient
{
    public partial class frmChat : Form
    {
        #region Campos
        private Contacto contacto;
        private string user;      
        private List<Mensaje> colaMensajes;
        private OpenFileDialog ofd;
        private TcpClient tcpSendFile;
        private TcpListener tcpReciveFile;
        #endregion

        #region Propiedades
        public Contacto Contacto
        {
            get { return contacto; }
            set 
            {
                this.Text = contacto.Nombre;
                contacto = value;
                ////Video Sender
                //vidSender.VideoDevice = 0;
                //vidSender.VideoDevice = 0;
                //vidSender.AudioDevice = 0;
                //vidSender.VideoFormat = 0;
                //vidSender.FrameRate = 16;
                //vidSender.VideoBitrate = 128000;
                //vidSender.AudioComplexity = 0;
                //vidSender.AudioQuality = 8;
                //vidSender.SendAudioStream = true;
                //vidSender.SendVideoStream = true;
                ////Video Reciber
                //vidReciver.ReceiveAudioStream = true;
                //vidReciver.ReceiveVideoStream = true;  
            }
        }
        public List<Mensaje> ColaMensajes
        {
            get { return colaMensajes; }
            set { colaMensajes = value; }
        }
        public string User
        {
            get { return user; }
            set { user = value; }
        }
        #endregion

        #region Constructores
        public frmChat()
        {
            InitializeComponent();
            contacto = new Contacto();
            colaMensajes = new List<Mensaje>();
            desactivarToolStripMenuItem.Checked = true;      
        } 
        #endregion       

        #region Metodos
        private void ProcesarMensaje(Mensaje msj)
        {
            switch(msj.Tipo)
            {
                case TipoMensaje.CHAT:
                    ProcesarChat(msj);
                    break;
                case TipoMensaje.SOLICITUD:
                    ProcesarSolicitud(msj);
                    break;
            }
        }
        private void ProcesarSolicitud(Mensaje msj)
        { 
            switch(msj.DetalleSolicitud)
            {
                case DetalleSolicitud.ARCHIVO_CONECTAR:
                    tcpReciveFile = new TcpListener(Red.GetThisMachineIP(),2090);
                    tcpReciveFile.Start(1);
                    if (tcpReciveFile.Pending())
                    {
                        TcpClient client = tcpReciveFile.AcceptTcpClient();

                    }
                    break;
                case DetalleSolicitud.VIDEO_CONECTAR:
                    ActivarVideoChat();
                    activarToolStripMenuItem.Checked = true;
                    desactivarToolStripMenuItem.Checked=false;
                    break;
                case DetalleSolicitud.VIDEO_DESCONECTAR:
                    DesactivarVideoChat();
                    desactivarToolStripMenuItem.Checked = true;
                    activarToolStripMenuItem.Checked = false;
                    break;
            }
        }
        private void ProcesarChat(Mensaje msj)
        {
            switch (msj.DetalleChat)
            {
                case DetalleChat.TEXTO:
                    Sounds.MessageAlert();
                    rtbContenido.PrintRTB(msj);
                    break;
                case DetalleChat.ZUMBIDO:
                    Sounds.Buzz();
                    rtbContenido.AppendText(msj.Remitente + " ha enviado un buzz!" + Environment.NewLine);
                    break;
            }
        }
        private void Alert(Exception ex)
        {
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void ActivarVideoChat()
        {
            try
            {
                if (!frmInicio.VideollamadaActiva)
                {
                    //vidSender.Connect(contacto.Ip.ToString(), 1235);
                    //vidReciver.Listen(Red.GetThisMachineIP().ToString(), 1234);
                    frmInicio.VideollamadaActiva = true;
                    activarToolStripMenuItem.Checked = true;
                    desactivarToolStripMenuItem.Checked = false;
                }
                else
                {
                    MessageBox.Show("Ya existe una sesion de videochat activa", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                Alert(ex);
            }
        }
        private void DesactivarVideoChat()
        {

            if (frmInicio.VideollamadaActiva)
            {
                Mensaje msj = new Mensaje()
                {
                    Tipo = TipoMensaje.SOLICITUD,
                    DetalleSolicitud = DetalleSolicitud.VIDEO_DESCONECTAR,
                    Remitente = user,
                    Destinatario = contacto.Nombre
                };
                frmInicio.ColaMensajesSalida.Add(msj);
                //vidSender.Disconnect();
                //vidReciver.Disconnect();
                frmInicio.VideollamadaActiva = false;
                activarToolStripMenuItem.Checked = false;
                desactivarToolStripMenuItem.Checked = true;
            }
        }
        #endregion

        #region Eventos
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {               
                if (!txtContenido.Text.Equals(""))
                {
                    Mensaje msj = new Mensaje()
                    {
                        Tipo = TipoMensaje.CHAT,
                        DetalleChat = DetalleChat.TEXTO,
                        Destinatario = contacto.Nombre,
                        Remitente = user,
                        Contenido = txtContenido.Text,
                        Encriptado=frmInicio.Encriptacion
                    };
                    if (frmInicio.Encriptacion)
                    { msj.Encriptar(); }
                    frmInicio.ColaMensajesSalida.Add(msj);
                    rtbContenido.PrintRTB(msj);
                }
            }
            catch (Exception ex)
            {
                Alert(ex);
            }
        }
        private void btnBuzz_Click(object sender, EventArgs e)
        {
            try
            {
                Mensaje msj = new Mensaje()
                {
                    Tipo = TipoMensaje.CHAT,
                    DetalleChat = DetalleChat.ZUMBIDO,
                    Destinatario = contacto.Nombre,
                    Remitente = user,
                    Contenido = txtContenido.Text,
                };
                frmInicio.ColaMensajesSalida.Add(msj);
                rtbContenido.AppendText(msj.Remitente + " ha enviado un buzz!" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Alert(ex);
            }
        }
        private void frmChat_Load(object sender, EventArgs e)
        {
            tmrPerformance.Enabled = true;
        }
        private void tmrPerformance_Tick(object sender, EventArgs e)
        {
            try
            {
                while (colaMensajes.Count > 0)
                {
                    Mensaje msj=colaMensajes[0];
                    colaMensajes.RemoveAt(0);
                    ProcesarMensaje(msj);                    
                }
            }
            catch (Exception ex)
            {
                Alert(ex);
            }
        }
        private void limpiarHistorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbContenido.Text = "";
        }
        private void enviarConversacionAUnArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                rtbContenido.SendToFile(contacto.Nombre);
                rtbContenido.Text = "";
            }
            catch (Exception ex)
            {
                Alert(ex);
            }
        }
        private void frmChat_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmInicio.RemoveVentana(contacto.Nombre);
        }
        private void txtContenido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEnviar_Click(null, null);
                txtContenido.Select(0, 0);
            }
        }
        private void activarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mensaje msj = new Mensaje()
            {
                Tipo = TipoMensaje.SOLICITUD,
                DetalleSolicitud = DetalleSolicitud.VIDEO_CONECTAR,
                Remitente = user,
                Destinatario = contacto.Nombre
            };
            frmInicio.ColaMensajesSalida.Add(msj);
            ActivarVideoChat();
        }
        private void desactivarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DesactivarVideoChat();
        }
        private void enviarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mensaje msj = new Mensaje()
            {
                Tipo= TipoMensaje.SOLICITUD,
                Destinatario=contacto.Nombre,
                DetalleSolicitud= DetalleSolicitud.ARCHIVO_CONECTAR,
                Remitente=user
            };
            frmInicio.ColaMensajesSalida.Add(msj);
            ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(ofd.FileName);
                    string fileI = fileInfo.Name + "|" + fileInfo.Length;
                    tcpSendFile = new TcpClient();
                    tcpSendFile.Connect(contacto.Ip, 2090);
                    StreamWriter sw = new StreamWriter(tcpSendFile.GetStream());
                    sw.WriteLine(fileI);
                    sw.Flush();
                    sw.Close();
                    Stream s= tcpSendFile.GetStream();
                    byte[] data= File.ReadAllBytes(ofd.FileName);
                    s.Write(data,0, data.Length);
                    tcpSendFile.Close();
                }
                catch(Exception ex)
                {
                    Alert(ex);
                }
                
            }
            else
            {
                Mensaje msj2 = new Mensaje()
                {
                    Tipo = TipoMensaje.SOLICITUD,
                    Destinatario = contacto.Nombre,
                    DetalleSolicitud = DetalleSolicitud.ARCHIVO_DESCONECTAR,
                    Remitente = user
                };
                frmInicio.ColaMensajesSalida.Add(msj2);
            }
        }
        #endregion  

        
    }
}
