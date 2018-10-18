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
    public partial class frm_establecimiento : Form
    {
        private string idEstablecimiento;
        private bool estadoGuardar = true;
        public DataGridViewRow fila;

        public frm_establecimiento()
        {
            InitializeComponent();
        }

        public frm_establecimiento(string idEstablecimiento, DataGridViewRow fila)
        {
            this.idEstablecimiento = idEstablecimiento;
            this.fila = fila;
            InitializeComponent();
            this.txt_codigo.Enabled = false;
            this.txt_codigo.Text = idEstablecimiento;
            this.buscarEstablecimiento(idEstablecimiento);
        }

        private void frm_establecimiento_Load(object sender, EventArgs e)
        {
            txt_codigo.Focus();
        }

        private void txt_codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.soloNumeros(e);
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!validar()) return;
            Establecimiento establecimiento = new Establecimiento();
            establecimiento.Idtbl_establecimiento = int.Parse(this.txt_codigo.Text);
            establecimiento.Nombre = this.txt_nombre.Text;
            establecimiento.Direccion = this.txt_direccion.Text;
            EstablecimientoTR tran = new EstablecimientoTR(establecimiento);
            string msn = "";
            if (estadoGuardar && tran.insertarEstablecimiento(ref msn))
            {
                Mensaje.informacion("Establecimiento ingresado exito");
                this.limpiar();
                txt_codigo.Select();
            }
            else if (!estadoGuardar && tran.actualizarEstablecimiento(ref msn))
            {
                Mensaje.informacion("Establecimiento actualizado con éxito.");
                if (this.fila != null) pasarDatos();
                this.limpiar();
                
                txt_codigo.Select();
            }
            else Mensaje.advertencia(msn); 
        }

        protected void pasarDatos()
        {
            this.fila.Cells["Nombre"].Value = this.txt_nombre.Text;
            this.fila.Cells["Dirección"].Value = this.txt_direccion.Text;
            this.Close();
        }

        protected Boolean validar()
        {
            if (this.txt_codigo.Text.Trim().Length < 1)
            {
                Mensaje.faltaCampo("Debe ingresar el campo código.");
                txt_codigo.Focus();
                return false;
            }
            else if (this.txt_nombre.Text.Trim().Length < 1)
            {
                Mensaje.faltaCampo("Debe ingresar el campo nombre.");
                txt_nombre.Focus();
                return false;
            }
            if (this.txt_direccion.Text.Trim().Length < 1)
            {
                Mensaje.faltaCampo("Debe ingresar el campo dirección.");
                txt_direccion.Focus();
                return false;
            }
            return true;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        public void limpiar() 
        {
            if (fila==null) this.txt_codigo.Clear();
            this.txt_nombre.Clear();
            this.txt_direccion.Clear();
            this.btn_guardar.Enabled = true;
        }

        private void txt_codigo_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.txt_codigo.Text.Trim().Length < 1)
                {
                    Mensaje.advertencia("Debe ingresar el campo código");
                    return;
                }
                this.buscarEstablecimiento(txt_codigo.Text);
            }
            General.soloNumeros(e);
        }

        public void buscarEstablecimiento(string codigo)
        {
            String mensaje = "";
            EstablecimientoTR tran = new EstablecimientoTR();
            Establecimiento establecimiento = tran.buscarXCodigo(codigo, ref mensaje);
            if (establecimiento != null)
            {
                llenarCampos(establecimiento);
                this.idEstablecimiento = establecimiento.Idtbl_establecimiento.ToString();
                activarEstadoActualizar();

            }
            else
            {
                if (String.IsNullOrEmpty(mensaje)) Mensaje.advertencia("No se encontró el establecimiento.");
                else Mensaje.error(mensaje);
            }
        }

        protected void llenarCampos(Establecimiento establecimiento)
        {
            this.txt_nombre.Text = establecimiento.Nombre;
            this.txt_direccion.Text = establecimiento.Direccion;
        }

        protected void activarEstadoActualizar()
        {
            this.btn_guardar.Text = "Actualizar";
            this.estadoGuardar = false;
        }

        private void txt_codigo_TextChanged(object sender, EventArgs e)
        {
            if (estadoGuardar == false) activarEstadoGuardar();
        }

        protected void activarEstadoGuardar()
        {
            this.btn_guardar.Text = "Guardar";
            this.estadoGuardar = true;
            this.txt_direccion.Clear();
            this.txt_nombre.Clear();
  
        }

    }
}
