using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Configuration;
using System.Net.NetworkInformation;
using System.Globalization;
using System.Net;

namespace Pos.Clases
{
    static class General
    {

        public static int? enteroDesdeString(string valor)
        { 
            if(String.IsNullOrEmpty(valor) || valor=="None")return null;
            return Convert.ToInt32(valor);
        }

        public static bool esDecimal(string valor)
        {
            decimal temp;
            if (decimal.TryParse(valor, out temp)) return true;
            return false;
        }

        public static string scapeCharacters(string texto)
        {

            //string texto = documento.InnerXml;
            texto = texto.Replace('á', 'a').Replace('é', 'e').Replace('í', 'i').Replace('ó', 'o').Replace('ú', 'u');
            texto = texto.Replace('Á', 'A').Replace('É', 'E').Replace('Í', 'I').Replace('Ó', 'O').Replace('Ú', 'U');
            return texto.Replace('Ñ','N').Replace('ñ','n');
        }

        public static bool esNodoVacio(string texto)
        {
            return (string.IsNullOrEmpty(texto) || texto == "None");
        }

        public static Decimal convertirDecimal(string valor)
        {
            //return (String.IsNullOrEmpty(valor) ? 0 : Convert.ToDecimal(valor,CultureInfo.GetCultureInfo("en")));
            return ((String.IsNullOrEmpty(valor) || valor == ".") ? 0 : Convert.ToDecimal(valor));
        }

        public static bool vacioOCero(string valor)
        {
            return (String.IsNullOrEmpty(valor) || valor == "0" || valor == "0.00");
        }

        public static Decimal convertirDecimal(object valor)
        {
            return ((valor == null) ? 0 : Convert.ToDecimal(valor, CultureInfo.GetCultureInfo("en")));
        }

        public static void soloNumeros(KeyPressEventArgs e)
        {
            if (((e.KeyChar) < 48 && e.KeyChar != 8 && e.KeyChar != 44 && e.KeyChar != 13) || e.KeyChar > 57) e.Handled = true;
        }

        public static void sinCaracteresEspeciales(KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsNumber(e.KeyChar) || Char.IsControl(e.KeyChar) || Char.IsSeparator(e.KeyChar) || "_.,@-".IndexOf(e.KeyChar) >= 0)
                e.Handled = false;
            else e.Handled = true;
        }

        public static void permitirDecimales(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')e.Handled = true;
            // only allow one decimal point
            if (e.KeyChar == '.' && ((sender is TextBox && (sender as TextBox).Text.IndexOf('.') > -1) || (sender is ComboBox && (sender as ComboBox).Text.IndexOf('.') > -1))) e.Handled = true;
            if (!char.IsControl(e.KeyChar))
            {
                //TextBox textBox = null;
                if (sender is TextBox)
                {
                    TextBox textBox = (TextBox)sender;
                    if (textBox.Text.IndexOf('.') > -1 && textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= 3) e.Handled = true;
                }
                else 
                {
                    ComboBox textBox = (ComboBox)sender;
                    if (textBox.Text.IndexOf('.') > -1 && textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= 3) e.Handled = true;
                }
                
            }
        }

        public static string getComputerName(){
            // "Usuario-PC";
           return IPGlobalProperties.GetIPGlobalProperties().HostName; ;
        }


        public static string encriptar(string s)
        {
            string cryptoKey = "abcdefghijklmnñopqrstuvwxyz1234567890_*()[]%#°!¡¿?ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
            byte[] IV = new byte[8] { 240, 3, 45, 29, 0, 76, 173, 59 };
            if (s == null || s.Length == 0) return string.Empty;
            string result = string.Empty;
            try
            {
                byte[] buffer = Encoding.ASCII.GetBytes(s);
                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
                des.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));
                des.IV = IV;
                result = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch { throw; }
            return result;
        }


        public static string desencriptar(string s)
        {
            string cryptoKey = "abcdefghijklmnñopqrstuvwxyz1234567890_*()[]%#°!¡¿?ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
            byte[] IV = new byte[8] { 240, 3, 45, 29, 0, 76, 173, 59 };
            if (s == null || s.Length == 0) return string.Empty;
            string result = string.Empty;
            try
            {
                byte[] buffer = Convert.FromBase64String(s);
                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
                des.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));
                des.IV = IV;
                result = Encoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch { return ""; }
            return result;
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public static string obtenerValorCelda(DataGridView datos, DataGridViewCellEventArgs e)
        {
            object dato = datos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            return (dato != null)? dato.ToString().Trim() : "";
        }

        public static string obtenerValorCelda(DataGridViewCell datos)
        {
            object dato = datos.Value;
            return (dato != null) ? dato.ToString() : "";
        }

        public static string obtenerValorCelda(DataGridView datos, int fila, int columna)
        {
            object dato = datos.Rows[fila].Cells[columna].Value;
            return (dato != null) ? dato.ToString() : "";
        }

        public static string obtenerValorCelda(DataGridView datos, int fila, string columna)
        {
            object dato = datos.Rows[fila].Cells[columna].Value;
            return (dato != null) ? dato.ToString() : "";
        }

        public static bool esNombreColumna(DataGridView datos, int columna, string nombre)
        {
            return datos.Columns[columna].Name == nombre;
        }

        public static bool filaVacia(DataGridViewRow fila)
        {
            foreach (DataGridViewCell celda in fila.Cells)if (celda.Value != null && celda.Value.ToString() != "") return false;
            return true;
        }

        public static bool celdaVacia(DataGridViewCell celda)
        {
            if (celda.Value == null) return true;
            if (String.IsNullOrEmpty(celda.Value.ToString())) return true;
            return false;
        }
        public static void filaVaciar(DataGridViewRow fila, int columna)
        {
            int i = 0;
            foreach (DataGridViewCell celda in fila.Cells)
            {
                if(i!=columna)celda.Value = "";
                i++;
            }
        }

        public static Decimal truncar(Decimal number, int digits)
        {
           /* Decimal stepper = (Decimal)(Math.Pow(10.0, (double)digits));
            int temp = (int)(stepper * number);
            return (Decimal)temp / stepper;*/

            Decimal valor = (Decimal)(Math.Pow(10.0, (double)digits));
            
            return Math.Truncate(number * valor) / valor;
        }

        public static bool tieneConexionInternet()
        {
            try
            {
                Ping ping = new Ping();
                PingReply pingStatus = ping.Send("www.google.com");
                if (pingStatus.Status == IPStatus.Success) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
