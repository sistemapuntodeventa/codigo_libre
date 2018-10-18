namespace Pos.App
{
    partial class frm_sincronizarPersonas
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
            this.btn_usb = new System.Windows.Forms.Button();
            this.btn_internet = new System.Windows.Forms.Button();
            this.dlg_abrir = new System.Windows.Forms.OpenFileDialog();
            this.pro_avance = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_estado = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_usb
            // 
            this.btn_usb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.btn_usb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btn_usb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(110)))), ((int)(((byte)(189)))));
            this.btn_usb.Image = global::Pos.Properties.Resources.usb;
            this.btn_usb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_usb.Location = new System.Drawing.Point(188, 33);
            this.btn_usb.Name = "btn_usb";
            this.btn_usb.Size = new System.Drawing.Size(129, 55);
            this.btn_usb.TabIndex = 2;
            this.btn_usb.Text = "USB";
            this.btn_usb.UseVisualStyleBackColor = false;
            this.btn_usb.Click += new System.EventHandler(this.btn_usb_Click);
            // 
            // btn_internet
            // 
            this.btn_internet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.btn_internet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btn_internet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(110)))), ((int)(((byte)(189)))));
            this.btn_internet.Image = global::Pos.Properties.Resources.sincronizacion;
            this.btn_internet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_internet.Location = new System.Drawing.Point(58, 33);
            this.btn_internet.Name = "btn_internet";
            this.btn_internet.Size = new System.Drawing.Size(124, 55);
            this.btn_internet.TabIndex = 1;
            this.btn_internet.Text = "Internet";
            this.btn_internet.UseVisualStyleBackColor = false;
            this.btn_internet.Click += new System.EventHandler(this.btn_internet_Click);
            // 
            // pro_avance
            // 
            this.pro_avance.Location = new System.Drawing.Point(58, 94);
            this.pro_avance.Name = "pro_avance";
            this.pro_avance.Size = new System.Drawing.Size(259, 16);
            this.pro_avance.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_estado);
            this.groupBox1.Controls.Add(this.btn_usb);
            this.groupBox1.Controls.Add(this.pro_avance);
            this.groupBox1.Controls.Add(this.btn_internet);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(191)))), ((int)(((byte)(68)))));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 139);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fuente de Datos";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lbl_estado
            // 
            this.lbl_estado.AutoSize = true;
            this.lbl_estado.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_estado.ForeColor = System.Drawing.Color.Black;
            this.lbl_estado.Location = new System.Drawing.Point(55, 111);
            this.lbl_estado.Name = "lbl_estado";
            this.lbl_estado.Size = new System.Drawing.Size(62, 16);
            this.lbl_estado.TabIndex = 7;
            this.lbl_estado.Text = "Recibiendo";
            // 
            // frm_sincronizarPersonas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(378, 139);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frm_sincronizarPersonas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sincronización de Cliente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_sincronizarPersonas_FormClosing);
            this.Load += new System.EventHandler(this.frm_sincronizarPersonas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_internet;
        private System.Windows.Forms.Button btn_usb;
        private System.Windows.Forms.OpenFileDialog dlg_abrir;
        private System.Windows.Forms.ProgressBar pro_avance;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_estado;
    }
}