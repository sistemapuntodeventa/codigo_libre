using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pos.Clases
{
    public class Producto
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string codigo_barra { get; set; }
        public int unidad_id { get; set; }
        public int categoria_id { get; set; }
        public int porcentaje_iva { get; set; }
        public decimal pvp1 { get; set; }
        public decimal pvp2 { get; set; }
        public decimal pvp3 { get; set; }
        public decimal minimo { get; set; }
        public decimal cantidad_stock { get; set; }
        public string estado { get; set; }
        public bool pvp_manual { get; set; }
        public bool seriado { get; set; }
        public List<String> series { get; set; }
        public string unidad { get; set; }
        
        public Producto()
        {
            this.id = 0;
            //this.unidad_id = 0;
            this.categoria_id = 0;
            this.codigo = "";
            this.nombre = "";
            this.pvp1 = 0;
            this.minimo = 0;
            this.porcentaje_iva = 0;
            this.pvp2 = 0;
            this.pvp3 = 0;
            this.cantidad_stock = 0;
            this.series = null;
        }

        public static Producto generar(Dictionary<String, String> diccionario)
        { 
            Producto producto = new Producto();
            producto.id = Int32.Parse(diccionario["id"]);
            producto.codigo = diccionario["codigo"];
            producto.nombre = diccionario["nombre"];
            producto.codigo_barra = diccionario["codigo_barra"];
            producto.unidad_id = Int32.Parse(diccionario["unidad_id"]);
            producto.categoria_id = Int32.Parse(diccionario["categoria_id"]);
            producto.porcentaje_iva = diccionario["porcentaje_iva"] != "" ? Int32.Parse(diccionario["porcentaje_iva"]) : 0;
            producto.pvp1 = diccionario["pvp1"] != "" ? Decimal.Parse(diccionario["pvp1"]) : 0;
            producto.pvp2 = diccionario["pvp2"] != "" ? Decimal.Parse(diccionario["pvp2"]) : 0;
            producto.pvp3 = diccionario["pvp3"] != "" ? Decimal.Parse(diccionario["pvp3"]) : 0;
            producto.minimo = diccionario["minimo"] != "" ? Decimal.Parse(diccionario["minimo"]) : 0;
            producto.cantidad_stock = diccionario["cantidad_stock"] != "" ? Decimal.Parse(diccionario["cantidad_stock"]) : 0;
            producto.descripcion = diccionario["descripcion"];
            producto.estado = diccionario["estado"];
            String series = diccionario["series"].Substring(1, diccionario["series"].Length - 2);
            if (!String.IsNullOrEmpty(series))
            {
                producto.series = new List<string>();
                foreach (String serie in series.Split(','))
                {
                    producto.series.Add(serie.Substring(1, serie.Length - 2));
                }
                //producto.series = series.Split(',').ToList();
            }
            producto.pvp_manual = Boolean.Parse(diccionario["pvp_manual"]);
            producto.seriado = Boolean.Parse(diccionario["seriado"]);
            return producto;
        }

    }
}
