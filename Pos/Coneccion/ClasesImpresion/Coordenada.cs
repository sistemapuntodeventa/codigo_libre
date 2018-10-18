using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestLib
{
    public class Coordenada
    {
        private int _id;
        private string _nombre;
        private decimal _x;
        private decimal _y;
        private int _tipo;
        private bool _derecha;
        private string _valor;

        public int id
        {
            set { this._id = value; }
            get { return this._id; }
        }

        public string nombre
        {
            set { this._nombre = value; }
            get { return this._nombre; }
        }

        public decimal X
        {
            set { this._x = value; }
            get { return this._x; }
        }

        public decimal Y
        {
            set { this._y = value; }
            get { return this._y; }
        }

        public int tipo
        {
            set { this._tipo = value; }
            get { return this._tipo; }
        }

        public string valor
        {
            set { this._valor = value; }
            get { return this._valor; }
        }

        public bool derecha
        {
            set { this._derecha = value; }
            get { return this._derecha; }
        }
    }
}
