using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pos.Clases
{
    public class Caja
    {
        private int id, id_empleado, codigo_secuencial, id_confPos;       
        private string apertura_cierre;
        private DateTime fecha_hora;
        private DateTime edicion;
        private decimal monto_incial, total_cierre, efectivo, cheque, tarjeta, retencion;
        private decimal total_facturado, total_cobro, saldo_final, efectivo_manual, cheque_manual;
        private int datafast, medianet, redApoyo;
        
        public Caja()
        {
            this.id = 0;
            this.id_empleado = 0;
            this.codigo_secuencial = 0;
            //this.estado=0;
            this.apertura_cierre = "";
            this.fecha_hora = DateTime.Now;
            this.monto_incial=0;
            this.id_confPos = 0;
            this.total_cierre = 0;
            this.efectivo = 0;
            this.cheque = 0;
            this.tarjeta = 0;
            this.retencion = 0;
            this.total_facturado = 0;
            this.total_cobro = 0;
            this.saldo_final = 0;
        }


        public decimal Efectivo_Manual
        {
            get { return efectivo_manual; }
            set { efectivo_manual = value; }
        }

        public decimal Cheque_Manual
        {
            get { return cheque_manual; }
            set { cheque_manual = value; }
        }

        public int Datafast
        {
            get { return datafast; }
            set { datafast = value; }
        }

        public int Medianet
        {
            get { return medianet; }
            set { medianet = value; }
        }

        public int RedApoyo
        {
            get { return redApoyo; }
            set { redApoyo = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Id_empleado
        {
            get { return id_empleado; }
            set { id_empleado = value; }
        }

        public int Codigo_secuencial
        {
            get { return codigo_secuencial; }
            set { codigo_secuencial = value; }
        }

        public string Apertura_cierre
        {
            get { return apertura_cierre; }
            set { apertura_cierre = value; }
        }

        public DateTime Fecha_hora
        {
            get { return fecha_hora; }
            set { fecha_hora = value; }
        }

        public DateTime Edicion
        {
            get { return edicion; }
            set { edicion = value; }
        }

        public decimal Monto_incial
        {
            get { return monto_incial; }
            set { monto_incial = value; }
        }

        public decimal Total_cierre
        {
            get { return total_cierre; }
            set { total_cierre = value; }
        }

        public decimal Efectivo
        {
            get { return efectivo; }
            set { efectivo = value; }
        }

        public decimal Cheque
        {
            get { return cheque; }
            set { cheque = value; }
        }

        public decimal Tarjeta
        {
            get { return tarjeta; }
            set { tarjeta = value; }
        }

        public int Id_confPos
        {
            get { return id_confPos; }
            set { id_confPos = value; }
        }

        public decimal Retencion
        {
            get { return retencion; }
            set { retencion = value; }
        }

        public decimal Total_facturado
        {
            get { return total_facturado; }
            set { total_facturado = value; }
        }

        public decimal Total_cobro
        {
            get { return total_cobro; }
            set { total_cobro = value; }
        }

        public decimal Saldo_final
        {
            get { return saldo_final; }
            set { saldo_final = value; }
        }

    }
}
