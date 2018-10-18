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

namespace Pos
{
    public partial class frm_ubicacionProducto : Form
    {
        private bool hizoCambio = false;
        private int categoriaAnterior;
        private int idUbicacion = -1;
        List<int> ubicacionesTemporal = null;

        public frm_ubicacionProducto()
        {
            InitializeComponent();
            this.eliminarTemporal();
        }

        private void frm_ubicacionProducto_Load(object sender, EventArgs e)
        {
            this.ubicacionesTemporal = new List<int>();
            this.cmb_ubicacion.SelectedIndexChanged -= cmb_ubicacion_SelectedIndexChanged;
            this.cmb_categoria.SelectedIndexChanged -= cmb_categoria_SelectedIndexChanged_1;
            this.llenarCategoria();
            this.llenarUbicacion();
            this.estadoInicial();
            this.cmb_ubicacion.SelectedIndexChanged += cmb_ubicacion_SelectedIndexChanged;
            this.cmb_categoria.SelectedIndexChanged += cmb_categoria_SelectedIndexChanged_1;
        }

        protected void estadoInicial()
        {
            this.cmb_categoria.SelectedIndex = -1;
            this.cmb_ubicacion.SelectedIndex = -1;
            this.ubicacionesTemporal.Clear();
            this.hizoCambio = false;
            this.grw_productos.DataBindings.Clear();
            grw_productos.Columns.Clear();
        }

        protected void llenarUbicacion()
        {
            DataTable datos = UbicacionTR.consultarUbicaciones();
            if (datos != null && datos.Rows.Count > 0)
            {
                this.cmb_ubicacion.DataSource = datos;
                this.cmb_ubicacion.ValueMember = "id";
                this.cmb_ubicacion.DisplayMember = "nombre";
                this.cmb_ubicacion.SelectedIndex = 0;
            }
        }

        protected void guardarElegidos()
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
            UbicacionTR tran = new UbicacionTR();
            tran.insertarProductos(ref mensaje, datos, this.idUbicacion, this.categoriaAnterior);
            this.categoriaAnterior = Convert.ToInt32(this.cmb_categoria.SelectedValue);
        }

        protected void llenarGrid()
        {

            this.grw_productos.DataBindings.Clear();
            grw_productos.Columns.Clear();
            if (this.cmb_categoria.SelectedIndex == -1) return;
            string mensaje = "";
            int idCategoria = (this.cmb_categoria.SelectedValue == null || this.cmb_categoria.SelectedIndex == 0) ? -1 : Convert.ToInt32(this.cmb_categoria.SelectedValue);
            DataTable datos = UbicacionTR.consultarProductos(this.idUbicacion, idCategoria);
            if (datos != null)
            {
                datos.Columns.Add("elegido", typeof(bool)).SetOrdinal(1);
                foreach (DataRow fila in datos.Rows) fila["elegido"] = (Convert.ToBoolean(fila["temp"]));
                this.grw_productos.DataSource = datos;
                this.grw_productos.Columns["id"].Visible = false;
                //this.grw_productos.Columns["categoria"].Visible = false;
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


        protected void llenarUbicaciones()
        {
            string msn = "";
            DataTable datos = PromocionTR.consultarCategorias(ref msn);
            if (datos != null)
            {
                DataRow fila1 = datos.NewRow();
                fila1["id"] = "0";
                fila1["nombre"] = "TODOS";
                datos.Rows.InsertAt(fila1, 0);

                DataRow fila = datos.NewRow();
                fila["id"] = "-1";
                fila["nombre"] = "SELECCIONADOS";
                datos.Rows.InsertAt(fila, 0);

                this.cmb_categoria.DataSource = datos;
                this.cmb_categoria.ValueMember = "id";
                this.cmb_categoria.DisplayMember = "nombre";

                //this.categoriaAnterior = -1;
                this.cmb_categoria.SelectedIndex = 0;
                //if (!this.estadoGuardar) this.llenarGrid();

            }
            else Mensaje.error(msn);
        }


        protected void llenarCategoria()
        {
            string msn = "";
            DataTable datos = PromocionTR.consultarCategorias(ref msn);
            if (datos != null)
            {
                DataRow fila1 = datos.NewRow();
                fila1["id"] = "0";
                fila1["nombre"] = "TODOS";
                datos.Rows.InsertAt(fila1, 0);

                DataRow fila = datos.NewRow();
                fila["id"] = "-1";
                fila["nombre"] = "SELECCIONADOS";
                datos.Rows.InsertAt(fila, 0);

                this.cmb_categoria.DataSource = datos;
                this.cmb_categoria.ValueMember = "id";
                this.cmb_categoria.DisplayMember = "nombre";

                //this.categoriaAnterior = -1;
                this.cmb_categoria.SelectedIndex = 0;
                //if (!this.estadoGuardar) this.llenarGrid();

            }
            else Mensaje.error(msn);
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmb_categoria_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (this.cmb_categoria.SelectedIndex == -1) return;
            try
            {
                if (this.hizoCambio) this.guardarElegidos();
                else this.categoriaAnterior = Convert.ToInt32(this.cmb_categoria.SelectedValue);
                this.llenarGrid();
                this.hizoCambio = false;
                //this.chk_todos.Checked = false;

                this.chk_todos.CheckedChanged -= chk_todos_CheckedChanged;
                this.chk_todos.Checked = false;
                this.chk_todos.CheckedChanged += chk_todos_CheckedChanged;
            }
            catch (Exception error)
            {
                Mensaje.error(error.Message);
            }
        }

        private void cmb_ubicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmb_ubicacion.SelectedIndex == -1) return;
            if (this.hizoCambio) this.guardarElegidos();
            this.hizoCambio = false;
            this.idUbicacion = Convert.ToInt32(this.cmb_ubicacion.SelectedValue);
            if (!this.yaFueCargado(Convert.ToInt32(this.cmb_ubicacion.SelectedValue)))
            {
                UbicacionTR.cargarDatosTemporal(this.idUbicacion);
                this.ubicacionesTemporal.Add(this.idUbicacion);
            }
            this.cmb_categoria.SelectedIndexChanged -= cmb_categoria_SelectedIndexChanged_1;
            this.cmb_categoria.SelectedIndex = 0;
            this.llenarGrid();
            this.cmb_categoria.SelectedIndexChanged += cmb_categoria_SelectedIndexChanged_1;
            
        }

        protected bool yaFueCargado(int idUbicacion)
        {
            for (int i = 0; i < this.ubicacionesTemporal.Count; i++) if (this.ubicacionesTemporal[i] == idUbicacion) return true;
            return false;
        }

        private void frm_ubicacionProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.eliminarTemporal();
        }

        protected void eliminarTemporal()
        {
            UbicacionTR.eliminarTemporal();
        }

        private void chk_todos_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow fila in this.grw_productos.Rows) fila.Cells["elegido"].Value = this.chk_todos.Checked;
            this.hizoCambio = true;
        }

        private void grw_productos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.hizoCambio = true;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cmb_ubicacion.SelectedIndex == -1)
                {
                    Mensaje.advertencia("Por favor escoja una ubicación");
                    return;
                }
                if (hizoCambio) this.guardarElegidos();
                foreach(int id in this.ubicacionesTemporal)
                UbicacionTR.insertarProductosDesdeTemporal(id);
                Mensaje.informacion("Productos ingresados con éxito.");
                this.estadoInicial();
                //this.limpiar(false);
            }
            catch (Exception error)
            {
                Mensaje.error(error.Message);
            }
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            UbicacionTR.eliminarTemporal();
            this.estadoInicial();
        }

    }
}
