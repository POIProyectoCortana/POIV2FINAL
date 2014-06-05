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

namespace ChatClient
{
    public partial class frmChat : Form
    {
        #region Campos
        private Contacto contacto;
        private string user;      
        private List<Mensaje> colaMensajes;             
        #endregion

        #region Propiedades
        public Contacto Contacto
        {
            get { return contacto; }
            set { contacto = value; }
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
                    break;
                case DetalleSolicitud.VIDEO_CONECTAR:
                    break;
            }
        }
        private void ProcesarChat(Mensaje msj)
        {
            switch (msj.DetalleChat)
            {
                case DetalleChat.TEXTO:
                    rtbContenido.PrintRTB(msj);
                    break;
                case DetalleChat.ZUMBIDO:
                    //Sounds.Buzz("");
                    break;
            }
        }
        private void Alert(Exception ex)
        {
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region Eventos
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtContenido.Text.Equals(""))
                {
                    frmInicio.ColaMensajesSalida.Add(new Mensaje()
                    {
                        Tipo = TipoMensaje.CHAT,
                        DetalleChat = DetalleChat.TEXTO,
                        Destinatario = contacto.Nombre,
                        Remitente = user,
                        Contenido = txtContenido.Text,
                    });
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
                frmInicio.ColaMensajesSalida.Add(new Mensaje()
                {
                    Tipo = TipoMensaje.CHAT,
                    DetalleChat = DetalleChat.ZUMBIDO,
                    Destinatario = contacto.Nombre,
                    Remitente = user,
                    Contenido = txtContenido.Text,
                });
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
                string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\Conversaciones\\";
                string fileName = contacto.Nombre + DateTime.Now.Date + DateTime.Now.TimeOfDay;
                File.Create(path + fileName);                
                StreamWriter sw = new StreamWriter(path + fileName);
                sw.Write(rtbContenido.Text);
                sw.Close();
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
        #endregion 
    }
}
