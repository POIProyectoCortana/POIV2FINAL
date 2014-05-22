using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UtileriasChat;

namespace Chat_Client
{
    public partial class frm_ChatGrupal : Form
    {
        #region Campos
        private int sesionId;
        private List<Mensaje> lMensajes;
        private string sesionAlias;
        private Sesion grupo;       
        #endregion

        #region Constructor
        public frm_ChatGrupal(Sesion grupo)
        {           
            InitializeComponent();
            this.grupo = grupo;
            tmrConversacion.Enabled = true;
            tmrConversacion.Interval = 1000;
            lMensajes = new List<Mensaje>();
            this.SesionAlias = grupo.SessionAlias;
        }
        #endregion

        #region Propiedades
        public List<Mensaje> LMensajes
        {
            get { return lMensajes; }
            set { lMensajes = value; }
        }
        public int SesionId
        {
            get { return sesionId; }
            set { sesionId = value; }
        }
        public string SesionAlias
        {
            get { return sesionAlias; }
            set { sesionAlias = value; }
        }
        public Sesion Grupo
        {
            get { return grupo; }
            set { grupo = value; }
        }
        #endregion

        #region Metodos
        #endregion

        #region Eventos
        private void frm_ChatGrupal_Load(object sender, EventArgs e)
        {
            this.Text = Grupo.SessionAlias;
            foreach(string integ in grupo.Integrantes)
            {
                lstIntegrantes.Items.Add(integ);
            }
        }
        private void tmrConversacion_Tick(object sender, EventArgs e)
        {
            while(LMensajes.Count>0)
            {
                Mensaje msj = LMensajes[0];
                LMensajes.RemoveAt(0);
                rtbChat.PrintRTB(msj);
            }
        }
        #endregion   

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            Mensaje msj = new Mensaje()
            {
                Tipo = TipoMensaje.CHAT,
                DetalleChat = DetalleChat.TEXTO_GRUPAL,
                GrupoId = this.SesionId,
                Contenido = txtChat.Text,
                Remitente= frm_Principal.userContact
            };
            frm_Principal._lMensajesAEnviar.Add(msj);
            txtChat.Text = "";
        }

        private void frm_ChatGrupal_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_Principal.QuitarVentanaGrupo(this.SesionId);
        }
    }
}
