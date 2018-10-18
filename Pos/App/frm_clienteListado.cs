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
    public partial class frm_clienteListado : Form
    {
        private int nRegistros;

        public frm_clienteListado()
        {
            InitializeComponent();
        }

        private void frm_clienteListado_Load(object sender, EventArgs e)
        {
            this.nRegistros = ParametroTR.consultarIntXNombre("listadoClientes");
            if (this.nRegistros != -1) this.cmb_registros.SelectedItem = this.nRegistros.ToString();
            else this.cmb_registros.SelectedItem = "TODOS";
            this.llenarGrid("", "");
        }

        protected void llenarGrid(string nombre, string cedula)
        {
            this.grw_clientes.DataBindings.Clear();
            grw_clientes.Columns.Clear();
            string mensaje = "";
            ClienteTR tran = new ClienteTR();
            int registros = (this.cmb_registros.Text != "TODOS") ? Convert.ToInt32(this.cmb_registros.Text) : -1;
            DataTable datos = tran.consultarClientes(ref mensaje, nombre, cedula, registros);
            if (datos != null)
            {
                this.grw_clientes.DataSource = datos;
                this.grw_clientes.Columns[0].Visible = false;
                int ancho = this.grw_clientes.Width - 20;
                this.grw_clientes.Columns[1].Width = Convert.ToInt16(ancho * 0.15);
                this.grw_clientes.Columns[2].Width = Convert.ToInt16(ancho * 0.30);
                this.grw_clientes.Columns[3].Width = Convert.ToInt16(ancho * 0.15);
                this.grw_clientes.Columns[4].Width = Convert.ToInt16(ancho * 0.37);

                DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
                bcol.Width = 20;
                bcol.HeaderText = "";
                bcol.Name = "botonEditar";
                bcol.UseColumnTextForButtonValue = true;
                //grw_empleado.Columns.Insert(5, bcol); 
                this.grw_clientes.Columns.Add(bcol);
            }
            else Mensaje.error(mensaje);

        }

        protected void editar(DataGridViewCellEventArgs e)
        {
            string cedula = this.grw_clientes.Rows[e.RowIndex].Cells[1].Value.ToString();
            frm_Cliente cliente = new frm_Cliente(cedula, grw_clientes.Rows[e.RowIndex]);
            cliente.ShowDialog();
        }

        private void grw_clientes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (this.grw_clientes.Columns[e.ColumnIndex].Name == "botonEditar")
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    Bitmap bmp = Pos.Properties.Resources.editar_fila;
                    DataGridViewButtonCell celBoton = this.grw_clientes.Rows[e.RowIndex].Cells["botonEditar"] as DataGridViewButtonCell;

                    Icon icoAtomico = Icon.FromHandle(bmp.GetHicon());
                    e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                    // this.grw_empleado.AutoResizeRow(e.RowIndex);
                    //this.grw_empleado.Rows[e.RowIndex].Height = 20;
                    this.grw_clientes.Columns[e.ColumnIndex].Width = 20;
                    e.Handled = true;
                }
            }
        }

        private void grw_clientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0 && this.grw_clientes.Columns[e.ColumnIndex].Name == "botonEditar") this.editar(e);
        }

        private void grw_clientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) this.editar(e);
        }

        private void txt_nombre_KeyUp(object sender, KeyEventArgs e)
        {
            this.llenarGrid(txt_nombre.Text, txt_cedula.Text);
        }

        private void txt_cedula_KeyUp(object sender, KeyEventArgs e)
        {
            this.llenarGrid(txt_nombre.Text, txt_cedula.Text);
        }

        private void cmb_registros_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.llenarGrid(this.txt_nombre.Text, this.txt_cedula.Text);
            this.txt_cedula.Select();
        }
    }
}
