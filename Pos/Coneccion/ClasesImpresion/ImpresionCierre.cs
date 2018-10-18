using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;
using Pos.Coneccion;

namespace Pos.ClasesImpresion
{
    class ImpresionCierre
    {

        private Font letra;
        private SolidBrush pincel;
        private int xActual;
        private int yActual;
        private int desplazamiento;
        private int nCorte;
        private int espacios;
        private string numero_caja;
        private string _fecha;
        private string _saldo_inicial;
        private string _total_facturado;
        private string _total_cobrado;
        private string _total_caja;
        private string _saldo_final;
        private string _valor_efectivo;
        private string _valor_cheque;
        private string _valor_tarjeta;
        private string _valor_retencion;
        private string _lote_datafast;
        private string _lote_medianet;
        private string _lote_redApoyo;
        private bool _cierreManual = false;

        public bool cierreManual
        {
            set { this._cierreManual = value; }
            get { return this._cierreManual; }
        }

        public string fecha
        {
            set { this._fecha = value; }
            get { return this._fecha; }
        }

        public string saldo_inicial
        {
            set { this._saldo_inicial = value; }
            get { return this._saldo_inicial; }
        }

        public string total_facturado
        {
            set { this._total_facturado = value; }
            get { return this._total_facturado; }
        }

        public string total_cobrado
        {
            set { this._total_cobrado = value; }
            get { return this._total_cobrado; }
        }

        public string total_caja
        {
            set { this._total_caja = value; }
            get { return this._total_caja; }
        }

        public string saldo_final
        {
            set { this._saldo_final = value; }
            get { return this._saldo_final; }
        }

        public string valor_efectivo
        {
            set { this._valor_efectivo = value; }
            get { return this._valor_efectivo; }
        }

        public string valor_cheque
        {
            set { this._valor_cheque = value; }
            get { return this._valor_cheque; }
        }

        public string valor_tarjeta
        {
            set { this._valor_tarjeta = value; }
            get { return this._valor_tarjeta; }
        }

        public string valor_retencion
        {
            set { this._valor_retencion = value; }
            get { return this._valor_retencion; }
        }

        public string lote_datafast
        {
            set { this._lote_datafast = value; }
            get { return this._lote_datafast; }
        }

        public string lote_medianet
        {
            set { this._lote_medianet = value; }
            get { return this._lote_medianet; }
        }

        public string lote_redApoyo
        {
            set { this._lote_redApoyo = value; }
            get { return this._lote_redApoyo; }
        }

        public ImpresionCierre()
        {
            string mensaje = "";
            this.pincel = new SolidBrush(Color.Black);
            this.letra = new Font("Sans Serif", 9, FontStyle.Regular);
            this.desplazamiento = 18;
            this.xActual = 0;
            this.yActual = 10;
            this.nCorte = ParametroTR.consultarIntXNombre("caracteresHoja");
         }

        public void imprimir()
        {
            PrintDocument impresion = new PrintDocument();
            PrintController printController = new StandardPrintController();
            PaperSize psize = new PaperSize("Custom", 350,450);
            impresion.DefaultPageSettings.PaperSize = psize;
            impresion.PrintController = printController;
            //impresion.PrinterSettings.PrinterName = ubicacion.impresora;
            impresion.PrintPage += new PrintPageEventHandler(imprimirDatos);
            impresion.Print();
        }

        protected string centrar(string texto)
        {
            if (texto.Length >= this.nCorte) return texto;
            int cantidad = (texto.Length % 2 == 0)?texto.Length/2:(texto.Length +1)/2; 
            int antes = (this.nCorte/2) + cantidad;
            return texto.PadLeft(antes, ' ');
        }

        protected string justificar(string texto)
        {
            return texto;
        }

        protected void imprimirDatos(object sender, PrintPageEventArgs ev)
        {
            string linea = "Fecha:" + DateTime.Now.ToString() + "\n";
            linea += "=======================================\n";
            linea += this.centrar("CIERRE DE CAJA") + "\n";
            linea += "=======================================\n";

            linea += this.centrar("Saldos") + "\n";
            linea += "----------------------------------------\n";
            linea += this.justificar("Inicial:") + this.saldo_inicial + "\n";

            if (!this.cierreManual)
            {
                linea += this.justificar("Facturado:") + this.total_facturado + "\n";
                linea += this.justificar("Cobrado:") + this.total_cobrado + "\n";
                linea += this.justificar("Final:") + this.saldo_final + "\n";
            }

            
            linea += "----------------------------------------\n";
            linea += this.centrar("Ventas") + "\n";
            linea += "----------------------------------------\n";
            linea += this.justificar("Efectivo:") + this.valor_efectivo + "\n";
            linea += this.justificar("Cheque:") + this.valor_cheque + "\n";

            linea += this.justificar("Tarjetas:") + this.valor_tarjeta + "\n";
            linea += this.justificar("Retencion:") + this._valor_retencion + "\n";

            if (!this.cierreManual)
            {
                linea += this.justificar("Total:") + this.total_caja + "\n";
            }

            linea += "----------------------------------------\n";
            linea += this.centrar("Lotes") + "\n";
            linea += "----------------------------------------\n";
            linea += this.justificar("Datafast:") + this.lote_datafast + "\n";
            linea += this.justificar("Medianet:") + this.lote_medianet + "\n";
            linea += this.justificar("Red Apoyo:") + this.lote_redApoyo + "\n";
            ev.Graphics.DrawString(linea, this.letra, this.pincel, this.xActual, this.yActual);
        }
    }
}
