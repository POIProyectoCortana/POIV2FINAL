namespace ChatClient
{
    partial class frmAcceso
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
            this.txtPuerto = new System.Windows.Forms.TextBox();
            this.lbl_Puerto = new System.Windows.Forms.Label();
            this.btnConectar = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtIPServidor = new System.Windows.Forms.TextBox();
            this.lbl_Nickname = new System.Windows.Forms.Label();
            this.lbl_IPServidor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPuerto
            // 
            this.txtPuerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPuerto.Location = new System.Drawing.Point(23, 156);
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(180, 26);
            this.txtPuerto.TabIndex = 3;
            this.txtPuerto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_Puerto
            // 
            this.lbl_Puerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Puerto.Location = new System.Drawing.Point(19, 130);
            this.lbl_Puerto.Name = "lbl_Puerto";
            this.lbl_Puerto.Size = new System.Drawing.Size(100, 23);
            this.lbl_Puerto.TabIndex = 0;
            this.lbl_Puerto.Text = "Puerto:";
            // 
            // btnConectar
            // 
            this.btnConectar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConectar.Location = new System.Drawing.Point(61, 206);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(104, 32);
            this.btnConectar.TabIndex = 4;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btn_Conectar_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(23, 41);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(180, 26);
            this.txtUsuario.TabIndex = 1;
            this.txtUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIPServidor
            // 
            this.txtIPServidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIPServidor.Location = new System.Drawing.Point(23, 98);
            this.txtIPServidor.Name = "txtIPServidor";
            this.txtIPServidor.Size = new System.Drawing.Size(180, 26);
            this.txtIPServidor.TabIndex = 2;
            this.txtIPServidor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_Nickname
            // 
            this.lbl_Nickname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Nickname.Location = new System.Drawing.Point(19, 15);
            this.lbl_Nickname.Name = "lbl_Nickname";
            this.lbl_Nickname.Size = new System.Drawing.Size(100, 23);
            this.lbl_Nickname.TabIndex = 0;
            this.lbl_Nickname.Text = "Usuario:";
            // 
            // lbl_IPServidor
            // 
            this.lbl_IPServidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_IPServidor.Location = new System.Drawing.Point(19, 72);
            this.lbl_IPServidor.Name = "lbl_IPServidor";
            this.lbl_IPServidor.Size = new System.Drawing.Size(100, 23);
            this.lbl_IPServidor.TabIndex = 0;
            this.lbl_IPServidor.Text = "Servidor:";
            // 
            // frmAcceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 250);
            this.Controls.Add(this.txtPuerto);
            this.Controls.Add(this.lbl_Puerto);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtIPServidor);
            this.Controls.Add(this.lbl_Nickname);
            this.Controls.Add(this.lbl_IPServidor);
            this.MaximizeBox = false;
            this.Name = "frmAcceso";
            this.Text = "Acceso";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPuerto;
        private System.Windows.Forms.Label lbl_Puerto;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtIPServidor;
        private System.Windows.Forms.Label lbl_Nickname;
        private System.Windows.Forms.Label lbl_IPServidor;
    }
}

