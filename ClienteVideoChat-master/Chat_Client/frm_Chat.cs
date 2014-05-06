using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using UtileriasChat;

namespace Chat_Client
{
    public partial class frm_Chat : Form
    {
        public string Nickname { get;set;}
        public int Id { get; set; }
        public frm_Principal Padre;
        public Queue<Mensaje> QRecibidos;
        public string Contacto;
        public frm_Chat(string C,frm_Principal P)
        {
            Padre = P;
            Contacto = C;
            InitializeComponent();
            this.Text = this.Text.ToString() + Contacto;
            QRecibidos= new Queue<Mensaje>();
            tmr_Conversacion.Enabled = true;
        }
        private void frm_Chat_FormClosed(object sender, FormClosedEventArgs e)
        {
            string filename =Nickname + Contacto + DateTime.Now.Date.Year.ToString()+DateTime.Now.Date.Month.ToString()+DateTime.Now.Date.Day.ToString()+".txt";
            string directory = "Conversaciones//";
            StreamWriter SW;
            frm_Principal._lConversaciones.Remove(this);
            if (File.Exists(directory + filename))
            {
                SW=File.AppendText(directory + filename);                
            }
            else
            {
                SW=File.CreateText(directory + filename);
            }
            SW.Write(rtb_Contenido.Text);
            SW.Close();
        }
        public void MostrarMensaje()
        {
            while (QRecibidos.Count > 0)
            {
                Mensaje M = QRecibidos.Dequeue();
                rtb_Contenido.AppendText(M.Contenido);
            }
        }
        private void tmr_Conversacion_Tick(object sender, EventArgs e)
        {
            MostrarMensaje();
        }
        private void btn_Enviar_Click(object sender, EventArgs e)
        {
            //Mensaje Msj = new Mensaje(Mensaje.TipoDeMensaje.Message,Padre.Nickname,this.Nickname,this.txt_Contenido.Text,DateTime.Now);
             //frm_Principal._qMensajesAEnviar.Enqueue(Msj);
        }
    }
}
