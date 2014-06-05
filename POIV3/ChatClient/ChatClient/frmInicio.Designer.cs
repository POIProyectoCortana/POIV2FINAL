namespace ChatClient
{
    partial class frmInicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grb_Conectados = new System.Windows.Forms.GroupBox();
            this.lstConectados = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstGrupos = new System.Windows.Forms.ListBox();
            this.grb_ChatGeneral = new System.Windows.Forms.GroupBox();
            this.btnChatGeneral = new System.Windows.Forms.Button();
            this.txtChatGeneral = new System.Windows.Forms.TextBox();
            this.rtbChatGeneral = new System.Windows.Forms.RichTextBox();
            this.mnuOpciones = new System.Windows.Forms.MenuStrip();
            this.chatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoGrupoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disponibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ocupadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ausenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encriptaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desactivadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grb_Conectados.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grb_ChatGeneral.SuspendLayout();
            this.mnuOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // grb_Conectados
            // 
            this.grb_Conectados.Controls.Add(this.lstConectados);
            this.grb_Conectados.Location = new System.Drawing.Point(12, 38);
            this.grb_Conectados.Name = "grb_Conectados";
            this.grb_Conectados.Size = new System.Drawing.Size(200, 267);
            this.grb_Conectados.TabIndex = 2;
            this.grb_Conectados.TabStop = false;
            this.grb_Conectados.Text = "Amigos conectados";
            // 
            // lstConectados
            // 
            this.lstConectados.FormattingEnabled = true;
            this.lstConectados.Location = new System.Drawing.Point(6, 20);
            this.lstConectados.Name = "lstConectados";
            this.lstConectados.ScrollAlwaysVisible = true;
            this.lstConectados.Size = new System.Drawing.Size(188, 238);
            this.lstConectados.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstGrupos);
            this.groupBox2.Location = new System.Drawing.Point(12, 311);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 140);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Grupos";
            // 
            // lstGrupos
            // 
            this.lstGrupos.FormattingEnabled = true;
            this.lstGrupos.Location = new System.Drawing.Point(7, 20);
            this.lstGrupos.Name = "lstGrupos";
            this.lstGrupos.ScrollAlwaysVisible = true;
            this.lstGrupos.Size = new System.Drawing.Size(187, 108);
            this.lstGrupos.TabIndex = 0;
            // 
            // grb_ChatGeneral
            // 
            this.grb_ChatGeneral.Controls.Add(this.btnChatGeneral);
            this.grb_ChatGeneral.Controls.Add(this.txtChatGeneral);
            this.grb_ChatGeneral.Controls.Add(this.rtbChatGeneral);
            this.grb_ChatGeneral.Location = new System.Drawing.Point(218, 38);
            this.grb_ChatGeneral.Name = "grb_ChatGeneral";
            this.grb_ChatGeneral.Size = new System.Drawing.Size(290, 413);
            this.grb_ChatGeneral.TabIndex = 5;
            this.grb_ChatGeneral.TabStop = false;
            this.grb_ChatGeneral.Text = "Chat general";
            // 
            // btnChatGeneral
            // 
            this.btnChatGeneral.Location = new System.Drawing.Point(229, 317);
            this.btnChatGeneral.Name = "btnChatGeneral";
            this.btnChatGeneral.Size = new System.Drawing.Size(55, 26);
            this.btnChatGeneral.TabIndex = 2;
            this.btnChatGeneral.Text = "Enviar";
            this.btnChatGeneral.UseVisualStyleBackColor = true;
            this.btnChatGeneral.Click += new System.EventHandler(this.btnChatGeneral_Click);
            // 
            // txtChatGeneral
            // 
            this.txtChatGeneral.Location = new System.Drawing.Point(6, 317);
            this.txtChatGeneral.Multiline = true;
            this.txtChatGeneral.Name = "txtChatGeneral";
            this.txtChatGeneral.Size = new System.Drawing.Size(217, 84);
            this.txtChatGeneral.TabIndex = 1;
            // 
            // rtbChatGeneral
            // 
            this.rtbChatGeneral.Cursor = System.Windows.Forms.Cursors.No;
            this.rtbChatGeneral.DetectUrls = false;
            this.rtbChatGeneral.Location = new System.Drawing.Point(6, 19);
            this.rtbChatGeneral.Name = "rtbChatGeneral";
            this.rtbChatGeneral.ReadOnly = true;
            this.rtbChatGeneral.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbChatGeneral.Size = new System.Drawing.Size(278, 286);
            this.rtbChatGeneral.TabIndex = 0;
            this.rtbChatGeneral.Text = "";
            // 
            // mnuOpciones
            // 
            this.mnuOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chatToolStripMenuItem,
            this.opcionesToolStripMenuItem});
            this.mnuOpciones.Location = new System.Drawing.Point(0, 0);
            this.mnuOpciones.Name = "mnuOpciones";
            this.mnuOpciones.Size = new System.Drawing.Size(520, 24);
            this.mnuOpciones.TabIndex = 6;
            this.mnuOpciones.Text = "menuStrip1";
            // 
            // chatToolStripMenuItem
            // 
            this.chatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoGrupoToolStripMenuItem,
            this.estadoToolStripMenuItem});
            this.chatToolStripMenuItem.Name = "chatToolStripMenuItem";
            this.chatToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.chatToolStripMenuItem.Text = "Chat";
            // 
            // nuevoGrupoToolStripMenuItem
            // 
            this.nuevoGrupoToolStripMenuItem.Name = "nuevoGrupoToolStripMenuItem";
            this.nuevoGrupoToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.nuevoGrupoToolStripMenuItem.Text = "Nuevo grupo";
            // 
            // estadoToolStripMenuItem
            // 
            this.estadoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disponibleToolStripMenuItem,
            this.ocupadoToolStripMenuItem,
            this.ausenteToolStripMenuItem});
            this.estadoToolStripMenuItem.Name = "estadoToolStripMenuItem";
            this.estadoToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.estadoToolStripMenuItem.Text = "Estado";
            // 
            // disponibleToolStripMenuItem
            // 
            this.disponibleToolStripMenuItem.Name = "disponibleToolStripMenuItem";
            this.disponibleToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.disponibleToolStripMenuItem.Text = "Disponible";
            // 
            // ocupadoToolStripMenuItem
            // 
            this.ocupadoToolStripMenuItem.Name = "ocupadoToolStripMenuItem";
            this.ocupadoToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.ocupadoToolStripMenuItem.Text = "Ocupado";
            // 
            // ausenteToolStripMenuItem
            // 
            this.ausenteToolStripMenuItem.Name = "ausenteToolStripMenuItem";
            this.ausenteToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.ausenteToolStripMenuItem.Text = "Ausente";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.encriptaciónToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // encriptaciónToolStripMenuItem
            // 
            this.encriptaciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activadaToolStripMenuItem,
            this.desactivadaToolStripMenuItem});
            this.encriptaciónToolStripMenuItem.Name = "encriptaciónToolStripMenuItem";
            this.encriptaciónToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.encriptaciónToolStripMenuItem.Text = "Encriptación";
            // 
            // activadaToolStripMenuItem
            // 
            this.activadaToolStripMenuItem.Name = "activadaToolStripMenuItem";
            this.activadaToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.activadaToolStripMenuItem.Text = "Activada";
            this.activadaToolStripMenuItem.Click += new System.EventHandler(this.activadaToolStripMenuItem_Click);
            // 
            // desactivadaToolStripMenuItem
            // 
            this.desactivadaToolStripMenuItem.Name = "desactivadaToolStripMenuItem";
            this.desactivadaToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.desactivadaToolStripMenuItem.Text = "Desactivada";
            this.desactivadaToolStripMenuItem.Click += new System.EventHandler(this.desactivadaToolStripMenuItem_Click);
            // 
            // frmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 459);
            this.Controls.Add(this.grb_ChatGeneral);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grb_Conectados);
            this.Controls.Add(this.mnuOpciones);
            this.MainMenuStrip = this.mnuOpciones;
            this.Name = "frmInicio";
            this.Text = "OnLine Chat";
            this.grb_Conectados.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.grb_ChatGeneral.ResumeLayout(false);
            this.grb_ChatGeneral.PerformLayout();
            this.mnuOpciones.ResumeLayout(false);
            this.mnuOpciones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grb_Conectados;
        private System.Windows.Forms.ListBox lstConectados;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstGrupos;
        private System.Windows.Forms.GroupBox grb_ChatGeneral;
        private System.Windows.Forms.Button btnChatGeneral;
        private System.Windows.Forms.TextBox txtChatGeneral;
        private System.Windows.Forms.RichTextBox rtbChatGeneral;
        private System.Windows.Forms.MenuStrip mnuOpciones;
        private System.Windows.Forms.ToolStripMenuItem chatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoGrupoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disponibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ocupadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ausenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem encriptaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activadaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desactivadaToolStripMenuItem;
    }
}