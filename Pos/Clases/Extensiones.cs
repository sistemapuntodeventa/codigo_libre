using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Pos.Clases
{
    public static class Extensiones
    {

        public static int? getIntNull(this MySqlDataReader data,string campo)
        {
            return (!data.IsDBNull(data.GetOrdinal(campo))) ? data.GetInt32(campo) : (int?)null;
        }

        public static int getInt(this MySqlDataReader data, string campo)
        {
            return (!data.IsDBNull(data.GetOrdinal(campo))) ? data.GetInt32(campo) : 0;
        }

        public static int getInt(this MySqlDataReader data, int index)
        {
            return (!data.IsDBNull(index)) ? data.GetInt32(index) : 0;
        }

        public static decimal? getDecimalNull(this MySqlDataReader data, string campo)
        {
            return (!data.IsDBNull(data.GetOrdinal(campo))) ? data.GetDecimal(campo) : (decimal?)null;
        }

        public static decimal getDecimal(this MySqlDataReader data, string campo)
        {
            return (!data.IsDBNull(data.GetOrdinal(campo))) ? data.GetDecimal(campo) : 0;
        }

        public static decimal getDecimal(this MySqlDataReader data, int index)
        {
            return (!data.IsDBNull(index)) ? data.GetDecimal(index) : 0;
        }

        public static string getStringNull(this MySqlDataReader data, string campo)
        {
            return (!data.IsDBNull(data.GetOrdinal(campo))) ? data.GetString(campo) : null;
        }

        public static string getString(this MySqlDataReader data, int campo)
        {
            return (!data.IsDBNull(campo)) ? data.GetString(campo) : "";
        }

        public static string getString(this MySqlDataReader data, string campo)
        {
            return (!data.IsDBNull(data.GetOrdinal(campo))) ? data.GetString(campo) : "";
        }

        public static bool getBoolean(this MySqlDataReader data, string campo)
        {
            return (!data.IsDBNull(data.GetOrdinal(campo))) ? data.GetBoolean(campo) : false;
        }

        public static string getStringNone(this MySqlDataReader data, string campo)
        {
            //int indice = data.GetOrdinal(campo);
            //return (!data.IsDBNull(indice)) ? (data.GetValue(indice).ToString()) : "None";
            string valor = data.GetValue(data.GetOrdinal(campo)).ToString();
            if (String.IsNullOrEmpty(valor)) return "None";
            return valor;
        }




    }
}
