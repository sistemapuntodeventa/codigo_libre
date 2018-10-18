namespace Pos.App
{
    partial class frm_promocionProducto
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
            this.grp_filtro = new System.Windows.Forms.GroupBox();
            this.chk_todos = new System.Windows.Forms.CheckBox();
            this.cmb_categoria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.txt_codigo = new System.Windows.Forms.TextBox();
            this.grp_data = new System.Windows.Forms.GroupBox();
            this.grw_productos = new System.Windows.Forms.DataGridView();
            this.grp_filtro.SuspendLayout();
            this.grp_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grw_productos)).BeginInit();
            this.SuspendLayout();
            // 
            // grp_filtro
            // 
            this.grp_filtro.Controls.Add(this.chk_todos);
            this.grp_filtro.Controls.Add(this.cmb_categoria);
            this.grp_filtro.Controls.Add(this.label2);
            this.grp_filtro.Controls.Add(this.label1);
            this.grp_filtro.Controls.Add(this.txt_nombre);
            this.grp_filtro.Controls.Add(this.txt_codigo);
            this.grp_filtro.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp_filtro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.grp_filtro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(191)))), ((int)(((byte)(68)))));
            this.grp_filtro.Location = new System.Drawing.Point(0, 0);
            this.grp_filtro.Name = "grp_filtro";
            this.grp_filtro.Size = new System.Drawing.Size(985, 91);
            this.grp_filtro.TabIndex = 4;
            this.grp_filtro.TabStop = false;
            this.grp_filtro.Text = "Filtro";
            // 
            // chk_todos
            // 
            this.chk_todos.AutoSize = true;
            this.chk_todos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chk_todos.Location = new System.Drawing.Point(447, 47);
            this.chk_todos.Name = "chk_todos";
            this.chk_todos.Size = new System.Drawing.Size(145, 19);
            this.chk_todos.TabIndex = 10;
            this.chk_todos.Text = "Seleccionar Todos";
            this.chk_todos.UseVisualStyleBackColor = true;
            this.chk_todos.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cmb_categoria
            // 
            this.cmb_categoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_categoria.FormattingEnabled = true;
            this.cmb_categoria.Location = new System.Drawing.Point(447, 18);
            this.cmb_categoria.Name = "cmb_categoria";
            this.cmb_categoria.Size = new System.Drawing.Size(254, 23);
            this.cmb_categoria.TabIndex = 9;
            this.cmb_categoria.SelectedIndexChanged += new System.EventHandler(this.cmb_categoria_SelectedIndexChanged);
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
            // 
            // txt_codigo
            // 
            this.txt_codigo.Location = new System.Drawing.Point(99, 20);
            this.txt_codigo.Name = "txt_codigo";
            this.txt_codigo.Size = new System.Drawing.Size(292, 21);
            this.txt_codigo.TabIndex = 3;
            // 
            // grp_data
            // 
            this.grp_data.Controls.Add(this.grw_productos);
            this.grp_data.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grp_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.grp_data.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grp_data.Location = new System.Drawing.Point(0, 97);
            this.grp_data.Name = "grp_data";
            this.grp_data.Size = new System.Drawing.Size(985, 448);
            this.grp_data.TabIndex = 5;
            this.grp_data.TabStop = false;
            this.grp_data.Text = "Datos";
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
            this.grw_productos.RowHeadersVisible = false;
            this.grw_productos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.grw_productos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grw_productos.Size = new System.Drawing.Size(979, 428);
            this.grw_productos.TabIndex = 4;
            // 
            // frm_promocionProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 545);
            this.Controls.Add(this.grp_filtro);
            this.Controls.Add(this.grp_data);
            this.Name = "frm_promocionProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_promocionProducto";
            this.Load += new System.EventHandler(this.frm_promocionProducto_Load);
            this.grp_filtro.ResumeLayout(false);
            this.grp_filtro.PerformLayout();
            this.grp_data.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grw_productos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_filtro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.TextBox txt_codigo;
        private System.Windows.Forms.GroupBox grp_data;
        private System.Windows.Forms.DataGridView grw_productos;
        private System.Windows.Forms.ComboBox cmb_categoria;
        private System.Windows.Forms.CheckBox chk_todos;
    }
}