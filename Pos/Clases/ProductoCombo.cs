using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pos.Clases
{
    public class ProductoCombo
    {
        private int _id;
        private string _nombre;
        private bool _obligatorio;
        private bool _mostrar_siempre;
        private bool _agregar_factura;
        private string _tipo_seleccion;
        private string _estado;
        private List<ProductoComboProducto> _productos_escoger;
        private List<ProductoComboProducto> _productos_aplican;
        
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

        public bool obligatorio
        {
            get { return _obligatorio; }
            set { _obligatorio = value; }
        }

        public bool agregar_factura
        {
            get { return _agregar_factura; }
            set { _agregar_factura = value; }
        }

        public bool mostrar_siempre
        {
            get { return _mostrar_siempre; }
            set { _mostrar_siempre = value; }
        }

        public string tipo_seleccion
        {
            get { return _tipo_seleccion; }
            set { _tipo_seleccion = value; }
        }

        public string estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public List<ProductoComboProducto> productos_escoger
        {
            get { return _productos_escoger; }
            set { _productos_escoger = value; }
        }

        public List<ProductoComboProducto> productos_aplican
        {
            get { return _productos_aplican; }
            set { _productos_aplican = value; }
        }
    }

    public class ProductoComboProducto
    {
        private int? _id;
        private int _tipo;
        private string _nombre;
        private string _codigo;
        private bool _escogido;
        private object _referencia;

        public ProductoComboProducto() 
        {
            this.tipo = 1;
            this.id = null;
            this.nombre = null;
        }

        public int? id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }


        public string codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public bool escogido
        {
            get { return _escogido; }
            set { _escogido = value; }
        }

        public object referencia
        {
            get { return _referencia; }
            set { _referencia = value; }
        }
    }
}
