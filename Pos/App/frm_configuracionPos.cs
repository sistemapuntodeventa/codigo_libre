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
using System.Management;
using Pos.Clases;
using System.Net.NetworkInformation;


namespace Pos.App
{
    public partial class frm_configuracionPos : Form
    {

        private int idConfPos = -1;
        private bool existePredeterminada = false;
        private bool estadoGuardar = true;
        public DataGridViewRow fila; 

        public frm_configuracionPos()
        {
            InitializeComponent();
        }

        public frm_configuracionPos(string codigo, DataGridViewRow fila)
        {
            InitializeComponent();
            this.idConfPos = Convert.ToInt32(codigo);
            this.fila = fila;
            this.estadoGuardar = false;
        }


        protected void buscarConfiguracion(int codigo)
        {
            String mensaje = "";
            ConfiguracionPosTR tran = new ConfiguracionPosTR();
            ConfiguracionPos configuracion = tran.consultarConfiguracion(codigo, ref mensaje);
            if (configuracion != null)
            {
                llenarCampos(configuracion);
                activarEstadoActualizar();

            }
            else
            {
                if (String.IsNullOrEmpty(mensaje)) Mensaje.advertencia("No se encontró el establecimiento.");
                else Mensaje.error(mensaje);
            }
        }

        protected void llenarCampos(ConfiguracionPos configuracion){
            this.cmb_establecimiento.SelectedValue = configuracion.Id_establecimiento;
            if (configuracion.Tipo_doc == "F") this.rd_factura.Checked = true;
            else if (configuracion.Tipo_doc == "N") this.rd_notaVenta.Checked = true;
            else if (configuracion.Tipo_doc == "G") this.rd_guia.Checked = true;
            else this.rd_dna.Checked = true;
            this.cmb_autorizacion.SelectedValue = configuracion.IdAutorizacion;
            if (configuracion.Activar_secuencia) this.rdb_usarSecuenciaSI.Checked = true;
            else this.rdb_usarSecuenciaNo.Checked = true;
            this.txt_ptoEmision.Text = configuracion.Pto_emision.ToString();
            this.txt_secuencial.Text = configuracion.Sec_inicio.ToString();
            this.txt_final.Text = configuracion.Sec_final.ToString();
            this.txt_actual.Text = configuracion.Sec_actual.ToString();
            this.chk_stock.Checked = configuracion.Stock;
            this.chk_servicio.Checked = configuracion.Servicio;
            this.chk_secuenciaImprimir.Checked = configuracion.SecuenciaAlImprimir;
            this.chk_sinCobro.Checked = configuracion.Sin_cobro;
            this.chk_predeterminada.Checked = configuracion.Predeterminada;
            this.actualizarDocumentoActual();
        }

        protected void activarEstadoActualizar() {
            this.btn_guardar.Text = "Actualizar";
        }

        private void frm_configuracionPos_Load(object sender, EventArgs e)
        {
            cargarEstablecimientos();
            if (estadoGuardar)
            {
                this.rdb_usarSecuenciaSI.Checked = true;
                this.cmb_autorizacion.SelectedIndex = -1;
            }
            else this.buscarConfiguracion(this.idConfPos);
            this.existePredeterminada = ConfiguracionPosTR.existePredeterminada(this.idConfPos,"F");
            if (this.estadoGuardar && !this.existePredeterminada) this.chk_predeterminada.Checked = true;
            //particular
            //this.chk_sinCobro.Visible = false;
        }

        protected void cargarEstablecimientos()
        {
            EstablecimientoTR estb = new EstablecimientoTR();
            string msn = "";
            DataTable datos = estb.consultarEstablecimiento(ref msn);
            if (datos != null)
            {
                this.cmb_establecimiento.DataSource = datos;
                this.cmb_establecimiento.ValueMember = "id";
                this.cmb_establecimiento.DisplayMember = "nombre";
                this.cmb_establecimiento.SelectedIndex = -1;
                this.txt_documento.Clear();

                this.txt_maquina.Text = IPGlobalProperties.GetIPGlobalProperties().HostName; ;
                this.rd_factura.Checked = true;
            }
            else Mensaje.error(msn);
        }


        private void txt_inicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.soloNumeros(e);
        }

   

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            this.existePredeterminada = ConfiguracionPosTR.existePredeterminada(this.idConfPos, this.getTipoDocumento());
            if (!this.existePredeterminada) this.chk_predeterminada.Checked = true;
            if (!validar()) return;
            int reemplazarPredeterminada = 0;
            if ((!this.estadoGuardar && (!this.existePredeterminada && this.chk_predeterminada.Checked)) || (chk_predeterminada.Checked && this.existePredeterminada && Mensaje.confirmacion("Actualmente existe una configuración predeterminada para esta máquina.\n Desea usar esta como predeterminada?")))
            {
                reemplazarPredeterminada = 1;
            }
            ConfiguracionPos config = tomarDatos();
            ConfiguracionPosTR tran = new ConfiguracionPosTR(config);

            string mensaje = "";
            if (!this.rd_dna.Checked && this.rdb_usarSecuenciaSI.Checked)
            {
                List<string> facturas = tran.validarRango(ref mensaje);
                if (!String.IsNullOrEmpty(mensaje))
                {
                    Mensaje.advertencia(mensaje);
                    return;
                }
                if (facturas != null)
                {
                    string nombreTipo = (this.rd_factura.Checked) ? "facturadas" : "emitidas";
                    frm_Mensaje pregunta = new frm_Mensaje("Las siguente secuencias ya han sido " + nombreTipo + " y se omitirán\n Desea continuar?", facturas);
                    pregunta.Owner = this;
                    if (pregunta.ShowDialog() == DialogResult.Cancel) return;
                }
            }
           // Mensaje.advertencia("Debo continuar.");
           // return;

            tran.refrescar();

            if (estadoGuardar && tran.insertarConfPOS(ref mensaje, reemplazarPredeterminada))
            {
                Mensaje.informacion("Configuración ingresada con éxito.");
                this.Close();
                //this.limpiar();
                //this.cmb_establecimiento.Select();
            }
            else if (!estadoGuardar && tran.actualizarConfPOS(ref mensaje, reemplazarPredeterminada))
            {
                Mensaje.informacion("Configuración actualizada con éxito.");
                if (this.fila != null) pasarDatos((reemplazarPredeterminada == 1));
                
            }
            else Mensaje.error(mensaje);
            
        }

        protected void pasarDatos(bool predeterminada) {
            this.fila.Cells["Establecimiento"].Value = this.cmb_establecimiento.Text;
            this.fila.Cells["Secuencia Inicial"].Value = this.txt_documento.Text;
            if(this.rd_factura.Checked) this.fila.Cells["Tipo Documento"].Value = "FACTURA";
            else if (this.rd_notaVenta.Checked) this.fila.Cells["Tipo Documento"].Value = "NOTA DE VENTA";
            else if (this.rd_guia.Checked) this.fila.Cells["Tipo Documento"].Value = "GUÍA DE REMISIÓN";
            else this.fila.Cells["Tipo Documento"].Value = "DNA";

            if (predeterminada)
            {
                frm_editarPos editarConf = (frm_editarPos)this.Owner;
                editarConf.limpiarPredeterminada();
                this.fila.Cells["Predeterminada"].Value = "SI";
            }
            else this.fila.Cells["Predeterminada"].Value = "NO";
            this.Close();
        }

        private string getTipoDocumento()
        {
            if (this.rd_factura.Checked) return "F";
            if (this.rd_notaVenta.Checked) return "N";
            if (this.rd_guia.Checked) return "G";
            return "D";  
        }

        private ConfiguracionPos tomarDatos()
        {
            ConfiguracionPos config = new ConfiguracionPos();

            config.Idconf_pos = this.idConfPos;
            if (this.cmb_establecimiento.SelectedValue != null)config.Id_establecimiento = (int)this.cmb_establecimiento.SelectedValue;
            config.Nombre_Maquina = General.getComputerName().Trim(); ;
            config.Tipo_doc = this.getTipoDocumento();

            if (!rd_dna.Checked)
            {
                if (this.cmb_autorizacion.SelectedValue != null)
                {
                    config.Autorizacion = this.cmb_autorizacion.Text;
                    config.IdAutorizacion = (int)this.cmb_autorizacion.SelectedValue;
                }

                config.Codigo_establecimiento = this.txt_codigoEmision.Text;
                config.Pto_emision = this.txt_ptoEmision.Text;
                if (!String.IsNullOrEmpty(this.txt_final.Text)) config.Sec_final = int.Parse(this.txt_final.Text);
                config.Secuencia_doc = this.txt_documento.Text;
                config.SecuenciaAlImprimir = this.chk_secuenciaImprimir.Checked;
            }

            if (this.rdb_usarSecuenciaSI.Checked)
            {
                config.Activar_secuencia = true;
                config.Sec_inicio = Convert.ToInt32(this.txt_secuencial.Text);
                config.Secuencial = this.txt_secuencial.Text;
                if (!String.IsNullOrEmpty(this.txt_actual.Text)) config.Sec_actual = int.Parse(this.txt_actual.Text);
            }
            
            config.Sin_cobro = this.chk_sinCobro.Checked;
            config.Stock = this.chk_stock.Checked;
      
            config.Servicio = this.chk_servicio.Checked;
            config.Predeterminada = this.chk_predeterminada.Checked;
            return config;
        }
  public bool validar()
        {
            if (this.cmb_establecimiento.SelectedIndex == -1)
            {
                Mensaje.faltaCampo("Debe seleccionar el establecimiento");
                cmb_establecimiento.Focus();
                return false;
            }
            if (!rd_dna.Checked)// si tiene seleccionado factura o nota de venta
            {
                if (this.cmb_autorizacion.SelectedIndex == -1)
                {
                    Mensaje.faltaCampo("Debe ingresar el campo autorización.");
                    cmb_autorizacion.Focus();
                    return false;
                }

                if (txt_ptoEmision.Text.Trim().Length < 1)
                {
                    Mensaje.faltaCampo("Debe ingresar el campo Punto de Emisión.");
                    cmb_autorizacion.Focus();
                    return false;
                }

                if (rdb_usarSecuenciaSI.Checked)// si tiene activado usar secuencia
                {
   
                    if (txt_secuencial.Text.Trim().Length < 1)
                    {
                        Mensaje.faltaCampo("Debe ingresar el campo Secuencia Inicio.");
                        cmb_autorizacion.Focus();
                        return false;
                    }
                    if (txt_final.Text.Trim().Length < 1)
                    {
                        Mensaje.faltaCampo("Debe ingresar el campo Secuencia Fin.");
                        cmb_autorizacion.Focus();
                        return false;
                    }
                    if (Convert.ToInt64(txt_secuencial.Text) >= Convert.ToInt64(txt_final.Text))
                    {
                        Mensaje.advertencia("La secuencia final debe ser mayor a la inicial");
                        this.txt_secuencial.Select();
                        return false;
                    }
                }

            }
            return true;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void txt_codigoEmision_KeyUp(object sender, KeyEventArgs e)
        {
            this.actualizarDocumentoActual();
        }

        private void txt_ptoEmision_KeyUp(object sender, KeyEventArgs e)
        {
            this.actualizarDocumentoActual();
        }

        private void txt_secuencial_KeyUp(object sender, KeyEventArgs e)
        {
            this.actualizarDocumentoActual();
            this.txt_actual.Text = this.txt_secuencial.Text;
        }

        protected void actualizarDocumentoActual()
        {
            if (this.rd_dna.Checked)
            {
                this.txt_documento.Text = this.txt_secuencial.Text;
            }
            else
            {
                this.txt_documento.Text = ponerDigitos(3, this.txt_codigoEmision.Text) + "-" +
                                            ponerDigitos(3, this.txt_ptoEmision.Text) + "-" +
                                            ponerDigitos(9, this.txt_secuencial.Text);
            }
        }

        public string ponerDigitos(int numero,string cadena)
        {
            int restante= numero - cadena.Length;
            String relleno = "";
            if (restante > 0){
                for (int i = 0; i < restante; i++){
                    relleno = relleno + "0";}
            }
            return (relleno + cadena);
        }

        
        private void cmb_establecimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmb_establecimiento.SelectedIndex == -1)
            {
                txt_codigoEmision.Clear();
                this.cmb_autorizacion.DataSource = null;
                this.cmb_autorizacion.Items.Clear();
                this.cmb_autorizacion.SelectedIndexChanged -= cmb_autorizacion_SelectedIndexChanged;
                return;
            }
            if(!this.cmb_establecimiento.SelectedValue.ToString().Equals("System.Data.DataRowView"))
            {
               

                if (rd_dna.Checked) return;
                this.cargarTextoDocumento();
                DataSet result = new DataSet();
                AutorizacionTR aut = new AutorizacionTR();
                int idEstablecimiento = (int)this.cmb_establecimiento.SelectedValue;

                string mensaje = "";
                DataTable datos = aut.consultarAutorizacion(idEstablecimiento,ref mensaje);
                if (datos != null)
                {
                    this.txt_final.Clear();
                    this.txt_secuencial.Clear();
                    this.actualizarDocumentoActual();
                    this.cmb_autorizacion.SelectedIndexChanged -= cmb_autorizacion_SelectedIndexChanged;
                    this.cmb_autorizacion.DataSource = datos;
                    this.cmb_autorizacion.ValueMember = "idtbl_autorizacion";
                    this.cmb_autorizacion.DisplayMember = "autorizacion";
                    this.cmb_autorizacion.SelectedIndex = -1;
                    this.cmb_autorizacion.SelectedIndexChanged += cmb_autorizacion_SelectedIndexChanged;
                }
                else Mensaje.error(mensaje);
            }
        }

        protected void cargarTextoDocumento() {
            if (cmb_establecimiento.SelectedIndex == -1) return;
            this.txt_codigoEmision.Text = this.cmb_establecimiento.SelectedValue.ToString();
            this.txt_documento.Text = ponerDigitos(3, this.txt_codigoEmision.Text) + "-" +
                   ponerDigitos(3, this.txt_ptoEmision.Text) + "-" +
                   ponerDigitos(9, this.txt_secuencial.Text);
        }

        private void chk_secuencial_CheckedChanged(object sender, EventArgs e)
        {

                this.txt_secuencial.Text = "";
                this.txt_final.Text = "";
                //this.txt_inicio.Text = "";             
                this.txt_final.Enabled = true;
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.cambiarEstadosControles();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.cambiarEstadosControles();
        }

        protected void cambiarEstadosControles()
        {

            if (this.rdb_usarSecuenciaSI.Checked)
            {
                this.txt_ptoEmision.Enabled = !this.rd_dna.Checked;
                this.txt_secuencial.Enabled = true;
                this.txt_final.Enabled = !this.rd_dna.Checked;
                this.chk_secuenciaImprimir.Enabled = true;
            }
            if (this.rdb_usarSecuenciaNo.Checked)
            {
                //this.txt_ptoEmision.Enabled = false;
                this.txt_secuencial.Enabled = false;
                this.txt_final.Enabled = false;
                this.chk_secuenciaImprimir.Enabled = false;
                this.txt_actual.Clear();
                //this.txt_codigoEmision.Clear();
                //this.txt_documento.Text = ponerDigitos(3, this.txt_codigoEmision.Text) + "-" + ponerDigitos(3, this.txt_ptoEmision.Text) + "-" + ponerDigitos(9, "0");
            }

            if (this.rd_dna.Checked)
            {
                this.txt_secuencial.Clear();
                this.txt_final.Clear();

                this.cmb_autorizacion.SelectedIndex = -1;
                this.txt_ptoEmision.Clear();
                this.txt_codigoEmision.Clear();
                this.txt_documento.Clear();
            }

            if (this.rd_guia.Checked)
            {
                this.chk_sinCobro.Checked = false;
                this.chk_secuenciaImprimir.Checked = false;
                this.chk_servicio.Checked = false;
                this.chk_stock.Checked = false;
                this.chk_sinCobro.Enabled = false;
                this.chk_secuenciaImprimir.Enabled = false;
                this.chk_servicio.Enabled = false;
                this.chk_stock.Enabled = false;
            }
            else
            {
                this.chk_sinCobro.Enabled = true;
                this.chk_secuenciaImprimir.Enabled = true;
                this.chk_servicio.Enabled = true;
                this.chk_stock.Enabled = true;
            
            }
        }

        private void cmb_autorizacion_SelectedIndexChanged(object sender, EventArgs e)
        
        {
            if (this.cmb_autorizacion.SelectedIndex != -1)
            {
                if (rd_dna.Checked || rdb_usarSecuenciaNo.Checked) return;
                String mensaje = "";
                AutorizacionTR tran = new AutorizacionTR();
                int idAutorizacion = Convert.ToInt32(this.cmb_autorizacion.SelectedValue.ToString());
                Autorizacion autorizacion = tran.consultarSecuencias(ref mensaje, idAutorizacion);
                if (autorizacion != null)
                {
                    this.txt_secuencial.Text = autorizacion.SecuenciaInicio;
                    this.txt_final.Text = autorizacion.SecuenciaFin;
                    this.actualizarDocumentoActual();
                }
                else Mensaje.error(mensaje);
            }
          

        }

        private void rd_dna_CheckedChanged(object sender, EventArgs e)
        {
            //if (rd_dna.Checked) this.noUsarFactura();
            //else this.usarFactura();
            this.cambiarEstadosControles();
        }

        protected void usarFactura() {
            this.cmb_autorizacion.Enabled = true;
            this.rdb_usarSecuenciaSI.Checked = true;
            this.rdb_usarSecuenciaSI.Enabled = true;
            this.rdb_usarSecuenciaNo.Enabled = true;
            this.txt_ptoEmision.Enabled = true;
            this.txt_secuencial.Enabled = true;
            this.txt_final.Enabled = true;
            cargarTextoDocumento();
        }


        protected void noUsarFactura() {
            this.cmb_autorizacion.Enabled = false;
            this.cmb_autorizacion.SelectedIndex = -1;

            this.rdb_usarSecuenciaSI.Checked = false;
            this.rdb_usarSecuenciaSI.Enabled = false;

            this.rdb_usarSecuenciaNo.Checked = false;
            this.rdb_usarSecuenciaNo.Enabled = false;

            this.txt_codigoEmision.Clear();

            this.txt_ptoEmision.Enabled = false;
            this.txt_ptoEmision.Clear();

            this.txt_secuencial.Enabled = false;
            this.txt_secuencial.Clear();

            this.txt_final.Enabled = false;
            this.txt_final.Clear();

            this.txt_actual.Clear();

            this.txt_documento.Clear();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }


        protected void limpiar() {
            this.cmb_establecimiento.SelectedIndex = -1;
            this.cmb_autorizacion.Enabled = true;

            this.rd_factura.Checked = true;

            this.rdb_usarSecuenciaSI.Checked = true;
            this.rdb_usarSecuenciaSI.Enabled = true;
            this.rdb_usarSecuenciaNo.Enabled = true;

            this.txt_ptoEmision.Enabled = true;
            this.txt_secuencial.Enabled = true;
            this.txt_final.Enabled = true;

            this.txt_codigoEmision.Clear();
            this.txt_ptoEmision.Clear();
            this.txt_secuencial.Clear();
            this.txt_final.Clear();
            this.txt_actual.Clear();
            this.txt_documento.Clear();
            this.chk_stock.Checked = false;
            this.chk_sinCobro.Checked = false;
            this.chk_servicio.Checked = false;
        
        }

        private void chk_sinCobro_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rd_notaVenta_CheckedChanged(object sender, EventArgs e)
        {
            this.cambiarEstadosControles();
        }

        private void rd_factura_CheckedChanged(object sender, EventArgs e)
        {
            this.cambiarEstadosControles();
        }

        private void cmb_autorizacion_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void rd_guia_CheckedChanged(object sender, EventArgs e)
        {
            this.cambiarEstadosControles();
        }

       
    }
}
