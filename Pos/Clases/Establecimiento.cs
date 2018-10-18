using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pos.Clases
{
    public class Establecimiento
    {
        private int idtbl_establecimiento;
        private  int id_empresa;
        private string nombre;
        private string direccion;
        private bool estado;     

        public Establecimiento() 
        {
            this.idtbl_establecimiento = 0;
            this.id_empresa = 0;
            this.nombre = "";
            this.direccion = "";
            this.estado = true;
        }

        public int Id_empresa
        {
            get { return id_empresa; }
            set { id_empresa = value; }
        }

        public int Idtbl_establecimiento
        {
            get { return idtbl_establecimiento; }
            set { idtbl_establecimiento = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }

       
    }
}
