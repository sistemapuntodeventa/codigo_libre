using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pos.Clases
{
    class Promocion
    {
        private int _id;
        private int _agrupacion;
        private string _nombre;
        private decimal _descuento;
        private int _cantidad;
        private bool _domingo;
        private bool _lunes;
        private bool _martes;
        private bool _miercoles;
        private bool _jueves;
        private bool _viernes;
        private bool _sabado;
        private string _estado;
        private string _tipo;
        private string _seleccion;
        //private bool _mismoGrupo;
        private DateTime _desde;
        private DateTime _hasta;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int agrupacion
        {
            get { return _agrupacion; }
            set { _agrupacion = value; }
        }

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public decimal descuento
        {
            get { return _descuento; }
            set { _descuento = value; }
        }

        public int cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public bool domingo
        {
            get { return _domingo; }
            set { _domingo = value; }
        }

        public bool lunes
        {
            get { return _lunes; }
            set { _lunes = value; }
        }

        public bool martes
        {
            get { return _martes; }
            set { _martes = value; }
        }

        public bool miercoles
        {
            get { return _miercoles; }
            set { _miercoles = value; }
        }

        public bool jueves
        {
            get { return _jueves; }
            set { _jueves = value; }
        }

        public bool viernes
        {
            get { return _viernes; }
            set { _viernes = value; }
        }

        public bool sabado
        {
            get { return _sabado; }
            set { _sabado = value; }
        }


        public string estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public string tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public string seleccion
        {
            get { return _seleccion; }
            set { _seleccion = value; }
        }
        //public bool mismoGrupo
        //{
        //    get { return _mismoGrupo; }
        //    set { _mismoGrupo = value; }
        //}

        public DateTime desde
        {
            get { return _desde; }
            set { _desde = value; }
        }

        public DateTime hasta
        {
            get { return _hasta; }
            set { _hasta = value; }
        }
    }
}
