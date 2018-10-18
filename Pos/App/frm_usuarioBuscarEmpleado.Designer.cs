namespace Pos.App
{
    partial class frm_buscar_empleado
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grp_filtro = new System.Windows.Forms.GroupBox();
            this.cmb_ingresado = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grp_data = new System.Windows.Forms.GroupBox();
            this.grw_empleados = new System.Windows.Forms.DataGridView();
            this.grp_filtro.SuspendLayout();
            this.grp_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grw_empleados)).BeginInit();
            this.SuspendLayout();
            // 
            // grp_filtro
            // 
            this.grp_filtro.Controls.Add(this.cmb_ingresado);
            this.grp_filtro.Controls.Add(this.label3);
            this.grp_filtro.Controls.Add(this.txt_nombre);
            this.grp_filtro.Controls.Add(this.label1);
            this.grp_filtro.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp_filtro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.grp_filtro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(191)))), ((int)(((byte)(68)))));
            this.grp_filtro.Location = new System.Drawing.Point(0, 0);
            this.grp_filtro.Name = "grp_filtro";
            this.grp_filtro.Size = new System.Drawing.Size(694, 97);
            this.grp_filtro.TabIndex = 0;
            this.grp_filtro.TabStop = false;
            this.grp_filtro.Text = "Filtro";
            // 
            // cmb_ingresado
            // 
            this.cmb_ingresado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ingresado.FormattingEnabled = true;
            this.cmb_ingresado.Items.AddRange(new object[] {
            "TODOS",
            "SI",
            "NO"});
            this.cmb_ingresado.Location = new System.Drawing.Point(150, 55);
            this.cmb_ingresado.Name = "cmb_ingresado";
            this.cmb_ingresado.Size = new System.Drawing.Size(292, 23);
            this.cmb_ingresado.TabIndex = 5;
            this.cmb_ingresado.SelectedIndexChanged += new System.EventHandler(this.cmb_ingresado_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label3.Location = new System.Drawing.Point(69, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ingresado:";
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(150, 28);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(292, 21);
            this.txt_nombre.TabIndex = 1;
            this.txt_nombre.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_filtro_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label1.Location = new System.Drawing.Point(14, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre o Apellido:";
            // 
            // grp_data
            // 
            this.grp_data.Controls.Add(this.grw_empleados);
            this.grp_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.grp_data.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(191)))), ((int)(((byte)(68)))));
            this.grp_data.Location = new System.Drawing.Point(0, 97);
            this.grp_data.Name = "grp_data";
            this.grp_data.Size = new System.Drawing.Size(694, 286);
            this.grp_data.TabIndex = 1;
            this.grp_data.TabStop = false;
            this.grp_data.Text = "Datos";
            this.grp_data.Enter += new System.EventHandler(this.grp_data_Enter);
            // 
            // grw_empleados
            // 
            this.grw_empleados.AllowUserToAddRows = false;
            this.grw_empleados.AllowUserToDeleteRows = false;
            this.grw_empleados.AllowUserToResizeColumns = false;
            this.grw_empleados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grw_empleados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grw_empleados.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grw_empleados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grw_empleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grw_empleados.DefaultCellStyle = dataGridViewCellStyle1;
            this.grw_empleados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grw_empleados.Location = new System.Drawing.Point(3, 17);
            this.grw_empleados.Name = "grw_empleados";
            this.grw_empleados.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grw_empleados.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grw_empleados.RowHeadersVisible = false;
            this.grw_empleados.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.grw_empleados.RowTemplate.ReadOnly = true;
            this.grw_empleados.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grw_empleados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grw_empleados.Size = new System.Drawing.Size(688, 266);
            this.grw_empleados.TabIndex = 3;
            this.grw_empleados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grw_empleados_CellDoubleClick);
            // 
            // frm_buscar_empleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 383);
            this.Controls.Add(this.grp_data);
            this.Controls.Add(this.grp_filtro);
            this.MaximizeBox = false;
            this.Name = "frm_buscar_empleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Empleado";
            this.Load += new System.EventHandler(this.frm_buscar_empleado_Load);
            this.grp_filtro.ResumeLayout(false);
            this.grp_filtro.PerformLayout();
            this.grp_data.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grw_empleados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_filtro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.GroupBox grp_data;
        private System.Windows.Forms.DataGridView grw_empleados;
        private System.Windows.Forms.ComboBox cmb_ingresado;
        private System.Windows.Forms.Label label3;
    }
}