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
    public partial class frm_buscarGuiaRemision : Form
    {
        public int idGuia { get; set; }

        public frm_buscarGuiaRemision()
        {
            InitializeComponent();
        }

        private void frm_buscarGuiaRemision_Load(object sender, EventArgs e)
        {
            this.llenarGrid(DateTime.Now, DateTime.Now);
        }

        protected void llenarGrid(DateTime desde, DateTime hasta)
        { 
            try
            {
                this.grw_guias.DataBindings.Clear();
                grw_guias.Columns.Clear();
                DataTable datos = GuiaRemisionTR.consultarGuias(desde,hasta);
                if (datos != null)
                {
                    this.grw_guias.DataSource = datos;
                    //this.grw_promociones.Columns[0].Visible = false;
                    /*int ancho = this.grw_promociones.Width - 40;
                    this.grw_promociones.Columns[1].Width = Convert.ToInt16(ancho * 0.20);
                    this.grw_promociones.Columns[2].Width = Convert.ToInt16(ancho * 0.10);
                    this.grw_promociones.Columns[3].Width = Convert.ToInt16(ancho * 0.10);
                    this.grw_promociones.Columns[4].Width = Convert.ToInt16(ancho * 0.10);
                    this.grw_promociones.Columns[5].Width = Convert.ToInt16(ancho * 0.20);
                    this.grw_promociones.Columns[6].Width = Convert.ToInt16(ancho * 0.20);
                    this.grw_promociones.Columns[7].Width = Convert.ToInt16(ancho * 0.10);*/

              
                }
            }
            catch (Exception e)
            {
                Mensaje.error(e.Message);
            }
        }

        private void dtp_desde_ValueChanged(object sender, EventArgs e)
        {
            this.llenarGrid(dtp_desde.Value, dtp_hasta.Value);
        }

        private void grw_promociones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (!this.grw_guias.Rows[e.RowIndex].Cells["Estado"].Value.Equals("Anulada"))
                {
                    this.idGuia = Convert.ToInt32(this.grw_guias.Rows[e.RowIndex].Cells[0].Value);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
        
    }
}
