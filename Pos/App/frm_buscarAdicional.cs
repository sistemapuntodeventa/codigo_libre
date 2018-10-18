using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pos.Coneccion;
using Pos.Clases;

namespace Pos.App
{
    public partial class frm_buscarAdicional : Form
    {
        private int idAdicional;

        public frm_buscarAdicional()
        {
            InitializeComponent();
        }

        public frm_buscarAdicional(int idAdicional)
        {
            InitializeComponent();
            this.idAdicional = idAdicional;
        }

        private void frm_buscarAdicional_Load(object sender, EventArgs e)
        {
            this.llenarGrid("");
        }

        protected void llenarGrid(string nombre)
        {
            this.grw_datos.DataBindings.Clear();
            grw_datos.Columns.Clear();
            string mensaje = "";
            AdicionalTR tran = new AdicionalTR();
            DataTable datos = tran.cargarListado(ref mensaje, idAdicional, nombre);
            if (datos != null)
            {
                this.grw_datos.DataSource = datos;
                int ancho = this.grw_datos.Width - 5;
                this.grw_datos.Columns[0].Width = Convert.ToInt16(ancho); 
                //this.grw_datos.Columns[1].Width = Convert.ToInt16(ancho * 0.25);
                //this.grw_datos.Columns[1].HeaderText = "Código";
             //   this.grw_datos.Columns[2].Width = Convert.ToInt16(ancho * 0.75);
             //   this.grw_datos.Columns[2].HeaderText = "Valor";
            }
            else Mensaje.error(mensaje);

        }

        private void txt_nombre_KeyUp(object sender, KeyEventArgs e)
        {
            this.llenarGrid(this.txt_nombre.Text);
        }

        private void grw_datos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frm_factura form = (frm_factura)this.Owner;
            string texto = this.grw_datos["texto", e.RowIndex].Value.ToString();
            form.setValorAdicional(this.idAdicional,texto);
            this.Close();
        }

    }
}
