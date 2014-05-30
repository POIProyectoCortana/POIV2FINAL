using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using UtileriasChat;
using System.IO;

namespace ChatServer
{
    public partial class frmPrincipal : Form
    {
        #region Campos       
        private int generadorIdGrupo;
        private List<Contacto> listaContactos;
        private List<ClienteRed> conexiones;
        private List<Mensaje> colaMensajes;
        private TcpListener serverListener;
        #endregion

        #region Propiedades
        public int GeneradorIdGrupo
        {
            get { return generadorIdGrupo; }
            set { generadorIdGrupo = value; }
        }
        public List<Contacto> ListaContactos
        {
            get { return listaContactos; }
            set { listaContactos = value; }
        }
        public List<Mensaje> ColaMensajes
        {
            get { return colaMensajes; }
            set { colaMensajes = value; }
        }
        #endregion

        #region Constructores
        public frmPrincipal()
        {
            InitializeComponent();
            txtServidor.Text = Red.GetThisMachineIP().ToString();
        }
        #endregion        
       
        #region Metodos
        public void Listener()
        {
            try
            {
                while (serverListener.Pending())                
                {
                    TcpClient NewTCPClient = serverListener.AcceptTcpClient();
                    ClienteRed NewClient = new ClienteRed(this,NewTCPClient);
                    Contacto data = NewClient.GetClientData();
                    listaContactos.Add(data);
                    conexiones.Add(NewClient);
                    int index = conexiones.IndexOf(NewClient);
                    conexiones[index].Start();                   
                }
            }
            catch(Exception ex)
            {
                WriteLog(ex);
            }
        }
        public void WriteLog(Exception ex)
        {
            this.txtLog.Text += DateTime.Now + "--" + ex.Message + Environment.NewLine;
        }
        public void WriteLog(string ex)
        {
            
            this.txtLog.Text += DateTime.Now + "--" + ex + Environment.NewLine;
        }
        #endregion

        #region Eventos
        private void btnIniciarServidor_Click(object sender, EventArgs e)
        {
            if (btnIniciarServidor.Text.Equals("Iniciar"))
            {
                int puerto;
                if (Int32.TryParse(txtPuerto.Text, out puerto))
                {
                    serverListener = new TcpListener(new IPEndPoint(Red.GetThisMachineIP(), puerto));
                    serverListener.Start();
                    btnIniciarServidor.Text = "Detener";
                    WriteLog("Servidor iniciado");
                    txtPuerto.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Introduzca un puerto valido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                serverListener.Stop();
                WriteLog("Servidor detenido");
                btnIniciarServidor.Text = "Iniciar";
                txtPuerto.Enabled = true;
            }
        }
        #endregion            
    }
}
