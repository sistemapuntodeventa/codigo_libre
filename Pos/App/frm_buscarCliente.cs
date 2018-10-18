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
using MySql.Data.MySqlClient;

namespace Pos.App
{
    public partial class frm_buscarCliente : Form
    {
        private int nRegistros;
        private bool habilitarCodigoCliente;
        public int id { get; set; }
        public string cedula { get; set; }

        public frm_buscarCliente()
        {
            InitializeComponent();
        }

        public frm_buscarCliente(bool codigoCliente)
        {
            InitializeComponent();
            this.habilitarCodigoCliente = codigoCliente;
        }

        private void frm_buscarCliente_Load(object sender, EventArgs e)
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
            DataTable datos = tran.consultarClientesSeleccion(ref mensaje, nombre, cedula, registros);
            if (datos != null)
            {
                this.grw_clientes.DataSource = datos;
                this.grw_clientes.Columns[0].Visible = false;
                int ancho = this.grw_clientes.Width;
                this.grw_clientes.Columns[2].Width = Convert.ToInt16(ancho * 0.55);
                if (this.habilitarCodigoCliente)
                {
                    this.grw_clientes.Columns[3].Width = Convert.ToInt16(ancho * 0.35);
                    this.grw_clientes.Columns[4].Width = Convert.ToInt16(ancho * 0.10);
                }
                else
                {
                    this.grw_clientes.Columns[3].Width = Convert.ToInt16(ancho * 0.10);
                }
            }
            else Mensaje.error(mensaje);

        }

        private void txt_nombre_KeyUp(object sender, KeyEventArgs e)
        {
            this.llenarGrid(txt_nombre.Text, txt_cedula.Text);
        }

        private void txt_cedula_KeyUp(object sender, KeyEventArgs e)
        {
            this.llenarGrid(txt_nombre.Text, txt_cedula.Text);
        }

        private void frm_buscarCliente_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Escape)this.Close();
        }

        private void txt_cedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.soloNumeros(e);
        }

        private void grw_clientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                this.id = Convert.ToInt32(this.grw_clientes["id", e.RowIndex].Value);
                this.cedula = this.grw_clientes["Cédula/Ruc", e.RowIndex].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void grw_clientes_KeyDown(object sender, KeyEventArgs e)
        {
 
        }

        private void cmb_registros_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.llenarGrid(this.txt_nombre.Text, this.txt_cedula.Text);
            this.txt_cedula.Select();
        }

        private void frm_buscarCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            int nuevoValor = (this.cmb_registros.Text != "TODOS") ? Convert.ToInt32(this.cmb_registros.Text) : -1;
            if (this.nRegistros != nuevoValor) ParametroTR.actualizarParametroEntero("listadoClientes", nuevoValor);
        }

    }
}
