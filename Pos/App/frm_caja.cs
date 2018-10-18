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
using System.Management;
using System.Net.NetworkInformation;
using TestLib;
using System.Threading;
using System.Xml;
using System.Collections;
using Pos.ClasesImpresion;

namespace Pos.App
{
    public partial class frm_abrir_cerrar : Form
    {
        private Caja cajaActiva;
        private Thread backgroundThread;
        private string tipo;
        private int idConfPos;
        private bool conexionInternet = false;
        private bool datafast = false;
        private bool medianet = false;
        private bool redapoyo = false;
        private bool cierreManual = true;
        private bool habilitarCampoEdicion = true;

        public frm_abrir_cerrar()
        {
            InitializeComponent();
        }

        public frm_abrir_cerrar(int idConfPos, string tipo)
        {
            InitializeComponent();
            this.tipo = tipo;
            this.idConfPos = idConfPos;
            this.cierreManual = ParametroTR.ConsultarBool("cierreManual");
            this.habilitarCampoEdicion = ParametroTR.ConsultarBool("habilitarCampoEdicion");
        }

        public void setIdCaja(int idCaja)
        {
            string mensaje = "";
            CajaTR tran = new CajaTR();
            Caja caja = tran.consultarXId(ref mensaje, idCaja);
            if (caja != null)
            {
                this.txt_secuencia.Text = caja.Codigo_secuencial.ToString();
                //this.txt_tipo.Text = "CERRAR";
                this.txt_fechaHora.Text = caja.Fecha_hora.ToString();
                this.txt_monto.Text = caja.Monto_incial.ToString();
                this.txt_tarjetas.Text = caja.Tarjeta.ToString();
                this.txt_efectivo.Text = caja.Efectivo.ToString();
                this.txt_cheque.Text = caja.Cheque.ToString();
                this.txt_retencion.Text = caja.Retencion.ToString();
                this.txt_saldoInicial.Text = caja.Monto_incial.ToString();
                this.txt_facturado.Text = caja.Total_facturado.ToString();
                this.txt_cobro.Text = caja.Total_cobro.ToString();
                this.txt_saldoFinal.Text = caja.Saldo_final.ToString();
                this.txt_total.Text = caja.Total_cobro.ToString();
                this.txt_efectivomanual.Text = caja.Efectivo_Manual.ToString();
                this.txt_chequemanual.Text = caja.Cheque_Manual.ToString();

                if (caja.Datafast != 0) this.txt_datafast.Text = caja.Datafast.ToString();
                else this.txt_datafast.Clear();
                if (caja.Medianet != 0) this.txt_medianet.Text = caja.Medianet.ToString();
                else this.txt_medianet.Clear();
                if (caja.RedApoyo != 0) this.txt_redApoyo.Text = caja.RedApoyo.ToString();
                else this.txt_redApoyo.Clear();
                this.activarEstadoImpresion();
            }
            else {
                if (String.IsNullOrEmpty(mensaje)) Mensaje.advertencia("No se encontró la caja ingresada.");
                else Mensaje.advertencia(mensaje);
            }

        }

        protected void activarEstadoImpresion()
        {
            this.btn_accion.Enabled = true;
            this.btn_accion.Text = "Imprimir";
        }

        protected void activarEstadoGuardar()
        {
            this.btn_accion.Text = "Abrir";
        }

        private void frm_abrir_cerrar_Load(object sender, EventArgs e)
        {
            this.estadoInicial();
            this.Height = this.flp_contenedor.Height + 30;
            this.CenterToScreen();
        }

        protected void bloquearBotones()
        {
            this.btn_accion.Enabled = false;
            this.btn_buscar.Enabled = false;
        }

        protected void estadoInicial()
        {
            try
            {
                //string msn = "";
                CajaTR tran = new CajaTR();
                this.cajaActiva = CajaTR.verEstadoCaja(this.idConfPos, "A");
                //if (this.habilitarCampoEdicion) { }
                if (cajaActiva == null && this.tipo == "abrir")
                {
                    this.grp_saldos.Visible = false;
                    this.grp_ventas.Visible = false;
                    this.grp_lotes.Visible = false;

                    this.btn_detalle.Visible = false;
                    this.txt_fechaHora.Text = DateTime.Now.ToString();
                    int numeroSecuencia = tran.sacarNumeroSecuencia(this.idConfPos);
                    this.txt_secuencia.Text = numeroSecuencia.ToString();
                    this.txt_monto.Clear();
                    this.txt_efectivo.Text = "0.00";
                    this.txt_cheque.Text = "0.00";
                    this.txt_tarjetas.Text = "0.00";
                    this.txt_retencion.Text = "0.00";
                    this.txt_total.Text = "0.00";
                    this.txt_saldoInicial.Text = "0.00";
                    this.txt_facturado.Text = "0.00";
                    this.txt_cobro.Text = "0.00";
                    this.txt_datafast.Clear();
                    this.txt_medianet.Clear();
                    this.txt_redApoyo.Clear();
                    this.btn_accion.Text = "Abrir";
                    this.txt_monto.Select();
                }
                else
                {
                    tran.refrescar();
                    decimal totaFacturado = tran.sacarTotalVendido(this.cajaActiva.Id);
                    tran.refrescar();
                    Caja recibido = tran.sacarTotalRecibido(this.cajaActiva.Id);

                    this.txt_secuencia.Text = cajaActiva.Codigo_secuencial.ToString();
                    this.txt_monto.Text = Math.Round(cajaActiva.Monto_incial, Global.cantidadDecimales).ToString();
                    this.dtp_edicion.Value = cajaActiva.Edicion;
                    this.txt_efectivo.Text = Math.Round(recibido.Efectivo, Global.cantidadDecimales).ToString();
                    this.txt_cheque.Text = Math.Round(recibido.Cheque, Global.cantidadDecimales).ToString();
                    this.txt_tarjetas.Text = Math.Round(recibido.Tarjeta, Global.cantidadDecimales).ToString();
                    this.txt_retencion.Text = Math.Round(recibido.Retencion, Global.cantidadDecimales).ToString();
                    recibido.Total_cierre = recibido.Efectivo + recibido.Cheque + recibido.Tarjeta + recibido.Retencion;
                    this.txt_total.Text = Math.Round(recibido.Total_cierre, Global.cantidadDecimales).ToString();

                    this.txt_saldoInicial.Text = Math.Round(cajaActiva.Monto_incial, Global.cantidadDecimales).ToString();
                    this.txt_cobro.Text = Math.Round(recibido.Total_cierre, Global.cantidadDecimales).ToString();
                    this.txt_facturado.Text = Math.Round(totaFacturado, Global.cantidadDecimales).ToString();
                    //this.txt_cobro.Text = Math.Round((facturado.Efectivo + facturado.Cheque + facturado.Tarjeta + facturado.Retencion), Global.cantidadDecimales).ToString();
                    this.txt_saldoFinal.Text = Math.Round((decimal.Parse(this.txt_saldoInicial.Text) + decimal.Parse(this.txt_cobro.Text)), Global.cantidadDecimales).ToString();
                    this.txt_monto.KeyUp -= txt_monto_KeyUp;
                    this.txt_monto.ReadOnly = true;
                    //ponerTotal();
                    if (recibido.Tarjeta > 0)
                    {
                        List<String> datos = CajaTR.obtenerPing(this.cajaActiva.Id);
                        foreach (string red in datos)
                        {
                            if (red == "D")
                            {
                                //this.label9.Visible = true;
                                //this.txt_datafast.Visible = true;
                                this.datafast = true;
                                this.txt_datafast.ReadOnly = false;
                            }
                            else if (red == "M")
                            {
                                //this.label10.Visible = true;
                                //this.txt_medianet.Visible = true;
                                this.medianet = true;
                                this.txt_medianet.ReadOnly = false;
                            }
                            else if (red == "R")
                            {
                                //this.label11.Visible = true;
                                //this.txt_redApoyo.Visible = true;
                                this.redapoyo = true;
                                this.txt_redApoyo.ReadOnly = false;
                            }
                        }
                    }

                    if (!this.datafast && !this.medianet && !this.redapoyo) this.grp_lotes.Visible = false;

                    if (this.tipo != "abrir")
                    {
                        if (this.cierreManual)
                        {
                            this.grp_saldos.Visible = false;
                            this.grp_ventas.Visible = false;
                            this.grp_saldosManual.Visible = true;
                        }

                        this.probarConexionInternet();
                        this.txt_fechaHora.Text = DateTime.Now.ToString();
                        //this.txt_tipo.Text = "CERRAR";
                        this.btn_accion.Text = "Cerrar";
                    }
                    else
                    {
                        Mensaje.advertencia("La caja ya está abierta, las opciones estarán deshabilitadas.");
                        //this.txt_tipo.Text = "ABRIR";

                        if (this.cierreManual)
                        {
                            this.grp_saldos.Visible = false;
                            this.grp_ventas.Visible = false;
                        }

                        this.txt_fechaHora.Text = cajaActiva.Fecha_hora.ToString();
                        this.txt_monto.ReadOnly = true;
                        this.btn_accion.Enabled = false;
                    }
                }
            }
            catch (Exception e)
            {
                Mensaje.error(e.Message);
                this.bloquearBotones();
            }
        }

        private void txt_secuencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.soloNumeros(e);
        }

        private void txt_monto_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.permitirDecimales(sender,e);
        }

        private void btn_accion_Click(object sender, EventArgs e)
        {
            this.cambiarEstadoCaja();
           
        }

        protected void imprimirCierre()
        {
            ImpresionCierre impresion = new ImpresionCierre();
            impresion.fecha = DateTime.Now.ToString();
            impresion.saldo_inicial = this.txt_saldoInicial.Text;
            impresion.total_facturado = this.txt_facturado.Text;
            impresion.total_cobrado = this.txt_cobro.Text;
            impresion.saldo_final = this.txt_saldoFinal.Text;
            if (this.cierreManual)
            {
                impresion.valor_efectivo = this.txt_efectivomanual.Text;
                impresion.valor_cheque = this.txt_chequemanual.Text;
            }
            else
            {
                impresion.valor_efectivo = this.txt_efectivo.Text;
                impresion.valor_cheque = this.txt_cheque.Text;
            }
            impresion.valor_tarjeta = this.txt_tarjetas.Text;
            impresion.valor_retencion = this.txt_retencion.Text;
            impresion.total_caja    =  this.txt_total.Text;
            impresion.lote_datafast = this.txt_datafast.Text;
            impresion.lote_medianet = this.txt_medianet.Text;
            impresion.lote_redApoyo = this.txt_redApoyo.Text;
            impresion.imprimir();
        }

        protected void imprimirCierreCaja()
        {
            this.imprimirCierre();
            return;
            Impresion Ticket1 = new Impresion();
            Ticket1.AbreCajon();  //abre el cajon
            Ticket1.TextoDerecha("\n");//Espacio necesario
            Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToString());
            Ticket1.LineasIgual();
            Ticket1.TextoDerecha("CIERRE DE CAJA");
            Ticket1.LineasIgual();

            
            Ticket1.TextoDerecha("Saldos");
            Ticket1.LineasGuion();
            Ticket1.TextoDerecha("Inicial:" + this.txt_saldoInicial.Text);

            if (!this.cierreManual)
            {
                Ticket1.TextoDerecha("Facturado:" + this.txt_facturado.Text);
                Ticket1.TextoDerecha("Cobrado:" + this.txt_cobro.Text);
                Ticket1.TextoDerecha("Final:" + this.txt_saldoFinal.Text);
            }

            Ticket1.TextoDerecha("\n");
            Ticket1.LineasGuion();
            Ticket1.TextoCentro ("Ventas");
            Ticket1.LineasGuion();
            if (this.cierreManual)
            {
                Ticket1.TextoDerecha("Efectivo:" + this.txt_efectivomanual.Text);
                Ticket1.TextoDerecha("Cheque:" + this.txt_chequemanual.Text);
            }
            else
            {
                Ticket1.TextoDerecha("Efectivo:" + this.txt_efectivo.Text);
                Ticket1.TextoDerecha("Cheque:" + this.txt_cheque.Text);
            }
            Ticket1.TextoDerecha("Tarjetas:" + this.txt_tarjetas.Text);
            Ticket1.TextoDerecha("Retencion:" + this.txt_retencion.Text);
            if (!this.cierreManual) Ticket1.TextoDerecha("Total:" + this.txt_total.Text);

            Ticket1.TextoDerecha("\n");
            Ticket1.LineasGuion();
            Ticket1.TextoCentro("Lotes");
            Ticket1.LineasGuion();
            Ticket1.TextoDerecha("Datafast:" + this.txt_datafast.Text);
            Ticket1.TextoDerecha("Medianet:" + this.txt_medianet.Text);
            Ticket1.TextoDerecha("Red Apoyo:" + this.txt_redApoyo.Text);

            Ticket1.CortaTicket();
        }


        protected bool validarCierre()
        {

            if (this.datafast && String.IsNullOrEmpty(txt_datafast.Text.Trim()))
            {
                Mensaje.advertencia("Por favor ingrese el número de lote para Datafast.");
                return false;
            }
            if (this.medianet && String.IsNullOrEmpty(txt_medianet.Text.Trim()))
            {
                Mensaje.advertencia("Por favor ingrese el número de lote para Medianet.");
                return false;
            }
            if (this.redapoyo && String.IsNullOrEmpty(txt_redApoyo.Text.Trim()))
            {
                Mensaje.advertencia("Por favor ingrese el número de lote para Red de Apoyo.");
                return false;
            }


            if (this.cierreManual)
            {
                string efectivoManual = String.IsNullOrEmpty(this.txt_efectivomanual.Text)?"0.00":this.txt_efectivomanual.Text;
                string chequeManual = String.IsNullOrEmpty(this.txt_chequemanual.Text) ? "0.00" : this.txt_chequemanual.Text;
                return Mensaje.confirmacion("Cerrar caja con los valores de $" + efectivoManual + " en efectivo y $" +  chequeManual + " en cheque?");
            }
            return true;
        }

        public Caja llenarDatosApertura()
        {
            Caja caja = new Caja();
            caja.Codigo_secuencial = int.Parse(this.txt_secuencia.Text);
            caja.Id_empleado = Global.logIdUser;
            caja.Edicion = this.dtp_edicion.Value.Date;
            caja.Apertura_cierre = "A";
            caja.Monto_incial = Decimal.Parse(this.txt_monto.Text);
            caja.Id_confPos = this.idConfPos;
            return caja;
        }

        public Caja llenarDatosCerrar()
        {
            Caja caja = new Caja();
            caja.Id = this.cajaActiva.Id;
            caja.Codigo_secuencial = int.Parse(this.txt_secuencia.Text);
            caja.Id_empleado = Global.idEmpleado;
            caja.Fecha_hora = DateTime.Parse(this.txt_fechaHora.Text);
            caja.Apertura_cierre = "C";
            caja.Monto_incial = Decimal.Parse(this.txt_monto.Text);
            caja.Id_confPos = this.idConfPos;

            caja.Efectivo = Decimal.Parse(this.txt_efectivo.Text);
            caja.Cheque = Decimal.Parse(this.txt_cheque.Text);
            caja.Tarjeta = Decimal.Parse(this.txt_tarjetas.Text);
            caja.Retencion = Decimal.Parse(this.txt_retencion.Text);
            caja.Total_cierre = Decimal.Parse(this.txt_total.Text);
            caja.Total_cobro = Decimal.Parse(this.txt_cobro.Text);
            caja.Total_facturado = Decimal.Parse(this.txt_facturado.Text);
            caja.Saldo_final = Decimal.Parse(this.txt_saldoFinal.Text);

            if (this.cierreManual)
            {
                caja.Efectivo_Manual = String.IsNullOrEmpty(this.txt_efectivomanual.Text)?0:Convert.ToDecimal(this.txt_efectivomanual.Text);
                caja.Cheque_Manual = String.IsNullOrEmpty(this.txt_chequemanual.Text)?0:Convert.ToDecimal(this.txt_chequemanual.Text);
            }

            return caja;
        }

        public bool validar()
        {
            if (String.IsNullOrEmpty(this.txt_secuencia.Text.Trim()))
            {
                Mensaje.advertencia("Ingrese el secuencial de la Apertura");
                this.txt_secuencia.Focus();
                return false;
            }           
            if (String.IsNullOrEmpty(this.txt_monto.Text.Trim()))
            {
                Mensaje.advertencia("Ingrese el monto inicial");
                this.txt_monto.Focus();
                return false;
            }
            return true;
        }

        private void txt_monto_KeyUp(object sender, KeyEventArgs e)
      {
            this.txt_saldoInicial.Text = this.txt_monto.Text;
            this.txt_efectivo.Text = "0.00";
            this.txt_cheque.Text = "0.00";
            this.txt_tarjetas.Text = "0.00";
            this.txt_retencion.Text = "0.00";
            this.txt_facturado.Text = "0.00";
            this.txt_cobro.Text = "0.00";            
            if (e.KeyData == Keys.Enter) this.cambiarEstadoCaja();
        }

        public void ponerTotal()
        {
             
            decimal efectivo = General.convertirDecimal(this.txt_efectivo.Text); 
            decimal cheque = General.convertirDecimal(this.txt_cheque.Text);
            decimal tarjeta = General.convertirDecimal(this.txt_tarjetas.Text);
            decimal retencion = General.convertirDecimal(this.txt_retencion.Text);
            this.txt_total.Text = (efectivo + cheque + tarjeta +  retencion).ToString();
            this.txt_facturado.Text = (efectivo + cheque + tarjeta + retencion).ToString();
            decimal facturado = General.convertirDecimal(this.txt_saldoInicial.Text); 
            decimal inicial = General.convertirDecimal(this.txt_cobro.Text);
            this.txt_saldoFinal.Text = (facturado + inicial).ToString();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            frm_cajaListado listado = new frm_cajaListado(this.idConfPos);
            listado.Owner = this;
            listado.ShowDialog();
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            this.estadoInicial();
        }

        private void enviarMailApertura(int idCaja)
        {
            frm_menu menu = (frm_menu)this.Owner;
            Thread hiloApertura = new Thread(
               new ThreadStart(() =>
               {
                   List<object> datosMail = ParametroTR.ConsultarInt("19,47,48");
                   if (datosMail[1].Equals("1"))
                   {
                       Mail correo = new Mail();
                       correo.enviarCorreo(datosMail[0].ToString(), datosMail[2].ToString(), correo.contenidoAperturaCaja(idCaja));
                   }
               }));
            menu.setThread(hiloApertura);
        }

        protected void cambiarEstadoCaja()
        {
            if (validar())
            {
                if (this.btn_accion.Text == "Abrir")
                {
                    Caja caja = this.llenarDatosApertura();
                    CajaTR tran = new CajaTR(caja);
                    String msn = "";
                    if (tran.abrirCaja(ref msn))
                    {
                        this.btn_accion.Enabled = false;
                        this.txt_monto.Enabled = false;
                        this.enviarMailApertura(caja.Id);
                        Mensaje.informacion("La caja ha sido abierta correctamente.");
                        this.Close();
                    }
                    else Mensaje.advertencia(msn);
                }
                else if (this.btn_accion.Text == "Cerrar")
                {// cerrar
                    if (!validarCierre()) return;
                    this.backgroundThread.Join();
                    Caja caja = llenarDatosCerrar();
                    CajaTR tran = new CajaTR(caja);
                    String msn = "";

                    int deboSincronizar = ParametroTR.consultarIntXNombre("sincronizarAlCerrar");
                    int deboEnviarCorreo = ParametroTR.consultarIntXNombre("enviarCorreo");
                    int turnoSincronizar = Sincronizacion.ultimoSincronizado(ref msn);
                    turnoSincronizar++;
 
                    if (tran.cerrarCaja(ref msn, this.txt_datafast.Text, this.txt_medianet.Text, this.txt_redApoyo.Text))
                    {
                        this.btn_accion.Text = "Imprimir";
                        if (deboSincronizar == 1 && turnoSincronizar == this.cajaActiva.Id) this.sincronizarCierreCaja((deboEnviarCorreo == 1));
                        else if(deboEnviarCorreo == 1 && this.conexionInternet)this.correoCierreCaja();
                        else Mensaje.informacion("Caja cerrada satisfactoriamente.");
                    }
                    else Mensaje.advertencia(msn);
                }
                else
                {
                    if (Impresion.IsPrinterOnline(Global.nombreImpresora)) this.imprimirCierreCaja();
                    else Mensaje.advertencia("La impresora no se encuentra disponible.");
                }
            }
        }

        protected void correoCierreCaja()
        {
            frm_cargando sincronizar = new frm_cargando(this.cajaActiva.Id,this.obtenerDatos(),true);
            sincronizar.Owner = this;
            sincronizar.ShowDialog();
        }

        protected void sincronizarCierreCaja(bool enviarCorreo)
        {
            try
            {
                if (this.conexionInternet)
                {
                    frm_cargando sincronizar = new frm_cargando(this.cajaActiva.Id,(enviarCorreo)?this.obtenerDatos():null);
                    sincronizar.Owner = this;
                    sincronizar.ShowDialog();
                }
                else {
                    if (Mensaje.confirmacion("Caja cerrada satisfactoriamente.\n Desea generar el archivo de cierre?"))
                    {
                        if (this.fbd_buscar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            string mensaje = "";
                            //string nuevoNumero = EmpresaTR.obtenerNumerodeCierre(ref mensaje).ToString();
                            Sincronizacion xml = new Sincronizacion();
                            XmlDocument documento = xml.generarXmlCierreCaja(this.cajaActiva.Id);
                            documento.Save(this.fbd_buscar.SelectedPath + @"\CierreCaja_" + DateTime.Now.ToShortDateString().Replace("/", "") + "_" + this.cajaActiva.Id + ".xml");
                            Sincronizacion.actualizarEstadoUsb(ref mensaje, this.cajaActiva.Id);
                            Mensaje.informacion("Archivo generado satisfactoriamente.");
                        }
                    }
             
                }

            }
            catch (Exception e)
            {
                Mensaje.error(e.Message);
            }
        }

        private Hashtable obtenerDatos()
        {
            Hashtable datos = new Hashtable();
            datos.Add("nCierre", "");
            datos.Add("direccion", "");
            datos.Add("fecha", DateTime.Now.ToString());
            datos.Add("cajero", "");
            datos.Add("efectivo", this.txt_efectivo.Text);
            datos.Add("cheque", this.txt_cheque.Text);
            datos.Add("tarjeta", this.txt_tarjetas.Text);
            datos.Add("notaCredito", "0");
            datos.Add("retencion", this.txt_retencion.Text);
            datos.Add("datafast", this.txt_datafast.Text);
            datos.Add("medianet", this.txt_medianet.Text);
            datos.Add("redApoyo", this.txt_redApoyo.Text);
            return datos;
        }

        protected void probarConexionInternet()
        {
            try
            {
                this.backgroundThread = new Thread(
                       new ThreadStart(() =>
                       {
                           try
                           {

                               if (General.tieneConexionInternet())this.conexionInternet = true;
                           }
                           catch (Exception error)
                           {
                               Mensaje.error(error.Message);
                           }
                       }
                   ));
                backgroundThread.Start();
            }
            catch (Exception error)
            {
                Mensaje.error(error.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string data = "";
                int espacios = 0;
                List<String[]> productos = CajaTR.consultarProductos(Convert.ToInt32(this.txt_secuencia.Text));
                if (productos != null)
                {
                    foreach (String[] producto in productos)
                    {
                        data += producto[0] + "\t" + producto[2] + "\n" + producto[1] + "\n\n";
                        espacios += 3;
                    }
                    ImpresionTexto impresion = new ImpresionTexto(data, espacios, this.txt_secuencia.Text, this.btn_accion.Text == "Cerrar" ? "Abierta" : "Cerrada");
                    impresion.imprimir();
                }
                else Mensaje.informacion("No existe productos para imprimir");
            }
            catch (Exception error)
            {
                Mensaje.error(error.Message);
            }
        }

        private void grp_aperturar_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_saldoInicial_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txt_efectivo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_limpiar_Click_1(object sender, EventArgs e)
        {
            this.estadoInicial();
        }

        private void frm_abrir_cerrar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.habilitarCampoEdicion && this.cajaActiva != null)
            {
                CajaTR.actualizarEdicion(this.cajaActiva.Id, this.dtp_edicion.Value);
            }
        }
    }
}
