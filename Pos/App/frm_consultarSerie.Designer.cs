namespace Pos.App
{
    partial class frm_consultarSerie
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
            this.lsb_datos = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grb_datos = new System.Windows.Forms.GroupBox();
            this.txt_filtro = new System.Windows.Forms.TextBox();
            this.grb_datos.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsb_datos
            // 
            this.lsb_datos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsb_datos.FormattingEnabled = true;
            this.lsb_datos.ItemHeight = 18;
            this.lsb_datos.Location = new System.Drawing.Point(12, 47);
            this.lsb_datos.Name = "lsb_datos";
            this.lsb_datos.Size = new System.Drawing.Size(276, 220);
            this.lsb_datos.TabIndex = 0;
            this.lsb_datos.SelectedIndexChanged += new System.EventHandler(this.lsb_datos_SelectedIndexChanged);
            this.lsb_datos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lsb_datos_KeyUp);
            this.lsb_datos.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsb_datos_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filtro:";
            // 
            // grb_datos
            // 
            this.grb_datos.Controls.Add(this.txt_filtro);
            this.grb_datos.Controls.Add(this.label1);
            this.grb_datos.Controls.Add(this.lsb_datos);
            this.grb_datos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grb_datos.Location = new System.Drawing.Point(0, 0);
            this.grb_datos.Name = "grb_datos";
            this.grb_datos.Size = new System.Drawing.Size(300, 283);
            this.grb_datos.TabIndex = 2;
            this.grb_datos.TabStop = false;
            this.grb_datos.Text = "Datos";
            // 
            // txt_filtro
            // 
            this.txt_filtro.Location = new System.Drawing.Point(50, 19);
            this.txt_filtro.Name = "txt_filtro";
            this.txt_filtro.Size = new System.Drawing.Size(238, 20);
            this.txt_filtro.TabIndex = 2;
            this.txt_filtro.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_filtro_KeyUp);
            // 
            // frm_consultarSerie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 283);
            this.Controls.Add(this.grb_datos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_consultarSerie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Serie";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_consultarSerie_FormClosing);
            this.Load += new System.EventHandler(this.frm_consultarSerie_Load);
            this.grb_datos.ResumeLayout(false);
            this.grb_datos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lsb_datos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grb_datos;
        private System.Windows.Forms.TextBox txt_filtro;
    }
}