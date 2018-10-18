namespace Pos.App
{
    partial class frm_buscarProducto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_buscarProducto));
            this.grw_productos = new System.Windows.Forms.DataGridView();
            this.grp_filtro = new System.Windows.Forms.GroupBox();
            this.cmb_registros = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.txt_codigo = new System.Windows.Forms.TextBox();
            this.grp_data = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.grw_productos)).BeginInit();
            this.grp_filtro.SuspendLayout();
            this.grp_data.SuspendLayout();
            this.SuspendLayout();
            // 
            // grw_productos
            // 
            this.grw_productos.AllowUserToAddRows = false;
            this.grw_productos.AllowUserToDeleteRows = false;
            this.grw_productos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grw_productos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.grw_productos.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grw_productos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grw_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grw_productos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grw_productos.Location = new System.Drawing.Point(3, 17);
            this.grw_productos.MultiSelect = false;
            this.grw_productos.Name = "grw_productos";
            this.grw_productos.ReadOnly = true;
            this.grw_productos.RowHeadersVisible = false;
            this.grw_productos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.grw_productos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grw_productos.Size = new System.Drawing.Size(783, 351);
            this.grw_productos.TabIndex = 4;
            this.grw_productos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grw_cliente_CellDoubleClick);
            this.grw_productos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnDataGirdView1_KeyPress);
            this.grw_productos.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.grw_productos_PreviewKeyDown);
            // 
            // grp_filtro
            // 
            this.grp_filtro.Controls.Add(this.cmb_registros);
            this.grp_filtro.Controls.Add(this.label3);
            this.grp_filtro.Controls.Add(this.label2);
            this.grp_filtro.Controls.Add(this.label1);
            this.grp_filtro.Controls.Add(this.txt_nombre);
            this.grp_filtro.Controls.Add(this.txt_codigo);
            this.grp_filtro.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp_filtro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.grp_filtro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(191)))), ((int)(((byte)(68)))));
            this.grp_filtro.Location = new System.Drawing.Point(0, 0);
            this.grp_filtro.Name = "grp_filtro";
            this.grp_filtro.Size = new System.Drawing.Size(789, 91);
            this.grp_filtro.TabIndex = 2;
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
            this.cmb_registros.Location = new System.Drawing.Point(702, 51);
            this.cmb_registros.Name = "cmb_registros";
            this.cmb_registros.Size = new System.Drawing.Size(75, 23);
            this.cmb_registros.TabIndex = 8;
            this.cmb_registros.SelectedIndexChanged += new System.EventHandler(this.cmb_registros_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label3.Location = new System.Drawing.Point(629, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Registros:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label2.Location = new System.Drawing.Point(31, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label1.Location = new System.Drawing.Point(37, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Código:";
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(99, 51);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(292, 21);
            this.txt_nombre.TabIndex = 4;
            this.txt_nombre.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_codigo_KeyUp);
            // 
            // txt_codigo
            // 
            this.txt_codigo.Location = new System.Drawing.Point(99, 20);
            this.txt_codigo.Name = "txt_codigo";
            this.txt_codigo.Size = new System.Drawing.Size(292, 21);
            this.txt_codigo.TabIndex = 3;
            this.txt_codigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_codigo_KeyUp);
            // 
            // grp_data
            // 
            this.grp_data.Controls.Add(this.grw_productos);
            this.grp_data.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grp_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.grp_data.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grp_data.Location = new System.Drawing.Point(0, 91);
            this.grp_data.Name = "grp_data";
            this.grp_data.Size = new System.Drawing.Size(789, 371);
            this.grp_data.TabIndex = 3;
            this.grp_data.TabStop = false;
            this.grp_data.Text = "Datos";
            // 
            // frm_buscarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(789, 462);
            this.Controls.Add(this.grp_filtro);
            this.Controls.Add(this.grp_data);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_buscarProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Buscar Productos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_buscarProducto_FormClosing);
            this.Load += new System.EventHandler(this.frm_buscarProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grw_productos)).EndInit();
            this.grp_filtro.ResumeLayout(false);
            this.grp_filtro.PerformLayout();
            this.grp_data.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grw_productos;
        private System.Windows.Forms.GroupBox grp_filtro;
        private System.Windows.Forms.GroupBox grp_data;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.TextBox txt_codigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_registros;
        private System.Windows.Forms.Label label3;
    }
}