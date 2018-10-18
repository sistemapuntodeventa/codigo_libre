namespace Pos.App
{
    partial class frm_cargando
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
            this.pro_avance = new System.Windows.Forms.ProgressBar();
            this.lbl_estado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pro_avance
            // 
            this.pro_avance.Location = new System.Drawing.Point(32, 21);
            this.pro_avance.Name = "pro_avance";
            this.pro_avance.Size = new System.Drawing.Size(259, 17);
            this.pro_avance.TabIndex = 0;
            // 
            // lbl_estado
            // 
            this.lbl_estado.AutoSize = true;
            this.lbl_estado.Location = new System.Drawing.Point(29, 41);
            this.lbl_estado.Name = "lbl_estado";
            this.lbl_estado.Size = new System.Drawing.Size(35, 13);
            this.lbl_estado.TabIndex = 1;
            this.lbl_estado.Text = "label1";
            // 
            // frm_cargando
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 72);
            this.Controls.Add(this.lbl_estado);
            this.Controls.Add(this.pro_avance);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_cargando";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sincronizando Cierre de Caja";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_cargando_FormClosing);
            this.Load += new System.EventHandler(this.frm_cargando_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pro_avance;
        private System.Windows.Forms.Label lbl_estado;
    }
}