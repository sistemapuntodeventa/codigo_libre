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
    public partial class frm_promocionProducto : Form
    {
        private int categoriaAnterior = -1;

        public frm_promocionProducto()
        {
            InitializeComponent();
        }

        private void frm_promocionProducto_Load(object sender, EventArgs e)
        {
            this.cmb_categoria.SelectedIndexChanged -= cmb_categoria_SelectedIndexChanged;
            this.llenarCategoria();
            //this.llenarGrid();
            this.cmb_categoria.SelectedIndexChanged += cmb_categoria_SelectedIndexChanged;
        }

        protected void llenarCategoria()
        {
            //PromocionTR pro = new PromocionTR();
            string msn = "";
            DataTable datos = PromocionTR.consultarCategorias(ref msn);
            if (datos != null)
            {
                DataRow fila = datos.NewRow();
                fila["nombre"] = "TODOS";
                datos.Rows.InsertAt(fila, 0);

                this.cmb_categoria.DataSource = datos;
                this.cmb_categoria.ValueMember = "id";
                this.cmb_categoria.DisplayMember = "nombre";
                this.cmb_categoria.SelectedIndex = -1;
            }
            else Mensaje.error(msn);
        }

        protected void llenarGrid()
        {
            this.grw_productos.DataBindings.Clear();
            grw_productos.Columns.Clear();
            string mensaje = "";
            int idCategoria = (this.cmb_categoria.SelectedValue == null || this.cmb_categoria.SelectedIndex == 0) ? -1 : Convert.ToInt32(this.cmb_categoria.SelectedValue);
            DataTable datos = PromocionTR.productosDisponibles(idCategoria);
            if (datos != null)
            {
                //DataTable temp = datos.Clone();
                //temp.Columns["elegido"].DataType = typeof(bool);
                datos.Columns.Add("elegido", typeof(bool)).SetOrdinal(1);
                foreach (DataRow fila in datos.Rows) fila["elegido"] = (Convert.ToBoolean(fila["temp"]));
                


                this.grw_productos.DataSource = datos;
                this.grw_productos.Columns["id"].Visible = false;
                this.grw_productos.Columns["elegido"].HeaderText = "";
                this.grw_productos.Columns["categoria"].Visible = false;
                this.grw_productos.Columns["temp"].Visible = false;
                int ancho = this.grw_productos.Width;
                this.grw_productos.Columns["elegido"].Width = Convert.ToInt16(ancho * 0.10);
                this.grw_productos.Columns["codigo"].Width = Convert.ToInt16(ancho * 0.15);
                this.grw_productos.Columns["nombre"].Width = Convert.ToInt16(ancho * 0.25);
                this.grw_productos.Columns["descripcion"].Width = Convert.ToInt16(ancho * 0.50);

                
                /* ----------------------------------- */
                //this.grw_productos.Columns[4].Width = Convert.ToInt16(ancho * 0.45);
                //this.grw_productos.Columns[5].Width = Convert.ToInt16(ancho * 0.15);
                //if (this.grw_productos.Rows.Count > 0) this.grw_productos.Rows[0].Cells[1].Selected = true;
            }
            else Mensaje.error(mensaje);
        }

        private void cmb_categoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<int[]> datos = new List<int[]>();
                foreach (DataGridViewRow fila in this.grw_productos.Rows)
                {
                    if (!String.IsNullOrEmpty(fila.Cells["elegido"].Value.ToString()) && Convert.ToBoolean(fila.Cells["elegido"].Value))
                    {
                        int[] producto = new int[2];
                        producto[0] = Convert.ToInt32(fila.Cells["id"].Value);
                        producto[1] = Convert.ToInt32(fila.Cells["categoria"].Value);
                        datos.Add(producto);
                    }
                }
                string mensaje = "";
                PromocionTR tran = new PromocionTR();
                tran.insertarProductos(ref mensaje, datos, 1,this.categoriaAnterior);
                this.categoriaAnterior = (this.cmb_categoria.SelectedIndex != 0) ? Convert.ToInt32(this.cmb_categoria.SelectedValue) : -1;
                this.llenarGrid();
            }
            catch (Exception error)
            {
                Mensaje.error(error.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow fila in this.grw_productos.Rows)fila.Cells["elegido"].Value = this.chk_todos.Checked;

        }
    }
}
