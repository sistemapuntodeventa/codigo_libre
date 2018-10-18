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
    public partial class frm__buscarPromocion : Form
    {
        public frm__buscarPromocion()
        {
            InitializeComponent();
        }

        public void actualizarFila(string nombre, string cantidad, string descuento,string desde, string hasta, bool estado,int fila)
        {
            this.grw_promociones["Nombre", fila].Value = nombre;
            this.grw_promociones["Cantidad", fila].Value = cantidad;
            this.grw_promociones["Desde", fila].Value = desde;
            this.grw_promociones["Hasta", fila].Value = hasta;
            this.grw_promociones["Porcentaje", fila].Value = descuento + "%";
            this.grw_promociones["Estado", fila].Value = (estado)?"ACTIVA":"INACTIVA";
        }

        private void frm__buscarPromocion_Load(object sender, EventArgs e)
        {
            List<ComboboxItem> lista = new List<ComboboxItem>();
            lista.Add(new ComboboxItem("TODOS", ""));
            lista.Add(new ComboboxItem("ACTIVA", "A"));
            lista.Add(new ComboboxItem("INACTIVA", "I"));
            this.cmb_estado.DataSource = lista;
            this.cmb_estado.DisplayMember = "Text";
            this.cmb_estado.ValueMember = "Value";
            this.cmb_estado.SelectedIndex = 1;
            this.llenarGrid("A");
            this.cmb_estado.SelectedIndexChanged += cmb_estado_SelectedIndexChanged;
        }

        protected void llenarGrid(string estado)
        {
            try
            {
                this.grw_promociones.DataBindings.Clear();
                grw_promociones.Columns.Clear();
                DataTable datos = PromocionTR.consultarPromociones(estado);
                if (datos != null)
                {
                    this.grw_promociones.DataSource = datos;
                    this.grw_promociones.Columns[0].Visible = false;
                    int ancho = this.grw_promociones.Width - 40;
                    this.grw_promociones.Columns[1].Width = Convert.ToInt16(ancho * 0.20);
                    this.grw_promociones.Columns[2].Width = Convert.ToInt16(ancho * 0.10);
                    this.grw_promociones.Columns[3].Width = Convert.ToInt16(ancho * 0.10);
                    this.grw_promociones.Columns[4].Width = Convert.ToInt16(ancho * 0.10);
                    this.grw_promociones.Columns[5].Width = Convert.ToInt16(ancho * 0.20);
                    this.grw_promociones.Columns[6].Width = Convert.ToInt16(ancho * 0.20);
                    this.grw_promociones.Columns[7].Width = Convert.ToInt16(ancho * 0.10);

                    DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
                    bcol.Width = 20;
                    bcol.HeaderText = "";
                    bcol.Name = "botonEditar";
                    bcol.UseColumnTextForButtonValue = true;
                    this.grw_promociones.Columns.Add(bcol);

                    DataGridViewButtonColumn bcol1 = new DataGridViewButtonColumn();
                    bcol1.Width = 20;
                    bcol1.HeaderText = "";
                    bcol1.Name = "botonEliminar";
                    bcol1.UseColumnTextForButtonValue = true;
                    this.grw_promociones.Columns.Add(bcol1);
                }
            }
            catch (Exception e)
            {
                Mensaje.error(e.Message);
            }
        }

        private void grw_promociones_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (this.grw_promociones.Columns[e.ColumnIndex].Name == "botonEditar")
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    Bitmap bmp = Pos.Properties.Resources.editar_fila;
                    DataGridViewButtonCell celBoton = this.grw_promociones.Rows[e.RowIndex].Cells["botonEditar"] as DataGridViewButtonCell;

                    Icon icoAtomico = Icon.FromHandle(bmp.GetHicon());
                    e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);
                    this.grw_promociones.Columns[e.ColumnIndex].Width = 20;
                    e.Handled = true;
                }

                if (this.grw_promociones.Columns[e.ColumnIndex].Name == "botonEliminar")
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    Bitmap bmp = Pos.Properties.Resources.borrar_fila;
                    DataGridViewButtonCell celBoton = this.grw_promociones.Rows[e.RowIndex].Cells["botonEliminar"] as DataGridViewButtonCell;

                    Icon icoAtomico = Icon.FromHandle(bmp.GetHicon());
                    e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 2, e.CellBounds.Top + 3);
                    this.grw_promociones.Columns[e.ColumnIndex].Width = 21;
                    e.Handled = true;
                }

            }
        }

        private void cmb_estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.llenarGrid(this.cmb_estado.SelectedValue.ToString());
        }

        private void grw_promociones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0 && this.grw_promociones.Columns[e.ColumnIndex].Name == "botonEditar") this.editar(e);
            else if (e.ColumnIndex > 0 && this.grw_promociones.Columns[e.ColumnIndex].Name == "botonEliminar") this.eliminar(e);
        }


        protected void editar(DataGridViewCellEventArgs e)
        {
            int idPromocion = (int)this.grw_promociones["id",e.RowIndex].Value;
            string tipo = this.grw_promociones["tipo", e.RowIndex].Value.ToString();
            Form promocion = null;
            if (tipo == "PRODUCTO")promocion = new frm_promocion(idPromocion, e.RowIndex);
            else if (tipo == "COMBO") promocion = new frm_promocionCombo(idPromocion, e.RowIndex);
            if(promocion!=null)promocion.ShowDialog(this);
            
        }

        protected void eliminar(DataGridViewCellEventArgs e)
        {
            try
            {
                if (Mensaje.confirmacion("¿Desea Eliminar la promoción?"))
                {
                    int idPromocion = (int)this.grw_promociones["id", e.RowIndex].Value;
                    if (PromocionTR.eliminarPromocion(idPromocion)) this.grw_promociones.Rows.RemoveAt(e.RowIndex);
                }
            }
            catch (Exception error)
            {
                Mensaje.error(error.Message);
            }
        }
    }
}
