using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pos.Clases;
using MySql.Data.MySqlClient;
using System.Data;
using System.Xml;
using Pos.App;
using System.Windows.Forms;

namespace Pos.Coneccion
{
    class FacturaCabeceraTR
    {
        private FacturaCabecera fac;
        private Conexion conf;

        public FacturaCabeceraTR()
        {
            this.conf = new Conexion();
        }

        public FacturaCabeceraTR(FacturaCabecera factura)
        {
            this.conf = new Conexion();
            this.fac = factura;
        }

#region GuardarFactura

        public bool guardarFactura(FacturaCabecera cabecera, List<FacturaDetalle> listaDetalles, List<FormaPago> listaPagos)
        {
            string lineaConexion = Conexion.lineaConexion;
            MySqlConnection conexion = null;
            MySqlTransaction tran =null;
            MySqlCommand cmd = null;
            bool estado = false;
            try
            {
                conexion = new MySqlConnection(lineaConexion);
                conexion.Open();
                tran = conexion.BeginTransaction();
                cmd = new MySqlCommand("factura_insertarCabecera", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Transaction = tran;
                this.insertarCabecera(cmd, cabecera, 1);

                cmd.CommandText = "factura_adicionales";
                this.insertarAdicionales(cmd, cabecera.Adicionales, cabecera.Id);

                cmd.CommandText = "factura_insertarDetalle";
                this.insertarDetalle(cmd, listaDetalles, cabecera,0);

                if (listaPagos != null)
                {
                    cmd.CommandText = "insertar_pagos";
                    this.insertarPagos(cmd, listaPagos, cabecera.Id);
                }

                tran.Commit();
                //tran.Rollback();
                conexion.Close();
                estado = true;
            }
            catch (Exception e)
            {
                tran.Rollback();
                throw e;
            }
            finally {
                conexion.Close();
                if (cmd != null) cmd.Dispose();
            }
            return estado;
        }

        public bool insertarCabecera(MySqlCommand cmd, FacturaCabecera factura, int opcion)
        {
            bool resultado = false;

            cmd.Parameters.AddWithValue("?opcion", opcion).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?id_confPosi", factura.IdConfPos).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?idClientei", factura.IdCliente).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?id_vendedori", factura.IdVendedor).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?autorizacioni", factura.Autorizacion).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?id_tipoDocumentoi", factura.Id_tipoDocumento).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?numero_documentoi", factura.Numero_actual).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?fecha_creacioni", DateTime.Now).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?fecha_vencimientoi", factura.Fecha_vencimiento).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?documentoi", factura.Numero_documento).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?descuentoi", factura.Descuento).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?servicioi", factura.Servicio).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?tarifa_0i", factura.Tarifa_0).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?tarifa_12i", factura.Tarifa_12).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?total_icei", factura.Total_ice).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?total_ivai", factura.Total_iva).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?totali", factura.Total).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?descripcioni", factura.Descripcion).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?estadoi", factura.Estado).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?empresa_idi", factura.Empresa_id).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?establecimiento_idi", factura.Establecimiento_id).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?imprimioi", factura.Imprimo).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?idCajai", factura.IdCaja).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?descuento_facturai", factura.DescuentoFactura).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?descuento_clientei", factura.DescuentoCliente).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?tipoDocumentoi", factura.Tipo).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?vueltoi", factura.Vuelto).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?idFacturai", factura.Id).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?idCajeroi", factura.IdCajero).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?adicional1i", (factura.Adicionales == null) ? "" : factura.Adicionales[0].valor).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?adicional2i", (factura.Adicionales == null || factura.Adicionales.Count < 2) ? "" : factura.Adicionales[1].valor).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?propinai", factura.Propina).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?id_usuarioAnulari", factura.IdUsuarioAnular).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?pagoParciali", factura.PagoParcial).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?idFactura", MySqlDbType.Int32).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            if (opcion == 1 && !String.IsNullOrEmpty(cmd.Parameters["?idFactura"].Value.ToString()))
            {
                factura.Id = (int)cmd.Parameters["?idFactura"].Value;
                resultado = true;
            }

            cmd.Parameters.Clear();
            return resultado;
        }

        public void insertarAdicionales(MySqlCommand cmd, List<adicionalFactura> listaAdicionales, int idCabecera)
        {
            if (listaAdicionales != null)
            {
                foreach (adicionalFactura adicional in listaAdicionales)
                {
                    cmd.Parameters.AddWithValue("?opcion", 2).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("?idFacturai", idCabecera).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("?idAdicionali", adicional.idAdicional).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("?valori", adicional.valor).Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }

        public void insertarDetalle(MySqlCommand cmd, List<FacturaDetalle> listaDetalles, FacturaCabecera cabecera, int almacenar)
        {

            foreach (FacturaDetalle detalle in listaDetalles)
            {

                cmd.Parameters.AddWithValue("?idfactura_cabecerai", cabecera.Id).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?id_productoi", detalle.Id_producto).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cantidadi", detalle.Cantidad).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?porc_descuentoi", detalle.Porc_descuento).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?valor_descuentoi", detalle.Valor_descuento).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?totali", detalle.Total).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?precioi", detalle.Precio).Direction = ParameterDirection.Input;
                //cmd.Parameters.AddWithValue("?unidad_idi", detalle.Unidad_id);
                //cmd.Parameters["?unidad_idi"].Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?base_ceroi", detalle.Base_cero).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?base_gravablei", detalle.Base_gravable).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?base_no_gravablei", detalle.Base_nogravable).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?icei", detalle.Ice).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?tipo_rete_idi", detalle.Tipo_reteid).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?pvp_ventai", detalle.Pvp_venta).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?porcentaje_ivai", detalle.Porc_Iva).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?porcentaje_icei", detalle.Porc_Ice).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idDetallei", detalle.Idfactura_detalle).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?almacenar", almacenar).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?id_cajai", cabecera.IdCaja).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?descripcioni", detalle.Descripcion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?id_seriei", detalle.Id_Serie).Direction = ParameterDirection.Input;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
        }

        public void insertarPagos(MySqlCommand cmd, List<FormaPago> listaPagos, int idCabecera)
        {

            foreach (FormaPago pago in listaPagos)
            {
                if (pago.Id_cabecera == 0)
                {
                    cmd.Parameters.AddWithValue("?id_cabecerai", idCabecera).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("?monto_efectivoi", pago.Monto_efectivo).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("?monto_chequei", pago.Monto_cheque).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("?monto_tarjetai", pago.Monto_tarjeta).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("?numero_chequei", pago.Numero_cheque).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("?bancoi", pago.Banco).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("?numero_tarjetai", pago.Numero_tarjeta).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("?tipo_tarjetai", pago.Tipo_tarjeta).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("?forma_pagoi", pago.Forma_pago).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("?numero_retencioni", pago.Numero_retencion).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("?tipo_pingi", pago.Tipo_ping).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("?monto_retencioni", pago.Monto_retencion).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("?numero_notai", pago.Numero_Nota).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("?monto_notai", pago.Monto_nota).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("?id_cajai", pago.Id_Caja).Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("?idPago", MySqlDbType.Int32);
                    cmd.Parameters["?idPago"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }


#endregion

#region actualizarFactura

        public bool actualizarFactura(FacturaCabecera cabecera, List<FacturaDetalle> listaDetalles, List<FormaPago> listaPagos, int idCabecera = -1, List<FormaPago> pagosEliminados = null, string estadoFactura = "P")
        {
            string lineaConexion = Conexion.lineaConexion;
            MySqlConnection conexion = null;
            MySqlTransaction tran = null;
            MySqlCommand cmd = null;
            bool estado = false;
            try
            {
                conexion = new MySqlConnection(lineaConexion);
                conexion.Open();
                tran = conexion.BeginTransaction();
                cmd = new MySqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Transaction = tran;
             

                if (cabecera != null && listaDetalles != null)
                {
                    cmd.CommandText = "factura_insertarCabecera";
                    this.insertarCabecera(cmd, cabecera, 2);

                    cmd.CommandText = "factura_adicionales";
                    this.eliminarAdicionales(cmd, cabecera.Id);

                    cmd.CommandText = "factura_adicionales";
                    this.insertarAdicionales(cmd, cabecera.Adicionales, cabecera.Id);

                    cmd.CommandText = "factura_insertarDetalle";
                    this.insertarDetalle(cmd, listaDetalles, cabecera, 1);

                    cmd.CommandText = "factura_eliminarProductos";
                    cmd.Parameters.AddWithValue("?idfactura_cabecerai", cabecera.Id);
                    cmd.Parameters["?idfactura_cabecerai"].Direction = ParameterDirection.Input;
                    cmd.ExecuteNonQuery();

                    if (pagosEliminados != null)
                    {
                        cmd.CommandText = "formapago_eliminar";
                        this.eliminarPagos(cmd,pagosEliminados);
                    }

                }
                if (listaPagos != null)
                {
                    cmd.CommandText = "insertar_pagos";
                    this.insertarPagos(cmd, listaPagos, (cabecera!=null)?cabecera.Id:idCabecera);
                }

                if (cabecera == null)
                {
                    cmd.CommandText = "factura_actualizar";
                    cmd.Parameters.AddWithValue("?opcion", 3).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("?idFacturai", idCabecera).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("?estadoi", estadoFactura).Direction = ParameterDirection.Input;
                    cmd.ExecuteNonQuery();
                }
                //cmd.CommandText = "FormaPago_actualizar";
                //this.insertarPagos(cmd, listaPagos, cabecera.Idfactura_cabecera);

                tran.Commit();
                //tran.Rollback();
                conexion.Close();
                estado = true;
            }
            catch (Exception e)
            {
                tran.Rollback();
                throw e;
            }
            finally
            {
                conexion.Close();
                if (cmd != null) cmd.Dispose();
            }
            return estado;
        }

        public void eliminarAdicionales(MySqlCommand cmd, int idCabecera)
        {
            cmd.Parameters.AddWithValue("?opcion", 3).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?idFacturai", idCabecera).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?idAdicionali", -1).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?valori", String.Empty).Direction = ParameterDirection.Input;

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public void eliminarPagos(MySqlCommand cmd, List<FormaPago> pagos)
        {
            foreach (FormaPago pago in pagos)
            {
                cmd.Parameters.AddWithValue("?idFormaPago", pago.Idforma_pagos).Direction = ParameterDirection.Input;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
        }
#endregion

        public static bool secuenciaCorrecta(ref string mensaje, int numero,int idFactura, string tipoDocumento, string autorizacion)
        {
            Conexion con = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            int cantidad = -1;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("factura_validarSecuencia");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?numeroi", numero);
                cmd.Parameters["?numeroi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?idFacturaActual", idFactura);
                cmd.Parameters["?idFacturaActual"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?tipoi", tipoDocumento);
                cmd.Parameters["?tipoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?autorizacioni", autorizacion);
                cmd.Parameters["?autorizacioni"].Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.Read()) { cantidad = data.GetInt32(0); }
            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                if(con!=null)con.cerrar();
            }
            return (cantidad == 0);
        }

        public int consultar_numeroActual(ref string mensaje)
        {
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            int numero = -1;
            try
            {
                cmd = this.conf.EjecutarSQL("factura_consultarNumero");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                
                data = cmd.ExecuteReader();
                if (data.Read()){ numero = data.GetInt32(0);}
            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                this.conf.cerrar();
            }
            return numero;
        }

        public DataTable consultarFacturas(ref string mensaje, DateTime desde, DateTime hasta, string estado, string filtro)
        {
            MySqlCommand cmd;
            DataSet datos = null;
            DataTable resultado = null;
            MySqlDataAdapter adapter = null;
            try
            {
                cmd = this.conf.EjecutarSQL("factura_consultarCabecera");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 2).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCabecera", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?fechaDesde", desde).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?fechaHasta", hasta).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?estadoi", estado).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?filtro", String.IsNullOrEmpty(filtro) ? null : filtro).Direction = ParameterDirection.Input;

                adapter = new MySqlDataAdapter(cmd);
                datos = new DataSet();
                adapter.Fill(datos, "facturas");
                resultado = datos.Tables["facturas"];
            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                conf.cerrar();
                if (adapter != null) adapter.Dispose();
            }
            return resultado;
        }
   
        public static FacturaCabecera consultarFactura(int idFactura)
        {
            FacturaCabecera factura = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion con = null;

            try
            {

                con = new Conexion();
                cmd = con.EjecutarSQL("factura_consultarCabecera");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCabecera", idFactura).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?fechaDesde", null).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?fechaHasta", null).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?estadoi", String.Empty).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?filtro", null).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.Read())
                {
                    factura = new FacturaCabecera();
                    factura.Id = (!data.IsDBNull(data.GetOrdinal("idfactura_cabecera"))) ? data.GetInt32("idfactura_cabecera") : -1;
                    factura.IdConfPos = (!data.IsDBNull(data.GetOrdinal("id_confPos"))) ? data.GetInt32("id_confPos") : -1;
                    factura.IdCliente = (!data.IsDBNull(data.GetOrdinal("idCliente"))) ? data.GetInt32("idCliente") : -1;
                    factura.IdVendedor = (!data.IsDBNull(data.GetOrdinal("id_vendedor"))) ? data.GetInt32("id_vendedor") : -1;
                    factura.Id_tipoDocumento = (!data.IsDBNull(data.GetOrdinal("id_tipoDocumento"))) ? data.GetInt32("id_tipoDocumento") : -1;
                    factura.Numero_actual = (!data.IsDBNull(data.GetOrdinal("numero_documento"))) ? data.GetInt32("numero_documento") : 0;
                    factura.Fecha_creacion = (!data.IsDBNull(data.GetOrdinal("fecha_creacion"))) ? data.GetDateTime("fecha_creacion") : DateTime.Now;

                    factura.Numero_documento = (!data.IsDBNull(data.GetOrdinal("documento"))) ? data.GetString("documento") : "";
                    factura.Descuento = (!data.IsDBNull(data.GetOrdinal("descuento"))) ? data.GetDecimal("descuento") : 0;
                    factura.Servicio = (!data.IsDBNull(data.GetOrdinal("servicio"))) ? data.GetDecimal("servicio") : 0;
                    factura.Tarifa_0 = (!data.IsDBNull(data.GetOrdinal("tarifa_0"))) ? data.GetDecimal("tarifa_0") : 0;
                    factura.Tarifa_12 = (!data.IsDBNull(data.GetOrdinal("tarifa_12"))) ? data.GetDecimal("tarifa_12") : 0;
                    factura.Total_ice = (!data.IsDBNull(data.GetOrdinal("total_ice"))) ? data.GetDecimal("total_ice") : 0;
                    factura.Total_iva = (!data.IsDBNull(data.GetOrdinal("total_iva"))) ? data.GetDecimal("total_iva") : 0;
                    factura.Total = (!data.IsDBNull(data.GetOrdinal("total"))) ? data.GetDecimal("total") : 0;
                    factura.Descripcion = (!data.IsDBNull(data.GetOrdinal("descripcion"))) ? data.GetString("descripcion") : "";
                    factura.Estado = (!data.IsDBNull(data.GetOrdinal("estado"))) ? data.GetString("estado") : "";
                    factura.Empresa_id = (!data.IsDBNull(data.GetOrdinal("empresa_id"))) ? data.GetInt32("empresa_id") : -1;
                    factura.Establecimiento_id = (!data.IsDBNull(data.GetOrdinal("establecimiento_id"))) ? data.GetInt32("establecimiento_id") : -1;
                    //factura.Subio = (!data.IsDBNull(data.GetOrdinal("subio"))) ? data.GetInt32("subio") : 0;
                    factura.Imprimo = (!data.IsDBNull(data.GetOrdinal("imprimio"))) ? data.GetBoolean("imprimio") : false;
                    factura.Vuelto = (!data.IsDBNull(data.GetOrdinal("vuelto"))) ? data.GetDecimal("vuelto") : 0;
                    factura.IdCaja = (!data.IsDBNull(data.GetOrdinal("id_caja"))) ? data.GetInt32("id_caja") : -1;
                    factura.IdCajero = (!data.IsDBNull(data.GetOrdinal("id_cajero"))) ? data.GetInt32("id_cajero") : -1;
                    factura.Propina = (!data.IsDBNull(data.GetOrdinal("propina"))) ? data.GetDecimal("propina") : 0;
                    factura.Fecha_vencimiento = (!data.IsDBNull(data.GetOrdinal("fecha_vencimiento"))) ? data.GetDateTime("fecha_vencimiento") : factura.Fecha_creacion;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                if (con != null) con.cerrar();
            }
 
            return factura;
        }

        public static List<adicionalFactura> consultarAdicionales(int idFactura)
        {
            List<adicionalFactura> adicionales = null;
            Conexion con = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("factura_adicionales");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idFacturai", idFactura).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idAdicionali", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?valori", String.Empty).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    adicionales = new List<adicionalFactura>();
                    while (data.Read())
                    {
                        adicionalFactura adicional = new adicionalFactura();
                        adicional.idAdicional = data.GetInt32("idAdicional");
                        adicional.valor = data.getString("valor");
                        adicionales.Add(adicional);
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

            return adicionales;
        }

        public static List<object[]> consultarFacturasPendientes(int adicional)
        {
            List<object[]> facturas = null;
            Conexion con = new Conexion();
            MySqlCommand cmd = con.EjecutarSQL("factura_consultarCabecera");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("?opcion", 3).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?idCabecera", adicional).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?fechaDesde", null).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?fechaHasta", null).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?estadoi", String.Empty).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?filtro", null).Direction = ParameterDirection.Input;

            MySqlDataReader data = cmd.ExecuteReader();
            if (data.HasRows)
            {
                facturas = new List<object[]>();
                while (data.Read())
                { 
                    Object[] datos= new Object[3];
                    datos[0] = data.GetInt32(0);
                    datos[1] = data.getString(1);
                    datos[2] = data.getString(2);
                    facturas.Add(datos);
                }
            }

            con.cerrar();
            return facturas;
        }

        public static bool anularFactrura(ref string mensaje, int idFactura, int? id_usuarioAnular = null)
        {

            bool resultado = false;
            MySqlCommand cmd = null;
            Conexion conf = null;
            try
            {
                conf = new Conexion();
                cmd = conf.EjecutarSQL("factura_anular");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?idFactura", idFactura).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?id_usuarioAnulari", id_usuarioAnular).Direction = ParameterDirection.Input;

                cmd.Parameters.Add(new MySqlParameter("?msn", MySqlDbType.VarChar));
                cmd.Parameters["?msn"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                mensaje = cmd.Parameters["?msn"].Value.ToString();
                if (String.IsNullOrEmpty(mensaje)) resultado = true;
            }
            catch (Exception e) { mensaje = e.Message; }
            finally {
                if (cmd != null) cmd.Dispose();
                conf.cerrar(); 
            }
            return resultado;

        }

        public static bool setFacturaImpresa(int idFactura)
        {

            bool resultado = false;
            MySqlCommand cmd = null;
            Conexion conf = null;
            try
            {
                conf = new Conexion();
                cmd = conf.EjecutarSQL("factura_actualizar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idFacturai", idFactura).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?estadoi", null).Direction = ParameterDirection.Input;
                cmd.ExecuteNonQuery();
                resultado = true;
                //mensaje = cmd.Parameters["?msn"].Value.ToString();
                //if (String.IsNullOrEmpty(mensaje)) resultado = true;
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (cmd != null) cmd.Dispose();
                conf.cerrar();
            }
            return resultado;

        }
    }
}
