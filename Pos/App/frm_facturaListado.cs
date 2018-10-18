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
    public partial class frm_facturaListado : Form
    {
        private List<object[]> adicionales;
        public int idFactura { get; set; }
        public bool anular { get; set; }
        public frm_facturaListado()
        {
            InitializeComponent();
        }

        private void frm_facturaListado_Load(object sender, EventArgs e)
        {
            string mensaje ="";
            string estado = ParametroTR.ConsultarStringXNombre(ref mensaje, "facturaEstado");
            if (String.IsNullOrEmpty(estado)) estado = "";
            
            this.cmb_estado.SelectedIndexChanged -= dtp_desde_ValueChanged;
            this.dtp_desde.ValueChanged -= dtp_desde_ValueChanged;
            this.dtp_hasta.ValueChanged -= dtp_desde_ValueChanged;

            List<ComboboxItem> estados = new List<ComboboxItem>();
            estados.Add(new ComboboxItem("TODOS",""));
            estados.Add(new ComboboxItem("PENDIENTE", "P"));
            estados.Add(new ComboboxItem("COBRADA", "C"));
            estados.Add(new ComboboxItem("ANULADA", "A"));
            this.cmb_estado.DataSource = estados;
            this.cmb_estado.ValueMember = "Value";
            this.cmb_estado.DisplayMember = "Text";

            this.adicionales = AdicionalTR.nombresFactura();

            this.dtp_desde.Value = new DateTime(DateTime.Now.Year,DateTime.Now.Month, 1);
            //this.dtp_desde.Value = DateTime.Now;
            this.dtp_hasta.Value = DateTime.Now;
            this.cmb_estado.SelectedValue = estado;

            
            this.llenarGrid(dtp_desde.Value,dtp_hasta.Value,estado,null);
            this.dtp_desde.ValueChanged += dtp_desde_ValueChanged;
            this.dtp_hasta.ValueChanged += dtp_desde_ValueChanged;
            this.cmb_estado.SelectedIndexChanged += dtp_desde_ValueChanged;
        }

        protected void llenarGrid(DateTime desde, DateTime hasta, string estado, string filtro)
        {
            this.grw_facturas.DataBindings.Clear();
            grw_facturas.Columns.Clear();
            string mensaje = "";
            FacturaCabeceraTR tran = new FacturaCabeceraTR();
            DataTable datos = tran.consultarFacturas(ref mensaje, desde, hasta, estado, filtro);
            if (datos != null)
            {
                this.grw_facturas.DataSource = datos;
                int ancho = this.grw_facturas.Width;

                this.grw_facturas.Columns["adicional1"].Visible = false;
                this.grw_facturas.Columns["adicional2"].Visible = false;

                if (this.adicionales != null)
                {
                    int valor = 0;
                    foreach (Object[] adicional in this.adicionales)
                    {
                        int id = Convert.ToInt32(adicional[0]);
                        string nombre = adicional[1].ToString();
                        if (id == 1)
                        {
                            this.grw_facturas.Columns["adicional1"].Width = Convert.ToInt16(ancho * 0.10);
                            valor += Convert.ToInt16(ancho * 0.10);
                            this.grw_facturas.Columns["adicional1"].HeaderText = nombre;
                            this.grw_facturas.Columns["adicional1"].Visible = true;
                        }
                        else
                        {
                            this.grw_facturas.Columns["adicional2"].Width = Convert.ToInt16(ancho * 0.10);
                            valor += Convert.ToInt16(ancho * 0.10);
                            this.grw_facturas.Columns["adicional2"].HeaderText = nombre;
                            this.grw_facturas.Columns["adicional2"].Visible = true;
                        }
                    }

                    ancho -= valor;
                }
                this.grw_facturas.Columns["id"].Visible = false;
                this.grw_facturas.Columns["Fecha"].Width = Convert.ToInt16(ancho * 0.20);
                this.grw_facturas.Columns["Documento"].Width = Convert.ToInt16(ancho * 0.20);
                this.grw_facturas.Columns["Identificación"].Width = Convert.ToInt16(ancho * 0.10);
                this.grw_facturas.Columns["Cliente"].Width = Convert.ToInt16(ancho * 0.20);
                //this.grw_facturas.Columns["Vendedor"].Width = Convert.ToInt16(ancho * 0.15);
                this.grw_facturas.Columns["Vendedor"].Visible = false;
                this.grw_facturas.Columns["Monto"].Width = Convert.ToInt16(ancho * 0.10);
                this.grw_facturas.Columns["Estado"].Width = Convert.ToInt16(ancho * 0.20);
                this.grw_facturas.Columns["anular"].Visible = false;
            }
            else Mensaje.error(mensaje);

        }

        private void dtp_desde_ValueChanged(object sender, EventArgs e)
        {
            this.llenarGrid(dtp_desde.Value, dtp_hasta.Value,this.cmb_estado.SelectedValue.ToString(),this.txt_filtro.Text);
        }


        private void grw_facturas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                this.idFactura = Convert.ToInt32(this.grw_facturas.Rows[e.RowIndex].Cells["id"].Value);
                this.anular = Convert.ToBoolean(this.grw_facturas.Rows[e.RowIndex].Cells["anular"].Value);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void frm_facturaListado_FormClosing(object sender, FormClosingEventArgs e)
        {
            ParametroTR.actualizarParametroString("facturaEstado", this.cmb_estado.SelectedValue.ToString());
        }

        private void txt_secuencia_KeyUp(object sender, KeyEventArgs e)
        {
            this.llenarGrid(dtp_desde.Value, dtp_hasta.Value, this.cmb_estado.SelectedValue.ToString(), this.txt_filtro.Text);
        }


    }
}
