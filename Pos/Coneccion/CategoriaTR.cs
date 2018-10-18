using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pos.Clases;
using MySql.Data.MySqlClient;
using System.Data;

namespace Pos.Coneccion
{
    class CategoriaTR
    {
        public static List<ComboboxItem> obtenerCategorias()
        {
            List<ComboboxItem> lista = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion conf = null;
            try
            {
                conf = new Conexion();
                cmd = conf.EjecutarSQL("categoria_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("?opcion", 1).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                lista = new List<ComboboxItem>();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        ComboboxItem combo = new ComboboxItem();
                        combo.Value = data.getString("id");
                        combo.Text = data.getString("nombre");
                        lista.Add(combo);
                    }
                }
            }
            catch (Exception e)
            {
                lista = null;
                throw e;
            }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                conf.cerrar();
            }
            return lista;
        }
    }
}
