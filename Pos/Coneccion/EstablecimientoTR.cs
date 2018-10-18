using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pos.Clases;
using MySql.Data.MySqlClient;
using System.Data;

namespace Pos.Coneccion
{
    public class EstablecimientoTR
    {
        private Conexion conf;
        private string nombre_stp;
        private Establecimiento establecimiento;

        public EstablecimientoTR() {
            this.conf = new Conexion();
        }

        public EstablecimientoTR(Establecimiento establecimiento)
        {
            this.conf = new Conexion();
            this.establecimiento = establecimiento;
        }

        public EstablecimientoTR(string nombreStore)
        {
            this.conf = new Conexion();
            this.nombre_stp = nombreStore;
            this.establecimiento = new Establecimiento();
            
        }

        internal Conexion Conf
        {
            get { return conf; }
            set { conf = value; }
        }

        public string Nombre_stp
        {
            get { return nombre_stp; }
            set { nombre_stp = value; }
        }

        public DataTable consultarEstablecimientos(ref string mensaje, string nombre = "")
        {
            MySqlCommand cmd;
            DataSet datos = null;
            DataTable resultado = null;
            MySqlDataAdapter adapter = null;
            try
            {

                cmd = this.Conf.EjecutarSQL("establecimiento_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 1);
                cmd.Parameters["?opcion"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?idEstableciento", null);
                cmd.Parameters["?idEstableciento"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?nombrei",nombre);
                cmd.Parameters["?nombrei"].Direction = ParameterDirection.Input;

                adapter = new MySqlDataAdapter(cmd);
                datos = new DataSet();
                adapter.Fill(datos, "Establecimiento");
                resultado = datos.Tables["Establecimiento"];
            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                conf.cerrar();
                if (adapter != null) adapter.Dispose();
            }
            return resultado;
        }

        public DataTable consultarEstablecimiento(ref string mensaje)
        {
            MySqlCommand cmd;
            DataSet datos = null;
            DataTable resultado = null;
            MySqlDataAdapter adapter = null;
            try
            {

                cmd = this.Conf.EjecutarSQL("establecimiento_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 1);
                cmd.Parameters["?opcion"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?idEstableciento", null);
                cmd.Parameters["?idEstableciento"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?nombrei", String.Empty);
                cmd.Parameters["?nombrei"].Direction = ParameterDirection.Input;

                adapter = new MySqlDataAdapter(cmd);
                datos = new DataSet();
                adapter.Fill(datos, "Establecimiento");
                resultado = datos.Tables["Establecimiento"];
            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                conf.cerrar();
                if (adapter != null) adapter.Dispose();
            }
            return resultado;
        }

        public bool actualizarEstablecimiento(ref string mensaje)
        {
            bool resultado = false;
            try
            {
                MySqlCommand cmd = this.conf.EjecutarSQL("establecimiento_actualizar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?idEstablecimientoi", this.establecimiento.Idtbl_establecimiento);
                cmd.Parameters["?idEstablecimientoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?nombrei", this.establecimiento.Nombre);
                cmd.Parameters["?nombrei"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?direccioni", this.establecimiento.Direccion);
                cmd.Parameters["?direccioni"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?estadoi", 1);
                cmd.Parameters["?estadoi"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();
                resultado = true;

            }
            catch (Exception e) { mensaje = e.Message; }
            finally { this.conf.cerrar(); }
            return resultado;
        }

        public Establecimiento buscarXCodigo(string codigo, ref string mensaje)
        {
            Establecimiento establecimiento = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            try
            {

                cmd = this.conf.EjecutarSQL("establecimiento_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 2);
                cmd.Parameters["?opcion"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?idEstableciento", codigo);
                cmd.Parameters["?idEstableciento"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?nombrei", String.Empty);
                cmd.Parameters["?nombrei"].Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.Read())
                {
                    establecimiento = new Establecimiento();
                    establecimiento.Idtbl_establecimiento = data.GetInt32("id");
                    establecimiento.Nombre = data.GetString("nombre");
                    establecimiento.Direccion = data.GetString("direccion");
                }
            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                this.conf.cerrar();
            }
            return establecimiento;
        }

        public bool insertarEstablecimiento(ref string mensaje)
        {
            bool resultado = false;
             MySqlCommand cmd = null;
            try
            {
                cmd = this.Conf.EjecutarSQL("establecimiento_insertar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?idtbl_establecimientoi", this.establecimiento.Idtbl_establecimiento);
                cmd.Parameters["?idtbl_establecimientoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?nombrei", this.establecimiento.Nombre);
                cmd.Parameters["?nombrei"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?direccioni", this.establecimiento.Direccion);
                cmd.Parameters["?direccioni"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?estadoi", 1);
                cmd.Parameters["?estadoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add(new MySqlParameter("?msn", MySqlDbType.VarChar));
                cmd.Parameters["?msn"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                mensaje = cmd.Parameters["?msn"].Value.ToString();
                if (String.IsNullOrEmpty(mensaje)) resultado = true;                
            }
            catch (Exception e){mensaje = e.Message;}
            finally {
                this.Conf.cerrar();
                if (cmd != null) cmd.Dispose();
            }
            return resultado;
        }

    }
}
