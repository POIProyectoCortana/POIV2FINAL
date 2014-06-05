using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UtileriasChat;

namespace ChatClient
{
    public partial class frmAGrupo : Form
    {
        #region Campos
        #endregion

        #region Propiedades
        #endregion

        #region Constructores
        public frmAGrupo()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodos
        private void Alert(Exception ex)
        {
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion       

        #region Eventos
        private void frmAGrupo_Load(object sender, EventArgs e)
        {
            if (frmInicio.Usuarios.Count <= 0)
            {
                MessageBox.Show("No hay contactos conectados", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                txtGrupo.Text = "";
                lstEnGrupo.Items.Clear();
                lstDisponibles.Items.Clear();
                foreach (Contacto c in frmInicio.Usuarios)
                {
                    lstDisponibles.Items.Add(c.Nombre);
                }        
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lstDisponibles.SelectedItem != null && lstDisponibles.Items.Count>0)
            {
                int index = lstDisponibles.SelectedIndex;
                lstEnGrupo.Items.Add(lstDisponibles.SelectedItem);
                lstDisponibles.Items.RemoveAt(index);
            }
        }
        private void btnAddPlus_Click(object sender, EventArgs e)
        {
            if (lstDisponibles.Items.Count > 0)
            {
                lstEnGrupo.Items.Clear();
                var items = new System.Collections.ArrayList(lstDisponibles.Items);
                foreach (var item in items)
                {
                    lstEnGrupo.Items.Add(item);
                }
                lstDisponibles.Items.Clear();
            }
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            if (lstEnGrupo.SelectedItem != null && lstEnGrupo.Items.Count>0)
            {
                int index = lstEnGrupo.SelectedIndex;
                lstDisponibles.Items.Add(lstEnGrupo.SelectedItem);
                lstEnGrupo.Items.RemoveAt(index);
            }
        }
        private void btnQuitPlus_Click(object sender, EventArgs e)
        {
            if (lstEnGrupo.Items.Count > 0)
            {
                lstDisponibles.Items.Clear();
                var items = new System.Collections.ArrayList(lstEnGrupo.Items);
                foreach (var item in items)
                {
                    lstDisponibles.Items.Add(item);
                }
                lstEnGrupo.Items.Clear();
            }
        }
        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (txtGrupo.Text.Equals(""))
            {
                MessageBox.Show("Debe proporcionar un nombre para este grupo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (lstEnGrupo.Items.Count <= 0)
            {
                MessageBox.Show("Debe seleccionar algun integrante para este grupo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string ContactosGrupo = "";
                var items = new System.Collections.ArrayList(lstEnGrupo.Items);
                foreach (var item in items)
                {
                    ContactosGrupo += item.ToString() + "|";
                }
                ContactosGrupo = ContactosGrupo.Remove(ContactosGrupo.Length - 1, 1);
                Mensaje msj = new Mensaje(TipoMensaje.SERVIDOR, DetalleServidor.NUEVO_GRUPO, null, txtGrupo.Text);
                Mensaje msj2 = new Mensaje(TipoMensaje.SERVIDOR, DetalleServidor.NUEVO_GRUPO_CONECTADO, null, ContactosGrupo);
                frmInicio.ColaMensajesSalida.Add(msj);
                frmInicio.ColaMensajesSalida.Add(msj2);
                this.Close();
            }
        }
        #endregion     
    }
}
