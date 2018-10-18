namespace Pos.App
{
    partial class frm__buscarPromocion
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
            this.grw_promociones = new System.Windows.Forms.DataGridView();
            this.grp_filtro = new System.Windows.Forms.GroupBox();
            this.cmb_estado = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grp_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grw_promociones)).BeginInit();
            this.grp_filtro.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_data
            // 
            this.grp_data.Controls.Add(this.grw_promociones);
            this.grp_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.grp_data.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grp_data.Location = new System.Drawing.Point(0, 70);
            this.grp_data.Name = "grp_data";
            this.grp_data.Size = new System.Drawing.Size(910, 447);
            this.grp_data.TabIndex = 3;
            this.grp_data.TabStop = false;
            this.grp_data.Text = "Información";
            // 
            // grw_promociones
            // 
            this.grw_promociones.AllowUserToAddRows = false;
            this.grw_promociones.AllowUserToDeleteRows = false;
            this.grw_promociones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grw_promociones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.grw_promociones.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grw_promociones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grw_promociones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grw_promociones.Location = new System.Drawing.Point(3, 17);
            this.grw_promociones.MultiSelect = false;
            this.grw_promociones.Name = "grw_promociones";
            this.grw_promociones.ReadOnly = true;
            this.grw_promociones.RowHeadersVisible = false;
            this.grw_promociones.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.grw_promociones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grw_promociones.Size = new System.Drawing.Size(904, 427);
            this.grw_promociones.TabIndex = 4;
            this.grw_promociones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grw_promociones_CellContentClick);
            this.grw_promociones.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.grw_promociones_CellPainting);
            // 
            // grp_filtro
            // 
            this.grp_filtro.Controls.Add(this.cmb_estado);
            this.grp_filtro.Controls.Add(this.label2);
            this.grp_filtro.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp_filtro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.grp_filtro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(191)))), ((int)(((byte)(68)))));
            this.grp_filtro.Location = new System.Drawing.Point(0, 0);
            this.grp_filtro.Name = "grp_filtro";
            this.grp_filtro.Size = new System.Drawing.Size(910, 70);
            this.grp_filtro.TabIndex = 2;
            this.grp_filtro.TabStop = false;
            this.grp_filtro.Text = "Filtro";
            // 
            // cmb_estado
            // 
            this.cmb_estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_estado.FormattingEnabled = true;
            this.cmb_estado.Location = new System.Drawing.Point(109, 23);
            this.cmb_estado.Name = "cmb_estado";
            this.cmb_estado.Size = new System.Drawing.Size(336, 23);
            this.cmb_estado.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label2.Location = new System.Drawing.Point(48, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Estado:";
            // 
            // frm__buscarPromocion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 517);
            this.Controls.Add(this.grp_data);
            this.Controls.Add(this.grp_filtro);
            this.Name = "frm__buscarPromocion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado Promociones";
            this.Load += new System.EventHandler(this.frm__buscarPromocion_Load);
            this.grp_data.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grw_promociones)).EndInit();
            this.grp_filtro.ResumeLayout(false);
            this.grp_filtro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_data;
        private System.Windows.Forms.DataGridView grw_promociones;
        private System.Windows.Forms.GroupBox grp_filtro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_estado;
    }
}