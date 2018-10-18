using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pos.Clases
{
    class FacturaDetalle
    {
        int idfactura_detalle;
        int idfactura_cabecera;
        int id_producto;
        int? id_serie;

        string producto;
        decimal cantidad;
        decimal porc_ice;
        decimal porc_iva;
        decimal porc_descuento;
        decimal valor_descuento;
        decimal total;
        decimal precio;
        decimal unidad_id;
        decimal base_cero;
        decimal base_gravable;
        decimal base_nogravable;
        decimal ice;
        decimal tipo_reteid;
        decimal pvp_venta;
        string descripcion;
        List<ProductoCombo> listaCombo;
        bool esCombo;

        //Producto producto;
        //Unidad unidad;        
        
        public FacturaDetalle()
        {
            this.idfactura_detalle = 0;
            this.idfactura_cabecera = 0;
            this.id_producto = 0;
            this.cantidad = 0;
            this.porc_descuento = 0;
            this.valor_descuento = 0;
            this.total = 0;
            //this.producto = new Producto();
            //this.unidad = new Unidad();
            this.listaCombo = null;
            this.Id_Serie = null;
        }

        public List<ProductoCombo> ListaCombo
        {
            get { return listaCombo; }
            set { listaCombo = value; }
        }

        public bool EsCombo
        {
            get { return esCombo; }
            set { esCombo = value; }
        }

        public string Producto
        {
            get { return producto; }
            set { producto = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public int Idfactura_detalle
        {
            get { return idfactura_detalle; }
            set { idfactura_detalle = value; }
        }

        public int Idfactura_cabecera
        {
            get { return idfactura_cabecera; }
            set { idfactura_cabecera = value; }
        }

        public int Id_producto
        {
            get { return id_producto; }
            set { id_producto = value; }
        }

        public int? Id_Serie
        {
            get { return id_serie; }
            set { id_serie = value; }
        }

        public decimal Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public decimal Porc_Ice
        {
            get { return porc_ice; }
            set { porc_ice = value; }
        }

        public decimal Porc_Iva
        {
            get { return porc_iva; }
            set { porc_iva = value; }
        }

        public decimal Porc_descuento
        {
            get { return porc_descuento; }
            set { porc_descuento = value; }
        }

        public decimal Valor_descuento
        {
            get { return valor_descuento; }
            set { valor_descuento = value; }
        }

        public decimal Total
        {
            get { return total; }
            set { total = value; }
        }

        public decimal Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public decimal Unidad_id
        {
            get { return unidad_id; }
            set { unidad_id = value; }
        }

        public decimal Base_cero
        {
            get { return base_cero; }
            set { base_cero = value; }
        }

        public decimal Base_gravable
        {
            get { return base_gravable; }
            set { base_gravable = value; }
        }

        public decimal Base_nogravable
        {
            get { return base_nogravable; }
            set { base_nogravable = value; }
        }

        public decimal Ice
        {
            get { return ice; }
            set { ice = value; }
        }

        public decimal Tipo_reteid
        {
            get { return tipo_reteid; }
            set { tipo_reteid = value; }
        }

        public decimal Pvp_venta
        {
            get { return pvp_venta; }
            set { pvp_venta = value; }
        }

        /*public Producto Producto
        {
            get { return producto; }
            set { producto = value; }
        }

        public Unidad Unidad
        {
            get { return unidad; }
            set { unidad = value; }
        }*/
    }
}
