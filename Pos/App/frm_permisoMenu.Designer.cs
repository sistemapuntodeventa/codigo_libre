namespace Pos.App
{
    partial class frm_permisoMenu
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
            this.trv_menu = new System.Windows.Forms.TreeView();
            this.lbl_item = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // trv_menu
            // 
            this.trv_menu.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trv_menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.trv_menu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trv_menu.Location = new System.Drawing.Point(0, 0);
            this.trv_menu.Name = "trv_menu";
            this.trv_menu.Size = new System.Drawing.Size(199, 283);
            this.trv_menu.TabIndex = 0;
            this.trv_menu.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.trv_menu_BeforeSelect);
            this.trv_menu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trv_menu_AfterSelect);
            // 
            // lbl_item
            // 
            this.lbl_item.AutoSize = true;
            this.lbl_item.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_item.Location = new System.Drawing.Point(205, 9);
            this.lbl_item.Name = "lbl_item";
            this.lbl_item.Size = new System.Drawing.Size(51, 20);
            this.lbl_item.TabIndex = 1;
            this.lbl_item.Text = "label1";
            // 
            // frm_permisoMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 283);
            this.Controls.Add(this.lbl_item);
            this.Controls.Add(this.trv_menu);
            this.Name = "frm_permisoMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Permisos Menú";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_permisoMenu_FormClosing);
            this.Load += new System.EventHandler(this.frm_permisoMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView trv_menu;
        private System.Windows.Forms.Label lbl_item;
    }
}