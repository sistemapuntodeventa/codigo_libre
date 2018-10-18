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
    public class UsuarioTR
    {
        private Conexion conf;
        private Usuario usuario;

        public UsuarioTR()
        {
            this.conf = new Conexion();

        }

        public UsuarioTR(Usuario usuario)
        {
            this.usuario = usuario;
            this.conf = new Conexion();
        }

        public DataTable consultarUsuarios(ref string mensaje, string nombre, int idRol)
        {
            MySqlCommand cmd;
            DataSet datos = null;
            DataTable resultado = null;
            MySqlDataAdapter adapter = null;
            try
            {
                cmd = this.conf.EjecutarSQL("usuario_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 1);
                cmd.Parameters["?opcion"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?id_usuarioi", -1);
                cmd.Parameters["?id_usuarioi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?nombrei", nombre);
                cmd.Parameters["?nombrei"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?cedulai", string.Empty);
                cmd.Parameters["?cedulai"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?idRoli", idRol);
                cmd.Parameters["?idRoli"].Direction = ParameterDirection.Input;

                adapter = new MySqlDataAdapter(cmd);
                datos = new DataSet();
                adapter.Fill(datos, "usuarios");
                resultado = datos.Tables["usuarios"];
            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                conf.cerrar();
                if (adapter != null) adapter.Dispose();
            }
            return resultado;
        }

        public Usuario buscarXId(int idUsuario, ref string mensaje)
        {
            Usuario usuario = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            try
            {

                cmd = this.conf.EjecutarSQL("usuario_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 2);
                cmd.Parameters["?opcion"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?id_usuarioi", idUsuario);
                cmd.Parameters["?id_usuarioi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?nombrei", string.Empty);
                cmd.Parameters["?nombrei"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?cedulai", string.Empty);
                cmd.Parameters["?cedulai"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?idRoli", -1);
                cmd.Parameters["?idRoli"].Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.Read())
                {
                    usuario = new Usuario();
                    usuario.Idtbl_usuario = (data.IsDBNull(data.GetOrdinal("id")))?0:data.GetInt16("id");
                    usuario.Id_Rol = (data.IsDBNull(data.GetOrdinal("idRol"))) ? 0 : data.GetInt16("idRol");
                    usuario.Cedula_Empleado = (data.IsDBNull(data.GetOrdinal("cedula"))) ? "" : data.GetString("cedula");
                    usuario.Nombre_Empleado = (data.IsDBNull(data.GetOrdinal("nombre"))) ? "" : data.GetString("nombre");
                    usuario.User = (data.IsDBNull(data.GetOrdinal("usuario"))) ? "" : data.GetString("usuario");
                    usuario.Password = (data.IsDBNull(data.GetOrdinal("password"))) ? "" : data.GetString("password");
                    usuario.Estado = (data.IsDBNull(data.GetOrdinal("estado"))) ? false: data.GetBoolean("estado");
                }
            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                this.conf.cerrar();
            }
            return usuario;
        }

        public Usuario buscarXCedula(string cedula, ref string mensaje)
        {
            Usuario usuario = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            try
            {

                cmd = this.conf.EjecutarSQL("usuario_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 3);
                cmd.Parameters["?opcion"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?id_usuarioi", -1);
                cmd.Parameters["?id_usuarioi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?nombrei", string.Empty);
                cmd.Parameters["?nombrei"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?cedulai", cedula);
                cmd.Parameters["?cedulai"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?idRoli", -1);
                cmd.Parameters["?idRoli"].Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.Read())
                {
                    usuario = new Usuario();
                    usuario.Idtbl_usuario = data.GetInt16("id");
                    usuario.Id_Rol = data.GetInt16("idRol");
                    usuario.Nombre_Empleado = data.GetString("nombre");
                    usuario.User = data.GetString("usuario");
                    usuario.Password = data.GetString("password");
                    usuario.Estado = data.GetBoolean("estado");
                }
            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                this.conf.cerrar();
            }
            return usuario;
        }

        public bool insertarUsuario(ref string mensaje)
        {
            bool resultado = false;
            MySqlCommand cmd = null;
            try
            {
                cmd = this.conf.EjecutarSQL("usuario_insertar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?id_roli", this.usuario.Id_Rol);
                cmd.Parameters["?id_roli"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?id_empleadoi", this.usuario.Id_Empleado);
                cmd.Parameters["?id_empleadoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?usuarioi", this.usuario.User);
                cmd.Parameters["?usuarioi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?passwordi", this.usuario.Password);
                cmd.Parameters["?passwordi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?estadoi", this.usuario.Estado);
                cmd.Parameters["?estadoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add(new MySqlParameter("?idUsuario", MySqlDbType.Int32));
                cmd.Parameters["?idUsuario"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add(new MySqlParameter("?msn", MySqlDbType.VarChar));
                cmd.Parameters["?msn"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                if (!String.IsNullOrEmpty(cmd.Parameters["?idUsuario"].Value.ToString())){
                    this.usuario.Idtbl_usuario = (int)cmd.Parameters["?idUsuario"].Value;
                    resultado = true;
                }
                else {
                    mensaje = cmd.Parameters["?msn"].Value.ToString();
                    if (String.IsNullOrEmpty(mensaje)) mensaje = "Error del sistema, por favor intente más tarde.";
                }
            }
            catch (Exception e) { mensaje = e.Message; }
            finally {
                conf.cerrar();
                if (cmd != null) cmd.Dispose();
            }
            return resultado;
        }

        public bool actualizarUsuario(ref string mensaje)
        {
            bool resultado = false;
            try
            {
                MySqlCommand cmd = this.conf.EjecutarSQL("usuario_actualizar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?id_usuarioi", this.usuario.Idtbl_usuario);
                cmd.Parameters["?id_usuarioi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?id_roli", this.usuario.Id_Rol);
                cmd.Parameters["?id_roli"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?usuarioi", this.usuario.User);
                cmd.Parameters["?usuarioi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?passwordi", this.usuario.Password);
                cmd.Parameters["?passwordi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?estadoi", this.usuario.Estado);
                cmd.Parameters["?estadoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add(new MySqlParameter("?msn", MySqlDbType.VarChar));
                cmd.Parameters["?msn"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
  
                mensaje = cmd.Parameters["?msn"].Value.ToString();
                if (String.IsNullOrEmpty(mensaje)) resultado = true;

            }
            catch (Exception e) { mensaje = e.Message; }
            finally { this.conf.cerrar(); }
            return resultado;
        }

        public bool eliminarUsuario(int idUsuario, ref string mensaje)
        {
            MySqlCommand cmd = this.conf.EjecutarSQL("usuario_eliminar");
            bool estado = false;
            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("?idUsuario", idUsuario);
                cmd.Parameters["?idUsuario"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add(new MySqlParameter("?msn", MySqlDbType.VarChar));
                cmd.Parameters["?msn"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                mensaje = cmd.Parameters["?msn"].Value.ToString();
                if(String.IsNullOrEmpty(mensaje))estado = true;

            }
            catch (Exception e){mensaje = e.Message;}
            finally
            {
                this.conf.cerrar();
                if (cmd != null) cmd.Dispose();
            }
            return estado;
        }

        public bool esUsuarioValido(ref string mensaje, string user, string password)
        {
            bool resultado = false;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            try
            {
                cmd = this.conf.EjecutarSQL("usuario_validarIngreso");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?usuarioi", user).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?contrasenai", password).Direction = ParameterDirection.Input;

                 data = cmd.ExecuteReader();
                 if (data.Read())
                 {  
                     Global.idEmpleado = data.GetInt16("idEmpleado");
                     Global.logIdUser = data.GetInt16("idUsuario");
                     Global.idRol = data.GetInt16("idRol");
                     Global.api = data.getString("api");
                     resultado = true;
                 }

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

        public static Usuario consultarUsuario(string user, string password)
        {
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion con = null;
            Usuario usuario = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("usuario_validarIngreso");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?usuarioi", user).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?contrasenai", password).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.Read())
                {
                    usuario = new Usuario();
                    usuario.Id_Empleado = data.GetInt16("idEmpleado");
                    usuario.Idtbl_usuario = data.GetInt16("idUsuario");
                    usuario.Id_Rol = data.GetInt16("idRol");
                }

            }
            catch (Exception e) { throw e; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                con.cerrar();
            }
            return usuario;
        }

    }
}
