using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pos.Clases
{
    class PromocionFactura
    {
        private int _id;
        private int _agrupacion;
        private int _cantidad;
        private int _descuento;
        private decimal _valorDescuento;
        private bool _aplicar;
        private List<valoresMenores> _menores;
        private List<PromocionGrupo> _grupo;
        private List<valoresMenores>[] _combo;
        private string _tipo;
        private string _seleccion;

        public PromocionFactura()
        {
            this._aplicar = false;
        }

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int agrupacion
        {
            get { return _agrupacion; }
            set { _agrupacion = value; }
        }

        public int cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public int descuento
        {
            get { return _descuento; }
            set { _descuento = value; }
        }

        public decimal valorDescuento
        {
            get { return _valorDescuento; }
            set { _valorDescuento = value; }
        }

        public bool aplicar
        {
            get { return _aplicar; }
            set { _aplicar = value; }
        }

        public List<valoresMenores> menores
        {
            get { return _menores; }
            set { _menores = value; }
        }

        public List<PromocionGrupo> grupo
        {
            get { return _grupo; }
            set { _grupo = value; }
        }

        public List<valoresMenores>[] combo
        {
            get { return _combo; }
            set { _combo = value; }
        }

        public string tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public string seleccion
        {
            get { return _seleccion; }
            set { _seleccion = value; }
        }

        public void insertarAscendente(valoresMenores elemento, List<valoresMenores> lista = null)
        {
            List<valoresMenores> listaItems = null;
            listaItems = (lista == null)?this.menores:lista;

            if (listaItems.Count < 1)
            {
                listaItems.Add(elemento);
                return;
            }
            for (int i = 0; i < listaItems.Count; i++)
            {
                if (elemento.valor < listaItems[i].valor)
                {
                    listaItems.Insert(i, elemento);
                    return;
                }
            }
            listaItems.Add(elemento);
        }

        public int contarProductos(List<valoresMenores> lista = null)
        { 
            int a = 0;
            List<valoresMenores> listaItems = null;
            listaItems = (lista == null) ? this.menores : lista;

            foreach (valoresMenores elemento in listaItems) a += elemento.cantidad;
            return a;
        }

        public static void setValoresPromociones(List<PromocionFactura> promociones, System.Windows.Forms.DataGridView grw_productos,decimal subtotalFactura)
        {
            foreach (PromocionFactura promocion in promociones)
            {
                if (promocion.tipo != "C")
                {
                    if (promocion.agrupacion == 1)
                    {
                        int cAplican = promocion.contarProductos() / promocion.cantidad;
                        if (cAplican > 0)
                        {
                            promocion.valorDescuento = promocion.getValorDescuento(cAplican, grw_productos, promocion.menores);
                            if(!PromocionFactura.existeMejorPromocion(promocion.menores,promocion.valorDescuento,promociones))promocion.aplicar = true;
                        }
                    }
                    else
                    {
                        foreach (PromocionGrupo grupo in promocion.grupo)
                        {
                            int cAplican = promocion.contarProductos(grupo.menores) / promocion.cantidad;
                            if (cAplican > 0)
                            {
                                promocion.valorDescuento = promocion.getValorDescuento(cAplican, grw_productos, grupo.menores);
                                if (!PromocionFactura.existeMejorPromocion(grupo.menores, grupo.valorDescuento, promociones)) promocion.aplicar = true;
                            }
                        }
                    }
                }
                else
                {
                    if (promocion.seleccion == "F")
                    {
                        if (promocion.menores.Count >= promocion.cantidad)
                        {
                            promocion.valorDescuento = (subtotalFactura * promocion.descuento / 100);
                            if (!PromocionFactura.existeMejorPromocion(promocion.menores, promocion.valorDescuento, promociones)) promocion.aplicar = true;
                        }
                    }
                    else
                    {
                        if (promocion.aplicaComboProductos())
                        {
                            promocion.unificarProductosCombo();
                            promocion.valorDescuento = promocion.getValorDescuentoCombo(grw_productos);
                            if (!PromocionFactura.existeMejorPromocion(promocion.menores, promocion.valorDescuento, promociones)) promocion.aplicar = true;
                        }
                    }
                }
            }
        }

        private bool aplicaComboProductos()
        {
            var menor = this.combo[0].Count;
            if (menor == 0) return false;
            for (int i = 1; i < this.cantidad; i++)
            {
                int cantidad = this.combo[i].Count;
                if (cantidad == 0) return false;
                if (cantidad < menor)menor = cantidad;
            }
            for (int i = 0; i < this.cantidad; i++) this.combo[i].RemoveRange(menor,this.combo[i].Count - menor);
            return true;
        }

        private void unificarProductosCombo()
        {
            this.menores = new List<valoresMenores>();
            for (int i = 0; i < this.cantidad; i++)
            {
                foreach (valoresMenores valor in this.combo[i])
                {
                    valoresMenores item = this.menores.Find(elemento => elemento.idProducto == valor.idProducto && elemento.posicion == valor.posicion);
                    if (item == null)
                    {
                        this.menores.Add(valor);
                    }
                    else
                    {
                        item.cantidad += 1;
                    }
                }
            }
        }


        private static bool existeMejorPromocion(List<valoresMenores> productos, Decimal valorDescuento, List<PromocionFactura> promociones)
        {
            foreach (PromocionFactura promocion in promociones)
            {
                if ((promocion.tipo == "P" && promocion.agrupacion == 1) || (promocion.tipo == "C"))
                {
                    if (promocion.aplicar)
                    {
                        if (PromocionFactura.existeRepetido(productos, promocion.menores))
                        {
                            if (valorDescuento > promocion.valorDescuento) promocion.aplicar = false;
                            else return true;
                        }
                    }
                }
                else
                {
                    foreach (PromocionGrupo grupo in promocion.grupo)
                    {
                        if (grupo.aplicar)
                        {
                            if (PromocionFactura.existeRepetido(productos, grupo.menores))
                            {
                                if (valorDescuento > grupo.valorDescuento) promocion.aplicar = false;
                                else return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private static bool existeRepetido(List<valoresMenores> lista1, List<valoresMenores> lista2)
        {
            foreach (valoresMenores valor1 in lista1)
            {
                foreach (valoresMenores valor2 in lista2)if (valor1.idProducto == valor2.idProducto) return true;
            }
            return false;
        }

        private decimal getValorDescuentoCombo(System.Windows.Forms.DataGridView grw_productos)
        {
            decimal valorDesc = 0;
            decimal cien = 100;
            foreach(valoresMenores valor in this.menores)
            {
                int fila = valor.posicion;
                decimal pvp = Decimal.Parse(General.obtenerValorCelda(grw_productos, fila, "precioU"));
                decimal cantidad = Decimal.Parse(General.obtenerValorCelda(grw_productos, fila, "cantidad"));
                decimal subtotal = pvp * cantidad;
                valorDesc = valorDesc + (subtotal * (this.descuento / cien));
            }
            return valorDesc;
        }

        private decimal getValorDescuento(int cAplican,System.Windows.Forms.DataGridView grw_productos, List<valoresMenores> menores) 
        {

            int x = 0;
            decimal valorDescuento = 0;
            while (cAplican > 0)
            {
                //decimal descuento = 0;
                int factor = 1;
                if (menores[x].cantidad > 1)
                {
                    factor = (cAplican > menores[x].cantidad) ? menores[x].cantidad : cAplican;
                }

                decimal pDescuento = General.truncar((this.descuento * factor) / (decimal)menores[x].cantidad, 2);
                int fila = menores[x].posicion;

                decimal pvp = Decimal.Parse(General.obtenerValorCelda(grw_productos, fila, "precioU"));
                decimal cantidad = Decimal.Parse(General.obtenerValorCelda(grw_productos, fila, "cantidad"));
                decimal subtotal = pvp * cantidad;
                valorDescuento += subtotal * (pDescuento / 100);

                cAplican -= menores[x].cantidad;
                x++;
            }
            return valorDescuento;
        }

        public string obtenerCombosIngresados()
        {
            string texto = "";    
            foreach (valoresMenores valor in this.menores) texto += "," + valor.posicion.ToString();
            return (texto == "") ? texto : texto.Substring(1);
        }

        public int obtenerNumeroCombo(int idProducto, List<int> numerosProducto)
        {
            int numeroCombo = numerosProducto[0];
            int ultimaCantidad = this.combo[numeroCombo].Count(elemento => elemento.idProducto == idProducto);
            foreach (int numero in numerosProducto)
            {
                int cantidad = this.combo[numero].Count(elemento => elemento.idProducto == idProducto);
                if (cantidad < ultimaCantidad)
                {
                    numeroCombo = numero;
                    ultimaCantidad = cantidad;
                }

            }
            return numeroCombo;
        }
    }


    class PromocionGrupo
    {
        private int _idCategoria;
        private string _nombre;
        private decimal _valorDescuento;
        private bool _aplicar;
        private List<valoresMenores> _menores;

        public PromocionGrupo() { 
            _menores = new List<valoresMenores>();
            _aplicar = false;
        }

        public int idCategoria
        {
            get { return _idCategoria; }
            set { _idCategoria = value; }
        }

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public decimal valorDescuento
        {
            get { return _valorDescuento; }
            set { _valorDescuento = value; }
        }

        public bool aplicar
        {
            get { return _aplicar; }
            set { _aplicar = value; }
        }

        public List<valoresMenores> menores
        {
            get { return _menores; }
            set { _menores = value; }
        }

    }

    class valoresMenores
    {
        private decimal _valor;
        private int _posicion;
        private int _numeroCombo;
        private int _cantidad;
        private int _idProducto;

        public decimal valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

        public int idProducto
        {
            get { return _idProducto; }
            set { _idProducto = value; }
        }

        public int numeroCombo
        {
            get { return _numeroCombo; }
            set { _numeroCombo = value; }
        }

        public int posicion
        {
            get { return _posicion; }
            set { _posicion = value; }
        }

        public int cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }
    }
}
