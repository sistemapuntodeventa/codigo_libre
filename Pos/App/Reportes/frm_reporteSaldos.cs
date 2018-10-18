using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Pos.Clases;
using Pos.Coneccion;

namespace Pos.App.Reportes
{
    public partial class frm_reporteSaldos : Form
    {
        private string empresa;

        public frm_reporteSaldos()
        {
            InitializeComponent();
            this.empresa = EmpresaTR.obtenerNombreEmpresa();
            this.Text += " " + empresa;
        }

        private void frm_reporteSaldos_Load(object sender, EventArgs e)
        {
            this.llenarComboCategorias();
            this.cargarReporte();
        }

        private void llenarComboCategorias()
        {
            List<ComboboxItem> lista = CategoriaTR.obtenerCategorias();
            ComboboxItem item_0 = new ComboboxItem();
            item_0.Text = "";
            item_0.Value = "";
            lista.Insert(0, item_0);

            this.cmb_categoria.DataSource = lista;
            this.cmb_categoria.ValueMember = "Value";
            this.cmb_categoria.DisplayMember = "Text";
        }

        protected void cargarReporte(bool inicial = false)
        {
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            ReportParameter[] param = new ReportParameter[1];
            param[0] = new ReportParameter("nombreEmpresa",this.empresa);
            this.reportViewer1.LocalReport.SetParameters(param);
            this.reporteProducto_SaldosTableAdapter.Connection.ConnectionString = Coneccion.Conexion.lineaConexion;
            int categoria = (this.cmb_categoria.SelectedIndex <= 0) ? -1 : Convert.ToInt32(this.cmb_categoria.SelectedValue);
            this.reporteProducto_SaldosTableAdapter.Fill(this.pos_contificoDataSet2.reporteProducto_Saldos, String.IsNullOrEmpty(this.txt_filtro.Text)?null:this.txt_filtro.Text,categoria);
            if (!inicial) this.reportViewer1.RefreshReport();
            else
            {
                this.reportViewer1.BeginInvoke(
                    new Action(() =>
                    {
                        this.reportViewer1.RefreshReport();
                    }));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.cargarReporte();
        }

    }
}
