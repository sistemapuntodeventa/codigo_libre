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
    public partial class frm_adicional : Form
    {
        private List<controlesAdicionales> paginaControles = null;

        public frm_adicional()
        {
            paginaControles = new List<controlesAdicionales>();
            InitializeComponent();
        }

        private class controlesAdicionales
        {
            public int idAdicional;
            public CheckBox chk_activo;
            public Label lbl_tipo;
            public ComboBox cmb_tipo;
            public Label lbl_nombre;
            public TextBox txt_nombre;
            public Label lbl_etiqueta;
            public TextBox txt_etiqueta;
            public DataGridView grw_datos;
            public CheckBox chk_requerido;
            public CheckBox chk_mostrarBusqueda;

            public controlesAdicionales(TabPage pagina)
            {
                idAdicional = -1;
                chk_activo = new CheckBox();
                lbl_tipo = new Label();
                cmb_tipo = new ComboBox();
                lbl_nombre = new Label();
                txt_nombre = new TextBox();
                lbl_etiqueta = new Label();
                txt_etiqueta = new TextBox();
                grw_datos = generarGrid();
                chk_requerido = new CheckBox();
                chk_mostrarBusqueda = new CheckBox();

                chk_activo.Location = new Point(338,9);
                lbl_tipo.Location = new Point(64, 38);
                cmb_tipo.Location = new Point(103, 35);
                lbl_nombre.Location = new Point(43, 65);
                txt_nombre.Location = new Point(103, 63);
                lbl_etiqueta.Location = new Point(43, 92);
                txt_etiqueta.Location = new Point(103, 89);
                grw_datos.Location = new Point(16, 120);
                chk_requerido.Location = new Point(16, 287);
                chk_mostrarBusqueda.Location = new Point(16, 312);

                lbl_tipo.Size = new Size(34, 15);
                cmb_tipo.Size = new Size(292, 23);
                lbl_nombre.Size = new Size(55, 15);
                txt_nombre.Size = new Size(292, 21);
                lbl_etiqueta.Size = new Size(55, 15);
                txt_etiqueta.Size = new Size(292, 21);
                grw_datos.Size = new Size(379, 161);
                chk_mostrarBusqueda.Size = new Size(144, 19);

                cmb_tipo.DropDownStyle = ComboBoxStyle.DropDownList;

                chk_activo.Text = "Activo";
                lbl_tipo.Text = "Tipo:";
                lbl_nombre.Text = "Nombre:";
                lbl_etiqueta.Text = "Etiqueta";

                chk_requerido.Text = "Requerido";
                chk_mostrarBusqueda.Text = "Mostrar en Búsqueda";

                pagina.Controls.Add(chk_activo);
                pagina.Controls.Add(lbl_tipo);
                pagina.Controls.Add(cmb_tipo);
                pagina.Controls.Add(lbl_nombre);
                pagina.Controls.Add(txt_nombre);
                pagina.Controls.Add(lbl_etiqueta);
                pagina.Controls.Add(txt_etiqueta);
                pagina.Controls.Add(grw_datos);
                pagina.Controls.Add(chk_requerido);
                pagina.Controls.Add(chk_mostrarBusqueda);

                this.llenarComboTipo(cmb_tipo);
            }

            protected void llenarComboTipo(ComboBox combo)
            {
                List<ComboboxItem> items = new List<ComboboxItem>();
                items.Add(new ComboboxItem("CAJA DE TEXTO", "T"));
                items.Add(new ComboboxItem("COMBO", "C"));
                items.Add(new ComboboxItem("BÚSQUEDA", "B"));
                items.Add(new ComboboxItem("FECHA", "F"));

                combo.DataSource = items;
                combo.ValueMember = "Value";
                combo.DisplayMember = "Text";

                cmb_tipo.SelectedIndexChanged += cmb_tipo_SelectedIndexChanged;
            }

            protected DataGridView generarGrid()
            {
                DataGridView data = new DataGridView();
                data.CellContentClick += grw_datos_CellContentClick;
                data.CellPainting += grw_datos_CellPainting;
                data.AllowUserToAddRows = true;
                data.AllowUserToDeleteRows = true;
                data.RowHeadersVisible = false;
                data.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                data.Dock = DockStyle.None;

                DataGridViewTextBoxColumn columnaValor = new DataGridViewTextBoxColumn();
                columnaValor.Name = "valor";
                columnaValor.HeaderText = "Valor";
                columnaValor.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                DataGridViewButtonColumn columnaEliminar = new DataGridViewButtonColumn();
                columnaEliminar.Name = "botonEliminar";
                columnaEliminar.HeaderText = "";

                data.Columns.Add(columnaValor);
                data.Columns.Add(columnaEliminar);

                return data;
            }

            private void cmb_tipo_SelectedIndexChanged(object sender, EventArgs e)
            {
                string valor = this.cmb_tipo.SelectedValue.ToString();
                if (valor == "T" || valor == "F") this.grw_datos.Enabled = false;
                else this.grw_datos.Enabled = true;
            }

            private void grw_datos_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                if (this.grw_datos.Columns[e.ColumnIndex].Name == "botonEliminar")
                {
                    if (e.RowIndex < this.grw_datos.Rows.Count - 1)
                    {
                        this.grw_datos.Rows.RemoveAt(e.RowIndex);
                        if (this.grw_datos.Rows.Count < 1) this.grw_datos.Rows.Add();
                    }
                }
            }

            private void grw_datos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {
                    if (this.grw_datos.Columns[e.ColumnIndex].Name == "botonEliminar")
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                        Bitmap bmp = Pos.Properties.Resources.borrar_fila;
                        DataGridViewButtonCell celBoton = this.grw_datos.Rows[e.RowIndex].Cells["botonEliminar"] as DataGridViewButtonCell;
                        Icon icoAtomico = Icon.FromHandle(bmp.GetHicon());
                        e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 2, e.CellBounds.Top + 3);
                        this.grw_datos.Columns[e.ColumnIndex].Width = 21;
                        e.Handled = true;
                    }

                }
            }
        }

        private void frm_adicional_Load(object sender, EventArgs e)
        {
            this.cargarAdicionales();
        }

        protected TabPage crearPagina(int numero)
        {
            TabPage paginaNueva = new TabPage();
            this.tac_adicionales.Controls.Add(paginaNueva);
            paginaNueva.Text = "Adicional " + numero;
            return paginaNueva;
        }

        protected void cargarAdicionales()
        { 
            AdicionalTR tran = new AdicionalTR();
            List<Adicional> adicionales = tran.cargarAdicionales();
            if(adicionales!=null)
            {
                this.txt_cantidad.Text = adicionales.Count.ToString();
                int n = 1;
                foreach (Adicional adicional in adicionales)
                {
                    TabPage paginaNueva = this.crearPagina(n);
                    controlesAdicionales controles = new controlesAdicionales(paginaNueva);
                    controles.idAdicional = adicional.idAdicional;
                    controles.cmb_tipo.SelectedValue = adicional.tipo;
                    //if (adicional.tipo == "T") controles.grw_datos.Enabled = false;
                    controles.txt_nombre.Text = adicional.nombre;
                    controles.txt_etiqueta.Text = adicional.etiqueta;
                    controles.chk_activo.Checked = (adicional.estado == "A");
                    controles.chk_requerido.Checked = adicional.obligatorio;
                    controles.chk_mostrarBusqueda.Checked = adicional.mostrarEnListado;
                    
                    if (adicional.items != null)
                    {
                        int i = 0;
                        foreach (String texto in adicional.items)
                        {
                            controles.grw_datos.Rows.Add();
                            controles.grw_datos["valor", i].Value = texto;
                            i++;
                        }
                    }
                    this.paginaControles.Add(controles);
                    n++;
                }
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (String.IsNullOrEmpty(this.txt_cantidad.Text)) this.limpiarPaginas();
            else
            {
                int cantidad;
                if (Int32.TryParse(this.txt_cantidad.Text, out cantidad)) this.generarPaginas(cantidad);
                else 
                    this.limpiarPaginas();
            }
        }

        protected void generarPaginas(int cantidadPedida)
        {
            int cantidadActual = this.paginaControles.Count;
            if (cantidadPedida > cantidadActual)
            {
                int cantidad = cantidadPedida - cantidadActual;
                for (int i = 0; i < cantidad; i++)
                {
                    cantidadActual++;
                    TabPage paginaNueva = this.crearPagina(cantidadActual);
                    controlesAdicionales controles = new controlesAdicionales(paginaNueva);
                    //paginaNueva.Text = cantidadActual.ToString() + " Productos";
                    //this.tac_adicionales.Controls.Add(paginaNueva);
                    this.paginaControles.Add(controles);
                }
            }
            else
            {
                int cantidad = cantidadActual - cantidadPedida;
                for (int i = cantidadActual - 1; i >= cantidadPedida; i--)
                {
                    this.paginaControles.RemoveAt(i);
                    this.tac_adicionales.Controls.RemoveAt(i);
                }
            }
        }

        protected void limpiarPaginas()
        {
            this.tac_adicionales.TabPages.Clear();
            this.paginaControles.Clear();
        }


        private bool validar(controlesAdicionales control,string numero)
        {
            if (control.chk_activo.Checked)
            {
                if (control.txt_nombre.Text.Trim().Length < 1)
                {
                    Mensaje.advertencia("Ingrese un nombre para el campo adicional " + numero +  ".");
                    control.txt_nombre.Select();
                    return false;
                }

                if (control.txt_etiqueta.Text.Trim().Length < 1)
                {
                    Mensaje.advertencia("Ingrese una etiqueta para el campo adicional " + numero + ".");
                    control.txt_etiqueta.Select();
                    return false;
                }

                string tipo = control.cmb_tipo.SelectedValue.ToString();
                if (tipo == "C" || tipo =="B")
                {
                    bool todasVacias = true;
                    foreach (DataGridViewRow fila in control.grw_datos.Rows)
                    {
                        if (!General.celdaVacia(fila.Cells["valor"]))
                        {
                            todasVacias = false;
                            break;
                        }
                    }

                    if (todasVacias)
                    {
                        Mensaje.advertencia("Debe ingresar por lo menos un valor para el campo adicional " + numero + ".");
                        control.grw_datos.Select();
                        return false;
                    }
                }
            }

            return true;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {

                int i = 0;
                foreach (controlesAdicionales control in this.paginaControles)
                {
                    if (!validar(control, i.ToString())) return;
                    i++;
                }
                string ids = "";
                foreach (controlesAdicionales control in this.paginaControles)
                {
                    Adicional adicional = new Adicional();
                    adicional.nombre = control.txt_nombre.Text;
                    adicional.etiqueta = control.txt_etiqueta.Text;
                    adicional.tipo = control.cmb_tipo.SelectedValue.ToString();
                    adicional.estado = (control.chk_activo.Checked) ? "A" : "I";
                    adicional.obligatorio = (control.chk_requerido.Checked);
                    adicional.mostrarEnListado = (control.chk_mostrarBusqueda.Checked);
                    adicional.idAdicional = control.idAdicional;
                    adicional.items = new List<String>();
                    if (control.cmb_tipo.SelectedValue.ToString() != "T")
                    {
                        foreach (DataGridViewRow fila in control.grw_datos.Rows) if (!General.celdaVacia(fila.Cells["valor"])) adicional.items.Add(fila.Cells["valor"].Value.ToString());
                    }

                    AdicionalTR tran = new AdicionalTR(adicional);
                    tran.actualizar();
                    ids += adicional.idAdicional.ToString() + ",";
                }
                AdicionalTR.eliminarAdicionales(ids.Substring(0, ids.Length - 1));
                Mensaje.informacion("Adicionales modificados satisfactoriamente.");
            }
            catch (Exception error)
            {
                Mensaje.error(error.Message);
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
