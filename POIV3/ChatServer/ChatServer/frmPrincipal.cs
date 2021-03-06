﻿using System;
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
        private List<Grupo> grupos;
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
        public List<Grupo> Grupo
        {
            get { return grupos; }
            set { grupos = value; } 
        }
        #endregion

        #region Constructores
        public frmPrincipal()
        {
            InitializeComponent();
            txtServidor.Text = Red.GetThisMachineIP().ToString();
            this.conexiones = new List<ClienteRed>();
            listaContactos = new List<Contacto>();
            colaMensajes = new List<Mensaje>();
            grupos = new List<Grupo>();
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
                    colaMensajes.Add(new Mensaje() 
                    { 
                        Destinatario=Red.BROADCAST, 
                        Tipo= TipoMensaje.SERVIDOR, 
                        DetalleServidor= DetalleServidor.NUEVO_CONECTADO ,
                        Contenido=data.Nombre+"|"+data.Ip.ToString()+"|"+data.Estado.ToString()
                    });
                }
            }
            catch(Exception ex)
            {
                WriteLog(ex);
            }
        }
        public void Delivering()
        {
            try
            {
                Mensaje msj = new Mensaje();
                while(colaMensajes.Count>0)
                {
                    msj = colaMensajes[0];
                    colaMensajes.RemoveAt(0);
                    ProcesarMensaje(msj);
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex);
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
                    DeliverUser(msj);
                    break;
                case TipoMensaje.SOLICITUD:
                    DeliverUser(msj);
                    break;
            }
        }
        public void ProcesarServidor(Mensaje msj)
        {
            switch (msj.DetalleServidor)
            {
                case DetalleServidor.NUEVO_CONECTADO:
                    DeliverUser(msj);
                    break;
                case DetalleServidor.NUEVO_GRUPO:
                    msj.GrupoId = GenerateGroup(new List<string>(msj.Contenido.Split('|')));
                    DeliverGroup(msj.GrupoId,msj,null);             
                    break;                    
            }
        }
        public void ProcesarChat(Mensaje msj)
        {
            switch (msj.DetalleChat)
            {
                case DetalleChat.TEXTO:
                case DetalleChat.ZUMBIDO:
                    DeliverUser(msj);
                    break;
                case DetalleChat.TEXTO_GRUPAL:
                case DetalleChat.ZUMBIDO_GRUPAL:
                    DeliverGroup(msj.GrupoId, msj, null);
                    break;
            }
        }
        public void DeliverGroup(int grupoId, Mensaje msj1, Mensaje msj2)
        {
            Grupo grupo = grupos.Find(
                    delegate(Grupo grup)
                    {
                        return grup.Id == grupoId;
                    }
            );
            if (grupo != null)
            {
                foreach (string username in grupo.Integrantes)
                {
                    ClienteRed cliente = conexiones.Find(
                            delegate(ClienteRed client)
                            {
                                return client.Usuario == username;
                            }
                    );
                    if (cliente != null)
                    {
                        cliente.ColaMensajes.Add(msj1);
                    }
                }
            }
        }
        public void DeliverUser(Mensaje msj)
        {
            if (msj.Destinatario == Red.BROADCAST)
            {
                foreach (ClienteRed cliente in conexiones)
                {
                    cliente.ColaMensajes.Add(msj);
                }
            }
            else
            {
                ClienteRed cliente = conexiones.Find(
                               delegate(ClienteRed client)
                               {
                                   return client.Usuario == msj.Destinatario;
                               }
                       );
                cliente.ColaMensajes.Add(msj);
            }
        }        
        public int GenerateGroup(List<string>integrantes)
        {
            if (integrantes != null)
            {
                UtileriasChat.Grupo grupo = new Grupo(generadorIdGrupo, integrantes[0]);
                integrantes.RemoveAt(0);
                grupo.Integrantes = integrantes;
                grupo.Id = generadorIdGrupo;
                grupos.Add(grupo);
                generadorIdGrupo++;                
                return grupo.Id;
            }
            else { return 0; }                         
        }
        public void WriteLog(Exception ex)
        {
            this.txtLog.AppendText(DateTime.Now + "--" + ex.Message + Environment.NewLine);
        }
        public void WriteLog(string ex)
        {            
            this.txtLog.AppendText(DateTime.Now + "--" + ex + Environment.NewLine);
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
                    tmrPerformance.Enabled = true;
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
                tmrPerformance.Enabled = false;
            }
        }
        private void tmrPerformance_Tick(object sender, EventArgs e)
        {
            Listener();
            Delivering();
        }
        #endregion                    
    }
}
