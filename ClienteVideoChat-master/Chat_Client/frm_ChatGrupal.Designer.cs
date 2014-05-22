namespace Chat_Client
{
    partial class frm_ChatGrupal
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
            this.label1 = new System.Windows.Forms.Label();
            this.lstIntegrantes = new System.Windows.Forms.ListBox();
            this.rtbChat = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarConversaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirDeConversaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.tmrConversacion = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // lstIntegrantes
            // 
            this.lstIntegrantes.FormattingEnabled = true;
            this.lstIntegrantes.Location = new System.Drawing.Point(12, 50);
            this.lstIntegrantes.Name = "lstIntegrantes";
            this.lstIntegrantes.Size = new System.Drawing.Size(144, 316);
            this.lstIntegrantes.TabIndex = 1;
            // 
            // rtbChat
            // 
            this.rtbChat.Location = new System.Drawing.Point(162, 27);
            this.rtbChat.Name = "rtbChat";
            this.rtbChat.Size = new System.Drawing.Size(440, 278);
            this.rtbChat.TabIndex = 2;
            this.rtbChat.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(614, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guardarConversaciónToolStripMenuItem,
            this.salirDeConversaciónToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // guardarConversaciónToolStripMenuItem
            // 
            this.guardarConversaciónToolStripMenuItem.Name = "guardarConversaciónToolStripMenuItem";
            this.guardarConversaciónToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.guardarConversaciónToolStripMenuItem.Text = "Guardar Conversación";
            // 
            // salirDeConversaciónToolStripMenuItem
            // 
            this.salirDeConversaciónToolStripMenuItem.Name = "salirDeConversaciónToolStripMenuItem";
            this.salirDeConversaciónToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.salirDeConversaciónToolStripMenuItem.Text = "Salir de Conversación";
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(527, 311);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 55);
            this.btnEnviar.TabIndex = 4;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // txtChat
            // 
            this.txtChat.Location = new System.Drawing.Point(162, 311);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(359, 54);
            this.txtChat.TabIndex = 5;
            // 
            // tmrConversacion
            // 
            this.tmrConversacion.Tick += new System.EventHandler(this.tmrConversacion_Tick);
            // 
            // frm_ChatGrupal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 369);
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.rtbChat);
            this.Controls.Add(this.lstIntegrantes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frm_ChatGrupal";
            this.Text = "frm_ChatGrupal";
            this.Load += new System.EventHandler(this.frm_ChatGrupal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstIntegrantes;
        private System.Windows.Forms.RichTextBox rtbChat;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarConversaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirDeConversaciónToolStripMenuItem;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.Timer tmrConversacion;
    }
}