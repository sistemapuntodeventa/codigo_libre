using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pos.Coneccion;
using Pos.Clases;

namespace Pos.App
{
    public partial class frm_cajaListado : Form
    {
        private int idConfPos;
        DateTime? desde = null;
        DateTime? hasta = null;

        public frm_cajaListado()
        {
            InitializeComponent();
        }

        public frm_cajaListado(DateTime desde, DateTime hasta)
        {
            InitializeComponent();
            this.desde = desde;
            this.hasta = hasta;
        }

        public frm_cajaListado(int idConfPos)
        {
            InitializeComponent();
            this.idConfPos = idConfPos;
        }

        private void frm_cajaListado_Load(object sender, EventArgs e)
        {
            this.dtp_desde.Value = (this.desde==null)?DateTime.Now:(DateTime)this.desde;
            this.dtp_hasta.Value = (this.hasta == null) ? DateTime.Now : (DateTime)this.hasta;
            this.llenarGrid(dtp_desde.Value, dtp_hasta.Value);
            this.dtp_desde.ValueChanged += dtp_desde_ValueChanged;
            this.dtp_hasta.ValueChanged += dtp_hasta_ValueChanged;
        }

        protected void llenarGrid(DateTime desde, DateTime hasta)
        {

            this.grw_cajas.DataBindings.Clear();
            grw_cajas.Columns.Clear();
            string mensaje = "";
            CajaTR tran = new CajaTR();
            DataTable datos = tran.consultarCierreCajas(ref mensaje, desde, hasta,this.idConfPos);
            if (datos != null)
            {
                this.grw_cajas.DataSource = datos;
                int ancho = this.grw_cajas.Width;
                this.grw_cajas.Columns["id"].Visible = false;
                this.grw_cajas.Columns["Vendedor"].Width = Convert.ToInt16(ancho * 0.20);
                this.grw_cajas.Columns["Fecha Apertura"].Width = Convert.ToInt16(ancho * 0.25);
                this.grw_cajas.Columns["Fecha Cierre"].Width = Convert.ToInt16(ancho * 0.25);
                this.grw_cajas.Columns["Monto Inicial"].Width = Convert.ToInt16(ancho * 0.10);
                this.grw_cajas.Columns["Cobrado"].Width = Convert.ToInt16(ancho * 0.10);
                this.grw_cajas.Columns["Monto Final"].Width = Convert.ToInt16(ancho * 0.10);
            }
            else Mensaje.error(mensaje);

        }

        private void dtp_desde_ValueChanged(object sender, EventArgs e)
        {
            this.llenarGrid(dtp_desde.Value, dtp_hasta.Value);
        }

        private void dtp_hasta_ValueChanged(object sender, EventArgs e)
        {
            this.llenarGrid(dtp_desde.Value, dtp_hasta.Value);
        }

        private void grw_facturas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int idCaja = Convert.ToInt32(this.grw_cajas.Rows[e.RowIndex].Cells["id"].Value);
                if (this.Owner.GetType() == typeof(frm_abrir_cerrar))
                {
                    frm_abrir_cerrar formularioCaja = (frm_abrir_cerrar)this.Owner;
                    formularioCaja.setIdCaja(idCaja);
                }
                else {

                    DateTime fechaInicio = Convert.ToDateTime(this.grw_cajas.Rows[e.RowIndex].Cells["Fecha Apertura"].Value, new System.Globalization.CultureInfo("en-AU", false));
                    DateTime fechaFin = Convert.ToDateTime(this.grw_cajas.Rows[e.RowIndex].Cells["Fecha Cierre"].Value, new System.Globalization.CultureInfo("en-AU", false));
                    //reporte.setCaja(idCaja, idCaja.ToString() + ", " + this.grw_cajas.Rows[e.RowIndex].Cells["vendedor"].Value.ToString(),fechaInicio,fechaFin);

                    if (this.Owner.GetType() == typeof(Pos.App.Reportes.frm_reporteProducto))
                        ((Pos.App.Reportes.frm_reporteProducto)this.Owner).setCaja(idCaja, idCaja.ToString() + ", " + this.grw_cajas.Rows[e.RowIndex].Cells["vendedor"].Value.ToString(), fechaInicio, fechaFin);
                    else
                        ((Pos.App.Reportes.frm_reporteVentas)this.Owner).setCaja(idCaja, idCaja.ToString() + ", " + this.grw_cajas.Rows[e.RowIndex].Cells["vendedor"].Value.ToString(), fechaInicio, fechaFin);
                }
                this.Close();
            }
        }
    }
}
