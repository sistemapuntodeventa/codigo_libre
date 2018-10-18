using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pos.Coneccion;
using MySql.Data.MySqlClient;
using Pos.Clases;

namespace Pos.App
{
    public partial class frm_editarPos : Form
    {

        public int idPOS;

        public frm_editarPos()
        {
            InitializeComponent();
            this.idPOS = 0;
        }

        private void frm_editarPos_Load(object sender, EventArgs e)
        {
            this.llenarComboTipoDocumento();
            this.llenarGrid("");
            this.cmb_tipoDocumento.SelectedValueChanged += cmb_tipoDocumento_SelectedIndexChanged;
        }

        protected void llenarComboTipoDocumento()
        {
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("", "Todos"));
            data.Add(new KeyValuePair<string, string>("F", "Factura"));
            data.Add(new KeyValuePair<string, string>("N", "Nota de Venta"));
            data.Add(new KeyValuePair<string, string>("D", "Documento No Autorizado"));
            data.Add(new KeyValuePair<string, string>("G", "Guía de Remisión"));
            this.cmb_tipoDocumento.DataSource = new BindingSource(data, null);
            this.cmb_tipoDocumento.DisplayMember = "Value";
            this.cmb_tipoDocumento.ValueMember = "Key";
            this.cmb_tipoDocumento.SelectedIndex = 0;

        }

        protected void llenarGrid(string tipoDocumento)
        {
            this.grw_configuraciones.DataBindings.Clear();
            grw_configuraciones.Columns.Clear(); 
            string msn = "";
            ConfiguracionPosTR conf = new ConfiguracionPosTR();
            DataTable datos = conf.consultarConfiguraciones(ref msn, tipoDocumento);
            if (datos != null)
            {
                this.grw_configuraciones.DataSource = datos;
                this.grw_configuraciones.Columns[0].Visible = false;
                int ancho = this.grw_configuraciones.Width - 20;
                this.grw_configuraciones.Columns[1].Width = Convert.ToInt16(ancho * 0.20);
                this.grw_configuraciones.Columns[2].Width = Convert.ToInt16(ancho * 0.20);
                this.grw_configuraciones.Columns[3].Width = Convert.ToInt16(ancho * 0.20);
                this.grw_configuraciones.Columns[4].Width = Convert.ToInt16(ancho * 0.20);
                this.grw_configuraciones.Columns[5].Width = Convert.ToInt16(ancho * 0.19);
                DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
                bcol.Width = 20;
                bcol.HeaderText = "";
                bcol.Name = "botonEditar";
                bcol.UseColumnTextForButtonValue = true;
                //grw_empleado.Columns.Insert(5, bcol); 
                this.grw_configuraciones.Columns.Add(bcol);

            }
            else Mensaje.error(msn);
        }

        public void limpiarDataGrid()
        {
            this.grw_configuraciones.DataBindings.Clear();
        }

        private void grw_configuraciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) this.editar(e);
        }

        private void grw_configuraciones_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (this.grw_configuraciones.Columns[e.ColumnIndex].Name == "botonEditar")
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    Bitmap bmp = Pos.Properties.Resources.editar_fila;
                    DataGridViewButtonCell celBoton = this.grw_configuraciones.Rows[e.RowIndex].Cells["botonEditar"] as DataGridViewButtonCell;

                    Icon icoAtomico = Icon.FromHandle(bmp.GetHicon());
                    e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                    // this.grw_empleado.AutoResizeRow(e.RowIndex);
                    //this.grw_empleado.Rows[e.RowIndex].Height = 20;
                    this.grw_configuraciones.Columns[e.ColumnIndex].Width = 20;
                    e.Handled = true;
                }
            }
        }

        private void grw_configuraciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0 && this.grw_configuraciones.Columns[e.ColumnIndex].Name == "botonEditar") this.editar(e);
        }


        protected void editar(DataGridViewCellEventArgs e)
        {
            string codigo = this.grw_configuraciones.Rows[e.RowIndex].Cells[0].Value.ToString();
            frm_configuracionPos configuracion = new frm_configuracionPos(codigo, grw_configuraciones.Rows[e.RowIndex]);
            configuracion.Owner = this;
            configuracion.ShowDialog();
        }

        public void limpiarPredeterminada()
        {
            foreach (DataGridViewRow fila in this.grw_configuraciones.Rows)
            {
                if (General.obtenerValorCelda(fila.Cells["Predeterminada"]) == "SI")
                {
                    fila.Cells["Predeterminada"].Value = "NO";
                }
            }
        }

        private void cmb_tipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.llenarGrid(this.cmb_tipoDocumento.SelectedValue.ToString());
        }
        
    }
}
