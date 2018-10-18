using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pos.Coneccion;
using MySql.Data.MySqlClient;
using Pos.Clases;

namespace Pos.App
{
    public partial class frm_buscar_empleado : Form
    {
        public int idEmpleado {get; set;}
        public string nombre { get; set; }
        public string cedula { get; set; }

        public frm_buscar_empleado()
        {
            InitializeComponent();
            
        }


        private void frm_buscar_empleado_Load(object sender, EventArgs e)
        {
            this.cmb_ingresado.SelectedIndex = 2;
           // this.llenarGrid("", 2);
        }

        protected void llenarGrid(string nombre,int mostrarTodos)
        {
            this.grw_empleados.DataBindings.Clear();
            grw_empleados.Columns.Clear();
            string mensaje = "";
            EmpleadoTR tran = new EmpleadoTR();
            DataTable datos = tran.consultarEmpleadosIngresados(ref mensaje, nombre, mostrarTodos);
            if (datos != null)
            {
                this.grw_empleados.DataSource = datos;
                int ancho = grw_empleados.Width;
                this.grw_empleados.Columns[0].Visible = false;
                this.grw_empleados.Columns[1].Width = Convert.ToInt16(ancho * 0.15);
                this.grw_empleados.Columns[2].Width = Convert.ToInt16(ancho * 0.40);
                this.grw_empleados.Columns[3].Width = Convert.ToInt16(ancho * 0.30);
                this.grw_empleados.Columns[4].Width = Convert.ToInt16(ancho * 0.14);
            }
            else Mensaje.error(mensaje);

        }

        private void txt_filtro_KeyUp(object sender, KeyEventArgs e)
        {
            this.llenarGrid(txt_nombre.Text,cmb_ingresado.SelectedIndex);
        }

        private void grw_empleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.idEmpleado = int.Parse(grw_empleados.Rows[e.RowIndex].Cells[0].Value.ToString());
            this.nombre = grw_empleados.Rows[e.RowIndex].Cells[2].Value.ToString();
            this.cedula = grw_empleados.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void grp_data_Enter(object sender, EventArgs e)
        {

        }

        private void cmb_ingresado_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.llenarGrid(txt_nombre.Text, cmb_ingresado.SelectedIndex);
        }
               
    }
}
