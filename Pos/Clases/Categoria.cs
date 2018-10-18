using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pos.Clases
{
    public class Categoria
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int? padre_id { get; set; }
        public string codigo { get; set; }
        public string tipo { get; set; }

    }
}
