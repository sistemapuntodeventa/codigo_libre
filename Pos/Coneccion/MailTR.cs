using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Pos.Coneccion
{
    class MailTR
    {

        public static DataTable datosApertura(int idCaja, string maquina)
        {
            return MailTR.obtenerDatos(idCaja,6,maquina);
        }

        public static DataTable datosAdicionales(int idCaja,string maquina, int idCajero)
        {
            return MailTR.obtenerDatos(idCaja, 5,maquina,idCajero);
        }

        public static DataTable resumenGeneral(int idCaja)
        {
            return MailTR.obtenerDatos(idCaja, 1);
        }

        public static DataTable resumenCobros(int idCaja)
        {
            return MailTR.obtenerDatos(idCaja, 3);
        }

        public static DataTable ventaCategoria(int idCaja)
        {
            return MailTR.obtenerDatos(idCaja, 2);
        }

        public static DataTable resumenRedesCobro(int idCaja)
        {
            return MailTR.obtenerDatos(idCaja, 4);
        }


        public static DataTable obtenerDatos(int idCaja, int opcion, string maquina = "", int idCajero = -1)
        {
            MySqlCommand cmd;
            DataSet datos = null;
            DataTable resultado = null;
            MySqlDataAdapter adapter = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("mail_generar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("?opcion", opcion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCaja", idCaja).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?maquina", maquina).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCajero", idCajero).Direction = ParameterDirection.Input;

                adapter = new MySqlDataAdapter(cmd);
                datos = new DataSet();
                adapter.Fill(datos);
                resultado = datos.Tables[0];
            }
            catch (Exception e) { throw e; }
            finally
            {
                if(con!=null)con.cerrar();
                if (adapter != null) adapter.Dispose();
            }
            return resultado;
        }
    }
}
