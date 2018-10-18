using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Pos.Clases;
using System.Data;
using System.Xml;
using System.Windows.Forms;
using Pos.App;

namespace Pos.Coneccion
{
    public class ClienteTR
    {
        private Conexion conf;
        private Persona cliente;
        
        public ClienteTR()
        {
            this.conf = new Conexion();

        }

        public ClienteTR(Persona persona)
        {
            this.cliente = persona;
            this.conf = new Conexion();
        }

        public Conexion Conf
        {
            get { return conf; }
            set { conf = value; }
        }

        public DataTable consultarClientes(ref string mensaje, string nombre, string cedula, int nRegistros)
        {
            MySqlCommand cmd;
            DataSet datos = null;
            DataTable resultado = null;
            MySqlDataAdapter adapter = null;
            try
            {
                cmd = this.conf.EjecutarSQL("cliente_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idClientei", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", nombre).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cedulai", cedula).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nRegistros", (nRegistros != -1) ? nRegistros : int.MaxValue).Direction = ParameterDirection.Input;

                adapter = new MySqlDataAdapter(cmd);
                datos = new DataSet();
                adapter.Fill(datos, "clientes");
                resultado = datos.Tables["clientes"];
            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                conf.cerrar();
                if (adapter != null) adapter.Dispose();
            }
            return resultado;
        }

        public DataTable consultarClientesSeleccion(ref string mensaje, string nombre, string cedula, int nRegistros)
        {
            MySqlCommand cmd;
            DataSet datos = null;
            DataTable resultado = null;
            MySqlDataAdapter adapter = null;
            try
            {
                cmd = this.conf.EjecutarSQL("cliente_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 3).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idClientei", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", nombre).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cedulai", cedula).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nRegistros", (nRegistros != -1) ? nRegistros : int.MaxValue).Direction = ParameterDirection.Input;

                adapter = new MySqlDataAdapter(cmd);
                datos = new DataSet();
                adapter.Fill(datos, "clientes");
                resultado = datos.Tables["clientes"];
            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                conf.cerrar();
                if (adapter != null) adapter.Dispose();
            }
            return resultado;
        }

        public Persona consultarUsuarioFinal(ref string mensaje)
        {
            Persona persona = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            try
            {
                cmd = this.conf.EjecutarSQL("cliente_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 5).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idClientei", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cedulai", String.Empty).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", String.Empty).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nRegistros", -1).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.Read())
                {
                    persona = new Persona();
                    persona.id = data.getInt("id");
                    persona.cedula = data.getString("cedula");
                    persona.razon_social = data.getString("razon_social");
                    persona.telefonos = data.getString("telefonos");
                    persona.direccion = data.getString("direccion");
                    persona.porcentaje_descuento = data.getDecimal("porcentaje_descuento");
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

        public static Persona buscarXCedula(string cedula)
        {
            Persona persona = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("cliente_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 2).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idClientei", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cedulai", cedula).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", String.Empty).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nRegistros", -1).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.Read())
                {
                    persona = new Persona();
                    persona.id= data.GetInt32("id");
                    persona.ruc = data.getString("ruc");
                    persona.cedula = data.getString("cedula");
                    persona.razon_social = data.getString("razon_social");
                    persona.codigo = data.getString("codigo");
                    persona.telefonos = data.getString("telefonos");
                    persona.direccion = data.getString("direccion");
                    persona.tipo = data.getString("tipo");
                    persona.es_cliente = data.GetBoolean("es_cliente");
                    persona.es_empleado = data.GetBoolean("es_empleado");
                    persona.es_extranjero = data.GetBoolean("es_extranjero");
                    persona.tipo_contrato = data.getString("tipo_contrato");
                    persona.sueldo = data.getDecimalNull("sueldo");
                    persona.email = data.getString("email");
                    persona.es_vendedor = data.GetBoolean("es_vendedor");
                    persona.id_contifico = data.getIntNull("id_contifico");
                    persona.bloqueado = data.getBoolean("bloqueado");//sk4
                    persona.porcentaje_descuento =  data.getDecimal("porcentaje_descuento");
                    persona.tiene_deuda = data.getBoolean("deuda");
                    
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

        public static Persona buscarXId(int idCliente)
        {
            Persona persona = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("cliente_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("?opcion", 4).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idClientei", idCliente).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cedulai", String.Empty).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", String.Empty).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nRegistros", -1).Direction = ParameterDirection.Input;
                data = cmd.ExecuteReader();
                if (data.Read())
                {
                    persona = new Persona();
                    persona.id = data.GetInt32("id");
                    persona.ruc = data.getString("ruc");
                    persona.cedula = data.getString("cedula");
                    persona.razon_social = data.getString("razon_social");
                    persona.codigo = data.getString("codigo");
                    persona.telefonos = data.getString("telefonos");
                    persona.direccion = data.getString("direccion");
                    persona.porcentaje_descuento = data.getDecimal("porcentaje_descuento");
                    persona.tiene_deuda = data.getBoolean("deuda");
                    persona.bloqueado = data.getBoolean("bloqueado");
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

        public bool insertarCliente(ref string mensaje)
        {
            bool resultado = false;
            MySqlCommand cmd = null;
            try
            {
                cmd = this.conf.EjecutarSQL("cliente_insertar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("?ruci", this.cliente.ruc).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cedulai", this.cliente.cedula).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?razon_sociali", this.cliente.razon_social).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?codigoi", this.cliente.codigo).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?telefonosi", this.cliente.telefonos).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?direccioni", this.cliente.direccion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?tipoi", this.cliente.tipo).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?es_clientei", this.cliente.es_cliente).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?es_empleadoi", this.cliente.es_empleado).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?tipo_contratoi", this.cliente.tipo_contrato).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?sueldoi", this.cliente.sueldo).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?emaili", this.cliente.email).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?es_vendedori", this.cliente.es_vendedor).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?id_contificoi", this.cliente.id_contifico).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?porcentaje_descuentoi", this.cliente.porcentaje_descuento).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?es_extranjeroi", this.cliente.es_extranjero).Direction = ParameterDirection.Input;

                cmd.Parameters.Add(new MySqlParameter("?id_persona", MySqlDbType.Int32));
                cmd.Parameters["?id_persona"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add(new MySqlParameter("?msn", MySqlDbType.VarChar));
                cmd.Parameters["?msn"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                if (!String.IsNullOrEmpty(cmd.Parameters["?id_persona"].Value.ToString()))
                {
                    this.cliente.id = (int)cmd.Parameters["?id_persona"].Value;
                    resultado = true;
                }
                else
                {
                    mensaje = cmd.Parameters["?msn"].Value.ToString();
                    if (String.IsNullOrEmpty(mensaje)) mensaje = "Error del sistema, por favor intente más tarde.";
                }

            }
            catch (Exception e) {mensaje = e.Message;}
            finally
            {
                this.conf.cerrar();
                if (cmd != null) cmd.Dispose();
            }
            return resultado;
        }


      
        public bool actualizarCliente(ref string mensaje)
        {
            bool resultado = false;
            try
            {
                MySqlCommand cmd = this.conf.EjecutarSQL("cliente_actualizar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?idi", this.cliente.id).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?razon_sociali", this.cliente.razon_social).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?codigoi", this.cliente.codigo).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?telefonosi", this.cliente.telefonos).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?direccioni", this.cliente.direccion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?emaili", this.cliente.email).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?es_extranjeroi", this.cliente.es_extranjero).Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();
                resultado = true;

            }
            catch (Exception e) { mensaje = e.Message; }
            finally { this.conf.cerrar(); }
            return resultado;
        }
        
    }
}
