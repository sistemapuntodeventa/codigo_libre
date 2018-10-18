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
    public partial class frm_adicionales : Form
    {
        public frm_adicionales()
        {
            InitializeComponent();
        }

        protected void llenarComboTipo(ComboBox combo)
        {
            List<ComboboxItem> items = new List<ComboboxItem>();
            items.Add(new ComboboxItem("CAJA DE TEXTO", "T"));
            items.Add(new ComboboxItem("COMBO", "C"));
            items.Add(new ComboboxItem("BÚSQUEDA", "B"));

            combo.DataSource = items;
            combo.ValueMember = "Value";
            combo.DisplayMember = "Text";
        }

        private void frm_adicionales_Load(object sender, EventArgs e)
        {
            this.llenarComboTipo(this.cmb_tipo1);
            this.llenarComboTipo(this.cmb_tipo2);

            string mensaje = "";
            AdicionalTR tran = new AdicionalTR();
            Adicional adicional1 = tran.consultar(ref mensaje,1);
            if (adicional1 != null)
            {
                this.cmb_tipo1.SelectedValue = adicional1.tipo;
                if (adicional1.tipo == "T") this.grw_items1.Enabled = false;
                this.txt_nombre1.Text = adicional1.nombre;
                this.txt_etiqueta1.Text = adicional1.etiqueta;
                this.chk_activo1.Checked = (adicional1.estado == "A");
                this.chk_requerido1.Checked = adicional1.obligatorio;
                this.chk_mostrarListado1.Checked = adicional1.mostrarEnListado;
                if (adicional1.items != null)
                {
                    int i = 0;
                    foreach (String texto in adicional1.items)
                    {
                        this.grw_items1.Rows.Add();
                        this.grw_items1["valor1", i].Value = texto;
                        i++;
                    }
                }
                Adicional adicional2 = tran.consultar(ref mensaje, 2);
                if (adicional2 != null)
                {
                    this.cmb_tipo2.SelectedValue = adicional2.tipo;
                    if (adicional2.tipo == "T") this.grw_items2.Enabled = false;
                    this.txt_nombre2.Text = adicional2.nombre;
                    this.txt_etiqueta2.Text = adicional2.etiqueta;
                    this.chk_activo2.Checked = (adicional2.estado == "A");
                    this.chk_requerido2.Checked = adicional2.obligatorio;
                    this.chk_mostrarListado2.Checked = adicional2.mostrarEnListado;
                    if (adicional2.items != null)
                    {
                        int i = 0;
                        foreach (String texto in adicional2.items)
                        {
                            this.grw_items2.Rows.Add();
                            this.grw_items2["valor2", i].Value = texto;
                            i++;
                        }
                    }
                }
            }
            else Mensaje.advertencia(mensaje);
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grw_items_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (this.grw_items1.Columns[e.ColumnIndex].Name == "botonEliminar1")
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    Bitmap bmp = Pos.Properties.Resources.borrar_fila;
                    DataGridViewButtonCell celBoton = this.grw_items1.Rows[e.RowIndex].Cells["botonEliminar1"] as DataGridViewButtonCell;
                    Icon icoAtomico = Icon.FromHandle(bmp.GetHicon());
                    e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 2, e.CellBounds.Top + 3);
                    this.grw_items1.Columns[e.ColumnIndex].Width = 21;
                    e.Handled = true;
                }

            }
        }


        protected bool validar()
        {
            if (this.chk_activo1.Checked)
            {
                if (this.txt_nombre1.Text.Trim().Length < 1)
                {
                    Mensaje.advertencia("Ingrese un nombre para el campo adicional 1.");
                    this.txt_nombre1.Select();
                    return false;
                }

                if (this.txt_etiqueta1.Text.Trim().Length < 1)
                {
                    Mensaje.advertencia("Ingrese una etiqueta para el campo adicional 1.");
                    this.txt_etiqueta1.Select();
                    return false;
                }

                if (this.cmb_tipo1.SelectedValue.ToString() != "T")
                {
                    bool todasVacias = true;
                    foreach (DataGridViewRow fila in this.grw_items1.Rows)
                    {
                        if (!General.celdaVacia(fila.Cells["valor1"]))
                        {
                            todasVacias = false;
                            break;
                        }
                    }

                    if (todasVacias)
                    {
                        Mensaje.advertencia("Debe ingresar por lo menos un valor para el campo adicional 1.");
                        this.grw_items1.Select();
                        return false;
                    }
                }
            }

            if (this.chk_activo2.Checked)
            {
                if (this.txt_nombre2.Text.Trim().Length < 1)
                {
                    Mensaje.advertencia("Ingrese un nombre para el campo adicional 2.");
                    this.txt_nombre2.Select();
                    return false;
                }

                if (this.txt_etiqueta2.Text.Trim().Length < 1)
                {
                    Mensaje.advertencia("Ingrese una etiqueta para el campo adicional 2.");
                    this.txt_etiqueta2.Select();
                    return false;
                }

                if (this.cmb_tipo2.SelectedValue.ToString() != "T")
                {
                    bool todasVacias = true;
                    foreach (DataGridViewRow fila in this.grw_items2.Rows)
                    {
                        if (!General.celdaVacia(fila.Cells["valor2"]))
                        {
                            todasVacias = false;
                            break;
                        }
                    }

                    if (todasVacias)
                    {
                        Mensaje.advertencia("Debe ingresar por lo menos un valor para el campo adicional 2.");
                        this.grw_items2.Select();
                        return false;
                    }
                }
            }

            return true;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!validar()) return;
            //string mensaje = "";
            Adicional adicional1 = new Adicional();
            adicional1.nombre = this.txt_nombre1.Text;
            adicional1.etiqueta = this.txt_etiqueta1.Text;
            adicional1.tipo = this.cmb_tipo1.SelectedValue.ToString();
            adicional1.estado = (this.chk_activo1.Checked)?"A":"I";
            adicional1.obligatorio = (this.chk_requerido1.Checked);
            adicional1.mostrarEnListado = (this.chk_mostrarListado1.Checked);
            adicional1.idAdicional = 1;
            adicional1.items = new List<String>();
            if (this.cmb_tipo1.SelectedValue.ToString() != "T")
            {
                foreach (DataGridViewRow fila in this.grw_items1.Rows) if (!General.celdaVacia(fila.Cells["valor1"])) adicional1.items.Add(fila.Cells["valor1"].Value.ToString());
            }

            AdicionalTR tran = new AdicionalTR(adicional1);
          /*  if (tran.actualizar(ref mensaje))
            {
                tran.refrescar();
                adicional1.nombre = this.txt_nombre2.Text;
                adicional1.etiqueta = this.txt_etiqueta2.Text;
                adicional1.tipo = this.cmb_tipo2.SelectedValue.ToString();
                adicional1.estado = (this.chk_activo2.Checked) ? "A" : "I";
                adicional1.obligatorio = (this.chk_requerido2.Checked);
                adicional1.mostrarEnListado = (this.chk_mostrarListado2.Checked);
                adicional1.idAdicional = 2;
                adicional1.items = new List<String>();
                if (this.cmb_tipo2.SelectedValue.ToString() != "T")
                {
                    foreach (DataGridViewRow fila in this.grw_items2.Rows) if (!General.celdaVacia(fila.Cells["valor2"])) adicional1.items.Add(fila.Cells["valor2"].Value.ToString());
                }

                if (tran.actualizar(ref mensaje))Mensaje.informacion("Adicional ingresado con éxito.");
                else Mensaje.error(mensaje);
            }
            else Mensaje.error(mensaje);*/
        }

        private void grw_items_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.grw_items1.Columns[e.ColumnIndex].Name == "botonEliminar1")
            {
                if (e.RowIndex < this.grw_items1.Rows.Count - 1)
                {
                    this.grw_items1.Rows.RemoveAt(e.RowIndex);
                    if (this.grw_items1.Rows.Count < 1) this.grw_items1.Rows.Add();
                }
            }
        }

        private void cmb_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmb_tipo1.SelectedValue.ToString() == "T") this.grw_items1.Enabled = false;
            else this.grw_items1.Enabled = true;
        }

        private void grw_items2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (this.grw_items2.Columns[e.ColumnIndex].Name == "botonEliminar2")
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    Bitmap bmp = Pos.Properties.Resources.borrar_fila;
                    DataGridViewButtonCell celBoton = this.grw_items2.Rows[e.RowIndex].Cells["botonEliminar2"] as DataGridViewButtonCell;
                    Icon icoAtomico = Icon.FromHandle(bmp.GetHicon());
                    e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 2, e.CellBounds.Top + 3);
                    this.grw_items2.Columns[e.ColumnIndex].Width = 21;
                    e.Handled = true;
                }
            }
        }

        private void grw_items2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.grw_items2.Columns[e.ColumnIndex].Name == "botonEliminar2")
            {
                if (e.RowIndex < this.grw_items2.Rows.Count - 1)
                {
                    this.grw_items2.Rows.RemoveAt(e.RowIndex);
                    if (this.grw_items2.Rows.Count < 1) this.grw_items2.Rows.Add();
                }
            }
        }

        private void cmb_tipo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmb_tipo2.SelectedValue.ToString() == "T") this.grw_items2.Enabled = false;
            else this.grw_items2.Enabled = true;
        }

        private void txt_nombre2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_etiqueta2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
