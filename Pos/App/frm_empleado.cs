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
    public partial class frm_empleado : Form
    {
        private int idEmpleado;
        private bool estadoGuardar = true;
        public DataGridViewRow fila;

        public frm_empleado()
        {
            InitializeComponent();
            llenarComboContrato();
        }

        public frm_empleado(string cedula, DataGridViewRow fila)
        {
            InitializeComponent();
            llenarComboContrato();
            this.txt_cedula.Enabled = false;
            this.txt_cedula.Text = cedula;
            this.buscarEmpleado(cedula);
            this.fila = fila;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }

        protected void limpiar()
        {
            if(fila==null)this.txt_cedula.Clear();
            this.txt_direccion.Clear();
            this.txt_email.Clear();
            this.txt_nombre.Clear();
            this.txt_sueldo.Clear();
            this.txt_telefono.Clear();
            this.cmb_contrato.SelectedIndex = -1;

        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!validar()) return;
            Persona persona = new Persona();
            persona.id = this.idEmpleado;
            persona.cedula = txt_cedula.Text;
            persona.razon_social = txt_nombre.Text;
            persona.telefonos = txt_telefono.Text;
            persona.email = txt_email.Text;
            persona.direccion = txt_direccion.Text;
            persona.tipo_contrato = cmb_contrato.SelectedValue.ToString();
            persona.sueldo = Convert.ToDecimal(this.txt_sueldo.Text);
            persona.es_empleado = true;
            persona.es_vendedor = true;
            persona.tipo = "N";
            EmpleadoTR tran = new EmpleadoTR(persona);
            string msn="";
            if (estadoGuardar && tran.insertarEmpleado(ref msn)) //guardar
            {    
                Mensaje.informacion("Empleado ingresado con éxito.");
                if (this.Owner.GetType() == typeof(frm_usuario))
                {
                    ((frm_usuario)this.Owner).setCedula(persona.cedula);
                    this.Close();
                }
                this.limpiar();
                txt_cedula.Focus();
            }
            else if(!estadoGuardar && tran.actualizarEmpleado(ref msn))
            {
                Mensaje.informacion("Empleado actualizado con éxito.");
                if (this.fila != null) pasarDatos();
                this.limpiar();
                txt_cedula.Focus();
            }
            else Mensaje.advertencia(msn);    
        }

        protected void pasarDatos()
        {
            this.fila.Cells["Nombre"].Value = this.txt_nombre.Text;
            this.fila.Cells["Teléfono"].Value = this.txt_telefono.Text;
            this.fila.Cells["Tipo de Contrato"].Value = this.cmb_contrato.Text;
            this.Close();
        }

        protected Boolean validar() {
            if (this.txt_cedula.Text.Trim().Length < 1)
            {
                Mensaje.faltaCampo("Debe ingresar el campo cédula.");
                txt_cedula.Focus();
                return false;
            }
            if (this.txt_cedula.Text.Trim().Length < 10)
            {
                Mensaje.faltaCampo("La cédula debe tener 10 dígitos.");
                txt_cedula.Focus();
                return false;
            }
            if (this.txt_nombre.Text.Trim().Length < 1)
            {
                Mensaje.faltaCampo("Debe ingresar el campo nombre.");
                txt_nombre.Focus();
                return false;
            }
            if (this.txt_telefono.Text.Trim().Length < 1)
            {
                Mensaje.faltaCampo("Debe ingresar el campo teléfono.");
                txt_telefono.Focus();
                return false;
            }
            if (this.txt_direccion.Text.Trim().Length < 1) {
                Mensaje.faltaCampo("Debe ingresar el campo dirección.");
                txt_direccion.Focus();
                return false; 
            }
            if (this.cmb_contrato.SelectedIndex == -1) {
                Mensaje.faltaCampo("Debe seleccionar la relación de dependencia");
                cmb_contrato.Focus();
                return false;
            }
            /*if (this.txt_email.Text.Trim().Length < 1) {
                Mensaje.faltaCampo("Debe ingresar el campo email.");
                txt_email.Focus();
                return false; 
            }*/
            if (this.txt_sueldo.Text.Trim().Length < 1)
            {
                Mensaje.faltaCampo("Debe ingresar el campo sueldo.");
                txt_sueldo.Focus();
                return false;
            }
            decimal temp=0;
            if (!Decimal.TryParse(txt_sueldo.Text,out temp))
            {
                Mensaje.faltaCampo("El sueldo ingresado es incorrecto.");
                txt_sueldo.Focus();
                return false;
            }
            return true;
        }

        private void frm_empleado_Load(object sender, EventArgs e)
        {
            //Apariencia.colorFormulario(this.Controls);
            if(estadoGuardar)this.cmb_contrato.SelectedIndex = -1;
        }

        protected void llenarComboContrato() {
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("A", "Relación de Dependencia"));
            data.Add(new KeyValuePair<string, string>("S", "Otros"));
            cmb_contrato.DataSource = new BindingSource(data, null);
            cmb_contrato.DisplayMember = "Value";
            cmb_contrato.ValueMember = "Key";
        }

        private void txt_cedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.txt_cedula.Text.Trim().Length < 1) {
                    Mensaje.advertencia("Debe ingresar el campo cédula");
                    return;
                }
                this.buscarEmpleado(txt_cedula.Text);
            }
            General.soloNumeros(e);
        }

        public void buscarEmpleado(string cedula) {
            try
            {
                Persona persona = EmpleadoTR.buscarXCedula(cedula);
                if (persona != null)
                {
                    llenarCampos(persona);
                    this.idEmpleado = persona.id;
                    activarEstadoActualizar();

                }
                else
                {
                    Mensaje.advertencia("No se encontró el empleado.");
                }
            }
            catch (Exception e)
            { 
                Mensaje.error(e.Message);
            }
        }

        public void llenarCampos(Persona persona)
        {
           
            this.txt_nombre.Text = persona.razon_social;
            this.txt_telefono.Text = persona.telefonos;
            this.txt_email.Text = persona.email;
            this.txt_direccion.Text = persona.direccion;
            this.txt_sueldo.Text = persona.sueldo.ToString();
            this.cmb_contrato.SelectedValue = persona.tipo_contrato;
        }

        private void txt_cedula_TextChanged(object sender, EventArgs e)
        {
            if (estadoGuardar == false) activarEstadoGuardar();
        }

        protected void activarEstadoActualizar()
        {
            this.btn_guardar.Enabled = false;
            this.estadoGuardar = false;
            //this.btn_guardar.Text = "Actualizar";
        }

        protected void activarEstadoGuardar()
        {
            this.btn_guardar.Enabled = true;
            this.btn_guardar.Text = "Guardar";
            this.estadoGuardar = true;
            this.cmb_contrato.SelectedIndex = -1;
            this.txt_direccion.Clear();
            this.txt_email.Clear();
            this.txt_nombre.Clear();
            this.txt_sueldo.Clear();
            this.txt_telefono.Clear();
        }

        private void txt_sueldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.permitirDecimales(sender, e);
        }

        private void txt_caracteres_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.sinCaracteresEspeciales(e);
        }
    }
}
