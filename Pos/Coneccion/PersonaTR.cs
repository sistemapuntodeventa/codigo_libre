using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pos.Clases;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Windows.Forms;

namespace Pos.Coneccion
{
    class PersonaTR
    {
        private Conexion conf;
        private Persona persona;

        public PersonaTR()
        {
            this.conf = new Conexion();

        }

        public PersonaTR(Persona persona)
        {
            this.persona = persona;
            this.conf = new Conexion();
        }

        public Conexion Conf
        {
            get { return conf; }
            set { conf = value; }
        }

        public Persona Persona
        {
            get { return persona; }
            set { persona = value; }
        }


        public bool SincronizarPersona(List<Persona> personas)
        {
            string lineaConexion = Conexion.lineaConexion;
            MySqlConnection conexion = null;
            MySqlTransaction tran = null;
            MySqlCommand cmd = null;
            bool estado = false;
            try
            {

                conexion = new MySqlConnection(lineaConexion);
                conexion.Open();
                tran = conexion.BeginTransaction();

                cmd = new MySqlCommand("persona_insertar", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Transaction = tran;

                this.insertarPersona(cmd, personas);

                tran.Commit();
                conexion.Close();
                estado = true;
            }
            catch (Exception e)
            {
                tran.Rollback();
                throw e;
            }
            finally
            {
                conexion.Close();
                if (cmd != null) cmd.Dispose();
            }
            return estado;
        }


        public bool sincronizarPersona(ref string msn, XmlDocument xml, ProgressBar barra)
        {

            string lineaConexion = Conexion.lineaConexion;
            MySqlConnection conexion = null;
            //MySqlTransaction tran = null;
            MySqlCommand cmd = null;
            bool estado = false;
            try
            {
                XmlNode raiz = xml.GetElementsByTagName("personas")[0];
                XmlNodeList listaPersonas = raiz.ChildNodes;

                conexion = new MySqlConnection(lineaConexion);
                conexion.Open();
               // tran = conexion.BeginTransaction();

                cmd = new MySqlCommand("persona_sincronizar", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
               // cmd.Transaction = tran;
                this.insertarPersona(cmd, listaPersonas, barra);

                //tran.Commit();
                conexion.Close();
                estado = true;
            }
            catch (Exception e)
            {
              //  tran.Rollback();
                msn = e.Message;
            }
            finally
            {
                conexion.Close();
                if (cmd != null) cmd.Dispose();
            }

            return estado;

        }

        private void insertarPersona(MySqlCommand cmd, XmlNodeList listaPersonas, ProgressBar barra)
        {
            int actual = 1;
            int total = listaPersonas.Count;
            foreach (XmlElement nodo in listaPersonas)
            {
                cmd.Parameters.AddWithValue("?idi", (!General.esNodoVacio(nodo["id_pos"].InnerText)) ? Convert.ToInt32(nodo["id_pos"].InnerText) : -1);
                cmd.Parameters["?idi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?fecha_creacioni", Convert.ToDateTime(nodo["fecha_creacion"].InnerText));
                cmd.Parameters["?fecha_creacioni"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?ultimo_cambioi", Convert.ToDateTime(nodo["ultimo_cambio"].InnerText));
                cmd.Parameters["?ultimo_cambioi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?ruci", (!General.esNodoVacio(nodo["ruc"].InnerText)) ? nodo["ruc"].InnerText : "");
                cmd.Parameters["?ruci"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?cedulai", (!General.esNodoVacio(nodo["cedula"].InnerText)) ? nodo["cedula"].InnerText : "");
                cmd.Parameters["?cedulai"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?razon_sociali", (!General.esNodoVacio(nodo["razon_social"].InnerText)) ? nodo["razon_social"].InnerText : "");
                cmd.Parameters["?razon_sociali"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?telefonosi", (!General.esNodoVacio(nodo["telefonos"].InnerText)) ? nodo["telefonos"].InnerText : "");
                cmd.Parameters["?telefonosi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?direccioni", (!General.esNodoVacio(nodo["direccion"].InnerText)) ? nodo["direccion"].InnerText : "");
                cmd.Parameters["?direccioni"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?tipoi", (!General.esNodoVacio(nodo["tipo"].InnerText)) ? nodo["tipo"].InnerText : "");
                cmd.Parameters["?tipoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?es_clientei",(!General.esNodoVacio(nodo["es_cliente"].InnerText)) ? Convert.ToBoolean(nodo["es_cliente"].InnerText) : false);
                cmd.Parameters["?es_clientei"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?es_empleadoi", (!General.esNodoVacio(nodo["es_empleado"].InnerText)) ? Convert.ToBoolean(nodo["es_empleado"].InnerText) : false);
                cmd.Parameters["?es_empleadoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?tipo_contratoi", (!General.esNodoVacio(nodo["tipo_contrato"].InnerText)) ? nodo["tipo_contrato"].InnerText : "");
                cmd.Parameters["?tipo_contratoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?sueldoi",(!General.esNodoVacio(nodo["sueldo"].InnerText)) ? Convert.ToDecimal(nodo["sueldo"].InnerText) : 0);
                cmd.Parameters["?sueldoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?emaili", (!General.esNodoVacio(nodo["email"].InnerText)) ? nodo["email"].InnerText : "");
                cmd.Parameters["?emaili"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?es_vendedori", (!General.esNodoVacio(nodo["es_vendedor"].InnerText)) ? Convert.ToBoolean(nodo["es_vendedor"].InnerText) : false);
                cmd.Parameters["?es_vendedori"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?id_contificoi", Convert.ToInt32(nodo["id_contifico"].InnerText));
                cmd.Parameters["?id_contificoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?porcentaje_descuentoi", (!General.esNodoVacio(nodo["porcentaje_descuento"].InnerText)) ? Convert.ToDecimal(nodo["porcentaje_descuento"].InnerText) : 0);
                cmd.Parameters["?porcentaje_descuentoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?estadoi", (!General.esNodoVacio(nodo["estado"].InnerText)) ? nodo["estado"].InnerText : "");
                cmd.Parameters["?estadoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add(new MySqlParameter("?msn", MySqlDbType.VarChar));
                cmd.Parameters["?msn"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                if (barra != null)
                {
                    barra.Value = (actual * 100) / total;
                    actual++;
                }
            }
        
        }


        public void insertarPersona(MySqlCommand cmd, List<Persona> personas)
        {
            foreach (Persona persona in personas)
            {
                cmd.CommandText = "persona_insertar";
                //cmd.Parameters.AddWithValue("?idi", persona.id).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?fecha_creacioni", persona.fecha_creacion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?ultimo_cambioi", persona.ultimo_cambio).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?ruci", persona.ruc).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cedulai", persona.cedula).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?razon_sociali", persona.razon_social).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?codigoi", persona.codigo).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?telefonosi", persona.telefonos).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?direccioni", persona.direccion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?tipoi", persona.tipo).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?es_clientei", persona.es_cliente).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?es_empleadoi", persona.es_empleado).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?sueldoi", persona.sueldo).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?tipo_contratoi", persona.tipo_contrato).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("emaili", persona.email).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?es_vendedori", persona.es_vendedor).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?id_contificoi", persona.id_contifico).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?porcentaje_descuentoi", persona.porcentaje_descuento).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?estadoi", persona.estado).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?es_extranjeroi", persona.es_extranjero).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?bloqueadoi", persona.bloqueado).Direction = ParameterDirection.Input;



                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

            }
        }


    }
}
