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
    public partial class frmGrupo : Form
    {
        #region Campos
        private string user;        
        private Grupo grupo;
        private List<Mensaje> colaMensajes;       
        #endregion

        #region Propiedades
        public Grupo Grupo
        {
            get { return grupo; }
            set { grupo = value; }
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
        public frmGrupo()
        {
            InitializeComponent();
            colaMensajes = new List<Mensaje>();
            grupo = new Grupo();
            tmrPerformance.Enabled = true;
        }
        #endregion        

        #region Metodos
        private void ProcesarMensaje(Mensaje msj)
        {
            switch (msj.Tipo)
            {
                case TipoMensaje.CHAT:
                    ProcesarChat(msj);
                    break;
                //case TipoMensaje.SOLICITUD:
                //    ProcesarSolicitud(msj);
                //    break;
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
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK);
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
                        DetalleChat = DetalleChat.TEXTO_GRUPAL,
                        GrupoId = grupo.Id,
                        Contenido = txtContenido.Text,
                        Remitente = user,
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
                    DetalleChat = DetalleChat.ZUMBIDO_GRUPAL,
                    Remitente = user,
                    GrupoId = grupo.Id,
                    Contenido = txtContenido.Text,
                });
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
                string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()))+"\\Conversaciones\\";
                string fileName = grupo.Alias + DateTime.Now.Date + DateTime.Now.TimeOfDay;
                File.Create(path + fileName);
                //FileStream fs=File.Open(path + fileName, FileMode.CreateNew, FileAccess.Write);
                StreamWriter sw = new StreamWriter(path + fileName);
                sw.Write(rtbContenido.Text);
                sw.Close();
            }
            catch (Exception ex)
            {
                Alert(ex); 
            }
        }
        private void tmrPerformance_Tick(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
