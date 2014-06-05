namespace ChatServer
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grpDatosServidor = new System.Windows.Forms.GroupBox();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.btnIniciarServidor = new System.Windows.Forms.Button();
            this.txtPuerto = new System.Windows.Forms.TextBox();
            this.lblIp = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblOnline = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lblLog = new System.Windows.Forms.Label();
            this.tmrPerformance = new System.Windows.Forms.Timer(this.components);
            this.grpDatosServidor.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDatosServidor
            // 
            this.grpDatosServidor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grpDatosServidor.Controls.Add(this.txtServidor);
            this.grpDatosServidor.Controls.Add(this.btnIniciarServidor);
            this.grpDatosServidor.Controls.Add(this.txtPuerto);
            this.grpDatosServidor.Controls.Add(this.lblIp);
            this.grpDatosServidor.Controls.Add(this.label2);
            this.grpDatosServidor.Controls.Add(this.label1);
            this.grpDatosServidor.Controls.Add(this.lblOnline);
            this.grpDatosServidor.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDatosServidor.ForeColor = System.Drawing.Color.Black;
            this.grpDatosServidor.Location = new System.Drawing.Point(13, 13);
            this.grpDatosServidor.Name = "grpDatosServidor";
            this.grpDatosServidor.Size = new System.Drawing.Size(363, 193);
            this.grpDatosServidor.TabIndex = 0;
            this.grpDatosServidor.TabStop = false;
            this.grpDatosServidor.Text = "Datos del servidor";
            // 
            // txtServidor
            // 
            this.txtServidor.Enabled = false;
            this.txtServidor.Location = new System.Drawing.Point(121, 93);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(216, 30);
            this.txtServidor.TabIndex = 9;
            this.txtServidor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnIniciarServidor
            // 
            this.btnIniciarServidor.Location = new System.Drawing.Point(29, 148);
            this.btnIniciarServidor.Name = "btnIniciarServidor";
            this.btnIniciarServidor.Size = new System.Drawing.Size(130, 33);
            this.btnIniciarServidor.TabIndex = 8;
            this.btnIniciarServidor.Text = "Iniciar";
            this.btnIniciarServidor.UseVisualStyleBackColor = true;
            this.btnIniciarServidor.Click += new System.EventHandler(this.btnIniciarServidor_Click);
            // 
            // txtPuerto
            // 
            this.txtPuerto.Location = new System.Drawing.Point(121, 42);
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(216, 30);
            this.txtPuerto.TabIndex = 7;
            this.txtPuerto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblIp
            // 
            this.lblIp.AutoSize = true;
            this.lblIp.Location = new System.Drawing.Point(75, 101);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(40, 22);
            this.lblIp.TabIndex = 6;
            this.lblIp.Text = "Ip:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Puerto:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(343, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "0";
            // 
            // lblOnline
            // 
            this.lblOnline.AutoSize = true;
            this.lblOnline.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOnline.Location = new System.Drawing.Point(197, 167);
            this.lblOnline.Name = "lblOnline";
            this.lblOnline.Size = new System.Drawing.Size(140, 14);
            this.lblOnline.TabIndex = 3;
            this.lblOnline.Text = "Cliententes online:";
            // 
            // txtLog
            // 
            this.txtLog.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Location = new System.Drawing.Point(13, 234);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(363, 192);
            this.txtLog.TabIndex = 1;
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLog.Location = new System.Drawing.Point(13, 209);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(50, 22);
            this.lblLog.TabIndex = 2;
            this.lblLog.Text = "Log:";
            // 
            // tmrPerformance
            // 
            this.tmrPerformance.Tick += new System.EventHandler(this.tmrPerformance_Tick);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(388, 438);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.grpDatosServidor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Servidor de chat";
            this.grpDatosServidor.ResumeLayout(false);
            this.grpDatosServidor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDatosServidor;
        public System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOnline;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.Button btnIniciarServidor;
        private System.Windows.Forms.TextBox txtPuerto;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer tmrPerformance;
    }
}

