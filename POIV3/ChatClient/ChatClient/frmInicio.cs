using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UtileriasChat;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ChatClient
{
    public partial class frmInicio : Form
    {
        #region Campos
        public static List<Mensaje> ColaMensajesSalida = new List<Mensaje>();
        public static List<Contacto> Usuarios= new List<Contacto>();
        public static List<frmChat> Ventanas= new List<frmChat>();
        public static List<frmGrupo> VentanasGrupal= new List<frmGrupo>();

        private frmAcceso padre;              
        string user;
        private bool encriptacion;
        private IFormatter serializador;        
        private NetworkStream serverStream;       
        private DetalleEstado estado;        
        private TcpClient tcpClientServer;       
        private List<Mensaje> colaMensajesEntrada;   
        private List<Grupo> grupos;        
        #endregion

        #region Propiedades
        public string User
        {
            get { return user; }
            set { user = value; }
        }        
        public  List<Mensaje> ColaMensajesEntrada
        {
            get { return colaMensajesEntrada; }
            set { colaMensajesEntrada = value; }
        }
        public TcpClient TcpClientServidor
        {
            get { return tcpClientServer; }
            set
            {
                tcpClientServer = value;
                serverStream = tcpClientServer.GetStream();
            }
        }
        public bool Encriptacion
        {
            get { return encriptacion; }
            set { encriptacion = value; }
        }
        public List<Grupo> Grupos
        {
            get { return grupos; }
            set { grupos = value; }
        }
        public frmAcceso Padre
        {
            get { return padre; }
            set { padre = value; }
        } 
        public DetalleEstado Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public NetworkStream ServerStream
        {
            get { return serverStream; }
            set { serverStream = value; }
        }
        public IFormatter Serializador
        {
            get { return serializador; }
            set { serializador = value; }
        }
        #endregion

        #region Constructores
        public frmInicio()
        {
            InitializeComponent();
            colaMensajesEntrada = new List<Mensaje>();
            frmInicio.Ventanas = new List<frmChat>();
            grupos = new List<Grupo>();
            frmInicio.VentanasGrupal = new List<frmGrupo>();
            encriptacion = false;
            estado = DetalleEstado.DISPONIBLE;
            serializador = new BinaryFormatter();
            WriteData(new Contacto() {Estado= EstadoCliente.CONECTADO, Ip= Red.GetThisMachineIP(), Nombre=user});
        }
        #endregion

        #region Metodos
        private void WriteData(object data)
        {
            try
            {
                serializador.Serialize(serverStream, data);
                serverStream.Flush();
            }
            catch (Exception ex)
            {
                Alert(ex);
            }
        }
        private object ReadData()
        {
            try
            {
                object data = new object();
                data=serializador.Deserialize(serverStream);
                serverStream.Flush();
                return data;
            }
            catch (Exception ex)
            {
                Alert(ex);
                return null;
            }
        }
        public void ProcesarMensaje(Mensaje msj)
        {
            switch (msj.Tipo)
            {
                case TipoMensaje.SERVIDOR:
                    ProcesarServidor(msj);
                    break;
                case TipoMensaje.CHAT:
                    ProcesarChat(msj);
                    break;
                case TipoMensaje.ESTADO:
                    break;
                case TipoMensaje.SOLICITUD:
                    break;
            }
        }
        public void ProcesarServidor(Mensaje msj)
        {
            switch (msj.DetalleServidor)
            {
                case DetalleServidor.NUEVO_CONECTADO:
                    break;
                case DetalleServidor.NUEVO_GRUPO:
                    break;
            }
        }
        public void ProcesarChat(Mensaje msj)
        {
            switch (msj.DetalleChat)
            {
                case DetalleChat.TEXTO:
                case DetalleChat.ZUMBIDO:
                    if (msj.Destinatario == Red.BROADCAST)
                    {
                        rtbChatGeneral.PrintRTB(msj);
                    }
                    else
                    {
                        DeliverChat(msj);
                    }
                    break;
                case DetalleChat.TEXTO_GRUPAL:
                case DetalleChat.ZUMBIDO_GRUPAL:
                    DeliverGrupo(msj);
                    break;
            }
        }
        private void DeliverChat(Mensaje msj)
        {
            try
            {
                frmChat ventana = frmInicio.Ventanas.Find(
                    delegate(frmChat chat)
                    {return chat.Contacto.Nombre == msj.Remitente;});
                if (ventana != null)
                {
                    ventana.ColaMensajes.Add(msj);
                }
                else
                {
                    frmChat nuevaVentana = new frmChat();
                    nuevaVentana.Contacto = Usuarios.Find(
                        delegate(Contacto usuario)
                        { return usuario.Nombre == msj.Remitente;});
                    frmInicio.Ventanas.Add(nuevaVentana);
                    frmInicio.Ventanas[frmInicio.Ventanas.IndexOf(nuevaVentana)].ColaMensajes.Add(msj);
                    frmInicio.Ventanas[frmInicio.Ventanas.IndexOf(nuevaVentana)].Show();                    
                }
            }
            catch(Exception ex)
            {
                Alert(ex);
            }
        }
        private void DeliverGrupo(Mensaje msj)
        {
            try
            {
                frmGrupo ventana = frmInicio.VentanasGrupal.Find(
                    delegate(frmGrupo chat)
                    { return chat.Grupo.Id == msj.GrupoId; });
                if (ventana != null)
                {
                    ventana.ColaMensajes.Add(msj);
                }
                else
                {
                    frmGrupo nuevaVentana = new frmGrupo();
                    nuevaVentana.Grupo = grupos.Find(
                        delegate(Grupo usuario)
                        { return usuario.Id == msj.GrupoId; });
                    frmInicio.VentanasGrupal.Add(nuevaVentana);
                    frmInicio.VentanasGrupal[frmInicio.VentanasGrupal.IndexOf(nuevaVentana)].ColaMensajes.Add(msj);
                    frmInicio.VentanasGrupal[frmInicio.VentanasGrupal.IndexOf(nuevaVentana)].Show();
                }
            }
            catch (Exception ex)
            {
                Alert(ex);
            }
        }
        public static void RemoveVentanaGrupo(int grupoId)
        {
            frmGrupo ventana = frmInicio.VentanasGrupal.Find(
               delegate(frmGrupo chat)
               {
                   return chat.Grupo.Id == grupoId;
               }
               );
            if (ventana != null)
            {
                frmInicio.VentanasGrupal.RemoveAt(frmInicio.VentanasGrupal.IndexOf(ventana));
            }
        }
        public static void RemoveVentana(string alias)
        {
            frmChat ventana = frmInicio.Ventanas.Find(
               delegate(frmChat chat)
               {
                   return chat.Contacto.Nombre == alias;
               }
               );
            if (ventana != null)
            {
                frmInicio.Ventanas.RemoveAt(frmInicio.Ventanas.IndexOf(ventana));
            }
        }
        private void Alert(Exception ex)
        {
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region Eventos
        private void activadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mnuOpciones.Items[0].BackColor = System.Drawing.Color.Bisque;
            this.encriptacion = true;
        }
        private void desactivadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.encriptacion = false;
        }
        private void btnChatGeneral_Click(object sender, EventArgs e)
        {
            ColaMensajesSalida.Add(new Mensaje(){
                 Destinatario=Red.BROADCAST,
                 Encriptado=encriptacion,
                 Contenido=txtChatGeneral.Text,
                 Remitente=user
            });
            txtChatGeneral.Text = "";
        }
        private void frmInicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Close();
            serverStream.Close();
            tcpClientServer.Close();
            padre.Show();

        }
        #endregion  

        

        

        
    }
}
