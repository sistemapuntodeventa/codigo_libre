using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pos.Clases;
using MySql.Data.MySqlClient;
using System.Data;

namespace Pos.Coneccion
{
    public class RolUsuarioTR
    {
        private Conexion conf;
        private string nombre_stp;
        private Rol rol;
        
        public RolUsuarioTR(string nombreStore)
        {
            this.conf = new Conexion();
            this.nombre_stp = nombreStore;
            this.rol = new Rol();
        }

        public Conexion Conf
        {
            get { return conf; }
            set { conf = value; }
        }

        public string Nombre_stp
        {
            get { return nombre_stp; }
            set { nombre_stp = value; }
        }

        internal Rol Rol
        {
            get { return rol; }
            set { rol = value; }
        }

        public void insertarRol()
        {
            MySqlCommand cmd = this.Conf.EjecutarSQL(this.Nombre_stp);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("?nombrei", this.Rol.Nombre);
            cmd.Parameters["?nombrei"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?estadoi", this.Rol.Estado);
            cmd.Parameters["?estadoi"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?idRol", MySqlDbType.Int32);
            cmd.Parameters["?idRol"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            this.Conf.cerrar();
            this.Rol.Idrol_usuario = (int)cmd.Parameters["?idRol"].Value;
        }

        public MySqlDataAdapter consultarRolUsuario()
        {
            MySqlCommand cmd = this.Conf.EjecutarSQL(this.Nombre_stp);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("?idRol", this.Rol.Idrol_usuario);
            cmd.Parameters["?idRol"].Direction = ParameterDirection.Input;
            return (new MySqlDataAdapter(cmd));
        }


        public void consultarRol()
        {
            int cont = 0;
            MySqlCommand cmd = this.Conf.EjecutarSQL(this.Nombre_stp);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("?idRol", this.Rol.Idrol_usuario);
            cmd.Parameters["?idRol"].Direction = ParameterDirection.Input;
            
            MySqlDataReader data = cmd.ExecuteReader(); 
            
            while (data.Read())
            {
                this.Rol.Idrol_usuario = data.GetInt32(0);
                this.Rol.Nombre = data.GetString(1);
                this.rol.Estado=data.GetBoolean(2);
                cont++;
            }
            if (cont == 0) { this.rol.Idrol_usuario = 0; }
        }

        public void actualizarRol()
        {
            MySqlCommand cmd = this.Conf.EjecutarSQL(this.Nombre_stp);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("?idRol", this.Rol.Idrol_usuario);
            cmd.Parameters["?idRol"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?nombrei", this.Rol.Nombre);
            cmd.Parameters["?nombrei"].Direction = ParameterDirection.Input;            
            
            cmd.ExecuteNonQuery();
            this.Conf.cerrar();
           
        }

        public void eliminarRol()
        {
            MySqlCommand cmd = this.Conf.EjecutarSQL(this.Nombre_stp);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("?idRol", this.Rol.Idrol_usuario);
            cmd.Parameters["?idRol"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?estadoi", this.Rol.Estado);
            cmd.Parameters["?estadoi"].Direction = ParameterDirection.Input;

            cmd.ExecuteNonQuery();
            this.Conf.cerrar();

        }

    }
}
