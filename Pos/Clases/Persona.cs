using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pos.Clases
{
    public class Persona
    {
        public int id  { get; set; }
        private int empresa_id { get; set; }
        public string ruc { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime ultimo_cambio { get; set; }
        public string cedula { get; set; }
        public string razon_social { get; set; }
        public string telefonos { get; set; }
        public string direccion { get; set; }
        public string tipo { get; set; }
        public bool es_cliente { get; set; }
        public bool es_empleado { get; set; }
        public bool tiene_deuda { get; set; }
        public string tipo_contrato { get; set; }
        public decimal? sueldo { get; set; }
        public string email { get; set; }
        public bool es_vendedor { get; set; }
        public int? id_contifico { get; set; }
        public decimal? porcentaje_descuento { get; set; }
        public string estado { get; set; }
        public bool es_extranjero { get; set; }
        public string codigo { get; set; }
        public bool bloqueado { get; set; } //sk1

        public Persona()
        {
            this.ruc = "";
            this.cedula = "";
            this.tipo = "";
            this.es_cliente = true;
            this.es_empleado = false;
            this.es_vendedor = false;
            this.es_extranjero = false;
            this.bloqueado = false;
           

        }

      

        public static Persona generar(Dictionary<String, String> diccionario)
        {
            Persona persona = new Persona();
            //persona.id = Int32.Parse(diccionario["id"]);
            persona.ruc = diccionario["ruc"];
            persona.cedula= diccionario["cedula"];
            persona.razon_social = diccionario["razon_social"];
            persona.telefonos= diccionario["telefonos"];
            persona.direccion= diccionario["direccion"];
            persona.tipo = diccionario["tipo"];
            persona.es_cliente = bool.Parse(diccionario["es_cliente"]);
            persona.es_empleado = bool.Parse(diccionario["es_empleado"]);
            persona.tipo_contrato = diccionario["tipo_contrato"];
            persona.email = diccionario["email"];
            persona.es_vendedor = bool.Parse(diccionario["es_vendedor"]);
            persona.bloqueado = bool.Parse(diccionario["bloqueado"]);  //sk3
            persona.id_contifico = Int32.Parse(diccionario["id"]);
            persona.porcentaje_descuento = decimal.Parse(diccionario["porcentaje_descuento"]);
            persona.estado = diccionario["estado"];
            persona.es_extranjero = bool.Parse(diccionario["es_extranjero"]);
            //persona.codigo = diccionario["codigo"];
            //persona.tiene_deuda = bool.Parse(diccionario["tiene_deuda"]); //codigo tiene_deuda prueba
            persona.ultimo_cambio = DateTime.Parse(diccionario["ultimo_cambio"]);
            persona.fecha_creacion = DateTime.Parse(diccionario["fecha_creacion"]);

            return persona;
           
        }

    }
}
