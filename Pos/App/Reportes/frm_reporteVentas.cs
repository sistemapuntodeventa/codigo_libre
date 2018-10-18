using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Pos.Coneccion;
using System.Threading;
using Pos.Clases;

namespace Pos.App.Reportes
{
    public partial class frm_reporteVentas : Form
    {

        private string empresa;
        private Thread backgroundThread;
        private List<String> datos;
        private bool error = false;
        private bool pagoParcial = false;
        private int idCaja;

        public frm_reporteVentas()
        {
            try
            {
                InitializeComponent();
                empresa = EmpresaTR.obtenerNombreEmpresa();
                datos = EmpresaTR.obtenerDatosReporte();
                pagoParcial = ParametroTR.ConsultarBool("pagoParcial");
                this.Text += " " + empresa;
            }
            catch (Exception e)
            {
                Mensaje.error(e.Message);
                this.error = true;
            }
        }

        private void frm_reporteVentas_Load(object sender, EventArgs e)
        {
            if (this.error) return;
            this.idCaja = -1;
            this.dtp_desde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            this.cmb_grupo.SelectedIndex = 0;

            this.dtp_desde.ValueChanged += cambiarFecha;
            this.dtp_hasta.ValueChanged += cambiarFecha;
        }


        protected void cargarReporte(int grupo, bool inicial = false)
        {
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            ReportParameter[] param = new ReportParameter[9];
            param[0] = new ReportParameter("grupo", grupo.ToString());
            param[1] = new ReportParameter("adicional1",(String.IsNullOrEmpty(datos[0])?null:datos[0]));
            param[2] = new ReportParameter("adicional2",(String.IsNullOrEmpty(datos[1]) ? null : datos[1]));
            param[3] = new ReportParameter("servicio", (!String.IsNullOrEmpty(datos[2])).ToString());
            param[4] = new ReportParameter("propina", (!String.IsNullOrEmpty(datos[3])).ToString());
            param[5] = new ReportParameter("nombreEmpresa", this.empresa);
            param[6] = new ReportParameter("desde", this.dtp_desde.Value.ToShortDateString());
            param[7] = new ReportParameter("hasta", this.dtp_hasta.Value.ToShortDateString());
            param[8] = new ReportParameter("pagoparcial", this.pagoParcial.ToString());
            this.reportViewer1.LocalReport.SetParameters(param);
            
            this.reporteVentas_ConsultarTableAdapter.Connection.ConnectionString = Coneccion.Conexion.lineaConexion;
            this.reporteVentas_ConsultarTableAdapter.Fill(this.pos_contificoDataSet1.reporteVentas_Consultar,grupo, this.dtp_desde.Value, this.dtp_hasta.Value,this.idCaja);
            if (!inicial) this.reportViewer1.RefreshReport();
            else {
                this.reportViewer1.BeginInvoke(
                    new Action(() =>
                    {
                        this.reportViewer1.RefreshReport();
                    }));
            }
        }

        private void refrescarReporte(object sender, EventArgs e)
        {
            if (this.backgroundThread != null) this.backgroundThread.Abort();
            this.cargarReporte(this.cmb_grupo.SelectedIndex + 1);
        }

        private void frm_reporteVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (this.backgroundThread != null) this.backgroundThread.Abort();
        }
/*
        private void reportViewer1_PrintingBegin(object sender, ReportPrintEventArgs e)
        {
            this.reportViewer1.PrinterSettings.PrinterName = e.PrinterSettings.PrinterName;
            this.reportViewer1.PrinterSettings.FromPage = e.PrinterSettings.FromPage;
            this.reportViewer1.PrinterSettings.ToPage = e.PrinterSettings.ToPage;
        }
        */
        private void button1_Click(object sender, EventArgs e)
        {
            this.cargarReporte(this.cmb_grupo.SelectedIndex + 1);
        }

        public void setCaja(int idCaja, string texto, DateTime fechaInicio, DateTime fechaFin)
        {
            this.dtp_desde.ValueChanged -= cambiarFecha;
            this.dtp_hasta.ValueChanged -= cambiarFecha;

            this.idCaja = idCaja;
            this.txt_caja.Text = texto;
            this.dtp_desde.Value = fechaInicio;
            this.dtp_hasta.Value = fechaFin;

            this.dtp_desde.ValueChanged += cambiarFecha;
            this.dtp_hasta.ValueChanged += cambiarFecha;
        }

        private void cambiarFecha(object sender, EventArgs e)
        {
            this.idCaja = -1;
            this.txt_caja.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_cajaListado listado = new frm_cajaListado(this.dtp_desde.Value, this.dtp_hasta.Value);
            listado.ShowDialog(this);
        }
    }
}
