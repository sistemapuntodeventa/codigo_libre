using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pos.Clases;
using MySql.Data.MySqlClient;
using System.Data;

namespace Pos.Coneccion
{
    public class AutorizacionTR
    {
        private Conexion conf;
        private string nombre_stp;
        private Autorizacion autorizacion;

        public AutorizacionTR()
        {
            this.conf = new Conexion();
        }

        public AutorizacionTR(Autorizacion autorizacion)
        {
            this.conf = new Conexion();
            this.autorizacion = autorizacion;
        }

        public AutorizacionTR(string nombreStore)
        {
            this.conf = new Conexion();
            this.nombre_stp = nombreStore;
            this.autorizacion = new Autorizacion();
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

        public Autorizacion Autorizacion
        {
            get { return autorizacion; }
            set { autorizacion = value; }
        }

        public DataTable consultarAutorizaciones(ref string mensaje, int codigoEstablecimiento, int estado)
        {
            MySqlCommand cmd;
            DataSet datos = null;
            DataTable resultado = null;
            MySqlDataAdapter adapter = null;
            try
            {
                cmd = this.conf.EjecutarSQL("autorizacion_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 1);
                cmd.Parameters["?opcion"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?id_establecimientoi", codigoEstablecimiento);
                cmd.Parameters["?id_establecimientoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?estadoi", estado);
                cmd.Parameters["?estadoi"].Direction = ParameterDirection.Input;

                adapter = new MySqlDataAdapter(cmd);
                datos = new DataSet();
                adapter.Fill(datos, "autorizacion");
                resultado = datos.Tables["autorizacion"];
            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                conf.cerrar();
                if (adapter != null) adapter.Dispose();
            }
            return resultado;
        }

        public Autorizacion consultarSecuencias(ref string mensaje, int idAutorizacion)
        {
            Autorizacion autorizacion = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            try
            {

                cmd = this.conf.EjecutarSQL("autorizacion_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 4);
                cmd.Parameters["?opcion"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?id_establecimientoi", idAutorizacion);
                cmd.Parameters["?id_establecimientoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?estadoi", null);
                cmd.Parameters["?estadoi"].Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.Read())
                {
                    autorizacion = new Autorizacion();
                    autorizacion.SecuenciaInicio = data.GetString("secuencia_inicio");
                    autorizacion.SecuenciaFin = data.GetString("secuencia_fin");

                }
            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                this.conf.cerrar();
            }
            return autorizacion; 
        }

        public Autorizacion buscarXId(int idAutorizacion, ref string mensaje)
        {
            Autorizacion autorizacion = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            try
            {

                cmd = this.conf.EjecutarSQL("autorizacion_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 2);
                cmd.Parameters["?opcion"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?id_establecimientoi", idAutorizacion);
                cmd.Parameters["?id_establecimientoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?estadoi", null);
                cmd.Parameters["?estadoi"].Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.Read())
                {
                    autorizacion = new Autorizacion();
                    autorizacion.Idtbl_autorizacion = data.GetInt32("idtbl_autorizacion");
                    autorizacion.Id_Establecimiento = data.GetInt32("id_establecimiento");
                    autorizacion.NumeroAutorizacion = data.GetString("autorizacion");
                    autorizacion.FechaVencimiento = data.GetDateTime("fecha_vencimiento");
                    autorizacion.SecuenciaInicio = data.GetString("secuencia_inicio");
                    autorizacion.SecuenciaFin = data.GetString("secuencia_fin");
             
                }
            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                this.conf.cerrar();
            }
            return autorizacion;
        }

        public DataTable consultarAutorizacion(int idEstablecimiento, ref string mensaje)
        {
            MySqlCommand cmd;
            DataSet datos = null;
            DataTable resultado = null;
            MySqlDataAdapter adapter = null;
            try
            {
                cmd = this.Conf.EjecutarSQL("autorizacion_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 3);
                cmd.Parameters["?opcion"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?id_establecimientoi", idEstablecimiento);
                cmd.Parameters["?id_establecimientoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?estadoi", 1);
                cmd.Parameters["?estadoi"].Direction = ParameterDirection.Input;

                adapter = new MySqlDataAdapter(cmd);
                datos = new DataSet();
                adapter.Fill(datos, "Autorizacion");
                resultado = datos.Tables["Autorizacion"];

            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                conf.cerrar();
                if (adapter != null) adapter.Dispose();
            }
            return resultado;
        }

        public bool insertarAutorizacion(ref string mensaje)
        {
            MySqlCommand cmd = null;
            Boolean resultado = false;
            try
            {
                cmd = this.Conf.EjecutarSQL("autorizacion_insertar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?id_establecimientoi", this.Autorizacion.Id_Establecimiento);
                cmd.Parameters["?id_establecimientoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?autorizacioni", this.Autorizacion.NumeroAutorizacion);
                cmd.Parameters["?autorizacioni"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?fechaVencimientoi", this.Autorizacion.FechaVencimiento);
                cmd.Parameters["?fechaVencimientoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?secuenciaInicioi", this.Autorizacion.SecuenciaInicio);
                cmd.Parameters["?secuenciaInicioi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?secuenciaFini", this.Autorizacion.SecuenciaFin);
                cmd.Parameters["?secuenciaFini"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?estadoi", this.Autorizacion.Estado);
                cmd.Parameters["?estadoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add(new MySqlParameter("?msn", MySqlDbType.VarChar));
                cmd.Parameters["?msn"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                mensaje = cmd.Parameters["?msn"].Value.ToString();
                if (String.IsNullOrEmpty(mensaje)) resultado = true;

            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                this.conf.cerrar();
                if (cmd != null) cmd.Dispose();
            }
            return resultado;
        }


        public bool actualizarAutorizacion(ref string mensaje)
        {
            bool resultado = false;
            try
            {
                MySqlCommand cmd = this.conf.EjecutarSQL("autorizacion_actualizar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?idtbl_autorizacioni", this.Autorizacion.Idtbl_autorizacion);
                cmd.Parameters["?idtbl_autorizacioni"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?id_establecimientoi", this.Autorizacion.Id_Establecimiento);
                cmd.Parameters["?id_establecimientoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?autorizacioni", this.Autorizacion.NumeroAutorizacion);
                cmd.Parameters["?autorizacioni"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?fechaVencimientoi", this.Autorizacion.FechaVencimiento);
                cmd.Parameters["?fechaVencimientoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?secuenciaInicioi", this.Autorizacion.SecuenciaInicio);
                cmd.Parameters["?secuenciaInicioi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?secuenciaFini", this.Autorizacion.SecuenciaFin);
                cmd.Parameters["?secuenciaFini"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?estadoi", this.Autorizacion.Estado);
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


    }
}
