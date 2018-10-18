namespace Pos.App
{
    partial class frm_usuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_usuario));
            this.grp_usuario = new System.Windows.Forms.GroupBox();
            this.lbl_estado = new System.Windows.Forms.Label();
            this.cmb_estado = new System.Windows.Forms.ComboBox();
            this.lbl_rol = new System.Windows.Forms.Label();
            this.cmb_rol = new System.Windows.Forms.ComboBox();
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.txt_usuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_usuario = new System.Windows.Forms.Label();
            this.grp_empleado = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_agregarEmpleado = new System.Windows.Forms.Button();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.txt_cedula = new System.Windows.Forms.TextBox();
            this.lbl_nombre = new System.Windows.Forms.Label();
            this.grp_usuario.SuspendLayout();
            this.grp_empleado.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_usuario
            // 
            this.grp_usuario.Controls.Add(this.lbl_estado);
            this.grp_usuario.Controls.Add(this.cmb_estado);
            this.grp_usuario.Controls.Add(this.lbl_rol);
            this.grp_usuario.Controls.Add(this.cmb_rol);
            this.grp_usuario.Controls.Add(this.btn_salir);
            this.grp_usuario.Controls.Add(this.btn_limpiar);
            this.grp_usuario.Controls.Add(this.btn_guardar);
            this.grp_usuario.Controls.Add(this.txt_password);
            this.grp_usuario.Controls.Add(this.txt_usuario);
            this.grp_usuario.Controls.Add(this.label1);
            this.grp_usuario.Controls.Add(this.lbl_usuario);
            this.grp_usuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.grp_usuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(191)))), ((int)(((byte)(68)))));
            this.grp_usuario.Location = new System.Drawing.Point(0, 93);
            this.grp_usuario.Name = "grp_usuario";
            this.grp_usuario.Size = new System.Drawing.Size(443, 230);
            this.grp_usuario.TabIndex = 3;
            this.grp_usuario.TabStop = false;
            this.grp_usuario.Text = "Datos Usuario";
            // 
            // lbl_estado
            // 
            this.lbl_estado.AutoSize = true;
            this.lbl_estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_estado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.lbl_estado.Location = new System.Drawing.Point(46, 124);
            this.lbl_estado.Name = "lbl_estado";
            this.lbl_estado.Size = new System.Drawing.Size(55, 15);
            this.lbl_estado.TabIndex = 11;
            this.lbl_estado.Text = "Estado:";
            this.lbl_estado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmb_estado
            // 
            this.cmb_estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_estado.FormattingEnabled = true;
            this.cmb_estado.ItemHeight = 15;
            this.cmb_estado.Location = new System.Drawing.Point(105, 121);
            this.cmb_estado.Name = "cmb_estado";
            this.cmb_estado.Size = new System.Drawing.Size(292, 23);
            this.cmb_estado.TabIndex = 6;
            // 
            // lbl_rol
            // 
            this.lbl_rol.AutoSize = true;
            this.lbl_rol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_rol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.lbl_rol.Location = new System.Drawing.Point(64, 87);
            this.lbl_rol.Name = "lbl_rol";
            this.lbl_rol.Size = new System.Drawing.Size(33, 15);
            this.lbl_rol.TabIndex = 8;
            this.lbl_rol.Text = "Rol:";
            this.lbl_rol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmb_rol
            // 
            this.cmb_rol.BackColor = System.Drawing.SystemColors.Window;
            this.cmb_rol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_rol.FormattingEnabled = true;
            this.cmb_rol.ItemHeight = 15;
            this.cmb_rol.Location = new System.Drawing.Point(107, 87);
            this.cmb_rol.Name = "cmb_rol";
            this.cmb_rol.Size = new System.Drawing.Size(292, 23);
            this.cmb_rol.TabIndex = 5;
            // 
            // btn_salir
            // 
            this.btn_salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.btn_salir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(110)))), ((int)(((byte)(189)))));
            this.btn_salir.Image = global::Pos.Properties.Resources.cerrar;
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salir.Location = new System.Drawing.Point(278, 166);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.btn_salir.Size = new System.Drawing.Size(92, 46);
            this.btn_salir.TabIndex = 9;
            this.btn_salir.Text = "Cerrar";
            this.btn_salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salir.UseVisualStyleBackColor = false;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.btn_limpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(110)))), ((int)(((byte)(189)))));
            this.btn_limpiar.Image = global::Pos.Properties.Resources.edit_clear;
            this.btn_limpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_limpiar.Location = new System.Drawing.Point(180, 166);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(92, 46);
            this.btn_limpiar.TabIndex = 8;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_limpiar.UseVisualStyleBackColor = false;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // btn_guardar
            // 
            this.btn_guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.btn_guardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(110)))), ((int)(((byte)(189)))));
            this.btn_guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_guardar.Image")));
            this.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_guardar.Location = new System.Drawing.Point(84, 166);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(92, 46);
            this.btn_guardar.TabIndex = 7;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar.UseVisualStyleBackColor = false;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(106, 56);
            this.txt_password.MaxLength = 15;
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(292, 21);
            this.txt_password.TabIndex = 4;
            // 
            // txt_usuario
            // 
            this.txt_usuario.Location = new System.Drawing.Point(106, 25);
            this.txt_usuario.MaxLength = 15;
            this.txt_usuario.Name = "txt_usuario";
            this.txt_usuario.Size = new System.Drawing.Size(292, 21);
            this.txt_usuario.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label1.Location = new System.Drawing.Point(29, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Password:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_usuario
            // 
            this.lbl_usuario.AutoSize = true;
            this.lbl_usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_usuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.lbl_usuario.Location = new System.Drawing.Point(41, 28);
            this.lbl_usuario.Name = "lbl_usuario";
            this.lbl_usuario.Size = new System.Drawing.Size(61, 15);
            this.lbl_usuario.TabIndex = 0;
            this.lbl_usuario.Text = "Usuario:";
            this.lbl_usuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grp_empleado
            // 
            this.grp_empleado.Controls.Add(this.label3);
            this.grp_empleado.Controls.Add(this.btn_agregarEmpleado);
            this.grp_empleado.Controls.Add(this.btn_buscar);
            this.grp_empleado.Controls.Add(this.txt_nombre);
            this.grp_empleado.Controls.Add(this.txt_cedula);
            this.grp_empleado.Controls.Add(this.lbl_nombre);
            this.grp_empleado.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp_empleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.grp_empleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(191)))), ((int)(((byte)(68)))));
            this.grp_empleado.Location = new System.Drawing.Point(0, 0);
            this.grp_empleado.Name = "grp_empleado";
            this.grp_empleado.Size = new System.Drawing.Size(443, 93);
            this.grp_empleado.TabIndex = 2;
            this.grp_empleado.TabStop = false;
            this.grp_empleado.Text = "Empleado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label3.Location = new System.Drawing.Point(38, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nombre:";
            // 
            // btn_agregarEmpleado
            // 
            this.btn_agregarEmpleado.Image = global::Pos.Properties.Resources.crear;
            this.btn_agregarEmpleado.Location = new System.Drawing.Point(262, 26);
            this.btn_agregarEmpleado.Name = "btn_agregarEmpleado";
            this.btn_agregarEmpleado.Size = new System.Drawing.Size(25, 25);
            this.btn_agregarEmpleado.TabIndex = 3;
            this.btn_agregarEmpleado.UseVisualStyleBackColor = true;
            this.btn_agregarEmpleado.Click += new System.EventHandler(this.btn_crear_Click);
            // 
            // btn_buscar
            // 
            this.btn_buscar.Image = global::Pos.Properties.Resources.buscar_lupa;
            this.btn_buscar.Location = new System.Drawing.Point(233, 26);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(25, 25);
            this.btn_buscar.TabIndex = 2;
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // txt_nombre
            // 
            this.txt_nombre.BackColor = System.Drawing.SystemColors.Window;
            this.txt_nombre.Enabled = false;
            this.txt_nombre.Location = new System.Drawing.Point(106, 59);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(292, 21);
            this.txt_nombre.TabIndex = 2;
            // 
            // txt_cedula
            // 
            this.txt_cedula.Location = new System.Drawing.Point(106, 28);
            this.txt_cedula.MaxLength = 10;
            this.txt_cedula.Name = "txt_cedula";
            this.txt_cedula.Size = new System.Drawing.Size(121, 21);
            this.txt_cedula.TabIndex = 1;
            this.txt_cedula.TextChanged += new System.EventHandler(this.txt_cedula_TextChanged);
            this.txt_cedula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cedula_KeyPress);
            // 
            // lbl_nombre
            // 
            this.lbl_nombre.AutoSize = true;
            this.lbl_nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_nombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.lbl_nombre.Location = new System.Drawing.Point(44, 28);
            this.lbl_nombre.Name = "lbl_nombre";
            this.lbl_nombre.Size = new System.Drawing.Size(56, 15);
            this.lbl_nombre.TabIndex = 0;
            this.lbl_nombre.Text = "Cedula:";
            this.lbl_nombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frm_usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 323);
            this.Controls.Add(this.grp_usuario);
            this.Controls.Add(this.grp_empleado);
            this.Name = "frm_usuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Usuario";
            this.Load += new System.EventHandler(this.frm_usuario_Load);
            this.grp_usuario.ResumeLayout(false);
            this.grp_usuario.PerformLayout();
            this.grp_empleado.ResumeLayout(false);
            this.grp_empleado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_usuario;
        private System.Windows.Forms.Label lbl_estado;
        private System.Windows.Forms.ComboBox cmb_estado;
        private System.Windows.Forms.Label lbl_rol;
        private System.Windows.Forms.ComboBox cmb_rol;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.TextBox txt_usuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_usuario;
        private System.Windows.Forms.GroupBox grp_empleado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_agregarEmpleado;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.TextBox txt_cedula;
        private System.Windows.Forms.Label lbl_nombre;
    }
}