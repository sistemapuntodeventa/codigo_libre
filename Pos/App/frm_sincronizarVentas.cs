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
using System.Xml;
using Pos.com.contifico.pos2;

namespace Pos.App
{
    public partial class frm_sincronizarVentas : Form
    {
        private int turnoSincronizar = -1;

        public frm_sincronizarVentas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void frm_sincronizarVentas_Load(object sender, EventArgs e)
        {
            string mensaje = "";
            int permitir = ParametroTR.consultarIntXNombre("sincronizarManual");
            this.grw_cajas.Enabled = (permitir == 1);

            this.dtp_desde.ValueChanged -= dtp_desde_ValueChanged;
            this.dtp_hasta.ValueChanged -= dtp_desde_ValueChanged;

            this.llenarComboEstado();
            this.dtp_desde.Value = DateTime.Now;
            this.dtp_hasta.Value = DateTime.Now;
            this.turnoSincronizar = Sincronizacion.ultimoSincronizado(ref mensaje);
            if (turnoSincronizar == -1) Mensaje.error(mensaje);
            turnoSincronizar++;
            //Mensaje.informacion(mensaje + this.ultimoSincronizado.ToString());
            this.llenarGrid(dtp_desde.Value, dtp_hasta.Value, this.cmb_estado.SelectedValue.ToString());

            this.dtp_desde.ValueChanged += dtp_desde_ValueChanged;
            this.dtp_hasta.ValueChanged += dtp_desde_ValueChanged;
            this.cmb_estado.SelectedValueChanged += cmb_estado_SelectedIndexChanged;
        }

        protected void llenarComboEstado()
        {
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("", "Todos"));
            data.Add(new KeyValuePair<string, string>("P", "Pendiente"));
            data.Add(new KeyValuePair<string, string>("C", "Sincronizada"));
            this.cmb_estado.DataSource = new BindingSource(data, null);
            this.cmb_estado.DisplayMember = "Value";
            this.cmb_estado.ValueMember = "Key";
            this.cmb_estado.SelectedIndex = 0;

        }

        protected void llenarGrid(DateTime desde, DateTime hasta, string estado)
        {
            this.grw_cajas.DataBindings.Clear();
            grw_cajas.Columns.Clear();
            string mensaje = "";
            CajaTR tran = new CajaTR();
            DataTable datos = tran.consultarEstadoCierreCajas(ref mensaje, desde, hasta, estado);
            if (datos != null)
            {
                this.grw_cajas.DataSource = datos;
                int ancho = this.grw_cajas.Width - 40;
                this.grw_cajas.Columns["idCaja"].HeaderText = "N°";
                this.grw_cajas.Columns["idCaja"].Width = Convert.ToInt16(ancho * 0.09);
                //this.grw_cajas.Columns["idCaja"].Visible = false;
                //this.grw_cajas.Columns["idCierreCaja"].Visible = false;
                this.grw_cajas.Columns["Vendedor"].Width = Convert.ToInt16(ancho * 0.25);
                this.grw_cajas.Columns["Fecha Cierre"].Width = Convert.ToInt16(ancho * 0.15);
                this.grw_cajas.Columns["Monto Inicial"].Width = Convert.ToInt16(ancho * 0.10);
                this.grw_cajas.Columns["Cobrado"].Width = Convert.ToInt16(ancho * 0.15);
                this.grw_cajas.Columns["Monto Final"].Width = Convert.ToInt16(ancho * 0.15);
                this.grw_cajas.Columns["Estado"].Width = Convert.ToInt16(ancho * 0.10);
                this.grw_cajas.Columns["generado"].Visible = false;
                this.grw_cajas.Columns["sincronizado"].Visible = false;

                DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
                bcol.Width = 20;
                bcol.HeaderText = "";
                
                bcol.Name = "usb";
                bcol.UseColumnTextForButtonValue = true;
                //bcol.Text = "USB";
                
                this.grw_cajas.Columns.Add(bcol);

                DataGridViewButtonColumn bcol1 = new DataGridViewButtonColumn();
                bcol1.Width = 20;
                bcol1.HeaderText = "";
                bcol1.Name = "internet";
                bcol1.UseColumnTextForButtonValue = true;
                this.grw_cajas.Columns.Add(bcol1);
            }
            else Mensaje.error(mensaje);

        }

        private void grw_cajas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (this.grw_cajas.Columns[e.ColumnIndex].Name == "usb")
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    Bitmap bmp = Pos.Properties.Resources.usbP;
                    DataGridViewButtonCell celBoton = this.grw_cajas.Rows[e.RowIndex].Cells["usb"] as DataGridViewButtonCell;

                    Icon icoAtomico = Icon.FromHandle(bmp.GetHicon());
                    e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);
                    this.grw_cajas.Columns[e.ColumnIndex].Width = 20;
                    e.Handled = true;
                }

                if (this.grw_cajas.Columns[e.ColumnIndex].Name == "internet")
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    Bitmap bmp = Pos.Properties.Resources.webP;
                    DataGridViewButtonCell celBoton = this.grw_cajas.Rows[e.RowIndex].Cells["internet"] as DataGridViewButtonCell;

                    Icon icoAtomico = Icon.FromHandle(bmp.GetHicon());
                    e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 2, e.CellBounds.Top + 3);
                    this.grw_cajas.Columns[e.ColumnIndex].Width = 20;
                    e.Handled = true;
                }

            }
        }

        private void grw_cajas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0 && this.grw_cajas.Columns[e.ColumnIndex].Name == "usb") this.sincronizarUsb(e.RowIndex);
            else if (e.ColumnIndex > 0 && this.grw_cajas.Columns[e.ColumnIndex].Name == "internet") this.sincronizarInternet(e.RowIndex);
        }

        protected void sincronizarUsb(int fila)
        {
            try
            {

                if (this.fbd_buscar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string mensaje = "";
                    //string nuevoNumero = EmpresaTR.obtenerNumerodeCierre(ref mensaje).ToString();
                    int idCaja = Convert.ToInt32(this.grw_cajas["idCaja", fila].Value);
                    Sincronizacion xml = new Sincronizacion();
                    XmlDocument documento = xml.generarXmlCierreCaja(idCaja,0,int.MaxValue,true,true);
                    documento.Save(this.fbd_buscar.SelectedPath + @"\CierreCaja_" + DateTime.Now.ToShortDateString().Replace("/", "") + "_" + idCaja + ".xml");
                    Sincronizacion.actualizarEstadoUsb(ref mensaje, idCaja);
                    Mensaje.informacion("Archivo generado satisfactoriamente.");
                    if (!this.grw_cajas["estado", fila].Value.Equals("SINCRONIZADO")) this.grw_cajas["estado", fila].Value = "GENERADO";
                }
            }
            catch (Exception e)
            {
                Mensaje.error(e.Message);
            }
    
        }

        protected void sincronizarInternet(int fila)
        {
            /*if (false && this.grw_cajas["estado", fila].Value.ToString() == "SINCRONIZADO")
            {
                Mensaje.advertencia("La caja ya ha sido sincronizada.");
                return;
            }
            */
            int idCaja = Convert.ToInt32(this.grw_cajas["idCaja", fila].Value);

            //this.turnoSincronizar = idCaja;
            //if (true || idCaja <= this.turnoSincronizar)
            //{
            if (Mensaje.confirmacion("Desea empezar la sincronización?\nEsto puede tardar unos minutos."))
            {
                //int idCaja = Convert.ToInt32(this.grw_cajas["idCaja", fila].Value);
                frm_cargando sincronizar = new frm_cargando(idCaja);
                sincronizar.Owner = this;
                DialogResult resultado =  sincronizar.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    this.turnoSincronizar = idCaja + 1;
                    this.grw_cajas["estado", fila].Value = "SINCRONIZADO";
                }
                else if (resultado == DialogResult.Ignore) this.grw_cajas["estado", fila].Value = "INCOMPLETO";
                   
            }
                
            //}
            //else Mensaje.advertencia("Debe sincronizar la caja N°" + turnoSincronizar);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dtp_desde_ValueChanged(object sender, EventArgs e)
        {
            this.llenarGrid(dtp_desde.Value, dtp_hasta.Value, this.cmb_estado.SelectedValue.ToString());
        }

        private void cmb_estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.llenarGrid(dtp_desde.Value, dtp_hasta.Value, this.cmb_estado.SelectedValue.ToString());
        }
    }
}
