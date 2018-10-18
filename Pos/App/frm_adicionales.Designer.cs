namespace Pos.App
{
    partial class frm_adicionales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_adicionales));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chk_activo1 = new System.Windows.Forms.CheckBox();
            this.grw_items1 = new System.Windows.Forms.DataGridView();
            this.valor1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.botonEliminar1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txt_etiqueta1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_nombre1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_tipo1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chk_activo2 = new System.Windows.Forms.CheckBox();
            this.grw_items2 = new System.Windows.Forms.DataGridView();
            this.valor2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.botonEliminar2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txt_etiqueta2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_nombre2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_tipo2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.chk_requerido1 = new System.Windows.Forms.CheckBox();
            this.chk_mostrarListado1 = new System.Windows.Forms.CheckBox();
            this.chk_mostrarListado2 = new System.Windows.Forms.CheckBox();
            this.chk_requerido2 = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grw_items1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grw_items2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(432, 384);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.chk_mostrarListado1);
            this.tabPage1.Controls.Add(this.chk_requerido1);
            this.tabPage1.Controls.Add(this.chk_activo1);
            this.tabPage1.Controls.Add(this.grw_items1);
            this.tabPage1.Controls.Add(this.txt_etiqueta1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txt_nombre1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cmb_tipo1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(424, 358);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Adicional1";
            // 
            // chk_activo1
            // 
            this.chk_activo1.AutoSize = true;
            this.chk_activo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.chk_activo1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.chk_activo1.Location = new System.Drawing.Point(334, 9);
            this.chk_activo1.Name = "chk_activo1";
            this.chk_activo1.Size = new System.Drawing.Size(63, 19);
            this.chk_activo1.TabIndex = 7;
            this.chk_activo1.Text = "Activo";
            this.chk_activo1.UseVisualStyleBackColor = true;
            // 
            // grw_items1
            // 
            this.grw_items1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grw_items1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.valor1,
            this.botonEliminar1});
            this.grw_items1.Location = new System.Drawing.Point(16, 120);
            this.grw_items1.Name = "grw_items1";
            this.grw_items1.RowHeadersVisible = false;
            this.grw_items1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grw_items1.Size = new System.Drawing.Size(379, 161);
            this.grw_items1.TabIndex = 6;
            this.grw_items1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grw_items_CellContentClick);
            this.grw_items1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.grw_items_CellPainting);
            // 
            // valor1
            // 
            this.valor1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.valor1.HeaderText = "Valor";
            this.valor1.Name = "valor1";
            // 
            // botonEliminar1
            // 
            this.botonEliminar1.HeaderText = "";
            this.botonEliminar1.Name = "botonEliminar1";
            // 
            // txt_etiqueta1
            // 
            this.txt_etiqueta1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.txt_etiqueta1.Location = new System.Drawing.Point(103, 89);
            this.txt_etiqueta1.Name = "txt_etiqueta1";
            this.txt_etiqueta1.Size = new System.Drawing.Size(292, 21);
            this.txt_etiqueta1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label3.Location = new System.Drawing.Point(27, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Etiqueta:";
            // 
            // txt_nombre1
            // 
            this.txt_nombre1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.txt_nombre1.Location = new System.Drawing.Point(103, 63);
            this.txt_nombre1.Name = "txt_nombre1";
            this.txt_nombre1.Size = new System.Drawing.Size(292, 21);
            this.txt_nombre1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label2.Location = new System.Drawing.Point(29, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre:";
            // 
            // cmb_tipo1
            // 
            this.cmb_tipo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_tipo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmb_tipo1.FormattingEnabled = true;
            this.cmb_tipo1.Location = new System.Drawing.Point(103, 35);
            this.cmb_tipo1.Name = "cmb_tipo1";
            this.cmb_tipo1.Size = new System.Drawing.Size(292, 23);
            this.cmb_tipo1.TabIndex = 1;
            this.cmb_tipo1.SelectedIndexChanged += new System.EventHandler(this.cmb_tipo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label1.Location = new System.Drawing.Point(52, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.chk_mostrarListado2);
            this.tabPage2.Controls.Add(this.chk_requerido2);
            this.tabPage2.Controls.Add(this.chk_activo2);
            this.tabPage2.Controls.Add(this.grw_items2);
            this.tabPage2.Controls.Add(this.txt_etiqueta2);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txt_nombre2);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.cmb_tipo2);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(424, 358);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Adicional2";
            // 
            // chk_activo2
            // 
            this.chk_activo2.AutoSize = true;
            this.chk_activo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.chk_activo2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.chk_activo2.Location = new System.Drawing.Point(334, 9);
            this.chk_activo2.Name = "chk_activo2";
            this.chk_activo2.Size = new System.Drawing.Size(63, 19);
            this.chk_activo2.TabIndex = 15;
            this.chk_activo2.Text = "Activo";
            this.chk_activo2.UseVisualStyleBackColor = true;
            // 
            // grw_items2
            // 
            this.grw_items2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grw_items2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.valor2,
            this.botonEliminar2});
            this.grw_items2.Location = new System.Drawing.Point(16, 120);
            this.grw_items2.Name = "grw_items2";
            this.grw_items2.RowHeadersVisible = false;
            this.grw_items2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grw_items2.Size = new System.Drawing.Size(379, 161);
            this.grw_items2.TabIndex = 14;
            this.grw_items2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grw_items2_CellContentClick);
            this.grw_items2.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.grw_items2_CellPainting);
            // 
            // valor2
            // 
            this.valor2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.valor2.HeaderText = "Valor";
            this.valor2.Name = "valor2";
            // 
            // botonEliminar2
            // 
            this.botonEliminar2.HeaderText = "";
            this.botonEliminar2.Name = "botonEliminar2";
            // 
            // txt_etiqueta2
            // 
            this.txt_etiqueta2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.txt_etiqueta2.Location = new System.Drawing.Point(103, 89);
            this.txt_etiqueta2.Name = "txt_etiqueta2";
            this.txt_etiqueta2.Size = new System.Drawing.Size(292, 21);
            this.txt_etiqueta2.TabIndex = 13;
            this.txt_etiqueta2.TextChanged += new System.EventHandler(this.txt_etiqueta2_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label4.Location = new System.Drawing.Point(27, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Etiqueta:";
            // 
            // txt_nombre2
            // 
            this.txt_nombre2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.txt_nombre2.Location = new System.Drawing.Point(103, 63);
            this.txt_nombre2.Name = "txt_nombre2";
            this.txt_nombre2.Size = new System.Drawing.Size(292, 21);
            this.txt_nombre2.TabIndex = 11;
            this.txt_nombre2.TextChanged += new System.EventHandler(this.txt_nombre2_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label5.Location = new System.Drawing.Point(29, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Nombre:";
            // 
            // cmb_tipo2
            // 
            this.cmb_tipo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_tipo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.cmb_tipo2.FormattingEnabled = true;
            this.cmb_tipo2.Location = new System.Drawing.Point(103, 35);
            this.cmb_tipo2.Name = "cmb_tipo2";
            this.cmb_tipo2.Size = new System.Drawing.Size(292, 23);
            this.cmb_tipo2.TabIndex = 9;
            this.cmb_tipo2.SelectedIndexChanged += new System.EventHandler(this.cmb_tipo2_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(120)))), ((int)(((byte)(168)))));
            this.label6.Location = new System.Drawing.Point(52, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Tipo:";
            // 
            // btn_salir
            // 
            this.btn_salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.btn_salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btn_salir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(110)))), ((int)(((byte)(189)))));
            this.btn_salir.Image = global::Pos.Properties.Resources.cerrar;
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salir.Location = new System.Drawing.Point(208, 393);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.btn_salir.Size = new System.Drawing.Size(92, 46);
            this.btn_salir.TabIndex = 13;
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
            this.btn_guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_guardar.Image")));
            this.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_guardar.Location = new System.Drawing.Point(110, 392);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(92, 46);
            this.btn_guardar.TabIndex = 12;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_guardar.UseVisualStyleBackColor = false;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // chk_requerido1
            // 
            this.chk_requerido1.AutoSize = true;
            this.chk_requerido1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.chk_requerido1.Location = new System.Drawing.Point(16, 287);
            this.chk_requerido1.Name = "chk_requerido1";
            this.chk_requerido1.Size = new System.Drawing.Size(93, 19);
            this.chk_requerido1.TabIndex = 8;
            this.chk_requerido1.Text = "Requerido";
            this.chk_requerido1.UseVisualStyleBackColor = true;
            // 
            // chk_mostrarListado1
            // 
            this.chk_mostrarListado1.AutoSize = true;
            this.chk_mostrarListado1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.chk_mostrarListado1.Location = new System.Drawing.Point(16, 312);
            this.chk_mostrarListado1.Name = "chk_mostrarListado1";
            this.chk_mostrarListado1.Size = new System.Drawing.Size(163, 19);
            this.chk_mostrarListado1.TabIndex = 9;
            this.chk_mostrarListado1.Text = "Mostrar en Búsqueda";
            this.chk_mostrarListado1.UseVisualStyleBackColor = true;
            // 
            // chk_mostrarListado2
            // 
            this.chk_mostrarListado2.AutoSize = true;
            this.chk_mostrarListado2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.chk_mostrarListado2.Location = new System.Drawing.Point(16, 312);
            this.chk_mostrarListado2.Name = "chk_mostrarListado2";
            this.chk_mostrarListado2.Size = new System.Drawing.Size(163, 19);
            this.chk_mostrarListado2.TabIndex = 17;
            this.chk_mostrarListado2.Text = "Mostrar en Búsqueda";
            this.chk_mostrarListado2.UseVisualStyleBackColor = true;
            // 
            // chk_requerido2
            // 
            this.chk_requerido2.AutoSize = true;
            this.chk_requerido2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.chk_requerido2.Location = new System.Drawing.Point(16, 287);
            this.chk_requerido2.Name = "chk_requerido2";
            this.chk_requerido2.Size = new System.Drawing.Size(93, 19);
            this.chk_requerido2.TabIndex = 16;
            this.chk_requerido2.Text = "Requerido";
            this.chk_requerido2.UseVisualStyleBackColor = true;
            // 
            // frm_adicionales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 449);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.tabControl1);
            this.Name = "frm_adicionales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adicionales";
            this.Load += new System.EventHandler(this.frm_adicionales_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grw_items1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grw_items2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txt_etiqueta1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_nombre1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_tipo1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grw_items1;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.CheckBox chk_activo1;
        private System.Windows.Forms.CheckBox chk_activo2;
        private System.Windows.Forms.DataGridView grw_items2;
        private System.Windows.Forms.TextBox txt_etiqueta2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_nombre2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_tipo2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor1;
        private System.Windows.Forms.DataGridViewButtonColumn botonEliminar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor2;
        private System.Windows.Forms.DataGridViewButtonColumn botonEliminar2;
        private System.Windows.Forms.CheckBox chk_mostrarListado1;
        private System.Windows.Forms.CheckBox chk_requerido1;
        private System.Windows.Forms.CheckBox chk_mostrarListado2;
        private System.Windows.Forms.CheckBox chk_requerido2;
    }
}