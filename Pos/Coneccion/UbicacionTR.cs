using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using Pos.Clases;

namespace Pos.Coneccion
{
    class UbicacionTR
    {

        public static bool eliminarUbicacion(ref string mensaje, int idUbicacion)
        {
            MySqlCommand cmd = null;
            Conexion con = null;
            bool estado = false;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("ubicacion_eliminar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?idUbicacion", idUbicacion).Direction = ParameterDirection.Input;
                cmd.Parameters.Add(new MySqlParameter("?msn", MySqlDbType.VarChar));
                cmd.Parameters["?msn"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                mensaje = cmd.Parameters["?msn"].Value.ToString();
                if (String.IsNullOrEmpty(mensaje)) estado = true;
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (con != null) con.cerrar();
            }
            return estado;
        }

        public static bool operacionUbicacion(List<Ubicacion> ubicaciones, bool insertar)
        {
            MySqlCommand cmd = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("ubicacion_insertar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (Ubicacion ubicacion in ubicaciones)
                {
                    cmd.Parameters.AddWithValue("?opcion", (insertar) ? 1 : 2).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("?idi", ubicacion.id).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("?nombrei", ubicacion.nombre).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("?impresorai", ubicacion.impresora).Direction = ParameterDirection.Input;
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }

            }
            catch (Exception e) { throw e; }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (con != null) con.cerrar();
            }
            return true;
        }

        public static bool insertarProductosDesdeTemporal(int idUbicacion)
        {
            MySqlCommand cmd = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("ubicacion_insertar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("?opcion", 3).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idi", idUbicacion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?impresorai", -1).Direction = ParameterDirection.Input;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (con != null) con.cerrar();
            }
            return true;
        }

        public static List<int> consultarUbicacionesProducto(int idProducto)
        {
            List<int> items = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("ubicacion_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 3).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idUbicacioni", idProducto).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCategoriai", -1).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();

                if (data.HasRows)
                {
                    items = new List<int>();
                    while (data.Read()) items.Add(data.getInt("id"));
                }
            }
            catch (Exception e)
            {
                items = null;
                throw e;
            }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                if (con != null) con.cerrar();
            }
            return items;
        }

        public static List<Ubicacion> listadoUbicaciones()
        {
            List<Ubicacion> items = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("ubicacion_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idUbicacioni", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCategoriai", -1).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();

                if (data.HasRows)
                {
                    items = new List<Ubicacion>();
                    while (data.Read())
                    {
                        Ubicacion dato = new Ubicacion();
                        dato.id = data.getInt("id");
                        dato.nombre = data.GetString("nombre");
                        dato.impresora = data.GetString("impresora");
                        dato.estado = data.GetString("estado");
                        items.Add(dato);
                    }
                }
            }
            catch (Exception e)
            {
                items = null;
                throw e;
            }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                if (con != null) con.cerrar();
            }
            return items;
        }

        public static DataTable consultarProductos(int idUbicacion, int idCategoria)
        {
            MySqlCommand cmd;
            DataSet datos = null;
            DataTable resultado = null;
            MySqlDataAdapter adapter = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("ubicacion_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 2).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idUbicacioni", idUbicacion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCategoriai", idCategoria).Direction = ParameterDirection.Input;

                adapter = new MySqlDataAdapter(cmd);
                datos = new DataSet();
                adapter.Fill(datos, "ubicacion");
                resultado = datos.Tables["ubicacion"];
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (con != null) con.cerrar();
                if (adapter != null) adapter.Dispose();
            }
            return resultado;
        }

        public static DataTable consultarUbicaciones()
        {
            MySqlCommand cmd;
            DataSet datos = null;
            DataTable resultado = null;
            MySqlDataAdapter adapter = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("ubicacion_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idUbicacioni", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCategoriai", -1).Direction = ParameterDirection.Input;

                adapter = new MySqlDataAdapter(cmd);
                datos = new DataSet();
                adapter.Fill(datos, "ubicacion");
                resultado = datos.Tables["ubicacion"];
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (con != null) con.cerrar();
                if (adapter != null) adapter.Dispose();
            }
            return resultado;
        }

        /*trabajo tablas temporales*/
        public static bool cargarDatosTemporal(int idUbicacion)
        {
            bool resultado = false;
            MySqlCommand cmd = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("ubicacion_operacion");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("?opcion", 3).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?id_ubicacioni", idUbicacion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?id_productoi", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?id_categoriai", -1).Direction = ParameterDirection.Input;
                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (con != null) con.cerrar();
                if (cmd != null) cmd.Dispose();
            }
            return resultado;
        }

        public static bool eliminarTemporal()
        {
            bool resultado = false;
            MySqlCommand cmd = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("ubicacion_operacion");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 2).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?id_ubicacioni", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?id_productoi", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?id_categoriai", -1).Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (con != null) con.cerrar();
                if (cmd != null) cmd.Dispose();
            }
            return resultado;
        }

        public bool insertarProductos(ref string mensaje, List<int[]> productos,int idUbicacion, int idCategoria)
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
                cmd = new MySqlCommand("ubicacion_operacion", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Transaction = tran;

                cmd.Parameters.AddWithValue("?opcion", 2).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?id_ubicacioni", idUbicacion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?id_productoi", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?id_categoriai", idCategoria).Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                this.insertarDetalle(cmd, productos, idUbicacion);
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

        private void insertarDetalle(MySqlCommand cmd, List<int[]> productos, int idUbicacion)
        {
            foreach (int[] producto in productos)
            {
                cmd.Parameters.AddWithValue("?opcion", 1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?id_ubicacioni", idUbicacion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?id_productoi", producto[0]).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?id_categoriai", producto[1]).Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
        }

        /*trabajo tablas temporales*/
    }
}
