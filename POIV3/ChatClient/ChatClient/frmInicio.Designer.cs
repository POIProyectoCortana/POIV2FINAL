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
            this.components = new System.ComponentModel.Container();
            this.grb_Conectados = new System.Windows.Forms.GroupBox();
            this.lstConectados = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstGrupos = new System.Windows.Forms.ListBox();
            this.grb_ChatGeneral = new System.Windows.Forms.GroupBox();
            this.btnBuzz = new System.Windows.Forms.Button();
            this.btnChatGeneral = new System.Windows.Forms.Button();
            this.txtChatGeneral = new System.Windows.Forms.TextBox();
            this.rtbChatGeneral = new System.Windows.Forms.RichTextBox();
            this.mnuOpciones = new System.Windows.Forms.MenuStrip();
            this.chatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disponibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ocupadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ausenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoGrupoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoGrupoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.encriptaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desactivarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.limpiarHistorialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enviarConversaciónAUnArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrPerformance = new System.Windows.Forms.Timer(this.components);
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
            this.lstConectados.DoubleClick += new System.EventHandler(this.lstConectados_DoubleClick);
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
            this.lstGrupos.DoubleClick += new System.EventHandler(this.lstGrupos_DoubleClick);
            // 
            // grb_ChatGeneral
            // 
            this.grb_ChatGeneral.Controls.Add(this.btnBuzz);
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
            // btnBuzz
            // 
            this.btnBuzz.Location = new System.Drawing.Point(229, 349);
            this.btnBuzz.Name = "btnBuzz";
            this.btnBuzz.Size = new System.Drawing.Size(55, 26);
            this.btnBuzz.TabIndex = 3;
            this.btnBuzz.Text = "Buzz";
            this.btnBuzz.UseVisualStyleBackColor = true;
            this.btnBuzz.Click += new System.EventHandler(this.btnBuzz_Click);
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
            this.txtChatGeneral.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChatGeneral_KeyDown);
            // 
            // rtbChatGeneral
            // 
            this.rtbChatGeneral.Cursor = System.Windows.Forms.Cursors.No;
            this.rtbChatGeneral.DetectUrls = false;
            this.rtbChatGeneral.Location = new System.Drawing.Point(6, 19);
            this.rtbChatGeneral.Name = "rtbChatGeneral";
            this.rtbChatGeneral.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbChatGeneral.Size = new System.Drawing.Size(278, 286);
            this.rtbChatGeneral.TabIndex = 0;
            this.rtbChatGeneral.Text = "";
            // 
            // mnuOpciones
            // 
            this.mnuOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chatToolStripMenuItem});
            this.mnuOpciones.Location = new System.Drawing.Point(0, 0);
            this.mnuOpciones.Name = "mnuOpciones";
            this.mnuOpciones.Size = new System.Drawing.Size(520, 24);
            this.mnuOpciones.TabIndex = 6;
            this.mnuOpciones.Text = "menuStrip1";
            // 
            // chatToolStripMenuItem
            // 
            this.chatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.estadoToolStripMenuItem,
            this.nuevoGrupoToolStripMenuItem,
            this.encriptaciónToolStripMenuItem,
            this.chatToolStripMenuItem1});
            this.chatToolStripMenuItem.Name = "chatToolStripMenuItem";
            this.chatToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.chatToolStripMenuItem.Text = "Opciones";
            // 
            // estadoToolStripMenuItem
            // 
            this.estadoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disponibleToolStripMenuItem,
            this.ocupadoToolStripMenuItem,
            this.ausenteToolStripMenuItem});
            this.estadoToolStripMenuItem.Name = "estadoToolStripMenuItem";
            this.estadoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.estadoToolStripMenuItem.Text = "Estado";
            // 
            // disponibleToolStripMenuItem
            // 
            this.disponibleToolStripMenuItem.Name = "disponibleToolStripMenuItem";
            this.disponibleToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.disponibleToolStripMenuItem.Text = "Disponible";
            this.disponibleToolStripMenuItem.Click += new System.EventHandler(this.disponibleToolStripMenuItem_Click);
            // 
            // ocupadoToolStripMenuItem
            // 
            this.ocupadoToolStripMenuItem.Name = "ocupadoToolStripMenuItem";
            this.ocupadoToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.ocupadoToolStripMenuItem.Text = "Ocupado";
            this.ocupadoToolStripMenuItem.Click += new System.EventHandler(this.ocupadoToolStripMenuItem_Click);
            // 
            // ausenteToolStripMenuItem
            // 
            this.ausenteToolStripMenuItem.Name = "ausenteToolStripMenuItem";
            this.ausenteToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.ausenteToolStripMenuItem.Text = "Ausente";
            this.ausenteToolStripMenuItem.Click += new System.EventHandler(this.ausenteToolStripMenuItem_Click);
            // 
            // nuevoGrupoToolStripMenuItem
            // 
            this.nuevoGrupoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoGrupoToolStripMenuItem1});
            this.nuevoGrupoToolStripMenuItem.Name = "nuevoGrupoToolStripMenuItem";
            this.nuevoGrupoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nuevoGrupoToolStripMenuItem.Text = "Grupos";
            // 
            // nuevoGrupoToolStripMenuItem1
            // 
            this.nuevoGrupoToolStripMenuItem1.Name = "nuevoGrupoToolStripMenuItem1";
            this.nuevoGrupoToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.nuevoGrupoToolStripMenuItem1.Text = "Nuevo grupo";
            this.nuevoGrupoToolStripMenuItem1.Click += new System.EventHandler(this.nuevoGrupoToolStripMenuItem1_Click);
            // 
            // encriptaciónToolStripMenuItem
            // 
            this.encriptaciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activarToolStripMenuItem,
            this.desactivarToolStripMenuItem});
            this.encriptaciónToolStripMenuItem.Name = "encriptaciónToolStripMenuItem";
            this.encriptaciónToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.encriptaciónToolStripMenuItem.Text = "Encriptación";
            // 
            // activarToolStripMenuItem
            // 
            this.activarToolStripMenuItem.Name = "activarToolStripMenuItem";
            this.activarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.activarToolStripMenuItem.Text = "Activar";
            this.activarToolStripMenuItem.Click += new System.EventHandler(this.activarToolStripMenuItem_Click);
            // 
            // desactivarToolStripMenuItem
            // 
            this.desactivarToolStripMenuItem.Name = "desactivarToolStripMenuItem";
            this.desactivarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.desactivarToolStripMenuItem.Text = "Desactivar";
            this.desactivarToolStripMenuItem.Click += new System.EventHandler(this.desactivarToolStripMenuItem_Click);
            // 
            // chatToolStripMenuItem1
            // 
            this.chatToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.limpiarHistorialToolStripMenuItem,
            this.enviarConversaciónAUnArchivoToolStripMenuItem});
            this.chatToolStripMenuItem1.Name = "chatToolStripMenuItem1";
            this.chatToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.chatToolStripMenuItem1.Text = "Chat";
            // 
            // limpiarHistorialToolStripMenuItem
            // 
            this.limpiarHistorialToolStripMenuItem.Name = "limpiarHistorialToolStripMenuItem";
            this.limpiarHistorialToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.limpiarHistorialToolStripMenuItem.Text = "Limpiar historial";
            this.limpiarHistorialToolStripMenuItem.Click += new System.EventHandler(this.limpiarHistorialToolStripMenuItem_Click);
            // 
            // enviarConversaciónAUnArchivoToolStripMenuItem
            // 
            this.enviarConversaciónAUnArchivoToolStripMenuItem.Name = "enviarConversaciónAUnArchivoToolStripMenuItem";
            this.enviarConversaciónAUnArchivoToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.enviarConversaciónAUnArchivoToolStripMenuItem.Text = "Enviar conversación a un archivo";
            this.enviarConversaciónAUnArchivoToolStripMenuItem.Click += new System.EventHandler(this.enviarConversaciónAUnArchivoToolStripMenuItem_Click);
            // 
            // tmrPerformance
            // 
            this.tmrPerformance.Tick += new System.EventHandler(this.tmrPerformance_Tick);
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
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmInicio_FormClosed);
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
        private System.Windows.Forms.ToolStripMenuItem estadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disponibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ocupadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ausenteToolStripMenuItem;
        private System.Windows.Forms.Timer tmrPerformance;
        private System.Windows.Forms.Button btnBuzz;
        private System.Windows.Forms.ToolStripMenuItem nuevoGrupoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem encriptaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desactivarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chatToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem limpiarHistorialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enviarConversaciónAUnArchivoToolStripMenuItem;
    }
}