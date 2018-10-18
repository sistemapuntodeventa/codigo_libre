using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pos.Clases;
using MySql.Data.MySqlClient;
using System.Data;

namespace Pos.Coneccion
{
    class PromocionTR
    {

        //private Conexion conf;
        private Promocion promocion;

        public PromocionTR()
        {

        }

        public PromocionTR(Promocion promocion)
        {
            this.promocion = promocion;
        }

        public static DataTable consultarPromociones(string estado)
        {
            MySqlCommand cmd;
            DataSet datos = null;
            DataTable resultado = null;
            MySqlDataAdapter adapter = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("promocion_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 5).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idPromocion", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCategoria", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idProducto", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?numero_productoi", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", String.Empty).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?estadoi", estado).Direction = ParameterDirection.Input;

                adapter = new MySqlDataAdapter(cmd);
                datos = new DataSet();
                adapter.Fill(datos, "promocion");
                resultado = datos.Tables["promocion"];
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (con != null) con.cerrar();
                if (adapter != null) adapter.Dispose();
            }
            return resultado;
        }

        public static DataTable consultarCategorias(ref string mensaje)
        {
            MySqlCommand cmd;
            DataSet datos = null;
            DataTable resultado = null;
            MySqlDataAdapter adapter = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("promocion_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idPromocion", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCategoria", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idProducto", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?numero_productoi", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", String.Empty).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?estadoi", String.Empty).Direction = ParameterDirection.Input;

                adapter = new MySqlDataAdapter(cmd);
                datos = new DataSet();
                adapter.Fill(datos, "promocion");
                resultado = datos.Tables["promocion"];
            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                if(con!=null)con.cerrar();
                if (adapter != null) adapter.Dispose();
            }
            return resultado;
        }

        public static DataTable productosDisponibles(int idCategoria, int idPromocion = -1, int numeroProducto = -1, string filtro = "")
        {
            MySqlCommand cmd;
            DataSet datos = null;
            DataTable resultado = null;
            MySqlDataAdapter adapter = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("promocion_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 2).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idPromocion", idPromocion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCategoria", idCategoria).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idProducto", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?numero_productoi", numeroProducto).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", filtro).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?estadoi", String.Empty).Direction = ParameterDirection.Input;

                adapter = new MySqlDataAdapter(cmd);
                datos = new DataSet();
                adapter.Fill(datos, "promocion");
                resultado = datos.Tables["promocion"];
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (con != null) con.cerrar();
                if (adapter != null) adapter.Dispose();
            }
            return resultado;
        }

        public static List<PromocionFactura> consultarDiaria()
        {
            List<PromocionFactura> listaPromocion = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion conf = null;
            try
            {
                conf = new Conexion();
                cmd = conf.EjecutarSQL("promocion_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 3).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idPromocion", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCategoria", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idProducto", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?numero_productoi", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", String.Empty).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?estadoi", String.Empty).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    listaPromocion = new List<PromocionFactura>();
                    while(data.Read())
                    {
                        PromocionFactura promocion = new PromocionFactura();
                        promocion.id = data.getInt("id");
                        promocion.agrupacion = data.getInt("agrupacion");
                        promocion.descuento = data.getInt("descuento");
                        promocion.cantidad = data.getInt("cantidad");
                        promocion.tipo = data.getString("tipo");
                        promocion.seleccion = data.getString("seleccion");
                        if (promocion.agrupacion == 1)
                        {
                            promocion.menores = new List<valoresMenores>();
                            if (promocion.seleccion == "P")
                            { 
                                promocion.combo = new List<valoresMenores>[promocion.cantidad];
                                for (int i = 0; i < promocion.cantidad; i++) promocion.combo[i] = new List<valoresMenores>();
                            }
                        }
                        else
                        {
                            promocion.grupo = new List<PromocionGrupo>();
                        }
                        listaPromocion.Add(promocion);
                    }
                }
            }
            catch (Exception e)
            {
                listaPromocion = null;
                throw e;
            }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                conf.cerrar();
            }
            return listaPromocion;
        }

        public static Promocion consultarXId(int idPromocion)
        {
            Promocion promocion = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion conf = null;
            try
            {
                conf = new Conexion();
                cmd = conf.EjecutarSQL("promocion_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 6).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idPromocion", idPromocion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCategoria", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idProducto", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?numero_productoi", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", String.Empty).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?estadoi", String.Empty).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();

                    if (data.Read())
                    {
                        promocion = new Promocion();
                        promocion.id = data.getInt("id");
                        promocion.agrupacion = data.getInt("agrupacion");
                        promocion.nombre = data.getString("nombre");
                        promocion.descuento = data.getDecimal("descuento");
                        promocion.cantidad = data.getInt("cantidad");
                        promocion.lunes = data.GetBoolean("lunes");
                        promocion.martes = data.GetBoolean("martes");
                        promocion.miercoles = data.GetBoolean("miercoles");
                        promocion.jueves = data.GetBoolean("jueves");
                        promocion.viernes = data.GetBoolean("viernes");
                        promocion.sabado = data.GetBoolean("sabado");
                        promocion.domingo = data.GetBoolean("domingo");
                        promocion.desde = data.GetDateTime("desde");
                        promocion.hasta = data.GetDateTime("hasta");
                        promocion.seleccion = data.getString("seleccion");
                        promocion.estado = data.getString("estado");
                        //promocion.mismoGrupo = data.GetBoolean("mismoGrupo");
                    }
            }
            catch (Exception e)
            {
                promocion = null;
                throw e;
            }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                conf.cerrar();
            }
            return promocion;
        }

        public static bool cargarDatosTemporal(int idConfiguracion, int idPromocion)
        {
            bool resultado = false;
            MySqlCommand cmd = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("promocion_operacion");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 3).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?id_confPosi", idConfiguracion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?id_productoi", idPromocion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?id_categoriai", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?numero_productoi", -1).Direction = ParameterDirection.Input;
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

        public static bool eliminarTemporal(int idConfiguracion)
        {
            bool resultado = false;
            MySqlCommand cmd = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("promocion_operacion");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 2).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?id_confPosi", idConfiguracion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?id_productoi", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?id_categoriai", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?numero_productoi", -1).Direction = ParameterDirection.Input;
                
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

        public bool insertarProductos(ref string mensaje, List<int[]> productos, int idConfiguracion, int idCategoria, int? numero_producto = -1)
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
                cmd = new MySqlCommand("promocion_operacion", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Transaction = tran;

                cmd.Parameters.AddWithValue("?opcion", 2).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?id_confPosi", idConfiguracion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?id_productoi", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?id_categoriai", idCategoria).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?numero_productoi", numero_producto).Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                this.insertarDetalle(cmd, productos, idConfiguracion, numero_producto);
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

        private void insertarDetalle(MySqlCommand cmd, List<int[]> productos, int idConfiguracion, int? numero_producto = null)
        {
            foreach (int[] producto in productos)
            {
                cmd.Parameters.AddWithValue("?opcion", 1);
                cmd.Parameters["?opcion"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?id_confPosi", idConfiguracion);
                cmd.Parameters["?id_confPosi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?id_productoi", producto[0]);
                cmd.Parameters["?id_productoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?id_categoriai", producto[1]);
                cmd.Parameters["?id_categoriai"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?numero_productoi", numero_producto);
                cmd.Parameters["?numero_productoi"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
        }

        public bool insertarPromocion()
        {
            return this.operacionPromocion(1);
        }

        public bool actualizarPromocion()
        {
            return this.operacionPromocion(2);
        }

        public static bool eliminarPromocion(int idPromocion)
        {
            bool resultado = false;
            MySqlCommand cmd = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("promocion_eliminar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?idPromocion", idPromocion);
                cmd.Parameters["?idPromocion"].Direction = ParameterDirection.Input;

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

        private bool operacionPromocion(int opcion)
        {
            bool resultado = false;
            MySqlCommand cmd = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("promocion_insertar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("?opcion", opcion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", this.promocion.nombre).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?agrupacioni", this.promocion.agrupacion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?descuentoi", this.promocion.descuento).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cantidadi", this.promocion.cantidad).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?lunesi", this.promocion.lunes).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?martesi", this.promocion.martes).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?miercolesi", this.promocion.miercoles).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?juevesi", this.promocion.jueves).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?viernesi", this.promocion.viernes).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?sabadoi", this.promocion.sabado).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?domingoi", this.promocion.domingo).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?desdei", this.promocion.desde).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?hastai", this.promocion.hasta).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?estadoi", this.promocion.estado).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?tipoi", this.promocion.tipo).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?seleccioni", this.promocion.seleccion).Direction = ParameterDirection.Input;
                //cmd.Parameters.AddWithValue("?mismoGrupoi", this.promocion.mismoGrupo);
                //cmd.Parameters["?mismoGrupoi"].Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idPromocioni", this.promocion.id).Direction = ParameterDirection.Input;

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

        public static List<int> consultarPromocionProducto(int idProducto)
        {
            List<int> promociones = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion conf = null;
            try
            {
                conf = new Conexion();
                cmd = conf.EjecutarSQL("promocion_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 4).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idPromocion", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCategoria", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idProducto", idProducto).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?numero_productoi", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", String.Empty).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?estadoi", String.Empty).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    promociones = new List<int>();
                    while (data.Read())promociones.Add(data.getInt("id_promocion"));
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
                conf.cerrar();
            }
            return promociones;
        }

        public static int consultarNumeroCombo(int idProducto, int idPromocion, string numerosExcluir)
        {
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion conf = null;
            int numero_producto = -1;
            try
            {
                conf = new Conexion();
                string sql = "SELECT numero_producto FROM promocion_productos WHERE id_producto =" + idProducto + (String.IsNullOrEmpty(numerosExcluir)?"":" AND numero_producto NOT IN ("+ numerosExcluir +")") + " AND id_promocion = " + idPromocion + " LIMIT 1";
                cmd = new MySqlCommand(sql, conf.abrir);
                cmd.CommandType = System.Data.CommandType.Text;
                data = cmd.ExecuteReader();
                if (data.Read()) numero_producto = data.getInt("numero_producto");
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                conf.cerrar();
            }
            return numero_producto;
        }

        public static List<int> consultarNumerosCombo(int idProducto, int idPromocion)
        {
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion conf = null;
            List<int> numeros = null;
            try
            {
                conf = new Conexion();
                string sql = "SELECT numero_producto FROM promocion_productos WHERE id_producto =" + idProducto + " AND id_promocion = " + idPromocion + " order by numero_producto ";
                cmd = new MySqlCommand(sql, conf.abrir);
                cmd.CommandType = System.Data.CommandType.Text;
                data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    numeros = new List<int>();
                    while (data.Read()) numeros.Add(data.getInt("numero_producto"));
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
                conf.cerrar();
            }
            return numeros;
        }
    }
}
