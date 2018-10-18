using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using Pos.Clases;

namespace Pos.Coneccion
{
    class GuiaRemisionTR
    {
        private GuiaRemision guia;

        public GuiaRemisionTR(GuiaRemision guia)
        {
            this.guia = guia;
        }

        public bool insertarGuia()
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
                cmd = new MySqlCommand("guiaRemision_operacion", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Transaction = tran;

                cmd.Parameters.AddWithValue("?opcion", 1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idi", guia.id).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?fechaEmisioni", guia.fechaEmision).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?fechaInicioi", guia.fechaInicio).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?fechaFini", guia.fechaFin).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?numeroDocumentoi", guia.numeroDocumento).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?autorizacioni", guia.autorizacion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?direccionPartidai", guia.direccionPartida).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idTransportistai", guia.transportista.id).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?placai", guia.placa).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?correoTransportistai", guia.transportista.email).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?descripcioni", guia.descripcion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?estadoi", guia.estado).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCajai", guia.caja.Id).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idGuiaRemisioni", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                guia.id = (int)cmd.Parameters["?idGuiaRemisioni"].Value;
                cmd.Parameters.Clear();

                this.insertarDestinatarios(cmd);
                tran.Commit();
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

        private void insertarDestinatarios(MySqlCommand cmd)
        {
            foreach (Destinatario destinatario in this.guia.destinatarios)
            {
                cmd.CommandText = "guiaRemision_destinatario";
                cmd.Parameters.AddWithValue("?opcion", 1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idGuiaRemisioni", this.guia.id).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idClientei", destinatario.cliente.id).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idDocumentoi", (destinatario.documento != null)?(int?)destinatario.documento.Id:null).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?motivoi", destinatario.motivo).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?direccioni", destinatario.direccion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?codigoDestinoi", destinatario.codigoDestino).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?rutai", destinatario.ruta).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idDestinatarioi", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int idDestinatario = (int)cmd.Parameters["?idDestinatarioi"].Value;
                cmd.Parameters.Clear();

                foreach (String[] detalle in destinatario.detalle)
                {
                    cmd.CommandText = "guiaRemision_detalle";
                    cmd.Parameters.AddWithValue("?opcion", 1).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("?idDestinatarioi", idDestinatario).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("?idProductoi", detalle[0]).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("?cantidadi", detalle[2]).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("?unidadi", detalle[3]).Direction = ParameterDirection.Input;
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }

        public void actualizarGuia()
        {
            MySqlCommand cmd = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("guiaRemision_operacion");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

               /* cmd.Parameters.AddWithValue("?opcion", 2).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idi", guia.id).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?fechaInicioTrasladoi", guia.fechaInicioTraslado).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?FechaFinTrasladoi", guia.fechaFinTraslado).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?comprobanteVentai", guia.comprobanteVenta).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?fechaEmisioni", guia.fechaEmision).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?ventai", guia.venta).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?comprai", guia.compra).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?transformacioni", guia.transformacion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?consignacioni", guia.consignacion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?trasladoEntreEstablecimientosi", guia.trasladoEntreEstablecimientos).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?trasladoEmisorItinerantei", guia.trasladoEmisorItinerante).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?devolucioni", guia.devolucion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?importacioni", guia.importacion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?exportacioni", guia.exportacion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?otrosi", guia.otros).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?puntoDePartidai", guia.puntoDePartida).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?ciudadPartidai", guia.ciudadPartida).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombreDestinatarioi", guia.nombreDestinatario).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cedulaDestinatarioi", guia.cedulaDestinatario).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?puntoLlegadai", guia.puntoLlegada).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?ciudadLlegadai", guia.ciudadLlegada).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombreEncargadoi", guia.nombreEncargado).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cedulaEncargadoi", guia.cedulaEncargado).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?placaEncargadoi", guia.placaEncargado).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idFacturaCabecerai", guia.idFactura).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idGuiaRemisioni", MySqlDbType.Int32).Direction = ParameterDirection.Output;*/
                cmd.ExecuteNonQuery();
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (con != null) con.cerrar();
                if (cmd != null) cmd.Dispose();
            }
        }

        public static GuiaRemision consultarXId(int idGuia)
        {
            GuiaRemision guia = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion conf = null;
            try
            {
                conf = new Conexion();
                cmd = conf.EjecutarSQL("guiaRemision_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idGuiaRemisioni", idGuia).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?fechaDesde", null).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?fechaHasta", null).Direction = ParameterDirection.Input;
                data = cmd.ExecuteReader();

                if (data.Read())
                {
                    guia = new GuiaRemision();
                    guia.id = data.GetInt32("id");
                    guia.fechaEmision = data.GetDateTime("fecha_emision");
                    guia.fechaInicio = data.GetDateTime("fecha_inicio");
                    guia.fechaFin = data.GetDateTime("fecha_fin");
                    guia.numeroDocumento = data.getString("numero_documento");
                    guia.autorizacion = data.getString("autorizacion");
                    guia.direccionPartida = data.getString("direccion_partida");
                    guia.descripcion = data.getString("descripcion");
                    guia.placa = data.getString("placa");
                    guia.id_caja = data.getInt("id_caja");
                    guia.estado = data.getString("estado");
                    guia.destinatarios = new List<Destinatario>();
                    Destinatario destinatario = new Destinatario();
                    destinatario.id = data.getInt("destinatario_id");
                    guia.transportista = EmpleadoTR.buscarXId(data.getInt("transportista_id"));
                    destinatario.cliente = ClienteTR.buscarXId(data.getInt("cliente_id"));
                    destinatario.documento = FacturaCabeceraTR.consultarFactura(data.getInt("documento_id"));
                    destinatario.motivo = data.getString("motivo");
                    destinatario.direccion = data.getString("direccion_destino");
                    destinatario.ruta = data.getString("ruta");
                    destinatario.codigoDestino = data.getString("codigo_destino");
                    guia.destinatarios.Add(destinatario);
                    cmd.Parameters.Clear();
                    data.Dispose();
                    destinatario.detalle = GuiaRemisionTR.consultarGuiaDetalle(cmd, conf, destinatario.id);
                }
            }
            catch (Exception e)
            {
                guia = null;
                throw e;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (conf!=null) conf.cerrar();
            }
            return guia;
        }

        public static List<String[]> consultarGuiaDetalle(MySqlCommand cmd, Conexion conf, int idGuia)
        {
            List<String[]> lista = null;
            MySqlDataReader data = null;
            cmd.CommandText = "guiaRemision_consultar";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("?opcion", 2).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?idGuiaRemisioni", idGuia).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?fechaDesde", null).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?fechaHasta", null).Direction = ParameterDirection.Input;
            data = cmd.ExecuteReader();
            if (data.HasRows)
            {
                lista = new List<string[]>();
                while (data.Read())
                {
                    String[] item = new String[4];
                    item[0] = data.GetValue(0).ToString();
                    item[1] = data.GetValue(1).ToString();
                    item[2] = data.GetValue(2).ToString();
                    item[3] = data.GetValue(3).ToString();
                    //item[4] = data.GetValue(4).ToString();
                    lista.Add(item);
                }
            }

            if (data != null) data.Dispose();
            return lista;
        }

        public static int consultarSecuencia()
        {
            int secuencia = -1;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion conf = null;
            try
            {
                conf = new Conexion();
                cmd = conf.EjecutarSQL("guiaRemision_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 4).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idGuiaRemisioni", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?fechaDesde", null).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?fechaHasta", null).Direction = ParameterDirection.Input;
                data = cmd.ExecuteReader();

                if (data.Read())
                {
                    secuencia = data.GetInt32("id");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (conf != null) conf.cerrar();
                if (data != null) data.Dispose();
            }
            return secuencia;
        }

        public static DataTable consultarGuias(DateTime desde,DateTime hasta)
        {
            MySqlCommand cmd;
            DataSet datos = null;
            DataTable resultado = null;
            MySqlDataAdapter adapter = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("guiaRemision_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 3).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idGuiaRemisioni", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?fechaDesde", desde).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?fechaHasta", hasta).Direction = ParameterDirection.Input;

                adapter = new MySqlDataAdapter(cmd);
                datos = new DataSet();
                adapter.Fill(datos);
                resultado = datos.Tables[0];
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (con != null) con.cerrar();
                if (adapter != null) adapter.Dispose();
            }
            return resultado;
        }

        public static bool anularGuia(GuiaRemision guia, bool nueva = false)
        {

            bool resultado = false;
            MySqlCommand cmd = null;
            Conexion conf = null;
            try
            {
                conf = new Conexion();
                cmd = conf.EjecutarSQL("guiaRemision_anular");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", (nueva)?2:1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idi", guia.id).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?fecha_emisioni", guia.fechaEmision).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?numero_documentoi", guia.numeroDocumento).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?autorizacioni", guia.autorizacion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?descripcioni", guia.descripcion).Direction = ParameterDirection.Input;
                cmd.ExecuteNonQuery();
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
