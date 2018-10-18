namespace Pos.App
{
    partial class frm_permisos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_permisos));
            this.iconoNotificacion = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.aPropina = new System.Windows.Forms.CheckBox();
            this.aNotaCredito = new System.Windows.Forms.CheckBox();
            this.aDescuento = new System.Windows.Forms.CheckBox();
            this.aDna = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cPropina = new System.Windows.Forms.CheckBox();
            this.cNotaCredito = new System.Windows.Forms.CheckBox();
            this.cDescuento = new System.Windows.Forms.CheckBox();
            this.cDna = new System.Windows.Forms.CheckBox();
            this.aSeleccionarVendedor = new System.Windows.Forms.CheckBox();
            this.aVueltoCheque = new System.Windows.Forms.CheckBox();
            this.aVueltoCredito = new System.Windows.Forms.CheckBox();
            this.cSeleccionarVendedor = new System.Windows.Forms.CheckBox();
            this.cVueltoCheque = new System.Windows.Forms.CheckBox();
            this.cVueltoCredito = new System.Windows.Forms.CheckBox();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.aAnularFactura = new System.Windows.Forms.CheckBox();
            this.cAnularFactura = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // iconoNotificacion
            // 
            this.iconoNotificacion.Text = "notifyIcon1";
            this.iconoNotificacion.Visible = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(284, 173);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.aAnularFactura);
            this.tabPage1.Controls.Add(this.aPropina);
            this.tabPage1.Controls.Add(this.aNotaCredito);
            this.tabPage1.Controls.Add(this.aDescuento);
            this.tabPage1.Controls.Add(this.aDna);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(276, 145);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Administrador";
            // 
            // aPropina
            // 
            this.aPropina.AutoSize = true;
            this.aPropina.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aPropina.Location = new System.Drawing.Point(25, 86);
            this.aPropina.Name = "aPropina";
            this.aPropina.Size = new System.Drawing.Size(69, 19);
            this.aPropina.TabIndex = 5;
            this.aPropina.Text = "Propina";
            this.aPropina.UseVisualStyleBackColor = true;
            // 
            // aNotaCredito
            // 
            this.aNotaCredito.AutoSize = true;
            this.aNotaCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aNotaCredito.Location = new System.Drawing.Point(25, 61);
            this.aNotaCredito.Name = "aNotaCredito";
            this.aNotaCredito.Size = new System.Drawing.Size(111, 19);
            this.aNotaCredito.TabIndex = 4;
            this.aNotaCredito.Text = "Nota de Crédito";
            this.aNotaCredito.UseVisualStyleBackColor = true;
            // 
            // aDescuento
            // 
            this.aDescuento.AutoSize = true;
            this.aDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aDescuento.Location = new System.Drawing.Point(25, 36);
            this.aDescuento.Name = "aDescuento";
            this.aDescuento.Size = new System.Drawing.Size(85, 19);
            this.aDescuento.TabIndex = 1;
            this.aDescuento.Text = "Descuento";
            this.aDescuento.UseVisualStyleBackColor = true;
            // 
            // aDna
            // 
            this.aDna.AutoSize = true;
            this.aDna.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aDna.Location = new System.Drawing.Point(25, 13);
            this.aDna.Name = "aDna";
            this.aDna.Size = new System.Drawing.Size(51, 19);
            this.aDna.TabIndex = 0;
            this.aDna.Text = "DNA";
            this.aDna.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.cAnularFactura);
            this.tabPage2.Controls.Add(this.cPropina);
            this.tabPage2.Controls.Add(this.cNotaCredito);
            this.tabPage2.Controls.Add(this.cDescuento);
            this.tabPage2.Controls.Add(this.cDna);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(276, 145);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cajero";
            // 
            // cPropina
            // 
            this.cPropina.AutoSize = true;
            this.cPropina.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cPropina.Location = new System.Drawing.Point(25, 86);
            this.cPropina.Name = "cPropina";
            this.cPropina.Size = new System.Drawing.Size(69, 19);
            this.cPropina.TabIndex = 10;
            this.cPropina.Text = "Propina";
            this.cPropina.UseVisualStyleBackColor = true;
            // 
            // cNotaCredito
            // 
            this.cNotaCredito.AutoSize = true;
            this.cNotaCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cNotaCredito.Location = new System.Drawing.Point(25, 61);
            this.cNotaCredito.Name = "cNotaCredito";
            this.cNotaCredito.Size = new System.Drawing.Size(111, 19);
            this.cNotaCredito.TabIndex = 9;
            this.cNotaCredito.Text = "Nota de Crédito";
            this.cNotaCredito.UseVisualStyleBackColor = true;
            // 
            // cDescuento
            // 
            this.cDescuento.AutoSize = true;
            this.cDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cDescuento.Location = new System.Drawing.Point(25, 36);
            this.cDescuento.Name = "cDescuento";
            this.cDescuento.Size = new System.Drawing.Size(85, 19);
            this.cDescuento.TabIndex = 6;
            this.cDescuento.Text = "Descuento";
            this.cDescuento.UseVisualStyleBackColor = true;
            // 
            // cDna
            // 
            this.cDna.AutoSize = true;
            this.cDna.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cDna.Location = new System.Drawing.Point(25, 13);
            this.cDna.Name = "cDna";
            this.cDna.Size = new System.Drawing.Size(51, 19);
            this.cDna.TabIndex = 5;
            this.cDna.Text = "DNA";
            this.cDna.UseVisualStyleBackColor = true;
            // 
            // aSeleccionarVendedor
            // 
            this.aSeleccionarVendedor.AutoSize = true;
            this.aSeleccionarVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aSeleccionarVendedor.Location = new System.Drawing.Point(29, 296);
            this.aSeleccionarVendedor.Name = "aSeleccionarVendedor";
            this.aSeleccionarVendedor.Size = new System.Drawing.Size(147, 19);
            this.aSeleccionarVendedor.TabIndex = 5;
            this.aSeleccionarVendedor.Text = "Seleccionar Vendedor";
            this.aSeleccionarVendedor.UseVisualStyleBackColor = true;
            // 
            // aVueltoCheque
            // 
            this.aVueltoCheque.AutoSize = true;
            this.aVueltoCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aVueltoCheque.Location = new System.Drawing.Point(29, 271);
            this.aVueltoCheque.Name = "aVueltoCheque";
            this.aVueltoCheque.Size = new System.Drawing.Size(123, 19);
            this.aVueltoCheque.TabIndex = 3;
            this.aVueltoCheque.Text = "Vuelto en Cheque";
            this.aVueltoCheque.UseVisualStyleBackColor = true;
            // 
            // aVueltoCredito
            // 
            this.aVueltoCredito.AutoSize = true;
            this.aVueltoCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aVueltoCredito.Location = new System.Drawing.Point(29, 248);
            this.aVueltoCredito.Name = "aVueltoCredito";
            this.aVueltoCredito.Size = new System.Drawing.Size(177, 19);
            this.aVueltoCredito.TabIndex = 2;
            this.aVueltoCredito.Text = "Vuelto en Tarjeta de Crédito";
            this.aVueltoCredito.UseVisualStyleBackColor = true;
            this.aVueltoCredito.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // cSeleccionarVendedor
            // 
            this.cSeleccionarVendedor.AutoSize = true;
            this.cSeleccionarVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cSeleccionarVendedor.Location = new System.Drawing.Point(29, 369);
            this.cSeleccionarVendedor.Name = "cSeleccionarVendedor";
            this.cSeleccionarVendedor.Size = new System.Drawing.Size(147, 19);
            this.cSeleccionarVendedor.TabIndex = 10;
            this.cSeleccionarVendedor.Text = "Seleccionar Vendedor";
            this.cSeleccionarVendedor.UseVisualStyleBackColor = true;
            // 
            // cVueltoCheque
            // 
            this.cVueltoCheque.AutoSize = true;
            this.cVueltoCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cVueltoCheque.Location = new System.Drawing.Point(29, 344);
            this.cVueltoCheque.Name = "cVueltoCheque";
            this.cVueltoCheque.Size = new System.Drawing.Size(123, 19);
            this.cVueltoCheque.TabIndex = 8;
            this.cVueltoCheque.Text = "Vuelto en Cheque";
            this.cVueltoCheque.UseVisualStyleBackColor = true;
            // 
            // cVueltoCredito
            // 
            this.cVueltoCredito.AutoSize = true;
            this.cVueltoCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cVueltoCredito.Location = new System.Drawing.Point(29, 321);
            this.cVueltoCredito.Name = "cVueltoCredito";
            this.cVueltoCredito.Size = new System.Drawing.Size(177, 19);
            this.cVueltoCredito.TabIndex = 7;
            this.cVueltoCredito.Text = "Vuelto en Tarjeta de Crédito";
            this.cVueltoCredito.UseVisualStyleBackColor = true;
            // 
            // btn_guardar
            // 
            this.btn_guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.btn_guardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btn_guardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(110)))), ((int)(((byte)(189)))));
            this.btn_guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_guardar.Image")));
            this.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_guardar.Location = new System.Drawing.Point(45, 180);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(92, 46);
            this.btn_guardar.TabIndex = 9;
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
            this.btn_salir.Location = new System.Drawing.Point(143, 181);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.btn_salir.Size = new System.Drawing.Size(92, 46);
            this.btn_salir.TabIndex = 11;
            this.btn_salir.Text = "Cerrar";
            this.btn_salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_salir.UseVisualStyleBackColor = false;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // aAnularFactura
            // 
            this.aAnularFactura.AutoSize = true;
            this.aAnularFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aAnularFactura.Location = new System.Drawing.Point(25, 111);
            this.aAnularFactura.Name = "aAnularFactura";
            this.aAnularFactura.Size = new System.Drawing.Size(105, 19);
            this.aAnularFactura.TabIndex = 6;
            this.aAnularFactura.Text = "Anular Factura";
            this.aAnularFactura.UseVisualStyleBackColor = true;
            // 
            // cAnularFactura
            // 
            this.cAnularFactura.AutoSize = true;
            this.cAnularFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cAnularFactura.Location = new System.Drawing.Point(25, 111);
            this.cAnularFactura.Name = "cAnularFactura";
            this.cAnularFactura.Size = new System.Drawing.Size(105, 19);
            this.cAnularFactura.TabIndex = 11;
            this.cAnularFactura.Text = "Anular Factura";
            this.cAnularFactura.UseVisualStyleBackColor = true;
            // 
            // frm_permisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 240);
            this.Controls.Add(this.cSeleccionarVendedor);
            this.Controls.Add(this.aSeleccionarVendedor);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.cVueltoCheque);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.cVueltoCredito);
            this.Controls.Add(this.aVueltoCheque);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.aVueltoCredito);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_permisos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Permisos";
            this.Load += new System.EventHandler(this.frm_permisos_Load);
            this.Click += new System.EventHandler(this.frm_permisos_Click);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon iconoNotificacion;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox aVueltoCheque;
        private System.Windows.Forms.CheckBox aVueltoCredito;
        private System.Windows.Forms.CheckBox aDescuento;
        private System.Windows.Forms.CheckBox aDna;
        private System.Windows.Forms.CheckBox aNotaCredito;
        private System.Windows.Forms.CheckBox cNotaCredito;
        private System.Windows.Forms.CheckBox cVueltoCheque;
        private System.Windows.Forms.CheckBox cVueltoCredito;
        private System.Windows.Forms.CheckBox cDescuento;
        private System.Windows.Forms.CheckBox cDna;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.CheckBox aSeleccionarVendedor;
        private System.Windows.Forms.CheckBox cSeleccionarVendedor;
        private System.Windows.Forms.CheckBox aPropina;
        private System.Windows.Forms.CheckBox cPropina;
        private System.Windows.Forms.CheckBox aAnularFactura;
        private System.Windows.Forms.CheckBox cAnularFactura;
    }
}