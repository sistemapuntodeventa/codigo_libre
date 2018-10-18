namespace Pos.App
{
    partial class frm_abono
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
            this.tab_notaCredito = new System.Windows.Forms.TabPage();
            this.label29 = new System.Windows.Forms.Label();
            this.txt_montoNota = new System.Windows.Forms.TextBox();
            this.txt_numeroNota = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.tab_retencion = new System.Windows.Forms.TabPage();
            this.label26 = new System.Windows.Forms.Label();
            this.txt_retencion = new System.Windows.Forms.TextBox();
            this.txt_numeroRetencion = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.tab_cheque = new System.Windows.Forms.TabPage();
            this.lbl_ncheque = new System.Windows.Forms.Label();
            this.txt_montoc = new System.Windows.Forms.TextBox();
            this.txt_numeroc = new System.Windows.Forms.TextBox();
            this.txt_banco = new System.Windows.Forms.TextBox();
            this.lbl_montoc = new System.Windows.Forms.Label();
            this.lbl_banco = new System.Windows.Forms.Label();
            this.tab_efectivo = new System.Windows.Forms.TabPage();
            this.txt_efectivo = new System.Windows.Forms.TextBox();
            this.txt_numerot1 = new System.Windows.Forms.TextBox();
            this.txt_montot1 = new System.Windows.Forms.TextBox();
            this.lbl_efectivo = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lbl_ntarjeta = new System.Windows.Forms.Label();
            this.lbl_tipo = new System.Windows.Forms.Label();
            this.cmb_tipo1 = new System.Windows.Forms.ComboBox();
            this.lbl_montot = new System.Windows.Forms.Label();
            this.cmb_pin1 = new System.Windows.Forms.ComboBox();
            this.tco_formaPago = new System.Windows.Forms.TabControl();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tab_notaCredito.SuspendLayout();
            this.tab_retencion.SuspendLayout();
            this.tab_cheque.SuspendLayout();
            this.tab_efectivo.SuspendLayout();
            this.tco_formaPago.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_notaCredito
            // 
            this.tab_notaCredito.BackColor = System.Drawing.Color.Transparent;
            this.tab_notaCredito.Controls.Add(this.label29);
            this.tab_notaCredito.Controls.Add(this.txt_montoNota);
            this.tab_notaCredito.Controls.Add(this.txt_numeroNota);
            this.tab_notaCredito.Controls.Add(this.label30);
            this.tab_notaCredito.Location = new System.Drawing.Point(4, 22);
            this.tab_notaCredito.Name = "tab_notaCredito";
            this.tab_notaCredito.Padding = new System.Windows.Forms.Padding(3);
            this.tab_notaCredito.Size = new System.Drawing.Size(376, 171);
            this.tab_notaCredito.TabIndex = 3;
            this.tab_notaCredito.Text = "Nota de Crédito";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label29.Location = new System.Drawing.Point(39, 20);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(48, 13);
            this.label29.TabIndex = 58;
            this.label29.Text = "# Nota:";
            // 
            // txt_montoNota
            // 
            this.txt_montoNota.Font = new System.Drawing.Font("Maiandra GD", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_montoNota.Location = new System.Drawing.Point(93, 43);
            this.txt_montoNota.Name = "txt_montoNota";
            this.txt_montoNota.Size = new System.Drawing.Size(243, 22);
            this.txt_montoNota.TabIndex = 56;
            // 
            // txt_numeroNota
            // 
            this.txt_numeroNota.Font = new System.Drawing.Font("Maiandra GD", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_numeroNota.Location = new System.Drawing.Point(93, 15);
            this.txt_numeroNota.MaxLength = 11;
            this.txt_numeroNota.Name = "txt_numeroNota";
            this.txt_numeroNota.Size = new System.Drawing.Size(243, 22);
            this.txt_numeroNota.TabIndex = 57;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label30.Location = new System.Drawing.Point(40, 48);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(46, 13);
            this.label30.TabIndex = 55;
            this.label30.Text = "Monto:";
            // 
            // tab_retencion
            // 
            this.tab_retencion.BackColor = System.Drawing.Color.Transparent;
            this.tab_retencion.Controls.Add(this.label26);
            this.tab_retencion.Controls.Add(this.txt_retencion);
            this.tab_retencion.Controls.Add(this.txt_numeroRetencion);
            this.tab_retencion.Controls.Add(this.label25);
            this.tab_retencion.Location = new System.Drawing.Point(4, 22);
            this.tab_retencion.Name = "tab_retencion";
            this.tab_retencion.Padding = new System.Windows.Forms.Padding(3);
            this.tab_retencion.Size = new System.Drawing.Size(376, 171);
            this.tab_retencion.TabIndex = 2;
            this.tab_retencion.Text = "Retención";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label26.Location = new System.Drawing.Point(7, 20);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(79, 13);
            this.label26.TabIndex = 54;
            this.label26.Text = "# Retención:";
            // 
            // txt_retencion
            // 
            this.txt_retencion.Font = new System.Drawing.Font("Maiandra GD", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_retencion.Location = new System.Drawing.Point(93, 43);
            this.txt_retencion.Name = "txt_retencion";
            this.txt_retencion.Size = new System.Drawing.Size(243, 22);
            this.txt_retencion.TabIndex = 39;
            // 
            // txt_numeroRetencion
            // 
            this.txt_numeroRetencion.Font = new System.Drawing.Font("Maiandra GD", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_numeroRetencion.Location = new System.Drawing.Point(93, 15);
            this.txt_numeroRetencion.MaxLength = 5;
            this.txt_numeroRetencion.Name = "txt_numeroRetencion";
            this.txt_numeroRetencion.Size = new System.Drawing.Size(243, 22);
            this.txt_numeroRetencion.TabIndex = 53;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label25.Location = new System.Drawing.Point(38, 48);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(46, 13);
            this.label25.TabIndex = 36;
            this.label25.Text = "Monto:";
            // 
            // tab_cheque
            // 
            this.tab_cheque.BackColor = System.Drawing.Color.Transparent;
            this.tab_cheque.Controls.Add(this.lbl_ncheque);
            this.tab_cheque.Controls.Add(this.txt_montoc);
            this.tab_cheque.Controls.Add(this.txt_numeroc);
            this.tab_cheque.Controls.Add(this.txt_banco);
            this.tab_cheque.Controls.Add(this.lbl_montoc);
            this.tab_cheque.Controls.Add(this.lbl_banco);
            this.tab_cheque.Location = new System.Drawing.Point(4, 22);
            this.tab_cheque.Name = "tab_cheque";
            this.tab_cheque.Padding = new System.Windows.Forms.Padding(3);
            this.tab_cheque.Size = new System.Drawing.Size(376, 171);
            this.tab_cheque.TabIndex = 1;
            this.tab_cheque.Text = "Cheque";
            // 
            // lbl_ncheque
            // 
            this.lbl_ncheque.AutoSize = true;
            this.lbl_ncheque.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ncheque.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl_ncheque.Location = new System.Drawing.Point(15, 20);
            this.lbl_ncheque.Name = "lbl_ncheque";
            this.lbl_ncheque.Size = new System.Drawing.Size(71, 13);
            this.lbl_ncheque.TabIndex = 22;
            this.lbl_ncheque.Text = "N°. Cheque:";
            // 
            // txt_montoc
            // 
            this.txt_montoc.BackColor = System.Drawing.Color.White;
            this.txt_montoc.Font = new System.Drawing.Font("Maiandra GD", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_montoc.Location = new System.Drawing.Point(93, 70);
            this.txt_montoc.Name = "txt_montoc";
            this.txt_montoc.Size = new System.Drawing.Size(243, 22);
            this.txt_montoc.TabIndex = 29;
            this.txt_montoc.Text = "0";
            // 
            // txt_numeroc
            // 
            this.txt_numeroc.BackColor = System.Drawing.Color.White;
            this.txt_numeroc.Font = new System.Drawing.Font("Maiandra GD", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_numeroc.Location = new System.Drawing.Point(93, 15);
            this.txt_numeroc.MaxLength = 5;
            this.txt_numeroc.Name = "txt_numeroc";
            this.txt_numeroc.Size = new System.Drawing.Size(243, 22);
            this.txt_numeroc.TabIndex = 21;
            // 
            // txt_banco
            // 
            this.txt_banco.BackColor = System.Drawing.Color.White;
            this.txt_banco.Font = new System.Drawing.Font("Maiandra GD", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_banco.Location = new System.Drawing.Point(93, 43);
            this.txt_banco.MaxLength = 300;
            this.txt_banco.Name = "txt_banco";
            this.txt_banco.Size = new System.Drawing.Size(243, 22);
            this.txt_banco.TabIndex = 24;
            // 
            // lbl_montoc
            // 
            this.lbl_montoc.AutoSize = true;
            this.lbl_montoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_montoc.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl_montoc.Location = new System.Drawing.Point(40, 75);
            this.lbl_montoc.Name = "lbl_montoc";
            this.lbl_montoc.Size = new System.Drawing.Size(46, 13);
            this.lbl_montoc.TabIndex = 28;
            this.lbl_montoc.Text = "Monto:";
            // 
            // lbl_banco
            // 
            this.lbl_banco.AutoSize = true;
            this.lbl_banco.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_banco.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl_banco.Location = new System.Drawing.Point(42, 48);
            this.lbl_banco.Name = "lbl_banco";
            this.lbl_banco.Size = new System.Drawing.Size(44, 13);
            this.lbl_banco.TabIndex = 23;
            this.lbl_banco.Text = "Banco:";
            // 
            // tab_efectivo
            // 
            this.tab_efectivo.BackColor = System.Drawing.Color.Transparent;
            this.tab_efectivo.Controls.Add(this.txt_efectivo);
            this.tab_efectivo.Controls.Add(this.txt_numerot1);
            this.tab_efectivo.Controls.Add(this.txt_montot1);
            this.tab_efectivo.Controls.Add(this.lbl_efectivo);
            this.tab_efectivo.Controls.Add(this.label23);
            this.tab_efectivo.Controls.Add(this.lbl_ntarjeta);
            this.tab_efectivo.Controls.Add(this.lbl_tipo);
            this.tab_efectivo.Controls.Add(this.cmb_tipo1);
            this.tab_efectivo.Controls.Add(this.lbl_montot);
            this.tab_efectivo.Controls.Add(this.cmb_pin1);
            this.tab_efectivo.Location = new System.Drawing.Point(4, 22);
            this.tab_efectivo.Name = "tab_efectivo";
            this.tab_efectivo.Padding = new System.Windows.Forms.Padding(3);
            this.tab_efectivo.Size = new System.Drawing.Size(376, 171);
            this.tab_efectivo.TabIndex = 0;
            this.tab_efectivo.Text = "Efectivo/Crédito";
            // 
            // txt_efectivo
            // 
            this.txt_efectivo.BackColor = System.Drawing.Color.White;
            this.txt_efectivo.Font = new System.Drawing.Font("Maiandra GD", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_efectivo.Location = new System.Drawing.Point(93, 15);
            this.txt_efectivo.Name = "txt_efectivo";
            this.txt_efectivo.Size = new System.Drawing.Size(243, 22);
            this.txt_efectivo.TabIndex = 0;
            this.txt_efectivo.Text = "0";
            // 
            // txt_numerot1
            // 
            this.txt_numerot1.BackColor = System.Drawing.Color.White;
            this.txt_numerot1.Font = new System.Drawing.Font("Maiandra GD", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_numerot1.Location = new System.Drawing.Point(93, 43);
            this.txt_numerot1.MaxLength = 16;
            this.txt_numerot1.Name = "txt_numerot1";
            this.txt_numerot1.Size = new System.Drawing.Size(243, 22);
            this.txt_numerot1.TabIndex = 1;
            // 
            // txt_montot1
            // 
            this.txt_montot1.BackColor = System.Drawing.Color.White;
            this.txt_montot1.Font = new System.Drawing.Font("Maiandra GD", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_montot1.Location = new System.Drawing.Point(93, 70);
            this.txt_montot1.Name = "txt_montot1";
            this.txt_montot1.Size = new System.Drawing.Size(243, 22);
            this.txt_montot1.TabIndex = 2;
            this.txt_montot1.Text = "0";
            // 
            // lbl_efectivo
            // 
            this.lbl_efectivo.AutoSize = true;
            this.lbl_efectivo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_efectivo.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl_efectivo.Location = new System.Drawing.Point(35, 20);
            this.lbl_efectivo.Name = "lbl_efectivo";
            this.lbl_efectivo.Size = new System.Drawing.Size(55, 13);
            this.lbl_efectivo.TabIndex = 36;
            this.lbl_efectivo.Text = "Efectivo:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label23.Location = new System.Drawing.Point(61, 103);
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
            this.lbl_ntarjeta.Location = new System.Drawing.Point(19, 48);
            this.lbl_ntarjeta.Name = "lbl_ntarjeta";
            this.lbl_ntarjeta.Size = new System.Drawing.Size(71, 13);
            this.lbl_ntarjeta.TabIndex = 31;
            this.lbl_ntarjeta.Text = "N°. Tarjeta:";
            // 
            // lbl_tipo
            // 
            this.lbl_tipo.AutoSize = true;
            this.lbl_tipo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tipo.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl_tipo.Location = new System.Drawing.Point(56, 132);
            this.lbl_tipo.Name = "lbl_tipo";
            this.lbl_tipo.Size = new System.Drawing.Size(34, 13);
            this.lbl_tipo.TabIndex = 32;
            this.lbl_tipo.Text = "Tipo:";
            // 
            // cmb_tipo1
            // 
            this.cmb_tipo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_tipo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_tipo1.FormattingEnabled = true;
            this.cmb_tipo1.Location = new System.Drawing.Point(93, 127);
            this.cmb_tipo1.Name = "cmb_tipo1";
            this.cmb_tipo1.Size = new System.Drawing.Size(243, 23);
            this.cmb_tipo1.TabIndex = 4;
            // 
            // lbl_montot
            // 
            this.lbl_montot.AutoSize = true;
            this.lbl_montot.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_montot.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl_montot.Location = new System.Drawing.Point(44, 75);
            this.lbl_montot.Name = "lbl_montot";
            this.lbl_montot.Size = new System.Drawing.Size(46, 13);
            this.lbl_montot.TabIndex = 34;
            this.lbl_montot.Text = "Monto:";
            // 
            // cmb_pin1
            // 
            this.cmb_pin1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_pin1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_pin1.FormattingEnabled = true;
            this.cmb_pin1.Location = new System.Drawing.Point(93, 98);
            this.cmb_pin1.Name = "cmb_pin1";
            this.cmb_pin1.Size = new System.Drawing.Size(243, 23);
            this.cmb_pin1.TabIndex = 3;
            // 
            // tco_formaPago
            // 
            this.tco_formaPago.Controls.Add(this.tab_efectivo);
            this.tco_formaPago.Controls.Add(this.tab_cheque);
            this.tco_formaPago.Controls.Add(this.tab_retencion);
            this.tco_formaPago.Controls.Add(this.tab_notaCredito);
            this.tco_formaPago.Dock = System.Windows.Forms.DockStyle.Top;
            this.tco_formaPago.Location = new System.Drawing.Point(0, 0);
            this.tco_formaPago.Name = "tco_formaPago";
            this.tco_formaPago.SelectedIndex = 0;
            this.tco_formaPago.Size = new System.Drawing.Size(384, 197);
            this.tco_formaPago.TabIndex = 2;
            this.tco_formaPago.SelectedIndexChanged += new System.EventHandler(this.tco_formaPago_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(184, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 3;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(265, 203);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 34);
            this.button2.TabIndex = 4;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frm_abono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 250);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tco_formaPago);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_abono";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Abono";
            this.Load += new System.EventHandler(this.frm_abono_Load);
            this.tab_notaCredito.ResumeLayout(false);
            this.tab_notaCredito.PerformLayout();
            this.tab_retencion.ResumeLayout(false);
            this.tab_retencion.PerformLayout();
            this.tab_cheque.ResumeLayout(false);
            this.tab_cheque.PerformLayout();
            this.tab_efectivo.ResumeLayout(false);
            this.tab_efectivo.PerformLayout();
            this.tco_formaPago.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tab_notaCredito;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txt_montoNota;
        private System.Windows.Forms.TextBox txt_numeroNota;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TabPage tab_retencion;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txt_retencion;
        private System.Windows.Forms.TextBox txt_numeroRetencion;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TabPage tab_cheque;
        private System.Windows.Forms.Label lbl_ncheque;
        private System.Windows.Forms.TextBox txt_montoc;
        private System.Windows.Forms.TextBox txt_numeroc;
        private System.Windows.Forms.TextBox txt_banco;
        private System.Windows.Forms.Label lbl_montoc;
        private System.Windows.Forms.Label lbl_banco;
        private System.Windows.Forms.TabPage tab_efectivo;
        private System.Windows.Forms.TextBox txt_efectivo;
        private System.Windows.Forms.TextBox txt_numerot1;
        private System.Windows.Forms.TextBox txt_montot1;
        private System.Windows.Forms.Label lbl_efectivo;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lbl_ntarjeta;
        private System.Windows.Forms.Label lbl_tipo;
        private System.Windows.Forms.ComboBox cmb_tipo1;
        private System.Windows.Forms.Label lbl_montot;
        private System.Windows.Forms.ComboBox cmb_pin1;
        private System.Windows.Forms.TabControl tco_formaPago;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}