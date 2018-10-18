using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pos.Clases
{
    public class Empresa
    {
        int idtbl_empresa, bodega, numeroDecimales, idConsumidorFinal, idCaja;  
        string ruc, razon_social, telefonos, direccion;
        string claveGenerada;   

        public Empresa()
        {

        }

        public int Idtbl_empresa
        {
            get { return idtbl_empresa; }
            set { idtbl_empresa = value; }
        }

        public String Ruc
        {
            get { return ruc; }
            set { ruc = value; }
        }

        public String Razon_social
        {
            get { return razon_social; }
            set { razon_social = value; }
        }

        public String Telefonos
        {
            get { return telefonos; }
            set { telefonos = value; }
        }

        public String Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string ClaveGenerada
        {
            get { return claveGenerada; }
            set { claveGenerada = value; }
        }

        public int Bodega
        {
            get { return bodega; }
            set { bodega = value; }
        }

        public int NumeroDecimales
        {
            get { return numeroDecimales; }
            set { numeroDecimales = value; }
        }

        public int IdConsumidorFinal
        {
            get { return idConsumidorFinal; }
            set { idConsumidorFinal = value; }
        }

        public int IdCaja
        {
            get { return idCaja; }
            set { idCaja = value; }
        }

    }
}
