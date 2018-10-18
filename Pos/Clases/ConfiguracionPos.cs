using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pos.Clases
{
    public class ConfiguracionPos
    {

        int idconf_pos, id_empresa, id_establecimiento, sec_inicio, sec_final, sec_actual, idAutorizacion;
        string secuencia_doc, autorizacion, nombre_maquina, tipo_doc, codigo_establecimiento,
               pto_emision, secuencial;              
        DateTime fecha_venciminento;
        bool activa, sin_cobro, stock, servicio, activar_secuencia, predeterminada, secuenciaAlImprimir;             

        public ConfiguracionPos()
        {
            this.idconf_pos=0;
            this.id_empresa=0;
            this.id_establecimiento=0;
            this.sec_inicio=0;
            this.sec_final = 0;
            this.sec_actual=0;
            this.secuencia_doc="";
            this.autorizacion="";
            this.nombre_maquina = "";
            this.tipo_doc="";
            this.codigo_establecimiento = "";
            this.pto_emision = "";
            this.secuencial = "";
            this.activa=true;
            this.fecha_venciminento = DateTime.Now;
            this.idAutorizacion = 0;
            this.sin_cobro = false;
            this.stock = false;
            this.servicio = false;
            this.activar_secuencia = false;
            this.predeterminada = false;
            this.secuenciaAlImprimir = false;
        }

        public int Idconf_pos
        {
            get { return idconf_pos; }
            set { idconf_pos = value; }
        }

        public int Id_empresa
        {
            get { return id_empresa; }
            set { id_empresa = value; }
        }

        public int Id_establecimiento
        {
            get { return id_establecimiento; }
            set { id_establecimiento = value; }
        }

        public int Sec_inicio
        {
            get { return sec_inicio; }
            set { sec_inicio = value; }
        }

        public int Sec_final
        {
            get { return sec_final; }
            set { sec_final = value; }
        }

        public int Sec_actual
        {
            get { return sec_actual; }
            set { sec_actual = value; }
        }

        public string Secuencia_doc
        {
            get { return secuencia_doc; }
            set { secuencia_doc = value; }
        }

        public string Autorizacion
        {
            get { return autorizacion; }
            set { autorizacion = value; }
        }

        public string Nombre_Maquina
        {
            get { return nombre_maquina; }
            set { nombre_maquina = value; }
        }

        public string Tipo_doc
        {
            get { return tipo_doc; }
            set { tipo_doc = value; }
        }

        public DateTime Fecha_venciminento
        {
            get { return fecha_venciminento; }
            set { fecha_venciminento = value; }
        }

        public string Codigo_establecimiento
        {
            get { return codigo_establecimiento; }
            set { codigo_establecimiento = value; }
        }

        public string Pto_emision
        {
            get { return pto_emision; }
            set { pto_emision = value; }
        }

        public bool SecuenciaAlImprimir
        {
            get { return secuenciaAlImprimir; }
            set { secuenciaAlImprimir = value; }
        }

        public bool Activa
        {
            get { return activa; }
            set { activa = value; }
        }

        public string Secuencial
        {
            get { return secuencial; }
            set { secuencial = value; }
        }

        public int IdAutorizacion
        {
            get { return idAutorizacion; }
            set { idAutorizacion = value; }
        }

        public bool Sin_cobro
        {
            get { return sin_cobro; }
            set { sin_cobro = value; }
        }

        public bool Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        public bool Servicio
        {
            get { return servicio; }
            set { servicio = value; }
        }

        public bool Activar_secuencia
        {
            get { return activar_secuencia; }
            set { activar_secuencia = value; }
        }

        public bool Predeterminada
        {
            get { return predeterminada; }
            set { predeterminada = value; }
        } 
       
    }
}
