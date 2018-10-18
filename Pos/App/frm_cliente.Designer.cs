namespace Pos.App
{
    partial class frm_Cliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Cliente));
            this.grp_datos = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flp_personas = new System.Windows.Forms.FlowLayoutPanel();
            this.cmb_tipo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.chk_extranjero = new System.Windows.Forms.CheckBox();
            this.txt_cedula = new System.Windows.Forms.TextBox();
            this.lbl_tipo = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.txt_ruc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.lbl_razon = new System.Windows.Forms.Label();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.txt_telefono = new System.Windows.Forms.TextBox();
            this.lbl_fono = new System.Windows.Forms.Label();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.txt_direccion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_codigo = new System.Windows.Forms.TextBox();
            this.flp_codigoCliente = new System.Windows.Forms.FlowLayoutPanel();
            this.grp_datos.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flp_personas.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.flowLayoutPanel7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flp_codigoCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_datos
            // 
            this.grp_datos.BackColor = System.Drawing.SystemColors.Control;
            this.grp_datos.Controls.Add(this.flowLayoutPanel1);
            this.grp_datos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_datos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.grp_datos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(191)))), ((int)(((byte)(68)))));
            this.grp_datos.Location = new System.Drawing.Point(0, 0);
            this.grp_datos.Name = "grp_datos";
            this.grp_datos.Size = new System.Drawing.Size(428, 391);
            this.grp_datos.TabIndex = 0;
            this.grp_datos.TabStop = false;
            this.grp_datos.Text = "Datos";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.flp_personas);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel4);
            this.flowLayoutPanel1.Controls.Add(this.flp_codigoCliente);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel5);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel6);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel7);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(422, 371);
            this.flowLayoutPanel1.TabIndex = 17;
            // 
            // flp_personas
            // 
            this.flp_personas.BackColor = System.Drawing.Color.Transparent;
            this.flp_personas.Controls.Add(this.cmb_tipo);
            this.flp_personas.Controls.Add(this.label3);
            this.flp_personas.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flp_personas.Location = new System.Drawing.Point(0, 0);
            this.flp_personas.Margin = new System.Windows.Forms.Padding(0);
            this.flp_personas.Name = "flp_personas";
            this.flp_personas.Padding = new System.Windows.Forms.Padding(20, 2, 2, 2);
            this.flp_personas.Size = new System.Drawing.Size(416, 30);
            this.flp_personas.TabIndex = 132;
            // 
            // cmb_tipo
            // 
            this.cmb_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_tipo.FormattingEnabled = true;
            this.cmb_tipo.Items.AddRange(new object[] {
            "Natural",
            "Jurídica"});
            this.cmb_tipo.Location = new System.Drawing.Point(114, 5);
            this.cmb_tipo.Name = "cmb_tipo";
            this.cmb_tipo.Size = new System.Drawing.Size(277, 23);
            this.cmb_tipo.TabIndex = 1;
            this.cmb_tipo.SelectedIndexChanged += new System.EventHandler(this.cmb_tipo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label3.Location = new System.Drawing.Point(59, 2);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 3, 10, 0);
            this.label3.Size = new System.Drawing.Size(49, 18);
            this.label3.TabIndex = 14;
            this.label3.Text = "Tipo:";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel2.Controls.Add(this.chk_extranjero);
            this.flowLayoutPanel2.Controls.Add(this.txt_cedula);
            this.flowLayoutPanel2.Controls.Add(this.lbl_tipo);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 30);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(20, 2, 2, 2);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(416, 30);
            this.flowLayoutPanel2.TabIndex = 133;
            // 
            // chk_extranjero
            // 
            this.chk_extranjero.AutoSize = true;
            this.chk_extranjero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.chk_extranjero.Location = new System.Drawing.Point(250, 5);
            this.chk_extranjero.Name = "chk_extranjero";
            this.chk_extranjero.Size = new System.Drawing.Size(141, 19);
            this.chk_extranjero.TabIndex = 3;
            this.chk_extranjero.Text = "Cliente Extranjero";
            this.chk_extranjero.UseVisualStyleBackColor = true;
            // 
            // txt_cedula
            // 
            this.txt_cedula.Location = new System.Drawing.Point(114, 5);
            this.txt_cedula.MaxLength = 10;
            this.txt_cedula.Name = "txt_cedula";
            this.txt_cedula.Size = new System.Drawing.Size(130, 21);
            this.txt_cedula.TabIndex = 2;
            this.txt_cedula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cedula_KeyPress);
            // 
            // lbl_tipo
            // 
            this.lbl_tipo.AutoSize = true;
            this.lbl_tipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.lbl_tipo.Location = new System.Drawing.Point(42, 2);
            this.lbl_tipo.Name = "lbl_tipo";
            this.lbl_tipo.Padding = new System.Windows.Forms.Padding(0, 3, 10, 0);
            this.lbl_tipo.Size = new System.Drawing.Size(66, 18);
            this.lbl_tipo.TabIndex = 0;
            this.lbl_tipo.Text = "Cédula:";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel3.Controls.Add(this.txt_ruc);
            this.flowLayoutPanel3.Controls.Add(this.label4);
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 60);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Padding = new System.Windows.Forms.Padding(20, 2, 2, 2);
            this.flowLayoutPanel3.Size = new System.Drawing.Size(416, 30);
            this.flowLayoutPanel3.TabIndex = 134;
            // 
            // txt_ruc
            // 
            this.txt_ruc.Location = new System.Drawing.Point(114, 5);
            this.txt_ruc.MaxLength = 13;
            this.txt_ruc.Name = "txt_ruc";
            this.txt_ruc.Size = new System.Drawing.Size(277, 21);
            this.txt_ruc.TabIndex = 4;
            this.txt_ruc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_fono_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label4.Location = new System.Drawing.Point(58, 2);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 3, 10, 0);
            this.label4.Size = new System.Drawing.Size(50, 18);
            this.label4.TabIndex = 16;
            this.label4.Text = "RUC:";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel4.Controls.Add(this.txt_nombre);
            this.flowLayoutPanel4.Controls.Add(this.lbl_razon);
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(0, 90);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Padding = new System.Windows.Forms.Padding(20, 2, 2, 2);
            this.flowLayoutPanel4.Size = new System.Drawing.Size(416, 30);
            this.flowLayoutPanel4.TabIndex = 135;
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(114, 5);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(277, 21);
            this.txt_nombre.TabIndex = 5;
            this.txt_nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_caracteres_KeyPress);
            // 
            // lbl_razon
            // 
            this.lbl_razon.AutoSize = true;
            this.lbl_razon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.lbl_razon.Location = new System.Drawing.Point(36, 2);
            this.lbl_razon.Name = "lbl_razon";
            this.lbl_razon.Padding = new System.Windows.Forms.Padding(0, 3, 10, 0);
            this.lbl_razon.Size = new System.Drawing.Size(72, 18);
            this.lbl_razon.TabIndex = 4;
            this.lbl_razon.Text = "Nombre:";
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel5.Controls.Add(this.txt_telefono);
            this.flowLayoutPanel5.Controls.Add(this.lbl_fono);
            this.flowLayoutPanel5.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(0, 150);
            this.flowLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Padding = new System.Windows.Forms.Padding(20, 2, 2, 2);
            this.flowLayoutPanel5.Size = new System.Drawing.Size(416, 30);
            this.flowLayoutPanel5.TabIndex = 136;
            // 
            // txt_telefono
            // 
            this.txt_telefono.Location = new System.Drawing.Point(114, 5);
            this.txt_telefono.MaxLength = 10;
            this.txt_telefono.Name = "txt_telefono";
            this.txt_telefono.Size = new System.Drawing.Size(277, 21);
            this.txt_telefono.TabIndex = 6;
            this.txt_telefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_fono_KeyPress);
            // 
            // lbl_fono
            // 
            this.lbl_fono.AutoSize = true;
            this.lbl_fono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.lbl_fono.Location = new System.Drawing.Point(31, 2);
            this.lbl_fono.Name = "lbl_fono";
            this.lbl_fono.Padding = new System.Windows.Forms.Padding(0, 3, 10, 0);
            this.lbl_fono.Size = new System.Drawing.Size(77, 18);
            this.lbl_fono.TabIndex = 5;
            this.lbl_fono.Text = "Teléfono:";
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel6.Controls.Add(this.txt_email);
            this.flowLayoutPanel6.Controls.Add(this.label2);
            this.flowLayoutPanel6.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel6.Location = new System.Drawing.Point(0, 180);
            this.flowLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Padding = new System.Windows.Forms.Padding(20, 2, 2, 2);
            this.flowLayoutPanel6.Size = new System.Drawing.Size(416, 30);
            this.flowLayoutPanel6.TabIndex = 137;
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(114, 5);
            this.txt_email.MaxLength = 70;
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(277, 21);
            this.txt_email.TabIndex = 7;
            this.txt_email.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_caracteres_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label2.Location = new System.Drawing.Point(50, 2);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 3, 10, 0);
            this.label2.Size = new System.Drawing.Size(58, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Email:";
            // 
            // flowLayoutPanel7
            // 
            this.flowLayoutPanel7.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel7.Controls.Add(this.txt_direccion);
            this.flowLayoutPanel7.Controls.Add(this.label1);
            this.flowLayoutPanel7.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel7.Location = new System.Drawing.Point(0, 210);
            this.flowLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            this.flowLayoutPanel7.Padding = new System.Windows.Forms.Padding(20, 2, 2, 2);
            this.flowLayoutPanel7.Size = new System.Drawing.Size(416, 87);
            this.flowLayoutPanel7.TabIndex = 138;
            // 
            // txt_direccion
            // 
            this.txt_direccion.Location = new System.Drawing.Point(114, 5);
            this.txt_direccion.Multiline = true;
            this.txt_direccion.Name = "txt_direccion";
            this.txt_direccion.Size = new System.Drawing.Size(277, 75);
            this.txt_direccion.TabIndex = 8;
            this.txt_direccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_caracteres_KeyPress);
            this.txt_direccion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_direccion_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label1.Location = new System.Drawing.Point(26, 2);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 3, 10, 0);
            this.label1.Size = new System.Drawing.Size(82, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Dirección:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.btn_limpiar);
            this.panel1.Controls.Add(this.btn_salir);
            this.panel1.Location = new System.Drawing.Point(3, 300);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(413, 70);
            this.panel1.TabIndex = 18;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(110)))), ((int)(((byte)(189)))));
            this.btnGuardar.Image = global::Pos.Properties.Resources.guardar;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(66, 10);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(92, 46);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.btn_limpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(110)))), ((int)(((byte)(189)))));
            this.btn_limpiar.Image = global::Pos.Properties.Resources.edit_clear;
            this.btn_limpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_limpiar.Location = new System.Drawing.Point(164, 10);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(92, 46);
            this.btn_limpiar.TabIndex = 10;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_limpiar.UseVisualStyleBackColor = false;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.btn_salir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(110)))), ((int)(((byte)(189)))));
            this.btn_salir.Image = global::Pos.Properties.Resources.salir;
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salir.Location = new System.Drawing.Point(262, 10);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.btn_salir.Size = new System.Drawing.Size(92, 46);
            this.btn_salir.TabIndex = 11;
            this.btn_salir.Text = "Salir";
            this.btn_salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salir.UseVisualStyleBackColor = false;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label5.Location = new System.Drawing.Point(42, 2);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 3, 10, 0);
            this.label5.Size = new System.Drawing.Size(66, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Código:";
            // 
            // txt_codigo
            // 
            this.txt_codigo.Location = new System.Drawing.Point(114, 5);
            this.txt_codigo.MaxLength = 70;
            this.txt_codigo.Name = "txt_codigo";
            this.txt_codigo.Size = new System.Drawing.Size(277, 21);
            this.txt_codigo.TabIndex = 7;
            // 
            // flp_codigoCliente
            // 
            this.flp_codigoCliente.BackColor = System.Drawing.Color.Transparent;
            this.flp_codigoCliente.Controls.Add(this.txt_codigo);
            this.flp_codigoCliente.Controls.Add(this.label5);
            this.flp_codigoCliente.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flp_codigoCliente.Location = new System.Drawing.Point(0, 120);
            this.flp_codigoCliente.Margin = new System.Windows.Forms.Padding(0);
            this.flp_codigoCliente.Name = "flp_codigoCliente";
            this.flp_codigoCliente.Padding = new System.Windows.Forms.Padding(20, 2, 2, 2);
            this.flp_codigoCliente.Size = new System.Drawing.Size(416, 30);
            this.flp_codigoCliente.TabIndex = 139;
            this.flp_codigoCliente.Visible = false;
            // 
            // frm_Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(428, 391);
            this.Controls.Add(this.grp_datos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Cliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registar Clientes";
            this.Load += new System.EventHandler(this.frm_Cliente_Load);
            this.grp_datos.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flp_personas.ResumeLayout(false);
            this.flp_personas.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.flowLayoutPanel7.ResumeLayout(false);
            this.flowLayoutPanel7.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.flp_codigoCliente.ResumeLayout(false);
            this.flp_codigoCliente.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_datos;
        private System.Windows.Forms.TextBox txt_cedula;
        private System.Windows.Forms.Label lbl_tipo;
        private System.Windows.Forms.TextBox txt_direccion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_telefono;
        private System.Windows.Forms.Label lbl_fono;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.Label lbl_razon;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_tipo;
        private System.Windows.Forms.CheckBox chk_extranjero;
        private System.Windows.Forms.TextBox txt_ruc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flp_personas;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flp_codigoCliente;
        private System.Windows.Forms.TextBox txt_codigo;
        private System.Windows.Forms.Label label5;
    }
}