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

namespace Chat_Server
{
    public partial class frm_ : Form
    {
        bool Encendido;
        TcpListener ServerListener;
        IPAddress ServerAddress;
        public frm_()
        {
            Encendido = false;
            InitializeComponent();
            ServerAddress = IPAddress.Parse(GetThisMachineIP());
            ServerListener = new TcpListener(ServerAddress, 1234);    
            this.lbl_DataServer.Text= "IP: "+GetThisMachineIP()+" \n Puerto: 1234";
        }

        private void lbl_Estado_Click(object sender, EventArgs e)
        {

        }

        private void btn_Iniciar_Click(object sender, EventArgs e)
        {
            if (!Encendido)
            {
                //aqui se inicia el servidor
                try
                {
                    ServerListener.Start();
                    Encendido = !Encendido;
                    lbl_DEstado.Text = "Encendido";
                    lbl_DEstado.ForeColor = System.Drawing.Color.DarkGreen;
                    lbl_DEstado.BackColor = System.Drawing.Color.LightGreen;
                    btn_Iniciar.Text = "Detener";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"ERROR",MessageBoxButtons.OK);                    
                }
                
            }
            else
            {
                try
                {
                    ServerListener.Stop();
                    Encendido = !Encendido;
                    lbl_DEstado.Text = "Apagado";
                    lbl_DEstado.ForeColor = System.Drawing.Color.DarkRed;
                    lbl_DEstado.BackColor = System.Drawing.Color.LightCoral;
                    btn_Iniciar.Text = "Iniciar"; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK);             
                }
            }
        }
        public string GetThisMachineIP()
        {
            IPHostEntry Host;
            string localIP = "";
            Host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in Host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }
    }
}
