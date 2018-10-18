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
    public partial class frm_empleadoListado : Form
    {
        public frm_empleadoListado()
        {
            InitializeComponent();
        }

        protected void editar(DataGridViewCellEventArgs e) {
            string cedula = this.grw_empleados.Rows[e.RowIndex].Cells[1].Value.ToString();
            frm_empleado empleado = new frm_empleado(cedula, grw_empleados.Rows[e.RowIndex]);
            empleado.ShowDialog();
        }

        private void frm_empleadoListado_Load(object sender, EventArgs e)
        {
            this.llenarGrid("","");
        }

        protected void llenarGrid(string nombre,string cedula) {
            this.grw_empleados.DataBindings.Clear();
            grw_empleados.Columns.Clear();  
            string mensaje = "";
            EmpleadoTR tran = new EmpleadoTR();
            DataTable datos = tran.consultarEmpleados(ref mensaje,nombre,cedula);
            if (datos != null)
            {
                this.grw_empleados.DataSource = datos;
                this.grw_empleados.Columns[0].Visible = false;

                int ancho = this.grw_empleados.Width - 20;
                this.grw_empleados.Columns[1].Width = Convert.ToInt16(ancho * 0.15);
                this.grw_empleados.Columns[2].Width = Convert.ToInt16(ancho * 0.35);
                this.grw_empleados.Columns[3].Width = Convert.ToInt16(ancho * 0.25);
                this.grw_empleados.Columns[4].Width = Convert.ToInt16(ancho * 0.25);

                DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
                bcol.Width = 20;
                bcol.HeaderText = "";
                bcol.Name = "botonEditar";
                bcol.UseColumnTextForButtonValue = true;
                //grw_empleado.Columns.Insert(5, bcol); 
                this.grw_empleados.Columns.Add(bcol);
            }
            else Mensaje.error(mensaje);
            
        }

        private void grw_empleados_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (this.grw_empleados.Columns[e.ColumnIndex].Name == "botonEditar")
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    Bitmap bmp = Pos.Properties.Resources.editar_fila;
                    DataGridViewButtonCell celBoton = this.grw_empleados.Rows[e.RowIndex].Cells["botonEditar"] as DataGridViewButtonCell;

                    Icon icoAtomico = Icon.FromHandle(bmp.GetHicon());
                    e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);
                    this.grw_empleados.Columns[e.ColumnIndex].Width = 20;
                    e.Handled = true;
                }
            }
        }

        private void grw_empleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0 && this.grw_empleados.Columns[e.ColumnIndex].Name == "botonEditar") this.editar(e);
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            this.llenarGrid(txt_nombre.Text, txt_cedula.Text);
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            this.llenarGrid(txt_nombre.Text, txt_cedula.Text);
        }

        private void txt_cedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.soloNumeros(e);
        }

        private void grw_empleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) this.editar(e);
        }

        private void txt_nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_empleado empleado = new frm_empleado();
            empleado.Owner = this;
            empleado.ShowDialog();
        }
    }
}
