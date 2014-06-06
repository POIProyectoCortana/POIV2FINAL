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
        #endregion

        #region Propiedades             
        #endregion

        #region Constructores
        public frmAcceso()
        {
            InitializeComponent();
            tcpClientServer = new TcpClient();            
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
                    TcpClient tcpServer= new TcpClient();
                    if (tcpServer != null)
                    {
                        tcpServer.Connect(ip, puerto);
                        frmInicio main = new frmInicio(tcpServer, txtUsuario.Text);
                        main.Padre = this;
                        this.Hide();
                        main.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        #endregion
       

     
    }
}
