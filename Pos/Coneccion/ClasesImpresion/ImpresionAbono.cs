using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;
using Pos.Coneccion;
using Pos.Clases;

namespace Pos.ClasesImpresion
{
    class ImpresionAbono
    {

        private Font letra;
        private SolidBrush pincel;
        private int xActual;
        private int yActual;
        private int nCorte;
        private string _monto_abonado;
        private string _total_abonado;
        private string _saldo;
        private string _total;
        private string _vuelto;
        private string _idpos;
        private string _clienten;
        private List<FormaPago> _pagos;

        public List<FormaPago> pagos
        {
            set { this._pagos = value; }
            get { return this._pagos; }
        }

        public string monto_abonado
        {
            set { this._monto_abonado = value; }
            get { return this._monto_abonado; }
        }

        public string total_abonado
        {
            set { this._total_abonado = value; }
            get { return this._total_abonado; }
        }

        public string total
        {
            set { this._total = value; }
            get { return this._total; }
        }

        public string vuelto
        {
            set { this._vuelto = value; }
            get { return this._vuelto; }
        }

        public string idpos
        {
            set { this._idpos = value; }
            get { return this._idpos; }
        }

        public string saldo
        {
            set { this._saldo = value; }
            get { return this._saldo; }
        }

        public string clienten
        {
            set { this._clienten = value; }
            get { return this._clienten; }
        }

        public ImpresionAbono()
        {
            this.pincel = new SolidBrush(Color.Black);
            this.letra = new Font("Sans Serif", 9, FontStyle.Regular);
            //this.desplazamiento = 18;
            this.xActual = 0;
            this.yActual = 10;
            this.nCorte = ParametroTR.consultarIntXNombre("caracteresHoja");
        }

        public void imprimir(string impresora)
        {
            PrintDocument impresion = new PrintDocument();
            PrintController printController = new StandardPrintController();
            PaperSize psize = new PaperSize("Custom", 350, 450);
            impresion.DefaultPageSettings.PaperSize = psize;
            impresion.PrintController = printController;
            impresion.PrinterSettings.PrinterName = impresora;
            impresion.PrintPage += new PrintPageEventHandler(imprimirDatos);
            impresion.Print();
        }

        protected string centrar(string texto)
        {
            if (texto.Length >= this.nCorte) return texto;
            int cantidad = (texto.Length % 2 == 0) ? texto.Length / 2 : (texto.Length + 1) / 2;
            int antes = (this.nCorte / 2) + cantidad;
            return texto.PadLeft(antes, ' ');
        }

        protected string justificar(string texto)
        {
            return texto;
        }

        protected void imprimirDatos(object sender, PrintPageEventArgs ev)
        {
            string linea = "Fecha:" + DateTime.Now.ToString() + "\n";
            linea += this.centrar("Distribuidora M&G") + "\n";
            linea += "=======================================\n";
            linea += this.centrar("COMPROBANTE DE ABONO") + "\n";
            linea += "=======================================\n";

            linea += this.justificar("Cliente: ") + this.clienten + "\n";
            linea += this.justificar("Abono: $") + this.monto_abonado + "\n";
            linea += this.justificar("Total Abonos: $") + this.total_abonado + "\n";
            linea += this.justificar("Total Documento: $") + this.total + "\n";
            linea += this.justificar("Saldo: $") + this.saldo + "\n";
            linea += this.justificar("Vuelto: $") + this.vuelto + "\n\n";
            linea += this.justificar("#Doc POS: ") + this.idpos + "\n\n"; 
            linea += "=======================================\n";
            linea += this.centrar("DETALLES") + "\n";
            linea += "=======================================\n";
            foreach (FormaPago pago in this.pagos)
            {
                linea += this.imprimirPago(pago);
                
            }
            linea += ".                     .\n";

            ev.Graphics.DrawString(linea, this.letra, this.pincel, this.xActual, this.yActual);
        }

        protected string imprimirPago(FormaPago pago)
        {
            string linea = pago.Fecha.ToShortDateString() + " ";
            if (pago.Monto_efectivo > 0)
            {

                linea += "   \t $ " + pago.Monto_efectivo + " Efectivo\n";
            }
            else if (pago.Monto_cheque > 0)
            {
                linea += "   \t $ " + pago.Monto_cheque + " Cheque\n";
            }
            else if (pago.Monto_tarjeta > 0)
            {
                linea += "   \t $ " + pago.Monto_tarjeta + " Tarjeta\n";
            }
            else if (pago.Monto_retencion > 0)
            {
                linea += "   \t $ " + pago.Monto_retencion + " Ret.\n";
            }
            else if (pago.Monto_nota > 0)
            {
                linea += "   \t $ " + pago.Monto_nota + " Nota C.\n";
            }
            return linea;
        }
    }
}
