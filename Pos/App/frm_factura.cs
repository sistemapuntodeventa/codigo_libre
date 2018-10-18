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
using System.Globalization;
using TestLib;
using System.Threading;
using Pos.ClasesImpresion;

namespace Pos.App
{

    public partial class frm_factura : Form
    {
        //Datos Factura
        private ConfiguracionPos confPredeterminada;
        private int idCliente = 0;
        private int idCaja;
        private int idFactura;
        private string clienteTelefono;
        private string clienteDireccion;
        private string descripcionProducto;

        //Control
        bool impresoraDisponible = false;
        bool terminoSecuencia = false;
        private bool puedoEscribir = true;
        public bool deboBuscar = true;
        private bool estadoGuardar = true;
        private bool facturaPagada = false;
        private string pvpManual = "";
        //private bool seImprimio = false;
        //private bool sePuedeAnular = false;

        //Autocompletar
        AutoCompleteStringCollection autoComplete;
        AutoCompleteStringCollection autoCompleteCodigo;

        //Permisos
        private bool vueltoCheque;
        private bool vueltoCredito;
        private bool seleccionarVendedor;
        private bool propina;
        private bool anularFactura;
        private bool modificarDiferenteCaja;

        //Parámetros
        private string codigoBarra = "";
        int cantidadDecimales = Global.cantidadDecimales;
        List<TextBox> listaControles = null;
        private int prefijo1;
        private int prefijo2;
        private int deTicket;
        private int espaciosArriba;
        private int espaciosItems;
        private int espaciosAbajo;
        private int espaciosDCorte;
        private int separacionLinea;
        private int caracteresProducto;
        private int copiasFactura;
        private int copiasFactura2;
        private bool imprimirDescripcion;
        private int adicionalPendiente;
        private int? idUsuarioAnular;
        private string impresora2;
        private string facturaDescripcion;
        private bool imprimirValores;
        private bool pagoParcial;
        private bool generarCorte;
        private bool imprimirUbicaciones;
        private List<FormaPago> pagos = null;
        private List<FormaPago> pagosEliminados = null;
        private bool habilitarCodigoCliente = false;
        private bool habilitarVentasDeudores = true;
        private bool habilitarProductoSerie = false;
        private bool habilitarCampoEdicion = false;
     

        //Adicionales & Promociones
        private List<PromocionFactura> promociones = null;
        private List<Ubicacion> ubicaciones = null;
        private List<Control> controlesAdicionales;
        private List<FacturaDetalle> productosEliminados = null;
        private decimal? descuentoFactura = 0;
        private decimal subtotalEliminado = 0;
        //Facturas Pendientes
        private Font letra;
        private bool formularioPendientes = false;

        public frm_factura()
        {
            InitializeComponent();
        }

        public void setIdFactura(int idFactura, bool anular)
        {
            this.txt_secuencia.Text = idFactura.ToString();
            this.buscarFactura(idFactura);
            this.setearCeldaActiva("producto", this.grw_productos.RowCount -1, true);
        }

        public void setCedulaCliente(String cedula)
        {
            this.txt_ruc.Text = cedula;
            this.buscarCliente(cedula);
        }


        public void setNumeroDocumento(String documento)
        {
            this.txt_numDoc.Text = documento;
            
        }

        protected void llenarComboEstado()
        {
            List<ComboboxItem> lista = new List<ComboboxItem>();
            this.cmb_estado.DataSource = null;
            this.cmb_estado.Items.Clear();

            lista.Add(new ComboboxItem("COBRADA", "C"));
            if (this.confPredeterminada.Sin_cobro)lista.Add(new ComboboxItem("PENDIENTE", "P"));
            lista.Add( new ComboboxItem("ANULADA","A"));  

            this.cmb_estado.ValueMember = "Value";
            this.cmb_estado.DisplayMember = "Text";
            this.cmb_estado.DataSource = lista;
        }

        public void mostrarPendientes()
        {
            this.grb_pendientes.Visible = true;
            this.grb_pendientes.Width = 151;
            this.Width += 151;
            this.tmi_pendientes.Text = "Ocultar Pendientes";
        }

        protected void bloquearFactura()
        {
            this.btn_buscar.Enabled = false;
            this.menu.Enabled = false;
            //this.tsb_guardar.Enabled = false;
        }

        private void frm_factura_Load(object sender, EventArgs e)
        {
            //try
            //{
                string msn = "";
                this.formularioPendientes = true;
                this.chk_todoEfectivo.Visible = false;
                this.impresoraDisponible = Impresion.IsPrinterOnline(Global.nombreImpresora);
                confPredeterminada = ConfiguracionPosTR.consultarConfiguracionPredeterminada(General.getComputerName(), ref msn);

                llenarComboTarjetasCredito();
                if (confPredeterminada == null)
                {
                    if (String.IsNullOrEmpty(msn)) Mensaje.advertencia("Debe configurar el Punto de venta y abrir caja para facturar.");
                    else Mensaje.error("Configuración Predeterminada: " +  msn);
                    this.bloquearFactura();
                    return;
                }

                Caja caja = CajaTR.verEstadoCaja(confPredeterminada.Idconf_pos, "A");    
                if (caja == null)
                {
                    Mensaje.advertencia("Debe abrir caja para poder facturar.");
                    this.bloquearFactura();
                    return;
                }

                this.idCaja = caja.Id;
                // imprimirFactura();
                int posFacturaX,posFacturaY;                      //0,1,2,3,4,5,6 ,7 ,8, 9 ,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32
                List<object> parametros = ParametroTR.ConsultarInt("4,5,6,7,8,9,10,11,12,15,16,25,28,29,30,33,35,36,37,38,39,40,43,44,45,46,51,54,55,57,58,59,60");
                if (parametros != null)
                {
                    this.prefijo1 = Convert.ToInt32(parametros[0]);
                    this.prefijo2 = Convert.ToInt32(parametros[1]);
                    this.deTicket = Convert.ToInt32(parametros[2]);
                    this.espaciosArriba = Convert.ToInt32(parametros[3]);
                    this.espaciosItems = Convert.ToInt32(parametros[4]);
                    this.espaciosAbajo = Convert.ToInt32(parametros[5]);
                    this.espaciosDCorte = Convert.ToInt32(parametros[6]);
                    this.separacionLinea = Convert.ToInt32(parametros[7]);
                    this.caracteresProducto = Convert.ToInt32(parametros[8]);
                    this.copiasFactura = Convert.ToInt32(parametros[9]);
                    this.imprimirDescripcion = parametros[10].Equals("1");
                    this.adicionalPendiente = Convert.ToInt32(parametros[11]);

                    this.facturaDescripcion = parametros[21].ToString();

                    if (this.prefijo1 != -1 || this.prefijo2 != -1) this.KeyPreview = true;
                    posFacturaX = Convert.ToInt32(parametros[12]);
                    posFacturaY = Convert.ToInt32(parametros[13]);

                    if (parametros[16].Equals("1")) this.tmi_tipoDocumento.Checked = true;
                    else this.flp_tipoDocumento.Visible = false;

                    if (parametros[17].Equals("1")) this.tmi_autorizacion.Checked = true;
                    else this.flp_autorizacion.Visible = false;

                    if (parametros[18].Equals("1")) this.tmi_fechaVencimiento.Checked = true;
                    else this.flp_fechaVencimiento.Visible = false;

                    if (parametros[19].Equals("1")) this.tmi_descripcion.Checked = true;
                    else this.flp_descripcion.Visible = false;

                    if (parametros[27].Equals("1")) this.mostrarDescripcionProducto();
                    else this.ocultarDescripcionProducto();

                    if (parametros[15].Equals("1"))
                    {
                        this.tsb_guia.Visible = true;
                        this.tls_guia.Visible = true;
                    }

                    this.impresora2 = parametros[14].ToString();
                    this.copiasFactura2 = Convert.ToInt32(parametros[22]);
                    this.imprimirValores = parametros[23].Equals("1");
                    this.modificarDiferenteCaja = parametros[24].Equals("1");
                    this.pagoParcial = parametros[25].Equals("1");
                    this.generarCorte = parametros[26].Equals("1");
                    this.imprimirUbicaciones = parametros[28].Equals("1");
                    this.habilitarCampoEdicion = parametros[29].Equals("1");
                    this.habilitarCodigoCliente = parametros[30].Equals("1");
                    this.habilitarVentasDeudores = parametros[31].Equals("1");

                    if (parametros[32].Equals("1"))
                    {
                        this.habilitarProductoSerie = true;
                        this.grw_productos.Columns["serie"].Visible = true;
                    }
                    
                }
                else
                {
                    Mensaje.error("Parámetros: " + msn);
                    this.bloquearFactura();
                    return;
                }

                this.descripcionProducto = this.habilitarCampoEdicion ? caja.Edicion.ToShortDateString() : "";
                Permiso permiso = PermisoTR.consultar(ref msn, Global.idRol);
                if (!permiso.dna)
                {
                    this.chk_dna.Visible = false;
                    this.txt_tipo.Width = 180;
                }
                if (!permiso.descuento)
                {
                    this.chk_descProd.Visible = false;
                    this.txt_descProducto.Width = 180;
                    this.grw_productos.Columns["pdesc"].ReadOnly = true;
                }

                if (!permiso.notaCredito) this.tco_formaPago.TabPages.RemoveAt(4);
                this.vueltoCheque = permiso.vueltoCheque;
                this.vueltoCredito = permiso.vueltoCredito;
                this.seleccionarVendedor = permiso.SeleccionarVendedor;
                this.anularFactura = permiso.anularFactura;
                this.propina = permiso.Propina;
                if (!this.propina)
                {
                    this.label27.Visible = false;
                    this.txt_propina.Visible = false;
                }

                if (seleccionarVendedor)
                {
                    this.cmb_vendedor.DataSource = EmpleadoTR.obtenerVendedores();
                    cmb_vendedor.DisplayMember = "Text";
                    cmb_vendedor.ValueMember = "Value";
                }
                else
                {
                    this.cmb_vendedor.Visible = false;
                    this.lbl_vendedor.Visible = false;
                }

                if (!this.confPredeterminada.Sin_cobro)
                {
                    this.toolStripSeparator1.Visible = false;
                    this.tsb_guardar.Visible = false;
                }

                if (this.pagoParcial)
                {
                    this.tco_formaPago.Controls.Remove(this.tab_cheque);
                    this.tco_formaPago.Controls.Remove(this.tab_efectivo);
                    this.tco_formaPago.Controls.Remove(this.tab_notaCredito);
                    this.tco_formaPago.Controls.Remove(this.tab_retencion);
                    this.tsb_reversar.Enabled = false;
                }
                else
                {
                    this.tco_formaPago.Controls.Remove(this.tab_abono);
                    this.tsb_reversar.Visible= false;
                }
 
                //this.estadoInicial(true);
                this.cargarAdicionales();
                this.promociones = PromocionTR.consultarDiaria();
                this.ubicaciones = UbicacionTR.listadoUbicaciones();
                this.productosEliminados = new List<FacturaDetalle>();
                this.estadoInicial(true);


                letra = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular);
                List<object[]> facturas = FacturaCabeceraTR.consultarFacturasPendientes(this.adicionalPendiente);
                if (facturas != null) foreach (object[] dato in facturas) this.agregarPendiente(dato[0].ToString(), dato[1].ToString(), Convert.ToBoolean(dato[2]));
            //}
            //catch (Exception error)
            //{
            //    Mensaje.error("General:" + error.Message);
            //    this.bloquearFactura();
            //}

        }

        public void ocultarDescripcionProducto()
        {
            this.grw_productos.Columns["codigo"].Width = 120;
            this.grw_productos.Columns["producto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.grw_productos.Columns["descripcion"].Visible = false;
        }

        public void mostrarDescripcionProducto()
        {
            this.grw_productos.Columns["codigo"].Width = 120;
            this.grw_productos.Columns["producto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.grw_productos.Columns["producto"].Width = 300;
            this.tmi_descripcionProducto.Checked = true;
            this.grw_productos.Columns["descripcion"].Visible = true;
        }

        #region pendientes

        public void agregarPendiente(string id, string nombre, bool imprimio)
        {
            Button boton = new Button();
            boton.Text = nombre;
            boton.Width = (this.habilitarCodigoCliente)?120:62;
            boton.Height = 31;
            boton.Font = this.letra;
            boton.TextAlign = ContentAlignment.MiddleRight;
            if (this.habilitarCodigoCliente && !imprimio) boton.Image = Pos.Properties.Resources.factura_pendiente;
            else
            {
                boton.Image = (imprimio) ? Pos.Properties.Resources.factura : Pos.Properties.Resources.comida;
            }
            boton.ImageAlign = ContentAlignment.MiddleLeft;
            boton.Name = "b" + id.ToString();
            boton.Click += boton_pendienteClick;
            boton.FlatStyle = FlatStyle.Flat;
            boton.Margin = new Padding(4);
            this.flp_pendientes.Controls.Add(boton);
        }

        public void modificarPendiente(string id, string nombre, bool imprimio)
        {
            Control[] controles = this.flp_pendientes.Controls.Find("b" + id.ToString(), false);
            if (controles != null)
            {
                Control control = controles[0];
                Button boton = (Button)control;
                boton.Text = nombre;
                if (imprimio) boton.Image = Pos.Properties.Resources.factura;
            }
        }

        public void removerPendiente(string id)
        {
            Control control = this.flp_pendientes.Controls["b" + id];
            if (control != null) this.flp_pendientes.Controls.Remove(control);
        }

        private void boton_pendienteClick(object sender, EventArgs e)
        {
            int idFactura = Convert.ToInt32(((Button)sender).Name.Substring(1));
            //((frm_factura)this.Owner).Focus();
            this.setIdFactura(idFactura, true);

        }

        #endregion

        protected void cargarAdicionales()
        {
            string msn = "";
            AdicionalTR tranAdicional = new AdicionalTR();
            List<Adicional> adicionales = tranAdicional.cargarAdicionales("A");
            if (adicionales != null)
            {
                bool primero = true;
                controlesAdicionales = new List<Control>();
                foreach (Adicional adicional in adicionales)
                {
                    Control nuevoControl;
                    FlowLayoutPanel panel = new FlowLayoutPanel();
                    panel.Margin = new Padding(0);
                    panel.Padding = new Padding(2);
                    panel.FlowDirection = FlowDirection.RightToLeft;
                    panel.Width = 286;
                    panel.Height = 30;
                    //panel.BackColor = (primero)?Color.Yellow:Color.Red;

                    int anchoControl = 180;
                    int anchoBusqueda = 152;
                    primero = false;

                    Label label = new Label();
                    label.Name = "lad_" + adicional.idAdicional.ToString();
                    label.Padding = new Padding(0, 3, 0, 0);
                    label.Text = adicional.etiqueta;
                    label.ForeColor = Color.FromArgb(80, 80, 80);
                    label.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
                    label.AutoSize = true;

                    if (adicional.tipo == "C")
                    {
                        ComboBox combo1 = new ComboBox();
                        combo1.DropDownStyle = ComboBoxStyle.DropDownList;
                        combo1.Width = anchoControl;
                        adicional.items.Insert(0, "");
                        combo1.DataSource = adicional.items;
                        nuevoControl = combo1;
                        panel.Controls.Add(combo1);
                    }
                    else if (adicional.tipo == "F")
                    {
                        DateTimePicker dtp_nuevo = new DateTimePicker();
                        dtp_nuevo.Width = anchoControl;
                        nuevoControl = dtp_nuevo;
                        panel.Controls.Add(dtp_nuevo);
                    }
                    else
                    {
                        TextBox texto1 = new TextBox();
                        if (adicional.tipo == "B")
                        {
                            texto1.Width = anchoBusqueda;
                            texto1.BackColor = Color.White;
                            texto1.Enabled = false;
                            texto1.MaxLength = 100;
                            //Botón de búsqueda
                            if (!primero)
                            {
                                Button botonBusqueda = new Button();
                                botonBusqueda.Name = "b" + adicional.idAdicional.ToString();
                                botonBusqueda.Width = 22;
                                botonBusqueda.Height = 23;
                                botonBusqueda.Image = Pos.Properties.Resources.buscar_lupa;
                                botonBusqueda.BackColor = Color.FromArgb(231, 243, 252);
                                botonBusqueda.Click += button1_Click_1;
                                panel.Controls.Add(botonBusqueda);
                            }
                        }
                        else texto1.Width = anchoControl;
                        panel.Controls.Add(texto1);
                        if (!primero) texto1.KeyUp += adicional_KeyUp;
                        nuevoControl = texto1;
                    }

                    nuevoControl.Name = "ad" + adicional.idAdicional.ToString();
                    nuevoControl.CausesValidation = adicional.obligatorio;
                    nuevoControl.AccessibleName = adicional.nombre;
                    controlesAdicionales.Add(nuevoControl);
                    panel.Controls.Add(label);
                    this.flp_datosFactura.Controls.Add(panel);
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(msn))
                {
                    Mensaje.error(msn);
                    this.bloquearFactura();
                }

            }
        }


        private void adicional_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox caja = (TextBox)sender;
            if (String.IsNullOrEmpty(caja.Text)) return;
            int mesa;
            if (!Int32.TryParse(caja.Text, out mesa)) return;
            if (mesa >= 111 && mesa <= 120) this.chk_servicio.Checked = false;
            else this.chk_servicio.Checked = true;
        }

        private void txt_adicional_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Mensaje.advertencia(((TextBox)sender).Name.Substring(2));
            }
        }

        public void setValorAdicional(int idAdicional, string valor)
        {
            //TextBox cajaTexto = (TextBox)controlesAdicionales[indice-1];
            //cajaTexto.Text = valor;
            foreach (Control control in controlesAdicionales)
            {
                if (control.Name == "ad" + idAdicional.ToString())
                {
                    control.Text = valor;
                }
            }
        }

        protected void estadoInicial(bool inicio = false)
        {
            
            if (!inicio && (this.estadoGuardar || this.confPredeterminada.SecuenciaAlImprimir))
            {
                string mensaje = "";        
                confPredeterminada = ConfiguracionPosTR.consultarConfiguracionPredeterminada(General.getComputerName(), ref mensaje);
            }

            if (this.confPredeterminada.Tipo_doc != "D" && (this.confPredeterminada.Activar_secuencia && this.confPredeterminada.Sec_actual > this.confPredeterminada.Sec_final))
            {
                if (inicio || !terminoSecuencia)
                {
                    string documento = (this.confPredeterminada.Tipo_doc == "F") ? "facturas" : "nota de ventas";
                    Mensaje.advertencia("La secuencia de " + documento + " ha terminado.");
                    terminoSecuencia = true;
                }
                this.tsb_imprimir.Enabled = false;
                this.tsb_anular.Enabled = false;
            }
            else
            {
                this.tsb_imprimir.Enabled = true;
                this.tsb_anular.Enabled = true;
            }

            this.tsb_nuevo.Enabled = true;
            this.tsb_guardar.Enabled = true;

            this.obtenerIdFactura();
            this.txt_fecha.Text = DateTime.Now.ToString();
            this.txt_numAut.Text = confPredeterminada.Autorizacion;

            this.dtp_vencimiento.Value = DateTime.Now;
            this.txt_descipcion.Clear();

            this.generarNumeroDocumento();

            if (confPredeterminada.Tipo_doc == "F") this.txt_tipo.Text = "FACTURA";
            else if (confPredeterminada.Tipo_doc == "N") this.txt_tipo.Text = "NOTA DE VENTA";
            else
            {
                this.chk_dna.Enabled = false;
                this.chk_dna.Checked = true;
            }

            this.llenarComboEstado();
            //this.cmb_estado.Enabled = true;
            if(this.seleccionarVendedor)this.cmb_vendedor.Enabled = true;

            

            if (controlesAdicionales != null)
            {
                foreach (Control control in controlesAdicionales)
                {
                    control.Enabled = true;
                    if (control is ComboBox) ((ComboBox)control).SelectedIndex = 0;
                    else control.Text = "";
                }
            }
            //Consultar usuario final
            string msn = "";
            ClienteTR cliente = new ClienteTR();
            Persona clienteFinal = cliente.consultarUsuarioFinal(ref msn);
            if (clienteFinal != null)
            {
                this.idCliente = clienteFinal.id;
                this.txt_ruc.Text = clienteFinal.cedula;
                this.clienteDireccion = clienteFinal.direccion;
                this.clienteTelefono = clienteFinal.telefonos;
                this.txt_Nombres.Text = clienteFinal.razon_social;
            }
            else {
                this.idCliente = 0;
                this.txt_ruc.Clear();
                this.borrarDatosCliente();
            }


            this.grw_productos.CellValueChanged -= grw_productos_CellValueChanged_1;
            this.grw_productos.DataSource = null;
            this.grw_productos.Rows.Clear();
            this.grw_productos.Rows.Add();
            this.grw_productos.CellValueChanged += grw_productos_CellValueChanged_1;

            this.txt_descProducto.Text = "0";
            this.chk_dna.Checked = false;
           // this.txt_descripcion.Text = "VENTA DESDE PUNTO DE VENTA";
            this.chk_descProd.Checked = false;
            this.chk_todoEfectivo.Checked = false;

            if (inicio)
            {
                autoComplete = new AutoCompleteStringCollection();
                ProductoTR tranPro = new ProductoTR();
                DataTable datos = tranPro.consultarNombreProductos(ref msn, confPredeterminada.Stock);
                foreach (DataRow fila in datos.Rows) autoComplete.Add(fila[0].ToString());

                autoCompleteCodigo = new AutoCompleteStringCollection();
                DataTable datosCodigo = tranPro.consultarCodigoProductos(ref msn, confPredeterminada.Stock);
                foreach (DataRow fila in datosCodigo.Rows) autoCompleteCodigo.Add(fila[0].ToString());
            }

            this.txt_efectivo.Text = "0";
            this.txt_propina.Text = "0";

            this.txt_numerot1.Clear();
            this.txt_montot1.Text = "0";
            this.cmb_pin1.SelectedIndex = 0;
            this.cmb_tipo1.SelectedIndex = 0;

            this.txt_numerot2.Clear();
            this.txt_montot2.Text = "0";
            this.cmb_tipo2.SelectedIndex = 0;
            this.cmb_pin2.SelectedIndex = 0;

            this.txt_numeroc.Clear();
            this.txt_banco.Clear();
            this.txt_montoc.Text = "0";

            this.txt_numeroRetencion.Clear();
            this.txt_retencion.Text = "0";

            this.txt_numeroNota.Clear();
            this.txt_montoNota.Text = "0";

            this.txt_iva12.Text = "0.00";
            this.txt_iva0.Text = "0.00";
            this.txt_descuento.Text = "0.00";
            this.txt_iva.Text = "0.00";
            this.txt_servicio.Text = "0.00";

            this.txt_total.Text = "0.00";
            this.txt_totalpago.Text = "0.00";
            this.txt_vuelto.Text = "0.00";
            this.txt_saldo.Text = "0.00";
            this.txt_total.Left = (this.pan_totales.Width - this.txt_total.Width) / 2;

            this.grw_productos.Focus();
            this.grw_productos.Enabled = true;

            if (this.confPredeterminada.Sin_cobro) this.cmb_estado.SelectedValue = "P";
            if (this.confPredeterminada.Servicio)
            {
                this.chk_servicio.Visible = true;
                this.chk_servicio.Checked = true;
            }

            if (!estadoGuardar) this.activarEstadoGuardar();
            this.estadoGuardar = true;

            this.facturaPagada = false;
            this.setearCeldaActiva("producto", 0, true);

            if (this.pagoParcial)
            {
                this.grw_abonos.DataSource = null;
                this.grw_abonos.Rows.Clear();
                this.pagos = null;
                this.pagosEliminados = null;
                this.btn_agregarPago.Enabled = false;
                this.tsb_reversar.Enabled = false;
                //this.grw_abonos.Rows.Add();
            }

            if (ubicaciones != null)
            {
                foreach (Ubicacion ubicacion in this.ubicaciones)
                {
                    ubicacion.productos.Clear();
                    ubicacion.productosEliminados.Clear();
                }
            }

            this.productosEliminados.Clear();
            this.tsb_preCuenta.Enabled = false;

        }

        public void obtenerIdFactura()//id de la factura a ingresar.
        {
            FacturaCabeceraTR tran = new FacturaCabeceraTR();
            string mensaje = "";
            int numero = tran.consultar_numeroActual(ref mensaje);
            if (numero != -1) this.txt_secuencia.Text = (numero + 1).ToString();
            else Mensaje.error(mensaje);
        }

        public void generarNumeroDocumento()
        {
            if (this.confPredeterminada.Activar_secuencia)// Si es false se activa el secuencia, si es verdadero no se activa
            {
                if (this.confPredeterminada.Tipo_doc == "D")
                {
                    this.txt_numDoc.Text = confPredeterminada.Sec_actual.ToString();
                }
                else
                {
                    this.txt_numDoc.Text = completarDigitos(3, confPredeterminada.Codigo_establecimiento.ToString()) + "-" +
                        completarDigitos(3, confPredeterminada.Pto_emision.ToString()) + "-" +
                        completarDigitos(9, (confPredeterminada.Sec_actual).ToString());
                }
            }
            else
            {
                this.txt_numDoc.Enabled = true;

                if(this.confPredeterminada.Tipo_doc != "D")
                this.txt_numDoc.Text = completarDigitos(3, confPredeterminada.Codigo_establecimiento.ToString()) + "-" + completarDigitos(3, confPredeterminada.Pto_emision.ToString()) + "-";
                else this.txt_numDoc.Clear();
                //this.txt_numDoc.ReadOnly = false;
                
                this.txt_numDoc.BackColor = System.Drawing.SystemColors.Window;
            }
        }

        public string completarDigitos(int numero, string cadena)
        {
            int restante = numero - cadena.Length;
            String relleno = "";
            if (restante > 0)for (int i = 0; i < restante; i++)relleno = relleno + "0";
            return (relleno + cadena);
        }   

        public void llenarComboTarjetasCredito()
        {

            List<ComboboxItem> lista = TarjetaCreditoTR.obtenerTarjetas();
            ComboboxItem item_0 = new ComboboxItem();
            item_0.Text = "";
            item_0.Value = "";
            lista.Insert(0,item_0);

            List<ComboboxItem> lista1 = lista.ToList<ComboboxItem>();
            ComboboxItem item1_0 = new ComboboxItem();
            item1_0.Text = "";
            item1_0.Value = "";
            lista1.Insert(0,item1_0);

            this.cmb_tipo1.DataSource = lista;
            this.cmb_tipo1.ValueMember = "Value";
            this.cmb_tipo1.DisplayMember = "Text";

            this.cmb_tipo2.DataSource = lista1;
            this.cmb_tipo2.ValueMember = "Value";
            this.cmb_tipo2.DisplayMember = "Text";

            List<ComboboxItem> listaPin = new List<ComboboxItem>();
            ComboboxItem pin_0 = new ComboboxItem();
            pin_0.Text = "";
            pin_0.Value = "";
            listaPin.Add(pin_0);
            ComboboxItem pin_1 = new ComboboxItem();
            pin_1.Text = "DataFast";
            pin_1.Value = "D";
            listaPin.Add(pin_1);
            ComboboxItem pin_2 = new ComboboxItem();
            pin_2.Text = "MediaNet";
            pin_2.Value = "M";
            listaPin.Add(pin_2);
            ComboboxItem pin_3 = new ComboboxItem();
            pin_3.Text = "Red de Apoyo";
            pin_3.Value = "R";
            listaPin.Add(pin_3);

            List<ComboboxItem> listaPin1 = new List<ComboboxItem>();
            ComboboxItem pin1_0 = new ComboboxItem();
            pin1_0.Text = "";
            pin1_0.Value = "";
            listaPin1.Add(pin1_0);
            ComboboxItem pin1_1 = new ComboboxItem();
            pin1_1.Text = "DataFast";
            pin1_1.Value = "D";
            listaPin1.Add(pin1_1);
            ComboboxItem pin1_2 = new ComboboxItem();
            pin1_2.Text = "MediaNet";
            pin1_2.Value = "M";
            listaPin1.Add(pin1_2);
            ComboboxItem pin1_3 = new ComboboxItem();
            pin1_3.Text = "Red de Apoyo";
            pin1_3.Value = "R";
            listaPin1.Add(pin1_3);

            this.cmb_pin1.DataSource = listaPin;
            this.cmb_pin1.ValueMember = "Value";
            this.cmb_pin1.DisplayMember = "Text";

            this.cmb_pin2.DataSource = listaPin1;
            this.cmb_pin2.ValueMember = "Value";
            this.cmb_pin2.DisplayMember = "Text";

        }

        private void chk_dna_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk_dna.Checked)
            {
                this.txt_numDoc.Enabled = true;
                this.txt_tipo.Text = "COMPROBANTE";
                this.txt_numDoc.Clear();
                this.txt_numDoc.Select();
            }
            else
            {

                this.txt_numDoc.Enabled = false;
                if (confPredeterminada.Tipo_doc == "F") this.txt_tipo.Text = "FACTURA";
                else if (confPredeterminada.Tipo_doc == "N") this.txt_tipo.Text = "NOTA DE VENTA";
                generarNumeroDocumento();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.mostrarBusquedaCliente();
        }

        private void mostrarBusquedaCliente()
        {
            frm_buscarCliente frmCliente = new frm_buscarCliente(this.habilitarCodigoCliente);
            DialogResult dr = frmCliente.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                this.setCedulaCliente(frmCliente.cedula);
            }
        }

        private void btn_crearCliente_Click(object sender, EventArgs e)
        {
            frm_Cliente cliente = new frm_Cliente();
            cliente.Owner = this;
            cliente.ShowDialog();
        }

        private void txt_ruc_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if(!this.validarTeclado(e))return;
            if (e.KeyChar == 13)
            {
                string cedula = this.txt_ruc.Text.Trim();
                if (cedula.Length < 10 && cedula.Length > 0)
                {
                    Mensaje.advertencia("La cédula o ruc debe ser de 10 o 13 dígitos.");
                    return;
                }
                else if (cedula.Length >= 10) this.buscarCliente(cedula);
            }
            General.soloNumeros(e);
        }

        public void buscarCliente(string cedula, int idClienteFactura = -1)
        {
            try
            {
                ClienteTR tran = new ClienteTR();
                Persona persona;
                if (idClienteFactura == -1) persona = ClienteTR.buscarXCedula(cedula);
                else persona = ClienteTR.buscarXId(idClienteFactura);
                if (persona != null)
                {
                    if (!this.habilitarVentasDeudores && this.estadoGuardar && persona.tiene_deuda)
                    {
                        Mensaje.informacion("La persona seleccionada posee documentos pendientes");
                        this.borrarDatosCliente();
                        return;
                    }

                    if (persona.bloqueado)
                    {
                        Mensaje.informacion("La persona seleccionada posee deudas no se podrá facturar con este nombre");
                        this.borrarDatosCliente();
                        return;
                    }    //sk3

                    this.txt_ruc.Text = (String.IsNullOrEmpty(persona.ruc) ? persona.cedula : persona.ruc);
                    this.txt_Nombres.Text = persona.razon_social;
                    this.clienteTelefono = persona.telefonos;
                    this.clienteDireccion = persona.direccion;
                    this.txt_descProducto.Text = persona.porcentaje_descuento.ToString();
                    this.descuentoFactura = persona.porcentaje_descuento;
                    this.idCliente = persona.id;
                    if (this.habilitarCodigoCliente && this.controlesAdicionales != null && this.controlesAdicionales.Count > 0) this.controlesAdicionales[0].Text = persona.codigo;
                    //this.setearCeldaActiva("producto", this.grw_productos.RowCount-1, true);
                    //this.setearCeldaActiva("producto", 0, true);
                }
                else
                {
                    frm_Cliente cliente = new frm_Cliente(this.txt_ruc.Text);
                    cliente.Owner = this;
                    cliente.ShowDialog();
                }
            }
            catch (Exception e)
            {
                Mensaje.error(e.Message);
                this.borrarDatosCliente();
            }
        }

        private void borrarDatosCliente()
        {
            this.txt_Nombres.Text = "";
            this.clienteTelefono = "";
            this.clienteDireccion = "";
        }

        private void txt_ruc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F3)
            {
                this.mostrarBusquedaCliente();
            }
        }

        private void txt_ruc_TextChanged(object sender, EventArgs e)
        {
            this.borrarDatosCliente();
        }

        private void grw_productos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (this.grw_productos.Columns[e.ColumnIndex].Name == "botonBuscar")
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    Bitmap bmp = Pos.Properties.Resources.buscar_lupa;
                    DataGridViewButtonCell celBoton = this.grw_productos.Rows[e.RowIndex].Cells["botonBuscar"] as DataGridViewButtonCell;
                    Icon icoAtomico = Icon.FromHandle(bmp.GetHicon());
                    e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);
                    this.grw_productos.Columns[e.ColumnIndex].Width = 20;
                    e.Handled = true;
                }
                else if (this.grw_productos.Columns[e.ColumnIndex].Name == "botonEliminar")
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    Bitmap bmp = Pos.Properties.Resources.borrar_fila;
                    DataGridViewButtonCell celBoton = this.grw_productos.Rows[e.RowIndex].Cells["botonEliminar"] as DataGridViewButtonCell;
                    Icon icoAtomico = Icon.FromHandle(bmp.GetHicon());
                    e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 2, e.CellBounds.Top + 3);
                    this.grw_productos.Columns[e.ColumnIndex].Width = 21;
                    e.Handled = true;
                }

            }
        }

        private void grw_productos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex < 0)return;
            if (this.grw_productos.Columns[e.ColumnIndex].Name == "botonBuscar") this.formuBuscarProducto(e);
            if (this.grw_productos.Columns[e.ColumnIndex].Name == "botonEliminar")
            {
                this.eliminarFilaProducto(e.RowIndex);
                /*this.subtotalEliminado = 0;
                if (!General.celdaVacia(this.grw_productos["subtotal", e.RowIndex]))
                {
                    decimal pvp = Decimal.Parse(General.obtenerValorCelda(grw_productos, e.RowIndex, "precioU"));
                    decimal cantidad = Decimal.Parse(General.obtenerValorCelda(grw_productos, e.RowIndex, "cantidad"));
                    this.subtotalEliminado = (pvp * cantidad);
                }
                this.grw_productos.Rows.RemoveAt(e.RowIndex);
                if (this.grw_productos.Rows.Count < 1) this.grw_productos.Rows.Add();*/
            }
        }

        public void eliminarFilaProducto(int indice)
        {
            if (!this.estadoGuardar)
            {
                decimal cantidad = Convert.ToDecimal(this.grw_productos.CurrentRow.Cells["cantidad"].Value);
                if (cantidad != 0)
                {
                    FacturaDetalle eliminado = new FacturaDetalle();
                    eliminado.Id_producto = Convert.ToInt32(this.grw_productos.CurrentRow.Cells["id_producto"].Value);
                    eliminado.Producto = this.grw_productos.CurrentRow.Cells["producto"].Value.ToString();
                    if (!General.celdaVacia(this.grw_productos.CurrentRow.Cells["descripcion"])) eliminado.Descripcion = this.grw_productos.CurrentRow.Cells["descripcion"].Value.ToString();
                    eliminado.Cantidad = cantidad;
                    this.productosEliminados.Add(eliminado);
                }

            }

            this.grw_productos.Rows.RemoveAt(indice);
            if (this.grw_productos.Rows.Count < 1) this.grw_productos.Rows.Add();
        }

        protected void formuBuscarProducto(DataGridViewCellEventArgs e)
        {
            frm_buscarProducto bp = new frm_buscarProducto(confPredeterminada.Stock,this.grw_productos.Rows[e.RowIndex]);
            bp.Owner = this;
            bp.ShowDialog();
        }

        public void buscarProducto(string codigo, string nombre, int fila, string codigoBarra = null, string cantidad = null)
        {
            //try
            //{

                String mensaje = "";
                ProductoTR tran = new ProductoTR();
                Producto producto = null;

                if (codigoBarra == null) producto = tran.consultarProducto(ref mensaje, codigo, nombre, this.confPredeterminada.Stock, this.confPredeterminada.Tipo_doc);
                else producto = tran.consultarCodigoBarra(ref mensaje, codigoBarra, this.confPredeterminada.Stock, this.confPredeterminada.Tipo_doc);

                if (producto != null)
                {

                    //this.grw_productos.Rows[fila].Cells["producto"].Value = producto.Nombre;
                    this.llenarFila(producto, fila,cantidad);
                }
                else
                {
                    if (String.IsNullOrEmpty(mensaje))
                    {
                        Mensaje.advertencia("No se encontró el producto.");
                        General.filaVaciar(this.grw_productos.Rows[fila], this.grw_productos.Columns[String.IsNullOrEmpty(codigo) ? "producto" : "codigo"].Index);
                    }
                    else Mensaje.advertencia(mensaje);
                }
            //}
            //catch (Exception e)
            //{
            //    Mensaje.error(e.Message);
            //    General.filaVaciar(this.grw_productos.Rows[fila], this.grw_productos.Columns[String.IsNullOrEmpty(codigo) ? "producto" : "codigo"].Index);
            //}
        }



        protected void llenarFila(Producto producto, int nfila, string cantidad = null)
        {
            this.grw_productos.CellValueChanged -= grw_productos_CellValueChanged_1;
            this.grw_productos.EndEdit();
            DataGridViewRow fila =  this.grw_productos.Rows[nfila];
            fila.Cells["codigo"].Value = producto.codigo;
            fila.Cells["Producto"].Value = producto.nombre;
            fila.Cells["id_producto"].Value = producto.id;
            fila.Cells["Unidad"].Value = producto.unidad;
            //fila.Cells["id_unidad"].Value = producto.Unidad_id;
            fila.Cells["iva"].Value = producto.porcentaje_iva;
            fila.Cells["ice"].Value = 0;
            //fila.Cells["inventariable"].Value = (producto.Inventariable)?1:0;

            DataGridViewComboBoxCell combo = (DataGridViewComboBoxCell)fila.Cells["precioU"];
            if (producto.pvp_manual)
            {
                fila.Cells["precioU"].Style.BackColor = Color.White;
                fila.Cells["pvp_manual"].Value = "1";
            }
            else
            {
                fila.Cells["precioU"].Style.BackColor = Color.FromArgb(253, 255, 187);
                fila.Cells["pvp_manual"].Value = "0";
            }

            combo.Items.Clear();
            combo.Items.Add(General.truncar(producto.pvp1, this.cantidadDecimales).ToString());
            if (producto.pvp2 != 0) combo.Items.Add(General.truncar(producto.pvp2, this.cantidadDecimales).ToString());
            if (producto.pvp3 != 0) combo.Items.Add(General.truncar(producto.pvp3, this.cantidadDecimales).ToString());
            combo.Value = combo.Items[0];

            fila.Cells["cantidad"].Value = (String.IsNullOrEmpty(cantidad)) ? "1" : cantidad;
            fila.Cells["cantidadStock"].Value = producto.cantidad_stock;
            // aparece stock del producto que se elije (1) sky
            fila.Cells["llena"].Value = "1";
            fila.Cells["id_detalle"].Value = "-1";
            fila.Cells["id_categoria"].Value = producto.categoria_id;

            //String cantidadS = General.obtenerValorCelda(this.grw_productos, nfila, "cantidad");

            if (this.promociones != null)
            {
                fila.Cells["promocion"].Value = PromocionTR.consultarPromocionProducto(producto.id);
            }

            fila.Cells["descripcion"].Value = this.descripcionProducto + " " + ((this.imprimirDescripcion)?producto.descripcion:"");

            //if (!String.IsNullOrEmpty(cantidadS)) 
            this.setearValoresFila(nfila, -1, -1);
            this.agregarFila();
            this.setearCeldaActiva("producto", nfila + 1, true);

            if (producto.seriado && this.habilitarProductoSerie)
            {
                this.mostrarFormSerie(fila, producto.id);
            }

            this.grw_productos.CellValueChanged += grw_productos_CellValueChanged_1;
        }

        private List<string> seriesIngresadas(int idProducto)
        {
            List<string> lista = new List<string>();
            foreach (DataGridViewRow fila in this.grw_productos.Rows)
            {
                string id = General.obtenerValorCelda(fila.Cells["id_producto"]);
                if (!String.IsNullOrEmpty(id) && Convert.ToInt32(id) == idProducto)
                {
                    if (fila.Cells["serie"].Value != null) lista.Add(fila.Cells["serie"].Value.ToString());
                }
            }
            return lista;
        }

        protected void calcularValorPromociones(Decimal subtotalActual)
        {
            this.txt_descProducto.Text = this.descuentoFactura.ToString();

            foreach (PromocionFactura promocion in this.promociones)
            {
                promocion.aplicar = false;
                promocion.valorDescuento = 0;
                if (promocion.agrupacion == 1)
                {
                    if (String.IsNullOrEmpty(promocion.seleccion) || promocion.seleccion == "F")
                    {
                        promocion.menores.Clear();
                    }
                    else
                    {
                        for (int i = 0; i < promocion.cantidad; i++)
                        {
                            promocion.combo[i].Clear();
                        }
                    }
                }
                else promocion.grupo.Clear();
            }
            //List<PromocionFactura> promocionesEncontradas = new List<PromocionFactura>();
            foreach (DataGridViewRow fila in this.grw_productos.Rows)
            {
                if (!General.celdaVacia(fila.Cells["cantidad"]) && Convert.ToDecimal(fila.Cells["cantidad"].Value) != 0 && fila.Cells["llena"].Value != null && fila.Cells["llena"].Value.Equals("1"))
                {

                    this.calcularSubtotalFila(fila.Index, (this.chk_descProd.Checked) ? (decimal)this.descuentoFactura : 0);
                    if (fila.Cells["promocion"].Value != null)
                    {
                        List<int> promociones = (List<int>)fila.Cells["promocion"].Value;
                        this.calcularSubtotalFila(fila.Index, (this.chk_descProd.Checked) ? (decimal)this.descuentoFactura : 0);
                        int vCantidad = Convert.ToInt32(Convert.ToDecimal(fila.Cells["cantidad"].Value));
                        decimal vPrecio = Convert.ToDecimal(fila.Cells["precioU"].Value);
                        if (promociones == null) return;
                        foreach (int idPromocion in promociones)
                        {
                            PromocionFactura promocion = this.promociones.Find(element => element.id == idPromocion);
                            if (promocion != null)
                            {
                                int idProducto = Convert.ToInt32(fila.Cells["id_producto"].Value);
                                //cualquier categoría
                                if (promocion.tipo != "C")
                                {
                                    valoresMenores valor = new valoresMenores() { cantidad = vCantidad, valor = vPrecio, posicion = fila.Index, idProducto = idProducto };
                                    if (promocion.agrupacion == 1) promocion.insertarAscendente(valor);
                                    else if (promocion.agrupacion == 2)//grupos por categoría
                                    {
                                        int idCategoria = Convert.ToInt32(fila.Cells["id_categoria"].Value);
                                        PromocionGrupo grupo = promocion.grupo.Find(element => element.idCategoria == idCategoria);
                                        if (grupo == null)
                                        {
                                            grupo = new PromocionGrupo() { idCategoria = idCategoria };
                                            promocion.grupo.Add(grupo);
                                        }
                                        promocion.insertarAscendente(valor, grupo.menores);
                                    }
                                    else if (promocion.agrupacion == 3) // grupos por nombre
                                    {
                                        string nombre = fila.Cells["producto"].Value.ToString();
                                        PromocionGrupo grupo = promocion.grupo.Find(element => element.nombre == nombre);
                                        if (grupo == null)
                                        {
                                            grupo = new PromocionGrupo() { nombre = nombre };
                                            promocion.grupo.Add(grupo);
                                        }
                                        promocion.insertarAscendente(valor, grupo.menores);
                                    }
                                }
                                else
                                {

                                    if (promocion.seleccion == "F")
                                    {
                                        for (int i = 0; i < vCantidad; i++)
                                        {
                                            int numero_combo = PromocionTR.consultarNumeroCombo(idProducto, idPromocion, promocion.obtenerCombosIngresados());
                                            valoresMenores existe = promocion.menores.Find(element => element.posicion == numero_combo);
                                            if (existe == null && numero_combo != -1)
                                            {
                                                valoresMenores valor = new valoresMenores() { cantidad = vCantidad, posicion = numero_combo, valor = vPrecio, idProducto = idProducto };
                                                promocion.menores.Add(valor);
                                            }
                                        }
                                    }
                                    else 
                                    {
                                        for (int i = 0; i < vCantidad; i++)
                                        {
                                            List<int> numerosCombo = PromocionTR.consultarNumerosCombo(idProducto, idPromocion);
                                            int numero_combo = promocion.obtenerNumeroCombo(idProducto, numerosCombo);
                                            //valoresMenores valor = promocion.combo[numero_combo].Find(element => element.idProducto == idProducto && element.posicion == fila.Index);
                                            //if (valor == null)
                                            //{
                                            valoresMenores valor = new valoresMenores() { cantidad = 1, numeroCombo = numero_combo, posicion = fila.Index, valor = vPrecio, idProducto = idProducto };
                                            promocion.insertarAscendente(valor, promocion.combo[numero_combo]);
                                            //}
                                            //else valor.cantidad++;
                                        }
                                    }
                                }
                            }

                        }
                    }
                }
            }

            decimal subtotal = Convert.ToDecimal(this.txt_iva12.Text) + Convert.ToDecimal(this.txt_iva0.Text) + Convert.ToDecimal(this.txt_descuento.Text) + subtotalActual;
            PromocionFactura.setValoresPromociones(this.promociones, this.grw_productos, subtotal);

            foreach (PromocionFactura promocion in this.promociones)
            {
                if (promocion.tipo != "C")
                {
                    if (promocion.agrupacion == 1)
                    {
                        if (promocion.aplicar)
                        {
                            int cAplican = promocion.contarProductos() / promocion.cantidad;
                            this.aplicarDescuento(cAplican, promocion.menores, promocion.descuento);
                        }
                    }
                    else
                    {
                        foreach (PromocionGrupo grupo in promocion.grupo)
                        {
                            if (grupo.aplicar)
                            {
                                int cAplican = promocion.contarProductos(grupo.menores) / promocion.cantidad;
                                this.aplicarDescuento(cAplican, grupo.menores, promocion.descuento);
                            }
                        }
                    }
                }
                else if (promocion.aplicar)
                {
                    if (promocion.seleccion == "F")
                    {
                        this.txt_descProducto.Text = promocion.descuento.ToString();
                        this.calcularDescuentoCliente();
                        return;
                    }
                    else
                    {
                        foreach(valoresMenores valor in promocion.menores)this.aplicarDescuentoCombo(valor,promocion.descuento);
                    }
                }
            }
        }

        private void aplicarDescuentoCombo(valoresMenores valor, decimal descuento)
        {
            int fila = valor.posicion;
            decimal pvp = Decimal.Parse(General.obtenerValorCelda(grw_productos, fila, "precioU"));
            decimal cantidad = Decimal.Parse(General.obtenerValorCelda(grw_productos, fila, "cantidad"));
            decimal pDescuento = General.truncar((descuento * valor.cantidad) / (decimal)cantidad, 2);
            this.calcularSubtotalFila(fila, pDescuento);
        }

        private void aplicarDescuento(int cAplican,List<valoresMenores> menores, decimal descuento) {
            int x = 0;
            while (cAplican > 0)
            {
                //decimal descuento = 0;
                int factor = 1;
                if (menores[x].cantidad > 1)
                {
                    factor = (cAplican > menores[x].cantidad) ? menores[x].cantidad : cAplican;
                }

                //descuento = promocion.descuento * (promocion.menores[x].cantidad / promocion.cantidad);
                decimal pDescuento = General.truncar((descuento * factor) / (decimal)menores[x].cantidad, 2);
                int fila = menores[x].posicion;
                //this.grw_productos.Rows[fila].Cells["pDesc"].Value = pDescuento;
                this.calcularSubtotalFila(fila, pDescuento);
                cAplican -= menores[x].cantidad;
                x++;
            }
        }

        protected void calcularSubtotalFila(int fila, decimal pDescuento)
        {
            decimal pvp = Decimal.Parse(General.obtenerValorCelda(this.grw_productos, fila, "precioU"));
            decimal cantidad = Decimal.Parse(General.obtenerValorCelda(this.grw_productos, fila, "cantidad"));
            decimal subtotal = pvp * cantidad;

            decimal valorDescuento = subtotal * (pDescuento / 100);
            this.grw_productos.Rows[fila].Cells["pdesc"].Value = pDescuento;
            this.grw_productos.Rows[fila].Cells["subtotaldesc"].Value = Math.Round(valorDescuento, 2);
            this.grw_productos.Rows[fila].Cells["subtotal"].Value = General.truncar((subtotal - valorDescuento), 2);
        }

        protected void setearValoresFila(int nfila, decimal pvpPrevio, decimal cantidadPrevia)
        {
            decimal cantidad;
            if (cantidadPrevia == -1) cantidad = Decimal.Parse(General.obtenerValorCelda(this.grw_productos, nfila, "cantidad"));
            else
            {
                cantidad = cantidadPrevia;
                this.grw_productos.CurrentRow.Cells["cantidad"].Value = cantidad;
            }
            
            decimal pvp;
            if (pvpPrevio == -1) pvp = Decimal.Parse(General.obtenerValorCelda(this.grw_productos, nfila, "precioU"));
            else 
            {
                pvp = pvpPrevio;
                this.grw_productos.CurrentRow.Cells["precioU"].Value = pvpPrevio;
            }

           
            decimal cantidadStock = Decimal.Parse(General.obtenerValorCelda(this.grw_productos, nfila, "cantidadStock"));
            decimal pDescuento = (General.obtenerValorCelda(this.grw_productos, nfila, "pdesc") != "") ? Convert.ToDecimal(this.grw_productos.Rows[nfila].Cells["pdesc"].Value) : 0;

            if (pDescuento == 0) //&& this.chk_descProd.Checked)
            {
                //if (String.IsNullOrEmpty(txt_descProducto.Text)) pDescuento = 0;
                //else pDescuento = Convert.ToDecimal(txt_descProducto.Text, CultureInfo.GetCultureInfo("en"));

                if (!String.IsNullOrEmpty(txt_descProducto.Text)) pDescuento = Convert.ToDecimal(txt_descProducto.Text, CultureInfo.GetCultureInfo("en"));
            }

            decimal subtotal;
            if (this.confPredeterminada.Stock || cantidad <= cantidadStock) //si la configuración del pos permite facturar en cero o la cantidad ingresada es menor o igual que la cantidad en stock del producto
            {
                subtotal = cantidad * pvp;
            }
            else //si la cantidad ingresad es mayour que la cantidad en stock del producto
             {
                Mensaje.advertencia("Solo hay en Stock " + cantidadStock + " producto(s)");
                this.grw_productos.EndEdit();
                this.grw_productos.Rows[nfila].Cells["cantidad"].Value = cantidadStock;
                subtotal = cantidadStock * pvp;
                
            }

            decimal valorDescuento = subtotal * (pDescuento / 100);
            this.grw_productos.Rows[nfila].Cells["pdesc"].Value = pDescuento;
            this.grw_productos.Rows[nfila].Cells["subtotaldesc"].Value = Math.Round(valorDescuento,2);
            decimal subtotalDesc = Math.Round((subtotal - valorDescuento),2);
            this.grw_productos.Rows[nfila].Cells["subtotal"].Value = subtotalDesc;

            if (!this.estadoGuardar && !General.celdaVacia(this.grw_productos["id_detalle", nfila]))
            {
                if (Convert.ToInt32(this.grw_productos["id_detalle", nfila].Value) != -1)
                {
                    this.grw_productos["modifico", nfila].Value = 1;
                }
            }

            if (this.promociones != null && this.grw_productos["promocion", nfila].Value != null) this.calcularValorPromociones(subtotalDesc);
            this.calcularValoresAPagar();
           
        }

        private void chk_descProd_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk_descProd.Checked) //activo descuento
            {
                this.txt_descProducto.Enabled = true;
                //this.txt_descProducto.Text = "0";              
                this.txt_descProducto.Focus();
                txt_descProducto.SelectionStart = 0;
                txt_descProducto.SelectionLength = txt_descProducto.Text.Length;
            }
            else //desactivo descuento
            {
                this.txt_descProducto.Enabled = false;
                //this.txt_descProducto.Text = "0";
            }
            this.calcularDescuentoCliente();
         ///   if (this.grw_productos.Rows.Count > 0) this.calcularDescuentoCliente();
        }

        protected void calcularDescuentoCliente()
        {
            string descuentoFactura = txt_descProducto.Text;
            decimal pDescuento;
            decimal subtotal;
            //!this.chk_descProd.Checked || 
            if (String.IsNullOrEmpty(descuentoFactura)) pDescuento = 0;
            else pDescuento = Convert.ToDecimal(descuentoFactura);

            foreach (DataGridViewRow fila in this.grw_productos.Rows)
            {
                if (fila.Cells["subtotal"].Value != null)
                {

                    fila.Cells["pdesc"].Value = pDescuento;
                    subtotal = Convert.ToDecimal(fila.Cells["cantidad"].Value) * Convert.ToDecimal(fila.Cells["precioU"].Value);
                    fila.Cells["subtotaldesc"].Value = Math.Round((pDescuento / 100) * subtotal, 2);
                    fila.Cells["subtotal"].Value = General.truncar(subtotal - ((pDescuento / 100) * subtotal), 2);
                }
            }

            this.calcularValoresAPagar();
        }

        private void nombreProducto_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F3)
            {
                frm_buscarProducto bp = new frm_buscarProducto(confPredeterminada.Stock, this.grw_productos.CurrentRow);
                bp.Owner = this;
                bp.ShowDialog();
            }
            
        }

        private void txt_descProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.permitirDecimales(sender, e);
        }

        private void txt_descProducto_KeyUp(object sender, KeyEventArgs e)
        {
            if (General.esDecimal(txt_descProducto.Text) || string.IsNullOrEmpty(txt_descProducto.Text)) this.calcularDescuentoCliente();
        }

        private void grw_productos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0) return;
            //DataGridView datos = (DataGridView)sender;
            //string columna = datos.Columns[e.ColumnIndex].Name;
            // || columna == "precioU"
           // if (columna == "codigo" || columna == "cantidad" || columna == "producto" || columna == "pdesc") this.setearCeldaActiva(columna,e.RowIndex, true);
        }

        protected void setearCeldaActiva(string columna, int fila, bool editar)
        {
            
            if (this.grw_productos.RowCount >= fila + 1)
            {
                this.grw_productos.Select();
                this.grw_productos.EditMode = DataGridViewEditMode.EditOnEnter;
                this.grw_productos.CurrentCell = this.grw_productos[columna, fila];
                this.grw_productos.CurrentCell.Selected = true;
                //this.grw_productos.BeginEdit(true);
            }
        }

        protected void eliminarEventos(TextBox cajaTexto)
        {

            cajaTexto.KeyUp -= new KeyEventHandler(txt_pdes_keyup);
            cajaTexto.KeyUp -= new KeyEventHandler(txt_cantidad_keyup);
            //cajaTexto.KeyPress -= new KeyPressEventHandler(codigoBarra_KeyPress);
            cajaTexto.KeyPress -= new KeyPressEventHandler(CajasoloDecimales_KeyPress);
            cajaTexto.KeyPress -= new KeyPressEventHandler(CajasoloNumeros_KeyPress);
            cajaTexto.KeyUp -= new KeyEventHandler(nombreProducto_KeyUp);
            cajaTexto.KeyUp -= new KeyEventHandler(txt_descripcion_keyup);
        }

        private void grw_productos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.grw_productos.CurrentCell.RowIndex < 0 || this.grw_productos.CurrentCell.ColumnIndex < 0) return;
            if (grw_productos.CurrentCell.ColumnIndex == grw_productos.Columns["codigo"].Index)
            {
                TextBox cajaTexto = e.Control as TextBox;
                this.eliminarEventos(cajaTexto);
                if (cajaTexto != null)
                {
                    cajaTexto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cajaTexto.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    cajaTexto.AutoCompleteCustomSource = autoCompleteCodigo;
                }
            }
            else if (grw_productos.CurrentCell.ColumnIndex == grw_productos.Columns["producto"].Index)
            {
                
                TextBox cajaTexto = e.Control as TextBox;
                this.eliminarEventos(cajaTexto);
                //cajaTexto.KeyPress += new KeyPressEventHandler(codigoBarra_KeyPress);
                cajaTexto.KeyUp += new KeyEventHandler(nombreProducto_KeyUp);
                if (cajaTexto != null)
                {
                    cajaTexto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cajaTexto.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    cajaTexto.AutoCompleteCustomSource = autoComplete;
                }
            }
            else if (grw_productos.CurrentCell.ColumnIndex == grw_productos.Columns["cantidad"].Index)
            {
                TextBox cajaTexto = e.Control as TextBox;
                cajaTexto.AutoCompleteCustomSource = null;
                this.eliminarEventos(cajaTexto);

                cajaTexto.KeyUp += new KeyEventHandler(txt_cantidad_keyup);
                cajaTexto.KeyPress += new KeyPressEventHandler(CajasoloDecimales_KeyPress);
            }
            else if (grw_productos.CurrentCell.ColumnIndex == grw_productos.Columns["pdesc"].Index)
            {
                TextBox cajaTexto = e.Control as TextBox;
                cajaTexto.AutoCompleteCustomSource = null;
                this.eliminarEventos(cajaTexto);

                cajaTexto.KeyUp += new KeyEventHandler(txt_pdes_keyup);
                cajaTexto.KeyPress += new KeyPressEventHandler(CajasoloDecimales_KeyPress);
            }
            else if (grw_productos.CurrentCell.ColumnIndex == grw_productos.Columns["precioU"].Index)
            {
                this.pvpManual = "";
                ComboBox cajaTexto = e.Control as ComboBox;
                e.CellStyle.BackColor = this.grw_productos.DefaultCellStyle.BackColor;
                if (General.obtenerValorCelda(this.grw_productos,this.grw_productos.CurrentRow.Index,"pvp_manual") == "1")
                {
                    cajaTexto.MaxLength = 8;
                    cajaTexto.DropDownStyle = ComboBoxStyle.DropDown;
                    cajaTexto.KeyPress -= new KeyPressEventHandler(CajasoloDecimales_KeyPress);
                    cajaTexto.KeyPress += new KeyPressEventHandler(CajasoloDecimales_KeyPress);
                    cajaTexto.KeyUp -= new KeyEventHandler(txt_precio_keyup);
                    cajaTexto.KeyUp += new KeyEventHandler(txt_precio_keyup);
                    cajaTexto.LostFocus -= new EventHandler(txt_precio_lostFocus);
                    cajaTexto.LostFocus += new EventHandler(txt_precio_lostFocus);
                }
                cajaTexto.SelectedIndexChanged -= new EventHandler(cmb_precio_changed);
                cajaTexto.SelectedIndexChanged += new EventHandler(cmb_precio_changed);
            }
            else if (grw_productos.CurrentCell.ColumnIndex == grw_productos.Columns["descripcion"].Index)
            {
                TextBox cajaTexto = e.Control as TextBox;
                cajaTexto.AutoCompleteCustomSource = null;
                this.eliminarEventos(cajaTexto);
                cajaTexto.KeyUp += new KeyEventHandler(txt_descripcion_keyup);
            }
        }

        private void txt_descripcion_keyup(object sender, KeyEventArgs e)
        {
            string descripcion = String.IsNullOrEmpty(((TextBox)sender).Text) ? "" : ((TextBox)sender).Text;
            this.grw_productos.CurrentRow.Cells["descripcion"].Value = descripcion;
        }

        private void cmb_precio_changed(object sender, EventArgs e)
        {
            int fila = this.grw_productos.CurrentRow.Index;
            if (!String.IsNullOrEmpty(General.obtenerValorCelda(this.grw_productos, fila, "cantidad")))
            {
                this.setearValoresFila(fila,Convert.ToDecimal(((ComboBox)sender).Text),-1);
            }
        }

        private void grw_productos_cellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (General.obtenerValorCelda(this.grw_productos, this.grw_productos.CurrentRow.Index, "pvp_manual") == "1")
            {
                //if(!String.IsNullOrEmpty(General.obtenerValorCelda(this.grw_productos, this.grw_productos.CurrentRow.Index, "precioU")))return;
                int columna = grw_productos.Columns["precioU"].Index;
                if (grw_productos.CurrentCell.ColumnIndex == columna)
                {
                    DataGridViewComboBoxCell combo = (DataGridViewComboBoxCell)this.grw_productos[columna, e.RowIndex];
                    if (String.IsNullOrEmpty(this.pvpManual)) this.pvpManual = "0";
                    //{
                    bool existe = false;
                    foreach (Object valor in combo.Items)
                    {
                        if (valor.ToString() == this.pvpManual)
                        {
                            existe = true;
                            break;
                        }
                    }
                    if (!existe) combo.Items.Add(this.pvpManual);
                    combo.Value = this.pvpManual;
                    this.pvpManual = "";
                    //}
                    //else combo.Value = combo.Items[0];
                }
            }
        }

        private void txt_precio_lostFocus(object sender, System.EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            this.pvpManual = combo.Text;
            //if (!String.IsNullOrEmpty(combo.Text)) this.pvpModificado = true;
        }

        private void txt_precio_keyup(object sender, KeyEventArgs e)
        {
            int fila = this.grw_productos.CurrentRow.Index;
            if (!String.IsNullOrEmpty(General.obtenerValorCelda(this.grw_productos, fila, "cantidad")))
            {
                decimal valor = String.IsNullOrEmpty(((ComboBox)sender).Text)? 0 : Convert.ToDecimal(((ComboBox)sender).Text);
                this.setearValoresFila(fila, valor, -1);
            }
        }

        private void txt_pdes_keyup(object sender, KeyEventArgs e)
        {
            decimal descuento = String.IsNullOrEmpty(((TextBox)sender).Text)? 0 : Convert.ToDecimal(((TextBox)sender).Text);
            decimal pDescuento = descuento / 100;
            DataGridViewRow fila = this.grw_productos.CurrentRow;
            decimal cantidad = Convert.ToDecimal(fila.Cells["cantidad"].Value);
            decimal pvp = Convert.ToDecimal(fila.Cells["precioU"].Value);
            decimal valor = cantidad * pvp;
            decimal valorDescuento = Math.Round((valor * pDescuento),2);
            fila.Cells["pdesc"].Value = descuento;
            fila.Cells["subtotaldesc"].Value = valorDescuento;
            fila.Cells["subtotal"].Value = General.truncar((valor - valorDescuento),2); //
            calcularValoresAPagar();


        }
        private void txt_cantidad_keyup(object sender, KeyEventArgs e)
        {
            int fila = this.grw_productos.CurrentRow.Index;
            string texto = ((TextBox)sender).Text;
            decimal cantidad = String.IsNullOrEmpty(texto) || texto == "."? 0 : Convert.ToDecimal(((TextBox)sender).Text); 
            if (General.obtenerValorCelda(this.grw_productos, fila, "llena") == "1")this.setearValoresFila(fila,-1,cantidad);
          
        }

        private void CajasoloDecimales_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.permitirDecimales(sender, e);
        }

        private void CajasoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.soloNumeros(e);
        }

        protected void agregarFila()
        {
            if (General.filaVacia(this.grw_productos.Rows[this.grw_productos.Rows.Count - 1])) return;
            this.grw_productos.Rows.Add();
        }

        private void grw_productos_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            if (!deboBuscar) return;
            string nombre = this.grw_productos.Columns[e.ColumnIndex].Name;
            if (!(nombre == "codigo" || nombre == "producto")) return;
            if (string.IsNullOrEmpty(General.obtenerValorCelda(grw_productos, e)))
            {
                if (General.obtenerValorCelda(this.grw_productos, e.RowIndex, "llena") == "1")
                {
                    General.filaVaciar(this.grw_productos.CurrentRow, e.ColumnIndex);
                    this.calcularValoresAPagar();
                }
                return;
            }
            this.deboBuscar = false;
            if(nombre == "codigo") this.buscarProducto(General.obtenerValorCelda(grw_productos, e), String.Empty, e.RowIndex);
            else if (nombre == "producto")this.buscarProducto(String.Empty, General.obtenerValorCelda(grw_productos, e), e.RowIndex);
            this.deboBuscar = true;  
        }

        private void calcularValoresAPagar()
        {

            decimal productosIva = 0,productosNoIva = 0,desc = 0, totalIva = 0,servicio = 0, subtotalTotal;
            decimal ivaActual, valorDescuentoActual, subtotalActual, valorActual, cantidadActual, pDescuento;
            foreach (DataGridViewRow fila in this.grw_productos.Rows)
            {
                if (General.obtenerValorCelda(this.grw_productos, fila.Index, "llena") == "1")
                {

                    ivaActual = Convert.ToDecimal(fila.Cells["iva"].Value);
                    subtotalActual = Convert.ToDecimal(fila.Cells["subtotal"].Value);
                    valorDescuentoActual = Convert.ToDecimal(fila.Cells["subtotaldesc"].Value);
                    valorActual = Convert.ToDecimal(fila.Cells["precioU"].Value);
                    cantidadActual = Convert.ToDecimal(fila.Cells["cantidad"].Value);
                    pDescuento = Convert.ToDecimal(fila.Cells["pdesc"].Value);
                    //if (fila.Cells["iva"].Value != null && fila.Cells["iva"].Value.ToString() != "0" && fila.Cells["iva"].Value.ToString() != "-1")
                    //{
                    //    productosIva = productosIva + subtotalActual;
                    //    totalIva += subtotalActual;
                    //}
                    //else productosNoIva = productosNoIva + subtotalActual;

                    if (ivaActual != 0)
                    {
                        
                        totalIva += (subtotalActual * ivaActual / 100);
                        //totalIva = General.truncar(total, 2);
                        productosIva += subtotalActual;
                    }
                    else productosNoIva += subtotalActual;

                    desc = desc + valorDescuentoActual;
          
                }
             }

           
            subtotalTotal = productosIva + productosNoIva;

             if (confPredeterminada.Servicio && this.chk_servicio.Checked)servicio = (subtotalTotal * 0.10m);

            // set valores finales con 4 decimales
             productosNoIva = Decimal.Round(productosNoIva, 2);
             productosIva = Decimal.Round(productosIva, 2);
             desc = Decimal.Round(desc, 2);
             totalIva = Decimal.Round(totalIva, 2);
             //valorIce = Decimal.Round(valorIce, 2);
             servicio = Decimal.Round(servicio, 2);

             this.txt_iva0.Text = productosNoIva.ToString();
             this.txt_iva12.Text = productosIva.ToString(); 
             this.txt_descuento.Text = desc.ToString();
             this.txt_iva.Text = totalIva.ToString();
             this.txt_servicio.Text = servicio.ToString();
             this.txt_total.Text = Decimal.Round((subtotalTotal + totalIva + servicio), 2).ToString("#,##0.00");
             //this.txt_saldo.Text = (decimal.Parse(this.txt_total.Text) - decimal.Parse(this.txt_totalpago.Text)).ToString();
             this.txt_total.Left = (this.pan_totales.Width - this.txt_total.Width) / 2;
             calcularTotalPagado();
            }

        private void txt_efectivo_KeyUp(object sender, KeyEventArgs e)
        {
            this.calcularTotalPagado();
        }

        protected void calcularTotalPagado()
        {
            decimal total = 0;
            if (this.pagoParcial)
            {
                if (this.pagos != null)
                {
                    foreach (FormaPago pago in this.pagos)
                    {
                        total += pago.getValor();
                    }
                }
            }
            else
            {
                total = General.convertirDecimal(this.txt_montoc.Text) +
                        General.convertirDecimal(this.txt_montot1.Text) +
                        General.convertirDecimal(this.txt_montot2.Text) +
                        General.convertirDecimal(this.txt_efectivo.Text) +
                        General.convertirDecimal(this.txt_retencion.Text) +
                        General.convertirDecimal(this.txt_montoNota.Text);
            }
            decimal total_fact = General.convertirDecimal(this.txt_total.Text);
            this.txt_totalpago.Text = Decimal.Round(total, this.cantidadDecimales).ToString();
            decimal saldo = total_fact - total;
            
            if (saldo < 0)
            {
                this.txt_saldo.Text = "0";
                this.txt_vuelto.Text = Decimal.Round(total - total_fact, this.cantidadDecimales).ToString();
            }
            else
            {
                this.txt_saldo.Text = Decimal.Round((saldo), this.cantidadDecimales).ToString();
                this.txt_vuelto.Text = "0";
            }

            if (this.pagoParcial) this.btn_agregarPago.Enabled = !(Convert.ToDecimal(this.txt_saldo.Text) == 0);
        }

        private void txt_calcularTotalesAPagar(object sender, KeyEventArgs e)
        {
            this.calcularTotalPagado();
        }

        private void txt_monto_click(object sender, EventArgs e)
        {
            TextBox cajaTexto = (TextBox)sender;
            if (cajaTexto.Text == "0") cajaTexto.SelectAll();
        }

        private void imprimirAbono()
        {
            if (!this.pagoParcial) return;
            if (String.IsNullOrEmpty(impresora2)) return;
            decimal monto = this.obtenerMontoAbonado();
            if (monto > 0)
            {
                ImpresionAbono impresion = new ImpresionAbono();
                impresion.clienten = this.txt_Nombres.Text;
                impresion.monto_abonado = monto.ToString();
                impresion.total = this.txt_total.Text;
                impresion.total_abonado = this.txt_totalpago.Text;
                impresion.pagos = this.pagos;
                impresion.saldo = this.txt_saldo.Text;
                impresion.idpos = this.txt_secuencia.Text;
                impresion.vuelto = this.txt_vuelto.Text;

                Thread hiloImpresion = null;
                hiloImpresion = new Thread(new ThreadStart(() =>
                {
                    impresion.imprimir(this.impresora2);
                }));
                hiloImpresion.Start();
            }
        }

        private decimal obtenerMontoAbonado()
        {
            decimal monto = 0;
            foreach (DataGridViewRow fila in this.grw_abonos.Rows)
            {
                if (fila.Cells["nuevo"].Value != null && fila.Cells["nuevo"].Value.ToString() == "1")
                {
                    monto += Convert.ToDecimal(fila.Cells["valor"].Value.ToString());
                }
            }
            return monto;
        }

        protected void actualizarFactura(bool puedoImprimir)
        {
            if (cmb_estado.SelectedValue.ToString() == "A")
            {
                    String msn = "";
                    if (FacturaCabeceraTR.anularFactrura(ref msn, this.idFactura, this.idUsuarioAnular))
                    {
                        Mensaje.informacion("Factura anulada correctamente.");
                        this.estadoInicial();
                    }
                    else Mensaje.advertencia(msn);
            }
            else if(!this.confPredeterminada.Sin_cobro)Mensaje.advertencia("No se ha realizado ningún cambio.");            
            else {

                try
                {
                    if (!validarIngreso(puedoImprimir)) return;
                    FacturaCabecera factura = (this.tsb_imprimir.Enabled)?this.tomarDatosCabecera(puedoImprimir):null;
                    List<FacturaDetalle> listaDetalle = (this.tsb_imprimir.Enabled) ? this.obtenerFacturaDetalle() : null;
                    FacturaCabeceraTR tranFactura = new FacturaCabeceraTR();
                    List<FormaPago> listaFormaPago = null;
                    string estadoFactura = (!this.tsb_imprimir.Enabled)?this.cmb_estado.SelectedValue.ToString():null;
                    listaFormaPago = ((Convert.ToDecimal(this.txt_saldo.Text) == 0 && !this.facturaPagada) || this.pagoParcial) ? this.obtenerFormasDePago() : null;
                    if (!validarDatos(puedoImprimir, factura, listaFormaPago)) return;
                    if (tranFactura.actualizarFactura(factura, listaDetalle, listaFormaPago, (factura != null) ? -1 : this.idFactura, this.pagosEliminados, estadoFactura))
                    {
                        if (this.confPredeterminada.SecuenciaAlImprimir && puedoImprimir && this.impresoraDisponible)// Si es false se activa el secuencia, si es verdadero no se activa
                        {
                            string msn = "";
                            ConfiguracionPosTR.actualizarNumeroActual(this.confPredeterminada.Idconf_pos, this.confPredeterminada.Sec_actual, this.confPredeterminada.Tipo_doc, ref msn);
                            if (!String.IsNullOrEmpty(msn)) Mensaje.mostrarNotificacion("Facturas omitidas", msn);
                        }
                        this.imprimirPedido(factura);
                        if (!puedoImprimir) this.imprimirAbono();
                        //--------------------- IMPRIMIR FACTURA -------------------------
                        if (puedoImprimir && this.impresoraDisponible) this.imprimirFactura();

                        if (this.formularioPendientes)
                        {
                            if (factura == null || factura.Estado != "P") this.removerPendiente((factura == null) ? this.idFactura.ToString() : factura.Id.ToString());
                            else this.modificarPendiente(factura.Id.ToString(), (factura.Adicionales == null || factura.Adicionales.Count < this.adicionalPendiente) ? "" : factura.Adicionales[this.adicionalPendiente - 1].valor, puedoImprimir);
                        }

                        Mensaje.informacion("Factura actualizada correctamente.");
                        this.estadoInicial();
                    }
                }
                catch (Exception e)
                {
                    Mensaje.error("Ha ocurrido un error.\n" + e.Message);
                    this.estadoInicial();
                }
            }
        }

        private bool validarDatos(bool voyImprimir, FacturaCabecera factura, List<FormaPago> listaFormaPago)
        {
            if (factura == null) return true;
            decimal totalPagar, totalTarjeta, totalCheque, totalCredito, totalRetencion, totalEfectivo;
            totalPagar = totalTarjeta = totalCheque = totalCredito = totalRetencion = totalEfectivo = 0;
            totalPagar = factura.Total;

            if (listaFormaPago != null)
            {
                foreach (FormaPago pago in listaFormaPago)
                {
                    totalRetencion += pago.Monto_retencion;
                    totalCheque += pago.Monto_cheque;
                    totalTarjeta += pago.Monto_tarjeta;
                    totalCredito += pago.Monto_nota;
                    totalEfectivo += pago.Monto_efectivo;
                }
            }

            if (!this.vueltoCredito && (totalTarjeta > totalPagar))
            {
                Mensaje.advertencia("El pago con tarjeta de crédito debe ser igual o menor al total a cobrar.");
                return false;
            }
            if (!this.vueltoCheque && (totalCheque > totalPagar))
            {
                Mensaje.advertencia("El pago con cheque debe ser igual o menor al total a cobrar.");
                return false;
            }

            if (totalRetencion > factura.Total)
            {
                Mensaje.advertencia("El pago con retención debe ser igual o menor al total a cobrar.");
                return false;
            }

            if (totalCredito > factura.Total)
            {
                Mensaje.advertencia("El pago con nota de crédito debe ser igual o menor al total a cobrar.");
                return false;
            }

            if (totalTarjeta + totalCheque + totalRetencion + totalCredito > totalPagar)
            {
                Mensaje.advertencia("Sólo se permite vueltos para pagos en efectivo.");
                return false;
            }

            if (this.propina && Convert.ToDecimal(this.txt_propina.Text) > 0 && totalTarjeta == 0)
            {
                Mensaje.advertencia("Sólo se permite dejar propina en pagos con tarjeta de crédito.");
                return false;
            }

            decimal pagado = totalRetencion + totalCheque + totalTarjeta + totalCredito + totalEfectivo - factura.Vuelto;
            decimal saldo = factura.Total - pagado;

            if (pagado > factura.Total)
            {
                Mensaje.advertencia("Por favor revise los datos del cobro.");
                return false;
            }

            //if (this.pagoParcial) return true;
            if (factura.Estado == "P")
            {
                if (pagado != 0 && saldo != 0 && !this.pagoParcial)
                {
                    Mensaje.advertencia("Se debe cobrar todo o nada del valor a pagar.");
                    return false;
                }
                if (saldo == 0 && !voyImprimir && this.tsb_imprimir.Enabled && !this.pagoParcial)
                {
                    Mensaje.advertencia("Una vez cobrada la factura debe ser impresa.");
                    return false;
                }

            }
            else
            {
                if (saldo != 0)
                {
                    Mensaje.advertencia("No se ha cobrado el valor total.");
                    return false;
                }

                if (!this.pagoParcial && !voyImprimir && this.tsb_imprimir.Enabled)
                {
                    Mensaje.advertencia("Una vez cobrada la factura debe ser impresa.");
                    return false;
                }
            }
            return true;
    
        }

        protected void guardarFactura(bool puedoImprimir, bool vieneDereversar = true)
        {
            //try
            //{
                //--------------------------- GUARDAR CABECERA -------------------------
                if (!validarIngreso(puedoImprimir)) return;

                FacturaCabecera factura = this.tomarDatosCabecera(puedoImprimir);
                //---------------------- GUARDAR DETALLE ---------------------------
                List<FacturaDetalle> listaDetalle = this.obtenerFacturaDetalle();
                //------------------- GUARDAR FORMA DE PAGO --------------------------
                List<FormaPago> listaFormaPago = (Convert.ToDecimal(this.txt_saldo.Text) == 0 || this.pagoParcial) ? this.obtenerFormasDePago() : null;
                FacturaCabeceraTR tranFactura = new FacturaCabeceraTR();
                if (!validarDatos(puedoImprimir, factura, listaFormaPago)) return;

                if (tranFactura.guardarFactura(factura, listaDetalle, listaFormaPago))
                {
                    this.idFactura = factura.Id;
                    if (vieneDereversar == true)
                    {

                    if ((this.confPredeterminada.Activar_secuencia && !this.chk_dna.Checked && (factura.Estado == "A" || !this.confPredeterminada.SecuenciaAlImprimir)) || (this.confPredeterminada.SecuenciaAlImprimir && puedoImprimir && this.impresoraDisponible))// Si es false se activa el secuencia, si es verdadero no se activa
                    {
                        string msn = "";
                        ConfiguracionPosTR.actualizarNumeroActual(this.confPredeterminada.Idconf_pos, this.confPredeterminada.Sec_actual, this.confPredeterminada.Tipo_doc, ref msn);
                        if (!String.IsNullOrEmpty(msn)) Mensaje.mostrarNotificacion("Facturas omitidas", msn);
                    }
                    }
                    this.imprimirPedido(factura);
                    if(!puedoImprimir)this.imprimirAbono();
                    //--------------------- IMPRIMIR FACTURA -------------------------
                    if (puedoImprimir && this.impresoraDisponible) this.imprimirFactura();
                    if (factura.Estado == "P" && this.formularioPendientes) this.agregarPendiente(factura.Id.ToString(), (factura.Adicionales == null || factura.Adicionales.Count < this.adicionalPendiente) ? "" : factura.Adicionales[this.adicionalPendiente - 1].valor, false);
                    Mensaje.informacion("Factura almacenda correctamente.");
                    this.estadoInicial();
                }
            //}
            //catch (Exception e)
            //{
            //    Mensaje.error("Ha ocurrido un error.\n" + e.Message);
            //    this.estadoInicial();
            //}

        }

        protected void imprimirPedido(FacturaCabecera factura)
        {
            if (this.ubicaciones == null) return;
            foreach (FacturaDetalle producto in this.productosEliminados) this.agregarUbicacionEliminada(producto);
            foreach (Ubicacion ubicacion in this.ubicaciones)
            {
                if (ubicacion.productos.Count > 0 || ubicacion.productosEliminados.Count > 0)
                {
                    Pedido pedido = new Pedido(ubicacion, this.controlesAdicionales, (factura != null)?factura.Numero_documento:"", this.txt_Nombres.Text, this.txt_secuencia.Text, this.txt_total.Text);
                    pedido.imprimir();
                }
            }
        }

        protected FacturaCabecera tomarDatosCabecera(bool voyImprimir)
        {
            FacturaCabecera factura = new FacturaCabecera();
            factura.Id = this.idFactura;
            factura.IdConfPos = confPredeterminada.Idconf_pos;
            factura.IdCliente = this.idCliente;
            factura.IdCajero = Global.idEmpleado;
            factura.Estado = this.cmb_estado.SelectedValue.ToString();
            factura.IdUsuarioAnular = this.idUsuarioAnular;
            factura.PagoParcial = this.pagoParcial;

            if (this.seleccionarVendedor) factura.IdVendedor = Convert.ToInt32(this.cmb_vendedor.SelectedValue);
            else factura.IdVendedor = factura.IdCajero;

            factura.DescuentoFactura = General.convertirDecimal(txt_descProducto.Text);
            if (!this.chk_dna.Checked && this.confPredeterminada.Tipo_doc!= "D")
            {
                if (this.confPredeterminada.Tipo_doc == "F") factura.Id_tipoDocumento = 1;
                else factura.Id_tipoDocumento = 2;

                if (this.estadoGuardar || this.confPredeterminada.SecuenciaAlImprimir || (voyImprimir && !this.confPredeterminada.Activar_secuencia))
                {
                    factura.Numero_documento = (this.confPredeterminada.SecuenciaAlImprimir && (!voyImprimir || !this.impresoraDisponible) && factura.Estado != "A") ? "" : this.txt_numDoc.Text;
                    if (this.confPredeterminada.Activar_secuencia)
                    {
                        factura.Numero_actual = (this.confPredeterminada.SecuenciaAlImprimir && (!voyImprimir || !this.impresoraDisponible) && factura.Estado != "A") ? 0 : this.confPredeterminada.Sec_actual;
                    }
                    else
                    {
                        if (this.txt_numDoc.Text.Length > 8)
                        {
                            int numero;
                            if (Int32.TryParse(this.txt_numDoc.Text.Substring(8), out numero)) factura.Numero_actual = Convert.ToInt32(numero);
                        }
                    }
                }
            }
            else
            {
                factura.Id_tipoDocumento = 3;
                factura.Numero_documento = this.txt_numDoc.Text;
                factura.Numero_actual = 0;
                //factura.Numero_actual = int.Parse(this.txt_numDoc.Text);
            }

            factura.Fecha_vencimiento = (this.flp_fechaVencimiento.Visible) ? this.dtp_vencimiento.Value : DateTime.Now;
            factura.Autorizacion = this.txt_numAut.Text;
            factura.Fecha_creacion = DateTime.Now;
            factura.Descuento = decimal.Parse(txt_descuento.Text.ToString());
            factura.Servicio = decimal.Parse(txt_servicio.Text.ToString());
            factura.Tarifa_0 = decimal.Parse(txt_iva0.Text.ToString());
            factura.Tarifa_12 = decimal.Parse(txt_iva12.Text.ToString());
            factura.Total_iva = decimal.Parse(txt_iva.Text.ToString());
            factura.Total = decimal.Parse(txt_total.Text.ToString());
            factura.Descripcion = (String.IsNullOrEmpty(this.txt_descipcion.Text))?this.facturaDescripcion:this.txt_descipcion.Text;

            factura.Empresa_id = confPredeterminada.Id_empresa;
            factura.Establecimiento_id = confPredeterminada.Id_establecimiento;
            factura.IdCaja = this.idCaja;
            factura.Tipo = this.confPredeterminada.Tipo_doc;
            factura.Vuelto = decimal.Parse(this.txt_vuelto.Text);
            factura.Propina = (!String.IsNullOrEmpty(this.txt_propina.Text))?decimal.Parse(this.txt_propina.Text):0;
            if (controlesAdicionales != null)
            {
                factura.Adicionales = new List<adicionalFactura>();
                foreach (Control control in controlesAdicionales)
                {
                    adicionalFactura adicional = new adicionalFactura();
                    adicional.idAdicional = Convert.ToInt32(control.Name.Substring(2));
                    adicional.valor = control.Text;
                    factura.Adicionales.Add(adicional);
                }
            }
            return factura;
        }

        private List<FacturaDetalle> obtenerFacturaDetalle()
        {
            List<FacturaDetalle> listaDetalle = new List<FacturaDetalle>();
            foreach (DataGridViewRow fila in this.grw_productos.Rows)
            {
                FacturaDetalle facturaDetalle = new FacturaDetalle();
                facturaDetalle.Cantidad = Convert.ToDecimal(fila.Cells["cantidad"].Value);
                if (facturaDetalle.Cantidad != 0)
                {
                    facturaDetalle.Id_producto = Convert.ToInt32(fila.Cells["id_producto"].Value);
                    facturaDetalle.Porc_descuento = Convert.ToDecimal(fila.Cells["pdesc"].Value);
                    facturaDetalle.Valor_descuento = Convert.ToDecimal(fila.Cells["subtotaldesc"].Value);
                    facturaDetalle.Precio = Convert.ToDecimal(fila.Cells["precioU"].Value);
                    facturaDetalle.Producto = fila.Cells["producto"].Value.ToString();
                    facturaDetalle.Pvp_venta = Convert.ToDecimal(fila.Cells["precioU"].Value);
                    facturaDetalle.Total = Convert.ToDecimal(fila.Cells["subtotal"].Value);
                    facturaDetalle.Porc_Iva = General.convertirDecimal(fila.Cells["iva"].Value);
                    if (facturaDetalle.Porc_Iva == 0) facturaDetalle.Base_cero = facturaDetalle.Total;
                    else if (facturaDetalle.Porc_Iva == -1) facturaDetalle.Base_nogravable = facturaDetalle.Total;
                    else facturaDetalle.Base_gravable = facturaDetalle.Total;
                    facturaDetalle.Idfactura_detalle = Convert.ToInt32(fila.Cells["id_detalle"].Value);
                    facturaDetalle.Descripcion = (!General.celdaVacia(fila.Cells["descripcion"])) ? fila.Cells["descripcion"].Value.ToString() : "";
                    //facturaDetalle.ListaCombo = (List<ProductoCombo>)fila.Cells["lista_combo"].Value;
                    facturaDetalle.EsCombo = !General.celdaVacia(fila.Cells["combo"]);
                    if (fila.Cells["referencia_combo"].Value == null)
                    {
                        if (facturaDetalle.Idfactura_detalle == -1) this.agregarUbicacion(facturaDetalle);
                        else if (Convert.ToBoolean(fila.Cells["modifico"].Value)) this.agregarProductoModificado(facturaDetalle);
                    }

                    if (!General.celdaVacia(fila.Cells["id_serie"]))
                    {
                        facturaDetalle.Id_Serie = Convert.ToInt32(fila.Cells["id_serie"].Value);
                    }
                    listaDetalle.Add(facturaDetalle);
                }

            }

            return listaDetalle;
        }

        private void agregarUbicacion(FacturaDetalle facturaDetalle)
        {
            if (this.ubicaciones == null) return;
            List<int> ubicaciones = UbicacionTR.consultarUbicacionesProducto(facturaDetalle.Id_producto);
            if (ubicaciones == null && !this.imprimirUbicaciones) return;
            if (ubicaciones == null)
            {
                foreach (Ubicacion ubicacion in this.ubicaciones)
                {
                    this.agregarUbicacionLista(facturaDetalle, ubicacion);
                }
            }
            else
            {
                foreach (int idUbicacion in ubicaciones)
                {
                    Ubicacion ubicacion = this.ubicaciones.Find(element => element.id == idUbicacion);
                    if (ubicacion != null)
                    {
                        this.agregarUbicacionLista(facturaDetalle, ubicacion);
                    }
                }
            }
        }

        private void agregarUbicacionLista(FacturaDetalle facturaDetalle, Ubicacion ubicacion)
        {
            FacturaDetalle detalle = (facturaDetalle.EsCombo) ? null : ubicacion.productos.Find(element => element.Id_producto == facturaDetalle.Id_producto && element.Descripcion == facturaDetalle.Descripcion);
            if (detalle == null) ubicacion.productos.Add(facturaDetalle);
            else
            {

                FacturaDetalle nuevo = new FacturaDetalle();
                nuevo.Producto = detalle.Producto;
                nuevo.Descripcion = detalle.Descripcion;
                nuevo.Cantidad = detalle.Cantidad + facturaDetalle.Cantidad;
                ubicacion.productos.Remove(detalle);
                ubicacion.productos.Add(nuevo);
            }
        }

        private void agregarUbicacionEliminada(FacturaDetalle facturaDetalle)
        {
            List<int> ubicaciones = UbicacionTR.consultarUbicacionesProducto(facturaDetalle.Id_producto);
            if (ubicaciones == null && !this.imprimirUbicaciones) return;
            if (ubicaciones == null)
            {
                foreach (Ubicacion ubicacion in this.ubicaciones)
                {
                    this.eliminarUbicacionLista(facturaDetalle, ubicacion);
                }
            }
            else
            {
                foreach (int idUbicacion in ubicaciones)
                {
                    Ubicacion ubicacion = this.ubicaciones.Find(element => element.id == idUbicacion);
                    if (ubicacion != null)
                    {
                        this.eliminarUbicacionLista(facturaDetalle, ubicacion);
                    }
                }
            }
        }

        private void eliminarUbicacionLista(FacturaDetalle facturaDetalle, Ubicacion ubicacion)
        {
            FacturaDetalle detalle = ubicacion.productosEliminados.Find(element => element.Id_producto == facturaDetalle.Id_producto && element.Descripcion == facturaDetalle.Descripcion);
            if (detalle == null) ubicacion.productosEliminados.Add(facturaDetalle);
            else
            {
                //nuevo.Cantidad = detalle.Cantidad + facturaDetalle.Cantidad;
            }
        }

        private void agregarProductoModificado(FacturaDetalle actual)
        {
            String[] original = FacturaDetalleTR.consultarCambios(actual.Idfactura_detalle);
            int idProductoAnterior = Convert.ToInt32(original[0]);
            int cantidadAnterior = (int)Convert.ToDecimal(original[1]);
            //string nombre = original[2];
            string descripcionAnterior = original[3];

            if (descripcionAnterior != actual.Descripcion)/*si cambio el producto*/
            {
                this.agregarUbicacion(actual);
                FacturaDetalle eliminado = new FacturaDetalle();
                eliminado.Producto = actual.Producto;
                eliminado.Descripcion = descripcionAnterior;
                eliminado.Cantidad = cantidadAnterior;
                eliminado.Id_producto = idProductoAnterior;
                this.productosEliminados.Add(eliminado);
                return;

            }
            if (actual.Cantidad < cantidadAnterior)//si la cantidad actual es menor a la que había antes (eliminar productos)
            {
                FacturaDetalle modificado = new FacturaDetalle();
                modificado.Producto = actual.Producto;
                modificado.Id_producto = actual.Id_producto;
                modificado.Cantidad = cantidadAnterior - actual.Cantidad;
                modificado.Descripcion = actual.Descripcion;
                this.productosEliminados.Add(modificado);
            }
            else //si la cantidad actual es mayor a la que había antes
            {
                FacturaDetalle modificado = new FacturaDetalle();
                modificado.Producto = actual.Producto;
                modificado.Id_producto = actual.Id_producto;
                modificado.Cantidad = actual.Cantidad - cantidadAnterior;
                modificado.Descripcion = actual.Descripcion;
                this.agregarUbicacion(modificado);
            }
        }

        protected List<FormaPago> obtenerFormasDePago()
        {
            if (this.pagoParcial) return this.pagos;
            List<FormaPago> listaFormaPago = new List<FormaPago>();

            if (!General.vacioOCero(txt_efectivo.Text))
            {
                FormaPago pagoEfectivo = new FormaPago();
                //pagoEfectivo.Id_cabecera = factura.Idfactura_cabecera;
                pagoEfectivo.Forma_pago = "EF";
                pagoEfectivo.Monto_efectivo = decimal.Parse(this.txt_efectivo.Text);
                pagoEfectivo.Id_Caja = this.idCaja;
                listaFormaPago.Add(pagoEfectivo);
            }

            if (!General.vacioOCero(txt_montoc.Text))
            {
                FormaPago pagoCheque = new FormaPago();
                //pagoCheque.Id_cabecera = factura.Idfactura_cabecera;
                pagoCheque.Forma_pago = "CH";
                pagoCheque.Monto_cheque = decimal.Parse(this.txt_montoc.Text);
                pagoCheque.Numero_cheque = this.txt_numeroc.Text;
                pagoCheque.Banco = this.txt_banco.Text;
                pagoCheque.Id_Caja = this.idCaja;
                listaFormaPago.Add(pagoCheque);
            }

            if (!General.vacioOCero(this.txt_montot1.Text))
            {
                FormaPago pagoTarjeta = new FormaPago();
                //pagoTarjeta.Id_cabecera = factura.Idfactura_cabecera;
                pagoTarjeta.Forma_pago = "TC";
                pagoTarjeta.Monto_tarjeta = decimal.Parse(this.txt_montot1.Text);
                pagoTarjeta.Numero_tarjeta = this.txt_numerot1.Text;
                pagoTarjeta.Tipo_tarjeta = this.cmb_tipo1.SelectedValue.ToString();
                pagoTarjeta.Tipo_ping = this.cmb_pin1.SelectedValue.ToString();
                pagoTarjeta.Id_Caja = this.idCaja;
                listaFormaPago.Add(pagoTarjeta);
            }
            if (!General.vacioOCero(this.txt_montot2.Text))
            {
                FormaPago pagoTarjeta = new FormaPago();
                //pagoTarjeta.Id_cabecera = factura.Idfactura_cabecera;
                pagoTarjeta.Forma_pago = "TC";
                pagoTarjeta.Monto_tarjeta = decimal.Parse(this.txt_montot2.Text);
                pagoTarjeta.Numero_tarjeta = this.txt_numerot2.Text;
                pagoTarjeta.Tipo_tarjeta = this.cmb_tipo2.SelectedValue.ToString();
                pagoTarjeta.Tipo_ping = this.cmb_pin2.SelectedValue.ToString();
                pagoTarjeta.Id_Caja = this.idCaja;
                listaFormaPago.Add(pagoTarjeta);
            }

            if (!General.vacioOCero(this.txt_retencion.Text))
            {
                FormaPago pagoRetencion = new FormaPago();
                //pagoRetencion.Id_cabecera = factura.Idfactura_cabecera;
                pagoRetencion.Forma_pago = "RF";
                pagoRetencion.Monto_retencion = decimal.Parse(this.txt_retencion.Text);
                pagoRetencion.Numero_retencion = int.Parse(this.txt_numeroRetencion.Text);
                pagoRetencion.Id_Caja = this.idCaja;
                listaFormaPago.Add(pagoRetencion);
            }

            if (!General.vacioOCero(this.txt_montoNota.Text))
            {
                FormaPago pagoNota = new FormaPago();
                //pagoNota.Id_cabecera = factura.Idfactura_cabecera;
                pagoNota.Forma_pago = "NC";
                pagoNota.Monto_nota = decimal.Parse(this.txt_montoNota.Text);
                pagoNota.Numero_Nota = int.Parse(this.txt_numeroNota.Text);
                pagoNota.Id_Caja = this.idCaja;
                listaFormaPago.Add(pagoNota);
            }

            return listaFormaPago;
        }

        protected bool validarIngreso(bool voyImprimir) {

            if ((this.chk_dna.Checked || (this.cmb_estado.SelectedValue.ToString() != "P" && !this.confPredeterminada.Activar_secuencia) || voyImprimir))
            {
                if (String.IsNullOrEmpty(this.txt_numDoc.Text))
                {
                    this.txt_numDoc.Focus();
                    Mensaje.advertencia("Ingrese un número de Documento");
                    return false;
                }
                if (this.confPredeterminada.Tipo_doc != "D" && !this.chk_dna.Checked && !this.confPredeterminada.Activar_secuencia)
                {
                    System.Text.RegularExpressions.Regex expresion = new System.Text.RegularExpressions.Regex(@"\d\d\d(-)\d\d\d(-)\d\d\d\d\d\d\d\d\d");
                    System.Text.RegularExpressions.Match match = expresion.Match(this.txt_numDoc.Text);
                    if (!match.Success)
                    {
                        this.txt_numDoc.Focus();
                        Mensaje.advertencia("El número de documento no tiene el formato correcto.");
                        return false;
                    }

                    
                    int numero;
                    if (Int32.TryParse(this.txt_numDoc.Text.Substring(8), out numero))
                    {
                        string mensaje = "";
                        if (!FacturaCabeceraTR.secuenciaCorrecta(ref mensaje, numero, this.idFactura, this.confPredeterminada.Tipo_doc, this.confPredeterminada.Autorizacion))
                        {
                            if (String.IsNullOrEmpty(mensaje)) Mensaje.advertencia("El número de factura ingresado ya existe.");
                            else Mensaje.advertencia(mensaje);
                            return false;
                        }
                        
                    }

                }
            }

            if (this.cmb_estado.Text == "ANULADA") return true;

            if (controlesAdicionales != null)
            {
                foreach (Control control in controlesAdicionales)
                {
                    if (control.CausesValidation)
                    {
                        if ((control is ComboBox && ((ComboBox)control).SelectedIndex == 0) || String.IsNullOrEmpty(control.Text))
                        {
                            Mensaje.advertencia("Ingrese valor para " + control.AccessibleName + ".");
                            return false;
                        }
                    }
                }
            }

            if (this.idCliente == 0)
            {
                this.txt_ruc.Focus();
                Mensaje.advertencia("Por favor escoja un Cliente");
                return false;
            }
            if (this.grw_productos.RowCount <= 0 || (this.grw_productos.RowCount == 1 && General.filaVacia(this.grw_productos.Rows[0])))
            {
                Mensaje.advertencia("Debe de ingresar por lo menos un producto.");
                return false;
            }
            int i = 1;
            int ultimaFila = this.grw_productos.RowCount;
            //if(General.filaVacia(this.grw_productos.Rows[this.grw_productos.RowCount -1]))
            DataGridViewCell celdaCantidad, celdaProducto, celdaDescuento;
            bool esUltimaVacia = false;
            foreach (DataGridViewRow fila in this.grw_productos.Rows)
            {
                celdaCantidad = fila.Cells["cantidad"];
                celdaProducto = fila.Cells["llena"];
                celdaDescuento = fila.Cells["pdesc"];

                esUltimaVacia = (i == ultimaFila && General.filaVacia(fila));

                if ((General.celdaVacia(celdaCantidad) || celdaCantidad.Value.ToString().Trim() == "0") && !esUltimaVacia)
                {
                    Mensaje.advertencia("Ingrese una cantidad en el item " + i);
                    this.grw_productos.CurrentCell = fila.Cells["cantidad"];
                    return false;
                }
                if ((General.celdaVacia(celdaProducto) || celdaProducto.Value.ToString() == "0") && !esUltimaVacia)
                {
                    Mensaje.advertencia("Ingrese un producto el item " + i);
                    this.grw_productos.CurrentCell = fila.Cells["cantidad"];
                    return false;
                }

                if (!General.celdaVacia(celdaProducto) && !esUltimaVacia)
                {
                    decimal descuento;
                    if (decimal.TryParse(celdaDescuento.Value.ToString(), out descuento))
                    {
                        if (descuento > 100)
                        {
                            Mensaje.advertencia("El porcentaje de descuento no puede ser mayor a 100. Fila: " + i);
                            this.grw_productos.CurrentCell = fila.Cells["pdesc"];
                            return false;
                        }
                    }
                    else {
                        Mensaje.advertencia("Porcentaje de descuento incorrecto. Fila: " + i);
                        return false;
                    }
                }
                i++;
            }

            if (!General.vacioOCero(txt_montot1.Text) && (String.IsNullOrEmpty(txt_numerot1.Text) || this.cmb_pin1.SelectedIndex == 0 || this.cmb_tipo1.SelectedIndex == 0))
            {
                Mensaje.advertencia("Ha ingresado un valor para la tarjeta de crédito uno.\nFavor llene todos los datos.");
                this.txt_montot1.Select();
                return false;
            }

            if (!General.vacioOCero(txt_montot2.Text) && (String.IsNullOrEmpty(txt_numerot2.Text) || this.cmb_pin2.SelectedIndex == 0 || this.cmb_tipo2.SelectedIndex == 0))
            {
                Mensaje.advertencia("Ha ingresado un valor para la tarjeta de crédito dos.\nFavor llene todos los datos.");
                this.txt_montot2.Select();
                return false;
            }

            if (!General.vacioOCero(txt_montoc.Text) && (String.IsNullOrEmpty(txt_numeroc.Text) || String.IsNullOrEmpty(txt_banco.Text)))
            {
                Mensaje.advertencia("Ha ingresado un valor de cheque. Favor llene todos los datos.");
                this.txt_montot2.Select();
                return false;
            }

            if (!General.vacioOCero(txt_retencion.Text) && String.IsNullOrEmpty(txt_numeroRetencion.Text))
            {
                Mensaje.advertencia("Ha ingresado un valor de retención. Favor llene todos los datos.");
                this.txt_retencion.Select();
                return false;
            }
           
            decimal totalPagar = General.convertirDecimal(this.txt_total.Text);
            decimal totalTarjeta = General.convertirDecimal(this.txt_montot1.Text) + General.convertirDecimal(this.txt_montot2.Text);
            decimal totalCheque = General.convertirDecimal(this.txt_montoc.Text);
            decimal totalCredito = General.convertirDecimal(this.txt_montoNota.Text);
            decimal totalRetencion = General.convertirDecimal(this.txt_retencion.Text);

            if (!this.vueltoCredito && (totalTarjeta > totalPagar))
            {
                Mensaje.advertencia("El pago con tarjeta de crédito debe ser igual o menor al total a cobrar.");
                return false;
            }
            if (!this.vueltoCheque && (totalCheque > totalPagar))
            {
                Mensaje.advertencia("El pago con cheque debe ser igual o menor al total a cobrar.");
                return false;
            }

            //if (!this.vueltoCheque && !this.vueltoCredito && (totalTarjeta + totalCheque > totalPagar))
            //{
            //    Mensaje.advertencia("El pago con cheque y tarjeta debe ser igual o menor al total a cobrar.");
            //    return false; 
            //}

            if (totalRetencion > totalPagar)
            {
                Mensaje.advertencia("El pago con retención debe ser igual o menor al total a cobrar.");
                return false;
            }

            if (totalCredito > totalPagar)
            {
                Mensaje.advertencia("El pago con nota de crédito debe ser igual o menor al total a cobrar.");
                return false;
            }

            if (totalTarjeta + totalCheque + totalRetencion + totalCredito > totalPagar)
            {
                Mensaje.advertencia("Sólo se permite vueltos para pagos en efectivo.");
                return false;
            }

            if (this.propina && Convert.ToDecimal(this.txt_propina.Text)>0 && totalTarjeta == 0)
            {
                Mensaje.advertencia("Sólo se permite dejar propina en pagos con tarjeta de crédito.");
                return false;
            }
           decimal pagado = Convert.ToDecimal(txt_totalpago.Text);
           decimal saldo = Convert.ToDecimal(txt_saldo.Text);

           //if (this.pagoParcial) return true;
           if (this.cmb_estado.SelectedValue.ToString() == "P")
           {
               if (pagado != 0 && saldo != 0 && !this.pagoParcial)
               {
                   Mensaje.advertencia("Se debe cobrar todo o nada del valor a pagar.");
                   return false;
               }
               if (saldo == 0) this.cmb_estado.SelectedValue = "C";

               if (saldo == 0 && !voyImprimir && this.tsb_imprimir.Enabled && !this.pagoParcial)
               {
                   Mensaje.advertencia("Una vez cobrada la factura debe ser impresa.");
                   return false;
               }

           }
           else
            {
                if (Convert.ToDecimal(txt_saldo.Text) != 0)
                {
                    Mensaje.advertencia("No se ha cobrado el valor total.");
                    return false;
                }

                if (!voyImprimir && this.tsb_imprimir.Enabled)
                {
                    Mensaje.advertencia("Una vez cobrada la factura debe ser impresa.");
                    return false;
                }
            }  
            return true;
           
        }

        private void txt_secuencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.txt_secuencia.Text.Trim().Length < 1)
                {
                    Mensaje.advertencia("Ingrese una secuencia para poder consultar.");
                    return;
                }
                this.buscarFactura(Convert.ToInt32(this.txt_secuencia.Text));
            }
            General.soloNumeros(e);
        }

        protected void buscarFactura(int idFactura)
        {
            this.estadoInicial();
            String mensaje = "";
            FacturaCabecera factura = FacturaCabeceraTR.consultarFactura(idFactura);
            if (factura != null)
            {
                factura.Adicionales = FacturaCabeceraTR.consultarAdicionales(factura.Id);
                this.estadoGuardar = false;
                this.idFactura = factura.Id;
                this.llenarCabecera(factura);
                this.llenarDetalle(idFactura);
                this.llenarFormaDePagos(factura);
                this.activarEstadoActualizar(factura);
            }
            else
            {
                if (String.IsNullOrEmpty(mensaje)) Mensaje.advertencia("No se encontró la factura.");
                else Mensaje.error(mensaje);
            }
        }

        public void llenarCabecera(FacturaCabecera factura)
        {
            this.txt_secuencia.Text = factura.Id.ToString();
            if (factura.Id_tipoDocumento == 1) { this.txt_tipo.Text = "FACTURA"; }
            else if (factura.Id_tipoDocumento == 2) { this.txt_tipo.Text = "NOTA DE VENTA"; }
            else
            {
                this.txt_tipo.Text = "DNA";
                this.chk_dna.Checked = true;
                this.chk_dna.Enabled = true;
            }

            if (factura.Numero_actual == 0 && this.confPredeterminada.SecuenciaAlImprimir && (factura.Estado == "P" || factura.Estado == "C") && !chk_dna.Checked)
            {
                this.generarNumeroDocumento();
            }
            else this.txt_numDoc.Text = factura.Numero_documento;

            this.txt_fecha.Text = factura.Fecha_creacion.ToString();
            this.buscarCliente("",factura.IdCliente);

            this.txt_iva12.Text = factura.Tarifa_12.ToString();
            this.txt_iva0.Text = factura.Tarifa_0.ToString();
            this.txt_descuento.Text = factura.Descuento.ToString();
            this.descuentoFactura = factura.Descuento;
            this.txt_iva.Text = factura.Total_iva.ToString();
            this.txt_servicio.Text = factura.Servicio.ToString();
            this.txt_total.Text = factura.Total.ToString("#,##0.00");
            this.txt_propina.Text = factura.Propina.ToString();
            this.dtp_vencimiento.Value = factura.Fecha_vencimiento;
            this.txt_descipcion.Text = factura.Descripcion;

            if (factura.Adicionales != null && this.controlesAdicionales != null)
            {
                foreach (adicionalFactura adicional in factura.Adicionales)
                {
                    Control control = controlesAdicionales.Find(element => element.Name == ("ad" + adicional.idAdicional));
                    if (control != null)
                    {
                        if (control.GetType() != typeof(DateTimePicker))
                        {
                            control.Text = adicional.valor;
                        }
                        else
                        {
                            DateTime valor;
                            if (DateTime.TryParse(adicional.valor, out valor)) ((DateTimePicker)control).Value = valor;
                        }
                    }
                }
            }

            cmb_estado.SelectedValue = factura.Estado;

            if (this.seleccionarVendedor)this.cmb_vendedor.SelectedValue = factura.IdVendedor.ToString(); 

        }

        protected void activarEstadoActualizar(FacturaCabecera factura) {
            //if (this.pagoParcial && factura.Estado == "C" && !factura.Imprimo) factura.Estado = "P";
            this.cmb_estado.Enabled = false;
            if (factura.Estado != "P" || factura.Imprimo || (!this.modificarDiferenteCaja && factura.IdCaja != this.idCaja))// si la factura está cobrada o anulada o ha sido impresa.
            {
                this.txt_ruc.Enabled = false;
                this.btn_buscarCliente.Enabled = false;
                this.btn_crearCliente.Enabled = false;
                this.grw_productos.Enabled = false;

                this.dtp_vencimiento.Enabled = false;
                this.txt_descipcion.Enabled = false;
                
                if (this.seleccionarVendedor) this.cmb_vendedor.Enabled = false;
                this.chk_descProd.Enabled = false;

                if (controlesAdicionales != null)
                {
                    foreach (Control control in controlesAdicionales) control.Enabled = false;
                }

                if (factura.Estado != "P")// si la factura está cobrada o anulada
                {
                    this.txt_efectivo.ReadOnly = true;

                    this.chk_todoEfectivo.Enabled = false;
                    this.txt_numerot1.ReadOnly = true;
                    this.txt_montot1.ReadOnly = true;
                    this.cmb_pin1.Enabled = false;
                    this.cmb_tipo1.Enabled = false;

                    this.txt_numerot2.ReadOnly = true;
                    this.txt_montot2.ReadOnly = true;
                    this.cmb_pin2.Enabled = false;
                    this.cmb_tipo2.Enabled = false;

                    this.txt_numeroc.ReadOnly = true;
                    this.txt_banco.ReadOnly = true;
                    this.txt_montoc.ReadOnly = true;

                    this.txt_numeroRetencion.ReadOnly = true;
                    this.txt_retencion.ReadOnly = true;
                }
            }
            else this.grw_productos.Rows.Add();

            this.chk_dna.Enabled = false;

            if (factura.Estado == "A" || (factura.Estado == "C" && factura.IdCaja != this.idCaja))
            {
                this.tsb_imprimir.Enabled = false;
                this.tsb_guardar.Enabled = false;
                this.tsb_anular.Enabled = false;
                this.tsb_reversar.Enabled = true;
                //this.cmb_estado.Enabled = false;
            }
            else if (factura.Estado == "C")
            {
                this.tsb_imprimir.Enabled = !factura.Imprimo;
                this.tsb_guardar.Enabled = false;
                this.tsb_anular.Enabled = true;
                this.tsb_reversar.Enabled = true;
                //this.cmb_estado.Enabled = true;
            }
            else
            {
                this.tsb_guardar.Enabled = true;
                //this.tsb_guardar.Enabled = true;
                this.tsb_anular.Enabled = true;
                //this.cmb_estado.Enabled = true;
                this.tsb_imprimir.Enabled = !factura.Imprimo;
            }
            this.txt_vuelto.Text = factura.Vuelto.ToString();

            if (terminoSecuencia)
            {
                this.tsb_imprimir.Enabled = false;
            }
            //this.btn_guardar.Text = "Actualizar";
            if (this.pagoParcial && !factura.Imprimo) this.tsb_imprimir.Enabled = true;
        }

        protected void activarEstadoGuardar()
        {
            this.cmb_estado.Enabled = true;
            this.chk_dna.Enabled = true;
            this.chk_descProd.Enabled = true;
            this.txt_ruc.Enabled = true;
            this.btn_buscarCliente.Enabled = true;
            this.btn_crearCliente.Enabled = true;
            this.txt_efectivo.ReadOnly = false;

            this.chk_todoEfectivo.Enabled = true;

            this.txt_numerot1.ReadOnly = false;
            this.txt_montot1.ReadOnly = false;
            this.cmb_pin1.Enabled = true;
            this.cmb_tipo1.Enabled = true;

            this.txt_numerot2.ReadOnly = false;
            this.txt_montot2.ReadOnly = false;
            this.cmb_pin2.Enabled = true;
            this.cmb_tipo2.Enabled = true;

            this.txt_numeroc.ReadOnly = false;
            this.txt_banco.ReadOnly = false;
            this.txt_montoc.ReadOnly = false;

            this.txt_numeroRetencion.ReadOnly = false;
            this.txt_retencion.ReadOnly = false;

            this.tsb_guardar.Enabled = true;


            this.dtp_vencimiento.Enabled = true;
            this.txt_descipcion.Enabled = true;
            //this.btn_guardar.Text = "Guardar";
        }

        protected void llenarDetalle(int idFactura)
        {
            this.grw_productos.CellValueChanged -= grw_productos_CellValueChanged_1;
            List<String[]> detalles = FacturaDetalleTR.consultarFacturaDetalle(idFactura);
            int nFila=0;
            DataGridViewRow fila;
            foreach(String[] detalle in detalles)
            {
                fila = this.grw_productos.Rows[nFila];
                fila.Cells["codigo"].Value = detalle[0];
                fila.Cells["producto"].Value = detalle[1];
                fila.Cells["cantidad"].Value = detalle[2];
                fila.Cells["unidad"].Value = detalle[3];
                DataGridViewComboBoxCell combo = (DataGridViewComboBoxCell)fila.Cells["precioU"];
                if (Convert.ToBoolean(detalle[13]))
                {
                    combo.Style.BackColor = Color.White;
                    fila.Cells["pvp_manual"].Value = 1;
                }else fila.Cells["pvp_manual"].Value = 0;
                

                string precio = General.truncar(Convert.ToDecimal(detalle[4]),this.cantidadDecimales).ToString();
                combo.Items.Add(precio);
                combo.Value = precio;
                fila.Cells["pdesc"].Value = detalle[5];
                fila.Cells["subtotaldesc"].Value = detalle[6];
                fila.Cells["subtotal"].Value = detalle[7];
                fila.Cells["id_producto"].Value = detalle[8];
                fila.Cells["iva"].Value = detalle[9];
                fila.Cells["ice"].Value = detalle[10];
                fila.Cells["cantidadStock"].Value = detalle[11];
                fila.Cells["llena"].Value = 1;
                fila.Cells["modifico"].Value = 0;
                fila.Cells["id_detalle"].Value = detalle[12];
                fila.Cells["descripcion"].Value = detalle[14];
                fila.Cells["id_serie"].Value = detalle[15];
                fila.Cells["serie"].Value = detalle[16];

                if (this.tsb_imprimir.Enabled && this.promociones != null)
                {
                    fila.Cells["promocion"].Value = PromocionTR.consultarPromocionProducto(Convert.ToInt32(detalle[8]));
                }


                nFila++;
                if(nFila < detalles.Count)this.grw_productos.Rows.Add();
            }
            this.grw_productos.CellValueChanged += grw_productos_CellValueChanged_1;
            //this.grw_productos.Enabled = false;
        }

        protected void llenarPagoParcial(List<FormaPago> pagos)
        {
            foreach (FormaPago pago in pagos)
            {
                String[] fila = new String[4];
                fila[0] = pago.Fecha.ToString("dd/MM/yyyy");
                fila[1] = pago.getValor().ToString();
                fila[2] = pago.getFormaPago();
                fila[3] = "0";
                this.grw_abonos.Rows.Add(fila);
            }
        }

        protected void llenarFormaDePagos(FacturaCabecera cabecera)
        {
            FormaPagoTR buscar_pagos = new FormaPagoTR();
            buscar_pagos.Pago.Id_cabecera = cabecera.Id;
            List<FormaPago> pagos = buscar_pagos.consultarPagos();
            if (this.pagoParcial)
            {
                llenarPagoParcial(pagos);
                this.pagos = pagos;
                this.calcularTotalPagado();
                return;
            }

            decimal totalPago = 0, totalEfectivo = 0, totalCheque = 0, totalTarjeta = 0, totalRetencion = 0, totalNota = 0;
            bool primeraTarjeta = true;
            if (pagos.Count > 0) this.facturaPagada = true;
            foreach(FormaPago forma in pagos)
            {
                if (forma.Forma_pago == "EF")
                {
                    this.txt_efectivo.Text = Math.Round(forma.Monto_efectivo,this.cantidadDecimales).ToString();
                    totalEfectivo = totalEfectivo + forma.Monto_efectivo;
                }
                else if (forma.Forma_pago == "CH")
                {
                    this.txt_montoc.Text = Math.Round(forma.Monto_cheque, this.cantidadDecimales).ToString();
                    this.txt_numeroc.Text = forma.Numero_cheque;
                    this.txt_banco.Text = forma.Banco;
                    totalCheque = totalCheque + forma.Monto_cheque;
                }
                else if (forma.Forma_pago == "TC")
                {
                    if (primeraTarjeta){
                        this.txt_montot1.Text = Math.Round(forma.Monto_tarjeta, this.cantidadDecimales).ToString();
                        this.txt_numerot1.Text = forma.Numero_tarjeta;
                        this.cmb_pin1.SelectedValue = forma.Tipo_ping;
                        this.cmb_tipo1.SelectedValue = forma.Tipo_tarjeta;
                        primeraTarjeta = false;
                    }
                    else {
                        this.txt_montot2.Text = Math.Round(forma.Monto_tarjeta, this.cantidadDecimales).ToString();
                        this.txt_numerot2.Text = forma.Numero_tarjeta;
                        this.cmb_pin2.SelectedValue = forma.Tipo_ping;
                        this.cmb_tipo2.SelectedValue = forma.Tipo_tarjeta;
                    }
                    totalTarjeta = totalTarjeta + forma.Monto_tarjeta;
                }
                else if (forma.Forma_pago == "RF")
                {
                    this.txt_retencion.Text = Math.Round(forma.Monto_retencion, this.cantidadDecimales).ToString();
                    this.txt_numeroRetencion.Text = forma.Numero_retencion.ToString();
                    totalRetencion = totalRetencion + forma.Monto_retencion;
                }
                else if (forma.Forma_pago == "NC")
                {
                    this.txt_montoNota.Text = Math.Round(forma.Monto_nota, this.cantidadDecimales).ToString();
                    this.txt_numeroNota.Text = forma.Numero_Nota.ToString();
                    totalNota = totalNota + forma.Monto_nota;
                }   
            }
            totalPago = totalEfectivo + totalCheque + totalTarjeta + totalRetencion + totalNota;
            /*this.txt_efectivo.Text = Math.Round(totalEfectivo,this.cantidadDecimales).ToString();
            this.txt_montoc.Text = Math.Round(totalCheque, this.cantidadDecimales).ToString();
            this.txt_montot1.Text = Math.Round(totalTarjeta, this.cantidadDecimales).ToString();
            this.txt_retencion.Text = Math.Round(totalRetencion, this.cantidadDecimales).ToString();*/
            this.txt_saldo.Text = (cabecera.Total - totalPago).ToString();
            this.calcularTotalPagado();
        }

        private void grw_productos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void grw_productos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if(this.promociones!=null)calcularValorPromociones(-this.subtotalEliminado);
            this.calcularValoresAPagar();
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            this.estadoInicial();
        }

        private void chk_todoEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            if(this.chk_todoEfectivo.Checked)this.txt_efectivo.Text = this.txt_total.Text;
            else this.txt_efectivo.Text = "0";
            this.calcularTotalPagado();
        }

        private void txt_secuencia_TextChanged(object sender, EventArgs e)
        {
            //if (!this.estadoGuardar) estadoInicial();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            frm_facturaListado facturas = new frm_facturaListado();
            DialogResult dr = facturas.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                this.setIdFactura(facturas.idFactura, facturas.anular);
            }
        }

        protected void imprimirFactura(bool preCuenta = false, bool reimprimir = false)
        {
            //if (!preCuenta) FacturaCabeceraTR.setFacturaImpresa(this.idFactura);
            //if (this.copiasFactura == 0) this.copiasFactura = 1;
            if (this.deTicket == 1)
            {
                //***ADIIONALES ECOGAL***
                if (Global.idEmpresa != 439)
                {
                    Thread hiloImpresion = null;
                    if (this.copiasFactura2 > 0 && !String.IsNullOrEmpty(this.impresora2))
                    {
                        hiloImpresion = new Thread(
                           new ThreadStart(() =>
                           {
                               this.imprimirTicket(this.copiasFactura2, this.impresora2);
                           }));
                        hiloImpresion.Start();
                    }

                    Thread hiloImpresion2 = new Thread(
                            new ThreadStart(() =>
                            {
                                this.imprimirTicket(this.copiasFactura);
                            }));
                    hiloImpresion2.Start();

                    if (hiloImpresion != null) hiloImpresion.Join();
                    hiloImpresion2.Join();
                }
                else this.imprimirTicket(this.copiasFactura);
            }
            else
            {
                Documento doc = new Documento();
                doc.fechaActual = DateTime.Now.ToShortDateString();
                doc.fechaVencimiento = this.dtp_vencimiento.Value.ToShortDateString();
                doc.clienteNombre = this.txt_Nombres.Text;
                doc.clienteCedula = this.txt_ruc.Text;
                doc.clienteDireccion = this.clienteDireccion;
                doc.clienteTelefono = this.clienteTelefono;

                if (controlesAdicionales != null)
                {
                    List<adicionalFactura> adicionales = new List<adicionalFactura>();
                    foreach (Control control in controlesAdicionales)
                    {
                        adicionalFactura adicional = new adicionalFactura();
                        adicional.idAdicional = Convert.ToInt32(control.Name.Substring(2));
                        adicional.etiqueta = control.AccessibleName;
                        adicional.valor = control.Text;
                        adicional.tipo = (control.GetType() == typeof(DateTimePicker)) ? 2 : 1;
                        adicionales.Add(adicional);
                    }
                    doc.adicionales = adicionales;
                }

                int i = 0;
                foreach (DataGridViewRow fila in this.grw_productos.Rows)
                {
                    if (fila.Cells["llena"].Value != null && fila.Cells["llena"].Value.ToString() == "1")
                    {
                        string[] datos = new string[6];
                        datos[0] = this.grw_productos.Rows[i].Cells["codigo"].Value.ToString();
                        datos[1] = this.grw_productos.Rows[i].Cells["cantidad"].Value.ToString();
                        datos[2] = (this.imprimirDescripcion) ? General.obtenerValorCelda(this.grw_productos.Rows[i].Cells["descripcion"]) : General.obtenerValorCelda(this.grw_productos.Rows[i].Cells["producto"]);
                        datos[3] = this.grw_productos.Rows[i].Cells["precioU"].Value.ToString();
                        datos[4] = this.grw_productos.Rows[i].Cells["subtotal"].Value.ToString();
                        datos[5] = General.obtenerValorCelda(this.grw_productos.Rows[i].Cells["descripcion"]);
                        doc.detalle.Add(datos);
                        i++;
                    }
                }
                doc.subtotalIVA = this.txt_iva12.Text;
                doc.subtotalCero = this.txt_iva0.Text;
                doc.valorDescuento = this.txt_descuento.Text;
                doc.ivaCobrado = this.txt_iva.Text;//IVA
                doc.totalPagar = this.txt_total.Text; // imprime linea con total
                doc.totalPagarTexto = Conversiones.NumeroALetras(Convert.ToDouble(this.txt_total.Text));
                doc.servicioCobrado = this.txt_servicio.Text;
                doc.imprimir(this.separacionLinea, this.caracteresProducto, (short)this.copiasFactura);
            }   
        }

        protected void imprimirTicket(int copiasFactura, string impresora = null)
        {
            Impresion Ticket1 = new Impresion(impresora);
            Ticket1.AbreCajon();  //abre el cajon
            for (int copias = 0; copias < copiasFactura; copias++)
            {

                for (int i = 0; i < this.espaciosArriba; i++) Ticket1.enter();
                string fecha = "Fecha:" + DateTime.Now.ToShortDateString();
                string hora = "Hora:" + string.Format("{0:HH:mm:ss tt}", DateTime.Now);
                string espacios = new string(' ',40 - (fecha.Length + hora.Length));
                Ticket1.TextoIzquierda(fecha + espacios + hora);
                Ticket1.TextoIzquierda("Cliente: " + this.txt_Nombres.Text);
                Ticket1.TextoIzquierda("Direccion: " + this.clienteDireccion);
                Ticket1.TextoIzquierda("Cedula/RUC:" + txt_ruc.Text);

                //***ADIIONALES ECOGAL***
                if (Global.idEmpresa == 439)
                {
                    if (this.controlesAdicionales.Count > 5)
                    {
                        string forma = "F.Pago:" + ((ComboBox)this.controlesAdicionales[5]).Text;
                        string vencimiento = "F.Vcto:" + this.dtp_vencimiento.Value.ToShortDateString();
                        espacios = new string(' ', 40 - (forma.Length + vencimiento.Length));
                        Ticket1.TextoIzquierda(forma + espacios + vencimiento);
                    }
                    else
                    {
                        Ticket1.TextoIzquierda("F.Vcto:" + this.dtp_vencimiento.Value.ToShortDateString());
                    }
                    if (this.controlesAdicionales.Count > 4) Ticket1.TextoIzquierda("Periodo Facturado:" + ((DateTimePicker)this.controlesAdicionales[3]).Value.ToShortDateString() + '-' + ((DateTimePicker)this.controlesAdicionales[4]).Value.ToShortDateString());
                    //**FIN ADICIONALES ECOGAL***
                }
                Ticket1.LineasIgual(); // imprime una linea de =
                Ticket1.EncabezadoVenta(this.imprimirValores); // imprime encabezados
                Ticket1.LineasGuion();// imprime una linea de guiones
                //Detalles
                if (this.espaciosItems == -1) this.espaciosItems = 11;
                int n = (this.confPredeterminada.Tipo_doc == "D") ? this.grw_productos.RowCount:this.espaciosItems;
                for (int i = 0; i < n; i++)
                {
                    //if ((i < this.grw_productos.Rows.Count - 1) && this.grw_productos.Rows[i].Cells["llena"].Value.ToString() == "1")
                    if (i < this.grw_productos.RowCount && this.grw_productos.Rows[i].Cells["llena"].Value != null && this.grw_productos.Rows[i].Cells["llena"].Value.ToString() == "1")
                    {
                        string nombre;
                        nombre = (this.imprimirDescripcion) ? General.obtenerValorCelda(this.grw_productos.Rows[i].Cells["descripcion"]) : General.obtenerValorCelda(this.grw_productos.Rows[i].Cells["producto"]);
                        string precioUnitario = this.grw_productos.Rows[i].Cells["precioU"].Value.ToString();
                        string cantidad = this.grw_productos.Rows[i].Cells["cantidad"].Value.ToString();
                        string subtotal = this.grw_productos.Rows[i].Cells["subtotal"].Value.ToString();
                        if (this.imprimirValores)
                        {
                            Ticket1.AgregaArticulo(nombre, Convert.ToDouble(cantidad), Convert.ToDouble(precioUnitario), Convert.ToDouble(subtotal)); //imprime una linea de descripcion
                        }
                        else
                        {
                            Ticket1.agregarArticuloCantidad(nombre, cantidad);
                        }
                        
                    }
                    else Ticket1.enter();
                }

                if (this.imprimirValores)
                {
                    Ticket1.LineasTotales(); // imprime linea
                    Ticket1.AgregaTotales("Subtotal 12%", Convert.ToDouble(this.txt_iva12.Text));//Subtotal
                    Ticket1.AgregaTotales("Subtotal 0%", Convert.ToDouble(this.txt_iva0.Text));//Subtotal
                    Ticket1.AgregaTotales("Dcto", Convert.ToDouble(this.txt_descuento.Text));//Descuento
                    Ticket1.AgregaTotales("IVA 12%", Convert.ToDouble(this.txt_iva.Text));//IVA
                    if (this.confPredeterminada.Servicio) Ticket1.AgregaTotales("Servicio", Convert.ToDouble(this.txt_servicio.Text)); // imprime linea con total
                    Ticket1.AgregaTotales("Total", Convert.ToDouble(this.txt_total.Text)); // imprime linea con total

                    //*****ECOGAL***********+
                    if (Global.idEmpresa == 439)
                    {
                        Ticket1.enter();
                        Ticket1.enter();
                        Ticket1.TextoIzquierda(" ______________        ________________ ");
                        Ticket1.TextoIzquierda("  F.AUTORIZADO          RECIBI CONFORME ");
                        //****FIN ECOGAL
                    }
                }

                //***PAN DORADO***
                if (Global.idEmpresa == 418)
                {
                    Ticket1.TextoIzquierda("Recibido: $" + this.txt_totalpago.Text + "  Cambio: $" + this.txt_vuelto.Text);
                    if (impresora != null && this.controlesAdicionales != null && this.controlesAdicionales.Count > 0)
                    {
                        String etiqueta = this.controlesAdicionales[0].AccessibleName;
                        String valor = this.controlesAdicionales[0].Text;
                        Ticket1.TextoIzquierda(etiqueta + ":" + valor);
                        Ticket1.TextoIzquierda("FAC: " + this.txt_numDoc.Text);
                    }
                }

                for (int i = 0; i < this.espaciosAbajo; i++) Ticket1.enter();
                if(this.generarCorte)Ticket1.CortaTicket(); // corta el ticket
            }

            for (int i = 0; i < this.espaciosDCorte; i++) Ticket1.enter();

        }

        private void frm_factura_KeyDown(object sender, KeyEventArgs e)
        {
            if (!this.puedoEscribir && e.KeyData != Keys.Enter)
            {        
                this.codigoBarra += Convert.ToChar(e.KeyValue);  
            }
        }

        private void frm_factura_KeyUp(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyData == this.prefijo1 || (int)e.KeyData == this.prefijo2)
            {
                this.setearSoloLectura();
                this.codigoBarra = "";
                this.puedoEscribir = false;

            }
            else if (!this.puedoEscribir && e.KeyData == Keys.Enter)
            {
                this.buscarProducto(null, null, this.grw_productos.CurrentRow.Index, this.codigoBarra);
                this.puedoEscribir = true;
                this.quitarSoloLectura();
            }
            else if (e.KeyData == Keys.F5) this.estadoInicial();
            else if (this.confPredeterminada.Sin_cobro && e.KeyData == Keys.F6 && this.tsb_guardar.Enabled) this.botonGuardar();
            else if (e.KeyData == Keys.F7 && this.tsb_imprimir.Enabled) this.botonImprimir();
            else if (e.KeyData == Keys.F8 && this.tsb_anular.Enabled) this.botonAnular();
        }

        protected void setearSoloLectura()
        {
            if (this.listaControles == null) this.listaControles = new List<TextBox>();
            IEnumerable<Control> controles = this.GetAllControls(this);
            this.recorrerTextbox(controles);
          
        }

        protected void recorrerTextbox(IEnumerable<Control> controles)
        {

            foreach (Control control in controles)
            {
                if (control is TextBox)
                {
                    TextBox cajaTexto = (TextBox)control;
                    if (!cajaTexto.ReadOnly)
                    {
                        this.listaControles.Add(cajaTexto);
                        cajaTexto.ReadOnly = true;
                    }
                }
            }
        }

        protected void quitarSoloLectura()
        { 
            foreach (TextBox control in this.listaControles) {
                control.ReadOnly = false;
            }
            this.listaControles.Clear();
        }

        public IEnumerable<Control> GetAllControls(Control root)
        {
            foreach (Control control in root.Controls)
            {
                foreach (Control child in GetAllControls(control))
                {
                    yield return child;
                }
            }
            yield return root;
        }

        private void tsb_nuevo_Click(object sender, EventArgs e)
        {
            this.estadoInicial();
        }

        private void tsb_guardar_Click(object sender, EventArgs e)
        {
            this.botonGuardar();
        }

        private void tsb_imprimir_Click(object sender, EventArgs e)
        {
            this.botonImprimir();
        }

        private void tsb_anular_Click(object sender, EventArgs e)
        {
            this.botonAnular();
        }

        protected void botonGuardar()
        {
            this.bloquearCajasPago();
            if (this.estadoGuardar) this.guardarFactura(false);
            else this.actualizarFactura(false);
            this.habilitarCajasPago();
        }

        protected void botonImprimir()
        {
            if (!this.impresoraDisponible)
            {
                Mensaje.advertencia("La impresora no se encuentra disponible.");
                return;
            }
            else
            {
                this.bloquearCajasPago();
                if (this.estadoGuardar) this.guardarFactura(true);
                else this.actualizarFactura(true);
                this.habilitarCajasPago();
            }
        }

        private void bloquearCajasPago() {
            this.txt_efectivo.Enabled = false;
            this.txt_montot1.Enabled = false;
            this.txt_montot2.Enabled = false;
            this.txt_montoc.Enabled = false;
            this.txt_montoNota.Enabled = false;
            this.txt_retencion.Enabled = false;
        }

        private void habilitarCajasPago()
        {
            this.txt_efectivo.Enabled = true;
            this.txt_montot1.Enabled = true;
            this.txt_montot2.Enabled = true;
            this.txt_montoc.Enabled = true;
            this.txt_montoNota.Enabled = true;
            this.txt_retencion.Enabled = true;
        }

        protected void botonAnular(bool vieneDeReversar = true)
        {
            this.idUsuarioAnular = Global.idUsuarioAnular;
            bool buscarUsuario = false;
            if (!this.anularFactura && this.idUsuarioAnular == null)
            {
                frm_loginPermiso nuevo = new frm_loginPermiso();
                if (nuevo.ShowDialog() == DialogResult.OK)
                {
                    this.idUsuarioAnular = nuevo.user.Idtbl_usuario;
                    buscarUsuario = true;
                }
                else return;
            }

            string mensaje = "";
            string documento = "";
            
            if (this.confPredeterminada.Tipo_doc == "F") documento = "la factura";
            else if (this.confPredeterminada.Tipo_doc == "N") documento = "la nota de venta";
            else if (this.confPredeterminada.Tipo_doc == "D") documento = "el documento no autorizado";

            if (this.estadoGuardar) mensaje = "Esta seguro que desea anular " + documento + "?";
            else
            {
                if (this.tsb_imprimir.Enabled) mensaje = "Este documento no ha sido impreso. Está seguro que desea anularlo?\n No se modificará la secuencia.";
                else mensaje = "Esta seguro que desea anular " + documento + "?\n Esto también anulará los cobros.";
            }
            if (buscarUsuario || Mensaje.confirmacion(mensaje))
            {
                this.cmb_estado.SelectedValue = "A";
                if (this.estadoGuardar) this.guardarFactura(false, vieneDeReversar);
                else this.actualizarFactura(false);
            }
            this.idUsuarioAnular = null;
        }

        private void tsb_duplicar_Click(object sender, EventArgs e)
        {
            try
            {
                string cedula = this.txt_ruc.Text;
                List<string[]> productos = new List<string[]>();
                string valor;
                foreach (DataGridViewRow fila in this.grw_productos.Rows)
                {
                    valor = General.obtenerValorCelda(fila.Cells["codigo"]);
                    if (!String.IsNullOrEmpty(valor))
                    {
                        string[] producto = new string[2];
                        producto[0] = valor;
                        producto[1] = fila.Cells["cantidad"].Value.ToString();
                        //producto[2] = fila.Cells["descripcion"].Value.ToString();
                        productos.Add(producto);
                    }
                }
                this.estadoInicial();
                this.setCedulaCliente(cedula);
                if (this.grw_productos.Rows.Count < 1) this.grw_productos.Rows.Add();
                int i = 0;
                foreach (string[] producto in productos)
                {
                    this.deboBuscar = false;
                    this.buscarProducto(producto[0], "", i, null, producto[1]);
                    this.deboBuscar = true;
                    //this.grw_productos["codigo", i].Value = producto[0];
                    //this.grw_productos["cantidad", i].Value = producto[1];
                    //this.grw_productos.Rows.Add();
                    i++;
                }
            }
            catch (Exception error)
            {
                Mensaje.advertencia(error.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            frm_buscarAdicional adicional = new frm_buscarAdicional(Convert.ToInt32(boton.Name.Substring(1)));
            adicional.Owner = this;
            adicional.ShowDialog();
        }

        private void txt_retencion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_numeroRetencion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_secuencia_KeyUp(object sender, KeyEventArgs e)
        {
           
            if(e.KeyData == Keys.Up)
            {
                int idActual = Convert.ToInt32(this.txt_secuencia.Text) + 1;
                this.buscarFactura(idActual);
                this.txt_secuencia.Select();
            }
            if (e.KeyData == Keys.Down)
            {
                int idActual = Convert.ToInt32(this.txt_secuencia.Text) - 1;
                this.buscarFactura(idActual);
                this.txt_secuencia.Select();
            }
            
        }

        private void chk_servicio_CheckedChanged(object sender, EventArgs e)
        {
            this.calcularValoresAPagar();
        }

        private void lbl_servicio_Click(object sender, EventArgs e)
        {
            this.chk_servicio.Checked = !this.chk_servicio.Checked;
        }

        private void frm_factura_FormClosing(object sender, FormClosingEventArgs e)
        {            
            int estado = (this.WindowState == FormWindowState.Maximized) ? 1 : 0;
            ParametroTR.actualizarParametroEntero("formularioFacturaEstado", estado);
            if(this.Owner!=null)((frm_menu)this.Owner).limpiarFactura();
            //this.Close();
            //this.Dispose();
        }

        private void frm_factura_SizeChanged(object sender, EventArgs e)
        {

        }

        private void tsb_guia_Click(object sender, EventArgs e)
        {
            /*List<int> productos = new List<int>();
            string valor;
            foreach (DataGridViewRow fila in this.grw_productos.Rows)
            {
                valor = General.obtenerValorCelda(fila.Cells["id_producto"]);
                if (!String.IsNullOrEmpty(valor))productos.Add(Convert.ToInt32(valor));
                
            }*/
            frm_guiaRemision guia = new frm_guiaRemision(this.txt_numDoc.Text,this.idCliente,this.idFactura);
            guia.ShowDialog();
        }

        private void tmi_tipoDocumento_Click(object sender, EventArgs e)
        {
            this.flp_tipoDocumento.Visible = !this.flp_tipoDocumento.Visible;
            ParametroTR.actualizarParametroEntero("mostrarTipoDocumento", (this.flp_tipoDocumento.Visible) ? 1 : 0);
        }

        private void tmi_autorizacion_Click(object sender, EventArgs e)
        {
            this.flp_autorizacion.Visible = !this.flp_autorizacion.Visible;
            ParametroTR.actualizarParametroEntero("mostrarAutorizacion", (this.flp_autorizacion.Visible) ? 1 : 0);
        }

        private void tmi_fechaVencimiento_Click(object sender, EventArgs e)
        {
            this.flp_fechaVencimiento.Visible = !this.flp_fechaVencimiento.Visible;
            ParametroTR.actualizarParametroEntero("mostrarVencimiento", (this.flp_fechaVencimiento.Visible) ? 1 : 0);
        }

        private void tmi_descripcion_Click(object sender, EventArgs e)
        {
            this.flp_descripcion.Visible = !this.flp_descripcion.Visible;
            ParametroTR.actualizarParametroEntero("mostrarDescripcion", (this.flp_descripcion.Visible) ? 1 : 0);
        }

        private void tmi_nuevo_Click(object sender, EventArgs e)
        {
            this.estadoInicial();
        }

        private void tab_abono_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            frm_abono frmAbono = new frm_abono(this.idCaja,Convert.ToDecimal(this.txt_saldo.Text));
            if (this.pagos == null) this.pagos = new List<FormaPago>();
            var result = frmAbono.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (FormaPago forma in frmAbono.listaFormaPago)
                {
                    String[] fila = new String[4];
                    fila[0] = DateTime.Now.ToString("dd/MM/yyyy");
                    //fila[1] = txt_total.Text;
                    //fila[2] = "Efectivo";
                    fila[1] = forma.getValor().ToString();
                    fila[2] = forma.getFormaPago();
                    fila[3] = "1";
                    this.pagos.Add(forma);
                    this.grw_abonos.Rows.Add(fila);
                }
                this.calcularTotalPagado();
            }
        }

        private void grw_abonos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (this.grw_abonos.Columns[e.ColumnIndex].Name == "botonEliminarPago")
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    Bitmap bmp = Pos.Properties.Resources.borrar_fila;
                    DataGridViewButtonCell celBoton = this.grw_abonos.Rows[e.RowIndex].Cells["botonEliminarPago"] as DataGridViewButtonCell;
                    Icon icoAtomico = Icon.FromHandle(bmp.GetHicon());
                    e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 2, e.CellBounds.Top + 3);
                    this.grw_abonos.Columns[e.ColumnIndex].Width = 21;
                    e.Handled = true;
                }

            }
        }

        private void grw_abonos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (this.grw_abonos.Columns[e.ColumnIndex].Name == "botonEliminarPago")
            {
                if (this.idCaja != this.pagos[e.RowIndex].Id_Caja)
                {
                    Mensaje.informacion("Este pago no se puede eliminar");
                    return;
                }

                if(Mensaje.confirmacion("Está seguro que desea eliminar el cobro?"))
                {
                    if (this.pagosEliminados == null) this.pagosEliminados = new List<FormaPago>();
                    if(this.pagos[e.RowIndex].Idforma_pagos != 0)this.pagosEliminados.Add(this.pagos[e.RowIndex]);
                    this.pagos.RemoveAt(e.RowIndex);
                    this.grw_abonos.Rows.RemoveAt(e.RowIndex);
                    this.calcularTotalPagado();
                }
            }
        }

        private void grw_abonos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                frm_abono frmAbono = new frm_abono(this.pagos[e.RowIndex]);
                frmAbono.ShowDialog();
            }
        }

        private void grw_productos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.ColumnIndex == this.grw_productos.Columns["precioU"].Index || e.ColumnIndex == this.grw_productos.Columns["subtotal"].Index) && e.Value != null)
            {
                DataGridViewCell cell = this.grw_productos.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string iva = (this.grw_productos.Rows[e.RowIndex].Cells["iva"].Value != null)?this.grw_productos.Rows[e.RowIndex].Cells["iva"].Value.ToString():"";
                if (iva.Equals("12"))
                {
                    decimal convertido = 0;
                    if (Decimal.TryParse(e.Value.ToString(), out convertido))
                    {
                        Decimal valor = Math.Round(convertido * 1.12m, this.cantidadDecimales);
                        cell.ToolTipText = "Total con IVA: $" + valor.ToString();
                    }
                }
                else
                {
                    cell.ToolTipText = "No grava IVA";
                }

            }
        }

        private void tmi_pendientes_Click(object sender, EventArgs e)
        {
            this.tmi_pendientes.Text = (this.grb_pendientes.Visible) ? "Mostrar Pendientes" : "Ocultar Pendientes";
            this.grb_pendientes.Visible = !this.grb_pendientes.Visible;
            this.grb_pendientes.Width = (this.grb_pendientes.Visible) ? 151 : 0;
            this.Width += (this.grb_pendientes.Visible) ? 151 : -151;
            ParametroTR.actualizarParametroEntero("mostrarPendientes", (this.grb_pendientes.Visible) ? 1 : 0);
        }

        private void tmi_descripcionProducto_Click(object sender, EventArgs e)
        {
            if(this.grw_productos.Columns["descripcion"].Visible)this.ocultarDescripcionProducto();
            else this.mostrarDescripcionProducto();
            ParametroTR.actualizarParametroEntero("descripcionProducto", (this.grw_productos.Columns["descripcion"].Visible) ? 1 : 0);
        }

        private void tsb_preCuenta_Click(object sender, EventArgs e)
        {
            if (!this.impresoraDisponible)
            {
                Mensaje.advertencia("La impresora no se encuentra disponible.");
                return;
            }
            else imprimirFactura(true);
        }

        private void grw_productos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.grw_productos.Columns[e.ColumnIndex].Name == "serie")
            { 
                string producto = General.obtenerValorCelda(this.grw_productos.CurrentRow.Cells["id_producto"]);
                if (!String.IsNullOrEmpty(producto))
                {
                    this.mostrarFormSerie(this.grw_productos.CurrentRow,Convert.ToInt32(producto));
                }
            }
        }

        private void mostrarFormSerie(DataGridViewRow fila,int idProducto)
        {
            frm_consultarSerie frm_serie = new frm_consultarSerie(idProducto, this.seriesIngresadas(idProducto), (this.estadoGuardar) ? null : (int?)this.idFactura, General.celdaVacia(fila.Cells["id_serie"]));
            DialogResult resultado = frm_serie.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                KeyValuePair<Int32,String>? serie = frm_serie.getSerie();
                if (serie != null)
                {
                    fila.Cells["serie"].Value = serie.Value.Value;
                    fila.Cells["id_serie"].Value = serie.Value.Key;
                }
            }
            else
            {
                this.eliminarFilaProducto(fila.Index);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void grp_total_Enter(object sender, EventArgs e)
        {

        }

        private void pan_totales_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_total_Click(object sender, EventArgs e)
        {

        }

        private void menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

          
            this.botonReversar();
            
        }
        // Reversa el ultimo pago y coloca el estado pendiente de una factura
        protected void botonReversar()
        {
            this.idUsuarioAnular = Global.idUsuarioAnular;
            bool buscarUsuario = false;
            if (!this.anularFactura && this.idUsuarioAnular == null)
            {
                frm_loginPermiso nuevo = new frm_loginPermiso();
                if (nuevo.ShowDialog() == DialogResult.OK)
                {
                    this.idUsuarioAnular = nuevo.user.Idtbl_usuario;
                    buscarUsuario = true;
                }
                else return;
            }

            string mensaje = "";
            string documento = "";

            if (this.confPredeterminada.Tipo_doc == "F") documento = "la factura";
            else if (this.confPredeterminada.Tipo_doc == "N") documento = "la nota de venta";
            else if (this.confPredeterminada.Tipo_doc == "D") documento = "el documento no autorizado";
            //Mensaje.advertencia("Al reversar el documento se eliminará el ultimo cobro y se anulará la secuencia guardada");
            string documentoanular = this.txt_numDoc.Text;
            if (this.estadoGuardar) mensaje = "Al reversar el documento se eliminará el ultimo cobro y se anulará la secuencia guardada ";
            else
            {
               /* if (this.tsb_imprimir.Enabled) mensaje = "Este documento no ha sido impreso. Está seguro que desa reversarlo?\n No se modificará la secuencia.";
                else*/ mensaje = "Esta seguro que desea reversar " + documento + "?\n Esto también reversara el ultimo cobro.";
            }
            if (buscarUsuario || Mensaje.confirmacion(mensaje))
            {
                FormaPagoTR tran = new FormaPagoTR();
                int idfactura;
                idfactura = Convert.ToInt32(this.txt_secuencia.Text);
                tran.eliminarPago(idfactura);
                Mensaje.advertencia("Se ha reversado correctamente la factura, favor verifique la nueva secuencia");
                // guarda los datos de la factura a reversar para anular secuencia utilizada
                try
                {
                string cedula = this.txt_ruc.Text;
                this.estadoInicial();
                txt_descipcion.Text = "Factura reversada desde el Punto de Venta";
                this.setCedulaCliente(cedula);
                this.setNumeroDocumento(documentoanular);
                this.cmb_estado.SelectedValue = "C";          
                this.botonAnular(false);
                    
            }
                catch (Exception error)
                {
                    Mensaje.advertencia(error.Message);
                }
            }


            this.idUsuarioAnular = null;
        }

        private void tsb_imprimirFactura_Click(object sender, EventArgs e)
        {

        }
 
    }
}
