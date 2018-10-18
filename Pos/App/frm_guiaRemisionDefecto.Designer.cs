namespace Pos.App
{
    partial class frm_guiaRemisionDefecto
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
            this.cbl_motivos = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_placaEncargado = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_puntoPartida = new System.Windows.Forms.TextBox();
            this.txt_cedulaEncargado = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_nombreEncargado = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_ciudadPartida = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbl_motivos
            // 
            this.cbl_motivos.CheckOnClick = true;
            this.cbl_motivos.ColumnWidth = 320;
            this.cbl_motivos.FormattingEnabled = true;
            this.cbl_motivos.Items.AddRange(new object[] {
            "Venta",
            "Compra",
            "Transformación",
            "Consignación",
            "Traslado entre establecimientos de la misma empresa",
            "Traslado por emisor itienerante de comprobantes de venta",
            "Devolución",
            "Importación",
            "Exportación",
            "Otros"});
            this.cbl_motivos.Location = new System.Drawing.Point(12, 33);
            this.cbl_motivos.MultiColumn = true;
            this.cbl_motivos.Name = "cbl_motivos";
            this.cbl_motivos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbl_motivos.Size = new System.Drawing.Size(660, 79);
            this.cbl_motivos.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Punto de partida:";
            // 
            // txt_placaEncargado
            // 
            this.txt_placaEncargado.Location = new System.Drawing.Point(490, 202);
            this.txt_placaEncargado.Name = "txt_placaEncargado";
            this.txt_placaEncargado.Size = new System.Drawing.Size(140, 20);
            this.txt_placaEncargado.TabIndex = 33;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(454, 206);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "Placa:";
            // 
            // txt_puntoPartida
            // 
            this.txt_puntoPartida.Location = new System.Drawing.Point(140, 122);
            this.txt_puntoPartida.Name = "txt_puntoPartida";
            this.txt_puntoPartida.Size = new System.Drawing.Size(302, 20);
            this.txt_puntoPartida.TabIndex = 24;
            // 
            // txt_cedulaEncargado
            // 
            this.txt_cedulaEncargado.Location = new System.Drawing.Point(140, 202);
            this.txt_cedulaEncargado.Name = "txt_cedulaEncargado";
            this.txt_cedulaEncargado.Size = new System.Drawing.Size(302, 20);
            this.txt_cedulaEncargado.TabIndex = 31;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(74, 206);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "R.U.C/C.I.:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(448, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Ciudad:";
            // 
            // txt_nombreEncargado
            // 
            this.txt_nombreEncargado.Location = new System.Drawing.Point(140, 176);
            this.txt_nombreEncargado.Name = "txt_nombreEncargado";
            this.txt_nombreEncargado.Size = new System.Drawing.Size(490, 20);
            this.txt_nombreEncargado.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Nombre o Razón Social:";
            // 
            // txt_ciudadPartida
            // 
            this.txt_ciudadPartida.Location = new System.Drawing.Point(490, 122);
            this.txt_ciudadPartida.Name = "txt_ciudadPartida";
            this.txt_ciudadPartida.Size = new System.Drawing.Size(140, 20);
            this.txt_ciudadPartida.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(405, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "IDENTIFICACIÓN DE LA PERSONA ENCARGADA DEL TRANSPORTE";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(10, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(153, 13);
            this.label12.TabIndex = 34;
            this.label12.Text = "MOTIVO DEL TRASLADO";
            // 
            // frm_guiaRemisionDefecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 240);
            this.Controls.Add(this.cbl_motivos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_placaEncargado);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_puntoPartida);
            this.Controls.Add(this.txt_cedulaEncargado);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_nombreEncargado);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_ciudadPartida);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label12);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frm_guiaRemisionDefecto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Valores por Defecto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_guiaRemisionDefecto_FormClosing);
            this.Load += new System.EventHandler(this.frm_guiaRemisionDefecto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox cbl_motivos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_placaEncargado;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_puntoPartida;
        private System.Windows.Forms.TextBox txt_cedulaEncargado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_nombreEncargado;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_ciudadPartida;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
    }
}