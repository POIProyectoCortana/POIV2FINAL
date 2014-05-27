namespace Chat_Client
{
    partial class frm_Principal
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
            this.grb_ChatGeneral = new System.Windows.Forms.GroupBox();
            this.btn_ChatGeneral = new System.Windows.Forms.Button();
            this.txt_ChatGeneral = new System.Windows.Forms.TextBox();
            this.rtb_ChatGeneral = new System.Windows.Forms.RichTextBox();
            this.grb_Conectados = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ltb_Conectados = new System.Windows.Forms.ListBox();
            this.tmr_Principal = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gruposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encriptaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstGrupos = new System.Windows.Forms.ListBox();
            this.videollamadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grb_ChatGeneral.SuspendLayout();
            this.grb_Conectados.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grb_ChatGeneral
            // 
            this.grb_ChatGeneral.Controls.Add(this.btn_ChatGeneral);
            this.grb_ChatGeneral.Controls.Add(this.txt_ChatGeneral);
            this.grb_ChatGeneral.Controls.Add(this.rtb_ChatGeneral);
            this.grb_ChatGeneral.Location = new System.Drawing.Point(12, 34);
            this.grb_ChatGeneral.Name = "grb_ChatGeneral";
            this.grb_ChatGeneral.Size = new System.Drawing.Size(345, 375);
            this.grb_ChatGeneral.TabIndex = 0;
            this.grb_ChatGeneral.TabStop = false;
            this.grb_ChatGeneral.Text = "Chat general";
            // 
            // btn_ChatGeneral
            // 
            this.btn_ChatGeneral.Location = new System.Drawing.Point(254, 317);
            this.btn_ChatGeneral.Name = "btn_ChatGeneral";
            this.btn_ChatGeneral.Size = new System.Drawing.Size(84, 51);
            this.btn_ChatGeneral.TabIndex = 2;
            this.btn_ChatGeneral.Text = "Enviar";
            this.btn_ChatGeneral.UseVisualStyleBackColor = true;
            this.btn_ChatGeneral.Click += new System.EventHandler(this.btn_ChatGeneral_Click);
            // 
            // txt_ChatGeneral
            // 
            this.txt_ChatGeneral.Location = new System.Drawing.Point(6, 317);
            this.txt_ChatGeneral.Multiline = true;
            this.txt_ChatGeneral.Name = "txt_ChatGeneral";
            this.txt_ChatGeneral.Size = new System.Drawing.Size(241, 52);
            this.txt_ChatGeneral.TabIndex = 1;
            // 
            // rtb_ChatGeneral
            // 
            this.rtb_ChatGeneral.Location = new System.Drawing.Point(6, 19);
            this.rtb_ChatGeneral.Name = "rtb_ChatGeneral";
            this.rtb_ChatGeneral.Size = new System.Drawing.Size(332, 286);
            this.rtb_ChatGeneral.TabIndex = 0;
            this.rtb_ChatGeneral.Text = "";
            // 
            // grb_Conectados
            // 
            this.grb_Conectados.Controls.Add(this.groupBox1);
            this.grb_Conectados.Controls.Add(this.ltb_Conectados);
            this.grb_Conectados.Location = new System.Drawing.Point(363, 34);
            this.grb_Conectados.Name = "grb_Conectados";
            this.grb_Conectados.Size = new System.Drawing.Size(200, 229);
            this.grb_Conectados.TabIndex = 1;
            this.grb_Conectados.TabStop = false;
            this.grb_Conectados.Text = "Amigos conectados";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 235);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 150);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Amigos conectados";
            // 
            // ltb_Conectados
            // 
            this.ltb_Conectados.FormattingEnabled = true;
            this.ltb_Conectados.Location = new System.Drawing.Point(6, 20);
            this.ltb_Conectados.Name = "ltb_Conectados";
            this.ltb_Conectados.Size = new System.Drawing.Size(188, 199);
            this.ltb_Conectados.TabIndex = 0;
            this.ltb_Conectados.DoubleClick += new System.EventHandler(this.ltb_Conectados_DoubleClick);
            // 
            // tmr_Principal
            // 
            this.tmr_Principal.Tick += new System.EventHandler(this.tmr_Principal_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(571, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gruposToolStripMenuItem,
            this.encriptaciónToolStripMenuItem,
            this.videollamadaToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // gruposToolStripMenuItem
            // 
            this.gruposToolStripMenuItem.Name = "gruposToolStripMenuItem";
            this.gruposToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.gruposToolStripMenuItem.Text = "Crear grupo";
            this.gruposToolStripMenuItem.Click += new System.EventHandler(this.gruposToolStripMenuItem_Click);
            // 
            // encriptaciónToolStripMenuItem
            // 
            this.encriptaciónToolStripMenuItem.Name = "encriptaciónToolStripMenuItem";
            this.encriptaciónToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.encriptaciónToolStripMenuItem.Text = "Encriptación";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstGrupos);
            this.groupBox2.Location = new System.Drawing.Point(363, 269);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 140);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Grupos";
            // 
            // lstGrupos
            // 
            this.lstGrupos.FormattingEnabled = true;
            this.lstGrupos.Location = new System.Drawing.Point(7, 20);
            this.lstGrupos.Name = "lstGrupos";
            this.lstGrupos.Size = new System.Drawing.Size(187, 108);
            this.lstGrupos.TabIndex = 0;
            this.lstGrupos.DoubleClick += new System.EventHandler(this.lstGrupos_DoubleClick);
            // 
            // videollamadaToolStripMenuItem
            // 
            this.videollamadaToolStripMenuItem.Name = "videollamadaToolStripMenuItem";
            this.videollamadaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.videollamadaToolStripMenuItem.Text = "Videollamada";
            this.videollamadaToolStripMenuItem.Click += new System.EventHandler(this.videollamadaToolStripMenuItem_Click);
            // 
            // frm_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 420);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grb_Conectados);
            this.Controls.Add(this.grb_ChatGeneral);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frm_Principal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_Principal_FormClosed);
            this.Load += new System.EventHandler(this.frm_Principal_Load);
            this.grb_ChatGeneral.ResumeLayout(false);
            this.grb_ChatGeneral.PerformLayout();
            this.grb_Conectados.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grb_ChatGeneral;
        private System.Windows.Forms.Button btn_ChatGeneral;
        private System.Windows.Forms.TextBox txt_ChatGeneral;
        private System.Windows.Forms.RichTextBox rtb_ChatGeneral;
        private System.Windows.Forms.GroupBox grb_Conectados;
        private System.Windows.Forms.ListBox ltb_Conectados;
        private System.Windows.Forms.Timer tmr_Principal;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem encriptaciónToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstGrupos;
        private System.Windows.Forms.ToolStripMenuItem gruposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videollamadaToolStripMenuItem;
    }
}