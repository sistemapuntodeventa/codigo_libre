namespace Pos
{
    partial class frm_guiaRemision
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt_cedulaDestinatario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_nombreDestinatario = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_direccionDestinatario = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_cedulaTransportista = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_nombreTransportista = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_placaTransportista = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtp_fechaInicioTraslado = new System.Windows.Forms.DateTimePicker();
            this.dtp_fechaFinTraslado = new System.Windows.Forms.DateTimePicker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_guardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_editar = new System.Windows.Forms.ToolStripButton();
            this.tsb_anular = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.grw_productos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.botonEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tbc_destinatarios = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txt_ruta = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_codigoDestino = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_motivoDestinatario = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_buscarCliente = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_documento = new System.Windows.Forms.TextBox();
            this.btn_transportista = new System.Windows.Forms.Button();
            this.txt_correoTransportista = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_autorizacion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtp_fechaEmision = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_descripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_direccionPartida = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txt_numeroDocumento = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.txt_secuencia = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grw_productos)).BeginInit();
            this.tbc_destinatarios.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_cedulaDestinatario
            // 
            this.txt_cedulaDestinatario.BackColor = System.Drawing.Color.White;
            this.txt_cedulaDestinatario.Enabled = false;
            this.txt_cedulaDestinatario.Location = new System.Drawing.Point(105, 16);
            this.txt_cedulaDestinatario.Name = "txt_cedulaDestinatario";
            this.txt_cedulaDestinatario.Size = new System.Drawing.Size(249, 20);
            this.txt_cedulaDestinatario.TabIndex = 12;
            this.txt_cedulaDestinatario.TextChanged += new System.EventHandler(this.txt_cedulaDestinatario_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label3.Location = new System.Drawing.Point(26, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "R.U.C/C.I.:";
            // 
            // txt_nombreDestinatario
            // 
            this.txt_nombreDestinatario.BackColor = System.Drawing.Color.White;
            this.txt_nombreDestinatario.Enabled = false;
            this.txt_nombreDestinatario.Location = new System.Drawing.Point(494, 16);
            this.txt_nombreDestinatario.Name = "txt_nombreDestinatario";
            this.txt_nombreDestinatario.Size = new System.Drawing.Size(278, 20);
            this.txt_nombreDestinatario.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label4.Location = new System.Drawing.Point(426, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Nombre:";
            // 
            // txt_direccionDestinatario
            // 
            this.txt_direccionDestinatario.BackColor = System.Drawing.Color.White;
            this.txt_direccionDestinatario.Location = new System.Drawing.Point(105, 42);
            this.txt_direccionDestinatario.Name = "txt_direccionDestinatario";
            this.txt_direccionDestinatario.Size = new System.Drawing.Size(667, 20);
            this.txt_direccionDestinatario.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label6.Location = new System.Drawing.Point(27, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Dirección:";
            // 
            // txt_cedulaTransportista
            // 
            this.txt_cedulaTransportista.BackColor = System.Drawing.Color.White;
            this.txt_cedulaTransportista.Enabled = false;
            this.txt_cedulaTransportista.Location = new System.Drawing.Point(112, 19);
            this.txt_cedulaTransportista.Name = "txt_cedulaTransportista";
            this.txt_cedulaTransportista.ReadOnly = true;
            this.txt_cedulaTransportista.Size = new System.Drawing.Size(249, 20);
            this.txt_cedulaTransportista.TabIndex = 7;
            this.txt_cedulaTransportista.TextChanged += new System.EventHandler(this.txt_cedulaTransportista_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label9.Location = new System.Drawing.Point(33, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 15);
            this.label9.TabIndex = 17;
            this.label9.Text = "R.U.C/C.I.:";
            // 
            // txt_nombreTransportista
            // 
            this.txt_nombreTransportista.BackColor = System.Drawing.Color.White;
            this.txt_nombreTransportista.Enabled = false;
            this.txt_nombreTransportista.Location = new System.Drawing.Point(501, 19);
            this.txt_nombreTransportista.Name = "txt_nombreTransportista";
            this.txt_nombreTransportista.Size = new System.Drawing.Size(278, 20);
            this.txt_nombreTransportista.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label10.Location = new System.Drawing.Point(433, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 15);
            this.label10.TabIndex = 15;
            this.label10.Text = "Nombre:";
            // 
            // txt_placaTransportista
            // 
            this.txt_placaTransportista.Location = new System.Drawing.Point(112, 46);
            this.txt_placaTransportista.Name = "txt_placaTransportista";
            this.txt_placaTransportista.Size = new System.Drawing.Size(278, 20);
            this.txt_placaTransportista.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label11.Location = new System.Drawing.Point(59, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 15);
            this.label11.TabIndex = 19;
            this.label11.Text = "Placa:";
            // 
            // dtp_fechaInicioTraslado
            // 
            this.dtp_fechaInicioTraslado.Location = new System.Drawing.Point(112, 76);
            this.dtp_fechaInicioTraslado.Name = "dtp_fechaInicioTraslado";
            this.dtp_fechaInicioTraslado.Size = new System.Drawing.Size(278, 20);
            this.dtp_fechaInicioTraslado.TabIndex = 3;
            // 
            // dtp_fechaFinTraslado
            // 
            this.dtp_fechaFinTraslado.Location = new System.Drawing.Point(501, 76);
            this.dtp_fechaFinTraslado.Name = "dtp_fechaFinTraslado";
            this.dtp_fechaFinTraslado.Size = new System.Drawing.Size(278, 20);
            this.dtp_fechaFinTraslado.TabIndex = 4;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.tsb_guardar,
            this.toolStripSeparator2,
            this.tsb_editar,
            this.tsb_anular,
            this.toolStripSeparator3,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(807, 27);
            this.toolStrip1.TabIndex = 30;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::Pos.Properties.Resources.guardar;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Padding = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.toolStripButton1.Size = new System.Drawing.Size(132, 24);
            this.toolStripButton1.Text = "Nuevo";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tsb_guardar
            // 
            this.tsb_guardar.Image = global::Pos.Properties.Resources.pos;
            this.tsb_guardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_guardar.Name = "tsb_guardar";
            this.tsb_guardar.Padding = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.tsb_guardar.Size = new System.Drawing.Size(215, 24);
            this.tsb_guardar.Text = "Guardar e Imprimir";
            this.tsb_guardar.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // tsb_editar
            // 
            this.tsb_editar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsb_editar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_editar.Image = global::Pos.Properties.Resources.editar_fila;
            this.tsb_editar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_editar.Name = "tsb_editar";
            this.tsb_editar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsb_editar.Size = new System.Drawing.Size(23, 24);
            this.tsb_editar.Text = "Valores por defecto";
            this.tsb_editar.Visible = false;
            this.tsb_editar.Click += new System.EventHandler(this.tsb_editar_Click);
            // 
            // tsb_anular
            // 
            this.tsb_anular.Image = global::Pos.Properties.Resources.borrar_fila;
            this.tsb_anular.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_anular.Name = "tsb_anular";
            this.tsb_anular.Padding = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.tsb_anular.Size = new System.Drawing.Size(132, 24);
            this.tsb_anular.Text = "Anular";
            this.tsb_anular.Click += new System.EventHandler(this.tsb_anular_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::Pos.Properties.Resources.icono_impresora16x16;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Padding = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.toolStripButton3.Size = new System.Drawing.Size(146, 24);
            this.toolStripButton3.Text = "Imprimir";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // grw_productos
            // 
            this.grw_productos.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grw_productos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grw_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grw_productos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre,
            this.cantidad,
            this.unidad,
            this.botonEliminar});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grw_productos.DefaultCellStyle = dataGridViewCellStyle2;
            this.grw_productos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grw_productos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grw_productos.Location = new System.Drawing.Point(3, 130);
            this.grw_productos.MultiSelect = false;
            this.grw_productos.Name = "grw_productos";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grw_productos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grw_productos.RowHeadersVisible = false;
            this.grw_productos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grw_productos.Size = new System.Drawing.Size(793, 243);
            this.grw_productos.TabIndex = 21;
            this.grw_productos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grw_productos_CellContentClick);
            this.grw_productos.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.grw_ubicaciones_CellPainting);
            this.grw_productos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grw_productos_CellValueChanged);
            this.grw_productos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grw_ubicaciones_EditingControlShowing);
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
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            // 
            // cantidad
            // 
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            // 
            // unidad
            // 
            this.unidad.HeaderText = "Unidad";
            this.unidad.Name = "unidad";
            // 
            // botonEliminar
            // 
            this.botonEliminar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.botonEliminar.HeaderText = "";
            this.botonEliminar.Name = "botonEliminar";
            // 
            // tbc_destinatarios
            // 
            this.tbc_destinatarios.Controls.Add(this.tabPage1);
            this.tbc_destinatarios.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbc_destinatarios.Location = new System.Drawing.Point(0, 235);
            this.tbc_destinatarios.Name = "tbc_destinatarios";
            this.tbc_destinatarios.SelectedIndex = 0;
            this.tbc_destinatarios.Size = new System.Drawing.Size(807, 402);
            this.tbc_destinatarios.TabIndex = 36;
            this.tbc_destinatarios.SelectedIndexChanged += new System.EventHandler(this.tbc_destinatarios_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txt_ruta);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txt_codigoDestino);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.grw_productos);
            this.tabPage1.Controls.Add(this.txt_motivoDestinatario);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.btn_buscarCliente);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.txt_documento);
            this.tabPage1.Controls.Add(this.txt_nombreDestinatario);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txt_cedulaDestinatario);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txt_direccionDestinatario);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(799, 376);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Destinatario 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txt_ruta
            // 
            this.txt_ruta.Location = new System.Drawing.Point(494, 68);
            this.txt_ruta.MaxLength = 100;
            this.txt_ruta.Name = "txt_ruta";
            this.txt_ruta.Size = new System.Drawing.Size(278, 20);
            this.txt_ruta.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label8.Location = new System.Drawing.Point(447, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 15);
            this.label8.TabIndex = 48;
            this.label8.Text = "Ruta:";
            // 
            // txt_codigoDestino
            // 
            this.txt_codigoDestino.Location = new System.Drawing.Point(105, 68);
            this.txt_codigoDestino.MaxLength = 3;
            this.txt_codigoDestino.Name = "txt_codigoDestino";
            this.txt_codigoDestino.Size = new System.Drawing.Size(278, 20);
            this.txt_codigoDestino.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label7.Location = new System.Drawing.Point(10, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 15);
            this.label7.TabIndex = 46;
            this.label7.Text = "Cod Destino:";
            // 
            // txt_motivoDestinatario
            // 
            this.txt_motivoDestinatario.Location = new System.Drawing.Point(494, 96);
            this.txt_motivoDestinatario.Name = "txt_motivoDestinatario";
            this.txt_motivoDestinatario.Size = new System.Drawing.Size(278, 20);
            this.txt_motivoDestinatario.TabIndex = 20;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label14.Location = new System.Drawing.Point(435, 99);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 15);
            this.label14.TabIndex = 40;
            this.label14.Text = "Motivo:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.button1.BackgroundImage = global::Pos.Properties.Resources.buscar_lupa;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("Maiandra GD", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(361, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(22, 23);
            this.button1.TabIndex = 19;
            this.button1.Tag = "Buscar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_buscarCliente
            // 
            this.btn_buscarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.btn_buscarCliente.BackgroundImage = global::Pos.Properties.Resources.buscar_lupa;
            this.btn_buscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_buscarCliente.Font = new System.Drawing.Font("Maiandra GD", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buscarCliente.Location = new System.Drawing.Point(361, 15);
            this.btn_buscarCliente.Name = "btn_buscarCliente";
            this.btn_buscarCliente.Size = new System.Drawing.Size(22, 23);
            this.btn_buscarCliente.TabIndex = 13;
            this.btn_buscarCliente.Tag = "Buscar";
            this.btn_buscarCliente.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_buscarCliente.UseVisualStyleBackColor = false;
            this.btn_buscarCliente.Click += new System.EventHandler(this.btn_buscarCliente_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label12.Location = new System.Drawing.Point(15, 99);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 15);
            this.label12.TabIndex = 37;
            this.label12.Text = "Documento:";
            // 
            // txt_documento
            // 
            this.txt_documento.BackColor = System.Drawing.Color.White;
            this.txt_documento.Enabled = false;
            this.txt_documento.Location = new System.Drawing.Point(105, 96);
            this.txt_documento.Name = "txt_documento";
            this.txt_documento.Size = new System.Drawing.Size(249, 20);
            this.txt_documento.TabIndex = 18;
            // 
            // btn_transportista
            // 
            this.btn_transportista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.btn_transportista.BackgroundImage = global::Pos.Properties.Resources.buscar_lupa;
            this.btn_transportista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_transportista.Font = new System.Drawing.Font("Maiandra GD", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_transportista.Location = new System.Drawing.Point(368, 18);
            this.btn_transportista.Name = "btn_transportista";
            this.btn_transportista.Size = new System.Drawing.Size(22, 23);
            this.btn_transportista.TabIndex = 8;
            this.btn_transportista.Tag = "Buscar";
            this.btn_transportista.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_transportista.UseVisualStyleBackColor = false;
            this.btn_transportista.Click += new System.EventHandler(this.btn_transportista_Click);
            // 
            // txt_correoTransportista
            // 
            this.txt_correoTransportista.BackColor = System.Drawing.Color.White;
            this.txt_correoTransportista.Enabled = false;
            this.txt_correoTransportista.Location = new System.Drawing.Point(501, 46);
            this.txt_correoTransportista.Name = "txt_correoTransportista";
            this.txt_correoTransportista.Size = new System.Drawing.Size(278, 20);
            this.txt_correoTransportista.TabIndex = 11;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label16.Location = new System.Drawing.Point(441, 49);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 15);
            this.label16.TabIndex = 42;
            this.label16.Text = "Correo:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbc_destinatarios);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(807, 637);
            this.panel1.TabIndex = 33;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_correoTransportista);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.btn_transportista);
            this.groupBox3.Controls.Add(this.txt_nombreTransportista);
            this.groupBox3.Controls.Add(this.txt_cedulaTransportista);
            this.groupBox3.Controls.Add(this.txt_placaTransportista);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 164);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(807, 73);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Transportista";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_autorizacion);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dtp_fechaEmision);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txt_descripcion);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txt_direccionPartida);
            this.groupBox2.Controls.Add(this.dtp_fechaFinTraslado);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.dtp_fechaInicioTraslado);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.txt_numeroDocumento);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.txt_secuencia);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(807, 164);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Guía Remisión";
            // 
            // txt_autorizacion
            // 
            this.txt_autorizacion.BackColor = System.Drawing.Color.White;
            this.txt_autorizacion.Enabled = false;
            this.txt_autorizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.txt_autorizacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_autorizacion.Location = new System.Drawing.Point(501, 45);
            this.txt_autorizacion.MaxLength = 17;
            this.txt_autorizacion.Name = "txt_autorizacion";
            this.txt_autorizacion.Size = new System.Drawing.Size(278, 21);
            this.txt_autorizacion.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label5.Location = new System.Drawing.Point(405, 46);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label5.Size = new System.Drawing.Size(90, 18);
            this.label5.TabIndex = 33;
            this.label5.Text = "Autorización:";
            // 
            // dtp_fechaEmision
            // 
            this.dtp_fechaEmision.Location = new System.Drawing.Point(112, 45);
            this.dtp_fechaEmision.Name = "dtp_fechaEmision";
            this.dtp_fechaEmision.Size = new System.Drawing.Size(278, 20);
            this.dtp_fechaEmision.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(43, 46);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label2.Size = new System.Drawing.Size(63, 18);
            this.label2.TabIndex = 30;
            this.label2.Text = "Emisión:";
            // 
            // txt_descripcion
            // 
            this.txt_descripcion.BackColor = System.Drawing.Color.White;
            this.txt_descripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txt_descripcion.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_descripcion.Location = new System.Drawing.Point(112, 134);
            this.txt_descripcion.Multiline = true;
            this.txt_descripcion.Name = "txt_descripcion";
            this.txt_descripcion.Size = new System.Drawing.Size(667, 20);
            this.txt_descripcion.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(22, 135);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label1.Size = new System.Drawing.Size(87, 18);
            this.label1.TabIndex = 28;
            this.label1.Text = "Descripción:";
            // 
            // txt_direccionPartida
            // 
            this.txt_direccionPartida.BackColor = System.Drawing.Color.White;
            this.txt_direccionPartida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txt_direccionPartida.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_direccionPartida.Location = new System.Drawing.Point(112, 106);
            this.txt_direccionPartida.Name = "txt_direccionPartida";
            this.txt_direccionPartida.Size = new System.Drawing.Size(667, 20);
            this.txt_direccionPartida.TabIndex = 5;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label26.Location = new System.Drawing.Point(22, 107);
            this.label26.Name = "label26";
            this.label26.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label26.Size = new System.Drawing.Size(84, 18);
            this.label26.TabIndex = 5;
            this.label26.Text = "Dir. Partida:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label22.Location = new System.Drawing.Point(421, 77);
            this.label22.Name = "label22";
            this.label22.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label22.Size = new System.Drawing.Size(74, 18);
            this.label22.TabIndex = 5;
            this.label22.Text = "Fecha Fin:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label21.Location = new System.Drawing.Point(17, 77);
            this.label21.Name = "label21";
            this.label21.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label21.Size = new System.Drawing.Size(89, 18);
            this.label21.TabIndex = 1;
            this.label21.Text = "Fecha Inicio:";
            // 
            // txt_numeroDocumento
            // 
            this.txt_numeroDocumento.BackColor = System.Drawing.Color.White;
            this.txt_numeroDocumento.Enabled = false;
            this.txt_numeroDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.txt_numeroDocumento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_numeroDocumento.Location = new System.Drawing.Point(501, 18);
            this.txt_numeroDocumento.MaxLength = 17;
            this.txt_numeroDocumento.Name = "txt_numeroDocumento";
            this.txt_numeroDocumento.Size = new System.Drawing.Size(278, 21);
            this.txt_numeroDocumento.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.button3.BackgroundImage = global::Pos.Properties.Resources.buscar_lupa;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Font = new System.Drawing.Font("Maiandra GD", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(368, 17);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(22, 23);
            this.button3.TabIndex = 9;
            this.button3.Tag = "Buscar";
            this.button3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label19.Location = new System.Drawing.Point(411, 19);
            this.label19.Name = "label19";
            this.label19.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label19.Size = new System.Drawing.Size(84, 18);
            this.label19.TabIndex = 3;
            this.label19.Text = "Documento:";
            // 
            // txt_secuencia
            // 
            this.txt_secuencia.BackColor = System.Drawing.Color.White;
            this.txt_secuencia.Enabled = false;
            this.txt_secuencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.txt_secuencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txt_secuencia.Location = new System.Drawing.Point(112, 18);
            this.txt_secuencia.Name = "txt_secuencia";
            this.txt_secuencia.Size = new System.Drawing.Size(249, 21);
            this.txt_secuencia.TabIndex = 0;
            this.txt_secuencia.TextChanged += new System.EventHandler(this.txt_secuencia_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label18.Location = new System.Drawing.Point(28, 19);
            this.label18.Name = "label18";
            this.label18.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label18.Size = new System.Drawing.Size(78, 18);
            this.label18.TabIndex = 19;
            this.label18.Text = "Secuencia:";
            // 
            // frm_guiaRemision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(807, 665);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frm_guiaRemision";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Guía de Remisión";
            this.Load += new System.EventHandler(this.frm_guiaRemision_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grw_productos)).EndInit();
            this.tbc_destinatarios.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_cedulaDestinatario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_nombreDestinatario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_direccionDestinatario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_cedulaTransportista;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_nombreTransportista;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_placaTransportista;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtp_fechaInicioTraslado;
        private System.Windows.Forms.DateTimePicker dtp_fechaFinTraslado;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView grw_productos;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsb_guardar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidad;
        private System.Windows.Forms.DataGridViewButtonColumn botonEliminar;
        private System.Windows.Forms.ToolStripButton tsb_editar;
        private System.Windows.Forms.TabControl tbc_destinatarios;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_documento;
        private System.Windows.Forms.Button btn_buscarCliente;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_correoTransportista;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btn_transportista;
        private System.Windows.Forms.TextBox txt_motivoDestinatario;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txt_secuencia;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txt_numeroDocumento;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txt_direccionPartida;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_autorizacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtp_fechaEmision;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_descripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ruta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_codigoDestino;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsb_anular;


    }
}