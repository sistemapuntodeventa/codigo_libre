using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;
using Pos.Coneccion;

namespace Pos.ClasesImpresion
{
    class ImpresionTexto
    {

        private Font letra;
        private SolidBrush pincel;
        private int xActual;
        private int yActual;
        private int desplazamiento;
        private int nCorte;
        private string textoDefecto;
        private int espacios;
        private string idCaja;
        private string estado;

        public ImpresionTexto(string textoDefecto,int espacios, string idCaja, string estado)
        {
            string mensaje = "";
            this.textoDefecto = textoDefecto;
            this.pincel = new SolidBrush(Color.Black);
            this.letra = new Font("Sans Serif", 9, FontStyle.Regular);
            this.desplazamiento = 18;
            this.xActual = 0;
            this.yActual = 10;
            this.espacios = espacios + 6;
            this.idCaja = idCaja;
            this.estado = estado;
            this.nCorte = ParametroTR.consultarIntXNombre("caracteresHoja");
         }

        public void imprimir()
        {
            PrintDocument impresion = new PrintDocument();
            PrintController printController = new StandardPrintController();
            PaperSize psize = new PaperSize("Custom", 350,this.espacios * this.desplazamiento);
            impresion.DefaultPageSettings.PaperSize = psize;
            impresion.PrintController = printController;
            //impresion.PrinterSettings.PrinterName = ubicacion.impresora;
            impresion.PrintPage += new PrintPageEventHandler(imprimirDatos);
            impresion.Print();
        }

        protected void imprimirDatos(object sender, PrintPageEventArgs ev)
        {
            string linea = "Fecha Impresion: " + DateTime.Now.ToString() + "\n";
            linea += "Caja #:" + this.idCaja + "\n";
            linea += "Estado:" + this.estado;
            ev.Graphics.DrawString(linea, this.letra, this.pincel, this.xActual, this.yActual);
            this.yActual += (desplazamiento * 3);

            linea = "***********************************\n";
            linea += "*   LISTADO PRODUCTOS   *\n";
            linea += "***********************************\n";
            ev.Graphics.DrawString(linea, this.letra, this.pincel, this.xActual, this.yActual);
            this.yActual += desplazamiento * 3;

            ev.Graphics.DrawString(this.textoDefecto, this.letra, this.pincel, this.xActual, this.yActual);
        }
    }
}
