using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pos.Coneccion;
using MySql.Data.MySqlClient;
using System.Data;
using Pos.Clases;

namespace TestLib
{
    public class CoordenadaTR
    {

        private Conexion config;
        private Coordenada coordenada;


        public CoordenadaTR()
        {
            this.config = new Conexion();
        }

        public CoordenadaTR(Coordenada coordenada)
        { 
            this.config = new Conexion();
            this.coordenada = coordenada;
        }

        public bool actualizarCoordenada(ref string mensaje)
        {
            bool resultado;
            MySqlCommand cmd = null;
            try
            {
                cmd = this.config.EjecutarSQL("coordenada_actualizar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?nombrei", this.coordenada.nombre);
                cmd.Parameters["?nombrei"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?xi", this.coordenada.X);
                cmd.Parameters["?xi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?yi", this.coordenada.Y);
                cmd.Parameters["?yi"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();

                return true;

            }
            catch (Exception e)
            {
                mensaje = e.Message;
                resultado = false;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                this.config.cerrar();
            }

            return resultado;
        }


        public List<Coordenada> consultarActivas(ref string mensaje,int idTipoDocumento)
        {
            List<Coordenada> coordenadas = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            try
            {
                cmd = this.config.EjecutarSQL("coordenada_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idTipoDocumento", idTipoDocumento).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                coordenadas = new List<Coordenada>();
                while (data.Read())
                {
                    Coordenada coordenada = new Coordenada();
                    coordenada.id = data.GetInt32("id");
                    coordenada.nombre = data.GetString("nombre");
                    coordenada.X = data.GetDecimal("x");
                    coordenada.Y = data.GetDecimal("y");
                    coordenada.tipo = data.GetInt16("detalle");
                    coordenada.valor = data.getString("valor");
                    coordenada.derecha = data.GetBoolean("derecha");
                    coordenadas.Add(coordenada);
                }
            }
            catch (Exception e)
            {
                coordenadas = null;
                mensaje = e.Message;
            }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                this.config.cerrar();
            }
            return coordenadas;
        }

        public bool inactivarCoordenadas(ref string mensaje)
        {
            MySqlCommand cmd = this.config.EjecutarSQL("coordenada_inactivar");
            bool estado = false;
            try
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                estado = true;

            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                this.config.cerrar();
                if (cmd != null) cmd.Dispose();
            }
            return estado;
        }

    }
}
