using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pos.Clases;
using MySql.Data.MySqlClient;
using System.Data;

namespace Pos.Coneccion
{
    public class CajaTR
    {
        private Conexion conf;
        private Caja caja;

        public CajaTR()
        {
            this.conf = new Conexion();
        }

        public CajaTR(Caja caja)
        {
            this.caja = caja;
            this.conf = new Conexion();
        }
        public void refrescar()
        {
            if (this.conf == null) this.conf = new Conexion();
        }

        public Conexion Conf
        {
            get { return conf; }
            set { conf = value; }
        }

        public Caja AperturarCerrar
        {
            get { return caja; }
            set { caja = value; }
        }

        public Caja consultarXId(ref string mensaje, int idCaja)
        {
            Caja caja = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            try
            {
                cmd = this.conf.EjecutarSQL("caja_Consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 4).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idconfPos", idCaja).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?fechaDesde", null).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?fechaHasta", null).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?accion", null).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?estadoi", null).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.Read())
                {
                    caja = new Caja();
                    caja.Id = data.GetInt32("id_caja");
                    caja.Fecha_hora = data.GetDateTime("fecha_cierre");
                    caja.Monto_incial = data.GetDecimal("monto_inicial");
                    caja.Efectivo = data.GetDecimal("efectivo"); 
                    caja.Cheque = data.GetDecimal("cheque");
                    caja.Tarjeta = data.GetDecimal("tarjeta");
                    caja.Codigo_secuencial = data.GetInt32("secuencial");
                    caja.Retencion = data.GetDecimal("retencion");
                    caja.Total_facturado = data.GetDecimal("total_facturado");
                    caja.Total_cobro = data.GetDecimal("total_cobrado");
                    caja.Saldo_final = data.GetDecimal("saldo_final");
                    if (!data.IsDBNull(data.GetOrdinal("lote_datafast")) && !String.IsNullOrEmpty(data.GetValue(data.GetOrdinal("lote_datafast")).ToString())) caja.Datafast = data.GetInt32("lote_datafast");
                    else caja.Datafast = 0;
                    if (!data.IsDBNull(data.GetOrdinal("lote_medianet")) && !String.IsNullOrEmpty(data.GetValue(data.GetOrdinal("lote_medianet")).ToString())) caja.Medianet = data.GetInt32("lote_medianet");
                    else caja.Medianet = 0;
                    if (!data.IsDBNull(data.GetOrdinal("lote_redApoyo")) && !String.IsNullOrEmpty(data.GetValue(data.GetOrdinal("lote_redApoyo")).ToString())) caja.RedApoyo = data.GetInt32("lote_redApoyo");
                    else caja.RedApoyo = 0;
                    caja.Efectivo_Manual = data.getDecimal("efectivo_manual");
                    caja.Cheque_Manual = data.getDecimal("cheque_manual");
                }
            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                this.conf.cerrar();
            }
            return caja;
        }

        public static bool actualizarEdicion(int idCaja, DateTime edicion)
        {
            bool resultado = false;
            Conexion conf = new Conexion();
            MySqlCommand cmd = null;
            try
            {
                cmd = conf.EjecutarSQL("caja_edicion");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?idCajai",idCaja).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?edicioni", edicion.Date).Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (cmd != null) cmd.Dispose();
                conf.cerrar();
            }
            return resultado;
        }

        public static List<String[]> consultarProductos(int idCaja)
        {
            List<String[]> productos = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("caja_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 6).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idconfPos", idCaja).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?accion", null).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?fechaDesde", null).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?fechaHasta", null).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?estadoi", null).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    productos = new List<string[]>();
                    while(data.Read())
                    {
                        String[] dato = new String[3];
                        dato[0] = data.getString("codigo");
                        dato[1] = data.getString("nombre");
                        dato[2] = data.getString("cantidad");
                        productos.Add(dato);
                    }
                }
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                if (con!=null)con.cerrar();
            }
            return productos;
        }

        public DataTable consultarEstadoCierreCajas(ref string mensaje, DateTime desde, DateTime hasta, string estado)
        {
            MySqlCommand cmd;
            DataSet datos = null;
            DataTable resultado = null;
            MySqlDataAdapter adapter = null;
            try
            {
                cmd = this.conf.EjecutarSQL("caja_Consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 5).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idconfPos", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?fechaDesde", desde).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?fechaHasta", hasta).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?accion", null).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?estadoi", estado).Direction = ParameterDirection.Input;

                adapter = new MySqlDataAdapter(cmd);
                datos = new DataSet();
                adapter.Fill(datos, "cajas");
                resultado = datos.Tables["cajas"];
            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                conf.cerrar();
                if (adapter != null) adapter.Dispose();
            }
            return resultado;
        }

        public DataTable consultarCierreCajas(ref string mensaje, DateTime desde, DateTime hasta, int idConfPos)
        {
            MySqlCommand cmd;
            DataSet datos = null;
            DataTable resultado = null;
            MySqlDataAdapter adapter = null;
            try
            {
                cmd = this.conf.EjecutarSQL("caja_Consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 3).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idconfPos", idConfPos).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?fechaDesde", desde).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?fechaHasta", hasta).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?accion", null).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?estadoi", null).Direction = ParameterDirection.Input;

                adapter = new MySqlDataAdapter(cmd);
                datos = new DataSet();
                adapter.Fill(datos, "cajas");
                resultado = datos.Tables["cajas"];
            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                conf.cerrar();
                if (adapter != null) adapter.Dispose();
            }
            return resultado;
        }

        public bool abrirCaja(ref string mensaje)
        {
            bool resultado = false;
            try
            {
                MySqlCommand cmd = this.Conf.EjecutarSQL("caja_abrir");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?id_empleadoi", this.AperturarCerrar.Id_empleado).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?apertura_cierrei", this.AperturarCerrar.Apertura_cierre).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?codigo_secuenciali", this.AperturarCerrar.Codigo_secuencial).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?monto_iniciali", this.AperturarCerrar.Monto_incial).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?edicioni", this.AperturarCerrar.Edicion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?id_confPosi", this.AperturarCerrar.Id_confPos).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idabrir_cerrar_cajai", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                if (!String.IsNullOrEmpty(cmd.Parameters["?idabrir_cerrar_cajai"].Value.ToString()))
                {
                    this.caja.Id = (int)cmd.Parameters["?idabrir_cerrar_cajai"].Value;
                    resultado = true;
                }
                else
                {
                    mensaje = cmd.Parameters["?msn"].Value.ToString();
                    if (String.IsNullOrEmpty(mensaje)) mensaje = "Error del sistema, por favor intente más tarde.";
                }
            }
            catch (Exception e)
            {
                mensaje = e.Message;
                resultado = false;
            }
            finally
            {
                this.conf.cerrar();
            }

            return resultado;
        }

        public bool cerrarCaja(ref string mensaje,string datafast, string medianet, string redApoyo)
        {
            bool resultado = false;
            try
            {
                MySqlCommand cmd = this.Conf.EjecutarSQL("caja_cerrar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("?id_empleadoi", this.AperturarCerrar.Id_empleado).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?apertura_cierrei", this.AperturarCerrar.Apertura_cierre).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?codigo_secuenciali", this.AperturarCerrar.Codigo_secuencial).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?monto_inciali", this.AperturarCerrar.Monto_incial).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?id_confPosi", this.AperturarCerrar.Id_confPos).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?efectivoi", this.AperturarCerrar.Efectivo).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?chequei", this.AperturarCerrar.Cheque).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?tarjetai", this.AperturarCerrar.Tarjeta).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?total_cierrei", this.AperturarCerrar.Total_cierre).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?total_facturadoi", this.AperturarCerrar.Total_facturado).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?total_cobradoi", this.AperturarCerrar.Total_cobro).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?saldo_finali", this.AperturarCerrar.Saldo_final).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?retencioni", this.AperturarCerrar.Retencion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?id_abrirCerrari", this.AperturarCerrar.Id).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?datafasti", datafast).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?medianeti", medianet).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?redApoyoi", redApoyo).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?efectivo_manuali", this.AperturarCerrar.Efectivo_Manual).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cheque_manuali", this.AperturarCerrar.Cheque_Manual).Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?idabrir_cerrar_cajai", MySqlDbType.Int32);
                cmd.Parameters["?idabrir_cerrar_cajai"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add(new MySqlParameter("?msn", MySqlDbType.VarChar));
                cmd.Parameters["?msn"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                if (!String.IsNullOrEmpty(cmd.Parameters["?idabrir_cerrar_cajai"].Value.ToString()))
                {
                    this.caja.Id = (int)cmd.Parameters["?idabrir_cerrar_cajai"].Value;
                    resultado = true;
                }
                else
                {
                    mensaje = cmd.Parameters["?msn"].Value.ToString();
                    if (String.IsNullOrEmpty(mensaje)) mensaje = "Error del sistema, por favor intente más tarde.";
                }
            }
            catch (Exception e)
            {
                mensaje = e.Message;
                resultado = false;
            }
            finally
            {
                this.conf.cerrar();
            }
            return resultado;
        }

        public static Caja verEstadoCaja(int idconfPos,string tipo)
        {
             Caja caja = null;
             MySqlCommand cmd = null;
             MySqlDataReader data = null;
             Conexion con = null;
             try
             {
                 con = new Conexion();
                 cmd = con.EjecutarSQL("caja_consultar");
                 cmd.CommandType = System.Data.CommandType.StoredProcedure;

                 cmd.Parameters.AddWithValue("?opcion", 1).Direction = ParameterDirection.Input;
                 cmd.Parameters.AddWithValue("?idconfPos", idconfPos).Direction = ParameterDirection.Input;
                 cmd.Parameters.AddWithValue("?accion", tipo).Direction = ParameterDirection.Input;
                 cmd.Parameters.AddWithValue("?fechaDesde", null).Direction = ParameterDirection.Input;
                 cmd.Parameters.AddWithValue("?fechaHasta", null).Direction = ParameterDirection.Input;
                 cmd.Parameters.AddWithValue("?estadoi", String.Empty).Direction = ParameterDirection.Input;

                 data = cmd.ExecuteReader();
                 if (data.Read())
                 {
                     caja = new Caja();
                     caja.Id = data.getInt("id_caja");
                     caja.Id_empleado = data.getInt("empleado_apertura");
                     caja.Fecha_hora = data.GetDateTime("fecha_apertura");
                     caja.Edicion = data.GetDateTime("edicion");
                     caja.Codigo_secuencial = data.getInt("secuencial");
                     caja.Monto_incial = data.getDecimal("monto_inicial");
                     caja.Id_confPos = idconfPos;
                 }
             }
             catch (Exception e) { throw e; }
             finally
             {
                 if (data != null) data.Dispose();
                 if (cmd != null) cmd.Dispose();
                 if (con != null)con.cerrar();
             }
             return caja;
        }

        public static List<String> obtenerPing(int idCaja)
        {
            List<String> datos = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion conf = new Conexion();
            try
            {
                cmd = conf.EjecutarSQL("xml_generarCierreCaja");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("?opcion", 6).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCierreCajai", idCaja).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idFacturaCabecerai", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?inicio", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cantidad", -1).Direction = ParameterDirection.Input;

                datos = new List<String>();
                data = cmd.ExecuteReader();
                while (data.Read())datos.Add(data.GetString(0));
                
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                conf.cerrar();
            }
            return datos;
        }

        public bool existeCajaActiva(int idconfPos, ref string mensaje)
        {
            bool resultado = false;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            try
            {
                cmd = this.conf.EjecutarSQL("caja_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 2).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idconfPos", idconfPos).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?accion", String.Empty).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?fechaDesde", null).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?fechaHasta", null).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?estadoi", null).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.Read()) resultado = true;
                
            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                this.conf.cerrar();
            }
            return resultado;
        }

        public Caja sacarTotalRecibido(int idCaja)
        {
            Caja caja = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            try
            {
                cmd = this.conf.EjecutarSQL("caja_sacarTotalRecibido");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?idCajai", idCaja);
                cmd.Parameters["?idCajai"].Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                caja = new Caja();

                if (data.Read()){
                    caja.Efectivo = data.GetDecimal(0);
                    caja.Cheque = data.GetDecimal(1);
                    caja.Tarjeta = data.GetDecimal(2);
                    caja.Retencion = data.GetDecimal(3);
                }
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                this.conf.cerrar();
            }
            return caja;

        }

        public decimal sacarTotalVendido(int idCaja)
        {
            decimal facturado = -1;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            try
            {
                cmd = this.conf.EjecutarSQL("caja_sacarTotalVendido");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?idCajai", idCaja);
                cmd.Parameters["?idCajai"].Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                caja = new Caja();

                if (data.Read())
                {
                    facturado = data.getDecimal("facturado");
                }
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                this.conf.cerrar();
            }
            return facturado;
        }

        public static bool actualizarEstado(int opcion, string estado, int idCaja)
        {
            bool resultado = false;
            MySqlCommand cmd = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("caja_actualizarEstado");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", opcion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCajai", idCaja).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idEmpleadoi", Global.idEmpleado).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?estadoi", estado).Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();
                resultado = true;

            }
            catch (Exception e) { throw e; }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (con != null) con.cerrar();
            }
            return resultado;
        }

        public int sacarNumeroSecuencia(int idConfPos)
        {
            int secuencia= -1;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            try
            {
                cmd = this.conf.EjecutarSQL("caja_obtenerSecuencial");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?idConfPos",idConfPos);
                cmd.Parameters["?idConfPos"].Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.Read()) { secuencia = data.IsDBNull(0) ? -1 : data.GetInt16(0); }
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                this.conf.cerrar();
            }
            return secuencia;
        }
    }
}
