using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pos.Clases
{
    class Ubicacion
    {
        private int _id;
        private string _nombre;
        private string _impresora;
        private string _estado;
        private List<FacturaDetalle> _productos;
        private List<FacturaDetalle> _productosEliminados;

        public Ubicacion()
        {
            this.productos = new List<FacturaDetalle>();
            this.productosEliminados = new List<FacturaDetalle>();
        }

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string impresora
        {
            get { return _impresora; }
            set { _impresora = value; }
        }

        public string estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public List<FacturaDetalle> productos
        {
            get { return _productos; }
            set { _productos = value; }
        }

        public List<FacturaDetalle> productosEliminados
        {
            get { return _productosEliminados; }
            set { _productosEliminados = value; }
        }
    }
}
