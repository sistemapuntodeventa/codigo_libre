namespace Pos.App
{
    partial class frm_buscarCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_buscarCliente));
            this.grp_filtro = new System.Windows.Forms.GroupBox();
            this.cmb_registros = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.txt_cedula = new System.Windows.Forms.TextBox();
            this.grp_data = new System.Windows.Forms.GroupBox();
            this.grw_clientes = new System.Windows.Forms.DataGridView();
            this.grp_filtro.SuspendLayout();
            this.grp_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grw_clientes)).BeginInit();
            this.SuspendLayout();
            // 
            // grp_filtro
            // 
            this.grp_filtro.Controls.Add(this.cmb_registros);
            this.grp_filtro.Controls.Add(this.label3);
            this.grp_filtro.Controls.Add(this.label2);
            this.grp_filtro.Controls.Add(this.label1);
            this.grp_filtro.Controls.Add(this.txt_nombre);
            this.grp_filtro.Controls.Add(this.txt_cedula);
            this.grp_filtro.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp_filtro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.grp_filtro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(191)))), ((int)(((byte)(68)))));
            this.grp_filtro.Location = new System.Drawing.Point(0, 0);
            this.grp_filtro.Name = "grp_filtro";
            this.grp_filtro.Size = new System.Drawing.Size(663, 100);
            this.grp_filtro.TabIndex = 0;
            this.grp_filtro.TabStop = false;
            this.grp_filtro.Text = "Filtro";
            // 
            // cmb_registros
            // 
            this.cmb_registros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_registros.FormattingEnabled = true;
            this.cmb_registros.Items.AddRange(new object[] {
            "5",
            "10",
            "20",
            "50",
            "TODOS"});
            this.cmb_registros.Location = new System.Drawing.Point(576, 49);
            this.cmb_registros.Name = "cmb_registros";
            this.cmb_registros.Size = new System.Drawing.Size(75, 23);
            this.cmb_registros.TabIndex = 10;
            this.cmb_registros.SelectedIndexChanged += new System.EventHandler(this.cmb_registros_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label3.Location = new System.Drawing.Point(503, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Registros:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label2.Location = new System.Drawing.Point(48, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cédula / RUC:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label1.Location = new System.Drawing.Point(15, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre o Apellido:";
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(151, 50);
            this.txt_nombre.MaxLength = 300;
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(292, 21);
            this.txt_nombre.TabIndex = 3;
            this.txt_nombre.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_nombre_KeyUp);
            // 
            // txt_cedula
            // 
            this.txt_cedula.Location = new System.Drawing.Point(151, 23);
            this.txt_cedula.MaxLength = 13;
            this.txt_cedula.Name = "txt_cedula";
            this.txt_cedula.Size = new System.Drawing.Size(292, 21);
            this.txt_cedula.TabIndex = 1;
            this.txt_cedula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cedula_KeyPress);
            this.txt_cedula.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_cedula_KeyUp);
            // 
            // grp_data
            // 
            this.grp_data.Controls.Add(this.grw_clientes);
            this.grp_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.grp_data.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grp_data.Location = new System.Drawing.Point(0, 100);
            this.grp_data.Name = "grp_data";
            this.grp_data.Size = new System.Drawing.Size(663, 327);
            this.grp_data.TabIndex = 1;
            this.grp_data.TabStop = false;
            this.grp_data.Text = "Información";
            // 
            // grw_clientes
            // 
            this.grw_clientes.AllowUserToAddRows = false;
            this.grw_clientes.AllowUserToDeleteRows = false;
            this.grw_clientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grw_clientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.grw_clientes.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grw_clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grw_clientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grw_clientes.Location = new System.Drawing.Point(3, 17);
            this.grw_clientes.MultiSelect = false;
            this.grw_clientes.Name = "grw_clientes";
            this.grw_clientes.ReadOnly = true;
            this.grw_clientes.RowHeadersVisible = false;
            this.grw_clientes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.grw_clientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grw_clientes.Size = new System.Drawing.Size(657, 307);
            this.grw_clientes.TabIndex = 4;
            this.grw_clientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grw_clientes_CellDoubleClick);
            this.grw_clientes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grw_clientes_KeyDown);
            // 
            // frm_buscarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(663, 427);
            this.Controls.Add(this.grp_data);
            this.Controls.Add(this.grp_filtro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_buscarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Cliente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_buscarCliente_FormClosing);
            this.Load += new System.EventHandler(this.frm_buscarCliente_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frm_buscarCliente_KeyUp);
            this.grp_filtro.ResumeLayout(false);
            this.grp_filtro.PerformLayout();
            this.grp_data.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grw_clientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_filtro;
        private System.Windows.Forms.TextBox txt_cedula;
        private System.Windows.Forms.GroupBox grp_data;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.DataGridView grw_clientes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_registros;
        private System.Windows.Forms.Label label3;
    }
}