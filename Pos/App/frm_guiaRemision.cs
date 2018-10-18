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
using Pos.App;

namespace Pos
{
    public partial class frm_guiaRemision : Form
    {
        //Autocompletar
        AutoCompleteStringCollection autoComplete;
        GuiaRemision guiaRemision = null;
        Persona transportista = null;
        Persona cliente = null;
        FacturaCabecera documento = null;
        bool deboBuscar = true;
        bool desdeFactura = false;
        bool vieneFactura = false;
        Caja caja = null;
        ConfiguracionPos configuracion = null;

        public frm_guiaRemision()
        {
            InitializeComponent();
        }

        public frm_guiaRemision(string comprobante,int idCliente, int idFactura)
        {
            InitializeComponent();
            this.buscarCliente(idCliente);
            if(idFactura != 0)this.buscarDocumento(idFactura);
            this.desdeFactura = true;
            this.vieneFactura = true;
        }

        public void setIdGuia(int id)
        {
            this.buscarGuia(id);
        }

        private GuiaRemision tomarDatos()
        {
            GuiaRemision remision = new GuiaRemision();
            remision.fechaEmision = this.dtp_fechaEmision.Value; 
            remision.fechaInicio = this.dtp_fechaInicioTraslado.Value;
            remision.fechaFin = this.dtp_fechaFinTraslado.Value;
            remision.estado = "E";
            remision.direccionPartida = this.txt_direccionPartida.Text;
            remision.numeroDocumento = this.txt_numeroDocumento.Text;
            remision.placa = this.txt_placaTransportista.Text;
            remision.autorizacion = this.txt_autorizacion.Text;
            remision.descripcion = this.txt_descripcion.Text;
            remision.transportista = this.transportista;
            remision.destinatarios = new List<Destinatario>();
            remision.caja = this.caja;
            Destinatario destinatario = new Destinatario();
            destinatario.cliente = this.cliente;
            destinatario.documento = this.documento;
            destinatario.direccion = this.txt_direccionDestinatario.Text;
            destinatario.motivo = this.txt_motivoDestinatario.Text;
            destinatario.codigoDestino = this.txt_codigoDestino.Text;
            destinatario.ruta = this.txt_ruta.Text;
            List<String[]> detalles = new List<String[]>();
            foreach (DataGridViewRow fila in this.grw_productos.Rows)
            {
                if (!General.celdaVacia(fila.Cells["nombre"]) && !General.celdaVacia(fila.Cells["id"]))
                {
                    String[] datos = new String[4];
                    datos[0] = fila.Cells["id"].Value.ToString();
                    datos[1] = fila.Cells["nombre"].Value.ToString();
                    datos[2] = fila.Cells["cantidad"].Value.ToString();
                    datos[3] = fila.Cells["unidad"].Value.ToString();
                    detalles.Add(datos);
                }
            }
            destinatario.detalle = detalles;
            remision.destinatarios.Add(destinatario);
            return remision;
        }

        private void grw_ubicaciones_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (this.grw_productos.Columns[e.ColumnIndex].Name == "botonEliminar")
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

        private void grw_ubicaciones_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox cajaTexto = e.Control as TextBox;
            if (grw_productos.CurrentCell.ColumnIndex == grw_productos.Columns["Nombre"].Index)
            {
                if (cajaTexto != null)
                {
                    cajaTexto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cajaTexto.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    cajaTexto.AutoCompleteCustomSource = autoComplete;
                }
            }
            else cajaTexto.AutoCompleteCustomSource = null;
        }

        public void buscarProducto(int idProducto, string nombre, int fila)
        {
            String mensaje = "";
            String[] datos = ProductoTR.consultarUnidad(idProducto, nombre);
            if (datos != null)
            {
                this.grw_productos.Rows[fila].Cells["id"].Value = datos[0];
                this.grw_productos.Rows[fila].Cells["nombre"].Value = datos[1];
                this.grw_productos.Rows[fila].Cells["unidad"].Value = datos[2];
                this.grw_productos.Rows[fila].Cells["cantidad"].Value = 1;
            }
            else
            {
                if (String.IsNullOrEmpty(mensaje))
                {
                    Mensaje.advertencia("No se encontró el producto.");
                }
                else Mensaje.advertencia(mensaje);
            }
        }

        private void frm_guiaRemision_Load(object sender, EventArgs e)
        {
            this.setCajaActiva();
            this.limpiar();
            this.setDireccionPartida();
            this.setDescipcionGuia();
            string msn = "";
            autoComplete = new AutoCompleteStringCollection();
            ProductoTR tranPro = new ProductoTR();
            DataTable datos = tranPro.consultarNombreProductos(ref msn, true);
            foreach (DataRow fila in datos.Rows) autoComplete.Add(fila[0].ToString());
        }

        private void setDireccionPartida(){

            string direccion_partida = EmpresaTR.obtenerDireccionEmpresa();

            this.txt_direccionPartida.Text = direccion_partida;
        }

        private void setDescipcionGuia()
        {

            string descripcion = "Venta";

            this.txt_descripcion.Text = descripcion;
        }

        private void setCajaActiva()
        {
            string msn = "";
            ConfiguracionPos confPredeterminada = ConfiguracionPosTR.consultarConfiguracionPredeterminada(General.getComputerName(), ref msn);
            this.configuracion = ConfiguracionPosTR.consultarConfiguracionPredeterminada(General.getComputerName(), ref msn, "G");
            if (confPredeterminada == null)
            {
                if (String.IsNullOrEmpty(msn)) Mensaje.advertencia("Debe configurar el Punto de venta y abrir caja para facturar.");
                else Mensaje.error("Configuración Predeterminada: " + msn);
                this.Close();
                return;
            }
            Caja caja = CajaTR.verEstadoCaja(confPredeterminada.Idconf_pos, "A");
            if (caja == null)
            {
                Mensaje.advertencia("Debe abrir caja para poder facturar.");
                this.Close();
                return;
            }

            if (this.configuracion == null)
            {
                Mensaje.advertencia("Debe configurar el punto de venta para emitir guías de remisión.");
                this.Close();
                return;
            }

            this.caja = caja;
        }

        private void actualizarSecuencia()
        {
            if (this.configuracion.Activar_secuencia)
            {
                string msn = "";
                ConfiguracionPosTR.actualizarNumeroGuia(this.configuracion.Idconf_pos, this.configuracion.Sec_actual, ref msn);
                this.configuracion.Sec_actual += 1;
                if (!String.IsNullOrEmpty(msn)) Mensaje.mostrarNotificacion("Facturas omitidas", msn);
            }
        }

        private void grw_productos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0) return;
            if (this.grw_productos.Columns[e.ColumnIndex].Name == "botonEliminar")
            {
                this.grw_productos.Rows.RemoveAt(e.RowIndex);
                if (this.grw_productos.Rows.Count < 1) this.grw_productos.Rows.Add();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }

        protected void limpiar(bool cargarDatos = true)
        {
            if (cargarDatos)
            {
                int secuencia = GuiaRemisionTR.consultarSecuencia();
                this.txt_secuencia.Text = secuencia.ToString();
                this.txt_numeroDocumento.Text = this.getNumeroDocumento();
                this.txt_autorizacion.Text = this.configuracion.Autorizacion;
            }
            if (this.desdeFactura)
            {
                this.desdeFactura = false;
                return;
            }
            this.tsb_guardar.Enabled = true;
            this.dtp_fechaInicioTraslado.Value = DateTime.Now;
            this.dtp_fechaFinTraslado.Value = DateTime.Now;
            this.txt_direccionPartida.Clear();
            this.txt_cedulaTransportista.Clear();
            this.txt_nombreTransportista.Clear();
            this.txt_placaTransportista.Clear();
            this.txt_correoTransportista.Clear();
            this.txt_descripcion.Clear();

            this.txt_cedulaDestinatario.Clear();
            this.txt_nombreDestinatario.Clear();
            this.txt_direccionDestinatario.Clear();
            this.txt_codigoDestino.Clear();
            this.txt_ruta.Clear();

            this.txt_documento.Clear();
            this.txt_motivoDestinatario.Clear();

            this.grw_productos.DataSource = null;
            this.grw_productos.Rows.Clear();
            this.guiaRemision = null;
            this.cliente = null;
            this.transportista = null;
            this.documento = null;
            this.setDireccionPartida();
            this.setDescipcionGuia();
            this.txt_descripcion.Focus();

        }

        private string getNumeroDocumento()
        {
            return completarDigitos(3, this.configuracion.Codigo_establecimiento.ToString()) + "-" +
                        completarDigitos(3, this.configuracion.Pto_emision.ToString()) + "-" +
                        completarDigitos(9, this.configuracion.Sec_actual.ToString());
        }

        private string completarDigitos(int numero, string cadena)
        {
            int restante = numero - cadena.Length;
            String relleno = "";
            if (restante > 0) for (int i = 0; i < restante; i++) relleno = relleno + "0";
            return (relleno + cadena);
        }   

        protected bool validar()
        {
            this.grw_productos.EndEdit();

            if (this.txt_direccionPartida.Text.Trim().Length < 1)
            {
                Mensaje.advertencia("Debe ingresar la dirección de partida");
                this.txt_direccionPartida.Focus();
                return false;
            }

            if (this.txt_descripcion.Text.Trim().Length < 1)
            {
                Mensaje.advertencia("Debe ingresar la descripcion");
                this.txt_descripcion.Focus();
                return false;
            }

            if (this.transportista == null)
            {
                Mensaje.advertencia("Debe ingresar el transportista");
                this.txt_cedulaTransportista.Focus();
                return false;
            }

            if (this.txt_placaTransportista.Text.Trim().Length < 1)
            {
                Mensaje.advertencia("Debe ingresar la placa");
                this.txt_placaTransportista.Focus();
                return false;
            }

            if (this.cliente == null)
            {
                Mensaje.advertencia("Debe ingresar el destinatario");
                this.txt_cedulaDestinatario.Focus();
                return false;
            }

            if (this.txt_direccionDestinatario.Text.Trim().Length < 1)
            {
                Mensaje.advertencia("Debe ingresar la dirección de llegada");
                this.txt_direccionDestinatario.Focus();
                return false;
            }

            if (this.txt_motivoDestinatario.Text.Trim().Length < 1)
            {
                Mensaje.advertencia("Debe ingresar el motivo");
                this.txt_motivoDestinatario.Focus();
                return false;
            }

            int i=0;
            foreach (DataGridViewRow fila in this.grw_productos.Rows)
            {
                if (!General.celdaVacia(fila.Cells["nombre"]))
                {
                    if (General.celdaVacia(fila.Cells["cantidad"]))
                    {
                        Mensaje.advertencia("Debe ingresar una cantidad en la fila " + (i+1));
                        return false;
                    }
                    
                }
                i++;
            }
            return true;
        }

        protected void guardarGuia()
        {
            try
            {
                if (!this.validar()) return;
                GuiaRemision guia = this.tomarDatos();
                GuiaRemisionTR tran = new GuiaRemisionTR(guia);
                tran.insertarGuia();
                this.actualizarSecuencia();
                guia.imprimir(18, 40);
                Mensaje.informacion("Guia almacenada satisfactoriamente");
                if (this.vieneFactura) this.Close();
                else this.limpiar();
            }
            catch (Exception e)
            {
                Mensaje.error(e.Message);
            }
        }

        private void grw_productos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!deboBuscar) return;
            string columna = this.grw_productos.Columns[e.ColumnIndex].Name;
            if (columna != "nombre") return;
            string producto = General.obtenerValorCelda(grw_productos, e);
            if (string.IsNullOrEmpty(producto))
            {
                General.filaVaciar(this.grw_productos.CurrentRow, e.ColumnIndex);
                return;
            }
            this.deboBuscar = false;
            this.buscarProducto(-1,producto, e.RowIndex);
            this.deboBuscar = true;  
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (!this.validar()) return;
            this.guiaRemision = this.tomarDatos();
            this.guiaRemision.imprimir(18, 40);
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            frm_buscarGuiaRemision listado = new frm_buscarGuiaRemision();
            listado.ShowDialog(this);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           /* if (e.KeyChar == 13)
            {
                if (this.txt_secuencia.Text.Trim().Length < 1)
                {
                    Mensaje.advertencia("Ingrese una secuencia para poder consultar.");
                    return;
                }
                this.buscarGuia(Convert.ToInt32(this.txt_secuencia.Text));
            }
            General.soloNumeros(e);*/
        }

        protected void buscarGuia(int idGuia)
        {
            GuiaRemision guia = GuiaRemisionTR.consultarXId(idGuia);
            if (guia != null)
            {
                this.limpiar(false);
                this.txt_secuencia.Text = guia.id.ToString();
                this.dtp_fechaEmision.Value = guia.fechaEmision;
                this.dtp_fechaInicioTraslado.Value = guia.fechaInicio;
                this.dtp_fechaFinTraslado.Value = guia.fechaFin;
                this.txt_direccionPartida.Text = guia.direccionPartida;
                this.txt_numeroDocumento.Text = guia.numeroDocumento;
                this.txt_autorizacion.Text = guia.autorizacion;
                this.txt_cedulaTransportista.Text = guia.transportista.cedula;
                this.txt_nombreTransportista.Text = guia.transportista.razon_social;
                this.txt_correoTransportista.Text = guia.transportista.email;
                this.txt_placaTransportista.Text = guia.placa;
                this.txt_descripcion.Text = guia.descripcion;
                Destinatario destinatario = guia.destinatarios[0];
                this.txt_cedulaDestinatario.Text = destinatario.cliente.cedula;
                this.txt_nombreDestinatario.Text = destinatario.cliente.razon_social;
                this.txt_documento.Text = (destinatario.documento!=null)?destinatario.documento.Numero_documento:"";
                this.txt_motivoDestinatario.Text = destinatario.motivo;
                this.txt_direccionDestinatario.Text = destinatario.direccion;
                this.txt_codigoDestino.Text = destinatario.codigoDestino;
                this.txt_ruta.Text = destinatario.ruta;

                if (destinatario.detalle != null)
                {
                    foreach (object[] producto in destinatario.detalle)
                    {
                        this.grw_productos.Rows.Add(producto);
                    }
                }
            }
            else Mensaje.informacion("No se encontró la guía ingresada");
            this.guiaRemision = guia;
            this.transportista = guia.transportista;
            this.documento = guia.destinatarios[0].documento;
            this.cliente = guia.destinatarios[0].cliente;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.guardarGuia();
        }

        private void txt_secuencia_KeyUp(object sender, KeyEventArgs e)
        {
            //if (String.IsNullOrEmpty(this.txt_secuencia.Text)) this.limpiar();
        }

        private void tsb_editar_Click(object sender, EventArgs e)
        {
            frm_guiaRemisionDefecto guia = new frm_guiaRemisionDefecto();
            guia.ShowDialog();
        }

        private void tbc_destinatarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage tabAgregar = tbc_destinatarios.TabPages["tbp_agregar"];
            if (tbc_destinatarios.SelectedTab == tabAgregar)
            {
                int indice = tbc_destinatarios.SelectedIndex;
                tbc_destinatarios.TabPages.Insert(indice, "Adicional " + (indice + 1));
                tbc_destinatarios.SelectedIndex = tbc_destinatarios.SelectedIndex - 1;
            }
        }

        private class TabControles
        { 
            
        }

        private void btn_buscarCliente_Click(object sender, EventArgs e)
        {
            
            frm_sincronizarPersonas frmSincronizarpersonas = new frm_sincronizarPersonas();
            DialogResult sp = frmSincronizarpersonas.ShowDialog(this);
            Console.WriteLine(sp);
            if (sp == DialogResult.Cancel){
                return;
          
            }else{
                  frm_buscarCliente frmCliente = new frm_buscarCliente();
            DialogResult dr = frmCliente.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                this.buscarCliente(frmCliente.id);
            }
            }
           
        }

        private void buscarCliente(int idCliente)
        {

            this.cliente = ClienteTR.buscarXId(idCliente);

             if (cliente.bloqueado)
            {
                Mensaje.informacion("La persona seleccionada posee documentos vencidos no se podrá emitir una guía de remisión a este nombre");
                this.borrarDatosCliente();
                return;
                this.limpiar();
            }
            this.txt_cedulaDestinatario.Text = String.IsNullOrEmpty(this.cliente.cedula) ? this.cliente.ruc : this.cliente.cedula;
            this.txt_nombreDestinatario.Text = this.cliente.razon_social;
            this.txt_direccionDestinatario.Text = this.cliente.direccion;
            Console.WriteLine(cliente.bloqueado);
            this.txt_direccionDestinatario.Focus();
        }

        private void borrarDatosCliente()
        {
            this.txt_cedulaDestinatario.Text = "";
            this.txt_nombreDestinatario.Text = "";
            this.txt_direccionDestinatario.Text = "";
            this.txt_cedulaDestinatario.Focus();


        }


        private void btn_transportista_Click(object sender, EventArgs e)
        {
            frm_buscar_empleado frmTransportista = new frm_buscar_empleado();
            DialogResult dr = frmTransportista.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                this.txt_cedulaTransportista.TextChanged -= txt_cedulaTransportista_TextChanged;
                this.transportista = EmpleadoTR.buscarXId(frmTransportista.idEmpleado);
                this.txt_cedulaTransportista.Text = this.transportista.cedula;
                this.txt_correoTransportista.Text = String.IsNullOrEmpty(this.transportista.email) ? "" : this.transportista.email;
                this.txt_nombreTransportista.Text = this.transportista.razon_social;
                this.txt_cedulaTransportista.TextChanged += txt_cedulaTransportista_TextChanged;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_facturaListado frmFacturas = new frm_facturaListado();
            DialogResult dr = frmFacturas.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                this.buscarDocumento(frmFacturas.idFactura);
            }
        }

        private void buscarDocumento(int idDocumento)
        {
            this.grw_productos.Rows.Clear();
            this.documento = FacturaCabeceraTR.consultarFactura(idDocumento);
            this.txt_documento.Text = this.documento.Numero_documento;
            List<String[]> detalles = FacturaDetalleTR.consultarFacturaDetalle(this.documento.Id);
            if (detalles != null)
            {
                int i = 0;
                foreach (String[] detalle in detalles)
                {
                    this.grw_productos.Rows.Add();
                    this.grw_productos.Rows[i].Cells["id"].Value = detalle[8];
                    this.grw_productos.Rows[i].Cells["nombre"].Value = detalle[1];
                    this.grw_productos.Rows[i].Cells["cantidad"].Value = detalle[2];
                    this.grw_productos.Rows[i].Cells["unidad"].Value = detalle[3];
                    i += 1;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_buscarGuiaRemision frmBuscar = new frm_buscarGuiaRemision();
            DialogResult dr = frmBuscar.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                this.setIdGuia(frmBuscar.idGuia);
                this.tsb_guardar.Enabled = false;
            }
        }

        private void txt_cedulaTransportista_TextChanged(object sender, EventArgs e)
        {
            this.borrarTransportista();
        }

        private void borrarTransportista()
        {
            this.transportista = null;
            this.txt_nombreTransportista.Clear();
            this.txt_correoTransportista.Clear();
        }

        private void txt_cedulaDestinatario_TextChanged(object sender, EventArgs e)
        {

        }

        private void tsb_anular_Click(object sender, EventArgs e)
        {
            if (Mensaje.confirmacion("Está seguro que desea eliminar la guía de remisión?"))
            {
                if (this.guiaRemision != null) GuiaRemisionTR.anularGuia(this.guiaRemision);
                else {
                    GuiaRemision guia = new GuiaRemision();
                    guia.numeroDocumento = this.txt_numeroDocumento.Text;
                    guia.fechaEmision = this.dtp_fechaEmision.Value;
                    guia.autorizacion = this.txt_autorizacion.Text;
                    guia.descripcion = this.txt_autorizacion.Text;
                    GuiaRemisionTR.anularGuia(guia, true);
                    this.actualizarSecuencia();
                }
                this.limpiar();
            }
        }

        private void txt_secuencia_TextChanged(object sender, EventArgs e)
        {

        }
    }


}
