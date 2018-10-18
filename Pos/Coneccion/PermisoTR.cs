using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pos.Clases;
using MySql.Data.MySqlClient;
using System.Data;

namespace Pos.Coneccion
{
    class PermisoTR
    {
        private Conexion conf;
        private Permiso permiso;

        public PermisoTR()
        {
            this.conf = new Conexion();
        }

        public PermisoTR(Permiso permiso)
        {
            this.permiso = permiso;
            this.conf = new Conexion();
        }

        public void refrescar()
        {
            if(this.conf == null)this.conf = new Conexion();
        }

        public static Permiso consultar(ref string mensaje, int idRol)
        {
            Permiso permiso = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion conf = null;
            try
            {

                conf = new Conexion();
                cmd = conf.EjecutarSQL("permiso_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("?idRoli", idRol).Direction = ParameterDirection.Input;
                data = cmd.ExecuteReader();
                if (data.Read())
                {
                    permiso = new Permiso();
                    permiso.dna = data.GetBoolean("dna");
                    permiso.descuento = data.GetBoolean("descuento");
                    permiso.vueltoCredito = data.GetBoolean("vueltoCredito");
                    permiso.vueltoCheque = data.GetBoolean("vueltoCheque");
                    permiso.notaCredito = data.GetBoolean("notaCredito");
                    permiso.SeleccionarVendedor = data.GetBoolean("seleccionarVendedor");
                    permiso.Propina = data.GetBoolean("propina");
                    permiso.Pendientes = data.GetBoolean("formularioPendientes");
                    permiso.anularFactura = data.GetBoolean("anularFactura");
                }
            }
            catch (Exception e)
            {
                permiso = null;
                mensaje = e.Message;
            }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                conf.cerrar();
            }
            return permiso;
        }

        public bool actualizar(ref string mensaje, int idRol)
        {
            bool resultado = false;
            try
            {
                MySqlCommand cmd = this.conf.EjecutarSQL("permiso_actualizar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?idRoli", idRol).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?dnai", this.permiso.dna).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?descuentoi", this.permiso.descuento).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?vueltoCreditoi", this.permiso.vueltoCredito).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?vueltoChequei", this.permiso.vueltoCheque).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?notaCreditoi", this.permiso.notaCredito).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?seleccionarVendedori", this.permiso.SeleccionarVendedor).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?propinai", this.permiso.Propina).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?formularioPendientesi", this.permiso.Pendientes).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?anularFacturai", this.permiso.anularFactura).Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();
                resultado = true;

            }
            catch (Exception e) { mensaje = e.Message; }
            finally { this.conf.cerrar(); }
            return resultado;
        }
        

    }
}
