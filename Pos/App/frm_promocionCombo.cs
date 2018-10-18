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
    public partial class frm_promocionCombo : Form
    {
        private List<object[]> paginas = null;
        private bool estadoGuardar = true;
        private bool hizoCambio = false;
        private int categoriaAnterior;
        private int paginaAnterior = 0;
        private int idConfiguracion = 1;
        private int idPromocion;
        private int fila;

        public frm_promocionCombo()
        {
            InitializeComponent();
            paginas = new List<object[]>();
            this.eliminarTemporal();
            this.chk_estado.Checked = true;         
        }

        public frm_promocionCombo(int idPromocion, int fila)
        {
            InitializeComponent();
            try
            {
                paginas = new List<object[]>();
                this.eliminarTemporal();
                this.idPromocion = idPromocion;
                this.fila = fila;
                PromocionTR.cargarDatosTemporal(this.idConfiguracion, idPromocion);
                Promocion promocion = PromocionTR.consultarXId(idPromocion);
                if (promocion != null)
                {
                    this.llenarDatos(promocion);
                    this.generarPaginas(promocion.cantidad);
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
            //this.cmb_mismoGrupo.SelectedIndex = promocion.agrupacion - 1;
            this.chk_lunes.Checked = promocion.lunes;
            this.chk_martes.Checked = promocion.martes;
            this.chk_miercoles.Checked = promocion.miercoles;
            this.chk_jueves.Checked = promocion.jueves;
            this.chk_viernes.Checked = promocion.viernes;
            this.chk_sabado.Checked = promocion.sabado;
            this.chk_domingo.Checked = promocion.domingo;
            this.dtp_desde.Value = promocion.desde;
            this.dtp_hasta.Value = promocion.hasta;
            this.cmb_seleccion.SelectedIndex = (promocion.seleccion == "F") ? 0 : 1;
            //this.cmb_mismoGrupo.SelectedIndex = (promocion.mismoGrupo) ? 0 : 1;
        }

        protected void eliminarTemporal()
        {
            PromocionTR.eliminarTemporal(this.idConfiguracion);
        }

        private void frm_promocionCombo_Load(object sender, EventArgs e)
        {
            this.cmb_categoria.SelectedIndexChanged -= cmb_categoria_SelectedIndexChanged;
            this.llenarCategoria();
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
                if (!this.estadoGuardar)
                {
                    for (int i = 0; i < this.tac_productos.TabCount;i++)this.llenarGrid(i);
                }

            }
            else Mensaje.error(msn);
        }

        protected void llenarGrid(int indice)
        {
            DataGridView grw_productos = (DataGridView)this.paginas[indice][1];
            grw_productos.DataBindings.Clear();
            grw_productos.Columns.Clear();
            if (this.cmb_categoria.SelectedIndex == -1) return;
            string mensaje = "";
            int idCategoria = (this.cmb_categoria.SelectedValue == null || this.cmb_categoria.SelectedIndex == 0) ? -1 : Convert.ToInt32(this.cmb_categoria.SelectedValue);
            DataTable datos = PromocionTR.productosDisponibles(idCategoria, -1,indice,this.txt_filtro.Text);
            if (datos != null)
            {
                //DataTable temp = datos.Clone();
                //temp.Columns["elegido"].DataType = typeof(bool);
                datos.Columns.Add("elegido", typeof(bool)).SetOrdinal(1);
                foreach (DataRow fila in datos.Rows) fila["elegido"] = (Convert.ToBoolean(fila["temp"]));
                grw_productos.DataSource = datos;
                grw_productos.Columns["id"].Visible = false;
                grw_productos.Columns["elegido"].HeaderText = "";
                grw_productos.Columns["categoria"].Visible = false;
                grw_productos.Columns["temp"].Visible = false;
                int ancho = grw_productos.Width;
                grw_productos.Columns["elegido"].Width = Convert.ToInt16(ancho * 0.10);
                grw_productos.Columns["codigo"].Width = Convert.ToInt16(ancho * 0.15);
                grw_productos.Columns["nombre"].Width = Convert.ToInt16(ancho * 0.25);
                grw_productos.Columns["descripcion"].Width = Convert.ToInt16(ancho * 0.50);

            }
            else Mensaje.error(mensaje);
        }

        private void txt_cantidad_KeyUp(object sender, KeyEventArgs e)
        {
            if (String.IsNullOrEmpty(this.txt_cantidad.Text)) this.limpiarPaginas();
            else {
                int cantidad;
                if (Int32.TryParse(this.txt_cantidad.Text, out cantidad)) this.generarPaginas(cantidad);
                else this.limpiarPaginas();
            }
        }

        protected void generarPaginas(int cantidadPedida)
        {
            int cantidadActual = this.paginas.Count;
            if (cantidadPedida > cantidadActual)
            {
                int cantidad = cantidadPedida - cantidadActual;
                for (int i = 0; i < cantidad; i++)
                {
                    TabPage paginaNueva = new TabPage();
                    DataGridView gridNuevo = this.generarGrid();
                    cantidadActual++;
                    paginaNueva.Text = cantidadActual.ToString() + " Productos";
                    paginaNueva.Controls.Add(gridNuevo);
                    this.tac_productos.Controls.Add(paginaNueva);

                    object[] objeto = new object[5];
                    objeto[0] = paginaNueva;
                    objeto[1] = gridNuevo;
                    objeto[2] = false; // seleccionado
                    objeto[3] = this.cmb_categoria.SelectedValue; // categoria seleccionada
                    objeto[4] = "";
                    this.paginas.Add(objeto);
                }
            }
            else
            {
                //int cantidad = cantidadActual - cantidadPedida;
                for (int i = cantidadActual - 1; i >= cantidadPedida; i--)
                {
                    this.paginas.RemoveAt(i);
                    this.tac_productos.Controls.RemoveAt(i);
                }
            }
        }

        protected void limpiarPaginas()
        {
            //foreach (object[] pagina in this.paginas) this.tac_productos.Controls.Remove((TabPage)pagina[0]);
            //this.cmb_categoria.SelectedIndexChanged -= this.cmb_categoria_SelectedIndexChanged;
            this.tac_productos.SelectedIndexChanged -= tac_productos_SelectedIndexChanged;
            this.tac_productos.TabPages.Clear();
            //this.cmb_categoria.SelectedIndex = 0;
            paginas.Clear();
            this.cmb_categoria.SelectedIndex = -1;
            //this.cmb_categoria.SelectedIndexChanged += this.cmb_categoria_SelectedIndexChanged;
            this.tac_productos.SelectedIndexChanged += tac_productos_SelectedIndexChanged;
        }

        protected DataGridView generarGrid()
        {
            DataGridView data = new DataGridView();
            data.CellEndEdit += grw_productos_CellEndEdit;
            data.AllowUserToAddRows = false;
            data.AllowUserToDeleteRows = false;
            data.RowHeadersVisible = false;
            data.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            data.Dock = DockStyle.Fill;
            return data;
        }

        private void grw_productos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.hizoCambio = true;
            this.paginas[this.tac_productos.SelectedIndex][2] = true;
        }

        private void cmb_categoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmb_categoria.SelectedIndex == -1) return;
            if (String.IsNullOrEmpty(this.txt_cantidad.Text) || this.tac_productos.TabPages.Count <= 0)
            {
                Mensaje.informacion("Por favor ingrese una cantidad de items.");
                this.cmb_categoria.SelectedIndex = -1;
                return;
            }


            int paginaActual = this.tac_productos.SelectedIndex;
           try
            {
                if (this.hizoCambio) this.guardarElegidos(paginaActual);
                else this.guardarCategoria(paginaActual);
                this.llenarGrid(paginaActual);
                this.hizoCambio = false;
                this.paginas[paginaActual][2] = false;
                this.chk_todos.CheckedChanged -= chk_todos_CheckedChanged;
                this.chk_todos.Checked = false;
                this.chk_todos.CheckedChanged += chk_todos_CheckedChanged;
            }
            catch (Exception error)
            {
                Mensaje.error(error.Message);
            }
        }

        protected void guardarCategoria(int indice)
        {
            this.categoriaAnterior = Convert.ToInt32(this.cmb_categoria.SelectedValue);
            this.paginas[indice][3] = Convert.ToInt32(this.cmb_categoria.SelectedValue);
        }

        protected void guardarElegidos(int indice)
        {
            List<int[]> datos = new List<int[]>();
            DataGridView grw_productos = (DataGridView)this.paginas[indice][1];
            foreach (DataGridViewRow fila in grw_productos.Rows)
            {
                if (!String.IsNullOrEmpty(fila.Cells["elegido"].Value.ToString()) && Convert.ToBoolean(fila.Cells["elegido"].Value))
                {
                    int[] producto = new int[3];
                    producto[0] = Convert.ToInt32(fila.Cells["id"].Value);
                    producto[1] = Convert.ToInt32(fila.Cells["categoria"].Value);
                    //producto[2] = this.tac_productos.SelectedIndex;
                    datos.Add(producto);
                }
            }
            string mensaje = "";
            PromocionTR tran = new PromocionTR();
            tran.insertarProductos(ref mensaje, datos, 1, this.categoriaAnterior,indice);
            this.guardarCategoria(indice);
        }

        private void tac_productos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.paginaAnterior != -1) this.paginas[this.paginaAnterior][4] = this.txt_filtro.Text;
            this.paginaAnterior = this.tac_productos.SelectedIndex;
            this.cmb_categoria.SelectedIndexChanged -= cmb_categoria_SelectedIndexChanged;
            this.cmb_categoria.SelectedValue = (this.paginas[this.tac_productos.SelectedIndex][3]!=null)?Convert.ToInt32(this.paginas[this.tac_productos.SelectedIndex][3]):-1;
            this.txt_filtro.Text = this.paginas[this.paginaAnterior][4].ToString();
            this.hizoCambio = Convert.ToBoolean(this.paginas[this.paginaAnterior][2]);
            this.cmb_categoria.SelectedIndexChanged += cmb_categoria_SelectedIndexChanged;
        }

        private void chk_todos_CheckedChanged(object sender, EventArgs e)
        {
            DataGridView grw_productos = (DataGridView)this.paginas[this.tac_productos.SelectedIndex][1];
            foreach (DataGridViewRow fila in grw_productos.Rows) fila.Cells["elegido"].Value = this.chk_todos.Checked;
            this.paginas[this.tac_productos.SelectedIndex][2] = true;
            this.hizoCambio = true;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validar()) return;
                int i = 0;
                foreach (object[] pagina in this.paginas)
                {
                    if(Convert.ToBoolean(pagina[2]))this.guardarElegidos(i);
                    i++;
                }
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
            promocion.actualizarFila(this.txt_nombre.Text, this.txt_cantidad.Text, this.txt_descuento.Text, this.dtp_desde.Text, this.dtp_hasta.Text, this.chk_estado.Checked, fila);
            this.Close();
        }

        private Promocion tomarDatos()
        {
            Promocion promocion = new Promocion();
            promocion.id = this.idPromocion;
            promocion.nombre = this.txt_nombre.Text;
            promocion.agrupacion = 1;
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
            promocion.seleccion = (cmb_seleccion.SelectedIndex == 0)?"F":"P";
            promocion.desde = dtp_desde.Value;
            promocion.hasta = dtp_hasta.Value;
            promocion.tipo = "C";
            //promocion.mismoGrupo = (this.cmb_mismoGrupo.SelectedIndex == 0);
            return promocion;
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

        protected void limpiar(bool limpiar = true)
        {
            this.limpiarPaginas();
            //this.tac_productos.TabPages.Clear();
            //grw_productos.Columns.Clear();
            //this.limpiarPaginas();
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
            //this.cmb_categoria.SelectedIndex = 0;
            //this.cmb_mismoGrupo.SelectedIndex = 0;
            if (limpiar) this.eliminarTemporal();
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_filtro_KeyUp(object sender, KeyEventArgs e)
        {
            int paginaActual = this.tac_productos.SelectedIndex;
            try
            {
                if (this.hizoCambio) this.guardarElegidos(paginaActual);
                this.llenarGrid(paginaActual);
                this.hizoCambio = false;
                this.paginas[paginaActual][2] = false;
                this.chk_todos.CheckedChanged -= chk_todos_CheckedChanged;
                this.chk_todos.Checked = false;
                this.chk_todos.CheckedChanged += chk_todos_CheckedChanged;
            }
            catch (Exception error)
            {
                Mensaje.error(error.Message);
            }
        }

        private void txt_filtro_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.soloNumeros(e);
        }
    }
}
