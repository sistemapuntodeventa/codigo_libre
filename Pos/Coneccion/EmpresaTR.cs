using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pos.Clases;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace Pos.Coneccion
{
    public class EmpresaTR
    {
        private Conexion conf;
        private Empresa empresa;

        public EmpresaTR(Empresa empresa)
        {
            this.empresa = empresa;
            this.conf = new Conexion();
        }

        public EmpresaTR()
        {
            this.conf = new Conexion();
        }

        public static void ejecutarPrueba()
        {
            string lineaConexion = "Server=localhost;Database=pos_contifico;Uid=root;Pwd=root;Port=3306";
            MySqlConnection conexion = new MySqlConnection(lineaConexion);
            conexion.Open();
            MySqlTransaction tran = conexion.BeginTransaction();

            try
            {
                MySqlCommand cmd = new MySqlCommand("prueba", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Transaction = tran;
                cmd.Parameters.AddWithValue("?nombrei", "hooa");
                cmd.Parameters["?nombrei"].Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?valori", 1);
                cmd.Parameters["?valori"].Direction = ParameterDirection.Input;
                cmd.ExecuteNonQuery();

                cmd.CommandText = "prueba";
                cmd.Parameters["?nombrei"].Value = "nombre";
                cmd.Parameters["?valori"].Value = 1;
                cmd.ExecuteNonQuery();
                //MySqlCommand cmd1 = new MySqlCommand("prueba", conexion);
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.Transaction = tran;
                //cmd.Parameters.AddWithValue("?nombrei", "hooa");
                //cmd.Parameters["?nombrei"].Direction = ParameterDirection.Input;
                //cmd.Parameters.AddWithValue("?valori", 2);
                //cmd.Parameters["?valori"].Direction = ParameterDirection.Input;
                //cmd.ExecuteNonQuery();

                tran.Commit();
                conexion.Close();
            }
            catch(Exception e)
            {
                tran.Rollback();
                Mensaje.error(e.Message);
            }
        }

        public bool insertarEmpresa(ref string mensaje)
        {
            MySqlCommand cmd = null;
            bool resultado = false;

            try
            {
                cmd = this.conf.EjecutarSQL("empresa_insertar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?idtbl_empresai", this.empresa.Idtbl_empresa);
                cmd.Parameters["?idtbl_empresai"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?ruci", this.empresa.Ruc);
                cmd.Parameters["?ruci"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?razon_sociali", this.empresa.Razon_social);
                cmd.Parameters["?razon_sociali"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?telefonosi", this.empresa.Telefonos);
                cmd.Parameters["?telefonosi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?direccioni", this.empresa.Direccion);
                cmd.Parameters["?direccioni"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?bodegai", this.empresa.Bodega);
                cmd.Parameters["?bodegai"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?decimalesi", this.empresa.NumeroDecimales);
                cmd.Parameters["?decimalesi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?id_consumidorFinali", this.empresa.IdConsumidorFinal);
                cmd.Parameters["?id_consumidorFinali"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?clave_generadai", this.empresa.ClaveGenerada);
                cmd.Parameters["?clave_generadai"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?id_cuentaCajai", this.empresa.IdCaja);
                cmd.Parameters["?id_cuentaCajai"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();
                resultado = true;
                this.conf.cerrar();
            }
            catch (Exception e) { mensaje = e.Message; }
            finally {
                if (cmd != null) cmd.Dispose();
                conf.cerrar();
            }
            return resultado;
        }

        public int obtenerIdEmpresa(ref string mensaje)
        {
            int idEmpresa = -1;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            try
            {
                cmd = this.conf.EjecutarSQL("empresa_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 1);
                cmd.Parameters["?opcion"].Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.Read()) idEmpresa = data.GetInt16(0);
     
            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                this.conf.cerrar();
            }
            return idEmpresa;
        }

        public static bool llenarDatosGlobales(ref string mensaje)
        {
            bool resultado = false;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion conf = new Conexion();
            try
            {
                cmd = conf.EjecutarSQL("parametro_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("?opcion", 3).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idi", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", "1,3").Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if(data.HasRows)
                {
                    if (data.Read()) Global.cantidadDecimales = data.getInt(0);
                    if (data.Read()) Global.nombreImpresora = data.getString(0);
                    resultado = true; 
                }
            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                if(conf!=null)conf.cerrar();
            }
            return resultado;

        }

        public static int obtenerIdBodega(ref string mensaje)
        {
            int idBodega = -1;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion conf = new Conexion();
            try
            {
                cmd = conf.EjecutarSQL("empresa_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("?opcion", 2).Direction = ParameterDirection.Input;
                data = cmd.ExecuteReader();
                if (data.Read()) idBodega = data.GetInt32(0);
            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                conf.cerrar();
            }
            return idBodega;
        }

        public static int obtenerIdBodegaProductos()
        {
            int idBodega = 0;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion conf = new Conexion();
            try
            {
                cmd = conf.EjecutarSQL("empresa_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("?opcion", 5).Direction = ParameterDirection.Input;
                data = cmd.ExecuteReader();
                if (data.Read()) idBodega = data.getInt(0);
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                conf.cerrar();
            }
            return idBodega;
        }


        public static int obtenerSincronizaionContinua()
        {
            int sincronizacion_continua = 0;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion conf = new Conexion();
            try
            {
                cmd = conf.EjecutarSQL("parametro_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("?opcion", 4).Direction = ParameterDirection.Input;
                data = cmd.ExecuteReader();
                if (data.Read()) sincronizacion_continua = data.getInt(0);
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                conf.cerrar();
            }
            return sincronizacion_continua;
        }


        public static string obtenerDireccionEmpresa()
        {
            string direccion = "";
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion conf = new Conexion();
            try
            {
                cmd = conf.EjecutarSQL("empresa_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("?opcion", 6).Direction = ParameterDirection.Input;
                data = cmd.ExecuteReader();
                if (data.Read()) direccion = data.getString(0);
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                conf.cerrar();
            }
            return direccion;
        }



        public static string obtenerNombreEmpresa()
        {
            string nombre = "";
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion conf = new Conexion();
            try
            {
                cmd = conf.EjecutarSQL("empresa_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 4);
                cmd.Parameters["?opcion"].Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.Read()) nombre = data.getString(0);

            }
            catch (Exception e) { throw e; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                conf.cerrar();
            }
            return nombre;
        }

        public static List<string> obtenerDatosReporte()
        {
            List<string> datos = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion conf = null;
            try
            {
                conf = new Conexion();
                cmd = conf.EjecutarSQL("reporte_obtenerDatos");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?maquina", General.getComputerName()).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    datos = new List<String>();
                    if (data.Read())
                    {
                        datos.Add(data.getString(0));
                        datos.Add(data.getString(1));
                        datos.Add(data.getString(2));
                        datos.Add(data.getString(3));
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
            return datos;
        }
    }
}
