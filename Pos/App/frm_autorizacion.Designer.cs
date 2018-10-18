namespace Pos.App
{
    partial class frm_autorizacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_autorizacion));
            this.grp_datos = new System.Windows.Forms.GroupBox();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.txt_fin = new System.Windows.Forms.TextBox();
            this.txt_inicio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_fechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_autorizacion = new System.Windows.Forms.TextBox();
            this.cmb_establecimiento = new System.Windows.Forms.ComboBox();
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.lbl_empresa = new System.Windows.Forms.Label();
            this.grp_datos.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_datos
            // 
            this.grp_datos.BackColor = System.Drawing.SystemColors.Control;
            this.grp_datos.Controls.Add(this.btn_limpiar);
            this.grp_datos.Controls.Add(this.txt_fin);
            this.grp_datos.Controls.Add(this.txt_inicio);
            this.grp_datos.Controls.Add(this.label4);
            this.grp_datos.Controls.Add(this.label3);
            this.grp_datos.Controls.Add(this.label2);
            this.grp_datos.Controls.Add(this.dtp_fechaVencimiento);
            this.grp_datos.Controls.Add(this.label1);
            this.grp_datos.Controls.Add(this.txt_autorizacion);
            this.grp_datos.Controls.Add(this.cmb_establecimiento);
            this.grp_datos.Controls.Add(this.btn_salir);
            this.grp_datos.Controls.Add(this.btn_guardar);
            this.grp_datos.Controls.Add(this.lbl_empresa);
            this.grp_datos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_datos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.grp_datos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(191)))), ((int)(((byte)(68)))));
            this.grp_datos.Location = new System.Drawing.Point(0, 0);
            this.grp_datos.Name = "grp_datos";
            this.grp_datos.Size = new System.Drawing.Size(537, 264);
            this.grp_datos.TabIndex = 1;
            this.grp_datos.TabStop = false;
            this.grp_datos.Text = "Datos";
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.btn_limpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(110)))), ((int)(((byte)(189)))));
            this.btn_limpiar.Image = global::Pos.Properties.Resources.edit_clear;
            this.btn_limpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_limpiar.Location = new System.Drawing.Point(219, 205);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(95, 46);
            this.btn_limpiar.TabIndex = 6;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_limpiar.UseVisualStyleBackColor = false;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click_1);
            // 
            // txt_fin
            // 
            this.txt_fin.Location = new System.Drawing.Point(182, 126);
            this.txt_fin.MaxLength = 10;
            this.txt_fin.Name = "txt_fin";
            this.txt_fin.Size = new System.Drawing.Size(292, 21);
            this.txt_fin.TabIndex = 3;
            this.txt_fin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_fin_KeyPress);
            // 
            // txt_inicio
            // 
            this.txt_inicio.Location = new System.Drawing.Point(182, 95);
            this.txt_inicio.MaxLength = 10;
            this.txt_inicio.Name = "txt_inicio";
            this.txt_inicio.Size = new System.Drawing.Size(292, 21);
            this.txt_inicio.TabIndex = 2;
            this.txt_inicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_inicio_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label4.Location = new System.Drawing.Point(60, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 15);
            this.label4.TabIndex = 21;
            this.label4.Text = "Secuencia Fin:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label3.Location = new System.Drawing.Point(45, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "Secuencia Inicio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label2.Location = new System.Drawing.Point(29, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Fecha Vencimiento:";
            // 
            // dtp_fechaVencimiento
            // 
            this.dtp_fechaVencimiento.Location = new System.Drawing.Point(182, 159);
            this.dtp_fechaVencimiento.Name = "dtp_fechaVencimiento";
            this.dtp_fechaVencimiento.Size = new System.Drawing.Size(292, 21);
            this.dtp_fechaVencimiento.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label1.Location = new System.Drawing.Point(72, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Autorización:";
            // 
            // txt_autorizacion
            // 
            this.txt_autorizacion.Location = new System.Drawing.Point(182, 65);
            this.txt_autorizacion.MaxLength = 10;
            this.txt_autorizacion.Name = "txt_autorizacion";
            this.txt_autorizacion.Size = new System.Drawing.Size(292, 21);
            this.txt_autorizacion.TabIndex = 1;
            this.txt_autorizacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_autorizacion_KeyPress_1);
            // 
            // cmb_establecimiento
            // 
            this.cmb_establecimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_establecimiento.FormattingEnabled = true;
            this.cmb_establecimiento.Location = new System.Drawing.Point(182, 34);
            this.cmb_establecimiento.Name = "cmb_establecimiento";
            this.cmb_establecimiento.Size = new System.Drawing.Size(292, 23);
            this.cmb_establecimiento.TabIndex = 0;
            this.cmb_establecimiento.SelectedIndexChanged += new System.EventHandler(this.cmb_establecimiento_SelectedIndexChanged);
            // 
            // btn_salir
            // 
            this.btn_salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.btn_salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btn_salir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(110)))), ((int)(((byte)(189)))));
            this.btn_salir.Image = global::Pos.Properties.Resources.salir;
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salir.Location = new System.Drawing.Point(317, 205);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.btn_salir.Size = new System.Drawing.Size(95, 46);
            this.btn_salir.TabIndex = 7;
            this.btn_salir.Text = "Cerrar";
            this.btn_salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salir.UseVisualStyleBackColor = false;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // btn_guardar
            // 
            this.btn_guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.btn_guardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_guardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(110)))), ((int)(((byte)(189)))));
            this.btn_guardar.Image = global::Pos.Properties.Resources.guardar;
            this.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_guardar.Location = new System.Drawing.Point(121, 205);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(95, 46);
            this.btn_guardar.TabIndex = 5;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar.UseVisualStyleBackColor = false;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // lbl_empresa
            // 
            this.lbl_empresa.AutoSize = true;
            this.lbl_empresa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.lbl_empresa.Location = new System.Drawing.Point(48, 34);
            this.lbl_empresa.Name = "lbl_empresa";
            this.lbl_empresa.Size = new System.Drawing.Size(114, 15);
            this.lbl_empresa.TabIndex = 0;
            this.lbl_empresa.Text = "Establecimiento:";
            // 
            // frm_autorizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(537, 264);
            this.Controls.Add(this.grp_datos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_autorizacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autorización de SRI";
            this.Load += new System.EventHandler(this.frm_autorizacion_Load);
            this.grp_datos.ResumeLayout(false);
            this.grp_datos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_datos;
        private System.Windows.Forms.Label lbl_empresa;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.ComboBox cmb_establecimiento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_autorizacion;
        private System.Windows.Forms.TextBox txt_fin;
        private System.Windows.Forms.TextBox txt_inicio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_fechaVencimiento;
        private System.Windows.Forms.Button btn_limpiar;
    }
}