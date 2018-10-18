using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Threading;
using Pos.Coneccion;

namespace Pos.App.Reportes
{


    public partial class frm_reporteProducto : Form
    {
        private string empresa;
        private int idCaja;

        public frm_reporteProducto()
        {
            InitializeComponent();
            empresa = EmpresaTR.obtenerNombreEmpresa();
            this.Text += " " + empresa;
        }

        private void frm_reporteProducto_Load(object sender, EventArgs e)
        {
            this.idCaja = -1;
            this.dtp_desde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            /*this.backgroundThread = new Thread(
                   new ThreadStart(() =>
                   {
                       this.cargarReporte(2, true);

                   }
                ));
            backgroundThread.Start();*/


            this.cmb_grupo.SelectedIndex = 1;
            //this.cmb_grupo.SelectedValueChanged += refrescarReporte;
            this.dtp_desde.ValueChanged += cambiarFecha;
            this.dtp_hasta.ValueChanged += cambiarFecha;
        }


        private void cambiarFecha(object sender, EventArgs e)
        {
            this.idCaja = -1;
            this.txt_caja.Clear();
        }

          protected void cargarReporte(int grupo, bool inicial = false)
        {
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            ReportParameter[] param = new ReportParameter[4];
            param[0] = new ReportParameter("grupo", grupo.ToString());
            param[1] = new ReportParameter("nombreEmpresa", this.empresa);
            param[2] = new ReportParameter("desde", this.dtp_desde.Value.ToShortDateString());
            param[3] = new ReportParameter("hasta", this.dtp_hasta.Value.ToShortDateString());
            this.reportViewer1.LocalReport.SetParameters(param);
            this.reporteProducto_ConsultarTableAdapter.Connection.ConnectionString = Coneccion.Conexion.lineaConexion;
       
            this.reporteProducto_ConsultarTableAdapter.Fill(this.pos_contificoDataSet.reporteProducto_Consultar, this.dtp_desde.Value, this.dtp_hasta.Value,this.idCaja);
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
            this.cargarReporte((this.cmb_grupo.SelectedIndex + 1));
        }

        private void frm_reporteProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
           // this.backgroundThread.Abort();
        }

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

        private void button2_Click(object sender, EventArgs e)
        {
            frm_cajaListado listado = new frm_cajaListado(this.dtp_desde.Value,this.dtp_hasta.Value);
            listado.ShowDialog(this);
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void cmb_grupo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
