using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pos.Clases;
using MySql.Data.MySqlClient;
using System.Data;

namespace Pos.Coneccion
{
    class AdicionalTR
    {
        private Conexion conf;
        private Adicional adicional;

        public AdicionalTR(Adicional adicional)
        {
            this.adicional = adicional;
            this.conf = new Conexion();
        }

        public AdicionalTR()
        {
            this.conf = new Conexion();
        }

        public void refrescar()
        {
            if (this.conf == null) this.conf = new Conexion();
        }

        public Adicional consultar(ref string mensaje, int idAdicional)
        {
            Adicional adicional = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion conf = null;
            try
            {

                conf = new Conexion();
                cmd = conf.EjecutarSQL("adicional_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idAdicionali", idAdicional).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", String.Empty).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?estadoi", String.Empty).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.Read())
                {
                    adicional = new Adicional();
                    adicional.nombre = data.getString("nombre");
                    adicional.etiqueta= data.getString("etiqueta");
                    adicional.tipo = data.getString("tipo");
                    adicional.estado = data.getString("estado");
                    adicional.obligatorio = data.GetBoolean("obligatorio");
                    adicional.mostrarEnListado = data.GetBoolean("mostrarFactura");
                    adicional.items = this.cargarItems(idAdicional);
                }
            }
            catch (Exception e)
            {
                adicional = null;
                mensaje = e.Message;
            }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                conf.cerrar();
            }
            return adicional;
        }

        public List<Adicional> cargarAdicionales (string estado = "")
        {
            List<Adicional> adicionales = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            try
            {

                cmd = this.conf.EjecutarSQL("adicional_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idAdicionali", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", String.Empty).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?estadoi", estado).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();

                if (data.HasRows)
                {
                    adicionales = new List<Adicional>();
                    while (data.Read())
                    {
                        Adicional adicional = new Adicional();
                        adicional.idAdicional = data.GetInt32("id");
                        adicional.nombre = data.getString("nombre");
                        adicional.etiqueta = data.getString("etiqueta");
                        adicional.tipo = data.getString("tipo");
                        adicional.items = this.cargarItems(adicional.idAdicional);
                        adicional.obligatorio = data.GetBoolean("obligatorio");
                        adicional.mostrarEnListado = data.GetBoolean("mostrarFactura");
                        adicional.estado = data.getString("estado");
                        adicionales.Add(adicional);
                    }
                }
            }
            catch (Exception e)
            {
                adicionales = null;
                throw e;
            }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                this.conf.cerrar();
            }
            return adicionales;
        }

        public static List<object[]> nombresFactura()
        {
            List<object[]> items = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion con = null;
            try
            {

                con = new Conexion();
                cmd = con.EjecutarSQL("adicional_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 3).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idAdicionali", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", String.Empty).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?estadoi", String.Empty).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();

                if (data.HasRows)
                {
                    items = new List<object[]>();
                    while (data.Read())
                    {
                        object[] datos = new Object[2];
                        datos[0] = data.GetInt16("id");
                        datos[1] = data.getString("nombre");
                        items.Add(datos);
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

        public List<String> cargarItems(int idAdicional)
        {
            List<String> items = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion con = null;
            try
            {

                con = new Conexion();
                cmd = con.EjecutarSQL("adicional_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 2).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idAdicionali", idAdicional).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", String.Empty).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?estadoi", String.Empty).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();

                if (data.HasRows)
                {
                    items = new List<String>();
                    while (data.Read())items.Add(data.getString("texto"));  
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
                if(con!=null)con.cerrar();
            }
            return items;
        }

        public DataTable cargarListado(ref string mensaje, int idAdicional, string nombre)
        {
            MySqlCommand cmd;
            DataSet datos = null;
            DataTable resultado = null;
            MySqlDataAdapter adapter = null;
            try
            {
                cmd = conf.EjecutarSQL("adicional_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 2).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idAdicionali", idAdicional).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", nombre).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?estadoi", String.Empty).Direction = ParameterDirection.Input;

                adapter = new MySqlDataAdapter(cmd);
                datos = new DataSet();
                adapter.Fill(datos);
                resultado = datos.Tables[0];
            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                conf.cerrar();
                if (adapter != null) adapter.Dispose();
            }
            return resultado;
        }

        public bool actualizar()
        {
            bool resultado = false;
            MySqlCommand cmd = null;
            try
            {
                cmd = conf.EjecutarSQL("adicional_actualizar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("?idi", this.adicional.idAdicional).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", this.adicional.nombre).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?etiquetai", this.adicional.etiqueta).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?tipoi", this.adicional.tipo).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?estadoi", this.adicional.estado).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?obligatorioi", this.adicional.obligatorio).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?mostrarFacturai", this.adicional.mostrarEnListado).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idAdicional", MySqlDbType.Int32).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                if (this.adicional.idAdicional == -1)
                {
                    this.adicional.idAdicional = (int)cmd.Parameters["?idAdicional"].Value;
                }

                if (this.adicional.tipo != "T")
                {
                    this.eliminarListado(this.adicional.idAdicional);
                    foreach (string valor in this.adicional.items) this.insertarListado(this.adicional.idAdicional, valor);
                }

                resultado = true;

            }
            catch (Exception e) { throw e; }
            finally { this.conf.cerrar(); }
            return resultado;
        }


        public static void eliminarAdicionales(string ids)
        {
            MySqlCommand cmd = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("adicional_eliminar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("?ids", ids).Direction = ParameterDirection.Input;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e) { throw e; }
            finally { if(con!=null)con.cerrar(); }
        }

        public bool insertarListado(int idAdicional, string valor)
        {
            bool resultado = false;
            MySqlCommand cmd = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("adicional_listado");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 2).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idAdicionali", idAdicional).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?valor", valor).Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();
                resultado = true;

            }
            catch (Exception e) {
                throw e;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if(con != null)con.cerrar();
            }
            return resultado;
        }

        public bool eliminarListado(int idAdicional)
        {
            bool resultado = false;
            MySqlCommand cmd = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("adicional_listado");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idAdicionali", idAdicional).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?valor", String.Empty).Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();
                resultado = true;

            }
            catch (Exception e) { throw e; }
            finally {
                if (cmd != null) cmd.Dispose();
                if(con!=null)con.cerrar(); 
            }
            return resultado;
        }
    }
}
