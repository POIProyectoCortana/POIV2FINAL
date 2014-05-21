namespace Chat_Server
{
    partial class frm_ServerMain
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
            this.btn_Iniciar = new System.Windows.Forms.Button();
            this.lbl_DEstado = new System.Windows.Forms.Label();
            this.grb_DatosServer = new System.Windows.Forms.GroupBox();
            this.lbl_DataServer = new System.Windows.Forms.Label();
            this.tmr_Server = new System.Windows.Forms.Timer(this.components);
            this.lbl_conectados = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grb_DatosServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Iniciar
            // 
            this.btn_Iniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Iniciar.Location = new System.Drawing.Point(12, 12);
            this.btn_Iniciar.Name = "btn_Iniciar";
            this.btn_Iniciar.Size = new System.Drawing.Size(90, 49);
            this.btn_Iniciar.TabIndex = 0;
            this.btn_Iniciar.Text = "Iniciar";
            this.btn_Iniciar.UseVisualStyleBackColor = true;
            this.btn_Iniciar.Click += new System.EventHandler(this.btn_Iniciar_Click);
            // 
            // lbl_DEstado
            // 
            this.lbl_DEstado.BackColor = System.Drawing.Color.LightCoral;
            this.lbl_DEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_DEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DEstado.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_DEstado.Location = new System.Drawing.Point(137, 9);
            this.lbl_DEstado.Name = "lbl_DEstado";
            this.lbl_DEstado.Size = new System.Drawing.Size(162, 57);
            this.lbl_DEstado.TabIndex = 2;
            this.lbl_DEstado.Text = "Apagado";
            this.lbl_DEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grb_DatosServer
            // 
            this.grb_DatosServer.Controls.Add(this.lbl_DataServer);
            this.grb_DatosServer.Location = new System.Drawing.Point(13, 81);
            this.grb_DatosServer.Name = "grb_DatosServer";
            this.grb_DatosServer.Size = new System.Drawing.Size(286, 75);
            this.grb_DatosServer.TabIndex = 3;
            this.grb_DatosServer.TabStop = false;
            this.grb_DatosServer.Text = "Datos del servidor";
            // 
            // lbl_DataServer
            // 
            this.lbl_DataServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DataServer.Location = new System.Drawing.Point(7, 20);
            this.lbl_DataServer.Name = "lbl_DataServer";
            this.lbl_DataServer.Size = new System.Drawing.Size(273, 39);
            this.lbl_DataServer.TabIndex = 0;
            this.lbl_DataServer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmr_Server
            // 
            this.tmr_Server.Tick += new System.EventHandler(this.tmr_Server_Tick);
            // 
            // lbl_conectados
            // 
            this.lbl_conectados.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl_conectados.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_conectados.Location = new System.Drawing.Point(138, 160);
            this.lbl_conectados.Name = "lbl_conectados";
            this.lbl_conectados.Size = new System.Drawing.Size(159, 20);
            this.lbl_conectados.TabIndex = 4;
            this.lbl_conectados.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_conectados.Click += new System.EventHandler(this.lbl_conectados_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(12, 183);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(287, 107);
            this.txtLog.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Log:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // frm_ServerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 293);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lbl_conectados);
            this.Controls.Add(this.grb_DatosServer);
            this.Controls.Add(this.lbl_DEstado);
            this.Controls.Add(this.btn_Iniciar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_ServerMain";
            this.Text = "Servidor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_ServerMain_FormClosing);
            this.Load += new System.EventHandler(this.frm_ServerMain_Load);
            this.grb_DatosServer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Iniciar;
        private System.Windows.Forms.Label lbl_DEstado;
        private System.Windows.Forms.GroupBox grb_DatosServer;
        private System.Windows.Forms.Label lbl_DataServer;
        private System.Windows.Forms.Timer tmr_Server;
        private System.Windows.Forms.Label lbl_conectados;
        internal System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label1;
    }
}

