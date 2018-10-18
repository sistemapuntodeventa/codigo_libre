using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pos.Clases;
using Pos.Coneccion;

namespace Pos.App
{
    public partial class frm_promocion : Form
    {
        private int categoriaAnterior;
        private int idConfiguracion = 1;
        private int idPromocion = -1;
        private bool hizoCambio = false;
        private bool estadoGuardar = true;
        private int fila;

        public frm_promocion(int idPromocion, int fila)
        {
            InitializeComponent();
            try
            {
                this.eliminarTemporal();
                this.idPromocion = idPromocion;
                this.fila = fila;
                PromocionTR.cargarDatosTemporal(this.idConfiguracion, idPromocion);
                Promocion promocion = PromocionTR.consultarXId(idPromocion);
                if (promocion != null)
                {
                    this.llenarDatos(promocion);
                    this.btn_guardar.Text = "Actualizar";
                    this.estadoGuardar = false;
                }
            }
            catch (Exception e)
            {
                Mensaje.error(e.Message);
            }
        }

        private void llenarDatos(Promocion promocion)
        {
            this.txt_nombre.Text = promocion.nombre;
            this.chk_estado.Checked = (promocion.estado == "A");
            this.txt_descuento.Text = promocion.descuento.ToString();
            this.txt_cantidad.Text = promocion.cantidad.ToString();
            this.cmb_mismoGrupo.SelectedIndex = promocion.agrupacion - 1;
            this.chk_lunes.Checked = promocion.lunes;
            this.chk_martes.Checked = promocion.martes;
            this.chk_miercoles.Checked = promocion.miercoles;
            this.chk_jueves.Checked = promocion.jueves;
            this.chk_viernes.Checked = promocion.viernes;
            this.chk_sabado.Checked = promocion.sabado;
            this.chk_domingo.Checked = promocion.domingo;
            this.dtp_desde.Value = promocion.desde;
            this.dtp_hasta.Value = promocion.hasta;
            //this.cmb_mismoGrupo.SelectedIndex = (promocion.mismoGrupo) ? 0 : 1;
        }

        public frm_promocion()
        {
            InitializeComponent();
            this.eliminarTemporal();
            this.chk_estado.Checked = true;
            this.cmb_mismoGrupo.SelectedIndex = 0;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validar()) return;
                if (hizoCambio) this.guardarElegidos();
                Promocion promocion = this.tomarDatos();
                PromocionTR tran = new PromocionTR(promocion);
                if (this.estadoGuardar)
                {
                    tran.insertarPromocion();
                    Mensaje.informacion("Promoción ingresada con éxito.");
                    this.limpiar(false);
                }
                else
                {
                    tran.actualizarPromocion();
                    Mensaje.informacion("Promoción actualizada con éxito.");
                    this.pasarDatos();
                }
            }
            catch (Exception error)
            {
                Mensaje.error(error.Message);
            }
        }

        protected void pasarDatos()
        {
            frm__buscarPromocion promocion = (frm__buscarPromocion)this.Owner;
            promocion.actualizarFila(this.txt_nombre.Text, this.txt_cantidad.Text, this.txt_descuento.Text,this.dtp_desde.Text,this.dtp_hasta.Text, this.chk_estado.Checked, fila);
            this.Close();
        }

        protected bool validar()
        {
            if (this.txt_descuento.Text.Trim().Length < 1)
            {
                Mensaje.informacion("Debe ingresar un porcentaje de descuento.");
                this.txt_descuento.Select();
                return false;
            }

            if (this.txt_cantidad.Text.Trim().Length < 1)
            {
                Mensaje.informacion("Debe ingresar una cantidad.");
                this.txt_cantidad.Select();
                return false;
            }

            if (!chk_domingo.Checked && !chk_lunes.Checked && !chk_martes.Checked && !chk_miercoles.Checked && !chk_jueves.Checked && !chk_viernes.Checked && !chk_sabado.Checked)
            {
                Mensaje.informacion("Debe seleccionar por lo menos un día de la semana.");
                this.chk_domingo.Select();
                return false;
            }

            return true;
        }

        private Promocion tomarDatos()
        {
            Promocion promocion = new Promocion();
            promocion.id = this.idPromocion;
            promocion.nombre = this.txt_nombre.Text;
            promocion.agrupacion = this.cmb_mismoGrupo.SelectedIndex + 1;
            promocion.estado = (this.chk_estado.Checked) ? "A" : "I";
            promocion.domingo = this.chk_domingo.Checked;
            promocion.lunes = this.chk_lunes.Checked;
            promocion.martes = this.chk_martes.Checked;
            promocion.miercoles = this.chk_miercoles.Checked;
            promocion.jueves = this.chk_jueves.Checked;
            promocion.viernes = this.chk_viernes.Checked;
            promocion.sabado = this.chk_sabado.Checked;
            promocion.descuento = Convert.ToDecimal(this.txt_descuento.Text);
            promocion.cantidad = Convert.ToInt32(this.txt_cantidad.Text);
            promocion.desde = dtp_desde.Value;
            promocion.hasta = dtp_hasta.Value;
            promocion.tipo = "P";
            //promocion.mismoGrupo = (this.cmb_mismoGrupo.SelectedIndex == 0);
            return promocion;
        }

        private void frm_promocion_Load(object sender, EventArgs e)
        {
            this.cmb_categoria.SelectedIndexChanged -= cmb_categoria_SelectedIndexChanged;
            this.llenarCategoria();
            //this.llenarGrid();
            this.cmb_categoria.SelectedIndexChanged += cmb_categoria_SelectedIndexChanged;

            this.dtp_desde.Format = DateTimePickerFormat.Custom;
            this.dtp_desde.CustomFormat = "dd/MM/yyyy HH:mm";

            this.dtp_hasta.Format = DateTimePickerFormat.Custom;
            this.dtp_hasta.CustomFormat = "dd/MM/yyyy HH:mm";

            if (this.estadoGuardar)
            {
                this.dtp_desde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                this.dtp_hasta.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 0);
            }

        }

        protected void llenarCategoria()
        {
            //PromocionTR pro = new PromocionTR();
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

                this.categoriaAnterior = -1;
                this.cmb_categoria.SelectedIndex = 0;
                if (!this.estadoGuardar) this.llenarGrid();
                //if (this.estadoGuardar)
                //{
                //    this.categoriaAnterior = -1;
                //    this.cmb_categoria.SelectedIndex = -1;
                //}
                //else
                //{
                //    this.categoriaAnterior = 0;
                //    this.cmb_categoria.SelectedIndex = 0;
                //    this.llenarGrid();
                //}

            }
            else Mensaje.error(msn);
        }

        private void cmb_categoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(this.hizoCambio)this.guardarElegidos();
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
            PromocionTR tran = new PromocionTR();
            tran.insertarProductos(ref mensaje, datos, 1, this.categoriaAnterior);
            this.categoriaAnterior = Convert.ToInt32(this.cmb_categoria.SelectedValue);
        }

        protected void llenarGrid()
        {
            
            this.grw_productos.DataBindings.Clear();
            grw_productos.Columns.Clear();
            if (this.cmb_categoria.SelectedIndex == -1) return;
            string mensaje = "";
            int idCategoria = (this.cmb_categoria.SelectedValue == null || this.cmb_categoria.SelectedIndex == 0) ? -1 : Convert.ToInt32(this.cmb_categoria.SelectedValue);
            DataTable datos = PromocionTR.productosDisponibles(idCategoria,this.idPromocion);
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

        private void chk_todos_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow fila in this.grw_productos.Rows) fila.Cells["elegido"].Value = this.chk_todos.Checked;
            this.hizoCambio = true;
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }

        protected void limpiar(bool limpiar = true)
        {
            this.grw_productos.DataBindings.Clear();
            grw_productos.Columns.Clear();
            this.txt_nombre.Clear();
            this.txt_cantidad.Clear();
            this.txt_descuento.Clear();
            this.chk_domingo.Checked = false;
            this.chk_lunes.Checked = false;
            this.chk_martes.Checked = false;
            this.chk_miercoles.Checked = false;
            this.chk_jueves.Checked = false;
            this.chk_viernes.Checked = false;
            this.chk_sabado.Checked = false;
            this.dtp_desde.Value = DateTime.Now;
            this.dtp_hasta.Value = DateTime.Now;
            this.cmb_categoria.SelectedIndex = 0;
            this.cmb_mismoGrupo.SelectedIndex = 0;
            if(limpiar)this.eliminarTemporal();
        }

        protected void eliminarTemporal()
        {
            PromocionTR.eliminarTemporal(this.idConfiguracion);
        }

        private void frm_promocion_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.eliminarTemporal();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grw_productos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.hizoCambio = true;
            
        }
    }
}
