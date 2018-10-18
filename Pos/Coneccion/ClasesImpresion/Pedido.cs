using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pos.Clases;
using System.Drawing.Printing;
using System.Drawing;
using Pos.Coneccion;

namespace TestLib
{
    class Pedido
    {
        private Ubicacion ubicacion;
        private Font letra;
        private Font letraProducto;
        private SolidBrush pincel;
        private int xActual;
        private int yActual;
        private int desplazamiento;
        private int desplazamientoProducto;
        private int nCorte;
        private int imprimirNombreCombo;
        private string adicionales;
        private int nAdicionales = 0;
        private string numero_documento;
        private string cliente;
        private string idpos;
        private string totalpagar;
        

        public Pedido(Ubicacion ubicacion, List<System.Windows.Forms.Control> controles, string numero_documento, string cliente, string secuencia, string totalpago)
        {
            this.ubicacion = ubicacion;
            this.pincel = new SolidBrush(Color.Black);
            this.letra = new Font("Sans Serif", 9, FontStyle.Regular);
            this.letraProducto = new Font("Sans Serif", 9, FontStyle.Regular);
            this.desplazamiento = 18;
            this.desplazamientoProducto = 18;
            this.xActual = 0;
            this.yActual = 10;
            this.cliente = cliente;
            this.nCorte = ParametroTR.consultarIntXNombre("caracteresHoja");
            this.imprimirNombreCombo = ParametroTR.consultarIntXNombre("imprimirNombreCombo");
            this.numero_documento = numero_documento;
            this.idpos = secuencia;
            this.totalpagar = totalpago;

            if (controles != null)
            {
                foreach (System.Windows.Forms.Control control in controles)
                {
                    this.adicionales = this.adicionales + control.AccessibleName + ": " + control.Text + "\n";
                    this.nAdicionales++;
                }
            }
        }

        public void imprimir()
        {
            PrintDocument impresion = new PrintDocument();
            PrintController printController = new StandardPrintController();
            PaperSize psize = new PaperSize("Custom",350, this.calcularDesplazmiento() + this.desplazamiento);
            impresion.DefaultPageSettings.PaperSize = psize;
            impresion.PrintController = printController;
            //impresion.DefaultPageSettings.PaperSize.
            impresion.PrinterSettings.PrinterName = ubicacion.impresora;
            impresion.PrintPage += new PrintPageEventHandler(imprimirFactura);
            
            //PaperSize psize = new PaperSize("Custom", (int)impresion.DefaultPageSettings.PrintableArea.Width,(int)impresion.DefaultPageSettings.PrintableArea.Height);
            //PaperSize psize = new PaperSize("Custom", this.tamanio., 200);
            //impresion.DefaultPageSettings.PaperSize = psize;

            impresion.Print();
        }


        protected int calcularDesplazmiento()
        {
            int valorY=0;
            valorY += (desplazamiento * 15);
            valorY += desplazamiento * (this.nAdicionales + 1);

            foreach (FacturaDetalle detalle in this.ubicacion.productos)
            {
                valorY += productoEspacio(detalle);
            }

            if (this.ubicacion.productosEliminados.Count > 0)
            {
                valorY += desplazamiento * 3;
                foreach (FacturaDetalle detalle in this.ubicacion.productosEliminados)
                {
                    valorY += productoEspacio(detalle);
                }
            }

            return valorY;
            //PaperSize psize = new PaperSize("Custom",(int)ev.Graphics.ClipBounds.Width,100);
            //this.documentoImpresion.DefaultPageSettings.PaperSize = psize;
        }
        protected void imprimirFactura(object sender, PrintPageEventArgs ev)
        {
            string linea = "";
            

            if (!String.IsNullOrEmpty(this.numero_documento))
            {
                linea = "Fac: " + this.numero_documento;
                ev.Graphics.DrawString(linea, this.letra, this.pincel, this.xActual, this.yActual);
                this.yActual += desplazamiento;
            }

            linea = "         Distribuidora M&G ";
            ev.Graphics.DrawString(linea, this.letra, this.pincel, this.xActual, this.yActual);
            this.yActual += desplazamiento;

            linea = "Fecha: " + DateTime.Now.ToString();
            ev.Graphics.DrawString(linea, this.letra, this.pincel, this.xActual, this.yActual);
            this.yActual += desplazamiento;

            linea = "Cliente: " + this.cliente;
            ev.Graphics.DrawString(linea, this.letra, this.pincel, this.xActual, this.yActual);
            this.yActual += desplazamiento;

            linea = "Doc referencia: " + this.idpos;
            ev.Graphics.DrawString(linea, this.letra, this.pincel, this.xActual, this.yActual);
            this.yActual += desplazamiento;

            linea = "Total a Pagar: " + this.totalpagar;
            ev.Graphics.DrawString(linea, this.letra, this.pincel, this.xActual, this.yActual);
            this.yActual += desplazamiento;


            ev.Graphics.DrawString(this.adicionales, this.letra, this.pincel, this.xActual, this.yActual);
            this.yActual += desplazamiento*(this.nAdicionales +1);

            linea = "--------------------------------------";
            ev.Graphics.DrawString(linea, this.letra, this.pincel, this.xActual, this.yActual);
            this.yActual += desplazamiento;

            foreach (FacturaDetalle detalle in this.ubicacion.productos)
            {
                this.imprimirProducto(ev, detalle, ref linea);
            }

            if (this.ubicacion.productosEliminados.Count > 0)
            {
                linea = "*************************\n";
                linea += "*       NO HACER       *\n";
                linea += "*************************\n";
                ev.Graphics.DrawString(linea, this.letra, this.pincel, this.xActual, this.yActual);
                this.yActual += desplazamiento * 3;
                foreach (FacturaDetalle detalle in this.ubicacion.productosEliminados)
                {
                    this.imprimirProducto(ev, detalle, ref linea);
                }
            }


            this.yActual += (desplazamiento * 8);
            linea = "";
            ev.Graphics.DrawString(linea, this.letra, this.pincel, this.xActual, this.yActual);
            this.yActual += desplazamiento;
            linea = "--------------------------------------";

            ev.Graphics.DrawString(linea, this.letra, this.pincel, this.xActual, this.yActual);
            this.yActual += desplazamiento;

            
            //PaperSize psize = new PaperSize("Custom",(int)ev.Graphics.ClipBounds.Width,100);
            //this.documentoImpresion.DefaultPageSettings.PaperSize = psize;
        }


        protected int productoEspacio(FacturaDetalle detalle)
        {
            int niveles = 0;
            int valorY = 0;
            string linea = detalle.Cantidad.ToString() + " " + detalle.Producto;
            linea = this.generarCorte(linea, ref niveles);
            
            valorY += desplazamiento * niveles;
            if (!String.IsNullOrEmpty(detalle.Descripcion))
            {
                niveles = 0;
                linea = this.generarCorte(detalle.Descripcion, ref niveles);
                
                valorY += desplazamiento * niveles;
            }

            if (detalle.ListaCombo != null)
            {
                foreach (ProductoCombo productoCombo in detalle.ListaCombo)
                {
                    if (productoCombo.productos_escoger != null)
                    {
                        List<ProductoComboProducto> escogidos = productoCombo.productos_escoger.FindAll(item => item.escogido == true);
                        if (escogidos.Count > 0)
                        {
                            valorY += desplazamiento;
                            foreach (ProductoComboProducto comboProducto in escogidos)
                            {
                                valorY += desplazamiento;
                            }
                        }
                    }
                }
            }

            valorY += (desplazamiento * 2);
            return valorY;
        }

        protected void imprimirProducto(PrintPageEventArgs ev, FacturaDetalle detalle, ref string linea)
        {
            int niveles = 0;
            linea = detalle.Cantidad.ToString() + " " + detalle.Producto;
            linea = this.generarCorte(linea, ref niveles);
            ev.Graphics.DrawString(linea, this.letraProducto, this.pincel, this.xActual, this.yActual);
            this.yActual += desplazamientoProducto * niveles;
            if (!String.IsNullOrEmpty(detalle.Descripcion))
            {
                niveles = 0;
                linea = this.generarCorte(detalle.Descripcion, ref niveles);
                ev.Graphics.DrawString(linea, this.letra, this.pincel, this.xActual, this.yActual);
                this.yActual += desplazamiento * niveles;
            }
            if (detalle.ListaCombo != null)
            { 
                foreach(ProductoCombo productoCombo in detalle.ListaCombo)
                {
                    if (productoCombo.productos_escoger != null)
                    {
                        List<ProductoComboProducto> escogidos = productoCombo.productos_escoger.FindAll(item => item.escogido == true);
                        if (escogidos.Count > 0)
                        {
                            if (this.imprimirNombreCombo == 1)
                            {
                                linea = "** " + productoCombo.nombre + " **";
                                ev.Graphics.DrawString(linea, this.letra, this.pincel, this.xActual, this.yActual);
                                this.yActual += desplazamiento;
                            }
                            foreach (ProductoComboProducto comboProducto in escogidos)
                            {
                                ev.Graphics.DrawString(comboProducto.nombre, this.letra, this.pincel, this.xActual, this.yActual);
                                this.yActual += desplazamiento;
                            }
                        }
                    }
                }
            }
            this.yActual += desplazamiento;
        }
        //protected int revisarCorteLinea(ref string linea)
        //{
        //    if (linea.Length > this.nCorte) return this.generarCorte(linea);
        //    return 0;
        //}

        protected string generarCorte(string linea, ref int niveles)
        {
            niveles++;
            if(linea.Length <= this.nCorte)return linea;
            int i = this.obtenerIndice(linea);
            if (i == -1) return linea.Substring(0,this.nCorte) + "\n" + this.generarCorte(linea.Substring(this.nCorte),ref niveles);
            return linea.Substring(0,i+1) + "\n" + this.generarCorte(linea.Substring(i+1),ref niveles);
        }

        protected int obtenerIndice(string linea)
        {
            for (int i = this.nCorte - 1; i > 0; i--) if (linea[i] == ' ') return i;
            return -1;
        }
    }
}
