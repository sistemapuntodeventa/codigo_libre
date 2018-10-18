using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Pos.Coneccion;
using Pos.Clases;

namespace Pos.App
{
    public partial class frm_buscarProducto : Form
    {
              
        public DataGridViewRow fila;
        public bool stock;
        public int nRegistros;

        public frm_buscarProducto(bool data, DataGridViewRow fila)
        {
            InitializeComponent();
            this.fila = fila;
            this.stock = data;
        }

   
        private void grw_cliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string codigo = this.grw_productos["Código", e.RowIndex].Value.ToString();
                this.fila.Cells["codigo"].Value = codigo;
                //frm_factura form = (frm_factura)this.Owner;
                //form.buscarProducto(codigo, string.Empty, this.fila.Index);
                this.Close();
            }
        }

        private void frm_buscarProducto_Load(object sender, EventArgs e)
        {
            this.nRegistros = ParametroTR.consultarIntXNombre("listadoProductos");
            if (this.nRegistros != -1) this.cmb_registros.SelectedItem = this.nRegistros.ToString();
            else this.cmb_registros.SelectedItem = "TODOS";
            
            //this.grw_productos.KeyPress += OnDataGirdView1_KeyPress;
            this.llenarGrid("", "");
            this.txt_nombre.Select();
        }

        

        private void OnDataGirdView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }


        protected void llenarGrid(string codigo, string nombre)
        {
            this.grw_productos.DataBindings.Clear();
            grw_productos.Columns.Clear();
            string mensaje = "";
            ProductoTR tran = new ProductoTR();
            int registros = (this.cmb_registros.Text != "TODOS") ? Convert.ToInt32(this.cmb_registros.Text) : -1;
            DataTable datos = tran.consultarProductos(ref mensaje, codigo, nombre, stock,registros);
            if (datos != null)
            {
                this.grw_productos.DataSource = datos;
                this.grw_productos.Columns[0].Visible = false;
                this.grw_productos.Columns[5].Visible = false;
                int ancho = this.grw_productos.Width;
                this.grw_productos.Columns[1].Width = Convert.ToInt16(ancho * 0.24);
                this.grw_productos.Columns[2].Width = Convert.ToInt16(ancho * 0.40);
                this.grw_productos.Columns[3].Width = Convert.ToInt16(ancho * 0.12);
                this.grw_productos.Columns[4].Width = Convert.ToInt16(ancho * 0.12);
                //this.grw_productos.Columns[5].Width = Convert.ToInt16(ancho * 0.15);
                this.grw_productos.Columns[6].Width = Convert.ToInt16(ancho * 0.12);
                if(this.grw_productos.Rows.Count > 0)this.grw_productos.Rows[0].Cells[1].Selected = true;

            }
            else Mensaje.error(mensaje);
        }

        private void txt_codigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape || e.KeyData == Keys.Up || e.KeyData == Keys.Down || e.KeyData == Keys.Enter)
            {
                this.moverFilaActiva(sender, e);
                return;
            }
            
            this.llenarGrid(txt_codigo.Text, txt_nombre.Text);
        }


        private void moverFilaActiva(object sender, KeyEventArgs e)
        {

           // if (e.KeyData!= Keys.Enter && e.KeyData != Keys.Down && e.KeyData != Keys.Up && e.KeyData != Keys.Escape) return;
            if (this.grw_productos.RowCount < 1) return;
            if (e.KeyData == Keys.Escape) this.Close();
            int fila = this.grw_productos.CurrentRow.Index;
            if (e.KeyData == Keys.Down)
            {
                if(this.grw_productos.Rows.Count > (fila + 1))
                this.grw_productos.Rows[fila + 1].Cells[1].Selected = true;
            }
            else if (e.KeyData == Keys.Up)
            {
                if((fila -1) >= 0)
                this.grw_productos.Rows[fila - 1].Cells[1].Selected = true;
            }
            else if (e.KeyData == Keys.Enter)
            {
                string codigo = this.grw_productos.CurrentRow.Cells["Código"].Value.ToString();
                this.fila.Cells["codigo"].Value = codigo;
                this.Close();
            }
        }

        private void grw_productos_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                int fila = this.grw_productos.CurrentCell.RowIndex;
                string codigo = this.grw_productos["Código", fila].Value.ToString();
                this.fila.Cells["codigo"].Value = codigo;
                //frm_factura form = (frm_factura)this.Owner;
                //form.buscarProducto(codigo, string.Empty, this.fila.Index);
                this.Close();
            }
        }

        private void frm_buscarProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            int nuevoValor = (this.cmb_registros.Text != "TODOS") ? Convert.ToInt32(this.cmb_registros.Text) : -1;
            if (this.nRegistros != nuevoValor) ParametroTR.actualizarParametroEntero("listadoProductos", nuevoValor);
        }

        private void cmb_registros_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.llenarGrid(this.txt_codigo.Text, this.txt_nombre.Text);
            this.txt_nombre.Select();
        }


    }
}
