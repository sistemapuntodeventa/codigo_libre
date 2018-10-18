using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pos.Clases
{
    class ItemMenu
    {
        private int _id;
        private int _idPadre;
        private string _nombre;
        private string _nombreItem;
        private string _estado;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int idPadre
        {
            get { return _idPadre; }
            set { _idPadre = value; }
        }

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string nombreItem
        {
            get { return _nombreItem; }
            set { _nombreItem = value; }
        }

        public string estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
    }
}
