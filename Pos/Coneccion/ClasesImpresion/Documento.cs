using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using TestLib;
using System.Drawing;
using Pos.Clases;

namespace TestLib
{
    class Documento
    {
        private string _clienteNombre;
        private string _fechaActual;
        private string _clienteCedula;
        private string _clienteTelefono;
        private string _clienteDireccion;
        private string _subtotalIVA;
        private string _subtotalCero;
        private string _ivaCobrado;
        private string _iceCobrado;
        private string _valorDescuento;
        private string _servicioCobrado;
        private string _totalPagar;
        private string _totalPagarTexto;
        private string _fechaVencimiento;
        private string _dineroEntregado;
        private string _vuelto;
        private List<adicionalFactura> _adicionales;
        private List<string[]> _detalle;
        private int desplazamiento;
        private int cortarCaracteres;
        private Font letra;
        private SolidBrush pincel;

        public Documento()
        {
            this.pincel = new SolidBrush(Color.Black);
            this.letra = new Font("Sans Serif", 9, FontStyle.Regular);
            this._detalle = new List<string[]>();
        }

        public string dineroEntregado
        {
            set { this._dineroEntregado = value; }
            get { return this._dineroEntregado; }
        }

        public string vuelto
        {
            set { this._vuelto = value; }
            get { return this._vuelto; }
        }

        public string clienteNombre
        {
            set { this._clienteNombre = value; }
            get { return this._clienteNombre; }
        }

        public string fechaActual
        {
            set { this._fechaActual = value; }
            get { return this._fechaActual; }
        }

        public string clienteCedula
        {
            set { this._clienteCedula = value; }
            get { return this._clienteCedula; }
        }

        public string clienteTelefono
        {
            set { this._clienteTelefono = value; }
            get { return this._clienteTelefono; }
        }

        public string clienteDireccion
        {
            set { this._clienteDireccion = value; }
            get { return this._clienteDireccion; }
        }

        public string subtotalIVA
        {
            set { this._subtotalIVA = value; }
            get { return this._subtotalIVA; }
        }

        public string subtotalCero
        {
            set { this._subtotalCero = value; }
            get { return this._subtotalCero; }
        }

        public string ivaCobrado
        {
            set { this._ivaCobrado = value; }
            get { return this._ivaCobrado; }
        }

        public string iceCobrado
        {
            set { this._iceCobrado = value; }
            get { return this._iceCobrado; }
        }

        public string valorDescuento
        {
            set { this._valorDescuento = value; }
            get { return this._valorDescuento; }
        }

        public string fechaVencimiento
        {
            set { this._fechaVencimiento = value; }
            get { return this._fechaVencimiento; }
        }

        public string servicioCobrado
        {
            set { this._servicioCobrado = value; }
            get { return this._servicioCobrado; }
        }

        public string totalPagar
        {
            set { this._totalPagar = value; }
            get { return this._totalPagar; }
        }

        public string totalPagarTexto
        {
            set { this._totalPagarTexto = value; }
            get { return this._totalPagarTexto; }
        }

        public List<adicionalFactura> adicionales
        {
            set { this._adicionales = value; }
            get { return this._adicionales; }
        }

        public List<String[]> detalle
        {
            set { this._detalle = value; }
            get { return this._detalle; }
        }

        public string obtenerValor(Coordenada coordenada)
        {
            if (coordenada.tipo == 2) return "";
            string propiedad = coordenada.nombre;
            if (propiedad == "clienteNombre") return this._clienteNombre;
            else if (propiedad == "fechaActual") return this._fechaActual;
            else if (propiedad == "clienteCedula") return this._clienteCedula;
            else if (propiedad == "clienteTelefono") return this._clienteTelefono;
            else if (propiedad == "clienteDireccion") return this._clienteDireccion;
            else if (propiedad == "subtotalIVA") return this._subtotalIVA;
            else if (propiedad == "subtotalCero") return this._subtotalCero;
            else if (propiedad == "ivaCobrado") return this._ivaCobrado;
            else if (propiedad == "iceCobrado") return this._iceCobrado;
            else if (propiedad == "valorDescuento") return this._valorDescuento;
            else if (propiedad == "servicioCobrado") return this._servicioCobrado;
            else if (propiedad == "totalPagar") return this._totalPagar;
            else if (propiedad == "totalPagarTexto") return this._totalPagarTexto;
            else if (propiedad == "fechaVencimiento") return this._fechaVencimiento;
            else if (propiedad == "dineroEntregado") return this._dineroEntregado;
            else if (propiedad == "vuelto") return this._vuelto;
            else if (propiedad == "dia") return DateTime.Now.Day.ToString();
            else if (propiedad == "mes") return DateTime.Now.Month.ToString();
            else if (propiedad == "anio") return DateTime.Now.Year.ToString();
            else if (this.adicionales != null && propiedad.IndexOf("adicional") >= 0)
            {
                //if (this.adicionales.Count >= Convert.ToInt32(propiedad.Substring(9)) - 1) ;
                adicionalFactura adicional = this.adicionales[Convert.ToInt32(propiedad.Substring(9)) - 1];
                if (adicional.tipo == 1) return adicional.valor;
                else
                {
                    DateTime fecha;
                    if (DateTime.TryParse(adicional.valor, out fecha)) return fecha.ToShortDateString();
                    return adicional.valor;
                }
            }
            return "";
        }

        public void imprimir(int desplazamiento, int cortarCaracteres, short copias)
        {
            this.desplazamiento = desplazamiento;
            this.cortarCaracteres = cortarCaracteres;
            PrintDocument impresion = new PrintDocument();
            PrintController printController = new StandardPrintController();
            impresion.PrintController = printController;
            impresion.PrinterSettings.Copies = copias;
            impresion.PrinterSettings.PrinterName = Global.nombreImpresora;
            impresion.PrintPage += new PrintPageEventHandler(imprimirFactura);

            List<object> parametros = Pos.Coneccion.ParametroTR.ConsultarInt("41,42");
            Decimal ancho = Convert.ToDecimal(parametros[0]);
            Decimal alto = Convert.ToDecimal(parametros[1]);
            if (ancho > 0 && alto > 0)
            {
                ancho = (ancho / 2.54M) * 100;
                alto = (alto / 2.54M) * 100;
                PaperSize psize = new PaperSize("Custom",Convert.ToInt32(ancho),Convert.ToInt32(alto));
                impresion.DefaultPageSettings.PaperSize = psize;
            }

            impresion.Print();
        }

        protected int impresoraX(decimal valor)
        {
            return (int)valor;
            //int resultado = (int)((valor * (decimal)120) / this.ppi);
            //return resultado;

        }

        protected int impresoraY(decimal valor)
        {
            return (int)valor;
            //int resultado = (int)((valor * (decimal)72) / this.ppi);
            //return resultado;
        }

        protected void imprimirFactura(object sender, PrintPageEventArgs ev)
        {
            CoordenadaTR tran = new CoordenadaTR();
            string mensaje = "";
            List<Coordenada> coordenadas = tran.consultarActivas(ref mensaje,1);
            Point codigo = new Point();
            Point pvp = new Point();
            Point cantidad = new Point();
            Point nombre = new Point();
            Point subtotal = new Point();
            Point descripcion = new Point();
            // ev.Graphics.DrawImage(Image.FromFile(@"C:\Users\user\Desktop\factura.jpg"),0,0);
            foreach (Coordenada coordenada in coordenadas)
            {
                if (coordenada.tipo != 1)
                {
                    if (!coordenada.derecha) ev.Graphics.DrawString(((!String.IsNullOrEmpty(coordenada.valor)) ? coordenada.valor : "") + this.obtenerValor(coordenada), this.letra, this.pincel, this.impresoraX(coordenada.X), this.impresoraY(coordenada.Y));
                    else
                    {
                        StringFormat drawFormat = new StringFormat();
                        drawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                        ev.Graphics.DrawString(((!String.IsNullOrEmpty(coordenada.valor)) ? coordenada.valor : "") + this.obtenerValor(coordenada), this.letra, this.pincel, this.impresoraX(coordenada.X), this.impresoraY(coordenada.Y), drawFormat);
                    }
                }
                else
                {
                    if (coordenada.nombre == "productoCodigo")
                    {
                        codigo.X = (int)coordenada.X;
                        codigo.Y = (int)coordenada.Y;
                    }
                    else if (coordenada.nombre == "productoPVP")
                    {
                        pvp.X = (int)coordenada.X;
                        pvp.Y = (int)coordenada.Y;
                    }
                    else if (coordenada.nombre == "productoCantidad")
                    {
                        cantidad.X = (int)coordenada.X;
                        cantidad.Y = (int)coordenada.Y;
                    }
                    else if (coordenada.nombre == "productoNombre")
                    {
                        nombre.X = (int)coordenada.X;
                        nombre.Y = (int)coordenada.Y;
                    }
                    else if (coordenada.nombre == "productoTotal")
                    {
                        subtotal.X = (int)coordenada.X;
                        subtotal.Y = (int)coordenada.Y;
                    }
                    else if (coordenada.nombre == "productoDescripcion")
                    {
                        descripcion.X = (int)coordenada.X;
                        descripcion.Y = (int)coordenada.Y;
                    }
                }
            }

            foreach (string[] datos in this.detalle)
            {
                if (codigo.X > 0 || codigo.Y > 0)
                {
                    ev.Graphics.DrawString(datos[0], this.letra, this.pincel, codigo);
                    codigo.Y += this.desplazamiento;
                }
                if (cantidad.X > 0 || cantidad.Y > 0)
                {
                    ev.Graphics.DrawString(datos[1], this.letra, this.pincel, cantidad);
                    cantidad.Y += this.desplazamiento;
                }
                if (nombre.X > 0 || nombre.Y > 0)
                {
                    ev.Graphics.DrawString((datos[2].Length > this.cortarCaracteres) ? datos[2].Substring(0, this.cortarCaracteres) : datos[2], this.letra, this.pincel, nombre);
                    nombre.Y += this.desplazamiento;
                }
                if (pvp.X > 0 || pvp.Y > 0)
                {
                    ev.Graphics.DrawString(datos[3], this.letra, this.pincel, pvp);
                    pvp.Y += this.desplazamiento;
                }
                if (subtotal.X > 0 || subtotal.Y > 0)
                {
                    ev.Graphics.DrawString(datos[4], this.letra, this.pincel, subtotal);
                    subtotal.Y += this.desplazamiento;
                }
                if (descripcion.X > 0 || descripcion.Y > 0)
                {
                    ev.Graphics.DrawString(datos[5], this.letra, this.pincel, descripcion);
                    descripcion.Y += this.desplazamiento;
                }
            }

        }
    }
}
