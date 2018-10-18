namespace Pos.App
{
    partial class frm_configuracionPos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_configuracionPos));
            this.grp_general = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdb_usarSecuenciaSI = new System.Windows.Forms.RadioButton();
            this.rdb_usarSecuenciaNo = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rd_factura = new System.Windows.Forms.RadioButton();
            this.rd_notaVenta = new System.Windows.Forms.RadioButton();
            this.rd_dna = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_maquina = new System.Windows.Forms.TextBox();
            this.cmb_autorizacion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_establecimiento = new System.Windows.Forms.ComboBox();
            this.chk_predeterminada = new System.Windows.Forms.CheckBox();
            this.lbl_actual = new System.Windows.Forms.Label();
            this.txt_actual = new System.Windows.Forms.TextBox();
            this.txt_final = new System.Windows.Forms.TextBox();
            this.lbl_final = new System.Windows.Forms.Label();
            this.txt_documento = new System.Windows.Forms.TextBox();
            this.txt_codigoEmision = new System.Windows.Forms.TextBox();
            this.txt_ptoEmision = new System.Windows.Forms.TextBox();
            this.txt_secuencial = new System.Windows.Forms.TextBox();
            this.chk_stock = new System.Windows.Forms.CheckBox();
            this.chk_servicio = new System.Windows.Forms.CheckBox();
            this.chk_sinCobro = new System.Windows.Forms.CheckBox();
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk_secuenciaImprimir = new System.Windows.Forms.CheckBox();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.rd_guia = new System.Windows.Forms.RadioButton();
            this.grp_general.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_general
            // 
            this.grp_general.BackColor = System.Drawing.Color.Transparent;
            this.grp_general.Controls.Add(this.panel2);
            this.grp_general.Controls.Add(this.panel1);
            this.grp_general.Controls.Add(this.label3);
            this.grp_general.Controls.Add(this.label5);
            this.grp_general.Controls.Add(this.label4);
            this.grp_general.Controls.Add(this.txt_maquina);
            this.grp_general.Controls.Add(this.cmb_autorizacion);
            this.grp_general.Controls.Add(this.label2);
            this.grp_general.Controls.Add(this.label1);
            this.grp_general.Controls.Add(this.cmb_establecimiento);
            this.grp_general.Controls.Add(this.chk_predeterminada);
            this.grp_general.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp_general.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.grp_general.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(191)))), ((int)(((byte)(68)))));
            this.grp_general.Location = new System.Drawing.Point(0, 0);
            this.grp_general.Name = "grp_general";
            this.grp_general.Size = new System.Drawing.Size(576, 225);
            this.grp_general.TabIndex = 0;
            this.grp_general.TabStop = false;
            this.grp_general.Text = "Datos generales";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdb_usarSecuenciaSI);
            this.panel2.Controls.Add(this.rdb_usarSecuenciaNo);
            this.panel2.Location = new System.Drawing.Point(147, 181);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(162, 27);
            this.panel2.TabIndex = 26;
            // 
            // rdb_usarSecuenciaSI
            // 
            this.rdb_usarSecuenciaSI.AutoSize = true;
            this.rdb_usarSecuenciaSI.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rdb_usarSecuenciaSI.Location = new System.Drawing.Point(3, 3);
            this.rdb_usarSecuenciaSI.Name = "rdb_usarSecuenciaSI";
            this.rdb_usarSecuenciaSI.Size = new System.Drawing.Size(38, 19);
            this.rdb_usarSecuenciaSI.TabIndex = 7;
            this.rdb_usarSecuenciaSI.TabStop = true;
            this.rdb_usarSecuenciaSI.Text = "Si";
            this.rdb_usarSecuenciaSI.UseVisualStyleBackColor = true;
            this.rdb_usarSecuenciaSI.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rdb_usarSecuenciaNo
            // 
            this.rdb_usarSecuenciaNo.AutoSize = true;
            this.rdb_usarSecuenciaNo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rdb_usarSecuenciaNo.Location = new System.Drawing.Point(94, 3);
            this.rdb_usarSecuenciaNo.Name = "rdb_usarSecuenciaNo";
            this.rdb_usarSecuenciaNo.Size = new System.Drawing.Size(43, 19);
            this.rdb_usarSecuenciaNo.TabIndex = 8;
            this.rdb_usarSecuenciaNo.TabStop = true;
            this.rdb_usarSecuenciaNo.Text = "No";
            this.rdb_usarSecuenciaNo.UseVisualStyleBackColor = true;
            this.rdb_usarSecuenciaNo.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rd_guia);
            this.panel1.Controls.Add(this.rd_factura);
            this.panel1.Controls.Add(this.rd_notaVenta);
            this.panel1.Controls.Add(this.rd_dna);
            this.panel1.Location = new System.Drawing.Point(148, 112);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(414, 31);
            this.panel1.TabIndex = 26;
            // 
            // rd_factura
            // 
            this.rd_factura.AutoSize = true;
            this.rd_factura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.rd_factura.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rd_factura.Location = new System.Drawing.Point(3, 3);
            this.rd_factura.Name = "rd_factura";
            this.rd_factura.Size = new System.Drawing.Size(73, 19);
            this.rd_factura.TabIndex = 3;
            this.rd_factura.Text = "Factura";
            this.rd_factura.UseVisualStyleBackColor = true;
            this.rd_factura.CheckedChanged += new System.EventHandler(this.rd_factura_CheckedChanged);
            // 
            // rd_notaVenta
            // 
            this.rd_notaVenta.AutoSize = true;
            this.rd_notaVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.rd_notaVenta.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rd_notaVenta.Location = new System.Drawing.Point(84, 3);
            this.rd_notaVenta.Name = "rd_notaVenta";
            this.rd_notaVenta.Size = new System.Drawing.Size(129, 19);
            this.rd_notaVenta.TabIndex = 4;
            this.rd_notaVenta.Text = "Nota Vta. (RISE)";
            this.rd_notaVenta.UseVisualStyleBackColor = true;
            this.rd_notaVenta.CheckedChanged += new System.EventHandler(this.rd_notaVenta_CheckedChanged);
            // 
            // rd_dna
            // 
            this.rd_dna.AutoSize = true;
            this.rd_dna.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.rd_dna.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rd_dna.Location = new System.Drawing.Point(223, 3);
            this.rd_dna.Name = "rd_dna";
            this.rd_dna.Size = new System.Drawing.Size(111, 19);
            this.rd_dna.TabIndex = 5;
            this.rd_dna.Text = "Comprobante";
            this.rd_dna.UseVisualStyleBackColor = true;
            this.rd_dna.CheckedChanged += new System.EventHandler(this.rd_dna_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label3.Location = new System.Drawing.Point(33, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Usar Secuencia:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label5.Location = new System.Drawing.Point(9, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Documento Emitido:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label4.Location = new System.Drawing.Point(73, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Máquina:";
            // 
            // txt_maquina
            // 
            this.txt_maquina.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txt_maquina.Enabled = false;
            this.txt_maquina.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_maquina.ForeColor = System.Drawing.Color.Maroon;
            this.txt_maquina.Location = new System.Drawing.Point(147, 81);
            this.txt_maquina.Name = "txt_maquina";
            this.txt_maquina.ReadOnly = true;
            this.txt_maquina.Size = new System.Drawing.Size(292, 22);
            this.txt_maquina.TabIndex = 2;
            this.txt_maquina.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmb_autorizacion
            // 
            this.cmb_autorizacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_autorizacion.FormattingEnabled = true;
            this.cmb_autorizacion.Location = new System.Drawing.Point(147, 152);
            this.cmb_autorizacion.Name = "cmb_autorizacion";
            this.cmb_autorizacion.Size = new System.Drawing.Size(292, 23);
            this.cmb_autorizacion.TabIndex = 6;
            this.cmb_autorizacion.SelectedIndexChanged += new System.EventHandler(this.cmb_autorizacion_SelectedIndexChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label2.Location = new System.Drawing.Point(26, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Autorización SRI:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label1.Location = new System.Drawing.Point(28, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Establecimiento:";
            // 
            // cmb_establecimiento
            // 
            this.cmb_establecimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_establecimiento.FormattingEnabled = true;
            this.cmb_establecimiento.Location = new System.Drawing.Point(147, 47);
            this.cmb_establecimiento.Name = "cmb_establecimiento";
            this.cmb_establecimiento.Size = new System.Drawing.Size(292, 23);
            this.cmb_establecimiento.TabIndex = 1;
            this.cmb_establecimiento.SelectedIndexChanged += new System.EventHandler(this.cmb_establecimiento_SelectedIndexChanged);
            // 
            // chk_predeterminada
            // 
            this.chk_predeterminada.AutoSize = true;
            this.chk_predeterminada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.chk_predeterminada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.chk_predeterminada.Location = new System.Drawing.Point(433, 20);
            this.chk_predeterminada.Name = "chk_predeterminada";
            this.chk_predeterminada.Size = new System.Drawing.Size(129, 19);
            this.chk_predeterminada.TabIndex = 18;
            this.chk_predeterminada.Text = "Predeterminada";
            this.chk_predeterminada.UseVisualStyleBackColor = true;
            // 
            // lbl_actual
            // 
            this.lbl_actual.AutoSize = true;
            this.lbl_actual.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_actual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.lbl_actual.Location = new System.Drawing.Point(90, 139);
            this.lbl_actual.Name = "lbl_actual";
            this.lbl_actual.Size = new System.Drawing.Size(45, 15);
            this.lbl_actual.TabIndex = 2;
            this.lbl_actual.Text = "Actual";
            // 
            // txt_actual
            // 
            this.txt_actual.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txt_actual.Enabled = false;
            this.txt_actual.Location = new System.Drawing.Point(147, 136);
            this.txt_actual.MaxLength = 9;
            this.txt_actual.Name = "txt_actual";
            this.txt_actual.ReadOnly = true;
            this.txt_actual.Size = new System.Drawing.Size(109, 21);
            this.txt_actual.TabIndex = 13;
            this.txt_actual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_inicio_KeyPress);
            // 
            // txt_final
            // 
            this.txt_final.Location = new System.Drawing.Point(147, 108);
            this.txt_final.MaxLength = 9;
            this.txt_final.Name = "txt_final";
            this.txt_final.Size = new System.Drawing.Size(109, 21);
            this.txt_final.TabIndex = 12;
            this.txt_final.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_inicio_KeyPress);
            // 
            // lbl_final
            // 
            this.lbl_final.AutoSize = true;
            this.lbl_final.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_final.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.lbl_final.Location = new System.Drawing.Point(105, 108);
            this.lbl_final.Name = "lbl_final";
            this.lbl_final.Size = new System.Drawing.Size(30, 15);
            this.lbl_final.TabIndex = 0;
            this.lbl_final.Text = "Fin:";
            // 
            // txt_documento
            // 
            this.txt_documento.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txt_documento.Enabled = false;
            this.txt_documento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_documento.Location = new System.Drawing.Point(147, 166);
            this.txt_documento.MaxLength = 17;
            this.txt_documento.Name = "txt_documento";
            this.txt_documento.ReadOnly = true;
            this.txt_documento.Size = new System.Drawing.Size(214, 22);
            this.txt_documento.TabIndex = 14;
            this.txt_documento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_documento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_inicio_KeyPress);
            // 
            // txt_codigoEmision
            // 
            this.txt_codigoEmision.BackColor = System.Drawing.SystemColors.Window;
            this.txt_codigoEmision.Enabled = false;
            this.txt_codigoEmision.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_codigoEmision.Location = new System.Drawing.Point(147, 28);
            this.txt_codigoEmision.MaxLength = 3;
            this.txt_codigoEmision.Name = "txt_codigoEmision";
            this.txt_codigoEmision.ReadOnly = true;
            this.txt_codigoEmision.Size = new System.Drawing.Size(109, 22);
            this.txt_codigoEmision.TabIndex = 9;
            this.txt_codigoEmision.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_inicio_KeyPress);
            this.txt_codigoEmision.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_codigoEmision_KeyUp);
            // 
            // txt_ptoEmision
            // 
            this.txt_ptoEmision.Location = new System.Drawing.Point(147, 56);
            this.txt_ptoEmision.MaxLength = 3;
            this.txt_ptoEmision.Name = "txt_ptoEmision";
            this.txt_ptoEmision.Size = new System.Drawing.Size(109, 21);
            this.txt_ptoEmision.TabIndex = 10;
            this.txt_ptoEmision.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_inicio_KeyPress);
            this.txt_ptoEmision.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_ptoEmision_KeyUp);
            // 
            // txt_secuencial
            // 
            this.txt_secuencial.Location = new System.Drawing.Point(147, 82);
            this.txt_secuencial.MaxLength = 9;
            this.txt_secuencial.Name = "txt_secuencial";
            this.txt_secuencial.Size = new System.Drawing.Size(109, 21);
            this.txt_secuencial.TabIndex = 11;
            this.txt_secuencial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_inicio_KeyPress);
            this.txt_secuencial.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_secuencial_KeyUp);
            // 
            // chk_stock
            // 
            this.chk_stock.AutoSize = true;
            this.chk_stock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.chk_stock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.chk_stock.Location = new System.Drawing.Point(147, 266);
            this.chk_stock.Name = "chk_stock";
            this.chk_stock.Size = new System.Drawing.Size(93, 19);
            this.chk_stock.TabIndex = 15;
            this.chk_stock.Text = "Stock en 0";
            this.chk_stock.UseVisualStyleBackColor = true;
            // 
            // chk_servicio
            // 
            this.chk_servicio.AutoSize = true;
            this.chk_servicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.chk_servicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.chk_servicio.Location = new System.Drawing.Point(147, 242);
            this.chk_servicio.Name = "chk_servicio";
            this.chk_servicio.Size = new System.Drawing.Size(109, 19);
            this.chk_servicio.TabIndex = 16;
            this.chk_servicio.Text = "10% Servicio";
            this.chk_servicio.UseVisualStyleBackColor = true;
            // 
            // chk_sinCobro
            // 
            this.chk_sinCobro.AutoSize = true;
            this.chk_sinCobro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.chk_sinCobro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.chk_sinCobro.Location = new System.Drawing.Point(147, 194);
            this.chk_sinCobro.Name = "chk_sinCobro";
            this.chk_sinCobro.Size = new System.Drawing.Size(87, 19);
            this.chk_sinCobro.TabIndex = 17;
            this.chk_sinCobro.Text = "Sin cobro";
            this.chk_sinCobro.UseVisualStyleBackColor = true;
            this.chk_sinCobro.CheckedChanged += new System.EventHandler(this.chk_sinCobro_CheckedChanged);
            // 
            // btn_salir
            // 
            this.btn_salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.btn_salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btn_salir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(110)))), ((int)(((byte)(189)))));
            this.btn_salir.Image = global::Pos.Properties.Resources.cerrar;
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salir.Location = new System.Drawing.Point(341, 524);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.btn_salir.Size = new System.Drawing.Size(92, 46);
            this.btn_salir.TabIndex = 19;
            this.btn_salir.Text = "Cerrar";
            this.btn_salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salir.UseVisualStyleBackColor = false;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // btn_guardar
            // 
            this.btn_guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.btn_guardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btn_guardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(110)))), ((int)(((byte)(189)))));
            this.btn_guardar.Image = global::Pos.Properties.Resources.guardar;
            this.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_guardar.Location = new System.Drawing.Point(143, 525);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(92, 46);
            this.btn_guardar.TabIndex = 18;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar.UseVisualStyleBackColor = false;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label6.Location = new System.Drawing.Point(26, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 15);
            this.label6.TabIndex = 21;
            this.label6.Text = "Establecimiento:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label7.Location = new System.Drawing.Point(75, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 15);
            this.label7.TabIndex = 22;
            this.label7.Text = "Emisión:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label8.Location = new System.Drawing.Point(90, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 15);
            this.label8.TabIndex = 23;
            this.label8.Text = "Inicio:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label9.Location = new System.Drawing.Point(44, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 15);
            this.label9.TabIndex = 24;
            this.label9.Text = "# Documento:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label10.Location = new System.Drawing.Point(55, 196);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 15);
            this.label10.TabIndex = 25;
            this.label10.Text = "Adicionales:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.chk_secuenciaImprimir);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_actual);
            this.groupBox1.Controls.Add(this.lbl_actual);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.chk_stock);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.chk_servicio);
            this.groupBox1.Controls.Add(this.txt_documento);
            this.groupBox1.Controls.Add(this.chk_sinCobro);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txt_codigoEmision);
            this.groupBox1.Controls.Add(this.txt_secuencial);
            this.groupBox1.Controls.Add(this.txt_ptoEmision);
            this.groupBox1.Controls.Add(this.txt_final);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lbl_final);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(191)))), ((int)(((byte)(68)))));
            this.groupBox1.Location = new System.Drawing.Point(0, 225);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(576, 293);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Documento";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // chk_secuenciaImprimir
            // 
            this.chk_secuenciaImprimir.AutoSize = true;
            this.chk_secuenciaImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.chk_secuenciaImprimir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.chk_secuenciaImprimir.Location = new System.Drawing.Point(147, 218);
            this.chk_secuenciaImprimir.Name = "chk_secuenciaImprimir";
            this.chk_secuenciaImprimir.Size = new System.Drawing.Size(223, 19);
            this.chk_secuenciaImprimir.TabIndex = 27;
            this.chk_secuenciaImprimir.Text = "Generar Secuencia al Imprimir";
            this.chk_secuenciaImprimir.UseVisualStyleBackColor = true;
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.btn_limpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btn_limpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(110)))), ((int)(((byte)(189)))));
            this.btn_limpiar.Image = global::Pos.Properties.Resources.edit_clear;
            this.btn_limpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_limpiar.Location = new System.Drawing.Point(243, 525);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(92, 46);
            this.btn_limpiar.TabIndex = 26;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_limpiar.UseVisualStyleBackColor = false;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // rd_guia
            // 
            this.rd_guia.AutoSize = true;
            this.rd_guia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.rd_guia.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rd_guia.Location = new System.Drawing.Point(340, 3);
            this.rd_guia.Name = "rd_guia";
            this.rd_guia.Size = new System.Drawing.Size(55, 19);
            this.rd_guia.TabIndex = 6;
            this.rd_guia.Text = "Guía";
            this.rd_guia.UseVisualStyleBackColor = true;
            this.rd_guia.CheckedChanged += new System.EventHandler(this.rd_guia_CheckedChanged);
            // 
            // frm_configuracionPos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(576, 580);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_limpiar);
            this.Controls.Add(this.grp_general);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.btn_salir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_configuracionPos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuracion del POS";
            this.Load += new System.EventHandler(this.frm_configuracionPos_Load);
            this.grp_general.ResumeLayout(false);
            this.grp_general.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_general;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_establecimiento;
        private System.Windows.Forms.TextBox txt_documento;
        private System.Windows.Forms.Label lbl_actual;
        private System.Windows.Forms.TextBox txt_actual;
        private System.Windows.Forms.TextBox txt_final;
        private System.Windows.Forms.Label lbl_final;
        private System.Windows.Forms.TextBox txt_maquina;
        private System.Windows.Forms.RadioButton rd_notaVenta;
        private System.Windows.Forms.RadioButton rd_factura;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.TextBox txt_codigoEmision;
        private System.Windows.Forms.TextBox txt_ptoEmision;
        private System.Windows.Forms.TextBox txt_secuencial;
        private System.Windows.Forms.ComboBox cmb_autorizacion;
        private System.Windows.Forms.RadioButton rd_dna;
        private System.Windows.Forms.CheckBox chk_stock;
        private System.Windows.Forms.CheckBox chk_servicio;
        private System.Windows.Forms.CheckBox chk_sinCobro;
        private System.Windows.Forms.CheckBox chk_predeterminada;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdb_usarSecuenciaSI;
        private System.Windows.Forms.RadioButton rdb_usarSecuenciaNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.CheckBox chk_secuenciaImprimir;
        private System.Windows.Forms.RadioButton rd_guia;
    }
}