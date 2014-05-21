namespace Chat_Client
{
    partial class frm_crearGrupo
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
            this.btnCrear = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGrupo = new System.Windows.Forms.TextBox();
            this.lstEnGrupo = new System.Windows.Forms.ListBox();
            this.lstDisponibles = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnAddPlus = new System.Windows.Forms.Button();
            this.btnQuitPlus = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(12, 270);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(373, 23);
            this.btnCrear.TabIndex = 0;
            this.btnCrear.Text = "Crear grupo";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnQuitPlus);
            this.groupBox1.Controls.Add(this.btnAddPlus);
            this.groupBox1.Controls.Add(this.btnQuit);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.lstDisponibles);
            this.groupBox1.Controls.Add(this.lstEnGrupo);
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 229);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre del grupo:";
            // 
            // txtGrupo
            // 
            this.txtGrupo.Location = new System.Drawing.Point(112, 9);
            this.txtGrupo.Multiline = true;
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.Size = new System.Drawing.Size(273, 20);
            this.txtGrupo.TabIndex = 3;
            // 
            // lstEnGrupo
            // 
            this.lstEnGrupo.FormattingEnabled = true;
            this.lstEnGrupo.Location = new System.Drawing.Point(7, 33);
            this.lstEnGrupo.Name = "lstEnGrupo";
            this.lstEnGrupo.Size = new System.Drawing.Size(146, 186);
            this.lstEnGrupo.TabIndex = 0;
            // 
            // lstDisponibles
            // 
            this.lstDisponibles.FormattingEnabled = true;
            this.lstDisponibles.Location = new System.Drawing.Point(220, 32);
            this.lstDisponibles.Name = "lstDisponibles";
            this.lstDisponibles.Size = new System.Drawing.Size(147, 186);
            this.lstDisponibles.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(159, 56);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(54, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "<";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(159, 114);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(54, 23);
            this.btnQuit.TabIndex = 3;
            this.btnQuit.Text = ">";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnAddPlus
            // 
            this.btnAddPlus.Location = new System.Drawing.Point(160, 85);
            this.btnAddPlus.Name = "btnAddPlus";
            this.btnAddPlus.Size = new System.Drawing.Size(54, 23);
            this.btnAddPlus.TabIndex = 4;
            this.btnAddPlus.Text = "<<";
            this.btnAddPlus.UseVisualStyleBackColor = true;
            this.btnAddPlus.Click += new System.EventHandler(this.btnAddPlus_Click);
            // 
            // btnQuitPlus
            // 
            this.btnQuitPlus.Location = new System.Drawing.Point(159, 143);
            this.btnQuitPlus.Name = "btnQuitPlus";
            this.btnQuitPlus.Size = new System.Drawing.Size(54, 23);
            this.btnQuitPlus.TabIndex = 5;
            this.btnQuitPlus.Text = ">>";
            this.btnQuitPlus.UseVisualStyleBackColor = true;
            this.btnQuitPlus.Click += new System.EventHandler(this.btnQuitPlus_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Contactos en grupo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(217, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Contactos disponibles";
            // 
            // frm_crearGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 302);
            this.Controls.Add(this.txtGrupo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCrear);
            this.Name = "frm_crearGrupo";
            this.Text = "Crear grupo";
            this.Load += new System.EventHandler(this.frm_crearGrupo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnQuitPlus;
        private System.Windows.Forms.Button btnAddPlus;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lstDisponibles;
        private System.Windows.Forms.ListBox lstEnGrupo;
        private System.Windows.Forms.TextBox txtGrupo;
    }
}