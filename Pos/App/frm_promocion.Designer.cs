namespace Pos.App
{
    partial class frm_promocion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_promocion));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmb_mismoGrupo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chk_estado = new System.Windows.Forms.CheckBox();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.grp_data = new System.Windows.Forms.GroupBox();
            this.chk_todos = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_categoria = new System.Windows.Forms.ComboBox();
            this.grw_productos = new System.Windows.Forms.DataGridView();
            this.chk_sabado = new System.Windows.Forms.CheckBox();
            this.chk_domingo = new System.Windows.Forms.CheckBox();
            this.txt_cantidad = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtp_hasta = new System.Windows.Forms.DateTimePicker();
            this.dtp_desde = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chk_viernes = new System.Windows.Forms.CheckBox();
            this.chk_jueves = new System.Windows.Forms.CheckBox();
            this.chk_miercoles = new System.Windows.Forms.CheckBox();
            this.chk_martes = new System.Windows.Forms.CheckBox();
            this.chk_lunes = new System.Windows.Forms.CheckBox();
            this.txt_descuento = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.grp_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grw_productos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmb_mismoGrupo);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.chk_estado);
            this.groupBox1.Controls.Add(this.txt_nombre);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.grp_data);
            this.groupBox1.Controls.Add(this.chk_sabado);
            this.groupBox1.Controls.Add(this.chk_domingo);
            this.groupBox1.Controls.Add(this.txt_cantidad);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dtp_hasta);
            this.groupBox1.Controls.Add(this.dtp_desde);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.chk_viernes);
            this.groupBox1.Controls.Add(this.chk_jueves);
            this.groupBox1.Controls.Add(this.chk_miercoles);
            this.groupBox1.Controls.Add(this.chk_martes);
            this.groupBox1.Controls.Add(this.chk_lunes);
            this.groupBox1.Controls.Add(this.txt_descuento);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(191)))), ((int)(((byte)(68)))));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(808, 569);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // cmb_mismoGrupo
            // 
            this.cmb_mismoGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_mismoGrupo.FormattingEnabled = true;
            this.cmb_mismoGrupo.Items.AddRange(new object[] {
            "productos de cualquier categoría.",
            "productos de la misma categoría.",
            "productos del mismo nombre."});
            this.cmb_mismoGrupo.Location = new System.Drawing.Point(110, 161);
            this.cmb_mismoGrupo.Name = "cmb_mismoGrupo";
            this.cmb_mismoGrupo.Size = new System.Drawing.Size(292, 23);
            this.cmb_mismoGrupo.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(79, 164);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 15);
            this.label10.TabIndex = 28;
            this.label10.Text = "en";
            // 
            // chk_estado
            // 
            this.chk_estado.AutoSize = true;
            this.chk_estado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chk_estado.Location = new System.Drawing.Point(712, 27);
            this.chk_estado.Name = "chk_estado";
            this.chk_estado.Size = new System.Drawing.Size(63, 19);
            this.chk_estado.TabIndex = 19;
            this.chk_estado.Text = "Activa";
            this.chk_estado.UseVisualStyleBackColor = true;
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(110, 25);
            this.txt_nombre.MaxLength = 200;
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(410, 21);
            this.txt_nombre.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(40, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 15);
            this.label9.TabIndex = 27;
            this.label9.Text = "Nombre:";
            // 
            // grp_data
            // 
            this.grp_data.Controls.Add(this.chk_todos);
            this.grp_data.Controls.Add(this.label1);
            this.grp_data.Controls.Add(this.cmb_categoria);
            this.grp_data.Controls.Add(this.grw_productos);
            this.grp_data.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grp_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.grp_data.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grp_data.Location = new System.Drawing.Point(3, 188);
            this.grp_data.Name = "grp_data";
            this.grp_data.Size = new System.Drawing.Size(802, 378);
            this.grp_data.TabIndex = 26;
            this.grp_data.TabStop = false;
            this.grp_data.Text = "Productos";
            // 
            // chk_todos
            // 
            this.chk_todos.AutoSize = true;
            this.chk_todos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chk_todos.Location = new System.Drawing.Point(414, 23);
            this.chk_todos.Name = "chk_todos";
            this.chk_todos.Size = new System.Drawing.Size(214, 19);
            this.chk_todos.TabIndex = 14;
            this.chk_todos.Text = "Seleccionar toda la categoría";
            this.chk_todos.UseVisualStyleBackColor = true;
            this.chk_todos.CheckedChanged += new System.EventHandler(this.chk_todos_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(33, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 27;
            this.label1.Text = "Categoría";
            // 
            // cmb_categoria
            // 
            this.cmb_categoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_categoria.FormattingEnabled = true;
            this.cmb_categoria.Location = new System.Drawing.Point(110, 20);
            this.cmb_categoria.Name = "cmb_categoria";
            this.cmb_categoria.Size = new System.Drawing.Size(289, 23);
            this.cmb_categoria.TabIndex = 13;
            this.cmb_categoria.SelectedIndexChanged += new System.EventHandler(this.cmb_categoria_SelectedIndexChanged);
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grw_productos.DefaultCellStyle = dataGridViewCellStyle2;
            this.grw_productos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grw_productos.Location = new System.Drawing.Point(3, 60);
            this.grw_productos.MultiSelect = false;
            this.grw_productos.Name = "grw_productos";
            this.grw_productos.RowHeadersVisible = false;
            this.grw_productos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.grw_productos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grw_productos.Size = new System.Drawing.Size(796, 315);
            this.grw_productos.TabIndex = 15;
            this.grw_productos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grw_productos_CellEndEdit);
            // 
            // chk_sabado
            // 
            this.chk_sabado.AutoSize = true;
            this.chk_sabado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chk_sabado.Location = new System.Drawing.Point(464, 83);
            this.chk_sabado.Name = "chk_sabado";
            this.chk_sabado.Size = new System.Drawing.Size(75, 19);
            this.chk_sabado.TabIndex = 10;
            this.chk_sabado.Text = "Sábado";
            this.chk_sabado.UseVisualStyleBackColor = true;
            // 
            // chk_domingo
            // 
            this.chk_domingo.AutoSize = true;
            this.chk_domingo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chk_domingo.Location = new System.Drawing.Point(110, 83);
            this.chk_domingo.Name = "chk_domingo";
            this.chk_domingo.Size = new System.Drawing.Size(84, 19);
            this.chk_domingo.TabIndex = 4;
            this.chk_domingo.Text = "Domingo";
            this.chk_domingo.UseVisualStyleBackColor = true;
            // 
            // txt_cantidad
            // 
            this.txt_cantidad.Location = new System.Drawing.Point(399, 55);
            this.txt_cantidad.MaxLength = 10;
            this.txt_cantidad.Name = "txt_cantidad";
            this.txt_cantidad.Size = new System.Drawing.Size(121, 21);
            this.txt_cantidad.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(526, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 15);
            this.label8.TabIndex = 20;
            this.label8.Text = "producto";
            // 
            // dtp_hasta
            // 
            this.dtp_hasta.Location = new System.Drawing.Point(483, 132);
            this.dtp_hasta.Name = "dtp_hasta";
            this.dtp_hasta.Size = new System.Drawing.Size(292, 21);
            this.dtp_hasta.TabIndex = 12;
            // 
            // dtp_desde
            // 
            this.dtp_desde.CustomFormat = "MM dd yyyy hh mm ss";
            this.dtp_desde.Location = new System.Drawing.Point(110, 132);
            this.dtp_desde.MinDate = new System.DateTime(2012, 11, 15, 0, 0, 0, 0);
            this.dtp_desde.Name = "dtp_desde";
            this.dtp_desde.Size = new System.Drawing.Size(292, 21);
            this.dtp_desde.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(414, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "hasta el";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(40, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "desde el";
            // 
            // chk_viernes
            // 
            this.chk_viernes.AutoSize = true;
            this.chk_viernes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chk_viernes.Location = new System.Drawing.Point(353, 107);
            this.chk_viernes.Name = "chk_viernes";
            this.chk_viernes.Size = new System.Drawing.Size(74, 19);
            this.chk_viernes.TabIndex = 9;
            this.chk_viernes.Text = "Viernes";
            this.chk_viernes.UseVisualStyleBackColor = true;
            // 
            // chk_jueves
            // 
            this.chk_jueves.AutoSize = true;
            this.chk_jueves.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chk_jueves.Location = new System.Drawing.Point(353, 83);
            this.chk_jueves.Name = "chk_jueves";
            this.chk_jueves.Size = new System.Drawing.Size(70, 19);
            this.chk_jueves.TabIndex = 8;
            this.chk_jueves.Text = "Jueves";
            this.chk_jueves.UseVisualStyleBackColor = true;
            // 
            // chk_miercoles
            // 
            this.chk_miercoles.AutoSize = true;
            this.chk_miercoles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chk_miercoles.Location = new System.Drawing.Point(236, 107);
            this.chk_miercoles.Name = "chk_miercoles";
            this.chk_miercoles.Size = new System.Drawing.Size(89, 19);
            this.chk_miercoles.TabIndex = 7;
            this.chk_miercoles.Text = "Miércoles";
            this.chk_miercoles.UseVisualStyleBackColor = true;
            // 
            // chk_martes
            // 
            this.chk_martes.AutoSize = true;
            this.chk_martes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chk_martes.Location = new System.Drawing.Point(236, 83);
            this.chk_martes.Name = "chk_martes";
            this.chk_martes.Size = new System.Drawing.Size(70, 19);
            this.chk_martes.TabIndex = 6;
            this.chk_martes.Text = "Martes";
            this.chk_martes.UseVisualStyleBackColor = true;
            // 
            // chk_lunes
            // 
            this.chk_lunes.AutoSize = true;
            this.chk_lunes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chk_lunes.Location = new System.Drawing.Point(110, 107);
            this.chk_lunes.Name = "chk_lunes";
            this.chk_lunes.Size = new System.Drawing.Size(65, 19);
            this.chk_lunes.TabIndex = 5;
            this.chk_lunes.Text = "Lunes";
            this.chk_lunes.UseVisualStyleBackColor = true;
            // 
            // txt_descuento
            // 
            this.txt_descuento.Location = new System.Drawing.Point(110, 53);
            this.txt_descuento.MaxLength = 10;
            this.txt_descuento.Name = "txt_descuento";
            this.txt_descuento.Size = new System.Drawing.Size(121, 21);
            this.txt_descuento.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(236, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "% de descuento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(45, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "los días";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(34, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Recibe el";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(351, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "en el";
            // 
            // btn_salir
            // 
            this.btn_salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.btn_salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btn_salir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(110)))), ((int)(((byte)(189)))));
            this.btn_salir.Image = global::Pos.Properties.Resources.cerrar;
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salir.Location = new System.Drawing.Point(474, 575);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.btn_salir.Size = new System.Drawing.Size(92, 46);
            this.btn_salir.TabIndex = 18;
            this.btn_salir.Text = "Cerrar";
            this.btn_salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salir.UseVisualStyleBackColor = false;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.btn_limpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btn_limpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(110)))), ((int)(((byte)(189)))));
            this.btn_limpiar.Image = global::Pos.Properties.Resources.edit_clear;
            this.btn_limpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_limpiar.Location = new System.Drawing.Point(376, 575);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(92, 46);
            this.btn_limpiar.TabIndex = 17;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_limpiar.UseVisualStyleBackColor = false;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // btn_guardar
            // 
            this.btn_guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.btn_guardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btn_guardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(110)))), ((int)(((byte)(189)))));
            this.btn_guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_guardar.Image")));
            this.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_guardar.Location = new System.Drawing.Point(278, 575);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(92, 46);
            this.btn_guardar.TabIndex = 16;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar.UseVisualStyleBackColor = false;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // frm_promocion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 631);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.btn_limpiar);
            this.Controls.Add(this.btn_salir);
            this.Name = "frm_promocion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Promociones";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_promocion_FormClosing);
            this.Load += new System.EventHandler(this.frm_promocion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grp_data.ResumeLayout(false);
            this.grp_data.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grw_productos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtp_hasta;
        private System.Windows.Forms.DateTimePicker dtp_desde;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chk_viernes;
        private System.Windows.Forms.CheckBox chk_jueves;
        private System.Windows.Forms.CheckBox chk_miercoles;
        private System.Windows.Forms.CheckBox chk_martes;
        private System.Windows.Forms.CheckBox chk_lunes;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.TextBox txt_descuento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_cantidad;
        private System.Windows.Forms.CheckBox chk_sabado;
        private System.Windows.Forms.CheckBox chk_domingo;
        private System.Windows.Forms.GroupBox grp_data;
        private System.Windows.Forms.DataGridView grw_productos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_categoria;
        private System.Windows.Forms.CheckBox chk_todos;
        private System.Windows.Forms.CheckBox chk_estado;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmb_mismoGrupo;
        private System.Windows.Forms.Label label10;
    }
}