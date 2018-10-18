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
    public partial class frm_establecimientoListado : Form
    {
        public frm_establecimientoListado()
        {
            InitializeComponent();
        }

        private void frm_establecimientoListado_Load(object sender, EventArgs e)
        {
            this.llenarGrid("");
        }


        protected void llenarGrid(string nombre)
        {
            this.grw_establecimiento.DataBindings.Clear();
            grw_establecimiento.Columns.Clear();
            string mensaje = "";
            EstablecimientoTR tran = new EstablecimientoTR();
            DataTable datos = tran.consultarEstablecimientos(ref mensaje, nombre);
            if (datos != null)
            {
                this.grw_establecimiento.DataSource = datos;
                this.grw_establecimiento.Columns[0].Visible = false;
                int ancho = this.grw_establecimiento.Width - 20;
                this.grw_establecimiento.Columns[1].Width = Convert.ToInt16(ancho * 0.25);
                this.grw_establecimiento.Columns[2].Width = Convert.ToInt16(ancho * 0.74);

                DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
                bcol.Width = 20;
                bcol.HeaderText = "";
                bcol.Name = "botonEditar";
                bcol.UseColumnTextForButtonValue = true;
                //grw_empleado.Columns.Insert(5, bcol); 
                this.grw_establecimiento.Columns.Add(bcol);
            }
            else Mensaje.error(mensaje);

        }

        private void grw_establecimiento_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (this.grw_establecimiento.Columns[e.ColumnIndex].Name == "botonEditar")
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    Bitmap bmp = Pos.Properties.Resources.editar_fila;
                    DataGridViewButtonCell celBoton = this.grw_establecimiento.Rows[e.RowIndex].Cells["botonEditar"] as DataGridViewButtonCell;

                    Icon icoAtomico = Icon.FromHandle(bmp.GetHicon());
                    e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                    // this.grw_empleado.AutoResizeRow(e.RowIndex);
                    //this.grw_empleado.Rows[e.RowIndex].Height = 20;
                    this.grw_establecimiento.Columns[e.ColumnIndex].Width = 20;
                    e.Handled = true;
                }
            }
        }

        private void txt_nombre_KeyUp(object sender, KeyEventArgs e)
        {
            this.llenarGrid(txt_nombre.Text);
        }

        private void grw_establecimiento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0 && this.grw_establecimiento.Columns[e.ColumnIndex].Name == "botonEditar") this.editar(e);
        }

        protected void editar(DataGridViewCellEventArgs e)
        {
            string idEstablecimiento = this.grw_establecimiento.Rows[e.RowIndex].Cells[0].Value.ToString();
            frm_establecimiento establecimiento = new frm_establecimiento(idEstablecimiento, grw_establecimiento.Rows[e.RowIndex]);
            establecimiento.ShowDialog();
        }

        private void grw_establecimiento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) this.editar(e);
        }
    }
}
