using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pos.Clases;
using MySql.Data.MySqlClient;
using System.Data;

namespace Pos.Coneccion
{
    public class FormaPagoTR
    {
        private Conexion conf;
        private string nombre_stp;
        private FormaPago pago;

        public FormaPagoTR()
        {
            this.conf = new Conexion();
            this.pago = new FormaPago();
        }

        public Conexion Conf
        {
            get { return conf; }
            set { conf = value; }
        }

        public string Nombre_stp
        {
            get { return nombre_stp; }
            set { nombre_stp = value; }
        }

        internal FormaPago Pago
        {
            get { return pago; }
            set { pago = value; }
        }

        public void insertarPago()
        {
            MySqlCommand cmd = this.Conf.EjecutarSQL("insertar_pagos");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("?id_cabecerai", this.Pago.Id_cabecera).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?monto_efectivoi", this.Pago.Monto_efectivo).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?monto_chequei", this.Pago.Monto_cheque).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?monto_tarjetai", this.Pago.Monto_tarjeta).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?numero_chequei", this.Pago.Numero_cheque).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?bancoi", this.Pago.Banco).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?numero_tarjetai", this.Pago.Numero_tarjeta).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?tipo_tarjetai", this.Pago.Tipo_tarjeta).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?forma_pagoi", this.Pago.Forma_pago).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?numero_retencioni", this.Pago.Numero_retencion).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?tipo_pingi", this.Pago.Tipo_ping).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?monto_retencioni", this.Pago.Monto_retencion).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?id_cajai", this.Pago.Id_Caja).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?idPago", MySqlDbType.Int32);
            cmd.Parameters["?idPago"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            this.Conf.cerrar();
            this.Pago.Idforma_pagos = (int)cmd.Parameters["?idPago"].Value;
        }

        //eliminar ultimo pago para dejar factura pendiente

        public void eliminarPago(int idfactura)
        {

            MySqlCommand cmd = this.Conf.EjecutarSQL("eliminar_pago");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("?id_cabecerai", idfactura).Direction = ParameterDirection.Input;

            cmd.ExecuteNonQuery();
            this.Conf.cerrar();

        }
  
        public List<FormaPago> consultarPagos()
        {
            List<FormaPago> lista = new List<FormaPago>();
            MySqlCommand cmd = this.Conf.EjecutarSQL("consultar_pagos");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("?idCabecera", this.Pago.Id_cabecera);
            cmd.Parameters["?idCabecera"].Direction = ParameterDirection.Input;

            MySqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                FormaPago item = new FormaPago();
                item.Idforma_pagos = data.GetInt32(0);
                item.Id_cabecera = data.GetInt32(1);
                item.Forma_pago = data.GetString(2);
                item.Monto_efectivo = data.GetDecimal(3);
                item.Monto_cheque = data.GetDecimal(4);
                item.Monto_tarjeta = data.GetDecimal(5);
                item.Monto_retencion = data.GetDecimal(6);
                item.Numero_cheque = data.GetString(7);
                item.Banco = data.GetString(8);
                item.Numero_tarjeta = data.GetString(9);
                item.Tipo_tarjeta = data.GetString(10);
                item.Numero_retencion = data.GetInt32(11);
                item.Tipo_ping = data.GetString(12);
                item.Numero_Nota = data.getInt(13);
                item.Monto_nota = data.getDecimal(14);
                item.Id_Caja = data.getInt(15);
                lista.Add(item);
            }
            this.conf.cerrar();
            return lista;
        }


    }
}
