using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.Types;
namespace Pos.Coneccion
{
using MySql.Data.MySqlClient;

    public class Conexion
    {
        private static string connStr = "Server=localhost;Database=pos_contifico;Uid=user;Pwd=user;Port=3306;charset=utf8";
        private  MySqlConnection conn ;
        private static MySqlCommand command;
        //private static Configuracion Coneccion;

        public Conexion()
        {            
            conn = new MySqlConnection(connStr);
        }

        public static string  lineaConexion
        {
            get { return connStr; }
        }

        public MySqlConnection abrir
        {
            get
            {
                try
                {
                    conn.Open();
                    return conn;
                }
                catch (Exception) { return new MySqlConnection(); }
            }
        }

        public MySqlCommand EjecutarSQL(string Sentencia_SQL)
        {
            command = new MySqlCommand(Sentencia_SQL, this.abrir);
            return command;
        }

        public void cerrar()
        {
            conn.Close();
        }
    }
}