using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pos.Clases
{
    class Rol
    {

        private int idrol_usuario;
        private string nombre;
        private bool estado;

        public Rol()
        {
            this.idrol_usuario=0;
            this.nombre="";
            this.estado=true;
        }

        public int Idrol_usuario
        {
          get { return idrol_usuario; }
          set { idrol_usuario = value; }
        }

        public string Nombre
        {
          get { return nombre; }
          set { nombre = value; }
        }

        public bool Estado
        {
          get { return estado; }
          set { estado = value; }
        }


    }
}
