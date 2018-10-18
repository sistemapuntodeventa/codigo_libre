namespace Pos.App
{
    partial class frm_factura
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_factura));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grw_productos = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.botonBuscar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioU = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pdesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotaldesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.botonEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.id_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.llena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_detalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.promocion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pvp_manual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modifico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.combo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lista_combo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referencia_combo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tco_formaPago = new System.Windows.Forms.TabControl();
            this.tab_abono = new System.Windows.Forms.TabPage();
            this.btn_agregarPago = new System.Windows.Forms.Button();
            this.grw_abonos = new System.Windows.Forms.DataGridView();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nuevo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.botonEliminarPago = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tab_efectivo = new System.Windows.Forms.TabPage();
            this.txt_propina = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txt_efectivo = new System.Windows.Forms.TextBox();
            this.lbl_efectivo = new System.Windows.Forms.Label();
            this.txt_numerot1 = new System.Windows.Forms.TextBox();
            this.cmb_pin2 = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txt_montot1 = new System.Windows.Forms.TextBox();
            this.txt_numerot2 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_montot2 = new System.Windows.Forms.TextBox();
            this.cmb_tipo2 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lbl_ntarjeta = new System.Windows.Forms.Label();
            this.lbl_tipo = new System.Windows.Forms.Label();
            this.cmb_tipo1 = new System.Windows.Forms.ComboBox();
            this.lbl_montot = new System.Windows.Forms.Label();
            this.cmb_pin1 = new System.Windows.Forms.ComboBox();
            this.tab_cheque = new System.Windows.Forms.TabPage();
            this.lbl_ncheque = new System.Windows.Forms.Label();
            this.txt_montoc = new System.Windows.Forms.TextBox();
            this.lbl_montoc = new System.Windows.Forms.Label();
            this.txt_numeroc = new System.Windows.Forms.TextBox();
            this.txt_banco = new System.Windows.Forms.TextBox();
            this.lbl_banco = new System.Windows.Forms.Label();
            this.tab_retencion = new System.Windows.Forms.TabPage();
            this.label26 = new System.Windows.Forms.Label();
            this.txt_retencion = new System.Windows.Forms.TextBox();
            this.txt_numeroRetencion = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.tab_notaCredito = new System.Windows.Forms.TabPage();
            this.label29 = new System.Windows.Forms.Label();
            this.txt_montoNota = new System.Windows.Forms.TextBox();
            this.txt_numeroNota = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.grp_total = new System.Windows.Forms.GroupBox();
            this.pan_vuelto = new System.Windows.Forms.Panel();
            this.txt_vuelto = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.pan_totales = new System.Windows.Forms.Panel();
            this.txt_saldo = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.txt_totalpago = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.txt_total = new System.Windows.Forms.Label();
            this.chk_todoEfectivo = new System.Windows.Forms.CheckBox();
            this.chk_servicio = new System.Windows.Forms.CheckBox();
            this.cmb_vendedor = new System.Windows.Forms.ComboBox();
            this.lbl_vendedor = new System.Windows.Forms.Label();
            this.txt_servicio = new System.Windows.Forms.TextBox();
            this.lbl_servicio = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txt_iva12 = new System.Windows.Forms.TextBox();
            this.txt_iva0 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_iva = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_descuento = new System.Windows.Forms.TextBox();
            this.grb_extras = new System.Windows.Forms.GroupBox();
            this.btn_buscarCliente = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Nombres = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_ruc = new System.Windows.Forms.TextBox();
            this.btn_crearCliente = new System.Windows.Forms.Button();
            this.flp_datosFactura = new System.Windows.Forms.FlowLayoutPanel();
            this.flp_personas = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.txt_secuencia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.txt_numDoc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_fecha = new System.Windows.Forms.Label();
            this.flp_tipoDocumento = new System.Windows.Forms.FlowLayoutPanel();
            this.chk_dna = new System.Windows.Forms.CheckBox();
            this.txt_tipo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.flp_autorizacion = new System.Windows.Forms.FlowLayoutPanel();
            this.txt_numAut = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.cmb_estado = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.chk_descProd = new System.Windows.Forms.CheckBox();
            this.txt_descProducto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.flp_fechaVencimiento = new System.Windows.Forms.FlowLayoutPanel();
            this.dtp_vencimiento = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.flp_descripcion = new System.Windows.Forms.FlowLayoutPanel();
            this.txt_descipcion = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.tsb_nuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_guardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_imprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_anular = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_duplicar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsb_preCuenta = new System.Windows.Forms.ToolStripMenuItem();
            this.tsb_imprimirFactura = new System.Windows.Forms.ToolStripMenuItem();
            this.tls_guia = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_guia = new System.Windows.Forms.ToolStripButton();
            this.tsb_reversar = new System.Windows.Forms.ToolStripButton();
            this.cms_clickDerecho = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmi_pendientes = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_nuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_tipoDocumento = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_autorizacion = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_fechaVencimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_descripcion = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_descripcionProducto = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.grb_pendientes = new System.Windows.Forms.GroupBox();
            this.flp_pendientes = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grw_productos)).BeginInit();
            this.panel1.SuspendLayout();
            this.tco_formaPago.SuspendLayout();
            this.tab_abono.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grw_abonos)).BeginInit();
            this.tab_efectivo.SuspendLayout();
            this.tab_cheque.SuspendLayout();
            this.tab_retencion.SuspendLayout();
            this.tab_notaCredito.SuspendLayout();
            this.grp_total.SuspendLayout();
            this.pan_vuelto.SuspendLayout();
            this.pan_totales.SuspendLayout();
            this.grb_extras.SuspendLayout();
            this.flp_datosFactura.SuspendLayout();
            this.flp_personas.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flp_tipoDocumento.SuspendLayout();
            this.flp_autorizacion.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.flowLayoutPanel7.SuspendLayout();
            this.flp_fechaVencimiento.SuspendLayout();
            this.flp_descripcion.SuspendLayout();
            this.menu.SuspendLayout();
            this.cms_clickDerecho.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grb_pendientes.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.grb_extras);
            this.groupBox1.Controls.Add(this.flp_datosFactura);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.groupBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(947, 628);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Factura";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grw_productos);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.groupBox2.Location = new System.Drawing.Point(3, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(941, 274);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Productos";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // grw_productos
            // 
            this.grw_productos.AllowUserToAddRows = false;
            this.grw_productos.AllowUserToDeleteRows = false;
            this.grw_productos.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grw_productos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grw_productos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grw_productos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grw_productos.BackgroundColor = System.Drawing.Color.White;
            this.grw_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grw_productos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.botonBuscar,
            this.producto,
            this.serie,
            this.cantidad,
            this.descripcion,
            this.precioU,
            this.unidad,
            this.pdesc,
            this.subtotaldesc,
            this.subtotal,
            this.botonEliminar,
            this.id_producto,
            this.iva,
            this.ice,
            this.cantidadStock,
            this.llena,
            this.id_detalle,
            this.promocion,
            this.id_categoria,
            this.pvp_manual,
            this.id_serie,
            this.modifico,
            this.combo,
            this.lista_combo,
            this.referencia_combo});
            this.grw_productos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grw_productos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grw_productos.Location = new System.Drawing.Point(3, 17);
            this.grw_productos.Name = "grw_productos";
            this.grw_productos.RowHeadersVisible = false;
            this.grw_productos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grw_productos.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.grw_productos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grw_productos.Size = new System.Drawing.Size(935, 254);
            this.grw_productos.TabIndex = 0;
            this.grw_productos.TabStop = false;
            this.grw_productos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grw_productos_CellClick);
            this.grw_productos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grw_productos_CellContentClick);
            this.grw_productos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grw_productos_CellDoubleClick);
            this.grw_productos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grw_productos_cellEndEdit);
            this.grw_productos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grw_productos_CellFormatting);
            this.grw_productos.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.grw_productos_CellPainting);
            this.grw_productos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grw_productos_CellValueChanged_1);
            this.grw_productos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grw_productos_DataError);
            this.grw_productos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grw_productos_EditingControlShowing);
            this.grw_productos.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.grw_productos_RowsRemoved);
            // 
            // codigo
            // 
            this.codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.codigo.FillWeight = 21.61776F;
            this.codigo.HeaderText = "Código";
            this.codigo.MaxInputLength = 35;
            this.codigo.Name = "codigo";
            this.codigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.codigo.Width = 80;
            // 
            // botonBuscar
            // 
            this.botonBuscar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.botonBuscar.FillWeight = 0.6880362F;
            this.botonBuscar.HeaderText = "";
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.ToolTipText = "Buscar Productos";
            this.botonBuscar.Width = 21;
            // 
            // producto
            // 
            this.producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.producto.FillWeight = 27.29844F;
            this.producto.HeaderText = "Producto";
            this.producto.Name = "producto";
            this.producto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.producto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.producto.Width = 300;
            // 
            // serie
            // 
            this.serie.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(255)))), ((int)(((byte)(187)))));
            this.serie.DefaultCellStyle = dataGridViewCellStyle2;
            this.serie.HeaderText = "Serie";
            this.serie.Name = "serie";
            this.serie.ReadOnly = true;
            this.serie.Visible = false;
            // 
            // cantidad
            // 
            this.cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cantidad.FillWeight = 36.24444F;
            this.cantidad.HeaderText = "Cant.";
            this.cantidad.MaxInputLength = 8;
            this.cantidad.Name = "cantidad";
            this.cantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cantidad.Width = 50;
            // 
            // descripcion
            // 
            this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.MaxInputLength = 100;
            this.descripcion.Name = "descripcion";
            // 
            // precioU
            // 
            this.precioU.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(255)))), ((int)(((byte)(187)))));
            this.precioU.DefaultCellStyle = dataGridViewCellStyle3;
            this.precioU.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.precioU.FillWeight = 0.6774454F;
            this.precioU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.precioU.HeaderText = "PVP.";
            this.precioU.Name = "precioU";
            this.precioU.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.precioU.Width = 60;
            // 
            // unidad
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(255)))), ((int)(((byte)(187)))));
            this.unidad.DefaultCellStyle = dataGridViewCellStyle4;
            this.unidad.FillWeight = 8.858236F;
            this.unidad.HeaderText = "Unidad";
            this.unidad.Name = "unidad";
            this.unidad.ReadOnly = true;
            this.unidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.unidad.Visible = false;
            // 
            // pdesc
            // 
            this.pdesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.pdesc.FillWeight = 0.3577775F;
            this.pdesc.HeaderText = "%Des.";
            this.pdesc.MaxInputLength = 5;
            this.pdesc.Name = "pdesc";
            this.pdesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pdesc.Width = 50;
            // 
            // subtotaldesc
            // 
            this.subtotaldesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(255)))), ((int)(((byte)(187)))));
            this.subtotaldesc.DefaultCellStyle = dataGridViewCellStyle5;
            this.subtotaldesc.FillWeight = 7.950681F;
            this.subtotaldesc.HeaderText = "Desc.";
            this.subtotaldesc.Name = "subtotaldesc";
            this.subtotaldesc.ReadOnly = true;
            this.subtotaldesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.subtotaldesc.Width = 50;
            // 
            // subtotal
            // 
            this.subtotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(255)))), ((int)(((byte)(187)))));
            this.subtotal.DefaultCellStyle = dataGridViewCellStyle6;
            this.subtotal.FillWeight = 33.12784F;
            this.subtotal.HeaderText = "Subtotal";
            this.subtotal.Name = "subtotal";
            this.subtotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.subtotal.Width = 60;
            // 
            // botonEliminar
            // 
            this.botonEliminar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.botonEliminar.FillWeight = 0.2457374F;
            this.botonEliminar.HeaderText = "";
            this.botonEliminar.Name = "botonEliminar";
            this.botonEliminar.Text = "";
            this.botonEliminar.ToolTipText = "Eliminar";
            this.botonEliminar.UseColumnTextForButtonValue = true;
            this.botonEliminar.Width = 21;
            // 
            // id_producto
            // 
            this.id_producto.HeaderText = "id_producto";
            this.id_producto.Name = "id_producto";
            this.id_producto.ReadOnly = true;
            this.id_producto.Visible = false;
            // 
            // iva
            // 
            this.iva.HeaderText = "iva";
            this.iva.Name = "iva";
            this.iva.ReadOnly = true;
            this.iva.Visible = false;
            // 
            // ice
            // 
            this.ice.HeaderText = "ice";
            this.ice.Name = "ice";
            this.ice.ReadOnly = true;
            this.ice.Visible = false;
            // 
            // cantidadStock
            // 
            this.cantidadStock.HeaderText = "cantidadStock";
            this.cantidadStock.Name = "cantidadStock";
            this.cantidadStock.ReadOnly = true;
            this.cantidadStock.Visible = false;
            // 
            // llena
            // 
            this.llena.HeaderText = "";
            this.llena.Name = "llena";
            this.llena.ReadOnly = true;
            this.llena.Visible = false;
            // 
            // id_detalle
            // 
            this.id_detalle.HeaderText = "";
            this.id_detalle.Name = "id_detalle";
            this.id_detalle.ReadOnly = true;
            this.id_detalle.Visible = false;
            // 
            // promocion
            // 
            this.promocion.HeaderText = "";
            this.promocion.Name = "promocion";
            this.promocion.Visible = false;
            // 
            // id_categoria
            // 
            this.id_categoria.HeaderText = "";
            this.id_categoria.Name = "id_categoria";
            this.id_categoria.ReadOnly = true;
            this.id_categoria.Visible = false;
            // 
            // pvp_manual
            // 
            this.pvp_manual.HeaderText = "";
            this.pvp_manual.Name = "pvp_manual";
            this.pvp_manual.Visible = false;
            // 
            // id_serie
            // 
            this.id_serie.HeaderText = "seriado";
            this.id_serie.Name = "id_serie";
            this.id_serie.Visible = false;
            // 
            // modifico
            // 
            this.modifico.HeaderText = "modifico";
            this.modifico.Name = "modifico";
            this.modifico.Visible = false;
            // 
            // combo
            // 
            this.combo.HeaderText = "combo";
            this.combo.Name = "combo";
            this.combo.Visible = false;
            // 
            // lista_combo
            // 
            this.lista_combo.HeaderText = "lista_combo";
            this.lista_combo.Name = "lista_combo";
            this.lista_combo.Visible = false;
            // 
            // referencia_combo
            // 
            this.referencia_combo.HeaderText = "referencia_combo";
            this.referencia_combo.Name = "referencia_combo";
            this.referencia_combo.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tco_formaPago);
            this.panel1.Controls.Add(this.grp_total);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 428);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(941, 197);
            this.panel1.TabIndex = 39;
            // 
            // tco_formaPago
            // 
            this.tco_formaPago.Controls.Add(this.tab_abono);
            this.tco_formaPago.Controls.Add(this.tab_efectivo);
            this.tco_formaPago.Controls.Add(this.tab_cheque);
            this.tco_formaPago.Controls.Add(this.tab_retencion);
            this.tco_formaPago.Controls.Add(this.tab_notaCredito);
            this.tco_formaPago.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tco_formaPago.Location = new System.Drawing.Point(0, 0);
            this.tco_formaPago.Name = "tco_formaPago";
            this.tco_formaPago.SelectedIndex = 0;
            this.tco_formaPago.Size = new System.Drawing.Size(452, 197);
            this.tco_formaPago.TabIndex = 1;
            // 
            // tab_abono
            // 
            this.tab_abono.BackColor = System.Drawing.Color.Transparent;
            this.tab_abono.Controls.Add(this.btn_agregarPago);
            this.tab_abono.Controls.Add(this.grw_abonos);
            this.tab_abono.Location = new System.Drawing.Point(4, 22);
            this.tab_abono.Name = "tab_abono";
            this.tab_abono.Padding = new System.Windows.Forms.Padding(3);
            this.tab_abono.Size = new System.Drawing.Size(444, 171);
            this.tab_abono.TabIndex = 4;
            this.tab_abono.Text = "Pago Parcial";
            this.tab_abono.Click += new System.EventHandler(this.tab_abono_Click);
            // 
            // btn_agregarPago
            // 
            this.btn_agregarPago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_agregarPago.ForeColor = System.Drawing.Color.Black;
            this.btn_agregarPago.Location = new System.Drawing.Point(363, 131);
            this.btn_agregarPago.Name = "btn_agregarPago";
            this.btn_agregarPago.Size = new System.Drawing.Size(75, 34);
            this.btn_agregarPago.TabIndex = 1;
            this.btn_agregarPago.Text = "Agregar";
            this.btn_agregarPago.UseVisualStyleBackColor = true;
            this.btn_agregarPago.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // grw_abonos
            // 
            this.grw_abonos.AllowUserToAddRows = false;
            this.grw_abonos.AllowUserToDeleteRows = false;
            this.grw_abonos.AllowUserToResizeColumns = false;
            this.grw_abonos.AllowUserToResizeRows = false;
            this.grw_abonos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grw_abonos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grw_abonos.BackgroundColor = System.Drawing.Color.White;
            this.grw_abonos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grw_abonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grw_abonos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.valor,
            this.tipo,
            this.nuevo,
            this.botonEliminarPago});
            this.grw_abonos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grw_abonos.Location = new System.Drawing.Point(3, 3);
            this.grw_abonos.Name = "grw_abonos";
            this.grw_abonos.ReadOnly = true;
            this.grw_abonos.RowHeadersVisible = false;
            this.grw_abonos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grw_abonos.Size = new System.Drawing.Size(438, 122);
            this.grw_abonos.TabIndex = 0;
            this.grw_abonos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grw_abonos_CellContentClick);
            this.grw_abonos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grw_abonos_CellDoubleClick);
            this.grw_abonos.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.grw_abonos_CellPainting);
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // valor
            // 
            this.valor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.valor.HeaderText = "Valor";
            this.valor.Name = "valor";
            this.valor.ReadOnly = true;
            // 
            // tipo
            // 
            this.tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tipo.HeaderText = "Tipo";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            // 
            // nuevo
            // 
            this.nuevo.HeaderText = "nuevo";
            this.nuevo.Name = "nuevo";
            this.nuevo.ReadOnly = true;
            this.nuevo.Visible = false;
            // 
            // botonEliminarPago
            // 
            this.botonEliminarPago.HeaderText = "";
            this.botonEliminarPago.Name = "botonEliminarPago";
            this.botonEliminarPago.ReadOnly = true;
            // 
            // tab_efectivo
            // 
            this.tab_efectivo.BackColor = System.Drawing.Color.White;
            this.tab_efectivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tab_efectivo.Controls.Add(this.txt_propina);
            this.tab_efectivo.Controls.Add(this.label27);
            this.tab_efectivo.Controls.Add(this.txt_efectivo);
            this.tab_efectivo.Controls.Add(this.lbl_efectivo);
            this.tab_efectivo.Controls.Add(this.txt_numerot1);
            this.tab_efectivo.Controls.Add(this.cmb_pin2);
            this.tab_efectivo.Controls.Add(this.label24);
            this.tab_efectivo.Controls.Add(this.txt_montot1);
            this.tab_efectivo.Controls.Add(this.txt_numerot2);
            this.tab_efectivo.Controls.Add(this.label22);
            this.tab_efectivo.Controls.Add(this.label15);
            this.tab_efectivo.Controls.Add(this.txt_montot2);
            this.tab_efectivo.Controls.Add(this.cmb_tipo2);
            this.tab_efectivo.Controls.Add(this.label11);
            this.tab_efectivo.Controls.Add(this.label23);
            this.tab_efectivo.Controls.Add(this.lbl_ntarjeta);
            this.tab_efectivo.Controls.Add(this.lbl_tipo);
            this.tab_efectivo.Controls.Add(this.cmb_tipo1);
            this.tab_efectivo.Controls.Add(this.lbl_montot);
            this.tab_efectivo.Controls.Add(this.cmb_pin1);
            this.tab_efectivo.Location = new System.Drawing.Point(4, 22);
            this.tab_efectivo.Name = "tab_efectivo";
            this.tab_efectivo.Padding = new System.Windows.Forms.Padding(3);
            this.tab_efectivo.Size = new System.Drawing.Size(444, 171);
            this.tab_efectivo.TabIndex = 0;
            this.tab_efectivo.Text = "Efectivo/Crédito";
            // 
            // txt_propina
            // 
            this.txt_propina.BackColor = System.Drawing.Color.White;
            this.txt_propina.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_propina.Location = new System.Drawing.Point(303, 16);
            this.txt_propina.MaxLength = 16;
            this.txt_propina.Name = "txt_propina";
            this.txt_propina.Size = new System.Drawing.Size(121, 21);
            this.txt_propina.TabIndex = 52;
            this.txt_propina.Text = "0";
            this.txt_propina.Click += new System.EventHandler(this.txt_monto_click);
            this.txt_propina.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CajasoloDecimales_KeyPress);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label27.Location = new System.Drawing.Point(221, 22);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(76, 13);
            this.label27.TabIndex = 53;
            this.label27.Text = "Propina T/C:";
            // 
            // txt_efectivo
            // 
            this.txt_efectivo.BackColor = System.Drawing.Color.White;
            this.txt_efectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_efectivo.Location = new System.Drawing.Point(86, 15);
            this.txt_efectivo.Name = "txt_efectivo";
            this.txt_efectivo.ShortcutsEnabled = false;
            this.txt_efectivo.Size = new System.Drawing.Size(121, 21);
            this.txt_efectivo.TabIndex = 0;
            this.txt_efectivo.Text = "0";
            this.txt_efectivo.Click += new System.EventHandler(this.txt_monto_click);
            this.txt_efectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CajasoloDecimales_KeyPress);
            this.txt_efectivo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_calcularTotalesAPagar);
            // 
            // lbl_efectivo
            // 
            this.lbl_efectivo.AutoSize = true;
            this.lbl_efectivo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_efectivo.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl_efectivo.Location = new System.Drawing.Point(28, 20);
            this.lbl_efectivo.Name = "lbl_efectivo";
            this.lbl_efectivo.Size = new System.Drawing.Size(55, 13);
            this.lbl_efectivo.TabIndex = 36;
            this.lbl_efectivo.Text = "Efectivo:";
            // 
            // txt_numerot1
            // 
            this.txt_numerot1.BackColor = System.Drawing.Color.White;
            this.txt_numerot1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_numerot1.Location = new System.Drawing.Point(88, 43);
            this.txt_numerot1.MaxLength = 16;
            this.txt_numerot1.Name = "txt_numerot1";
            this.txt_numerot1.Size = new System.Drawing.Size(121, 21);
            this.txt_numerot1.TabIndex = 1;
            this.txt_numerot1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CajasoloNumeros_KeyPress);
            // 
            // cmb_pin2
            // 
            this.cmb_pin2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_pin2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_pin2.FormattingEnabled = true;
            this.cmb_pin2.Location = new System.Drawing.Point(303, 98);
            this.cmb_pin2.Name = "cmb_pin2";
            this.cmb_pin2.Size = new System.Drawing.Size(121, 23);
            this.cmb_pin2.TabIndex = 7;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label24.Location = new System.Drawing.Point(268, 103);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(29, 13);
            this.label24.TabIndex = 51;
            this.label24.Text = "PIN:";
            // 
            // txt_montot1
            // 
            this.txt_montot1.BackColor = System.Drawing.Color.White;
            this.txt_montot1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_montot1.Location = new System.Drawing.Point(87, 70);
            this.txt_montot1.Name = "txt_montot1";
            this.txt_montot1.ShortcutsEnabled = false;
            this.txt_montot1.Size = new System.Drawing.Size(122, 21);
            this.txt_montot1.TabIndex = 2;
            this.txt_montot1.Text = "0";
            this.txt_montot1.Click += new System.EventHandler(this.txt_monto_click);
            this.txt_montot1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CajasoloDecimales_KeyPress);
            this.txt_montot1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_calcularTotalesAPagar);
            // 
            // txt_numerot2
            // 
            this.txt_numerot2.BackColor = System.Drawing.Color.White;
            this.txt_numerot2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_numerot2.Location = new System.Drawing.Point(303, 43);
            this.txt_numerot2.MaxLength = 16;
            this.txt_numerot2.Name = "txt_numerot2";
            this.txt_numerot2.Size = new System.Drawing.Size(121, 21);
            this.txt_numerot2.TabIndex = 5;
            this.txt_numerot2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CajasoloNumeros_KeyPress);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label22.Location = new System.Drawing.Point(216, 48);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(81, 13);
            this.label22.TabIndex = 44;
            this.label22.Text = "N°. Tarjeta 2:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label15.Location = new System.Drawing.Point(263, 132);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 13);
            this.label15.TabIndex = 45;
            this.label15.Text = "Tipo:";
            // 
            // txt_montot2
            // 
            this.txt_montot2.BackColor = System.Drawing.Color.White;
            this.txt_montot2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_montot2.Location = new System.Drawing.Point(305, 70);
            this.txt_montot2.Name = "txt_montot2";
            this.txt_montot2.ShortcutsEnabled = false;
            this.txt_montot2.Size = new System.Drawing.Size(121, 21);
            this.txt_montot2.TabIndex = 6;
            this.txt_montot2.Text = "0";
            this.txt_montot2.Click += new System.EventHandler(this.txt_monto_click);
            this.txt_montot2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CajasoloDecimales_KeyPress);
            this.txt_montot2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_calcularTotalesAPagar);
            // 
            // cmb_tipo2
            // 
            this.cmb_tipo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_tipo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_tipo2.FormattingEnabled = true;
            this.cmb_tipo2.Location = new System.Drawing.Point(303, 127);
            this.cmb_tipo2.Name = "cmb_tipo2";
            this.cmb_tipo2.Size = new System.Drawing.Size(121, 23);
            this.cmb_tipo2.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label11.Location = new System.Drawing.Point(251, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 47;
            this.label11.Text = "Monto:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label23.Location = new System.Drawing.Point(54, 103);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(29, 13);
            this.label23.TabIndex = 49;
            this.label23.Text = "PIN:";
            // 
            // lbl_ntarjeta
            // 
            this.lbl_ntarjeta.AutoSize = true;
            this.lbl_ntarjeta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ntarjeta.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl_ntarjeta.Location = new System.Drawing.Point(2, 48);
            this.lbl_ntarjeta.Name = "lbl_ntarjeta";
            this.lbl_ntarjeta.Size = new System.Drawing.Size(81, 13);
            this.lbl_ntarjeta.TabIndex = 31;
            this.lbl_ntarjeta.Text = "N°. Tarjeta 1:";
            // 
            // lbl_tipo
            // 
            this.lbl_tipo.AutoSize = true;
            this.lbl_tipo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tipo.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl_tipo.Location = new System.Drawing.Point(49, 132);
            this.lbl_tipo.Name = "lbl_tipo";
            this.lbl_tipo.Size = new System.Drawing.Size(34, 13);
            this.lbl_tipo.TabIndex = 32;
            this.lbl_tipo.Text = "Tipo:";
            // 
            // cmb_tipo1
            // 
            this.cmb_tipo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_tipo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_tipo1.FormattingEnabled = true;
            this.cmb_tipo1.Location = new System.Drawing.Point(87, 127);
            this.cmb_tipo1.Name = "cmb_tipo1";
            this.cmb_tipo1.Size = new System.Drawing.Size(121, 23);
            this.cmb_tipo1.TabIndex = 4;
            // 
            // lbl_montot
            // 
            this.lbl_montot.AutoSize = true;
            this.lbl_montot.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_montot.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl_montot.Location = new System.Drawing.Point(37, 75);
            this.lbl_montot.Name = "lbl_montot";
            this.lbl_montot.Size = new System.Drawing.Size(46, 13);
            this.lbl_montot.TabIndex = 34;
            this.lbl_montot.Text = "Monto:";
            // 
            // cmb_pin1
            // 
            this.cmb_pin1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_pin1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_pin1.FormattingEnabled = true;
            this.cmb_pin1.Location = new System.Drawing.Point(88, 98);
            this.cmb_pin1.Name = "cmb_pin1";
            this.cmb_pin1.Size = new System.Drawing.Size(121, 23);
            this.cmb_pin1.TabIndex = 3;
            // 
            // tab_cheque
            // 
            this.tab_cheque.BackColor = System.Drawing.Color.White;
            this.tab_cheque.Controls.Add(this.lbl_ncheque);
            this.tab_cheque.Controls.Add(this.txt_montoc);
            this.tab_cheque.Controls.Add(this.lbl_montoc);
            this.tab_cheque.Controls.Add(this.txt_numeroc);
            this.tab_cheque.Controls.Add(this.txt_banco);
            this.tab_cheque.Controls.Add(this.lbl_banco);
            this.tab_cheque.Location = new System.Drawing.Point(4, 22);
            this.tab_cheque.Name = "tab_cheque";
            this.tab_cheque.Padding = new System.Windows.Forms.Padding(3);
            this.tab_cheque.Size = new System.Drawing.Size(444, 171);
            this.tab_cheque.TabIndex = 1;
            this.tab_cheque.Text = "Cheque";
            // 
            // lbl_ncheque
            // 
            this.lbl_ncheque.AutoSize = true;
            this.lbl_ncheque.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ncheque.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl_ncheque.Location = new System.Drawing.Point(12, 20);
            this.lbl_ncheque.Name = "lbl_ncheque";
            this.lbl_ncheque.Size = new System.Drawing.Size(71, 13);
            this.lbl_ncheque.TabIndex = 22;
            this.lbl_ncheque.Text = "N°. Cheque:";
            // 
            // txt_montoc
            // 
            this.txt_montoc.BackColor = System.Drawing.Color.White;
            this.txt_montoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_montoc.Location = new System.Drawing.Point(90, 70);
            this.txt_montoc.Name = "txt_montoc";
            this.txt_montoc.ShortcutsEnabled = false;
            this.txt_montoc.Size = new System.Drawing.Size(121, 21);
            this.txt_montoc.TabIndex = 29;
            this.txt_montoc.Text = "0";
            this.txt_montoc.Click += new System.EventHandler(this.txt_monto_click);
            this.txt_montoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CajasoloDecimales_KeyPress);
            this.txt_montoc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_calcularTotalesAPagar);
            // 
            // lbl_montoc
            // 
            this.lbl_montoc.AutoSize = true;
            this.lbl_montoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_montoc.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl_montoc.Location = new System.Drawing.Point(37, 70);
            this.lbl_montoc.Name = "lbl_montoc";
            this.lbl_montoc.Size = new System.Drawing.Size(46, 13);
            this.lbl_montoc.TabIndex = 28;
            this.lbl_montoc.Text = "Monto:";
            // 
            // txt_numeroc
            // 
            this.txt_numeroc.BackColor = System.Drawing.Color.White;
            this.txt_numeroc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_numeroc.Location = new System.Drawing.Point(90, 18);
            this.txt_numeroc.MaxLength = 5;
            this.txt_numeroc.Name = "txt_numeroc";
            this.txt_numeroc.Size = new System.Drawing.Size(243, 21);
            this.txt_numeroc.TabIndex = 21;
            // 
            // txt_banco
            // 
            this.txt_banco.BackColor = System.Drawing.Color.White;
            this.txt_banco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_banco.Location = new System.Drawing.Point(90, 44);
            this.txt_banco.MaxLength = 300;
            this.txt_banco.Name = "txt_banco";
            this.txt_banco.Size = new System.Drawing.Size(243, 21);
            this.txt_banco.TabIndex = 24;
            // 
            // lbl_banco
            // 
            this.lbl_banco.AutoSize = true;
            this.lbl_banco.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_banco.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl_banco.Location = new System.Drawing.Point(39, 43);
            this.lbl_banco.Name = "lbl_banco";
            this.lbl_banco.Size = new System.Drawing.Size(44, 13);
            this.lbl_banco.TabIndex = 23;
            this.lbl_banco.Text = "Banco:";
            // 
            // tab_retencion
            // 
            this.tab_retencion.BackColor = System.Drawing.Color.White;
            this.tab_retencion.Controls.Add(this.label26);
            this.tab_retencion.Controls.Add(this.txt_retencion);
            this.tab_retencion.Controls.Add(this.txt_numeroRetencion);
            this.tab_retencion.Controls.Add(this.label25);
            this.tab_retencion.Location = new System.Drawing.Point(4, 22);
            this.tab_retencion.Name = "tab_retencion";
            this.tab_retencion.Padding = new System.Windows.Forms.Padding(3);
            this.tab_retencion.Size = new System.Drawing.Size(444, 171);
            this.tab_retencion.TabIndex = 2;
            this.tab_retencion.Text = "Retención";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label26.Location = new System.Drawing.Point(12, 20);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(79, 13);
            this.label26.TabIndex = 54;
            this.label26.Text = "# Retención:";
            // 
            // txt_retencion
            // 
            this.txt_retencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_retencion.Location = new System.Drawing.Point(95, 45);
            this.txt_retencion.Name = "txt_retencion";
            this.txt_retencion.ShortcutsEnabled = false;
            this.txt_retencion.Size = new System.Drawing.Size(121, 21);
            this.txt_retencion.TabIndex = 39;
            this.txt_retencion.Click += new System.EventHandler(this.txt_monto_click);
            this.txt_retencion.TextChanged += new System.EventHandler(this.txt_retencion_TextChanged);
            this.txt_retencion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CajasoloDecimales_KeyPress);
            this.txt_retencion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_calcularTotalesAPagar);
            // 
            // txt_numeroRetencion
            // 
            this.txt_numeroRetencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_numeroRetencion.Location = new System.Drawing.Point(95, 18);
            this.txt_numeroRetencion.MaxLength = 5;
            this.txt_numeroRetencion.Name = "txt_numeroRetencion";
            this.txt_numeroRetencion.Size = new System.Drawing.Size(221, 21);
            this.txt_numeroRetencion.TabIndex = 53;
            this.txt_numeroRetencion.TextChanged += new System.EventHandler(this.txt_numeroRetencion_TextChanged);
            this.txt_numeroRetencion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CajasoloNumeros_KeyPress);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label25.Location = new System.Drawing.Point(45, 48);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(46, 13);
            this.label25.TabIndex = 36;
            this.label25.Text = "Monto:";
            // 
            // tab_notaCredito
            // 
            this.tab_notaCredito.BackColor = System.Drawing.Color.White;
            this.tab_notaCredito.Controls.Add(this.label29);
            this.tab_notaCredito.Controls.Add(this.txt_montoNota);
            this.tab_notaCredito.Controls.Add(this.txt_numeroNota);
            this.tab_notaCredito.Controls.Add(this.label30);
            this.tab_notaCredito.Location = new System.Drawing.Point(4, 22);
            this.tab_notaCredito.Name = "tab_notaCredito";
            this.tab_notaCredito.Padding = new System.Windows.Forms.Padding(3);
            this.tab_notaCredito.Size = new System.Drawing.Size(444, 171);
            this.tab_notaCredito.TabIndex = 3;
            this.tab_notaCredito.Text = "Nota de Crédito";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label29.Location = new System.Drawing.Point(41, 20);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(48, 13);
            this.label29.TabIndex = 58;
            this.label29.Text = "# Nota:";
            // 
            // txt_montoNota
            // 
            this.txt_montoNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_montoNota.Location = new System.Drawing.Point(95, 44);
            this.txt_montoNota.Name = "txt_montoNota";
            this.txt_montoNota.ShortcutsEnabled = false;
            this.txt_montoNota.Size = new System.Drawing.Size(121, 21);
            this.txt_montoNota.TabIndex = 56;
            this.txt_montoNota.Click += new System.EventHandler(this.txt_monto_click);
            this.txt_montoNota.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CajasoloDecimales_KeyPress);
            this.txt_montoNota.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_calcularTotalesAPagar);
            // 
            // txt_numeroNota
            // 
            this.txt_numeroNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_numeroNota.Location = new System.Drawing.Point(95, 16);
            this.txt_numeroNota.MaxLength = 11;
            this.txt_numeroNota.Name = "txt_numeroNota";
            this.txt_numeroNota.Size = new System.Drawing.Size(221, 21);
            this.txt_numeroNota.TabIndex = 57;
            this.txt_numeroNota.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CajasoloNumeros_KeyPress);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label30.Location = new System.Drawing.Point(42, 47);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(46, 13);
            this.label30.TabIndex = 55;
            this.label30.Text = "Monto:";
            // 
            // grp_total
            // 
            this.grp_total.Controls.Add(this.pan_vuelto);
            this.grp_total.Controls.Add(this.pan_totales);
            this.grp_total.Controls.Add(this.chk_todoEfectivo);
            this.grp_total.Controls.Add(this.chk_servicio);
            this.grp_total.Controls.Add(this.cmb_vendedor);
            this.grp_total.Controls.Add(this.lbl_vendedor);
            this.grp_total.Controls.Add(this.txt_servicio);
            this.grp_total.Controls.Add(this.lbl_servicio);
            this.grp_total.Controls.Add(this.label17);
            this.grp_total.Controls.Add(this.txt_iva12);
            this.grp_total.Controls.Add(this.txt_iva0);
            this.grp_total.Controls.Add(this.label16);
            this.grp_total.Controls.Add(this.label10);
            this.grp_total.Controls.Add(this.txt_iva);
            this.grp_total.Controls.Add(this.label13);
            this.grp_total.Controls.Add(this.txt_descuento);
            this.grp_total.Dock = System.Windows.Forms.DockStyle.Right;
            this.grp_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.grp_total.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.grp_total.Location = new System.Drawing.Point(452, 0);
            this.grp_total.Name = "grp_total";
            this.grp_total.Size = new System.Drawing.Size(489, 197);
            this.grp_total.TabIndex = 0;
            this.grp_total.TabStop = false;
            this.grp_total.Text = "Total";
            this.grp_total.Enter += new System.EventHandler(this.grp_total_Enter);
            // 
            // pan_vuelto
            // 
            this.pan_vuelto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(208)))), ((int)(((byte)(80)))));
            this.pan_vuelto.Controls.Add(this.txt_vuelto);
            this.pan_vuelto.Controls.Add(this.label36);
            this.pan_vuelto.ForeColor = System.Drawing.Color.White;
            this.pan_vuelto.Location = new System.Drawing.Point(183, 130);
            this.pan_vuelto.Name = "pan_vuelto";
            this.pan_vuelto.Size = new System.Drawing.Size(295, 34);
            this.pan_vuelto.TabIndex = 115;
            // 
            // txt_vuelto
            // 
            this.txt_vuelto.AutoSize = true;
            this.txt_vuelto.BackColor = System.Drawing.Color.Transparent;
            this.txt_vuelto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_vuelto.ForeColor = System.Drawing.Color.White;
            this.txt_vuelto.Location = new System.Drawing.Point(155, 8);
            this.txt_vuelto.Name = "txt_vuelto";
            this.txt_vuelto.Size = new System.Drawing.Size(44, 20);
            this.txt_vuelto.TabIndex = 6;
            this.txt_vuelto.Text = "0.00";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.Transparent;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.Color.White;
            this.label36.Location = new System.Drawing.Point(83, 10);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(67, 18);
            this.label36.TabIndex = 5;
            this.label36.Text = "VUELTO";
            // 
            // pan_totales
            // 
            this.pan_totales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.pan_totales.Controls.Add(this.txt_saldo);
            this.pan_totales.Controls.Add(this.label33);
            this.pan_totales.Controls.Add(this.txt_totalpago);
            this.pan_totales.Controls.Add(this.label31);
            this.pan_totales.Controls.Add(this.txt_total);
            this.pan_totales.ForeColor = System.Drawing.Color.White;
            this.pan_totales.Location = new System.Drawing.Point(183, 20);
            this.pan_totales.Name = "pan_totales";
            this.pan_totales.Size = new System.Drawing.Size(295, 105);
            this.pan_totales.TabIndex = 114;
            this.pan_totales.Paint += new System.Windows.Forms.PaintEventHandler(this.pan_totales_Paint);
            // 
            // txt_saldo
            // 
            this.txt_saldo.AutoSize = true;
            this.txt_saldo.BackColor = System.Drawing.Color.Transparent;
            this.txt_saldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_saldo.ForeColor = System.Drawing.Color.White;
            this.txt_saldo.Location = new System.Drawing.Point(215, 77);
            this.txt_saldo.Name = "txt_saldo";
            this.txt_saldo.Size = new System.Drawing.Size(49, 24);
            this.txt_saldo.TabIndex = 4;
            this.txt_saldo.Text = "0.00";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.White;
            this.label33.Location = new System.Drawing.Point(162, 82);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(53, 16);
            this.label33.TabIndex = 3;
            this.label33.Text = "SALDO";
            // 
            // txt_totalpago
            // 
            this.txt_totalpago.AutoSize = true;
            this.txt_totalpago.BackColor = System.Drawing.Color.Transparent;
            this.txt_totalpago.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_totalpago.ForeColor = System.Drawing.Color.White;
            this.txt_totalpago.Location = new System.Drawing.Point(69, 77);
            this.txt_totalpago.Name = "txt_totalpago";
            this.txt_totalpago.Size = new System.Drawing.Size(49, 24);
            this.txt_totalpago.TabIndex = 2;
            this.txt_totalpago.Text = "0.00";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.White;
            this.label31.Location = new System.Drawing.Point(4, 82);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(65, 16);
            this.label31.TabIndex = 1;
            this.label31.Text = "PAGADO";
            // 
            // txt_total
            // 
            this.txt_total.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_total.AutoSize = true;
            this.txt_total.BackColor = System.Drawing.Color.Transparent;
            this.txt_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 44.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_total.ForeColor = System.Drawing.Color.White;
            this.txt_total.Location = new System.Drawing.Point(77, 7);
            this.txt_total.Name = "txt_total";
            this.txt_total.Size = new System.Drawing.Size(148, 67);
            this.txt_total.TabIndex = 0;
            this.txt_total.Text = "0.00";
            this.txt_total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txt_total.Click += new System.EventHandler(this.txt_total_Click);
            // 
            // chk_todoEfectivo
            // 
            this.chk_todoEfectivo.AutoSize = true;
            this.chk_todoEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.chk_todoEfectivo.ForeColor = System.Drawing.SystemColors.GrayText;
            this.chk_todoEfectivo.Location = new System.Drawing.Point(11, 229);
            this.chk_todoEfectivo.Name = "chk_todoEfectivo";
            this.chk_todoEfectivo.Size = new System.Drawing.Size(132, 19);
            this.chk_todoEfectivo.TabIndex = 17;
            this.chk_todoEfectivo.Text = "Todo en Efectivo";
            this.chk_todoEfectivo.UseVisualStyleBackColor = true;
            this.chk_todoEfectivo.CheckedChanged += new System.EventHandler(this.chk_todoEfectivo_CheckedChanged);
            // 
            // chk_servicio
            // 
            this.chk_servicio.AutoSize = true;
            this.chk_servicio.Location = new System.Drawing.Point(32, 129);
            this.chk_servicio.Name = "chk_servicio";
            this.chk_servicio.Size = new System.Drawing.Size(15, 14);
            this.chk_servicio.TabIndex = 113;
            this.chk_servicio.UseVisualStyleBackColor = true;
            this.chk_servicio.Visible = false;
            this.chk_servicio.CheckedChanged += new System.EventHandler(this.chk_servicio_CheckedChanged);
            // 
            // cmb_vendedor
            // 
            this.cmb_vendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_vendedor.FormattingEnabled = true;
            this.cmb_vendedor.Location = new System.Drawing.Point(86, 248);
            this.cmb_vendedor.Name = "cmb_vendedor";
            this.cmb_vendedor.Size = new System.Drawing.Size(92, 23);
            this.cmb_vendedor.TabIndex = 112;
            // 
            // lbl_vendedor
            // 
            this.lbl_vendedor.AutoSize = true;
            this.lbl_vendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_vendedor.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl_vendedor.Location = new System.Drawing.Point(8, 251);
            this.lbl_vendedor.Name = "lbl_vendedor";
            this.lbl_vendedor.Size = new System.Drawing.Size(72, 15);
            this.lbl_vendedor.TabIndex = 111;
            this.lbl_vendedor.Text = "Vendedor:";
            // 
            // txt_servicio
            // 
            this.txt_servicio.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txt_servicio.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_servicio.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold);
            this.txt_servicio.Location = new System.Drawing.Point(110, 125);
            this.txt_servicio.Name = "txt_servicio";
            this.txt_servicio.ReadOnly = true;
            this.txt_servicio.Size = new System.Drawing.Size(55, 22);
            this.txt_servicio.TabIndex = 0;
            this.txt_servicio.Text = "0.00";
            // 
            // lbl_servicio
            // 
            this.lbl_servicio.AutoSize = true;
            this.lbl_servicio.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_servicio.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl_servicio.Location = new System.Drawing.Point(48, 128);
            this.lbl_servicio.Name = "lbl_servicio";
            this.lbl_servicio.Size = new System.Drawing.Size(52, 14);
            this.lbl_servicio.TabIndex = 61;
            this.lbl_servicio.Text = "Servicio";
            this.lbl_servicio.Click += new System.EventHandler(this.lbl_servicio_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label17.Location = new System.Drawing.Point(19, 22);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(81, 14);
            this.label17.TabIndex = 59;
            this.label17.Text = "Subtotal 12%";
            // 
            // txt_iva12
            // 
            this.txt_iva12.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txt_iva12.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_iva12.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold);
            this.txt_iva12.Location = new System.Drawing.Point(110, 19);
            this.txt_iva12.Name = "txt_iva12";
            this.txt_iva12.ReadOnly = true;
            this.txt_iva12.Size = new System.Drawing.Size(55, 22);
            this.txt_iva12.TabIndex = 0;
            this.txt_iva12.Text = "0.00";
            // 
            // txt_iva0
            // 
            this.txt_iva0.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txt_iva0.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_iva0.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold);
            this.txt_iva0.Location = new System.Drawing.Point(110, 45);
            this.txt_iva0.Name = "txt_iva0";
            this.txt_iva0.ReadOnly = true;
            this.txt_iva0.Size = new System.Drawing.Size(55, 22);
            this.txt_iva0.TabIndex = 0;
            this.txt_iva0.Text = "0.00";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label16.Location = new System.Drawing.Point(26, 47);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 14);
            this.label16.TabIndex = 57;
            this.label16.Text = "Subtotal 0%";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label10.Location = new System.Drawing.Point(36, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 14);
            this.label10.TabIndex = 47;
            this.label10.Text = "Descuento";
            // 
            // txt_iva
            // 
            this.txt_iva.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txt_iva.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_iva.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold);
            this.txt_iva.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txt_iva.Location = new System.Drawing.Point(110, 97);
            this.txt_iva.Name = "txt_iva";
            this.txt_iva.ReadOnly = true;
            this.txt_iva.Size = new System.Drawing.Size(55, 22);
            this.txt_iva.TabIndex = 0;
            this.txt_iva.Text = "0.00";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label13.Location = new System.Drawing.Point(74, 100);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 14);
            this.label13.TabIndex = 49;
            this.label13.Text = "IVA";
            // 
            // txt_descuento
            // 
            this.txt_descuento.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txt_descuento.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_descuento.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold);
            this.txt_descuento.ForeColor = System.Drawing.Color.Black;
            this.txt_descuento.Location = new System.Drawing.Point(110, 71);
            this.txt_descuento.Name = "txt_descuento";
            this.txt_descuento.ReadOnly = true;
            this.txt_descuento.Size = new System.Drawing.Size(55, 22);
            this.txt_descuento.TabIndex = 0;
            this.txt_descuento.Text = "0.00";
            // 
            // grb_extras
            // 
            this.grb_extras.Controls.Add(this.btn_buscarCliente);
            this.grb_extras.Controls.Add(this.label8);
            this.grb_extras.Controls.Add(this.txt_Nombres);
            this.grb_extras.Controls.Add(this.label5);
            this.grb_extras.Controls.Add(this.txt_ruc);
            this.grb_extras.Controls.Add(this.btn_crearCliente);
            this.grb_extras.Dock = System.Windows.Forms.DockStyle.Top;
            this.grb_extras.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grb_extras.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.grb_extras.Location = new System.Drawing.Point(3, 106);
            this.grb_extras.Name = "grb_extras";
            this.grb_extras.Size = new System.Drawing.Size(941, 48);
            this.grb_extras.TabIndex = 4;
            this.grb_extras.TabStop = false;
            this.grb_extras.Text = "Información Cliente";
            // 
            // btn_buscarCliente
            // 
            this.btn_buscarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.btn_buscarCliente.BackgroundImage = global::Pos.Properties.Resources.buscar_lupa;
            this.btn_buscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_buscarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buscarCliente.Location = new System.Drawing.Point(269, 15);
            this.btn_buscarCliente.Name = "btn_buscarCliente";
            this.btn_buscarCliente.Size = new System.Drawing.Size(22, 23);
            this.btn_buscarCliente.TabIndex = 10;
            this.btn_buscarCliente.Tag = "Buscar";
            this.btn_buscarCliente.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_buscarCliente.UseVisualStyleBackColor = false;
            this.btn_buscarCliente.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label8.Location = new System.Drawing.Point(351, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 15);
            this.label8.TabIndex = 107;
            this.label8.Text = "Nombre:";
            // 
            // txt_Nombres
            // 
            this.txt_Nombres.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Nombres.BackColor = System.Drawing.Color.White;
            this.txt_Nombres.Enabled = false;
            this.txt_Nombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Nombres.Location = new System.Drawing.Point(419, 16);
            this.txt_Nombres.MaxLength = 100;
            this.txt_Nombres.Name = "txt_Nombres";
            this.txt_Nombres.Size = new System.Drawing.Size(446, 21);
            this.txt_Nombres.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label5.Location = new System.Drawing.Point(15, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Cédula / Ruc:";
            // 
            // txt_ruc
            // 
            this.txt_ruc.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_ruc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ruc.Location = new System.Drawing.Point(110, 15);
            this.txt_ruc.MaxLength = 13;
            this.txt_ruc.Name = "txt_ruc";
            this.txt_ruc.Size = new System.Drawing.Size(153, 21);
            this.txt_ruc.TabIndex = 0;
            this.txt_ruc.TextChanged += new System.EventHandler(this.txt_ruc_TextChanged);
            this.txt_ruc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ruc_KeyPress);
            this.txt_ruc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_ruc_KeyUp);
            // 
            // btn_crearCliente
            // 
            this.btn_crearCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.btn_crearCliente.BackgroundImage = global::Pos.Properties.Resources.crear1;
            this.btn_crearCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_crearCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_crearCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_crearCliente.Location = new System.Drawing.Point(297, 16);
            this.btn_crearCliente.Name = "btn_crearCliente";
            this.btn_crearCliente.Size = new System.Drawing.Size(22, 23);
            this.btn_crearCliente.TabIndex = 11;
            this.btn_crearCliente.Tag = "Crear";
            this.btn_crearCliente.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_crearCliente.UseVisualStyleBackColor = false;
            this.btn_crearCliente.Click += new System.EventHandler(this.btn_crearCliente_Click);
            // 
            // flp_datosFactura
            // 
            this.flp_datosFactura.AutoSize = true;
            this.flp_datosFactura.Controls.Add(this.flp_personas);
            this.flp_datosFactura.Controls.Add(this.flowLayoutPanel2);
            this.flp_datosFactura.Controls.Add(this.flowLayoutPanel3);
            this.flp_datosFactura.Controls.Add(this.flp_tipoDocumento);
            this.flp_datosFactura.Controls.Add(this.flp_autorizacion);
            this.flp_datosFactura.Controls.Add(this.flowLayoutPanel6);
            this.flp_datosFactura.Controls.Add(this.flowLayoutPanel7);
            this.flp_datosFactura.Controls.Add(this.flp_fechaVencimiento);
            this.flp_datosFactura.Controls.Add(this.flp_descripcion);
            this.flp_datosFactura.Dock = System.Windows.Forms.DockStyle.Top;
            this.flp_datosFactura.Location = new System.Drawing.Point(3, 16);
            this.flp_datosFactura.Name = "flp_datosFactura";
            this.flp_datosFactura.Size = new System.Drawing.Size(941, 90);
            this.flp_datosFactura.TabIndex = 0;
            // 
            // flp_personas
            // 
            this.flp_personas.BackColor = System.Drawing.Color.Transparent;
            this.flp_personas.Controls.Add(this.btn_buscar);
            this.flp_personas.Controls.Add(this.txt_secuencia);
            this.flp_personas.Controls.Add(this.label6);
            this.flp_personas.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flp_personas.Location = new System.Drawing.Point(0, 0);
            this.flp_personas.Margin = new System.Windows.Forms.Padding(0);
            this.flp_personas.Name = "flp_personas";
            this.flp_personas.Padding = new System.Windows.Forms.Padding(2);
            this.flp_personas.Size = new System.Drawing.Size(286, 30);
            this.flp_personas.TabIndex = 131;
            // 
            // btn_buscar
            // 
            this.btn_buscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.btn_buscar.BackgroundImage = global::Pos.Properties.Resources.buscar_lupa;
            this.btn_buscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buscar.Location = new System.Drawing.Point(257, 5);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(22, 23);
            this.btn_buscar.TabIndex = 9;
            this.btn_buscar.Tag = "Buscar";
            this.btn_buscar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_buscar.UseVisualStyleBackColor = false;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // txt_secuencia
            // 
            this.txt_secuencia.BackColor = System.Drawing.Color.White;
            this.txt_secuencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.txt_secuencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txt_secuencia.Location = new System.Drawing.Point(99, 5);
            this.txt_secuencia.Name = "txt_secuencia";
            this.txt_secuencia.Size = new System.Drawing.Size(152, 21);
            this.txt_secuencia.TabIndex = 0;
            this.txt_secuencia.TextChanged += new System.EventHandler(this.txt_secuencia_TextChanged);
            this.txt_secuencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_secuencia_KeyPress);
            this.txt_secuencia.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_secuencia_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label6.Location = new System.Drawing.Point(15, 2);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label6.Size = new System.Drawing.Size(78, 18);
            this.label6.TabIndex = 19;
            this.label6.Text = "Secuencia:";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel2.Controls.Add(this.txt_numDoc);
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(286, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(286, 30);
            this.flowLayoutPanel2.TabIndex = 132;
            // 
            // txt_numDoc
            // 
            this.txt_numDoc.BackColor = System.Drawing.Color.White;
            this.txt_numDoc.Enabled = false;
            this.txt_numDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.txt_numDoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_numDoc.Location = new System.Drawing.Point(99, 5);
            this.txt_numDoc.MaxLength = 17;
            this.txt_numDoc.Name = "txt_numDoc";
            this.txt_numDoc.Size = new System.Drawing.Size(180, 21);
            this.txt_numDoc.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label3.Location = new System.Drawing.Point(9, 2);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label3.Size = new System.Drawing.Size(84, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Documento:";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel3.Controls.Add(this.label1);
            this.flowLayoutPanel3.Controls.Add(this.txt_fecha);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(572, 0);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Padding = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel3.Size = new System.Drawing.Size(286, 30);
            this.flowLayoutPanel3.TabIndex = 133;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(5, 2);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(40, 3, 0, 0);
            this.label1.Size = new System.Drawing.Size(90, 18);
            this.label1.TabIndex = 114;
            this.label1.Text = "Fecha:";
            // 
            // txt_fecha
            // 
            this.txt_fecha.AutoSize = true;
            this.txt_fecha.BackColor = System.Drawing.Color.Transparent;
            this.txt_fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_fecha.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_fecha.Location = new System.Drawing.Point(101, 2);
            this.txt_fecha.Name = "txt_fecha";
            this.txt_fecha.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.txt_fecha.Size = new System.Drawing.Size(111, 18);
            this.txt_fecha.TabIndex = 113;
            this.txt_fecha.Text = "27/10/2012 9:00";
            // 
            // flp_tipoDocumento
            // 
            this.flp_tipoDocumento.BackColor = System.Drawing.Color.Transparent;
            this.flp_tipoDocumento.Controls.Add(this.chk_dna);
            this.flp_tipoDocumento.Controls.Add(this.txt_tipo);
            this.flp_tipoDocumento.Controls.Add(this.label2);
            this.flp_tipoDocumento.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flp_tipoDocumento.Location = new System.Drawing.Point(0, 30);
            this.flp_tipoDocumento.Margin = new System.Windows.Forms.Padding(0);
            this.flp_tipoDocumento.Name = "flp_tipoDocumento";
            this.flp_tipoDocumento.Padding = new System.Windows.Forms.Padding(2);
            this.flp_tipoDocumento.Size = new System.Drawing.Size(286, 30);
            this.flp_tipoDocumento.TabIndex = 134;
            // 
            // chk_dna
            // 
            this.chk_dna.AutoSize = true;
            this.chk_dna.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_dna.ForeColor = System.Drawing.Color.Gray;
            this.chk_dna.Location = new System.Drawing.Point(225, 5);
            this.chk_dna.Name = "chk_dna";
            this.chk_dna.Size = new System.Drawing.Size(54, 19);
            this.chk_dna.TabIndex = 4;
            this.chk_dna.Text = "DNA";
            this.chk_dna.UseVisualStyleBackColor = true;
            this.chk_dna.CheckedChanged += new System.EventHandler(this.chk_dna_CheckedChanged);
            // 
            // txt_tipo
            // 
            this.txt_tipo.BackColor = System.Drawing.Color.White;
            this.txt_tipo.Enabled = false;
            this.txt_tipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.txt_tipo.Location = new System.Drawing.Point(98, 5);
            this.txt_tipo.Name = "txt_tipo";
            this.txt_tipo.Size = new System.Drawing.Size(121, 21);
            this.txt_tipo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(53, 2);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label2.Size = new System.Drawing.Size(39, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo:";
            // 
            // flp_autorizacion
            // 
            this.flp_autorizacion.BackColor = System.Drawing.Color.Transparent;
            this.flp_autorizacion.Controls.Add(this.txt_numAut);
            this.flp_autorizacion.Controls.Add(this.label4);
            this.flp_autorizacion.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flp_autorizacion.Location = new System.Drawing.Point(286, 30);
            this.flp_autorizacion.Margin = new System.Windows.Forms.Padding(0);
            this.flp_autorizacion.Name = "flp_autorizacion";
            this.flp_autorizacion.Padding = new System.Windows.Forms.Padding(2);
            this.flp_autorizacion.Size = new System.Drawing.Size(286, 30);
            this.flp_autorizacion.TabIndex = 135;
            // 
            // txt_numAut
            // 
            this.txt_numAut.BackColor = System.Drawing.Color.White;
            this.txt_numAut.Enabled = false;
            this.txt_numAut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.txt_numAut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txt_numAut.Location = new System.Drawing.Point(99, 5);
            this.txt_numAut.Name = "txt_numAut";
            this.txt_numAut.Size = new System.Drawing.Size(180, 21);
            this.txt_numAut.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label4.Location = new System.Drawing.Point(3, 2);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label4.Size = new System.Drawing.Size(90, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "Autorización:";
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel6.Controls.Add(this.cmb_estado);
            this.flowLayoutPanel6.Controls.Add(this.label18);
            this.flowLayoutPanel6.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel6.Location = new System.Drawing.Point(572, 30);
            this.flowLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Padding = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel6.Size = new System.Drawing.Size(286, 30);
            this.flowLayoutPanel6.TabIndex = 136;
            // 
            // cmb_estado
            // 
            this.cmb_estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_estado.FormattingEnabled = true;
            this.cmb_estado.Location = new System.Drawing.Point(100, 5);
            this.cmb_estado.Name = "cmb_estado";
            this.cmb_estado.Size = new System.Drawing.Size(179, 21);
            this.cmb_estado.TabIndex = 6;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label18.Location = new System.Drawing.Point(39, 2);
            this.label18.Name = "label18";
            this.label18.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label18.Size = new System.Drawing.Size(55, 18);
            this.label18.TabIndex = 27;
            this.label18.Text = "Estado:";
            // 
            // flowLayoutPanel7
            // 
            this.flowLayoutPanel7.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel7.Controls.Add(this.chk_descProd);
            this.flowLayoutPanel7.Controls.Add(this.txt_descProducto);
            this.flowLayoutPanel7.Controls.Add(this.label7);
            this.flowLayoutPanel7.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel7.Location = new System.Drawing.Point(0, 60);
            this.flowLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            this.flowLayoutPanel7.Padding = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel7.Size = new System.Drawing.Size(286, 30);
            this.flowLayoutPanel7.TabIndex = 137;
            // 
            // chk_descProd
            // 
            this.chk_descProd.AutoSize = true;
            this.chk_descProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_descProd.ForeColor = System.Drawing.Color.Gray;
            this.chk_descProd.Location = new System.Drawing.Point(264, 5);
            this.chk_descProd.Name = "chk_descProd";
            this.chk_descProd.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.chk_descProd.Size = new System.Drawing.Size(15, 17);
            this.chk_descProd.TabIndex = 6;
            this.chk_descProd.UseVisualStyleBackColor = true;
            this.chk_descProd.CheckedChanged += new System.EventHandler(this.chk_descProd_CheckedChanged);
            // 
            // txt_descProducto
            // 
            this.txt_descProducto.BackColor = System.Drawing.Color.White;
            this.txt_descProducto.Enabled = false;
            this.txt_descProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.txt_descProducto.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_descProducto.Location = new System.Drawing.Point(99, 5);
            this.txt_descProducto.MaxLength = 4;
            this.txt_descProducto.Name = "txt_descProducto";
            this.txt_descProducto.Size = new System.Drawing.Size(159, 21);
            this.txt_descProducto.TabIndex = 2;
            this.txt_descProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_descProducto_KeyPress);
            this.txt_descProducto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_descProducto_KeyUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label7.Location = new System.Drawing.Point(3, 2);
            this.label7.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label7.Size = new System.Drawing.Size(91, 18);
            this.label7.TabIndex = 110;
            this.label7.Text = "%Descuento:";
            // 
            // flp_fechaVencimiento
            // 
            this.flp_fechaVencimiento.BackColor = System.Drawing.Color.Transparent;
            this.flp_fechaVencimiento.Controls.Add(this.dtp_vencimiento);
            this.flp_fechaVencimiento.Controls.Add(this.label9);
            this.flp_fechaVencimiento.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flp_fechaVencimiento.Location = new System.Drawing.Point(286, 60);
            this.flp_fechaVencimiento.Margin = new System.Windows.Forms.Padding(0);
            this.flp_fechaVencimiento.Name = "flp_fechaVencimiento";
            this.flp_fechaVencimiento.Padding = new System.Windows.Forms.Padding(2);
            this.flp_fechaVencimiento.Size = new System.Drawing.Size(286, 30);
            this.flp_fechaVencimiento.TabIndex = 138;
            // 
            // dtp_vencimiento
            // 
            this.dtp_vencimiento.Location = new System.Drawing.Point(99, 5);
            this.dtp_vencimiento.Name = "dtp_vencimiento";
            this.dtp_vencimiento.Size = new System.Drawing.Size(180, 20);
            this.dtp_vencimiento.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label9.Location = new System.Drawing.Point(3, 2);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label9.Size = new System.Drawing.Size(90, 18);
            this.label9.TabIndex = 5;
            this.label9.Text = "Vencimiento:";
            // 
            // flp_descripcion
            // 
            this.flp_descripcion.BackColor = System.Drawing.Color.Transparent;
            this.flp_descripcion.Controls.Add(this.txt_descipcion);
            this.flp_descripcion.Controls.Add(this.label12);
            this.flp_descripcion.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flp_descripcion.Location = new System.Drawing.Point(572, 60);
            this.flp_descripcion.Margin = new System.Windows.Forms.Padding(0);
            this.flp_descripcion.Name = "flp_descripcion";
            this.flp_descripcion.Padding = new System.Windows.Forms.Padding(2);
            this.flp_descripcion.Size = new System.Drawing.Size(286, 30);
            this.flp_descripcion.TabIndex = 139;
            // 
            // txt_descipcion
            // 
            this.txt_descipcion.BackColor = System.Drawing.Color.White;
            this.txt_descipcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.txt_descipcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txt_descipcion.Location = new System.Drawing.Point(99, 5);
            this.txt_descipcion.Name = "txt_descipcion";
            this.txt_descipcion.Size = new System.Drawing.Size(180, 21);
            this.txt_descipcion.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label12.Location = new System.Drawing.Point(6, 2);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label12.Size = new System.Drawing.Size(87, 18);
            this.label12.TabIndex = 5;
            this.label12.Text = "Descripción:";
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_nuevo,
            this.toolStripSeparator3,
            this.tsb_guardar,
            this.toolStripSeparator1,
            this.tsb_imprimir,
            this.toolStripSeparator2,
            this.tsb_anular,
            this.toolStripSeparator4,
            this.tsb_duplicar,
            this.toolStripSeparator5,
            this.toolStripDropDownButton1,
            this.tls_guia,
            this.tsb_guia,
            this.tsb_reversar});
            this.menu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(947, 28);
            this.menu.TabIndex = 38;
            this.menu.TabStop = true;
            this.menu.Text = "Opciones";
            this.menu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menu_ItemClicked);
            // 
            // tsb_nuevo
            // 
            this.tsb_nuevo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsb_nuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsb_nuevo.Image")));
            this.tsb_nuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_nuevo.Name = "tsb_nuevo";
            this.tsb_nuevo.Padding = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.tsb_nuevo.Size = new System.Drawing.Size(136, 25);
            this.tsb_nuevo.Text = "Nuevo";
            this.tsb_nuevo.ToolTipText = "Nuevo (F5)";
            this.tsb_nuevo.Click += new System.EventHandler(this.tsb_nuevo_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // tsb_guardar
            // 
            this.tsb_guardar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsb_guardar.Image = ((System.Drawing.Image)(resources.GetObject("tsb_guardar.Image")));
            this.tsb_guardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_guardar.Name = "tsb_guardar";
            this.tsb_guardar.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.tsb_guardar.Size = new System.Drawing.Size(117, 25);
            this.tsb_guardar.Text = "Guardar";
            this.tsb_guardar.ToolTipText = "Guardar (F6)";
            this.tsb_guardar.Click += new System.EventHandler(this.tsb_guardar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // tsb_imprimir
            // 
            this.tsb_imprimir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsb_imprimir.Image = ((System.Drawing.Image)(resources.GetObject("tsb_imprimir.Image")));
            this.tsb_imprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_imprimir.Name = "tsb_imprimir";
            this.tsb_imprimir.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.tsb_imprimir.Size = new System.Drawing.Size(194, 25);
            this.tsb_imprimir.Text = "Guardar e Imprimir";
            this.tsb_imprimir.ToolTipText = "Guardar e Imprimir (F7)";
            this.tsb_imprimir.Click += new System.EventHandler(this.tsb_imprimir_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // tsb_anular
            // 
            this.tsb_anular.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsb_anular.Image = ((System.Drawing.Image)(resources.GetObject("tsb_anular.Image")));
            this.tsb_anular.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_anular.Name = "tsb_anular";
            this.tsb_anular.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.tsb_anular.Size = new System.Drawing.Size(106, 25);
            this.tsb_anular.Text = "Anular";
            this.tsb_anular.ToolTipText = "Anular (F8)";
            this.tsb_anular.Click += new System.EventHandler(this.tsb_anular_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // tsb_duplicar
            // 
            this.tsb_duplicar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsb_duplicar.Image = ((System.Drawing.Image)(resources.GetObject("tsb_duplicar.Image")));
            this.tsb_duplicar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_duplicar.Name = "tsb_duplicar";
            this.tsb_duplicar.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.tsb_duplicar.Size = new System.Drawing.Size(118, 25);
            this.tsb_duplicar.Text = "Duplicar";
            this.tsb_duplicar.Click += new System.EventHandler(this.tsb_duplicar_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 23);
            this.toolStripSeparator5.Visible = false;
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_preCuenta,
            this.tsb_imprimirFactura});
            this.toolStripDropDownButton1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripDropDownButton1.Image = global::Pos.Properties.Resources.printer;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(130, 25);
            this.toolStripDropDownButton1.Text = "Imprimir";
            this.toolStripDropDownButton1.Visible = false;
            // 
            // tsb_preCuenta
            // 
            this.tsb_preCuenta.Image = global::Pos.Properties.Resources.preFactura;
            this.tsb_preCuenta.Name = "tsb_preCuenta";
            this.tsb_preCuenta.Size = new System.Drawing.Size(158, 26);
            this.tsb_preCuenta.Text = "Pre-Cuenta";
            this.tsb_preCuenta.Click += new System.EventHandler(this.tsb_preCuenta_Click);
            // 
            // tsb_imprimirFactura
            // 
            this.tsb_imprimirFactura.Image = global::Pos.Properties.Resources.factura;
            this.tsb_imprimirFactura.Name = "tsb_imprimirFactura";
            this.tsb_imprimirFactura.Size = new System.Drawing.Size(158, 26);
            this.tsb_imprimirFactura.Text = "Factura";
            this.tsb_imprimirFactura.Click += new System.EventHandler(this.tsb_imprimirFactura_Click);
            // 
            // tls_guia
            // 
            this.tls_guia.Name = "tls_guia";
            this.tls_guia.Size = new System.Drawing.Size(6, 23);
            this.tls_guia.Visible = false;
            // 
            // tsb_guia
            // 
            this.tsb_guia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsb_guia.Image = global::Pos.Properties.Resources.guia_remision;
            this.tsb_guia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_guia.Name = "tsb_guia";
            this.tsb_guia.Size = new System.Drawing.Size(152, 25);
            this.tsb_guia.Text = "Guía de Remisión";
            this.tsb_guia.Visible = false;
            this.tsb_guia.Click += new System.EventHandler(this.tsb_guia_Click);
            // 
            // tsb_reversar
            // 
            this.tsb_reversar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsb_reversar.Image = global::Pos.Properties.Resources.edit_clear;
            this.tsb_reversar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_reversar.Name = "tsb_reversar";
            this.tsb_reversar.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.tsb_reversar.Size = new System.Drawing.Size(121, 25);
            this.tsb_reversar.Text = "Reversar";
            this.tsb_reversar.Visible = false;
            this.tsb_reversar.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // cms_clickDerecho
            // 
            this.cms_clickDerecho.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmi_pendientes,
            this.tmi_nuevo,
            this.verToolStripMenuItem});
            this.cms_clickDerecho.Name = "cms_clickDerecho";
            this.cms_clickDerecho.Size = new System.Drawing.Size(177, 70);
            // 
            // tmi_pendientes
            // 
            this.tmi_pendientes.Name = "tmi_pendientes";
            this.tmi_pendientes.Size = new System.Drawing.Size(176, 22);
            this.tmi_pendientes.Text = "Mostrar Pendientes";
            this.tmi_pendientes.Click += new System.EventHandler(this.tmi_pendientes_Click);
            // 
            // tmi_nuevo
            // 
            this.tmi_nuevo.Name = "tmi_nuevo";
            this.tmi_nuevo.Size = new System.Drawing.Size(176, 22);
            this.tmi_nuevo.Text = "Nuevo";
            this.tmi_nuevo.Click += new System.EventHandler(this.tmi_nuevo_Click);
            // 
            // verToolStripMenuItem
            // 
            this.verToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmi_tipoDocumento,
            this.tmi_autorizacion,
            this.tmi_fechaVencimiento,
            this.tmi_descripcion,
            this.tmi_descripcionProducto});
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.verToolStripMenuItem.Text = "Ver";
            // 
            // tmi_tipoDocumento
            // 
            this.tmi_tipoDocumento.CheckOnClick = true;
            this.tmi_tipoDocumento.Name = "tmi_tipoDocumento";
            this.tmi_tipoDocumento.Size = new System.Drawing.Size(190, 22);
            this.tmi_tipoDocumento.Text = "Tipo de Documento";
            this.tmi_tipoDocumento.Click += new System.EventHandler(this.tmi_tipoDocumento_Click);
            // 
            // tmi_autorizacion
            // 
            this.tmi_autorizacion.CheckOnClick = true;
            this.tmi_autorizacion.Name = "tmi_autorizacion";
            this.tmi_autorizacion.Size = new System.Drawing.Size(190, 22);
            this.tmi_autorizacion.Text = "Autorización";
            this.tmi_autorizacion.Click += new System.EventHandler(this.tmi_autorizacion_Click);
            // 
            // tmi_fechaVencimiento
            // 
            this.tmi_fechaVencimiento.CheckOnClick = true;
            this.tmi_fechaVencimiento.Name = "tmi_fechaVencimiento";
            this.tmi_fechaVencimiento.Size = new System.Drawing.Size(190, 22);
            this.tmi_fechaVencimiento.Text = "Fecha de Vencimiento";
            this.tmi_fechaVencimiento.Click += new System.EventHandler(this.tmi_fechaVencimiento_Click);
            // 
            // tmi_descripcion
            // 
            this.tmi_descripcion.CheckOnClick = true;
            this.tmi_descripcion.Name = "tmi_descripcion";
            this.tmi_descripcion.Size = new System.Drawing.Size(190, 22);
            this.tmi_descripcion.Text = "Descripción Factura";
            this.tmi_descripcion.Click += new System.EventHandler(this.tmi_descripcion_Click);
            // 
            // tmi_descripcionProducto
            // 
            this.tmi_descripcionProducto.CheckOnClick = true;
            this.tmi_descripcionProducto.Name = "tmi_descripcionProducto";
            this.tmi_descripcionProducto.Size = new System.Drawing.Size(190, 22);
            this.tmi_descripcionProducto.Text = "Descripción Producto";
            this.tmi_descripcionProducto.Click += new System.EventHandler(this.tmi_descripcionProducto_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.grb_pendientes);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(947, 628);
            this.panel2.TabIndex = 39;
            // 
            // grb_pendientes
            // 
            this.grb_pendientes.Controls.Add(this.flp_pendientes);
            this.grb_pendientes.Dock = System.Windows.Forms.DockStyle.Left;
            this.grb_pendientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.grb_pendientes.Location = new System.Drawing.Point(0, 0);
            this.grb_pendientes.Name = "grb_pendientes";
            this.grb_pendientes.Size = new System.Drawing.Size(0, 628);
            this.grb_pendientes.TabIndex = 2;
            this.grb_pendientes.TabStop = false;
            this.grb_pendientes.Text = "Pendientes";
            this.grb_pendientes.Visible = false;
            // 
            // flp_pendientes
            // 
            this.flp_pendientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_pendientes.Location = new System.Drawing.Point(3, 16);
            this.flp_pendientes.Name = "flp_pendientes";
            this.flp_pendientes.Size = new System.Drawing.Size(0, 609);
            this.flp_pendientes.TabIndex = 0;
            // 
            // frm_factura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(947, 656);
            this.ContextMenuStrip = this.cms_clickDerecho;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frm_factura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Factura";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_factura_FormClosing);
            this.Load += new System.EventHandler(this.frm_factura_Load);
            this.SizeChanged += new System.EventHandler(this.frm_factura_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_factura_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frm_factura_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grw_productos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tco_formaPago.ResumeLayout(false);
            this.tab_abono.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grw_abonos)).EndInit();
            this.tab_efectivo.ResumeLayout(false);
            this.tab_efectivo.PerformLayout();
            this.tab_cheque.ResumeLayout(false);
            this.tab_cheque.PerformLayout();
            this.tab_retencion.ResumeLayout(false);
            this.tab_retencion.PerformLayout();
            this.tab_notaCredito.ResumeLayout(false);
            this.tab_notaCredito.PerformLayout();
            this.grp_total.ResumeLayout(false);
            this.grp_total.PerformLayout();
            this.pan_vuelto.ResumeLayout(false);
            this.pan_vuelto.PerformLayout();
            this.pan_totales.ResumeLayout(false);
            this.pan_totales.PerformLayout();
            this.grb_extras.ResumeLayout(false);
            this.grb_extras.PerformLayout();
            this.flp_datosFactura.ResumeLayout(false);
            this.flp_personas.ResumeLayout(false);
            this.flp_personas.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flp_tipoDocumento.ResumeLayout(false);
            this.flp_tipoDocumento.PerformLayout();
            this.flp_autorizacion.ResumeLayout(false);
            this.flp_autorizacion.PerformLayout();
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.flowLayoutPanel7.ResumeLayout(false);
            this.flowLayoutPanel7.PerformLayout();
            this.flp_fechaVencimiento.ResumeLayout(false);
            this.flp_fechaVencimiento.PerformLayout();
            this.flp_descripcion.ResumeLayout(false);
            this.flp_descripcion.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.cms_clickDerecho.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.grb_pendientes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.GroupBox grb_extras;
        private System.Windows.Forms.Button btn_buscarCliente;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_Nombres;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_ruc;
        private System.Windows.Forms.Button btn_crearCliente;
        private System.Windows.Forms.TextBox txt_numAut;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_descProducto;
        private System.Windows.Forms.CheckBox chk_descProd;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox chk_dna;
        private System.Windows.Forms.TextBox txt_secuencia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_tipo;
        private System.Windows.Forms.TextBox txt_numDoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView grw_productos;
        private System.Windows.Forms.TabControl tco_formaPago;
        private System.Windows.Forms.TabPage tab_efectivo;
        private System.Windows.Forms.TextBox txt_efectivo;
        private System.Windows.Forms.Label lbl_efectivo;
        private System.Windows.Forms.TabPage tab_cheque;
        private System.Windows.Forms.Label lbl_ncheque;
        private System.Windows.Forms.TextBox txt_montoc;
        private System.Windows.Forms.Label lbl_montoc;
        private System.Windows.Forms.TextBox txt_numeroc;
        private System.Windows.Forms.TextBox txt_banco;
        private System.Windows.Forms.Label lbl_banco;
        private System.Windows.Forms.TabPage tab_retencion;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txt_retencion;
        private System.Windows.Forms.TextBox txt_numeroRetencion;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.GroupBox grp_total;
        private System.Windows.Forms.TextBox txt_servicio;
        private System.Windows.Forms.Label lbl_servicio;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txt_iva12;
        private System.Windows.Forms.TextBox txt_iva0;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_iva;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_descuento;
        private System.Windows.Forms.CheckBox chk_todoEfectivo;
        private System.Windows.Forms.TextBox txt_numerot1;
        private System.Windows.Forms.ComboBox cmb_pin2;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txt_montot1;
        private System.Windows.Forms.TextBox txt_numerot2;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_montot2;
        private System.Windows.Forms.ComboBox cmb_tipo2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lbl_ntarjeta;
        private System.Windows.Forms.Label lbl_tipo;
        private System.Windows.Forms.ComboBox cmb_tipo1;
        private System.Windows.Forms.Label lbl_montot;
        private System.Windows.Forms.ComboBox cmb_pin1;
        private System.Windows.Forms.ComboBox cmb_estado;
        private System.Windows.Forms.TabPage tab_notaCredito;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txt_montoNota;
        private System.Windows.Forms.TextBox txt_numeroNota;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton tsb_guardar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsb_imprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsb_anular;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsb_nuevo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsb_duplicar;
        private System.Windows.Forms.ComboBox cmb_vendedor;
        private System.Windows.Forms.Label lbl_vendedor;
        private System.Windows.Forms.Label txt_fecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chk_servicio;
        private System.Windows.Forms.TextBox txt_propina;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Panel pan_vuelto;
        private System.Windows.Forms.Panel pan_totales;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label txt_totalpago;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label txt_total;
        private System.Windows.Forms.Label txt_vuelto;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label txt_saldo;
        private System.Windows.Forms.ToolStripSeparator tls_guia;
        private System.Windows.Forms.ToolStripButton tsb_guia;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flp_datosFactura;
        private System.Windows.Forms.FlowLayoutPanel flp_personas;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flp_tipoDocumento;
        private System.Windows.Forms.FlowLayoutPanel flp_autorizacion;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.FlowLayoutPanel flp_fechaVencimiento;
        private System.Windows.Forms.DateTimePicker dtp_vencimiento;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ContextMenuStrip cms_clickDerecho;
        private System.Windows.Forms.ToolStripMenuItem tmi_nuevo;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tmi_tipoDocumento;
        private System.Windows.Forms.ToolStripMenuItem tmi_autorizacion;
        private System.Windows.Forms.ToolStripMenuItem tmi_fechaVencimiento;
        private System.Windows.Forms.ToolStripMenuItem tmi_descripcion;
        private System.Windows.Forms.FlowLayoutPanel flp_descripcion;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_descipcion;
        private System.Windows.Forms.TabPage tab_abono;
        private System.Windows.Forms.DataGridView grw_abonos;
        private System.Windows.Forms.Button btn_agregarPago;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem tmi_pendientes;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox grb_pendientes;
        private System.Windows.Forms.FlowLayoutPanel flp_pendientes;
        private System.Windows.Forms.ToolStripMenuItem tmi_descripcionProducto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem tsb_preCuenta;
        private System.Windows.Forms.ToolStripMenuItem tsb_imprimirFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nuevo;
        private System.Windows.Forms.DataGridViewButtonColumn botonEliminarPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewButtonColumn botonBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn serie;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewComboBoxColumn precioU;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn pdesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotaldesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotal;
        private System.Windows.Forms.DataGridViewButtonColumn botonEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn iva;
        private System.Windows.Forms.DataGridViewTextBoxColumn ice;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn llena;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_detalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn promocion;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn pvp_manual;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_serie;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifico;
        private System.Windows.Forms.DataGridViewTextBoxColumn combo;
        private System.Windows.Forms.DataGridViewTextBoxColumn lista_combo;
        private System.Windows.Forms.DataGridViewTextBoxColumn referencia_combo;
        private System.Windows.Forms.ToolStripButton tsb_reversar;

    }
}