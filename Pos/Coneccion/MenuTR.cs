using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using Pos.Clases;

namespace Pos.Coneccion
{
    class MenuTR
    {
        public static List<ItemMenu> consultarItems()
        {
            MySqlCommand cmd = null;
            List<ItemMenu> resultado = null;
            MySqlDataReader data = null;
            Conexion conf = new Conexion();
            try
            {

                cmd = conf.EjecutarSQL("menu_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("?opcion", 1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idMenui", -1).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if(data.HasRows)
                {
                    resultado = new List<ItemMenu>();
                    while (data.Read())
                    {
                        ItemMenu item = new ItemMenu();
                        item.id = data.getInt("id");
                        item.idPadre = data.getInt("id_padre");
                        item.nombre = data.getString("nombre");
                        item.nombreItem = data.getString("nombreItem");
                        item.estado = data.getString("estado");
                        resultado.Add(item);
                    }
                }


            }
            catch (Exception e) { throw e; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                conf.cerrar();
            }
            return resultado;
        }

        public static List<ItemMenu> consultarItemsXRol(int idRol)
        {
            MySqlCommand cmd = null;
            List<ItemMenu> resultado = null;
            MySqlDataReader data = null;
            Conexion conf = new Conexion();
            try
            {

                cmd = conf.EjecutarSQL("menu_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("?opcion", 3).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idMenui", idRol).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    resultado = new List<ItemMenu>();
                    while (data.Read())
                    {
                        ItemMenu item = new ItemMenu();
                        item.id = data.getInt("id");
                        item.idPadre = data.getInt("id_padre");
                        //item.nombre = data.getString("nombre");
                        item.nombreItem = data.getString("nombreItem");
                        //item.estado = data.getString("estado");
                        resultado.Add(item);
                    }
                }


            }
            catch (Exception e) { throw e; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                conf.cerrar();
            }
            return resultado;
        }

        public static List<int> consultarPermisos(int idMenu)
        {
            MySqlCommand cmd = null;
            List<int> resultado = null;
            MySqlDataReader data = null;
            Conexion conf = new Conexion();
            try
            {

                cmd = conf.EjecutarSQL("menu_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("?opcion", 2).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idMenui", idMenu).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if(data.HasRows)
                {
                    resultado = new List<int>();
                    while (data.Read())resultado.Add(data.GetInt32("id_rol"));
                }
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                conf.cerrar();
            }
            return resultado;
        }

        public static bool actualizar(int idMenu,List<int> listaRoles)
        {
            bool resultado = false;
            Conexion con = null;
            try
            {
                con = new Conexion();
                MySqlCommand cmd = con.EjecutarSQL("menu_insertar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?id_menui", idMenu).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?id_roli", -1).Direction = ParameterDirection.Input;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                foreach (int idRol in listaRoles)
                {
                    cmd.Parameters.AddWithValue("?opcion", 2).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("?id_menui", idMenu).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("?id_roli", idRol).Direction = ParameterDirection.Input;
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();  
                }


                resultado = true;

            }
            catch (Exception e) { throw e; }
            finally { if(con!=null)con.cerrar(); }
            return resultado;
        }
        
   
    }
}
