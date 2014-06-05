namespace ChatClient
{
    partial class frmGrupo
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.limpiarHistorialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enviarConversacionAUnArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtContenido = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.rtbContenido = new System.Windows.Forms.RichTextBox();
            this.lstIntegrantes = new System.Windows.Forms.ListBox();
            this.btnBuzz = new System.Windows.Forms.Button();
            this.tmrPerformance = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chatToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(444, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chatToolStripMenuItem
            // 
            this.chatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chatToolStripMenuItem1});
            this.chatToolStripMenuItem.Name = "chatToolStripMenuItem";
            this.chatToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.chatToolStripMenuItem.Text = "Opciones";
            // 
            // chatToolStripMenuItem1
            // 
            this.chatToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.limpiarHistorialToolStripMenuItem,
            this.enviarConversacionAUnArchivoToolStripMenuItem});
            this.chatToolStripMenuItem1.Name = "chatToolStripMenuItem1";
            this.chatToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.chatToolStripMenuItem1.Text = "Chat";
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
            // txtContenido
            // 
            this.txtContenido.Location = new System.Drawing.Point(4, 368);
            this.txtContenido.Multiline = true;
            this.txtContenido.Name = "txtContenido";
            this.txtContenido.Size = new System.Drawing.Size(358, 54);
            this.txtContenido.TabIndex = 9;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(368, 368);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 25);
            this.btnEnviar.TabIndex = 8;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // rtbContenido
            // 
            this.rtbContenido.Location = new System.Drawing.Point(154, 27);
            this.rtbContenido.Name = "rtbContenido";
            this.rtbContenido.ReadOnly = true;
            this.rtbContenido.Size = new System.Drawing.Size(278, 335);
            this.rtbContenido.TabIndex = 7;
            this.rtbContenido.Text = "";
            // 
            // lstIntegrantes
            // 
            this.lstIntegrantes.FormattingEnabled = true;
            this.lstIntegrantes.Location = new System.Drawing.Point(4, 47);
            this.lstIntegrantes.Name = "lstIntegrantes";
            this.lstIntegrantes.Size = new System.Drawing.Size(144, 316);
            this.lstIntegrantes.TabIndex = 6;
            // 
            // btnBuzz
            // 
            this.btnBuzz.Location = new System.Drawing.Point(368, 399);
            this.btnBuzz.Name = "btnBuzz";
            this.btnBuzz.Size = new System.Drawing.Size(75, 23);
            this.btnBuzz.TabIndex = 16;
            this.btnBuzz.Text = "Buzz";
            this.btnBuzz.UseVisualStyleBackColor = true;
            this.btnBuzz.Click += new System.EventHandler(this.btnBuzz_Click);
            // 
            // tmrPerformance
            // 
            this.tmrPerformance.Tick += new System.EventHandler(this.tmrPerformance_Tick);
            // 
            // frmGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 424);
            this.Controls.Add(this.btnBuzz);
            this.Controls.Add(this.txtContenido);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.rtbContenido);
            this.Controls.Add(this.lstIntegrantes);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmGrupo";
            this.Text = "frmGrupo";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chatToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem limpiarHistorialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enviarConversacionAUnArchivoToolStripMenuItem;
        private System.Windows.Forms.TextBox txtContenido;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.RichTextBox rtbContenido;
        private System.Windows.Forms.ListBox lstIntegrantes;
        private System.Windows.Forms.Button btnBuzz;
        private System.Windows.Forms.Timer tmrPerformance;
    }
}