namespace Pos.App
{
    partial class frm_menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_menu));
            this.menu_principal = new System.Windows.Forms.MenuStrip();
            this.tsm_editar = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flp_botones = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_caja = new System.Windows.Forms.Button();
            this.btn_facturar = new System.Windows.Forms.Button();
            this.btn_guia = new System.Windows.Forms.Button();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.sba_estado = new System.Windows.Forms.StatusStrip();
            this.tsl_estado = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuDerecho = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sincronizarProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sincronizarPersonasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_principal.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flp_botones.SuspendLayout();
            this.sba_estado.SuspendLayout();
            this.menuDerecho.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu_principal
            // 
            this.menu_principal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menu_principal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsm_editar});
            this.menu_principal.Location = new System.Drawing.Point(0, 0);
            this.menu_principal.Name = "menu_principal";
            this.menu_principal.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menu_principal.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menu_principal.Size = new System.Drawing.Size(1235, 24);
            this.menu_principal.TabIndex = 0;
            this.menu_principal.Text = "Menu Principal";
            // 
            // tsm_editar
            // 
            this.tsm_editar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsm_editar.Image = ((System.Drawing.Image)(resources.GetObject("tsm_editar.Image")));
            this.tsm_editar.Name = "tsm_editar";
            this.tsm_editar.Size = new System.Drawing.Size(28, 20);
            this.tsm_editar.Click += new System.EventHandler(this.tsm_editar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.flp_botones);
            this.panel1.Controls.Add(this.sba_estado);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 279);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1235, 199);
            this.panel1.TabIndex = 3;
            // 
            // flp_botones
            // 
            this.flp_botones.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flp_botones.Controls.Add(this.btn_caja);
            this.flp_botones.Controls.Add(this.btn_facturar);
            this.flp_botones.Controls.Add(this.btn_guia);
            this.flp_botones.Controls.Add(this.btn_cerrar);
            this.flp_botones.Controls.Add(this.btn_salir);
            this.flp_botones.Location = new System.Drawing.Point(376, 40);
            this.flp_botones.Name = "flp_botones";
            this.flp_botones.Size = new System.Drawing.Size(795, 102);
            this.flp_botones.TabIndex = 6;
            // 
            // btn_caja
            // 
            this.btn_caja.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_caja.AutoSize = true;
            this.btn_caja.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_caja.BackColor = System.Drawing.Color.White;
            this.btn_caja.FlatAppearance.BorderSize = 0;
            this.btn_caja.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_caja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(90)))), ((int)(((byte)(136)))));
            this.btn_caja.Image = global::Pos.Properties.Resources.lock_open;
            this.btn_caja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_caja.Location = new System.Drawing.Point(5, 4);
            this.btn_caja.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_caja.MaximumSize = new System.Drawing.Size(147, 92);
            this.btn_caja.MinimumSize = new System.Drawing.Size(147, 92);
            this.btn_caja.Name = "btn_caja";
            this.btn_caja.Size = new System.Drawing.Size(147, 92);
            this.btn_caja.TabIndex = 1;
            this.btn_caja.Text = "Abrir";
            this.btn_caja.UseVisualStyleBackColor = false;
            this.btn_caja.Click += new System.EventHandler(this.btn_caja_Click);
            // 
            // btn_facturar
            // 
            this.btn_facturar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_facturar.AutoSize = true;
            this.btn_facturar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_facturar.BackColor = System.Drawing.Color.White;
            this.btn_facturar.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_facturar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(90)))), ((int)(((byte)(136)))));
            this.btn_facturar.Image = global::Pos.Properties.Resources.pos;
            this.btn_facturar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_facturar.Location = new System.Drawing.Point(162, 4);
            this.btn_facturar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_facturar.MaximumSize = new System.Drawing.Size(147, 92);
            this.btn_facturar.MinimumSize = new System.Drawing.Size(147, 92);
            this.btn_facturar.Name = "btn_facturar";
            this.btn_facturar.Size = new System.Drawing.Size(147, 92);
            this.btn_facturar.TabIndex = 2;
            this.btn_facturar.Text = "Facturar";
            this.btn_facturar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_facturar.UseVisualStyleBackColor = false;
            this.btn_facturar.Click += new System.EventHandler(this.btn_factura_Click);
            // 
            // btn_guia
            // 
            this.btn_guia.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_guia.AutoSize = true;
            this.btn_guia.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_guia.BackColor = System.Drawing.Color.White;
            this.btn_guia.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_guia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(90)))), ((int)(((byte)(136)))));
            this.btn_guia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_guia.Location = new System.Drawing.Point(319, 4);
            this.btn_guia.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_guia.MaximumSize = new System.Drawing.Size(147, 92);
            this.btn_guia.MinimumSize = new System.Drawing.Size(147, 92);
            this.btn_guia.Name = "btn_guia";
            this.btn_guia.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btn_guia.Size = new System.Drawing.Size(147, 92);
            this.btn_guia.TabIndex = 5;
            this.btn_guia.Text = "Guía Remisión";
            this.btn_guia.UseVisualStyleBackColor = false;
            this.btn_guia.Visible = false;
            this.btn_guia.Click += new System.EventHandler(this.btn_guia_Click_1);
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_cerrar.AutoSize = true;
            this.btn_cerrar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_cerrar.BackColor = System.Drawing.Color.White;
            this.btn_cerrar.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cerrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(90)))), ((int)(((byte)(136)))));
            this.btn_cerrar.Image = global::Pos.Properties.Resources._lock;
            this.btn_cerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cerrar.Location = new System.Drawing.Point(476, 4);
            this.btn_cerrar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_cerrar.MaximumSize = new System.Drawing.Size(147, 92);
            this.btn_cerrar.MinimumSize = new System.Drawing.Size(147, 92);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btn_cerrar.Size = new System.Drawing.Size(147, 92);
            this.btn_cerrar.TabIndex = 3;
            this.btn_cerrar.Text = "Cerrar";
            this.btn_cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cerrar.UseVisualStyleBackColor = false;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click_1);
            // 
            // btn_salir
            // 
            this.btn_salir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_salir.AutoSize = true;
            this.btn_salir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_salir.BackColor = System.Drawing.Color.White;
            this.btn_salir.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_salir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(90)))), ((int)(((byte)(136)))));
            this.btn_salir.Image = global::Pos.Properties.Resources.salir;
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salir.Location = new System.Drawing.Point(633, 4);
            this.btn_salir.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_salir.MaximumSize = new System.Drawing.Size(147, 92);
            this.btn_salir.MinimumSize = new System.Drawing.Size(147, 92);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(147, 92);
            this.btn_salir.TabIndex = 4;
            this.btn_salir.Text = "Salir";
            this.btn_salir.UseVisualStyleBackColor = false;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // sba_estado
            // 
            this.sba_estado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsl_estado});
            this.sba_estado.Location = new System.Drawing.Point(0, 177);
            this.sba_estado.Name = "sba_estado";
            this.sba_estado.Size = new System.Drawing.Size(1235, 22);
            this.sba_estado.TabIndex = 5;
            this.sba_estado.Text = "Estado";
            this.sba_estado.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.sba_estado_ItemClicked);
            // 
            // tsl_estado
            // 
            this.tsl_estado.Name = "tsl_estado";
            this.tsl_estado.Size = new System.Drawing.Size(0, 17);
            // 
            // menuDerecho
            // 
            this.menuDerecho.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sincronizarProductosToolStripMenuItem,
            this.sincronizarPersonasToolStripMenuItem});
            this.menuDerecho.Name = "menuDerecho";
            this.menuDerecho.Size = new System.Drawing.Size(190, 48);
            // 
            // sincronizarProductosToolStripMenuItem
            // 
            this.sincronizarProductosToolStripMenuItem.Name = "sincronizarProductosToolStripMenuItem";
            this.sincronizarProductosToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.sincronizarProductosToolStripMenuItem.Text = "Sincronizar Productos";
            this.sincronizarProductosToolStripMenuItem.Click += new System.EventHandler(this.sincronizarProductosToolStripMenuItem_Click);
            // 
            // sincronizarPersonasToolStripMenuItem
            // 
            this.sincronizarPersonasToolStripMenuItem.Name = "sincronizarPersonasToolStripMenuItem";
            this.sincronizarPersonasToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.sincronizarPersonasToolStripMenuItem.Text = "Sincronizar Personas";
            this.sincronizarPersonasToolStripMenuItem.Click += new System.EventHandler(this.sincronizarPersonasToolStripMenuItem_Click);
            // 
            // frm_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1235, 478);
            this.ContextMenuStrip = this.menuDerecho;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menu_principal);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu_principal;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frm_menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Punto de Venta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_menu_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_menu_FormClosed);
            this.Load += new System.EventHandler(this.frm_menu_Load);
            this.menu_principal.ResumeLayout(false);
            this.menu_principal.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flp_botones.ResumeLayout(false);
            this.flp_botones.PerformLayout();
            this.sba_estado.ResumeLayout(false);
            this.sba_estado.PerformLayout();
            this.menuDerecho.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu_principal;
        private System.Windows.Forms.Button btn_caja;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.Button btn_facturar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.ToolStripMenuItem tsm_editar;
        private System.Windows.Forms.ContextMenuStrip menuDerecho;
        private System.Windows.Forms.ToolStripMenuItem sincronizarProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sincronizarPersonasToolStripMenuItem;
        private System.Windows.Forms.StatusStrip sba_estado;
        private System.Windows.Forms.ToolStripStatusLabel tsl_estado;
        private System.Windows.Forms.FlowLayoutPanel flp_botones;
        private System.Windows.Forms.Button btn_guia;
    }
}