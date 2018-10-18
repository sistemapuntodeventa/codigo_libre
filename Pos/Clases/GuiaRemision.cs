using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestLib;
using System.Drawing;
using System.Drawing.Printing;

namespace Pos.Clases
{

    public class Destinatario
    {
        public int id { get; set; }
        public Persona cliente { get; set; }
        public string direccion { get; set; }
        public string motivo { get; set; }
        public string codigoDestino { get; set; }
        public string ruta { get; set; }
        public FacturaCabecera documento { get; set; }
        public List<String[]> detalle { get; set; }
    }

    class GuiaRemision
    {
        public int id { get; set; }
        public int id_caja { get; set; }
        public string numeroDocumento { get; set; }
        public string autorizacion { get; set; }
        public DateTime fechaEmision { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public string direccionPartida { get; set; }
        public string placa { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
        public List<Destinatario> destinatarios { get; set; }
        public Persona transportista { get; set; }
        public Caja caja { get; set; }
        private Font letra;
        private SolidBrush pincel;
        private int desplazamiento;
        private int cortarCaracteres;


        public GuiaRemision()
        {
            this.pincel = new SolidBrush(Color.Black);
            this.letra = new Font("Sans Serif", 9, FontStyle.Regular);
        }

        public object this[string propertyName]
        {
            get
            {
                return ((object)this).GetType().GetProperty(propertyName).GetValue(this, null);
            }
        }


        public void imprimir(int desplazamiento, int cortarCaracteres)
        {
            this.desplazamiento = desplazamiento;
            this.cortarCaracteres = cortarCaracteres;
            PrintDocument impresion = new PrintDocument();
            impresion.PrintPage += new PrintPageEventHandler(imprimirGuia);
            impresion.Print();
        }

        public string obtenerValor(Coordenada coordenada)
        {
            if (coordenada.tipo == 2) return "";
            string propiedad = coordenada.nombre;
            if (propiedad == "nombreDestinatario") return this.destinatarios[0].cliente.razon_social;
            if (propiedad == "cedulaDestinatario") return this.destinatarios[0].cliente.cedula;
            if (propiedad == "direccionDestinatario") return this.destinatarios[0].direccion;
            if (propiedad == "codigoDestinatario") return this.destinatarios[0].codigoDestino;
            if (propiedad == "rutaDestinatario") return this.destinatarios[0].ruta;
            if (propiedad == "nombreTransportista") return this.transportista.razon_social;
            if (propiedad == "cedulaTransportista") return this.transportista.cedula;
            if (propiedad == "correoTransportista") return this.transportista.email;
            return this[coordenada.nombre].ToString();
        }

        protected void imprimirGuia(object sender, PrintPageEventArgs ev)
        {
            CoordenadaTR tran = new CoordenadaTR();
            string mensaje = "";
            List<Coordenada> coordenadas = tran.consultarActivas(ref mensaje, 2);
            Point unidad = new Point();
            Point cantidad = new Point();
            Point nombre = new Point();
            StringFormat drawFormat = new StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;

            foreach (Coordenada coordenada in coordenadas)
            {
                if (coordenada.tipo == 0) ev.Graphics.DrawString(this.obtenerValor(coordenada), this.letra, this.pincel, (int)coordenada.X, (int)coordenada.Y,coordenada.derecha?drawFormat:null);
                else if (coordenada.tipo == 1)
                {
                    if (coordenada.nombre == "productoCantidad")
                    {
                        cantidad.X = (int)coordenada.X;
                        cantidad.Y = (int)coordenada.Y;
                    }
                    else if (coordenada.nombre == "unidadProducto")
                    {
                        unidad.X = (int)coordenada.X;
                        unidad.Y = (int)coordenada.Y;
                    }
                    else if (coordenada.nombre == "productoNombre")
                    {
                        nombre.X = (int)coordenada.X;
                        nombre.Y = (int)coordenada.Y;
                    }
                }
            }

            List<string[]> detalle = this.destinatarios[0].detalle;
            foreach (string[] datos in detalle)
            {
                if (unidad.X > 0 || unidad.Y > 0)
                {
                    ev.Graphics.DrawString(datos[3], this.letra, this.pincel, unidad);
                    unidad.Y += this.desplazamiento;
                }
                if (cantidad.X > 0 || cantidad.Y > 0)
                {
                    ev.Graphics.DrawString(datos[2], this.letra, this.pincel, cantidad,drawFormat);
                    cantidad.Y += this.desplazamiento;
                }
                if (nombre.X > 0 || nombre.Y > 0)
                {
                    ev.Graphics.DrawString((datos[1].Length > this.cortarCaracteres) ? datos[1].Substring(0, this.cortarCaracteres) : datos[1], this.letra, this.pincel, nombre);
                    nombre.Y += this.desplazamiento;
                }
            }

        }
    }
}

