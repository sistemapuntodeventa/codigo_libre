using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Xml;
using Pos.Clases;

namespace Pos.Coneccion
{

    public class Sincronizacion
    {
        private Conexion conf;

        public Sincronizacion()
        {
            this.conf = new Conexion();
        }

        public XmlDocument generarXmlCierreCaja(int idCaja, int desde = -1, int cantidad = -1, bool ultimo = false, bool generarXml = false)
        {
            try
            {
                XmlDocument documento = new XmlDocument();
                XmlElement root = (XmlElement)documento.AppendChild(documento.CreateElement("root"));
                this.generarConfiguracion(documento, root, idCaja, ultimo);
                this.obtenerDatosCaja(documento, root, idCaja);
                this.obtenerClientes(documento, root, idCaja,desde,cantidad);
                this.generarXmlFacturas(documento, root, idCaja,desde,cantidad);
                if(generarXml)this.generarXmlGuiasRemision(documento,root, idCaja, desde, cantidad);
                else root.AppendChild(documento.CreateElement("guias"));
                return documento;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public XmlDocument generarXmlGuias(int idCaja, int desde = -1, int cantidad = -1, bool ultimo = false)
        {
            try
            {
                XmlDocument documento = new XmlDocument();
                XmlElement root = (XmlElement)documento.AppendChild(documento.CreateElement("root"));
                this.generarConfiguracion(documento, root, idCaja, ultimo);
                this.obtenerDatosCaja(documento, root, idCaja);
                this.obtenerClientesGuias(documento, root, idCaja, desde, cantidad);
                root.AppendChild(documento.CreateElement("documentos"));
                this.generarXmlGuiasRemision(documento, root, idCaja, desde, cantidad);
                return documento;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static int prueba()
        {
            return -1;
        }

        public static bool actualizarEstadoUsb(ref string mensaje, int idCaja)
        {
            bool resultado = false;
            MySqlCommand cmd = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("caja_actualizarEstado");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCajai", idCaja).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idEmpleadoi", Global.idEmpleado).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?estadoi", String.Empty).Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();
                resultado = true;

            }
            catch (Exception e) { mensaje = e.Message; }
            finally {
                if (cmd != null) cmd.Dispose();
                if (con != null) con.cerrar(); 
            }
            return resultado;
        }

        public static bool actualizarEstadoInternet(string estado, int idCaja)
        {
            return CajaTR.actualizarEstado(2, estado, idCaja);
        }

        public static bool actualizarEstadoInternetGuias(string estado, int idCaja)
        {
            return CajaTR.actualizarEstado(3, estado, idCaja);
        }

        protected void generarConfiguracion(XmlDocument documento, XmlElement root, int idCaja, bool fin)
        {
            //string valorConfiguracion = Global.idEmpresa.ToString() + DateTime.Now.ToShortDateString().Replace("/", "") + nuevoNumero;
            string valorConfiguracion = Global.idEmpresa.ToString() + DateTime.Now.ToShortDateString().Replace("/", "");
            root.AppendChild(documento.CreateElement("config")).InnerText = valorConfiguracion;

            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            try
            {

                cmd = this.conf.EjecutarSQL("xml_generarCierreCaja");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("?opcion", 8).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCierreCajai", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idFacturaCabecerai", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?inicio", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cantidad", -1).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.Read())
                {
                    root.AppendChild(documento.CreateElement("idCuentaPorCobrar")).InnerText = data.getStringNone("id_cuentaXCobrar");
                    root.AppendChild(documento.CreateElement("idCuentaCaja")).InnerText = data.getStringNone("id_cuentaCaja");
                    root.AppendChild(documento.CreateElement("idCuentaDatafast")).InnerText = data.getStringNone("id_cuentaDatafast");
                    root.AppendChild(documento.CreateElement("idCuentaMedianet")).InnerText = data.getStringNone("id_cuentaMedianet");
                    root.AppendChild(documento.CreateElement("idCuentaRedApoyo")).InnerText = data.getStringNone("id_cuentaRedApoyo");
                    root.AppendChild(documento.CreateElement("idComercioDatafast")).InnerText = data.getStringNone("id_comercioDatafast");
                    root.AppendChild(documento.CreateElement("idComercioMedianet")).InnerText = data.getStringNone("id_comercioMedianet");
                    root.AppendChild(documento.CreateElement("idComercioRedApoyo")).InnerText = data.getStringNone("id_comercioRedApoyo");
                    root.AppendChild(documento.CreateElement("idBodega")).InnerText = data.getStringNone("bodega");
                    root.AppendChild(documento.CreateElement("idProductoServicio")).InnerText = data.getStringNone("id_productoServicio");
                    root.AppendChild(documento.CreateElement("ultimoGrupo")).InnerText = fin.ToString();
                    //root.AppendChild(documento.CreateElement("idProductoPropina")).InnerText = data.getStringNone("id_productoPropina");
                }
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                this.conf.cerrar();
            }
        }

        protected void obtenerDatosCaja(XmlDocument documento, XmlElement root, int idCaja)
        {
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            try
            {

                cmd = this.conf.EjecutarSQL("xml_generarCierreCaja");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 7).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCierreCajai", idCaja).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idFacturaCabecerai", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?inicio", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cantidad", -1).Direction = ParameterDirection.Input;

                //XmlElement clientes = (XmlElement)root.AppendChild(documento.CreateElement("cajas"));
                XmlElement caja = (XmlElement)root.AppendChild(documento.CreateElement("Caja"));
                data = cmd.ExecuteReader();
                if (data.Read())
                {
    
                    caja.AppendChild(documento.CreateElement("id_caja")).InnerText = data.getStringNone("id_caja");
                    caja.AppendChild(documento.CreateElement("fecha_apertura")).InnerText = data.GetDateTime("fecha_apertura").ToString("yyyy-MM-dd");
                    caja.AppendChild(documento.CreateElement("empleado_apertura")).InnerText = data.getStringNone("empleado_apertura");
                    caja.AppendChild(documento.CreateElement("fecha_cierre")).InnerText = data.GetDateTime("fecha_cierre").ToString("yyyy-MM-dd");
                    caja.AppendChild(documento.CreateElement("empleado_cierre")).InnerText = data.getStringNone("empleado_cierre");

                    //caja.AppendChild(documento.CreateElement("apertura_cierre")).InnerText = data.getStringNone("apertura_cierre");

                    caja.AppendChild(documento.CreateElement("secuencial")).InnerText = data.getStringNone("secuencial");
                    //caja.AppendChild(documento.CreateElement("estado")).InnerText = data.getStringNone("estado");

                    caja.AppendChild(documento.CreateElement("monto_inicial")).InnerText = data.getStringNone("monto_inicial");
                    caja.AppendChild(documento.CreateElement("total_cierre")).InnerText = data.getStringNone("total_cierre");
                    caja.AppendChild(documento.CreateElement("efectivo")).InnerText = data.getStringNone("efectivo");
                    caja.AppendChild(documento.CreateElement("cheque")).InnerText = data.getStringNone("cheque");
                    caja.AppendChild(documento.CreateElement("tarjeta")).InnerText = data.getStringNone("tarjeta");

                    //caja.AppendChild(documento.CreateElement("id_confPos")).InnerText = data.getStringNone("id_confPos");

                    caja.AppendChild(documento.CreateElement("total_facturado")).InnerText = data.getStringNone("total_facturado");
                    caja.AppendChild(documento.CreateElement("total_cobrado")).InnerText = data.getStringNone("total_cobrado");
                    caja.AppendChild(documento.CreateElement("saldo_final")).InnerText = data.getStringNone("saldo_final");
                    caja.AppendChild(documento.CreateElement("retencion")).InnerText = data.getStringNone("retencion");

                    caja.AppendChild(documento.CreateElement("lote_datafast")).InnerText = data.getStringNone("lote_datafast");
                    caja.AppendChild(documento.CreateElement("lote_medianet")).InnerText = data.getStringNone("lote_medianet");
                    caja.AppendChild(documento.CreateElement("lote_redApoyo")).InnerText = data.getStringNone("lote_redApoyo");
                }
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                this.conf.cerrar();
            }
        }

        protected void obtenerClientes( XmlDocument documento, XmlElement root, int idCaja, int desde, int cantidad)
        { 
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            try
            {

                cmd = this.conf.EjecutarSQL("xml_generarCierreCaja");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 2).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCierreCajai", idCaja).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idFacturaCabecerai", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?inicio", desde).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cantidad", cantidad).Direction = ParameterDirection.Input;

                XmlElement clientes = (XmlElement)root.AppendChild(documento.CreateElement("personas"));
                data = cmd.ExecuteReader();
                while(data.Read())
                {
                    this.llenarDatosPersona(documento, clientes, data);
                }
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                this.conf.cerrar();
            }
        }

        protected void obtenerClientesGuias(XmlDocument documento, XmlElement root, int idCaja, int desde, int cantidad)
        {
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            try
            {

                cmd = this.conf.EjecutarSQL("xml_generarGuia");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 4).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCierreCajai", idCaja).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idGuiai", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?inicio", desde).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cantidad", cantidad).Direction = ParameterDirection.Input;

                XmlElement clientes = (XmlElement)root.AppendChild(documento.CreateElement("personas"));
                data = cmd.ExecuteReader();
                while (data.Read())
                {
                    this.llenarDatosPersona(documento, clientes, data);
                }
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                this.conf.cerrar();
            }
        }

        protected void llenarDatosPersona(XmlDocument documento, XmlElement clientes, MySqlDataReader data)
        {
            XmlElement cliente = (XmlElement)clientes.AppendChild(documento.CreateElement("persona"));
            cliente.AppendChild(documento.CreateElement("id")).InnerText = data.getStringNone("id");
            cliente.AppendChild(documento.CreateElement("ruc")).InnerText = data.getStringNone("ruc");
            cliente.AppendChild(documento.CreateElement("cedula")).InnerText = data.getStringNone("cedula");
            cliente.AppendChild(documento.CreateElement("razon_social")).InnerText = data.getStringNone("razon_social");
            cliente.AppendChild(documento.CreateElement("telefonos")).InnerText = data.getStringNone("telefonos");
            cliente.AppendChild(documento.CreateElement("direccion")).InnerText = data.getStringNone("direccion").TrimEnd(new char[] { '\r', '\n' });
            cliente.AppendChild(documento.CreateElement("tipo")).InnerText = data.getStringNone("tipo");
            cliente.AppendChild(documento.CreateElement("es_cliente")).InnerText = data.getBoolean("es_cliente").ToString();
            cliente.AppendChild(documento.CreateElement("es_empleado")).InnerText = data.getBoolean("es_empleado").ToString();
            cliente.AppendChild(documento.CreateElement("tipo_contrato")).InnerText = data.getStringNone("tipo_contrato");
            cliente.AppendChild(documento.CreateElement("sueldo")).InnerText = data.getStringNone("sueldo");
            cliente.AppendChild(documento.CreateElement("email")).InnerText = data.getStringNone("email");
            cliente.AppendChild(documento.CreateElement("es_vendedor")).InnerText = data.getBoolean("es_vendedor").ToString();
            cliente.AppendChild(documento.CreateElement("es_extranjero")).InnerText = data.getBoolean("es_extranjero").ToString();
            cliente.AppendChild(documento.CreateElement("porcentaje_descuento")).InnerText = data.getStringNone("porcentaje_descuento");
        }

        protected void generarXmlFacturas(XmlDocument documento, XmlElement root, int idCaja, int desde, int cantidad)
        {
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            try
            {
                if (this.conf == null) this.conf = new Conexion();
                cmd = this.conf.EjecutarSQL("xml_generarCierreCaja");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 3).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCierreCajai", idCaja).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idFacturaCabecerai", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?inicio", desde).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cantidad", cantidad).Direction = ParameterDirection.Input;

                XmlElement facturas = (XmlElement)root.AppendChild(documento.CreateElement("documentos"));
                data = cmd.ExecuteReader();
                decimal vuelto=0;
                while (data.Read())
                {
                    XmlElement factura = (XmlElement)facturas.AppendChild(documento.CreateElement("documento"));
                    XmlElement cabecera = (XmlElement)factura.AppendChild(documento.CreateElement("cabecera"));
                    this.llenarCabecera(cabecera, documento, data, ref vuelto);
                    int idCabecera = data.getInt("idfactura_cabecera");
                    this.llenarFacturaDetalle(documento, factura, idCabecera);
                    this.llenarFormaDePago(documento, factura, idCabecera, data.getString("estadoFactura"), vuelto, data.getBoolean("pagoParcial"),idCaja);
                }
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                this.conf.cerrar();
            }
        }

        protected void llenarCabecera(XmlElement cabecera, XmlDocument documento, MySqlDataReader data, ref decimal vuelto)
        {
            //cabecera.AppendChild(documento.CreateElement("idfactura_cabecera")).InnerText = data.getStringNone("idfactura_cabecera");
            string creacion = data.GetDateTime("fecha_creacion").ToString("yyyy-MM-dd");
            //cabecera.AppendChild(documento.CreateElement("fecha_creacion")).InnerText = data.getStringNone("fecha_creacion");
            cabecera.AppendChild(documento.CreateElement("fecha_creacion")).InnerText = creacion;
            //cabecera.AppendChild(documento.CreateElement("ultimo_cambio")).InnerText = data.getStringNone("ultimo_cambio");
            cabecera.AppendChild(documento.CreateElement("tipo_documento")).InnerText = data.getStringNone("tipoDocumento");
            cabecera.AppendChild(documento.CreateElement("documento")).InnerText = data.getStringNone("documento");
            cabecera.AppendChild(documento.CreateElement("estado")).InnerText = data.getStringNone("estadoFactura");
            cabecera.AppendChild(documento.CreateElement("idCliente")).InnerText = data.getStringNone("idCliente");
            cabecera.AppendChild(documento.CreateElement("id_vendedor")).InnerText = data.getStringNone("id_vendedor");
            cabecera.AppendChild(documento.CreateElement("idClienteContifico")).InnerText = data.getStringNone("idClienteContifico");
            cabecera.AppendChild(documento.CreateElement("idVendedorContifico")).InnerText = data.getStringNone("idVendedorContifico");
            cabecera.AppendChild(documento.CreateElement("descripcion")).InnerText = data.getStringNone("descripcion");
            cabecera.AppendChild(documento.CreateElement("total")).InnerText = data.getStringNone("total");
            cabecera.AppendChild(documento.CreateElement("autorizacion")).InnerText = data.getStringNone("autorizacion");
            cabecera.AppendChild(documento.CreateElement("subtotal_12")).InnerText = data.getStringNone("tarifa_12");
            cabecera.AppendChild(documento.CreateElement("subtotal_0")).InnerText = data.getStringNone("tarifa_0");
            cabecera.AppendChild(documento.CreateElement("iva")).InnerText = data.getStringNone("total_iva");
            cabecera.AppendChild(documento.CreateElement("ice")).InnerText = data.getStringNone("total_ice");
            cabecera.AppendChild(documento.CreateElement("servicio")).InnerText = data.getStringNone("servicio");
            cabecera.AppendChild(documento.CreateElement("imprimio")).InnerText = data.getStringNone("imprimio");
            cabecera.AppendChild(documento.CreateElement("adicional1")).InnerText = data.getStringNone("adicional1");
            cabecera.AppendChild(documento.CreateElement("adicional2")).InnerText = data.getStringNone("adicional2");
            cabecera.AppendChild(documento.CreateElement("id_pos")).InnerText = data.getStringNone("idfactura_cabecera");
            cabecera.AppendChild(documento.CreateElement("propina")).InnerText = data.getStringNone("propina");
            cabecera.AppendChild(documento.CreateElement("fecha_vencimiento")).InnerText = data.IsDBNull(data.GetOrdinal("fecha_vencimiento"))?creacion: data.GetDateTime("fecha_vencimiento").ToString("yyyy-MM-dd");
            cabecera.AppendChild(documento.CreateElement("pagoParcial")).InnerText = data.getBoolean("pagoParcial").ToString();
            vuelto = data.getDecimal("vuelto");
        }

        protected void llenarFacturaDetalle(XmlDocument documento, XmlElement root, int idFacturaCabecera)
        {
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion conexion = null;
            try
            {
                conexion = new Conexion();
                //if (this.conf == null) this.conf = new Conexion();
                cmd = conexion.EjecutarSQL("xml_generarCierreCaja");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 4).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCierreCajai", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idFacturaCabecerai", idFacturaCabecera).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?inicio", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cantidad", -1).Direction = ParameterDirection.Input;

                XmlElement detalles = (XmlElement)root.AppendChild(documento.CreateElement("detalles"));
                data = cmd.ExecuteReader();
    
                while (data.Read())
                {
                    XmlElement detalle = (XmlElement)detalles.AppendChild(documento.CreateElement("detalle"));
                    //detalle.AppendChild(documento.CreateElement("idfactura_detalle")).InnerText = data.getStringNone("idfactura_detalle");
                    //detalle.AppendChild(documento.CreateElement("fecha_creacion")).InnerText = data.getStringNone("fecha_creacion");
                    //detalle.AppendChild(documento.CreateElement("ultimo_cambio")).InnerText = data.getStringNone("ultimo_cambio");
                    //detalle.AppendChild(documento.CreateElement("idfactura_cabecera")).InnerText = data.getStringNone("idfactura_cabecera");
                    detalle.AppendChild(documento.CreateElement("total")).InnerText = data.getStringNone("total");
                    detalle.AppendChild(documento.CreateElement("id_contifico")).InnerText = data.getStringNone("id_producto");
                    detalle.AppendChild(documento.CreateElement("cantidad")).InnerText = data.getStringNone("cantidad");
                    detalle.AppendChild(documento.CreateElement("unidad_id")).InnerText = data.getStringNone("unidad_id");
                    detalle.AppendChild(documento.CreateElement("precio")).InnerText = data.getStringNone("precio");
                    detalle.AppendChild(documento.CreateElement("porcentaje_descuento")).InnerText = data.getStringNone("porc_descuento");
                    //detalle.AppendChild(documento.CreateElement("porcentaje_iva")).InnerText = data.getStringNone("porcentaje_iva");
                    detalle.AppendChild(documento.CreateElement("porcentaje_iva")).InnerText = data.getInt("porcentaje_iva").ToString();
                    //detalle.AppendChild(documento.CreateElement("porcentaje_ice")).InnerText = data.getStringNone("porcentaje_ice");
                    detalle.AppendChild(documento.CreateElement("base_cero")).InnerText = data.getStringNone("base_cero");
                    detalle.AppendChild(documento.CreateElement("base_gravable")).InnerText = data.getStringNone("base_gravable");
                    detalle.AppendChild(documento.CreateElement("base_no_gravable")).InnerText = data.getStringNone("base_no_gravable");
                    detalle.AppendChild(documento.CreateElement("ice")).InnerText = data.getStringNone("ice");
                    detalle.AppendChild(documento.CreateElement("tipo_rete_id")).InnerText = data.getStringNone("tipo_rete_id");
                    detalle.AppendChild(documento.CreateElement("descripcion")).InnerText = data.getStringNone("descripcion");
                    detalle.AppendChild(documento.CreateElement("serie")).InnerText = data.getString("serie");
                }
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                if(conexion != null)conexion.cerrar();
            }
        }

        protected void llenarFormaDePago(XmlDocument documento, XmlElement root, int idFacturaCabecera, string estado, decimal vuelto, bool pagoParcial,int idCaja)
        {
            if ((estado == "A" || (estado == "P" && !pagoParcial)))
            {
                XmlElement clientes = (XmlElement)root.AppendChild(documento.CreateElement("cobros"));
                return;
            }
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion conexion = null;
            try
            {
                conexion = new Conexion();
                cmd = conexion.EjecutarSQL("xml_generarCierreCaja");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 5).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCierreCajai", idCaja).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idFacturaCabecerai", idFacturaCabecera).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?inicio", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cantidad", -1).Direction = ParameterDirection.Input;

                XmlElement clientes = (XmlElement)root.AppendChild(documento.CreateElement("cobros"));
                data = cmd.ExecuteReader();
                decimal efectivo;
                string formaPago;
                while (data.Read())
                {
                    //cliente.AppendChild(documento.CreateElement("idforma_pagos")).InnerText = data.getStringNone("idforma_pagos");
                    //cliente.AppendChild(documento.CreateElement("id_cabecera")).InnerText = data.getStringNone("id_cabecera");
                    formaPago = data.getStringNone("forma_pago");
                    efectivo = data.getDecimal("monto_efectivo");

                    if (formaPago != "EF" || (efectivo - vuelto) > 0)
                    {

                        XmlElement cliente = (XmlElement)clientes.AppendChild(documento.CreateElement("cobro"));
                        cliente.AppendChild(documento.CreateElement("forma_cobro")).InnerText = formaPago;

                        if (formaPago == "EF")
                        {

                            cliente.AppendChild(documento.CreateElement("monto_efectivo")).InnerText = (efectivo - vuelto).ToString();
                        }
                        else
                            cliente.AppendChild(documento.CreateElement("monto_efectivo")).InnerText = data.getStringNone("monto_efectivo");

                        cliente.AppendChild(documento.CreateElement("monto_cheque")).InnerText = data.getStringNone("monto_cheque");
                        cliente.AppendChild(documento.CreateElement("monto_tarjeta")).InnerText = data.getStringNone("monto_tarjeta");
                        cliente.AppendChild(documento.CreateElement("monto_retencion")).InnerText = data.getStringNone("monto_retencion");
                        cliente.AppendChild(documento.CreateElement("numero_cheque")).InnerText = data.getStringNone("numero_cheque");
                        cliente.AppendChild(documento.CreateElement("banco")).InnerText = data.getStringNone("banco");
                        cliente.AppendChild(documento.CreateElement("numero_tarjeta")).InnerText = data.getStringNone("numero_tarjeta");
                        cliente.AppendChild(documento.CreateElement("tipo_tarjeta")).InnerText = data.getStringNone("tipo_tarjeta");
                        cliente.AppendChild(documento.CreateElement("numero_retencion")).InnerText = data.getStringNone("numero_retencion");
                        cliente.AppendChild(documento.CreateElement("tipo_ping")).InnerText = data.getStringNone("tipo_ping");

                        string creacion = data.GetDateTime("fecha_creacion").ToString("yyyy-MM-dd");
                        cliente.AppendChild(documento.CreateElement("fecha_creacion")).InnerText = creacion;
                    }
                }
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                if(conexion != null)conexion.cerrar();
            }
        }

        public static int ultimoSincronizado(ref string mensaje)
        {
            int numero = -1;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("xml_generarCierreCaja");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCierreCajai", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idFacturaCabecerai", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?inicio", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cantidad", -1).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.Read()) numero = data.getInt("maximo");
                
            }
            catch (Exception e)
            {

                mensaje = e.Message;
            }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                if (con != null) con.cerrar();
            }
            return numero;
        }

        public static bool actualizarEstadoFacturas(int idCaja)
        {
            return Sincronizacion.actualizarEstado(11, idCaja, -1, -1);
        }

        public static bool actualizarEstadoTemp(int idCaja, int inicio, int cantidad)
        {
            return Sincronizacion.actualizarEstado(10, idCaja, inicio, cantidad);
        }

        public static bool actualizarEstadoGuias(int idCaja)
        {
            return Sincronizacion.actualizarEstado(11, idCaja, -1, -1, true);
        }

        public static bool actualizarEstadoTempGuias(int idCaja, int inicio, int cantidad)
        {
            return Sincronizacion.actualizarEstado(10, idCaja, inicio, cantidad, true);
        }

        public static bool actualizarEstado(int opcion, int idCaja,int inicio,int cantidad, bool guia = false)
        {
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion con = null;
            bool estado = false;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL((guia)?"xml_generarGuia":"xml_generarCierreCaja");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", opcion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCierreCajai", idCaja).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue((guia)?"?idGuiai":"?idFacturaCabecerai", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?inicio", inicio).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cantidad", cantidad).Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();
                estado = true;

            }
            catch (Exception e){throw e;}
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                if (con != null) con.cerrar();
            }
            return estado;
        }

        public static List<int> cantidadFacturas(int idCaja)
        {
            List<int> datos = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("xml_generarCierreCaja");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 9).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCierreCajai", idCaja).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idFacturaCabecerai", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?inicio", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cantidad", -1).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.Read())
                {
                    datos = new List<int>();
                    datos.Add(data.getInt("facturas"));
                    datos.Add(data.getInt("cantidad"));
                    datos.Add(data.getInt("veces"));
                }

            }
            catch (Exception e){ throw e; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                if (con != null) con.cerrar();
            }
            return datos;
        }

        public static List<int> cantidadGuias(int idCaja)
        {
            List<int> datos = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("xml_generarGuia");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 9).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCierreCajai", idCaja).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idGuiai", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?inicio", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cantidad", -1).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.Read())
                {
                    datos = new List<int>();
                    datos.Add(data.getInt("guias"));
                    datos.Add(data.getInt("cantidad"));
                    datos.Add(data.getInt("veces"));
                }

            }
            catch (Exception e) { throw e; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                if (con != null) con.cerrar();
            }
            return datos;
        }

        public List<int> cajasPendientes()
        {
            List<int> cajas = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("xml_generarCierreCaja");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 12).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCierreCajai", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idFacturaCabecerai", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?inicio", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cantidad", -1).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    cajas = new List<int>();
                    while (data.Read())
                    {
                        cajas.Add(data.getInt("id_caja"));
                    }
                }

            }
            catch (Exception e) { throw e; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                if (con != null) con.cerrar();
            }
            return cajas;
        }

        protected void generarXmlGuiasRemision(XmlDocument documento, XmlElement root, int idCaja, int desde, int cantidad)
        {
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            try
            {
                if (this.conf == null) this.conf = new Conexion();
                cmd = this.conf.EjecutarSQL("xml_generarGuia");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("?opcion", 1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCierreCajai", idCaja).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idGuiai", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?inicio", desde).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cantidad", cantidad).Direction = ParameterDirection.Input;

                XmlElement guias = (XmlElement)root.AppendChild(documento.CreateElement("guias"));
                data = cmd.ExecuteReader();
                while (data.Read())
                {
                    XmlElement guia = (XmlElement)guias.AppendChild(documento.CreateElement("guia"));
                    XmlElement cabecera = (XmlElement)guia.AppendChild(documento.CreateElement("cabecera"));
                    XmlElement destinatarios = (XmlElement)guia.AppendChild(documento.CreateElement("destinatarios"));
                    this.llenarCabeceraGuia(cabecera, documento, data);
                    int idGuia = data.getInt("id");
                    this.llenarDestinatariosGuia(documento, destinatarios, idGuia);
                    //this.llenarFormaDePago(documento, factura, idCabecera, data.getString("estadoFactura"), vuelto, data.getBoolean("pagoParcial"), idCaja);
                }
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                this.conf.cerrar();
            }
        }

        protected void llenarCabeceraGuia(XmlElement cabecera, XmlDocument documento, MySqlDataReader data)
        {
            cabecera.AppendChild(documento.CreateElement("fecha_emision")).InnerText = data.GetDateTime("fecha_emision").ToString("yyyy-MM-dd");
            cabecera.AppendChild(documento.CreateElement("fecha_inicio")).InnerText = data.GetDateTime("fecha_inicio").ToString("yyyy-MM-dd");
            cabecera.AppendChild(documento.CreateElement("fecha_fin")).InnerText = data.GetDateTime("fecha_fin").ToString("yyyy-MM-dd");
            cabecera.AppendChild(documento.CreateElement("numero_documento")).InnerText = data.getStringNone("numero_documento");
            cabecera.AppendChild(documento.CreateElement("autorizacion")).InnerText = data.getStringNone("autorizacion");
            cabecera.AppendChild(documento.CreateElement("direccion_partida")).InnerText = data.getStringNone("direccion_partida");
            cabecera.AppendChild(documento.CreateElement("id_transportista")).InnerText = data.getStringNone("transportista_id");
            cabecera.AppendChild(documento.CreateElement("id_transportistaContifico")).InnerText = data.getStringNone("idTransportistaContifico");
            cabecera.AppendChild(documento.CreateElement("placa")).InnerText = data.getStringNone("placa");
            cabecera.AppendChild(documento.CreateElement("descripcion")).InnerText = data.getStringNone("descripcion");
            cabecera.AppendChild(documento.CreateElement("estado")).InnerText = data.getStringNone("estado");
        }

        protected void llenarDestinatariosGuia(XmlDocument documento, XmlElement root, int idFacturaCabecera)
        {
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion conexion = null;
            try
            {
                conexion = new Conexion();
                cmd = conexion.EjecutarSQL("xml_generarGuia");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 2).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCierreCajai", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idGuiai", idFacturaCabecera).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?inicio", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cantidad", -1).Direction = ParameterDirection.Input;
                data = cmd.ExecuteReader();

                while (data.Read())
                {
                    XmlElement destinatario = (XmlElement)root.AppendChild(documento.CreateElement("destinatario"));
                    XmlElement cabecera = (XmlElement)destinatario.AppendChild(documento.CreateElement("cabecera"));
                    int idDestinatario = data.getInt("id");
                    cabecera.AppendChild(documento.CreateElement("id_destinatario")).InnerText = data.getStringNone("cliente_id");
                    cabecera.AppendChild(documento.CreateElement("id_destinatarioContifico")).InnerText = data.getStringNone("id_destinatarioContifico");
                    cabecera.AppendChild(documento.CreateElement("motivo")).InnerText = data.getStringNone("motivo");
                    cabecera.AppendChild(documento.CreateElement("direccion")).InnerText = data.getStringNone("direccion");
                    cabecera.AppendChild(documento.CreateElement("numero_doc")).InnerText = data.getStringNone("documento");
                    cabecera.AppendChild(documento.CreateElement("autorizacion_doc")).InnerText = data.getStringNone("autorizacion");
                    cabecera.AppendChild(documento.CreateElement("codigo_destino")).InnerText = data.getStringNone("codigo_destino");
                    cabecera.AppendChild(documento.CreateElement("ruta")).InnerText = data.getStringNone("ruta");
                    XmlElement productos = (XmlElement)destinatario.AppendChild(documento.CreateElement("productos"));
                    this.llenarProductosGuia(documento, productos, idDestinatario);
                }
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                if (conexion != null) conexion.cerrar();
            }
        }

        protected void llenarProductosGuia(XmlDocument documento, XmlElement root, int idDesinatario)
        {
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion conexion = null;
            try
            {
                conexion = new Conexion();
                cmd = conexion.EjecutarSQL("xml_generarGuia");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 3).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCierreCajai", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idGuiai", idDesinatario).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?inicio", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cantidad", -1).Direction = ParameterDirection.Input;
                data = cmd.ExecuteReader();

                while (data.Read())
                {
                    XmlElement producto = (XmlElement)root.AppendChild(documento.CreateElement("producto"));
                    producto.AppendChild(documento.CreateElement("id")).InnerText = data.getStringNone("producto_id");
                    producto.AppendChild(documento.CreateElement("cantidad")).InnerText = data.getStringNone("cantidad");
                }
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                if (conexion != null) conexion.cerrar();
            }
        }

        public void setTextoCotrol(System.Windows.Forms.ToolStrip control, string texto)
        {
            control.BeginInvoke(
                new Action(() =>
                 {
                     control.Items[0].Text = texto;
                 }));
        }

        private Boolean ValidarCertificado(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public bool sincronizarPartes(int idCaja, System.Windows.Forms.ToolStrip control, string mensajeOmitir)
        {
            Sincronizacion.actualizarEstadoFacturas(idCaja);
            List<int> cantidad = Sincronizacion.cantidadFacturas(idCaja);
            Sincronizacion xml = new Sincronizacion();
            bool errorSincronizar = false;
            bool sincronizoCorrecto = false;
            string errores = "";

            if (cantidad[0] == 0)
            {
                Sincronizacion.actualizarEstadoInternet("C", idCaja);
                this.setTextoCotrol(control, "No hay facturas por sincronizar en esta caja.");
                return true;
            }

            for (int i = 0; i < cantidad[2]; i++)
            {
                /* 0->n°facturas
                 * 1->cantidad a sincronizar
                 * 2->n° veces a sincronizar
                 */
                int inicio = ((i * cantidad[1]) + 1);
                int fin = (inicio + cantidad[1]) - 1;
                if (fin > cantidad[0]) fin = cantidad[0];

                this.setTextoCotrol(control, "Recopilando Información Caja N°" + idCaja + " desde " + inicio + " a " + fin + " de " + cantidad[0]);
                XmlDocument documento = xml.generarXmlCierreCaja(idCaja, inicio - 1, cantidad[1], (i==cantidad[2]-1 && !errorSincronizar));
                this.setTextoCotrol(control, "Sincronizando caja N°" + idCaja + " documento " + inicio + " a " + fin + " de " + cantidad[0]);

                SincronizarVentasService servicio = new SincronizarVentasService();
                servicio.Timeout = 800000;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(ValidarCertificado);
                sincronizar_ventas parametro = new sincronizar_ventas();
                parametro.empresa = Global.idEmpresa;
                parametro.xml_ventas = General.scapeCharacters(documento.InnerXml);
                sincronizar_ventasResponse respuesta = servicio.sincronizar_ventas(parametro);
                string resultado = respuesta.sincronizar_ventasResult;
                XmlDocument resultadoXml = new XmlDocument();
                resultadoXml.LoadXml(resultado);
                XmlNode raiz = resultadoXml.GetElementsByTagName("root")[0];
                bool respuestaXml = Convert.ToBoolean(raiz["respuesta"].InnerText);
                string errorXml = raiz["error"].InnerText;
                bool errorCorrecto = (!respuestaXml && !String.IsNullOrEmpty(mensajeOmitir)) ? (errorXml.IndexOf(mensajeOmitir) >= 0) : false;

                if (respuestaXml || errorCorrecto)
                {
                    if (errorCorrecto) errores += errorXml + "\n";
                    Sincronizacion.actualizarEstadoTemp(idCaja, inicio - 1, cantidad[1]);
                    sincronizoCorrecto = true;
                }
                else
                {
                    errores += errorXml + "\n";
                    errorSincronizar = true;
                }
            }


            if (errorSincronizar && sincronizoCorrecto)
            {
                Sincronizacion.actualizarEstadoFacturas(idCaja);
                Sincronizacion.actualizarEstadoInternet("I", idCaja);
                Mail correo = new Mail();
                correo.enviarCorreoError(idCaja,errores);
                return false;
            }
            
            if (errorSincronizar)
            {
                Mail correo = new Mail();
                correo.enviarCorreoError(idCaja,errores);
                return false;
            }
            else if (sincronizoCorrecto)
            {
                Sincronizacion.actualizarEstadoInternet("C", idCaja);
                Sincronizacion.actualizarEstadoFacturas(idCaja);
                return true;
            }

            return false;
        }

        public bool sincronizarPartesGuias(int idCaja, System.Windows.Forms.ToolStrip control, string mensajeOmitir)
        {
            Sincronizacion.actualizarEstadoGuias(idCaja);
            List<int> cantidad = Sincronizacion.cantidadGuias(idCaja);
            Sincronizacion xml = new Sincronizacion();
            bool errorSincronizar = false;
            bool sincronizoCorrecto = false;
            string errores = "";

            if (cantidad[0] == 0)
            {
                Sincronizacion.actualizarEstadoInternetGuias("C", idCaja);
                this.setTextoCotrol(control, "No hay guias por sincronizar en esta caja.");
                return true;
            }

            for (int i = 0; i < cantidad[2]; i++)
            {
                /* 0->n°facturas
                 * 1->cantidad a sincronizar
                 * 2->n° veces a sincronizar
                 */
                int inicio = ((i * cantidad[1]) + 1);
                int fin = (inicio + cantidad[1]) - 1;
                if (fin > cantidad[0]) fin = cantidad[0];

                this.setTextoCotrol(control, "Recopilando Información Guías de Remisión: Caja N°" + idCaja + " desde " + inicio + " a " + fin + " de " + cantidad[0]);
                XmlDocument documento = xml.generarXmlGuias(idCaja, inicio - 1, cantidad[1], (i == cantidad[2] - 1 && !errorSincronizar));
                this.setTextoCotrol(control, "Sincronizando Guías de Remisión: caja N°" + idCaja + " documento " + inicio + " a " + fin + " de " + cantidad[0]);

                SincronizarVentasService servicio = new SincronizarVentasService();
                servicio.Timeout = 800000;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(ValidarCertificado);
                sincronizar_ventas parametro = new sincronizar_ventas();
                parametro.empresa = Global.idEmpresa;
                parametro.xml_ventas = General.scapeCharacters(documento.InnerXml);
                sincronizar_ventasResponse respuesta = servicio.sincronizar_ventas(parametro);
                string resultado = respuesta.sincronizar_ventasResult;
                XmlDocument resultadoXml = new XmlDocument();
                resultadoXml.LoadXml(resultado);
                XmlNode raiz = resultadoXml.GetElementsByTagName("root")[0];
                bool respuestaXml = Convert.ToBoolean(raiz["respuesta"].InnerText);
                string errorXml = raiz["error"].InnerText;
                bool errorCorrecto = (!respuestaXml && !String.IsNullOrEmpty(mensajeOmitir)) ? (errorXml.IndexOf(mensajeOmitir) >= 0) : false;

                if (respuestaXml || errorCorrecto)
                {
                    if (errorCorrecto) errores += errorXml + "\n";
                    Sincronizacion.actualizarEstadoTempGuias(idCaja, inicio - 1, cantidad[1]);
                    sincronizoCorrecto = true;
                }
                else
                {
                    errores += errorXml + "\n";
                    errorSincronizar = true;
                }
            }


            if (errorSincronizar && sincronizoCorrecto)
            {
                Sincronizacion.actualizarEstadoGuias(idCaja);
                Sincronizacion.actualizarEstadoInternetGuias("I", idCaja);
                Mail correo = new Mail();
                correo.enviarCorreoError(idCaja, errores);
                return false;
            }

            if (errorSincronizar)
            {
                Mail correo = new Mail();
                correo.enviarCorreoError(idCaja, errores);
                return false;
            }
            else if (sincronizoCorrecto)
            {
                Sincronizacion.actualizarEstadoInternetGuias("C", idCaja);
                Sincronizacion.actualizarEstadoGuias(idCaja);
                return true;
            }

            return false;
        }

    }
}
