using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pos.Clases;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace Pos.Coneccion
{
    class EmpleadoTR
    {
        private Conexion conf;
        private Persona persona;

        public EmpleadoTR()
        {
            this.conf = new Conexion();

        }

        public EmpleadoTR(Persona persona)
        {
            this.persona = persona;
            this.conf = new Conexion();
        }

        public DataTable consultarEmpleadosIngresados(ref string mensaje, string nombre, int mostrarTodos)
        {
            MySqlCommand cmd;
            DataSet datos = null;
            DataTable resultado = null;
            MySqlDataAdapter adapter = null;
            try
            {
                cmd = this.conf.EjecutarSQL("empleado_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 4).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idi", null).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", nombre).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cedulai", String.Empty).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?mostrarTodos", mostrarTodos).Direction = ParameterDirection.Input;

                adapter = new MySqlDataAdapter(cmd);
                datos = new DataSet();
                adapter.Fill(datos, "empleados");
                resultado = datos.Tables["empleados"];
            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                conf.cerrar();
                if (adapter != null) adapter.Dispose();
            }
            return resultado;
        }

        public DataTable consultarEmpleados(ref string mensaje, string nombre, string cedula)
        {
            MySqlCommand cmd;
            DataSet datos = null;
            DataTable resultado = null;
            MySqlDataAdapter adapter = null;
            try
            {
                cmd = this.conf.EjecutarSQL("empleado_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idi", null).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", nombre).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cedulai", cedula).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?mostrarTodos", -1).Direction = ParameterDirection.Input;

                adapter = new MySqlDataAdapter(cmd);
                datos = new DataSet();
                adapter.Fill(datos, "empleados");
                resultado = datos.Tables["empleados"];
            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                conf.cerrar();
                if (adapter != null) adapter.Dispose();
            }
            return resultado;
        }

        public static Persona buscarXId(int id)
        {
            return EmpleadoTR.buscar(id, null);
        }

        public static Persona buscarXCedula(String cedula)
        {
            return EmpleadoTR.buscar(null, cedula);
        }

        private static Persona buscar(int? id = null, string cedula = null)
        {
            Persona persona = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("empleado_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 2).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idi", id).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cedulai", cedula).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", String.Empty).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?mostrarTodos", -1).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.Read())
                {
                    persona = new Persona();
                    persona.id = data.GetInt32("id");
                    persona.ruc = data.getString("ruc");
                    persona.cedula = data.getString("cedula");
                    persona.razon_social = data.getString("razon_social");
                    persona.telefonos = data.getString("telefonos");
                    persona.direccion = data.getString("direccion");
                    persona.es_cliente = data.GetBoolean("es_cliente");
                    persona.es_empleado = data.GetBoolean("es_empleado");
                    persona.tipo_contrato = data.getString("tipo_contrato");
                    persona.sueldo = data.getDecimal("sueldo");
                    persona.email = data.getString("email");
                    persona.es_vendedor = data.GetBoolean("es_vendedor");
                    persona.id_contifico = data.getIntNull("id_contifico");
                    persona.porcentaje_descuento = data.getDecimal("porcentaje_descuento");
                    
                }
            }
            catch (Exception e) {
                throw e;
            }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                if (con != null) con.cerrar();
            }
            return persona;
        }

        public static List<ComboboxItem> obtenerVendedores()
        {
            List<ComboboxItem> vendedores = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion con = null;
            try
            {

                con = new Conexion();
                cmd = con.EjecutarSQL("empleado_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 5).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idi", null).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cedulai", String.Empty).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", String.Empty).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?mostrarTodos", -1).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    vendedores = new List<ComboboxItem>();
                    while(data.Read())
                    {
                        ComboboxItem item = new ComboboxItem();
                        item.Value = data.GetInt32("valor").ToString();
                        item.Text = data.getString("texto");
                        vendedores.Add(item);
                    }
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
            return vendedores;
        }

        public Persona buscarNombreId(string cedula, ref string mensaje)
        {
            Persona persona = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            try
            {


                cmd = this.conf.EjecutarSQL("empleado_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 3).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idi", null).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cedulai", String.Empty).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", String.Empty).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?mostrarTodos", -1).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.Read())
                {
                    persona = new Persona();
                    persona.id = data.GetInt32("id");
                    persona.razon_social= data.getString("razon_social");
                }
            }
            catch (Exception e) {
                persona = null;
                mensaje = e.Message; 
            }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                this.conf.cerrar();
            }
            return persona;
        }

        public bool insertarEmpleado(ref string mensaje)
        {
            bool resultado;
            MySqlCommand cmd = null;
            try
            {
                cmd = this.conf.EjecutarSQL("empleado_insertar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?ruci", this.persona.ruc);
                cmd.Parameters["?ruci"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?cedulai", this.persona.cedula);
                cmd.Parameters["?cedulai"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?razon_sociali", this.persona.razon_social);
                cmd.Parameters["?razon_sociali"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?telefonosi", this.persona.telefonos);
                cmd.Parameters["?telefonosi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?direccioni", this.persona.direccion);
                cmd.Parameters["?direccioni"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?tipoi", this.persona.tipo);
                cmd.Parameters["?tipoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?es_clientei", this.persona.es_cliente);
                cmd.Parameters["?es_clientei"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?es_empleadoi", this.persona.es_empleado);
                cmd.Parameters["?es_empleadoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?tipo_contratoi", this.persona.tipo_contrato);
                cmd.Parameters["?tipo_contratoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?sueldoi", this.persona.sueldo);
                cmd.Parameters["?sueldoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?emaili", this.persona.email);
                cmd.Parameters["?emaili"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?es_vendedori", this.persona.es_vendedor);
                cmd.Parameters["?es_vendedori"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?id_contificoi", this.persona.id_contifico);
                cmd.Parameters["?id_contificoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?porcentaje_descuentoi", this.persona.porcentaje_descuento);
                cmd.Parameters["?porcentaje_descuentoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add(new MySqlParameter("?id_persona", MySqlDbType.Int32));
                cmd.Parameters["?id_persona"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add(new MySqlParameter("?msn", MySqlDbType.VarChar));
                cmd.Parameters["?msn"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                if (!String.IsNullOrEmpty(cmd.Parameters["?id_persona"].Value.ToString()))
                {
                    this.persona.id = (int)cmd.Parameters["?id_persona"].Value;
                    resultado = true;
                }
                else
                {
                    mensaje = cmd.Parameters["?msn"].Value.ToString();
                    if (String.IsNullOrEmpty(mensaje)) mensaje = "Error del sistema, por favor intente más tarde.";
                    resultado = false;
                }

            }
            catch (Exception e)
            {
                mensaje = e.Message;
                resultado = false;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                this.conf.cerrar();
            }

            return resultado;

        }

        public bool actualizarEmpleado(ref string mensaje)
        {
            bool resultado = false;
            try
            {
                MySqlCommand cmd = this.conf.EjecutarSQL("empleado_actualizar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?idi", this.persona.id);
                cmd.Parameters["?idi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?ruci", this.persona.ruc);
                cmd.Parameters["?ruci"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?cedulai", this.persona.cedula);
                cmd.Parameters["?cedulai"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?razon_sociali", this.persona.razon_social);
                cmd.Parameters["?razon_sociali"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?telefonosi", this.persona.telefonos);
                cmd.Parameters["?telefonosi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?direccioni", this.persona.direccion);
                cmd.Parameters["?direccioni"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?tipo_contratoi", this.persona.tipo_contrato);
                cmd.Parameters["?tipo_contratoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?sueldoi", this.persona.sueldo);
                cmd.Parameters["?sueldoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?emaili", this.persona.email);
                cmd.Parameters["?emaili"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();
                resultado = true;

            }
            catch (Exception e) { mensaje = e.Message; }
            finally { this.conf.cerrar(); }
            return resultado;
        }

       
    }
}
