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
using System.Text.RegularExpressions;

namespace Pos.App
{
    public partial class frm_Cliente : Form
    {
        private int idCliente;
        private bool estadoGuardar = true;
        public DataGridViewRow fila;
        private bool validarIdentificacion = false;
        private bool habilitarCodigo = false;

        public frm_Cliente()
        {
            InitializeComponent();
        }

        public frm_Cliente(string cedula)
        {
            InitializeComponent();
            if (cedula.Length > 10)
            {
                this.txt_cedula.Enabled = false;
                this.txt_ruc.Text = cedula;
            }
            else this.txt_cedula.Text = cedula;
            this.txt_nombre.Select();
        }

        public frm_Cliente(string cedula, DataGridViewRow fila)
        {
            InitializeComponent();
            this.txt_cedula.Enabled = false;
            this.txt_cedula.Text = cedula;
            //this.rd_cedula.Enabled = false;
            //this.rd_ruc.Enabled = false;
            this.buscarCliente(cedula);
            this.fila = fila;
        }

        public void buscarCliente(string cedula)
        {
            try
            {
                Persona persona = ClienteTR.buscarXCedula(cedula);
                if (persona != null)
                {
                    llenarCampos(persona);
                    this.idCliente = persona.id;
                    activarEstadoActualizar();
                }
                else
                {
                    Mensaje.advertencia("No se encontró el cliente.");
                }
            }
            catch (Exception e)
            {
                Mensaje.error(e.Message);
            }
        }

        protected void activarEstadoActualizar()
        {
            //this.btnGuardar.Enabled = false;
            this.btnGuardar.Text = "Actualizar";
            this.estadoGuardar = false;
            //this.rd_cedula.Enabled = false;
            //this.rd_ruc.Enabled = false;
        }

        public void llenarCampos(Persona persona)
        {
            //if (persona.Tipo == "N")this.rd_cedula.Checked = true;
            //else this.rd_ruc.Checked = true;
            this.txt_cedula.Text = persona.cedula;
            this.txt_ruc.Text = persona.ruc;
            this.txt_nombre.Text = persona.razon_social;
            this.txt_codigo.Text = persona.codigo;
            this.txt_telefono.Text = persona.telefonos;
            this.txt_email.Text = persona.email;
            this.txt_direccion.Text = persona.direccion;
            this.chk_extranjero.Checked = persona.es_extranjero;
        }

        private void txt_cedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.txt_cedula.Text.Trim().Length < 1)
                {
                    Mensaje.advertencia("Debe ingresar el campo cédula");
                    return;
                }
                this.buscarCliente(txt_cedula.Text);
            }
            if(!this.chk_extranjero.Checked)General.soloNumeros(e);
        }

        private void txt_fono_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.soloNumeros(e);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.guardar();
        }

        private void guardar()
        {
            if (!validar()) return;
            Persona persona = new Persona();
            persona.id = this.idCliente;
            persona.cedula= this.txt_cedula.Text.Trim();
            persona.ruc = this.txt_ruc.Text.Trim();
            persona.tipo = this.cmb_tipo.SelectedValue.ToString();
            if (persona.tipo == "N" && String.IsNullOrEmpty(persona.cedula) && persona.ruc.Length == 13) persona.cedula = persona.ruc.Substring(0, 10);
            persona.razon_social = txt_nombre.Text;
            persona.codigo = this.txt_codigo.Text;
            persona.telefonos = txt_telefono.Text;
            persona.email = txt_email.Text;
            persona.direccion = txt_direccion.Text;
            persona.es_cliente = true;
            persona.es_extranjero = this.chk_extranjero.Checked;
            ClienteTR tran = new ClienteTR(persona);
            string msn = "";
            if (estadoGuardar && tran.insertarCliente(ref msn)) //guardar
            {
                Mensaje.informacion("Cliente ingresado con éxito.");
                if (this.Owner.GetType() == typeof(frm_factura)) pasarDatosFactura();
                this.limpiar();
                txt_cedula.Focus();
            }
            else if (!estadoGuardar && tran.actualizarCliente(ref msn))
            {
                Mensaje.informacion("Cliente actualizado con éxito.");
                if (this.fila != null) pasarDatos();
                this.limpiar();
                txt_cedula.Focus();
            }
            else Mensaje.advertencia(msn);
        }

        protected void pasarDatosFactura()
        {
            frm_factura factura = (frm_factura)this.Owner;
            factura.setCedulaCliente((this.txt_cedula.Text.Trim().Length > 0)?this.txt_cedula.Text:this.txt_ruc.Text);
            this.Close();
        }

        protected void pasarDatos()
        {
            this.fila.Cells["Nombre"].Value = this.txt_nombre.Text;
            this.fila.Cells["Teléfono"].Value = this.txt_telefono.Text;
            this.fila.Cells["eMail"].Value = this.txt_email.Text;
            this.Close();
        }

        public bool validar()
        {
            if (cmb_tipo.SelectedValue.Equals("N"))
            {

                if (this.txt_cedula.Text.Trim().Length < 1 && this.txt_ruc.Text.Trim().Length < 1)
                {
                    Mensaje.faltaCampo("Debe ingresar cédula o ruc.");
                    txt_cedula.Focus();
                    return false;
                }

                if (this.txt_cedula.Text.Trim().Length > 0 && this.txt_cedula.Text.Trim().Length < 10 && !this.chk_extranjero.Checked)
                {
                    Mensaje.faltaCampo("El campo cédula debe tener 10 dígitos.");
                    txt_cedula.Focus();
                    return false;
                }

                if (this.txt_ruc.Text.Trim().Length > 0 && this.txt_ruc.Text.Trim().Length < 13 && !this.chk_extranjero.Checked)
                {
                    Mensaje.faltaCampo("El campo ruc debe tener 13 dígitos.");
                    txt_ruc.Focus();
                    return false;
                }
            }
            else {
                if (this.txt_ruc.Text.Trim().Length < 13)
                {
                    Mensaje.faltaCampo("Debe ingresar el campo ruc.");
                    txt_ruc.Focus();
                    return false;
                }
            
            }

            if (!this.chk_extranjero.Checked && this.validarIdentificacion)
            {
                if (!String.IsNullOrEmpty(this.txt_cedula.Text))
                {
                    if (!this.validarCedula(this.txt_cedula.Text))
                    {
                        Mensaje.faltaCampo("La cédula es incorrecta.");
                        txt_cedula.Focus();
                        return false;
                    }
                }
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
            /*if (this.txt_email.Text.Trim().Length < 1)
            {
                Mensaje.faltaCampo("Debe ingresar el campo email.");
                txt_email.Focus();
                return false;
            }*/
            if (this.txt_direccion.Text.Trim().Length < 1)
            {
                Mensaje.faltaCampo("Debe ingresar el campo dirección.");
                txt_direccion.Focus();
                return false;
            }

            return true;
        }

        private Boolean validarCorreo(String email)
        {
            if (email != "")
            {
                String expresion;
                expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                if (Regex.IsMatch(email, expresion))
                {
                    if (Regex.Replace(email, expresion, String.Empty).Length == 0)return true;
                    return false;
                    
                }
                return false;  
            }
            return true;
        }

        private void frm_Cliente_Load(object sender, EventArgs e)
        {
            this.validarIdentificacion = ParametroTR.ConsultarBool("validarIdentificacion");
            this.habilitarCodigo = ParametroTR.ConsultarBool("habilitarCodigoCliente");
            this.flp_codigoCliente.Visible = this.habilitarCodigo;
            this.Height = (this.habilitarCodigo)?419:388;
            
            this.llenarComboTipo(true);
            if (this.estadoGuardar)
            {
                if (this.txt_ruc.Text.Length > 0)this.cmb_tipo.SelectedIndex = 1;
                if (!String.IsNullOrEmpty(this.txt_ruc.Text) || !String.IsNullOrEmpty(this.txt_cedula.Text))
                {
                    this.txt_nombre.Focus();
                }
            }
        }

        protected void llenarComboTipo(bool cedula)
        {
            cmb_tipo.DataSource = null;
            cmb_tipo.Items.Clear();
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            if (cedula) data.Add(new KeyValuePair<string, string>("N", "Natural"));
            data.Add(new KeyValuePair<string, string>("J", "Jurídica"));
            cmb_tipo.DataSource = new BindingSource(data, null);
            cmb_tipo.DisplayMember = "Value";
            cmb_tipo.ValueMember = "Key";
            this.cmb_tipo.SelectedIndex = 0;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }

        protected void limpiar()
        {
            if (fila == null)
            {
                this.txt_cedula.Clear();
                this.txt_ruc.Clear();
            }
            this.cmb_tipo.SelectedIndex = 0;
            this.txt_nombre.Clear();
            this.txt_codigo.Clear();
            this.txt_telefono.Clear();
            this.txt_email.Clear();
            this.txt_direccion.Clear();
        }

        protected void activarEstadoGuardar()
        {
            this.btnGuardar.Enabled = true;
            this.btnGuardar.Text = "Guardar";
            this.estadoGuardar = true;
            this.txt_codigo.Clear();
            this.txt_direccion.Clear();
            this.txt_email.Clear();
            this.txt_nombre.Clear();
            this.txt_telefono.Clear();
        }


        private void cmb_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmb_tipo.SelectedIndex == 0)
            {
                this.txt_cedula.Enabled = true;
                //this.txt_cedula.Select();
            }
            if (cmb_tipo.SelectedIndex == 1)
            {
                this.txt_cedula.Enabled = false;
                this.txt_cedula.Clear();
                //this.txt_ruc.Select();
            }
        }


        private void txt_caracteres_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.sinCaracteresEspeciales(e);
        }

        private void txt_direccion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.guardar();
            }
        }

        private bool validarCedula(String ced)
        {
            int isNumeric;
            var total = 0;
            const int tamanoLongitudCedula = 10;
            int[] coeficientes = {2, 1, 2, 1, 2, 1, 2, 1, 2};
            const int numeroProvincias = 25;
            const int tercerDigito = 6;

            if (int.TryParse(ced, out isNumeric) && ced.Length == tamanoLongitudCedula)
            {
                var provincia = Convert.ToInt32(String.Concat(ced[0],ced[1],String.Empty));
                var digitoTres = Convert.ToInt32(ced[2] + String.Empty);
                if ((provincia > 0 && provincia <= numeroProvincias) && digitoTres < tercerDigito)
                {
                    var digitoVerificadorRecibido = Convert.ToInt32(ced[9] + String.Empty);
                    for (var k = 0; k < coeficientes.Length; k++)
                    {
                        var valor = Convert.ToInt32(coeficientes[k] + String.Empty) *
                                    Convert.ToInt32(ced[k] + String.Empty);
                        total = valor >= 10 ? total + (valor - 9) : total + valor;
                    }
                    var digitoVerificadorObtenido = total >= 10 ? (total % 10) != 0 ?
                                                    10 - (total % 10) : (total % 10) : total;
                    return digitoVerificadorObtenido == digitoVerificadorRecibido;
                }
                return false;
            }
            return false;
        }
        
    }
}
