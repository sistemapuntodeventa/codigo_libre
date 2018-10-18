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

        public XmlDocument generarXmlCierreCaja(int idCaja)
        {
            try
            {

                XmlDocument documento = new XmlDocument();
                XmlElement root = (XmlElement)documento.AppendChild(documento.CreateElement("root"));
                 this.generarConfiguracion(documento, root, idCaja);
                 this.generarIdBodega(documento, root);
                 //XmlElement cajas = (XmlElement)root.AppendChild(documento.CreateElement("cajas"));
                 this.obtenerDatosCaja(documento, root, idCaja);
                // this.obtenerDatosCaja(ref mensaje, documento, cajas, idCaja, "Cierre");
                 this.obtenerClientes(documento, root, idCaja);
                 this.generarXmlFacturas(documento, root, idCaja);
               //documento.Save("c:\\Punto de Venta\\data.xml");
                // documento.Save("c:\\Punto de Venta\\CierreCaja_" + DateTime.Now.ToShortDateString().Replace("/", "") + "_" + nuevoNumero + ".xml");

                 // Create an XML declaration. 
                 /*XmlDeclaration xmldecl;
                 xmldecl = documento.CreateXmlDeclaration("1.0", null, null);
                 xmldecl.Encoding = "UTF-8";
                 //xmldecl.Standalone = "yes";
                 documento.InsertBefore(xmldecl, root);*/

                 return documento;
            }
            catch (Exception e)
            {
                throw e;
                //return false;
            }
        }

        public static bool actualizarEstadoUsb(ref string mensaje, int idCaja, int idEmpleado)
        {
            bool resultado = false;
            MySqlCommand cmd = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("caja_actualizarEstado");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 1);
                cmd.Parameters["?opcion"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?idCajai", idCaja);
                cmd.Parameters["?idCajai"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?idEmpleadoi", idEmpleado);
                cmd.Parameters["?idEmpleadoi"].Direction = ParameterDirection.Input;

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

        public static bool actualizarEstadoInternet(ref string mensaje, int idCaja, int idEmpleado)
        {
            bool resultado = false;
            MySqlCommand cmd = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("caja_actualizarEstado");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 2);
                cmd.Parameters["?opcion"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?idCajai", idCaja);
                cmd.Parameters["?idCajai"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?idEmpleadoi", idEmpleado);
                cmd.Parameters["?idEmpleadoi"].Direction = ParameterDirection.Input;

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

        protected void generarIdBodega(XmlDocument documento, XmlElement root)
        {
            string msn = "";
            int idBodega = EmpresaTR.obtenerIdBodega(ref msn);
            root.AppendChild(documento.CreateElement("idBodega")).InnerText = idBodega.ToString();
        }

        protected void generarConfiguracion(XmlDocument documento, XmlElement root, int idCaja)
        {
            //string valorConfiguracion = Global.idEmpresa.ToString() + DateTime.Now.ToShortDateString().Replace("/", "") + nuevoNumero;
            string valorConfiguracion = Global.idEmpresa.ToString() + DateTime.Now.ToShortDateString().Replace("/", "");
            root.AppendChild(documento.CreateElement("config")).InnerText = valorConfiguracion;
            /*
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            try
            {

                cmd = this.conf.EjecutarSQL("xml_generarCierreCaja");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 8);
                cmd.Parameters["?opcion"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?idCierreCajai", -1);
                cmd.Parameters["?idCierreCajai"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?idFacturaCabecerai", -1);
                cmd.Parameters["?idFacturaCabecerai"].Direction = ParameterDirection.Input;

                //XmlElement clientes = (XmlElement)root.AppendChild(documento.CreateElement("cajas"));
                XmlElement configuracion = (XmlElement)root.AppendChild(documento.CreateElement("configuracion"));
                data = cmd.ExecuteReader();
                if (data.Read())
                {
                    configuracion.AppendChild(documento.CreateElement("id_empresa")).InnerText = data.getStringNone("idtbl_empresa");
                    configuracion.AppendChild(documento.CreateElement("id_bodega")).InnerText = data.getStringNone("bodega");
                    configuracion.AppendChild(documento.CreateElement("clave_generada")).InnerText = data.getStringNone("clave_generada");
                    configuracion.AppendChild(documento.CreateElement("id_cuentaCaja")).InnerText = data.getStringNone("id_cuentaCaja");
                    configuracion.AppendChild(documento.CreateElement("id_cuentaXCobrar")).InnerText = data.getStringNone("id_cuentaXCobrar");
                    configuracion.AppendChild(documento.CreateElement("id_cuentaDatafast")).InnerText = data.getStringNone("id_cuentaDatafast");
                    configuracion.AppendChild(documento.CreateElement("id_cuentaMedianet")).InnerText = data.getStringNone("id_cuentaMedianet");
                    configuracion.AppendChild(documento.CreateElement("id_cuentaRedApoyo")).InnerText = data.getStringNone("id_cuentaRedApoyo");
                }
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                this.conf.cerrar();
            }*/
        }

        protected void obtenerDatosCaja(XmlDocument documento, XmlElement root, int idCaja)
        {
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            try
            {

                cmd = this.conf.EjecutarSQL("xml_generarCierreCaja");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 7);
                cmd.Parameters["?opcion"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?idCierreCajai", idCaja);
                cmd.Parameters["?idCierreCajai"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?idFacturaCabecerai", -1);
                cmd.Parameters["?idFacturaCabecerai"].Direction = ParameterDirection.Input;

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

        protected void obtenerClientes( XmlDocument documento, XmlElement root, int idCaja)
        { 
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            try
            {

                cmd = this.conf.EjecutarSQL("xml_generarCierreCaja");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 2);
                cmd.Parameters["?opcion"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?idCierreCajai", idCaja);
                cmd.Parameters["?idCierreCajai"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?idFacturaCabecerai", -1);
                cmd.Parameters["?idFacturaCabecerai"].Direction = ParameterDirection.Input;

                XmlElement clientes = (XmlElement)root.AppendChild(documento.CreateElement("personas"));
                data = cmd.ExecuteReader();
                while(data.Read())
                {
                    XmlElement cliente = (XmlElement)clientes.AppendChild(documento.CreateElement("persona"));
                    cliente.AppendChild(documento.CreateElement("id")).InnerText = data.getStringNone("id");
                    //cliente.AppendChild(documento.CreateElement("fecha_creacion").AppendChild(documento.CreateCDataSection(data.getStringNone("fecha_creacion"))));
                    //cliente.AppendChild(documento.CreateElement("fecha_creacion")).InnerText = data.getStringNone("fecha_creacion");
                    //cliente.AppendChild(documento.CreateElement("ultimo_cambio")).InnerText = data.getStringNone("ultimo_cambio");
                    //cliente.AppendChild(documento.CreateElement("ultimo_cambio").AppendChild(documento.CreateCDataSection(data.getStringNone("ultimo_cambio"))));
                    cliente.AppendChild(documento.CreateElement("ruc")).InnerText = data.getStringNone("ruc");
                    cliente.AppendChild(documento.CreateElement("cedula")).InnerText = data.getStringNone("cedula");
                    cliente.AppendChild(documento.CreateElement("razon_social")).InnerText = data.getStringNone("razon_social");
                    cliente.AppendChild(documento.CreateElement("telefonos")).InnerText = data.getStringNone("telefonos");
                    cliente.AppendChild(documento.CreateElement("direccion")).InnerText = data.getStringNone("direccion");
                    cliente.AppendChild(documento.CreateElement("tipo")).InnerText = data.getStringNone("tipo");
                    cliente.AppendChild(documento.CreateElement("es_cliente")).InnerText = data.getStringNone("es_cliente");
                    cliente.AppendChild(documento.CreateElement("es_empleado")).InnerText = data.getStringNone("es_empleado");
                    cliente.AppendChild(documento.CreateElement("tipo_contrato")).InnerText = data.getStringNone("tipo_contrato");
                    cliente.AppendChild(documento.CreateElement("sueldo")).InnerText = data.getStringNone("sueldo");
                    cliente.AppendChild(documento.CreateElement("email")).InnerText = data.getStringNone("email");
                    cliente.AppendChild(documento.CreateElement("es_vendedor")).InnerText = data.getStringNone("es_vendedor");
                    cliente.AppendChild(documento.CreateElement("es_extranjero")).InnerText = data.getStringNone("es_extranjero");
                    //cliente.AppendChild(documento.CreateElement("id_contifico")).InnerText = data.getStringNone("id_contifico");
                    cliente.AppendChild(documento.CreateElement("porcentaje_descuento")).InnerText = data.getStringNone("porcentaje_descuento");
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

        protected void generarXmlFacturas(XmlDocument documento, XmlElement root, int idCaja)
        {
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            try
            {
                if (this.conf == null) this.conf = new Conexion();
                cmd = this.conf.EjecutarSQL("xml_generarCierreCaja");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 3);
                cmd.Parameters["?opcion"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?idCierreCajai", idCaja);
                cmd.Parameters["?idCierreCajai"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?idFacturaCabecerai", -1);
                cmd.Parameters["?idFacturaCabecerai"].Direction = ParameterDirection.Input;

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
                    this.llenarFormaDePago(documento, factura, idCabecera, data.getString("estado"),vuelto);
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
            
            //cabecera.AppendChild(documento.CreateElement("fecha_creacion")).InnerText = data.getStringNone("fecha_creacion");
            cabecera.AppendChild(documento.CreateElement("fecha_creacion")).InnerText = data.GetDateTime("fecha_creacion").ToString("yyyy-MM-dd");
            //cabecera.AppendChild(documento.CreateElement("ultimo_cambio")).InnerText = data.getStringNone("ultimo_cambio");
            cabecera.AppendChild(documento.CreateElement("tipo_documento")).InnerText = data.getStringNone("tipoDocumento");
            cabecera.AppendChild(documento.CreateElement("documento")).InnerText = data.getStringNone("documento");
            cabecera.AppendChild(documento.CreateElement("estado")).InnerText = data.getStringNone("estado");
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
            cabecera.AppendChild(documento.CreateElement("propina")).InnerText = data.getStringNone("propina");
            cabecera.AppendChild(documento.CreateElement("imprimio")).InnerText = data.getStringNone("imprimio");
            cabecera.AppendChild(documento.CreateElement("adicional1")).InnerText = data.getStringNone("adicional1");
            cabecera.AppendChild(documento.CreateElement("adicional2")).InnerText = data.getStringNone("adicional2");
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

                cmd.Parameters.AddWithValue("?opcion", 4);
                cmd.Parameters["?opcion"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?idCierreCajai", -1);
                cmd.Parameters["?idCierreCajai"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?idFacturaCabecerai", idFacturaCabecera);
                cmd.Parameters["?idFacturaCabecerai"].Direction = ParameterDirection.Input;

                XmlElement detalles = (XmlElement)root.AppendChild(documento.CreateElement("detalles"));
                data = cmd.ExecuteReader();
    
                while (data.Read())
                {
                    XmlElement detalle = (XmlElement)detalles.AppendChild(documento.CreateElement("detalle"));
                    //detalle.AppendChild(documento.CreateElement("idfactura_detalle")).InnerText = data.getStringNone("idfactura_detalle");
                    //detalle.AppendChild(documento.CreateElement("fecha_creacion")).InnerText = data.getStringNone("fecha_creacion");
                    //detalle.AppendChild(documento.CreateElement("ultimo_cambio")).InnerText = data.getStringNone("ultimo_cambio");
                    //detalle.AppendChild(documento.CreateElement("idfactura_cabecera")).InnerText = data.getStringNone("idfactura_cabecera");
                    //detalle.AppendChild(documento.CreateElement("total")).InnerText = data.getStringNone("total");
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
                    //detalle.AppendChild(documento.CreateElement("tipo_rete_id")).InnerText = data.getStringNone("tipo_rete_id");
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

        protected void llenarFormaDePago(XmlDocument documento, XmlElement root, int idFacturaCabecera, string estado, decimal vuelto)
        {
            if (estado == "A")
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

                cmd.Parameters.AddWithValue("?opcion", 5);
                cmd.Parameters["?opcion"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?idCierreCajai", -1);
                cmd.Parameters["?idCierreCajai"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?idFacturaCabecerai", idFacturaCabecera);
                cmd.Parameters["?idFacturaCabecerai"].Direction = ParameterDirection.Input;

                XmlElement clientes = (XmlElement)root.AppendChild(documento.CreateElement("cobros"));
                data = cmd.ExecuteReader();
                decimal efectivo;
                string formaPago;
                while (data.Read())
                {
                    XmlElement cliente = (XmlElement)clientes.AppendChild(documento.CreateElement("cobro"));
                    //cliente.AppendChild(documento.CreateElement("idforma_pagos")).InnerText = data.getStringNone("idforma_pagos");
                    //cliente.AppendChild(documento.CreateElement("id_cabecera")).InnerText = data.getStringNone("id_cabecera");

                    formaPago = data.getStringNone("forma_pago");
                    cliente.AppendChild(documento.CreateElement("forma_cobro")).InnerText = formaPago;

                    if (formaPago == "EF")
                    {
                        efectivo = data.getDecimal("monto_efectivo");
                        cliente.AppendChild(documento.CreateElement("monto_efectivo")).InnerText = (efectivo  - vuelto).ToString();
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

                cmd.Parameters.AddWithValue("?opcion", 1);
                cmd.Parameters["?opcion"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?idCierreCajai", -1);
                cmd.Parameters["?idCierreCajai"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?idFacturaCabecerai", -1);
                cmd.Parameters["?idFacturaCabecerai"].Direction = ParameterDirection.Input;

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
    }
}
