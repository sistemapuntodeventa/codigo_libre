namespace Pos.App
{
    partial class frm_ubicacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ubicacion));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_impresora2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_impresora = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.grw_ubicaciones = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_copias = new System.Windows.Forms.TextBox();
            this.txt_copias2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_ancho = new System.Windows.Forms.TextBox();
            this.txt_alto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chk_ubicaciones = new System.Windows.Forms.CheckBox();
            this.chk_copiarprefactura = new System.Windows.Forms.CheckBox();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impresora = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.botonEliminar1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grw_ubicaciones)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(61, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Prefactura:";
            // 
            // cmb_impresora2
            // 
            this.cmb_impresora2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_impresora2.FormattingEnabled = true;
            this.cmb_impresora2.Location = new System.Drawing.Point(132, 75);
            this.cmb_impresora2.Name = "cmb_impresora2";
            this.cmb_impresora2.Size = new System.Drawing.Size(292, 21);
            this.cmb_impresora2.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(27, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Impresora Principal:";
            // 
            // cmb_impresora
            // 
            this.cmb_impresora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_impresora.FormattingEnabled = true;
            this.cmb_impresora.Location = new System.Drawing.Point(132, 17);
            this.cmb_impresora.Name = "cmb_impresora";
            this.cmb_impresora.Size = new System.Drawing.Size(292, 21);
            this.cmb_impresora.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(461, 262);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chk_copiarprefactura);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.txt_copias2);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.txt_copias);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.cmb_impresora);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.cmb_impresora2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(453, 236);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Impresora Principal";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_guardar
            // 
            this.btn_guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.btn_guardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btn_guardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(110)))), ((int)(((byte)(189)))));
            this.btn_guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_guardar.Image")));
            this.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_guardar.Location = new System.Drawing.Point(136, 277);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(92, 46);
            this.btn_guardar.TabIndex = 12;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar.UseVisualStyleBackColor = false;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.btn_salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btn_salir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(110)))), ((int)(((byte)(189)))));
            this.btn_salir.Image = global::Pos.Properties.Resources.cerrar;
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salir.Location = new System.Drawing.Point(234, 277);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.btn_salir.Size = new System.Drawing.Size(92, 46);
            this.btn_salir.TabIndex = 13;
            this.btn_salir.Text = "Cerrar";
            this.btn_salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salir.UseVisualStyleBackColor = false;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // grw_ubicaciones
            // 
            this.grw_ubicaciones.BackgroundColor = System.Drawing.Color.White;
            this.grw_ubicaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grw_ubicaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grw_ubicaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre,
            this.impresora,
            this.botonEliminar1});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grw_ubicaciones.DefaultCellStyle = dataGridViewCellStyle1;
            this.grw_ubicaciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grw_ubicaciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grw_ubicaciones.Location = new System.Drawing.Point(3, 35);
            this.grw_ubicaciones.MultiSelect = false;
            this.grw_ubicaciones.Name = "grw_ubicaciones";
            this.grw_ubicaciones.RowHeadersVisible = false;
            this.grw_ubicaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grw_ubicaciones.Size = new System.Drawing.Size(447, 198);
            this.grw_ubicaciones.TabIndex = 7;
            this.grw_ubicaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grw_ubicaciones_CellContentClick);
            this.grw_ubicaciones.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.grw_ubicaciones_CellPainting);
            this.grw_ubicaciones.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.grw_ubicaciones_RowsAdded);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chk_ubicaciones);
            this.tabPage1.Controls.Add(this.grw_ubicaciones);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(453, 236);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Pedidos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(84, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Copias:";
            // 
            // txt_copias
            // 
            this.txt_copias.Location = new System.Drawing.Point(132, 44);
            this.txt_copias.Name = "txt_copias";
            this.txt_copias.Size = new System.Drawing.Size(100, 20);
            this.txt_copias.TabIndex = 29;
            // 
            // txt_copias2
            // 
            this.txt_copias2.Location = new System.Drawing.Point(132, 102);
            this.txt_copias2.Name = "txt_copias2";
            this.txt_copias2.Size = new System.Drawing.Size(100, 20);
            this.txt_copias2.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(84, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Copias:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_ancho);
            this.groupBox1.Controls.Add(this.txt_alto);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(3, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(447, 105);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Papel Continuo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Ancho:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(98, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Alto:";
            // 
            // txt_ancho
            // 
            this.txt_ancho.Location = new System.Drawing.Point(129, 19);
            this.txt_ancho.Name = "txt_ancho";
            this.txt_ancho.Size = new System.Drawing.Size(100, 20);
            this.txt_ancho.TabIndex = 20;
            // 
            // txt_alto
            // 
            this.txt_alto.Location = new System.Drawing.Point(129, 45);
            this.txt_alto.Name = "txt_alto";
            this.txt_alto.Size = new System.Drawing.Size(100, 20);
            this.txt_alto.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(235, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "cm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(235, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "cm";
            // 
            // chk_ubicaciones
            // 
            this.chk_ubicaciones.AutoSize = true;
            this.chk_ubicaciones.Location = new System.Drawing.Point(8, 9);
            this.chk_ubicaciones.Name = "chk_ubicaciones";
            this.chk_ubicaciones.Size = new System.Drawing.Size(234, 17);
            this.chk_ubicaciones.TabIndex = 8;
            this.chk_ubicaciones.Text = "Imprimir todos los productos en ubicaciones.";
            this.chk_ubicaciones.UseVisualStyleBackColor = true;
            // 
            // chk_copiarprefactura
            // 
            this.chk_copiarprefactura.AutoSize = true;
            this.chk_copiarprefactura.Location = new System.Drawing.Point(238, 46);
            this.chk_copiarprefactura.Name = "chk_copiarprefactura";
            this.chk_copiarprefactura.Size = new System.Drawing.Size(170, 17);
            this.chk_copiarprefactura.TabIndex = 33;
            this.chk_copiarprefactura.Text = "Copiar en impresora prefactura";
            this.chk_copiarprefactura.UseVisualStyleBackColor = true;
            this.chk_copiarprefactura.CheckedChanged += new System.EventHandler(this.chk_copiarprefactura_CheckedChanged);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // nombre
            // 
            this.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombre.HeaderText = "Ubicación";
            this.nombre.Name = "nombre";
            // 
            // impresora
            // 
            this.impresora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.impresora.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.impresora.HeaderText = "Impresora";
            this.impresora.MaxDropDownItems = 10;
            this.impresora.Name = "impresora";
            // 
            // botonEliminar1
            // 
            this.botonEliminar1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.botonEliminar1.HeaderText = "";
            this.botonEliminar1.Name = "botonEliminar1";
            // 
            // frm_ubicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(461, 334);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_ubicacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impresión";
            this.Load += new System.EventHandler(this.frm_parametro_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grw_ubicaciones)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_impresora;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_impresora2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView grw_ubicaciones;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_copias;
        private System.Windows.Forms.TextBox txt_copias2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_ancho;
        private System.Windows.Forms.TextBox txt_alto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chk_ubicaciones;
        private System.Windows.Forms.CheckBox chk_copiarprefactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewComboBoxColumn impresora;
        private System.Windows.Forms.DataGridViewButtonColumn botonEliminar1;
    }
}