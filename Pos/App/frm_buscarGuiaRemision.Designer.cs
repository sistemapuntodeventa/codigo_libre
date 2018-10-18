namespace Pos.App
{
    partial class frm_buscarGuiaRemision
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
            this.grp_data = new System.Windows.Forms.GroupBox();
            this.grw_guias = new System.Windows.Forms.DataGridView();
            this.grp_filtro = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_desde = new System.Windows.Forms.DateTimePicker();
            this.dtp_hasta = new System.Windows.Forms.DateTimePicker();
            this.grp_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grw_guias)).BeginInit();
            this.grp_filtro.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_data
            // 
            this.grp_data.BackColor = System.Drawing.Color.Transparent;
            this.grp_data.Controls.Add(this.grw_guias);
            this.grp_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_data.ForeColor = System.Drawing.Color.Black;
            this.grp_data.Location = new System.Drawing.Point(0, 70);
            this.grp_data.Name = "grp_data";
            this.grp_data.Size = new System.Drawing.Size(778, 387);
            this.grp_data.TabIndex = 5;
            this.grp_data.TabStop = false;
            this.grp_data.Text = "Información";
            // 
            // grw_guias
            // 
            this.grw_guias.AllowUserToAddRows = false;
            this.grw_guias.AllowUserToDeleteRows = false;
            this.grw_guias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grw_guias.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.grw_guias.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grw_guias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grw_guias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grw_guias.Location = new System.Drawing.Point(3, 17);
            this.grw_guias.MultiSelect = false;
            this.grw_guias.Name = "grw_guias";
            this.grw_guias.ReadOnly = true;
            this.grw_guias.RowHeadersVisible = false;
            this.grw_guias.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.grw_guias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grw_guias.Size = new System.Drawing.Size(772, 367);
            this.grw_guias.TabIndex = 4;
            this.grw_guias.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grw_promociones_CellDoubleClick);
            // 
            // grp_filtro
            // 
            this.grp_filtro.BackColor = System.Drawing.Color.Transparent;
            this.grp_filtro.Controls.Add(this.label1);
            this.grp_filtro.Controls.Add(this.label2);
            this.grp_filtro.Controls.Add(this.dtp_desde);
            this.grp_filtro.Controls.Add(this.dtp_hasta);
            this.grp_filtro.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp_filtro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_filtro.ForeColor = System.Drawing.Color.Black;
            this.grp_filtro.Location = new System.Drawing.Point(0, 0);
            this.grp_filtro.Name = "grp_filtro";
            this.grp_filtro.Size = new System.Drawing.Size(778, 70);
            this.grp_filtro.TabIndex = 4;
            this.grp_filtro.TabStop = false;
            this.grp_filtro.Text = "Filtro";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(30, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Desde:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(397, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Hasta:";
            // 
            // dtp_desde
            // 
            this.dtp_desde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_desde.Location = new System.Drawing.Point(80, 20);
            this.dtp_desde.Name = "dtp_desde";
            this.dtp_desde.Size = new System.Drawing.Size(292, 21);
            this.dtp_desde.TabIndex = 7;
            this.dtp_desde.ValueChanged += new System.EventHandler(this.dtp_desde_ValueChanged);
            // 
            // dtp_hasta
            // 
            this.dtp_hasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_hasta.Location = new System.Drawing.Point(443, 20);
            this.dtp_hasta.Name = "dtp_hasta";
            this.dtp_hasta.Size = new System.Drawing.Size(292, 21);
            this.dtp_hasta.TabIndex = 8;
            this.dtp_hasta.ValueChanged += new System.EventHandler(this.dtp_desde_ValueChanged);
            // 
            // frm_buscarGuiaRemision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(778, 457);
            this.Controls.Add(this.grp_data);
            this.Controls.Add(this.grp_filtro);
            this.Name = "frm_buscarGuiaRemision";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Guia Remisión";
            this.Load += new System.EventHandler(this.frm_buscarGuiaRemision_Load);
            this.grp_data.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grw_guias)).EndInit();
            this.grp_filtro.ResumeLayout(false);
            this.grp_filtro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_data;
        private System.Windows.Forms.DataGridView grw_guias;
        private System.Windows.Forms.GroupBox grp_filtro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_desde;
        private System.Windows.Forms.DateTimePicker dtp_hasta;
    }
}