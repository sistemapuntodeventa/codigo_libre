using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pos.Clases
{
    public class Autorizacion
    {
        private int idtbl_autorizacion;
        private int id_establecimiento;
        private DateTime fechaVencimiento;
        private string secuenciaInicio;
        private string secuenciaFin;
        private string numeroAutorizacion;
        private bool estado;

        public Autorizacion()
        {
            this.idtbl_autorizacion = 0;
            this.id_establecimiento = 0;
            this.numeroAutorizacion = "";
            this.estado = true;
        }

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }        

        public int Idtbl_autorizacion
        {
            get { return idtbl_autorizacion; }
            set { idtbl_autorizacion = value; }
        }


        public DateTime FechaVencimiento
        {
            get { return fechaVencimiento; }
            set { fechaVencimiento = value; }
        }

        public string NumeroAutorizacion
        {
            get { return numeroAutorizacion; }
            set { numeroAutorizacion = value; }
        }

        public string SecuenciaInicio
        {
            get { return secuenciaInicio; }
            set { secuenciaInicio = value; }
        }

        public string SecuenciaFin
        {
            get { return secuenciaFin; }
            set { secuenciaFin = value; }
        }

        public int Id_Establecimiento
        {
            get { return id_establecimiento; }
            set { id_establecimiento = value; }
        }

        
    }
}
