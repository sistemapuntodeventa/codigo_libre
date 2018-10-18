using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pos.Clases;
using Pos.Coneccion;

namespace Pos.App
{
    public partial class frm_abono : Form
    {
        public List<FormaPago> listaFormaPago = null;
        private FormaPago formaPago = null;
        private int idCaja;
        private decimal saldo;

        public frm_abono(int idCaja,decimal saldo)
        {
            InitializeComponent();
            this.idCaja = idCaja;
            this.saldo = saldo;
        }

        public frm_abono(FormaPago forma)
        {
            InitializeComponent();
            formaPago = forma;
        }



        private void frm_abono_Load(object sender, EventArgs e)
        {

            this.txt_efectivo.Focus();
            this.llenarComboTarjetasCredito();

            if (this.formaPago != null)
            {
                foreach (Control c in this.Controls)
                {
                    c.Enabled = (c is Button || c is Label);
                }

                switch (this.formaPago.Forma_pago)
                {
                    case "EF":  this.txt_efectivo.Text = this.formaPago.Monto_efectivo.ToString();
                                this.tco_formaPago.SelectedIndex = 0;
                                break;
                    case "CH":  this.txt_montoc.Text = this.formaPago.Monto_cheque.ToString();
                                this.txt_banco.Text = this.formaPago.Banco;
                                this.txt_numeroc.Text = this.formaPago.Numero_cheque;
                                this.tco_formaPago.SelectedIndex = 1;
                                break;
                    case "TC":  this.txt_numerot1.Text = this.formaPago.Numero_tarjeta;
                                this.txt_montot1.Text = this.formaPago.Monto_tarjeta.ToString();
                                this.cmb_pin1.SelectedValue = this.formaPago.Tipo_ping;
                                this.cmb_tipo1.SelectedValue = this.formaPago.Tipo_tarjeta;
                                this.tco_formaPago.SelectedIndex = 0;
                                break;
                    case "RF":  this.txt_retencion.Text = this.formaPago.Monto_retencion.ToString();
                                this.txt_numeroRetencion.Text = this.formaPago.Numero_retencion.ToString();
                                this.tco_formaPago.SelectedIndex = 2;
                                break;
                    case "NC":  this.txt_montoNota.Text = this.formaPago.Monto_nota.ToString();
                                this.txt_numeroNota.Text = this.formaPago.Numero_Nota.ToString();
                                this.tco_formaPago.SelectedIndex = 3;
                                break;
                }
            }
        }

        private void tco_formaPago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private bool validarIngreso()
        {
            if (!General.vacioOCero(txt_montot1.Text) && (String.IsNullOrEmpty(txt_numerot1.Text) || this.cmb_pin1.SelectedIndex == 0 || this.cmb_tipo1.SelectedIndex == 0))
            {
                Mensaje.advertencia("Ha ingresado un valor para la tarjeta de crédito uno.\nFavor llene todos los datos.");
                this.txt_montot1.Select();
                return false;
            }

            if (!General.vacioOCero(txt_montoc.Text) && (String.IsNullOrEmpty(txt_numeroc.Text) || String.IsNullOrEmpty(txt_banco.Text)))
            {
                Mensaje.advertencia("Ha ingresado un valor de cheque. Favor llene todos los datos.");
                this.txt_montoc.Select();
                return false;
            }

            if (!General.vacioOCero(txt_retencion.Text) && String.IsNullOrEmpty(txt_numeroRetencion.Text))
            {
                Mensaje.advertencia("Ha ingresado un valor de retención. Favor llene todos los datos.");
                this.txt_retencion.Select();
                return false;
            }

            decimal totalPagar = this.saldo;
            decimal totalTarjeta = General.convertirDecimal(this.txt_montot1.Text);
            decimal totalCheque = General.convertirDecimal(this.txt_montoc.Text);
            decimal totalCredito = General.convertirDecimal(this.txt_montoNota.Text);
            decimal totalRetencion = General.convertirDecimal(this.txt_retencion.Text);

            if (totalTarjeta > totalPagar)
            {
                Mensaje.advertencia("El pago con tarjeta de crédito debe ser igual o menor al total a cobrar.");
                return false;
            }
            if (totalCheque > totalPagar)
            {
                Mensaje.advertencia("El pago con cheque debe ser igual o menor al total a cobrar.");
                return false;
            }

            if (totalRetencion > totalPagar)
            {
                Mensaje.advertencia("El pago con retención debe ser igual o menor al total a cobrar.");
                return false;
            }

            if (totalCredito > totalPagar)
            {
                Mensaje.advertencia("El pago con nota de crédito debe ser igual o menor al total a cobrar.");
                return false;
            }

            if (totalTarjeta + totalCheque + totalRetencion + totalCredito > totalPagar)
            {
                Mensaje.advertencia("Sólo se permite vueltos para pagos en efectivo.");
                return false;
            }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected void obtenerFormasDePago()
        {
            this.listaFormaPago = new List<FormaPago>();
            if (!General.vacioOCero(txt_efectivo.Text))
            {
                FormaPago pagoEfectivo = new FormaPago();
                //pagoEfectivo.Id_cabecera = factura.Idfactura_cabecera;
                pagoEfectivo.Forma_pago = "EF";
                pagoEfectivo.Monto_efectivo = decimal.Parse(this.txt_efectivo.Text);
                pagoEfectivo.Id_Caja = this.idCaja;
                listaFormaPago.Add(pagoEfectivo);
            }

            if (!General.vacioOCero(txt_montoc.Text))
            {
                FormaPago pagoCheque = new FormaPago();
                //pagoCheque.Id_cabecera = factura.Idfactura_cabecera;
                pagoCheque.Forma_pago = "CH";
                pagoCheque.Monto_cheque = decimal.Parse(this.txt_montoc.Text);
                pagoCheque.Numero_cheque = this.txt_numeroc.Text;
                pagoCheque.Banco = this.txt_banco.Text;
                pagoCheque.Id_Caja = this.idCaja;
                listaFormaPago.Add(pagoCheque);
            }

            if (!General.vacioOCero(this.txt_montot1.Text))
            {
                FormaPago pagoTarjeta = new FormaPago();
                //pagoTarjeta.Id_cabecera = factura.Idfactura_cabecera;
                pagoTarjeta.Forma_pago = "TC";
                pagoTarjeta.Monto_tarjeta = decimal.Parse(this.txt_montot1.Text);
                pagoTarjeta.Numero_tarjeta = this.txt_numerot1.Text;
                pagoTarjeta.Tipo_tarjeta = this.cmb_tipo1.SelectedValue.ToString();
                pagoTarjeta.Tipo_ping = this.cmb_pin1.SelectedValue.ToString();
                pagoTarjeta.Id_Caja = this.idCaja;
                listaFormaPago.Add(pagoTarjeta);
            }

            if (!General.vacioOCero(this.txt_retencion.Text))
            {
                FormaPago pagoRetencion = new FormaPago();
                //pagoRetencion.Id_cabecera = factura.Idfactura_cabecera;
                pagoRetencion.Forma_pago = "RF";
                pagoRetencion.Monto_retencion = decimal.Parse(this.txt_retencion.Text);
                pagoRetencion.Numero_retencion = int.Parse(this.txt_numeroRetencion.Text);
                pagoRetencion.Id_Caja = this.idCaja;
                listaFormaPago.Add(pagoRetencion);
            }

            if (!General.vacioOCero(this.txt_montoNota.Text))
            {
                FormaPago pagoNota = new FormaPago();
                //pagoNota.Id_cabecera = factura.Idfactura_cabecera;
                pagoNota.Forma_pago = "NC";
                pagoNota.Monto_nota = decimal.Parse(this.txt_montoNota.Text);
                pagoNota.Numero_Nota = int.Parse(this.txt_numeroNota.Text);
                pagoNota.Id_Caja = this.idCaja;
                listaFormaPago.Add(pagoNota);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.validarIngreso()) return;
            this.DialogResult = DialogResult.OK;
            this.obtenerFormasDePago();
            this.Close();
        }

        public void llenarComboTarjetasCredito()
        {

            List<ComboboxItem> lista = TarjetaCreditoTR.obtenerTarjetas();
            ComboboxItem item_0 = new ComboboxItem();
            item_0.Text = "";
            item_0.Value = "";
            lista.Insert(0, item_0);

            this.cmb_tipo1.DataSource = lista;
            this.cmb_tipo1.ValueMember = "Value";
            this.cmb_tipo1.DisplayMember = "Text";

            List<ComboboxItem> listaPin = new List<ComboboxItem>();
            ComboboxItem pin_0 = new ComboboxItem();
            pin_0.Text = "";
            pin_0.Value = "";
            listaPin.Add(pin_0);
            ComboboxItem pin_1 = new ComboboxItem();
            pin_1.Text = "DataFast";
            pin_1.Value = "D";
            listaPin.Add(pin_1);
            ComboboxItem pin_2 = new ComboboxItem();
            pin_2.Text = "MediaNet";
            pin_2.Value = "M";
            listaPin.Add(pin_2);
            ComboboxItem pin_3 = new ComboboxItem();
            pin_3.Text = "Red de Apoyo";
            pin_3.Value = "R";
            listaPin.Add(pin_3);

            this.cmb_pin1.DataSource = listaPin;
            this.cmb_pin1.ValueMember = "Value";
            this.cmb_pin1.DisplayMember = "Text";

        }
    }
}
