using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Pos.Coneccion
{
    static class ParametroTR
    {

        public static List<object> ConsultarInt(string id)
        {
            MySqlCommand cmd = null;
            List<object> resultado = null;
            MySqlDataReader data = null;
            Conexion conf = new Conexion();
            try
            {

                cmd = conf.EjecutarSQL("parametro_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("?opcion", 3).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idi", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", id).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if(data.HasRows)
                {
                    resultado = new List<object>();
                    while (data.Read())resultado.Add(data.GetValue(0)); 
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

        public static int consultarIntXNombre(string nombre)
        {
            MySqlCommand cmd = null;
            int resultado = -1;
            MySqlDataReader data = null;
            Conexion conf = new Conexion();
            try
            {

                cmd = conf.EjecutarSQL("parametro_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("?opcion", 1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idi", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", nombre).Direction = ParameterDirection.Input;
                data = cmd.ExecuteReader();
                if (data.Read()) resultado = data.GetInt16(0);
                
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

        // para parar sincronizacion continua para revisión de problemas.
        public static int ConsultarSincronizacionContinua(string nombre)
        {
            MySqlCommand cmd = null;
            int resultado = -1;
            MySqlDataReader data = null;
            Conexion conf = new Conexion();
            try
            {

                cmd = conf.EjecutarSQL("parametro_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("?opcion", 4).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idi", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", nombre).Direction = ParameterDirection.Input;
                data = cmd.ExecuteReader();
                if (data.Read()) resultado = data.GetInt32(0);

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

        public static bool ConsultarBool(string nombre)
        {
            MySqlCommand cmd = null;
            int resultado = -1;
            MySqlDataReader data = null;
            Conexion conf = new Conexion();
            try
            {

                cmd = conf.EjecutarSQL("parametro_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("?opcion", 1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idi", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", nombre).Direction = ParameterDirection.Input;
                data = cmd.ExecuteReader();
                if (data.Read()) resultado = data.GetInt32(0);

            }
            catch (Exception e) { throw e; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                conf.cerrar();
            }
            return (resultado == 1);
        }

        public static string ConsultarStringXNombre(ref string mensaje, string nombre)
        {
            MySqlCommand cmd = null;
            string resultado = "";
            MySqlDataReader data = null;
            Conexion conf = new Conexion();
            try
            {

                cmd = conf.EjecutarSQL("parametro_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("?opcion", 2).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idi", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", nombre).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.Read()) resultado = data.GetString(0);

            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                conf.cerrar();
            }
            return resultado;
        }

        public static bool actualizarParametroEntero(string nombre, int nuevoValor)
        {
            bool resultado = false;
            Conexion conf = new Conexion();
             MySqlCommand cmd = null;
            try
            {
                cmd = conf.EjecutarSQL("parametro_actualizar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?idi", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", nombre).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?valorEnteroi",nuevoValor).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?valorStringi", String.Empty).Direction = ParameterDirection.Input;
                
                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception e) { throw e; }
            finally {
                if (cmd != null) cmd.Dispose();
                conf.cerrar(); 
            }
            return resultado;
        }

        public static bool actualizarParametroString(string nombre, string nuevoValor)
        {
            bool resultado = false;
            Conexion conf = new Conexion();
             MySqlCommand cmd = null;
            try
            {
                cmd = conf.EjecutarSQL("parametro_actualizar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?idi", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", nombre).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?valorEnteroi",null).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?valorStringi", nuevoValor).Direction = ParameterDirection.Input;
                
                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception e) { throw e; }
            finally {
                if (cmd != null) cmd.Dispose();
                conf.cerrar(); 
            }
            return resultado;
        }
    }
}
