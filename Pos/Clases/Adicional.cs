using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pos.Clases
{
    class Adicional
    {
        private int _idAdicional;
        private string _nombre;
        private string _etiqueta;
        private string _tipo;
        private string _estado;
        private bool _obligatorio;
        private bool _mostrarEnListado;
        private List<String> _items;

        public Adicional()
        {
            //this.items = new List<String>();
        }

        public int idAdicional
        {
            get { return _idAdicional; }
            set { _idAdicional = value; }
        }

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string etiqueta
        {
            get { return _etiqueta; }
            set { _etiqueta = value; }
        }

        public string tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public string estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public bool obligatorio
        {
            get { return _obligatorio; }
            set { _obligatorio = value; }
        }

        public bool mostrarEnListado
        {
            get { return _mostrarEnListado; }
            set { _mostrarEnListado = value; }
        }
        public List<String> items
        {
            get { return _items; }
            set { _items = value; }
        }

    }
}
