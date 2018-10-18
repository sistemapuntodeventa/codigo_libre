using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pos.Clases
{
    class Permiso
    {
        private bool _dna;
        private bool _descuento;
        private bool _vueltoCredito;
        private bool _vueltoCheque;
        private bool _notaCredito;
        private bool _seleccionarVendedor;
        private bool _propina;
        private bool _pendientes;
        private bool _anularFactura;

        public bool dna
        {
            get { return _dna; }
            set { _dna = value; }
        }

        public bool anularFactura
        {
            get { return _anularFactura; }
            set { _anularFactura = value; }
        }

        public bool descuento
        {
            get { return _descuento; }
            set { _descuento = value; }
        }

        public bool vueltoCredito
        {
            get { return _vueltoCredito; }
            set { _vueltoCredito = value; }
        }

        public bool vueltoCheque
        {
            get { return _vueltoCheque; }
            set { _vueltoCheque = value; }
        }

        public bool notaCredito
        {
            get { return _notaCredito; }
            set { _notaCredito = value; }
        }

        public bool SeleccionarVendedor
        {
            get { return _seleccionarVendedor; }
            set { _seleccionarVendedor = value; }
        }

        public bool Propina
        {
            get { return _propina; }
            set { _propina = value; }
        }

        public bool Pendientes
        {
            get { return _pendientes; }
            set { _pendientes = value; }
        }
    }
}
