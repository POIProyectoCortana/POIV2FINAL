﻿namespace Chat_Client
{
    partial class frm_Videollamada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Videollamada));
            //this.axVideoChatSender1 = new AxVideoChatSenderLib.AxVideoChatSender();
            //this.axVideoChatReceiver1 = new AxVideoChatReceiverLib.AxVideoChatReceiver();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            //((System.ComponentModel.ISupportInitialize)(this.axVideoChatSender1)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.axVideoChatReceiver1)).BeginInit();
            this.SuspendLayout();
            // 
            // axVideoChatSender1
            // 
            //this.axVideoChatSender1.Enabled = true;
            //this.axVideoChatSender1.Location = new System.Drawing.Point(12, 12);
            //this.axVideoChatSender1.Name = "axVideoChatSender1";
            //this.axVideoChatSender1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axVideoChatSender1.OcxState")));
            //this.axVideoChatSender1.Size = new System.Drawing.Size(253, 235);
            //this.axVideoChatSender1.TabIndex = 0;
            // 
            // axVideoChatReceiver1
            // 
            //this.axVideoChatReceiver1.Enabled = true;
            //this.axVideoChatReceiver1.Location = new System.Drawing.Point(296, 12);
            //this.axVideoChatReceiver1.Name = "axVideoChatReceiver1";
            //this.axVideoChatReceiver1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axVideoChatReceiver1.OcxState")));
            //this.axVideoChatReceiver1.Size = new System.Drawing.Size(398, 327);
            //this.axVideoChatReceiver1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(85, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Activar Mi Camara";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(468, 345);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Ver Camara";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(13, 286);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Activar Audio";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(162, 286);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(103, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Desactivar Audio";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // frm_Videollamada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 416);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            //this.Controls.Add(this.axVideoChatReceiver1);
            //this.Controls.Add(this.axVideoChatSender1);
            this.Name = "frm_Videollamada";
            this.Text = "frm_Videollamada";
            this.Load += new System.EventHandler(this.frm_Videollamada_Load);
            //((System.ComponentModel.ISupportInitialize)(this.axVideoChatSender1)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.axVideoChatReceiver1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        //private AxVideoChatSenderLib.AxVideoChatSender axVideoChatSender1;
        //private AxVideoChatReceiverLib.AxVideoChatReceiver axVideoChatReceiver1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}