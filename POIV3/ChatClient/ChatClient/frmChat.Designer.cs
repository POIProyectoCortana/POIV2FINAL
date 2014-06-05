namespace ChatClient
{
    partial class frmChat
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
            this.btnBuzz = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.txtContenido = new System.Windows.Forms.TextBox();
            this.rtbContenido = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuOpciones = new System.Windows.Forms.ToolStripMenuItem();
            this.videllamadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enviarPeticionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.limpiarHistorialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enviarConversacionAUnArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.archivosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enviarArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tmrPerformance = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuzz
            // 
            this.btnBuzz.Location = new System.Drawing.Point(544, 370);
            this.btnBuzz.Name = "btnBuzz";
            this.btnBuzz.Size = new System.Drawing.Size(69, 23);
            this.btnBuzz.TabIndex = 15;
            this.btnBuzz.Text = "Buzz";
            this.btnBuzz.UseVisualStyleBackColor = true;
            this.btnBuzz.Click += new System.EventHandler(this.btnBuzz_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(544, 341);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(69, 23);
            this.btnEnviar.TabIndex = 13;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // txtContenido
            // 
            this.txtContenido.Location = new System.Drawing.Point(342, 341);
            this.txtContenido.Multiline = true;
            this.txtContenido.Name = "txtContenido";
            this.txtContenido.Size = new System.Drawing.Size(195, 61);
            this.txtContenido.TabIndex = 12;
            // 
            // rtbContenido
            // 
            this.rtbContenido.Location = new System.Drawing.Point(342, 27);
            this.rtbContenido.Name = "rtbContenido";
            this.rtbContenido.ReadOnly = true;
            this.rtbContenido.Size = new System.Drawing.Size(259, 308);
            this.rtbContenido.TabIndex = 10;
            this.rtbContenido.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpciones});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(613, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuOpciones
            // 
            this.mnuOpciones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.videllamadaToolStripMenuItem,
            this.chatToolStripMenuItem,
            this.archivosToolStripMenuItem});
            this.mnuOpciones.Name = "mnuOpciones";
            this.mnuOpciones.Size = new System.Drawing.Size(72, 20);
            this.mnuOpciones.Text = "Opciones";
            // 
            // videllamadaToolStripMenuItem
            // 
            this.videllamadaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enviarPeticionToolStripMenuItem});
            this.videllamadaToolStripMenuItem.Name = "videllamadaToolStripMenuItem";
            this.videllamadaToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.videllamadaToolStripMenuItem.Text = "Videllamada";
            // 
            // enviarPeticionToolStripMenuItem
            // 
            this.enviarPeticionToolStripMenuItem.Name = "enviarPeticionToolStripMenuItem";
            this.enviarPeticionToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.enviarPeticionToolStripMenuItem.Text = "Enviar peticion";
            // 
            // chatToolStripMenuItem
            // 
            this.chatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.limpiarHistorialToolStripMenuItem,
            this.enviarConversacionAUnArchivoToolStripMenuItem});
            this.chatToolStripMenuItem.Name = "chatToolStripMenuItem";
            this.chatToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.chatToolStripMenuItem.Text = "Chat";
            // 
            // limpiarHistorialToolStripMenuItem
            // 
            this.limpiarHistorialToolStripMenuItem.Name = "limpiarHistorialToolStripMenuItem";
            this.limpiarHistorialToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.limpiarHistorialToolStripMenuItem.Text = "Limpiar historial";
            this.limpiarHistorialToolStripMenuItem.Click += new System.EventHandler(this.limpiarHistorialToolStripMenuItem_Click);
            // 
            // enviarConversacionAUnArchivoToolStripMenuItem
            // 
            this.enviarConversacionAUnArchivoToolStripMenuItem.Name = "enviarConversacionAUnArchivoToolStripMenuItem";
            this.enviarConversacionAUnArchivoToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.enviarConversacionAUnArchivoToolStripMenuItem.Text = "Enviar conversacion a un archivo";
            this.enviarConversacionAUnArchivoToolStripMenuItem.Click += new System.EventHandler(this.enviarConversacionAUnArchivoToolStripMenuItem_Click);
            // 
            // archivosToolStripMenuItem
            // 
            this.archivosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enviarArchivoToolStripMenuItem});
            this.archivosToolStripMenuItem.Name = "archivosToolStripMenuItem";
            this.archivosToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.archivosToolStripMenuItem.Text = "Archivos";
            // 
            // enviarArchivoToolStripMenuItem
            // 
            this.enviarArchivoToolStripMenuItem.Name = "enviarArchivoToolStripMenuItem";
            this.enviarArchivoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.enviarArchivoToolStripMenuItem.Text = "Enviar archivo";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(311, 234);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(71, 268);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(194, 125);
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // tmrPerformance
            // 
            this.tmrPerformance.Tick += new System.EventHandler(this.tmrPerformance_Tick);
            // 
            // frmChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 405);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnBuzz);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txtContenido);
            this.Controls.Add(this.rtbContenido);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmChat";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmChat_FormClosed);
            this.Load += new System.EventHandler(this.frmChat_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuzz;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txtContenido;
        private System.Windows.Forms.RichTextBox rtbContenido;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuOpciones;
        private System.Windows.Forms.ToolStripMenuItem videllamadaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enviarPeticionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem limpiarHistorialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enviarConversacionAUnArchivoToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem archivosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enviarArchivoToolStripMenuItem;
        private System.Windows.Forms.Timer tmrPerformance;
    }
}