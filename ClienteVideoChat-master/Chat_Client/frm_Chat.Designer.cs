namespace Chat_Client
{
    partial class frm_Chat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Chat));
            this.rtb_Contenido = new System.Windows.Forms.RichTextBox();
            this.btn_Adjuntar = new System.Windows.Forms.Button();
            this.txt_Contenido = new System.Windows.Forms.TextBox();
            this.btn_Enviar = new System.Windows.Forms.Button();
            this.tmr_Conversacion = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.axVideoChatReceiver1 = new AxVideoChatReceiverLib.AxVideoChatReceiver();
            this.axVideoChatSender1 = new AxVideoChatSenderLib.AxVideoChatSender();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axVideoChatReceiver1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axVideoChatSender1)).BeginInit();
            this.SuspendLayout();
            // 
            // rtb_Contenido
            // 
            this.rtb_Contenido.Location = new System.Drawing.Point(329, 2);
            this.rtb_Contenido.Name = "rtb_Contenido";
            this.rtb_Contenido.Size = new System.Drawing.Size(316, 247);
            this.rtb_Contenido.TabIndex = 0;
            this.rtb_Contenido.Text = "";
            // 
            // btn_Adjuntar
            // 
            this.btn_Adjuntar.Location = new System.Drawing.Point(557, 293);
            this.btn_Adjuntar.Name = "btn_Adjuntar";
            this.btn_Adjuntar.Size = new System.Drawing.Size(88, 23);
            this.btn_Adjuntar.TabIndex = 1;
            this.btn_Adjuntar.Text = "Adjuntar";
            this.btn_Adjuntar.UseVisualStyleBackColor = true;
            // 
            // txt_Contenido
            // 
            this.txt_Contenido.Location = new System.Drawing.Point(329, 255);
            this.txt_Contenido.Multiline = true;
            this.txt_Contenido.Name = "txt_Contenido";
            this.txt_Contenido.Size = new System.Drawing.Size(316, 32);
            this.txt_Contenido.TabIndex = 2;
            // 
            // btn_Enviar
            // 
            this.btn_Enviar.Location = new System.Drawing.Point(329, 293);
            this.btn_Enviar.Name = "btn_Enviar";
            this.btn_Enviar.Size = new System.Drawing.Size(88, 23);
            this.btn_Enviar.TabIndex = 3;
            this.btn_Enviar.Text = "Enviar";
            this.btn_Enviar.UseVisualStyleBackColor = true;
            this.btn_Enviar.Click += new System.EventHandler(this.btn_Enviar_Click);
            // 
            // tmr_Conversacion
            // 
            this.tmr_Conversacion.Tick += new System.EventHandler(this.tmr_Conversacion_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(429, 293);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Emoticon";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(493, 293);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Buzz";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // axVideoChatReceiver1
            // 
            this.axVideoChatReceiver1.Enabled = true;
            this.axVideoChatReceiver1.Location = new System.Drawing.Point(-1, 2);
            this.axVideoChatReceiver1.Name = "axVideoChatReceiver1";
            this.axVideoChatReceiver1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axVideoChatReceiver1.OcxState")));
            this.axVideoChatReceiver1.Size = new System.Drawing.Size(324, 229);
            this.axVideoChatReceiver1.TabIndex = 7;
            // 
            // axVideoChatSender1
            // 
            this.axVideoChatSender1.Enabled = true;
            this.axVideoChatSender1.Location = new System.Drawing.Point(-1, 237);
            this.axVideoChatSender1.Name = "axVideoChatSender1";
            this.axVideoChatSender1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axVideoChatSender1.OcxState")));
            this.axVideoChatSender1.Size = new System.Drawing.Size(113, 79);
            this.axVideoChatSender1.TabIndex = 8;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(118, 264);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Videollamada";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frm_Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 323);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.axVideoChatSender1);
            this.Controls.Add(this.axVideoChatReceiver1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Enviar);
            this.Controls.Add(this.txt_Contenido);
            this.Controls.Add(this.btn_Adjuntar);
            this.Controls.Add(this.rtb_Contenido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_Chat";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_Chat_FormClosed);
            this.Load += new System.EventHandler(this.frm_Chat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axVideoChatReceiver1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axVideoChatSender1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_Contenido;
        private System.Windows.Forms.Button btn_Adjuntar;
        private System.Windows.Forms.TextBox txt_Contenido;
        private System.Windows.Forms.Button btn_Enviar;
        private System.Windows.Forms.Timer tmr_Conversacion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private AxVideoChatReceiverLib.AxVideoChatReceiver axVideoChatReceiver1;
        private AxVideoChatSenderLib.AxVideoChatSender axVideoChatSender1;
        private System.Windows.Forms.Button button3;
    }
}