using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pos.Clases
{

    public class adicionalFactura
    {
        public int idAdicional;
        public int tipo;
        public string etiqueta;
        public string valor;
    }

    public class FacturaCabecera
    {

        int idCajero;
        int idCliente;
        int idVendedor;
        int idConfPos;

        int id, id_tipoDocumento, empresa_id, establecimiento_id, subio;
        int? id_usuarioAnular;
        string numero_documento, referencia, descripcion, estado;       
        DateTime fecha_vencimiento, fecha_creacion;        
        decimal descuento, servicio, tarifa_0, tarifa_12, total_ice, total_iva, total;
        int numero_actual;
        bool imprimo;
        int idCaja;
        string autorizacion;
        decimal descuento_cliente;
        decimal descuento_factura;
        string tipo;
        decimal vuelto;
        decimal propina;
        bool pagoParcial;
        List<adicionalFactura> adicionales;

        public FacturaCabecera()
        {
            this.Numero_documento = "";
        }


        public FacturaCabecera(DateTime fechaVenc)
        {
            this.id = 0;
            this.id_tipoDocumento = 0;
            this.numero_documento = "";
            this.referencia = "";
            this.fecha_vencimiento = fechaVenc;
            this.fecha_creacion = DateTime.Now;
            this.descuento = 0;
            this.servicio = 0;
            this.tarifa_0 = 0;
            this.tarifa_12 = 0;
            this.total_ice = 0;
            this.total_iva = 0;
            this.total = 0;
            this.empresa_id = 0;
            this.establecimiento_id = 0;
            this.numero_actual = 0;
            this.imprimo = false;
            this.subio = 0;
            this.estado = "P";
            this.pagoParcial = false;
        }

        public List<adicionalFactura> Adicionales
        {
            get { return adicionales; }
            set { adicionales = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int? IdUsuarioAnular
        {
            get { return id_usuarioAnular; }
            set { id_usuarioAnular = value; }
        }

        public int Id_tipoDocumento
        {
            get { return id_tipoDocumento; }
            set { id_tipoDocumento = value; }
        }

        public string Autorizacion
        {
            get { return autorizacion; }
            set { autorizacion = value; }
        }

        public int IdCaja
        {
            get { return idCaja; }
            set { idCaja = value; }
        }

        public int IdConfPos
        {
            get { return idConfPos; }
            set { idConfPos = value; }
        }

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public string Numero_documento
        {
            get { return numero_documento; }
            set { numero_documento = value; }
        }

        public string Referencia
        {
            get { return referencia; }
            set { referencia = value; }
        }

        public DateTime Fecha_vencimiento
        {
            get { return fecha_vencimiento; }
            set { fecha_vencimiento = value; }
        }

        public decimal Propina
        {
            get { return propina; }
            set { propina = value; }
        }

        public decimal Vuelto
        {
            get { return vuelto; }
            set { vuelto = value; }
        }

        public decimal Servicio
        {
            get { return servicio; }
            set { servicio = value; }
        }

        public decimal Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }

        public decimal DescuentoFactura
        {
            get { return descuento_factura; }
            set { descuento_factura = value; }
        }

        public decimal DescuentoCliente
        {
            get { return descuento_cliente; }
            set { descuento_cliente = value; }
        }

        public decimal Tarifa_0
        {
            get { return tarifa_0; }
            set { tarifa_0 = value; }
        }

        public decimal Tarifa_12
        {
            get { return tarifa_12; }
            set { tarifa_12 = value; }
        }

        public decimal Total_ice
        {
            get { return total_ice; }
            set { total_ice = value; }
        }

        public decimal Total_iva
        {
            get { return total_iva; }
            set { total_iva = value; }
        }

        public decimal Total
        {
            get { return total; }
            set { total = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public int Empresa_id
        {
            get { return empresa_id; }
            set { empresa_id = value; }
        }

        public int Establecimiento_id
        {
            get { return establecimiento_id; }
            set { establecimiento_id = value; }
        }

        public int IdVendedor
        {
            get { return idVendedor; }
            set { idVendedor = value; }
        }

        public int IdCajero
        {
            get { return idCajero; }
            set { idCajero = value; }
        }

        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        public int Numero_actual
        {
            get { return numero_actual; }
            set { numero_actual = value; }
        }

        public bool Imprimo
        {
            get { return imprimo; }
            set { imprimo = value; }
        }

        public DateTime Fecha_creacion
        {
            get { return fecha_creacion; }
            set { fecha_creacion = value; }
        }

        public int Subio
        {
            get { return subio; }
            set { subio = value; }
        }

        public bool PagoParcial
        {
            get { return pagoParcial; }
            set { pagoParcial = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }


    }
}
