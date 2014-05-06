using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;


namespace Chat_Client
{
    public partial class frm_Conectar : Form
    {
        TcpClient _serverSocket;
        public frm_Conectar()
        {
            InitializeComponent();  
        }
        private void frm_Conectar_Load(object sender, EventArgs e)
        {

        }
        private void btn_Conectar_Click(object sender, EventArgs e)
        {
            try
            {                
                if(this.txt_Nickname.Text =="" ||  this.txt_Nickname.Text== null)
                {
                    throw new Exception("El Nickname de identificación no debe estar vacío. No se ha podido iniciar la conexión");
                }
                else
                {                   
                    _serverSocket = new TcpClient();
                    _serverSocket.Connect(IPAddress.Parse(txt_IPServidor.Text), Convert.ToInt32(txt_Puerto.Text));
                    frm_Principal MainScreen = new frm_Principal(_serverSocket, txt_Nickname.Text, txt_IPServidor.Text, txt_Puerto.Text, this);                                      
                    this.Hide();
                    MainScreen.Show(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"ERROR",MessageBoxButtons.OK);              
            }
            
        }
        private void frm_Conectar_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
       
    }
}
