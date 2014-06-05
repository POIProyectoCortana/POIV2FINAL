using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class frmAcceso : Form
    {
        #region Campos
        TcpClient tcpClientServer;
        frmInicio mainScreen;        
        #endregion

        #region Propiedades
        public TcpClient TcpClientServer
        {
            get { return tcpClientServer; }
            set { tcpClientServer = value; }
        }
        public frmInicio MainScreen
        {
            get { return mainScreen; }
            set { mainScreen = value; }
        }
        #endregion

        #region Constructores
        public frmAcceso()
        {
            InitializeComponent();
            tcpClientServer = new TcpClient();
            mainScreen = new frmInicio();
        }
        #endregion

       

        #region Metodos
        #endregion

        #region Eventos
        private void btn_Conectar_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress ip;
                int puerto;
                if (txtUsuario.Text.Equals(""))
                {
                    throw new Exception("El Nickname de identificación no debe estar vacío.");
                }
                else if (!IPAddress.TryParse(txtIPServidor.Text, out ip))
                {
                    throw new Exception("La IP de servidor no es válida.");
                }
                else if (!Int32.TryParse(txtPuerto.Text, out puerto))
                {
                    throw new Exception("El puerto de servidor no es válido.");
                }
                else
                {
                    tcpClientServer.Connect(ip, puerto);
                    mainScreen.TcpClientServidor = tcpClientServer;
                    mainScreen.User = txtUsuario.Text;
                    this.Hide();
                    mainScreen.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK);
            }
        }
        #endregion
       

     
    }
}
