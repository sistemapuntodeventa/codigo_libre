using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pos.Clases;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using Pos.App;

namespace Pos.Coneccion
{
    class FacturaDetalleTR
    {
        FacturaDetalle detalle;
        private string nombre_stp;
        private Conexion conf;

        public FacturaDetalleTR()
        {
            this.conf = new Conexion();
        }

        public FacturaDetalleTR(string nombreStore)
        {
            this.detalle = new FacturaDetalle();
            this.nombre_stp = nombreStore;
            this.conf = new Conexion();
        }

        public FacturaDetalleTR(FacturaDetalle detalle)
        {
            this.detalle = detalle;
            this.conf = new Conexion();
        }

        public string Nombre_stp
        {
            get { return nombre_stp; }
            set { nombre_stp = value; }
        }

        internal FacturaDetalle Detalle
        {
            get { return detalle; }
            set { detalle = value; }
        }

        internal Conexion Conf
        {
            get { return conf; }
            set { conf = value; }
        }

        public static List<String[]> consultarFacturaDetalle(int idFactura)
        {
            List<String[]> lista = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("factura_consultarDetalle");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idCabecera", idFactura).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                lista = new List<String[]>();
                while (data.Read())
                {
                    String[] item = new String[17];
                    item[0] = data.GetValue(0).ToString();
                    item[1] = data.GetValue(1).ToString();
                    item[2] = data.GetValue(2).ToString();
                    item[3] = data.GetValue(3).ToString();
                    item[4] = data.GetValue(4).ToString();
                    item[5] = data.GetValue(5).ToString();
                    item[6] = data.GetValue(6).ToString();
                    item[7] = data.GetValue(7).ToString();
                    item[8] = data.GetValue(8).ToString();
                    item[9] = data.GetValue(9).ToString();
                    item[10] = data.GetValue(10).ToString();
                    item[11] = data.GetValue(11).ToString();
                    item[12] = data.GetValue(12).ToString();
                    item[13] = data.GetValue(13).ToString();
                    item[14] = data.GetValue(14).ToString();
                    item[15] = data.GetValue(15).ToString();
                    item[16] = data.GetValue(16).ToString();
                    lista.Add(item);
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
            return lista;
        }

        public static String[] consultarCambios(int idFacturaDetalle)
        {
            String[] datos = null;
            Conexion con = new Conexion();
            MySqlCommand cmd = con.EjecutarSQL("factura_consultarDetalle");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("?opcion", 2).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?idCabecera", idFacturaDetalle).Direction = ParameterDirection.Input;

            MySqlDataReader data = cmd.ExecuteReader();
            if (data.Read())
            {
                datos = new String[4];
                datos[0] = data.GetValue(0).ToString();
                datos[1] = data.GetValue(1).ToString();
                datos[2] = data.GetValue(2).ToString();
                datos[3] = data.GetValue(3).ToString();
            }
            if (con != null) con.cerrar();
            return datos;
        }

    }
}
