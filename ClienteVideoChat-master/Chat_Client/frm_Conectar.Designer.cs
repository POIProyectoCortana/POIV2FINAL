namespace Chat_Client
{
    partial class frm_Conectar
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
            this.lbl_IPServidor = new System.Windows.Forms.Label();
            this.lbl_Nickname = new System.Windows.Forms.Label();
            this.txt_IPServidor = new System.Windows.Forms.TextBox();
            this.txt_Nickname = new System.Windows.Forms.TextBox();
            this.btn_Conectar = new System.Windows.Forms.Button();
            this.txt_Puerto = new System.Windows.Forms.TextBox();
            this.lbl_Puerto = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_IPServidor
            // 
            this.lbl_IPServidor.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_IPServidor.Location = new System.Drawing.Point(76, 36);
            this.lbl_IPServidor.Name = "lbl_IPServidor";
            this.lbl_IPServidor.Size = new System.Drawing.Size(100, 23);
            this.lbl_IPServidor.TabIndex = 0;
            this.lbl_IPServidor.Text = "Servidor:";
            // 
            // lbl_Nickname
            // 
            this.lbl_Nickname.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Nickname.Location = new System.Drawing.Point(76, 12);
            this.lbl_Nickname.Name = "lbl_Nickname";
            this.lbl_Nickname.Size = new System.Drawing.Size(100, 23);
            this.lbl_Nickname.TabIndex = 1;
            this.lbl_Nickname.Text = "Nickname:";
            // 
            // txt_IPServidor
            // 
            this.txt_IPServidor.Location = new System.Drawing.Point(185, 36);
            this.txt_IPServidor.Name = "txt_IPServidor";
            this.txt_IPServidor.Size = new System.Drawing.Size(180, 20);
            this.txt_IPServidor.TabIndex = 2;
            // 
            // txt_Nickname
            // 
            this.txt_Nickname.Location = new System.Drawing.Point(185, 10);
            this.txt_Nickname.Name = "txt_Nickname";
            this.txt_Nickname.Size = new System.Drawing.Size(180, 20);
            this.txt_Nickname.TabIndex = 1;
            // 
            // btn_Conectar
            // 
            this.btn_Conectar.Location = new System.Drawing.Point(185, 96);
            this.btn_Conectar.Name = "btn_Conectar";
            this.btn_Conectar.Size = new System.Drawing.Size(75, 23);
            this.btn_Conectar.TabIndex = 4;
            this.btn_Conectar.Text = "Conectar";
            this.btn_Conectar.UseVisualStyleBackColor = true;
            this.btn_Conectar.Click += new System.EventHandler(this.btn_Conectar_Click);
            // 
            // txt_Puerto
            // 
            this.txt_Puerto.Location = new System.Drawing.Point(185, 62);
            this.txt_Puerto.Name = "txt_Puerto";
            this.txt_Puerto.Size = new System.Drawing.Size(180, 20);
            this.txt_Puerto.TabIndex = 3;
            // 
            // lbl_Puerto
            // 
            this.lbl_Puerto.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Puerto.Location = new System.Drawing.Point(76, 64);
            this.lbl_Puerto.Name = "lbl_Puerto";
            this.lbl_Puerto.Size = new System.Drawing.Size(100, 23);
            this.lbl_Puerto.TabIndex = 5;
            this.lbl_Puerto.Text = "Puerto:";
            // 
            // frm_Conectar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 131);
            this.Controls.Add(this.txt_Puerto);
            this.Controls.Add(this.lbl_Puerto);
            this.Controls.Add(this.btn_Conectar);
            this.Controls.Add(this.txt_Nickname);
            this.Controls.Add(this.txt_IPServidor);
            this.Controls.Add(this.lbl_Nickname);
            this.Controls.Add(this.lbl_IPServidor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Conectar";
            this.Text = "Acceder";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_Conectar_FormClosed);
            this.Load += new System.EventHandler(this.frm_Conectar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_IPServidor;
        private System.Windows.Forms.Label lbl_Nickname;
        private System.Windows.Forms.TextBox txt_IPServidor;
        private System.Windows.Forms.TextBox txt_Nickname;
        private System.Windows.Forms.Button btn_Conectar;
        private System.Windows.Forms.TextBox txt_Puerto;
        private System.Windows.Forms.Label lbl_Puerto;
    }
}

