using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pos.Coneccion;

namespace Pos.App
{
    public partial class frm_consultarSerie : Form
    {
        private KeyValuePair<Int32, String>? serie;
        private int idProducto;
        private List<string> excluir;
        private bool primeraCarga = true;
        private List<KeyValuePair<Int32, String>> series = null;
        private int? idFactura;
        private bool serieVacia;

        public KeyValuePair<Int32, String>? getSerie()
        {
            return this.serie;
        }

        public frm_consultarSerie()
        {
            InitializeComponent();
        }

        public frm_consultarSerie(int idProducto, List<string> excluir, int? idFactura, bool serieVacia)
        {
            InitializeComponent();
            this.idProducto = idProducto;
            this.excluir = excluir;
            this.idFactura = idFactura;
            this.serieVacia = serieVacia;
        }

        private void frm_consultarSerie_Load(object sender, EventArgs e)
        {
            this.llenarDatos();
        }

        private void llenarDatos()
        {
            this.lsb_datos.Items.Clear();
            this.series = ProductoTR.consultarSeries(this.idProducto, this.seriesGetString(), this.idFactura,this.txt_filtro.Text);
            if (this.series != null)
            {
                foreach (KeyValuePair<Int32, String> valor in this.series)
                {
                    this.lsb_datos.Items.Add(valor.Value);
                }
            }
        }
        
        private string seriesGetString()
        {
            if (this.excluir.Count < 1) return "";
            string valor = "";
            foreach (string serie in this.excluir)
            {
                valor += "'" + serie + "',";
            }
            return valor.Substring(0, valor.Length - 1);
        }

        private void lsb_datos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lsb_datos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.retornarValor();
        }

        private void lsb_datos_KeyUp(object sender, KeyEventArgs e)
        {
            if (!primeraCarga)
            {
                if (e.KeyData == Keys.Enter)
                {
                    this.retornarValor();
                }
            }
            else primeraCarga = false;
        }

        private void retornarValor()
        {
            if (this.lsb_datos.SelectedIndex > -1)
            {
                this.serie = this.series[this.lsb_datos.SelectedIndex];
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void frm_consultarSerie_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.serie == null && !this.serieVacia) this.DialogResult = DialogResult.OK;
        }

        private void txt_filtro_KeyUp(object sender, KeyEventArgs e)
        {
            this.llenarDatos();
        }

    }
}
