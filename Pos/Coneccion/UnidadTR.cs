using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pos.Clases;
using MySql.Data.MySqlClient;
using System.Data;

namespace Pos.Coneccion
{
    public class UnidadTR
    {
        private Conexion conf;
        private string nombre_stp;
        private Unidad unidad;

        public UnidadTR(Unidad unidad)
        {
            this.conf = new Conexion();
            this.unidad = unidad;
        }

        public UnidadTR(String nombreSP)
        {
            this.conf = new Conexion();
            this.nombre_stp = nombreSP;
            this.unidad = new Unidad();
        }

        public Conexion Conf
        {
            get { return conf; }
            set { conf = value; }
        }

        public string Nombre_stp
        {
            get { return nombre_stp; }
            set { nombre_stp = value; }
        }

        public Unidad Unidad
        {
            get { return unidad; }
            set { unidad = value; }
        }
    }
}
