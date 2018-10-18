using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pos.Clases
{
    public class FormaPago
    {
        private int idforma_pagos, id_cabecera, numero_retencion, numero_nota;
        private string forma_pago, numero_cheque, banco, numero_tarjeta, tipo_tarjeta, tipo_ping;
        private decimal monto_efectivo, monto_cheque, monto_tarjeta, monto_retencion, monto_nota;
        private DateTime fecha;
        private int id_caja;

        public FormaPago() 
        {
            this.fecha = DateTime.Now;
            this.idforma_pagos = 0;
            this.id_cabecera = 0;
            this.forma_pago = "";
            this.numero_cheque = "";
            this.banco = "";
            this.numero_tarjeta = "";
            this.tipo_tarjeta = "";
            this.monto_efectivo = 0;
            this.monto_cheque = 0;
            this.monto_tarjeta = 0;
            this.numero_retencion = 0;
            this.tipo_ping = "";
            this.monto_retencion = 0;
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public int Id_Caja
        {
            get { return id_caja; }
            set { id_caja = value; }
        }

        public int Numero_Nota
        {
            get { return numero_nota; }
            set { numero_nota = value; }
        }
        public decimal Monto_nota
        {
            get { return monto_nota; }
            set { monto_nota = value; }
        }
        public int Idforma_pagos
        {
            get { return idforma_pagos; }
            set { idforma_pagos = value; }
        }

        public int Id_cabecera
        {
            get { return id_cabecera; }
            set { id_cabecera = value; }
        }

        public string Forma_pago
        {
            get { return forma_pago; }
            set { forma_pago = value; }
        }

        public string Numero_cheque
        {
            get { return numero_cheque; }
            set { numero_cheque = value; }
        }

        public string Banco
        {
            get { return banco; }
            set { banco = value; }
        }

        public string Numero_tarjeta
        {
            get { return numero_tarjeta; }
            set { numero_tarjeta = value; }
        }

        public string Tipo_tarjeta
        {
            get { return tipo_tarjeta; }
            set { tipo_tarjeta = value; }
        }

        public decimal Monto_efectivo
        {
            get { return monto_efectivo; }
            set { monto_efectivo = value; }
        }

        public decimal Monto_cheque
        {
            get { return monto_cheque; }
            set { monto_cheque = value; }
        }

        public decimal Monto_tarjeta
        {
            get { return monto_tarjeta; }
            set { monto_tarjeta = value; }
        }

        public int Numero_retencion
        {
            get { return numero_retencion; }
            set { numero_retencion = value; }
        }

        public string Tipo_ping
        {
            get { return tipo_ping; }
            set { tipo_ping = value; }
        }

        public decimal Monto_retencion
        {
            get { return monto_retencion; }
            set { monto_retencion = value; }
        }

        public string getFormaPago()
        {
            switch (this.forma_pago)
            { 
                case "EF":return "Efectivo";
                case "CH":return "Cheque";
                case "TC": return "Tarjeta";
                case "RF": return "Retención";
                case "NC": return "Nota Crédito";
            }
            return "";
        }

        public decimal getValor()
        {
            switch (this.forma_pago)
            {
                case "EF": return this.monto_efectivo;
                case "CH": return this.monto_cheque;
                case "TC": return this.monto_tarjeta;
                case "RF": return this.monto_retencion;
                case "NC": return this.monto_nota;
            }
            return 0;
        }
    }
}
