using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pos.Clases;
using MySql.Data.MySqlClient;
using System.Data;

namespace Pos.Coneccion
{
    public class ConfiguracionPosTR
    {
        private Conexion conf;
        private string nombre_stp;
        private ConfiguracionPos pos;
 

        public ConfiguracionPosTR(ConfiguracionPos confPos)
        {
            this.conf = new Conexion();
            this.pos = confPos;
    
        }


        public ConfiguracionPosTR()
        {
            this.conf = new Conexion();

        }

        public string Nombre_stp
        {
            get { return nombre_stp; }
            set { nombre_stp = value; }
        }

        internal ConfiguracionPos Pos
        {
            get { return pos; }
            set { pos = value; }
        }

        public DataTable consultarConfiguraciones(ref string mensaje, string tipoDocumento)
        {
            MySqlCommand cmd = null;
            MySqlDataAdapter adapter = null;
            DataSet dataset = null;
            DataTable datos = null;
            try
            {
                cmd = this.conf.EjecutarSQL("confPos_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 1);
                cmd.Parameters["?opcion"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?idConfPosi", null);
                cmd.Parameters["?idConfPosi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?nombreMaquinai", General.getComputerName());
                cmd.Parameters["?nombreMaquinai"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?tipoDocumentoi", tipoDocumento);
                cmd.Parameters["?tipoDocumentoi"].Direction = ParameterDirection.Input;

                adapter = new MySqlDataAdapter(cmd);
                dataset = new DataSet();
                adapter.Fill(dataset, "configuracion");
                datos = dataset.Tables["configuracion"];
            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                conf.cerrar();
                if (adapter != null) adapter.Dispose();
                if (dataset != null) dataset.Dispose();
            }
            return datos;
        }

        public static bool existePredeterminada(int idExcluir = -1, string tipoDocumento = null)
        {
            return (ConfiguracionPosTR.idConfPredeterminada(idExcluir, tipoDocumento) != -1);
        }

        public static int idConfPredeterminada(int idExcluir = -1, string tipoDocumento = null)
        {
            int idConf = -1;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("confPos_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 3).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idConfPosi", idExcluir).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombreMaquinai", General.getComputerName()).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?tipoDocumentoi", tipoDocumento).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.Read()) { idConf = data.IsDBNull(0) ? -1 : data.GetInt32(0); }
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                if (con != null) con.cerrar();
            }
            return idConf;
        }

        public void refrescar()
        {
            if (this.conf == null) this.conf = new Conexion();
        }

        public List<string> validarRango(ref string mensaje)
        {
            List<string> resultado = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            try
            {

                cmd = this.conf.EjecutarSQL("confPos_validarSecuencia");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?establecimientoi", this.pos.Codigo_establecimiento).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cajai", this.pos.Pto_emision).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?secuenciaInicioi", this.pos.Sec_actual).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?secuenciaFini", this.pos.Sec_final).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?tipoDocumentoi", this.pos.Tipo_doc).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?emisioni", Convert.ToInt32(this.pos.Pto_emision)).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?autorizacioni", this.pos.Autorizacion).Direction = ParameterDirection.Input;

                cmd.Parameters.Add(new MySqlParameter("?msn", MySqlDbType.VarChar));
                cmd.Parameters["?msn"].Direction = ParameterDirection.Output;

                data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    resultado = new List<string>();
                    while (data.Read()) resultado.Add(data.GetString(0));
                }

                if (cmd.Parameters["?msn"].Value!=null) mensaje = cmd.Parameters["?msn"].Value.ToString();
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

        public ConfiguracionPos consultarConfiguracion(int idConfPos, ref string mensaje)
        {
            ConfiguracionPos configuracion = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            try
            {


                cmd = this.conf.EjecutarSQL("confPos_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 2).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idConfPosi", idConfPos).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombreMaquinai", General.getComputerName()).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?tipoDocumentoi", String.Empty).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.Read())
                {
                    configuracion = new ConfiguracionPos();
                    configuracion.Id_establecimiento = data.GetInt32("id_establecimiento");
                    configuracion.Nombre_Maquina = data.GetString("mac_address");
                    configuracion.Tipo_doc = data.GetString("tipo_doc");
                    configuracion.IdAutorizacion = data.GetInt32("autorizacion");
                    configuracion.Codigo_establecimiento = data.GetString("codigo_establecimiento");
                    configuracion.Pto_emision = data.GetString("pto_emision");
                    configuracion.Sec_inicio = data.GetInt32("sec_inicio");
                    configuracion.Sec_final = data.GetInt32("sec_final");
                    configuracion.Sec_actual = data.GetInt32("sec_actual");
                    configuracion.Stock = data.GetBoolean("stock");
                    configuracion.Activar_secuencia = data.GetBoolean("activar_secuencia");
                    configuracion.Servicio = data.GetBoolean("servicio");
                    configuracion.Sin_cobro = data.GetBoolean("sin_cobro");
                    configuracion.Predeterminada = data.GetBoolean("predeterminada");
                    configuracion.SecuenciaAlImprimir = data.GetBoolean("secuencia_imprimir");

                }
            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                this.conf.cerrar();
            }
            return configuracion;
        }

        public static ConfiguracionPos consultarConfiguracionPredeterminada(string nombreMaquina, ref string msn, string tipoDocumento = null)
        {
            ConfiguracionPos configuracion = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("confPos_predeterminada");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("?nombreMaquinai", nombreMaquina.Trim()).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?tipo_doci", tipoDocumento).Direction = ParameterDirection.Input;
                data = cmd.ExecuteReader();
                if (data.Read())
                {
                    configuracion = new ConfiguracionPos();
                    configuracion.Nombre_Maquina = nombreMaquina;
                    configuracion.Idconf_pos = data.GetInt32("idconf_pos");
                    configuracion.Id_establecimiento = data.GetInt32("id_establecimiento");
                    configuracion.Sec_inicio = data.GetInt32("sec_inicio");
                    configuracion.Sec_final = data.GetInt32("sec_final");
                    configuracion.Sec_actual = data.GetInt32("sec_actual");
                    configuracion.IdAutorizacion = !data.IsDBNull(data.GetOrdinal("idAutorizacion"))? data.GetInt32("idAutorizacion"): 0;
                    configuracion.Autorizacion = !data.IsDBNull(data.GetOrdinal("autorizacion"))? data.GetString("autorizacion") :"";
                    configuracion.Tipo_doc = data.GetString("tipo_doc");
                    configuracion.Codigo_establecimiento = data.GetString("codigo_establecimiento");
                    configuracion.Pto_emision = data.GetString("pto_emision");
                    configuracion.Secuencia_doc = data.GetString("secuencial");
                    configuracion.Sin_cobro = data.GetBoolean("sin_cobro");
                    configuracion.Stock = data.GetBoolean("stock");
                    configuracion.Servicio = data.GetBoolean("servicio");
                    configuracion.Activar_secuencia = data.GetBoolean("activar_secuencia");
                    configuracion.Predeterminada = data.GetBoolean("predeterminada");
                    configuracion.SecuenciaAlImprimir = data.GetBoolean("secuencia_imprimir");
                }
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                if (con != null) con.cerrar();
            }
            return configuracion;
        }


        public bool insertarConfPOS(ref string mensaje, int reemplazarPredeterminada)
        {
            MySqlCommand cmd = null;
            bool resultado = false;
            try
            {
                cmd = this.conf.EjecutarSQL("confPos_insertar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?id_establecimientoi", this.Pos.Id_establecimiento);
                cmd.Parameters["?id_establecimientoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?sec_inicioi", this.Pos.Sec_inicio);
                cmd.Parameters["?sec_inicioi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?sec_finali", this.Pos.Sec_final);
                cmd.Parameters["?sec_finali"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?sec_actuali", this.Pos.Sec_inicio);
                cmd.Parameters["?sec_actuali"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?secuencia_doci", this.Pos.Secuencia_doc);
                cmd.Parameters["?secuencia_doci"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?idautorizacioni", this.Pos.IdAutorizacion);
                cmd.Parameters["?idautorizacioni"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?mac_addressi", this.Pos.Nombre_Maquina);
                cmd.Parameters["?mac_addressi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?tipo_doci", this.Pos.Tipo_doc);
                cmd.Parameters["?tipo_doci"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?codigo_establecimientoi", this.Pos.Codigo_establecimiento);
                cmd.Parameters["?codigo_establecimientoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?pto_emisioni", this.Pos.Pto_emision);
                cmd.Parameters["?pto_emisioni"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?secuenciali", this.Pos.Secuencial);
                cmd.Parameters["?secuenciali"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?activai", this.Pos.Activa);
                cmd.Parameters["?activai"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?sin_cobroi", this.Pos.Sin_cobro);
                cmd.Parameters["?sin_cobroi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?stocki", this.Pos.Stock);
                cmd.Parameters["?stocki"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?servicioi", this.Pos.Servicio);
                cmd.Parameters["?servicioi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?activar_secuenciai", this.Pos.Activar_secuencia);
                cmd.Parameters["?activar_secuenciai"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?predeterminadai", this.Pos.Predeterminada);
                cmd.Parameters["?predeterminadai"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?reemplazarPredeterminadai", reemplazarPredeterminada);
                cmd.Parameters["?reemplazarPredeterminadai"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?secenciaImprimiri", this.Pos.SecuenciaAlImprimir);
                cmd.Parameters["?secenciaImprimiri"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?idconf", MySqlDbType.Int32);
                cmd.Parameters["?idconf"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("?msn", MySqlDbType.VarChar);
                cmd.Parameters["?msn"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                if (!String.IsNullOrEmpty(cmd.Parameters["?idconf"].Value.ToString()))
                {
                    this.Pos.Idconf_pos = (int)cmd.Parameters["?idconf"].Value;
                    resultado = true;
                }
                else
                {
                    mensaje = cmd.Parameters["?msn"].Value.ToString();
                    if (String.IsNullOrEmpty(mensaje)) mensaje = "Error del sistema, por favor intente más tarde.";
                }
            }
            catch (Exception e){mensaje = e.Message;}
            finally{
                conf.cerrar();
                if (cmd != null) cmd.Dispose();
            }
            return resultado;
        }

        public bool actualizarConfPOS(ref string mensaje, int reemplazarPredeterminada)
        {

            bool resultado = false;
            try
            {
                MySqlCommand cmd = this.conf.EjecutarSQL("confPos_actualizar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?idPos", this.Pos.Idconf_pos);
                cmd.Parameters["?idPos"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?id_establecimientoi", this.Pos.Id_establecimiento);
                cmd.Parameters["?id_establecimientoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?sec_inicioi", this.Pos.Sec_inicio);
                cmd.Parameters["?sec_inicioi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?sec_finali", this.Pos.Sec_final);
                cmd.Parameters["?sec_finali"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?sec_actuali", this.Pos.Sec_actual);
                cmd.Parameters["?sec_actuali"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?secuencia_doci", this.Pos.Secuencia_doc);
                cmd.Parameters["?secuencia_doci"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?idautorizacioni", this.Pos.IdAutorizacion);
                cmd.Parameters["?idautorizacioni"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?mac_addressi", this.Pos.Nombre_Maquina);
                cmd.Parameters["?mac_addressi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?tipo_doci", this.Pos.Tipo_doc);
                cmd.Parameters["?tipo_doci"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?codigo_establecimientoi", this.Pos.Codigo_establecimiento);
                cmd.Parameters["?codigo_establecimientoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?pto_emisioni", this.Pos.Pto_emision);
                cmd.Parameters["?pto_emisioni"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?secuenciali", this.Pos.Secuencial);
                cmd.Parameters["?secuenciali"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?activai", this.Pos.Activa);
                cmd.Parameters["?activai"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?sin_cobroi", this.Pos.Sin_cobro);
                cmd.Parameters["?sin_cobroi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?stocki", this.Pos.Stock);
                cmd.Parameters["?stocki"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?servicioi", this.Pos.Servicio);
                cmd.Parameters["?servicioi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?activar_secuenciai", this.Pos.Activar_secuencia);
                cmd.Parameters["?activar_secuenciai"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?predeterminadai", this.Pos.Predeterminada);
                cmd.Parameters["?predeterminadai"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?secuenciaImprimiri", this.Pos.SecuenciaAlImprimir);
                cmd.Parameters["?secuenciaImprimiri"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?reemplazarPredeterminadai", reemplazarPredeterminada);
                cmd.Parameters["?reemplazarPredeterminadai"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception e) { mensaje = e.Message; }
            finally { this.conf.cerrar(); }
            return resultado;
            
        }

        public void eliminarConfPOS()
        {
            MySqlCommand cmd = this.conf.EjecutarSQL(this.Nombre_stp);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("?idPos", this.Pos.Idconf_pos);
            cmd.Parameters["?idPos"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?estado", this.Pos.Activa);
            cmd.Parameters["?estado"].Direction = ParameterDirection.Input;

            cmd.ExecuteNonQuery();
            this.conf.cerrar();
        }

        public int validarConfiguracionPOS()
        {
            int cont = 0;
            MySqlCommand cmd = this.conf.EjecutarSQL(this.Nombre_stp);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("?macAddress", this.Pos.Nombre_Maquina);
            cmd.Parameters["?macAddress"].Direction = ParameterDirection.Input;

            MySqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                cont++;
            }
            this.conf.cerrar();
            return cont;
        }

        public static void actualizarNumeroActual(int idConfPos, int secuenciaActual, string tipo, ref string mensaje)
        {
            try
            {
                Conexion con = new Conexion();
                MySqlCommand cmd = con.EjecutarSQL("actualizar_NumeroActual");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("?idPos", idConfPos).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?sec_actuali", secuenciaActual).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?tipoi", tipo).Direction = ParameterDirection.Input;
                cmd.Parameters.Add(new MySqlParameter("?msn", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                mensaje = cmd.Parameters["?msn"].Value.ToString();
                con.cerrar();
            }
            catch (Exception e)
            {
                Mensaje.advertencia(e.Message);
            }
        }

        public static void actualizarNumeroGuia(int idConfPos, int secuenciaActual, ref string mensaje)
        {
            try
            {
                Conexion con = new Conexion();
                MySqlCommand cmd = con.EjecutarSQL("guiaRemision_actualizarSecuencia");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("?idPos", idConfPos).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?sec_actuali", secuenciaActual).Direction = ParameterDirection.Input;
                cmd.Parameters.Add(new MySqlParameter("?msn", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                mensaje = cmd.Parameters["?msn"].Value.ToString();
                con.cerrar();
            }
            catch (Exception e)
            {
                Mensaje.advertencia(e.Message);
            }
        }

    }
}
