using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestLib;
using Pos.Clases;
using Pos.Coneccion;

namespace Pos.App
{
    public partial class frm_parametro : Form
    {
        string impresoraActual = "";
        string impresoraActual2 = "";

        public frm_parametro()
        {
            InitializeComponent();
        }

        private void frm_parametro_Load(object sender, EventArgs e)
        {
            List<Object> lista = ParametroTR.ConsultarInt("41,42,15,43");
            this.txt_ancho.Text = lista[1].ToString();
            this.txt_alto.Text = lista[2].ToString();
            this.txt_copias.Text = lista[0].ToString();
            this.txt_copias2.Text = lista[3].ToString();
            this.llenarImpresoraPrincipal();
        }

        protected void llenarImpresoraPrincipal()
        {
            string mensaje = "";
            this.impresoraActual = ParametroTR.ConsultarStringXNombre(ref mensaje, "impresora");
            this.impresoraActual2 = ParametroTR.ConsultarStringXNombre(ref mensaje, "impresora2");

            List<ComboboxItem> impresoras = Impresion.impresorasDisponibles(this.impresoraActual);
            this.cmb_impresora.DataSource = impresoras;
            this.cmb_impresora.ValueMember = "Value";
            this.cmb_impresora.DisplayMember = "Text";
            this.cmb_impresora.SelectedValue = this.impresoraActual;

            List<ComboboxItem> impresoras2 = Impresion.impresorasDisponibles(this.impresoraActual2);
            this.cmb_impresora2.DataSource = impresoras2;
            this.cmb_impresora2.ValueMember = "Value";
            this.cmb_impresora2.DisplayMember = "Text";
            this.cmb_impresora2.SelectedValue = this.impresoraActual2;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {   
                if (this.impresoraActual != this.cmb_impresora.SelectedValue.ToString())
                {
                    ParametroTR.actualizarParametroString("impresora", this.cmb_impresora.SelectedValue.ToString());
                    Global.nombreImpresora = this.cmb_impresora.SelectedValue.ToString();
                
                }

                if (this.impresoraActual2 != this.cmb_impresora2.SelectedValue.ToString())
                {
                    ParametroTR.actualizarParametroString("impresora2", this.cmb_impresora2.SelectedValue.ToString());
                }

                ParametroTR.actualizarParametroEntero("facturaCopias", Convert.ToInt32(this.txt_copias.Text));
                ParametroTR.actualizarParametroEntero("facturaCopias2", Convert.ToInt32(this.txt_copias2.Text));
                ParametroTR.actualizarParametroString("anchoHoja", this.txt_ancho.Text);
                ParametroTR.actualizarParametroString("altoHoja", this.txt_alto.Text);
                Mensaje.informacion("Datos actualizados satisfactoriamente");
                this.Close();
            }
            catch (Exception error)
            {
                Mensaje.advertencia(error.Message);
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_ancho_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.permitirDecimales(sender, e);
        }
    }
}
