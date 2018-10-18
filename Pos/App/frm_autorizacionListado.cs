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
    public partial class frm_autorizacionListado : Form
    {
        public frm_autorizacionListado()
        {
            InitializeComponent();
        }

        private void frm_autorizacionListado_Load(object sender, EventArgs e)
        {
            this.cmb_establecimiento.SelectedIndexChanged -= new System.EventHandler(this.cmb_establecimiento_SelectedIndexChanged);
            this.cmb_estado.SelectedIndexChanged -= new System.EventHandler(this.cmb_estado_SelectedIndexChanged);
            this.cargarEstablecimientos();
            this.llenarComboEstado();
            this.llenarGrid();
            this.cmb_establecimiento.SelectedIndexChanged += new System.EventHandler(this.cmb_establecimiento_SelectedIndexChanged);
            this.cmb_estado.SelectedIndexChanged += new System.EventHandler(this.cmb_estado_SelectedIndexChanged);
        }

        protected void llenarGrid()
        {
            this.grw_autorizaciones.DataBindings.Clear();
            grw_autorizaciones.Columns.Clear();  

            int codigoEstablecimiento = (cmb_establecimiento.SelectedIndex == 0) ? -1 : int.Parse(cmb_establecimiento.SelectedValue.ToString());
            int estado = (cmb_estado.SelectedIndex == 0) ? -1 : int.Parse(cmb_estado.SelectedValue.ToString());

            AutorizacionTR tran = new AutorizacionTR();
            string mensaje = "";
            DataTable datos = tran.consultarAutorizaciones(ref mensaje, codigoEstablecimiento, estado);
            if (datos != null)
            {
                this.grw_autorizaciones.DataSource = datos;
                this.grw_autorizaciones.Columns[0].Visible = false;
                int ancho = this.grw_autorizaciones.Width - 20;
                this.grw_autorizaciones.Columns[1].Width = Convert.ToInt16(ancho * 0.20);
                this.grw_autorizaciones.Columns[2].Width = Convert.ToInt16(ancho * 0.16);
                this.grw_autorizaciones.Columns[3].Width = Convert.ToInt16(ancho * 0.16);
                this.grw_autorizaciones.Columns[4].Width = Convert.ToInt16(ancho * 0.16);
                this.grw_autorizaciones.Columns[5].Width = Convert.ToInt16(ancho * 0.16);
                this.grw_autorizaciones.Columns[6].Width = Convert.ToInt16(ancho * 0.15);
                DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
                bcol.Width = 20;
                bcol.HeaderText = "";
                bcol.Name = "botonEditar";
                bcol.UseColumnTextForButtonValue = true;
                this.grw_autorizaciones.Columns.Add(bcol);
            }
            else Mensaje.error(mensaje);
        }

        protected void cargarEstablecimientos()
        {
            string msn = "";
            EstablecimientoTR tran = new EstablecimientoTR();
            DataTable datos = tran.consultarEstablecimiento(ref msn);

            DataRow fila = datos.NewRow();
            //fila["id"] = "";
            fila["nombre"] = "Todos";
            datos.Rows.InsertAt(fila, 0);

            if (datos != null)
            {
                this.cmb_establecimiento.DataSource = datos;
                this.cmb_establecimiento.ValueMember = "id";
                this.cmb_establecimiento.DisplayMember = "nombre";
            }
            else Mensaje.error(msn);

            this.cmb_establecimiento.Focus();
        }


        protected void llenarComboEstado()
        {
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("", "Todos"));
            data.Add(new KeyValuePair<string, string>("1", "Activo"));
            data.Add(new KeyValuePair<string, string>("0", "Inactivo"));
            cmb_estado.DataSource = new BindingSource(data, null);
            cmb_estado.DisplayMember = "Value";
            cmb_estado.ValueMember = "Key";
        }

        private void cmb_establecimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.llenarGrid();
        }

        private void cmb_estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.llenarGrid();
        }

        private void cmb_establecimiento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void cmb_estado_SelectionChangeCommitted(object sender, EventArgs e)
        {
         
        }

        private void grw_autorizaciones_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (this.grw_autorizaciones.Columns[e.ColumnIndex].Name == "botonEditar")
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    Bitmap bmp = Pos.Properties.Resources.editar_fila;
                    DataGridViewButtonCell celBoton = this.grw_autorizaciones.Rows[e.RowIndex].Cells["botonEditar"] as DataGridViewButtonCell;

                    Icon icoAtomico = Icon.FromHandle(bmp.GetHicon());
                    e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                    // this.grw_empleado.AutoResizeRow(e.RowIndex);
                    //this.grw_empleado.Rows[e.RowIndex].Height = 20;
                    this.grw_autorizaciones.Columns[e.ColumnIndex].Width = 20;
                    e.Handled = true;
                }
            }
        }

        private void grw_autorizaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0 && this.grw_autorizaciones.Columns[e.ColumnIndex].Name == "botonEditar") this.editar(e);
        }

        protected void editar(DataGridViewCellEventArgs e)
        {
            int idAutorizacion = int.Parse(this.grw_autorizaciones.Rows[e.RowIndex].Cells[0].Value.ToString());
            frm_autorizacion autorizacion = new frm_autorizacion(idAutorizacion, grw_autorizaciones.Rows[e.RowIndex]);
            autorizacion.ShowDialog();
        }

        private void grw_autorizaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) this.editar(e);
        }
    }
}
