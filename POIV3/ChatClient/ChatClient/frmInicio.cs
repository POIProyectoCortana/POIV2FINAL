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
        internal static bool Encriptacion=false;
        internal static bool VideollamadaActiva = false;
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
        public frmInicio(TcpClient tcp,string user)
        {
            InitializeComponent();
            colaMensajesEntrada = new List<Mensaje>();
            frmInicio.Ventanas = new List<frmChat>();
            grupos = new List<Grupo>();
            frmInicio.VentanasGrupal = new List<frmGrupo>();
            estado = DetalleEstado.DISPONIBLE;
            serializador = new BinaryFormatter();
            tcpClientServer = tcp;
            User = user;
            serverStream = tcpClientServer.GetStream();
            WriteData(new Contacto() {Estado= EstadoCliente.CONECTADO, Ip= Red.GetThisMachineIP(), Nombre=user});
            dynamic obj = ReadData();
            Usuarios = obj;
            BindUserList(Usuarios);
            tmrPerformance.Enabled = true;
            disponibleToolStripMenuItem.Checked = true;
            desactivarToolStripMenuItem.Checked = true;            
        }
        #endregion

        #region Metodos
        private void Listening()
        {
            while(serverStream.DataAvailable)
            {
                dynamic data = ReadData();
                Mensaje msj = new Mensaje()
                {
                    Contenido = data.Contenido,
                    Destinatario = data.Destinatario,
                    DetalleChat = data.DetalleChat,
                    DetalleEstado = data.DetalleEstado,
                    DetalleServidor = data.DetalleServidor,
                    DetalleSolicitud = data.DetalleSolicitud,
                    Encriptado = data.Encriptado,
                    GrupoId = data.GrupoId,
                    Remitente = data.Remitente,
                    Tipo = data.Tipo
                };
                colaMensajesEntrada.Add(msj);                
            }
        }
        private void Delivering()
        {
            while (colaMensajesEntrada.Count > 0)
            {
                Mensaje msj = colaMensajesEntrada[0];
                colaMensajesEntrada.RemoveAt(0);
                ProcesarMensaje(msj);
            }
        }
        private void Writening()
        {
            Mensaje msj = new Mensaje();
            while (ColaMensajesSalida.Count > 0)
            {
                msj = ColaMensajesSalida[0];
                ColaMensajesSalida.RemoveAt(0);
                WriteData(msj);
            }
        }
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
                    ProcesarEstado(msj);
                    break;
                case TipoMensaje.SOLICITUD:
                    DeliverChat(msj);
                    break;
            }
        }
        public void ProcesarServidor(Mensaje msj)
        {
            switch (msj.DetalleServidor)
            {
                case DetalleServidor.NUEVO_CONECTADO:
                    string[]data = msj.Contenido.Split('|');
                    Usuarios.Add(new Contacto() 
                        { Nombre = data[0], 
                            Ip = IPAddress.Parse(data[1]), 
                            Estado =(EstadoCliente)Enum.Parse(typeof(EstadoCliente), data[2]) });
                    BindUserList(Usuarios);
                    break;
                case DetalleServidor.NUEVO_GRUPO:
                    GenerateGroup(msj);
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
                        switch (msj.DetalleChat)
                        {
                            case DetalleChat.TEXTO:
                                Sounds.MessageAlert();
                                if (msj.Encriptado)
                                { msj.Desencriptar(); }
                                rtbChatGeneral.PrintRTB(msj);
                                
                                break;
                            case DetalleChat.ZUMBIDO:
                                Sounds.MessageAlert();
                                rtbChatGeneral.AppendText(msj.Remitente + " ha enviado un buzz!" + Environment.NewLine);
                                break;
                        }
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
        public void ProcesarEstado(Mensaje msj)
        {
            Contacto contacto = FindUsuario(msj.Remitente);
            if (contacto != null)
            {
                int index=Usuarios.IndexOf(contacto);
                Usuarios[index].EstadoChat = msj.DetalleEstado;
            }
            BindUserList(Usuarios);
        }
        private void DeliverChat(Mensaje msj)
        {
            try
            {
                frmChat ventana =FindVentana(msj.Remitente);                   
                if (ventana != null)
                {
                    ventana.ColaMensajes.Add(msj);
                }
                else
                {
                    frmChat nuevaVentana = new frmChat();
                    nuevaVentana.Contacto = FindUsuario(msj.Remitente);
                    nuevaVentana.User = user;  
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
                frmGrupo ventana = FindVentanaGrupo(msj.GrupoId); 
                if (ventana != null)
                {  ventana.ColaMensajes.Add(msj); }
                else
                {
                    frmGrupo nuevaVentana = new frmGrupo();
                    nuevaVentana.Grupo = FindGrupo(msj.GrupoId);
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
            frmGrupo ventana =   frmInicio.VentanasGrupal.Find(
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
        public void BindUserList(List<Contacto> usuarios)
        {
            lstConectados.Items.Clear();
            foreach (Contacto usuario in usuarios)
            {
                if(usuario.Nombre!=user)
                lstConectados.Items.Add(usuario.Nombre+"----"+usuario.EstadoChat.ToString());
            }
        }
        public void BindGroupList(List<Grupo> grupos)
        {
            lstGrupos.Items.Clear();            
            foreach (Grupo grupo in grupos)
            {
                lstGrupos.Items.Add(grupo.Alias); 
            }
        }
        public bool GenerateGroup(Mensaje msj)
        {
            try
            {
                List<string> data = new List<string>(msj.Contenido.Split('|'));
                string alias = data[0];
                data.RemoveAt(0);
                Grupo grupo = new Grupo(msj.GrupoId, alias);
                grupo.Integrantes = data;
                grupos.Add(grupo);
                BindGroupList(grupos);
                return true;
            }
            catch (Exception ex)
            {
                Alert(ex);
                return false;
            }
        }
        public Contacto FindUsuario(string usuario)
        {
            Contacto data=Usuarios.Find(
                delegate(Contacto cont)
                    {
                        return cont.Nombre==usuario;
                    }
                );
            return data;
        }
        public frmChat FindVentana(string usuario)
        {
            frmChat ventana = Ventanas.Find(
                       delegate(frmChat chat)
                       {
                           return chat.Contacto.Nombre == usuario;
                       }
            );
            return ventana;
        }
        public frmGrupo FindVentanaGrupo(string alias)
        {
            frmGrupo ventana = VentanasGrupal.Find(
                      delegate(frmGrupo chat)
                      {
                          return chat.Grupo.Alias == alias;
                      }
           );
            return ventana;
        }
        public frmGrupo FindVentanaGrupo(int id)
        {
            frmGrupo ventana = VentanasGrupal.Find(
                      delegate(frmGrupo chat)
                      {
                          return chat.Grupo.Id == id;
                      }
           );
            return ventana;
        }
        public Grupo FindGrupo(string alias)
        {
            Grupo grupo = grupos.Find(
                      delegate(Grupo grup)
                      {
                          return grup.Alias == alias;
                      }
           );
            return grupo;
        }
        public Grupo FindGrupo(int id)
        {
            Grupo grupo = grupos.Find(
                      delegate(Grupo grup)
                      {
                          return grup.Id == id;
                      }
           );
            return grupo;
        }
        private void Alert(Exception ex)
        {
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region Eventos
        private void btnChatGeneral_Click(object sender, EventArgs e)
        {
            if (!txtChatGeneral.Text.Equals(""))
            {
                Mensaje msj = new Mensaje()
                {
                    Destinatario = Red.BROADCAST,
                    Encriptado = frmInicio.Encriptacion,
                    Contenido = txtChatGeneral.Text,
                    Remitente = user,
                    Tipo = TipoMensaje.CHAT,
                    DetalleChat =DetalleChat.TEXTO
                };
                if (frmInicio.Encriptacion)
                { msj.Encriptar(); }
                ColaMensajesSalida.Add(msj);
                txtChatGeneral.Text = "";
            }
        }
        private void frmInicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            serverStream.Close();
            tcpClientServer.Close();
            padre.Show();
        }
        private void lstConectados_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (lstConectados.SelectedIndex >=0 )
                {
                    frmChat ventana = FindVentana(this.lstConectados.SelectedItem.ToString());
                    if (ventana == null)
                    {
                        frmChat NuevaVentana = new frmChat();
                        int index1=lstConectados.SelectedItem.ToString().IndexOf("-");
                        int index2=lstConectados.SelectedItem.ToString().Length -
                            lstConectados.SelectedItem.ToString().IndexOf("-");
                        string usuario = this.lstConectados.SelectedItem.ToString().Remove(index1,index2);
                        NuevaVentana.Contacto =FindUsuario(usuario);
                        NuevaVentana.User = user;
                        Ventanas.Add(NuevaVentana);
                        NuevaVentana.Show();
                    }
                    else
                    {
                        ventana.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Alert(ex); 
            }
        }
        private void lstGrupos_DoubleClick(object sender, EventArgs e)
        {
            try 
            {
                if (lstGrupos.SelectedIndex >=0)                
                {
                    frmGrupo chat = FindVentanaGrupo(lstGrupos.SelectedItem.ToString());
                    if (chat == null)
                    {
                        Grupo grup=FindGrupo(lstGrupos.SelectedItem.ToString());
                        frmGrupo ventana = new frmGrupo();
                        ventana.Grupo = grup;
                        VentanasGrupal.Add(ventana);
                        ventana.Show();
                    }
                    else
                    {
                        chat.Show();
                    }
                }
            }
            catch(Exception ex)
            {
                Alert(ex);
            }
        }
        private void tmrPerformance_Tick(object sender, EventArgs e)
        {
            Listening();
            Delivering();
            Writening();
        }
        private void txtChatGeneral_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnChatGeneral_Click(null, null);
                txtChatGeneral.Select(0, 0);
            }
        }
        private void disponibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mensaje msj = new Mensaje()
            {
                Destinatario = Red.BROADCAST,
                Encriptado = frmInicio.Encriptacion,
                Remitente = user,
                Tipo = TipoMensaje.ESTADO,
                DetalleEstado =DetalleEstado.DISPONIBLE            
            };
            ColaMensajesSalida.Add(msj);
            disponibleToolStripMenuItem.Checked = true;
            ocupadoToolStripMenuItem.Checked = false;
            ausenteToolStripMenuItem.Checked = false;
        }
        private void ocupadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mensaje msj = new Mensaje()
            {
                Destinatario = Red.BROADCAST,
                Encriptado = frmInicio.Encriptacion,
                Remitente = user,
                Tipo = TipoMensaje.ESTADO,
                DetalleEstado = DetalleEstado.OCUPADO
            };
            ColaMensajesSalida.Add(msj);
            ocupadoToolStripMenuItem.Checked = true;
            disponibleToolStripMenuItem.Checked = false;
            ausenteToolStripMenuItem.Checked = false;
        }
        private void ausenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mensaje msj = new Mensaje()
            {
                Destinatario = Red.BROADCAST,
                Encriptado = frmInicio.Encriptacion,
                Remitente = user,
                Tipo = TipoMensaje.ESTADO,
                DetalleEstado = DetalleEstado.AUSENTE
            };
            ColaMensajesSalida.Add(msj);
            ausenteToolStripMenuItem.Checked = true;
            disponibleToolStripMenuItem.Checked = false;
            ausenteToolStripMenuItem.Checked = false;
        }      
        private void btnBuzz_Click(object sender, EventArgs e)
        {
            Mensaje msj = new Mensaje()
            {
                Destinatario = Red.BROADCAST,
                Encriptado = frmInicio.Encriptacion,
                Contenido = "",
                Remitente = user,
                Tipo = TipoMensaje.CHAT,
                DetalleChat=DetalleChat.ZUMBIDO
            };
            ColaMensajesSalida.Add(msj);
        }
        private void nuevoGrupoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAGrupo ventana = new frmAGrupo();
            ventana.ShowDialog();
        }
        private void activarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInicio.Encriptacion = true;
            activarToolStripMenuItem.Checked = true;
            desactivarToolStripMenuItem.Checked = false;
        }
        private void desactivarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInicio.Encriptacion = false;
            desactivarToolStripMenuItem.Checked = true;
            activarToolStripMenuItem.Checked = false;
        }
        private void limpiarHistorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbChatGeneral.Text = "";
        }
        private void enviarConversaciónAUnArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbChatGeneral.SendToFile(Red.BROADCAST);
        }
        #endregion          
    }
}
