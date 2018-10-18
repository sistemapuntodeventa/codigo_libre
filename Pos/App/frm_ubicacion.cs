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
    public partial class frm_ubicacion : Form
    {
        List<ComboboxItem> impresoras = null;
        string impresoraActual = "";
        string impresoraActual2 = "";

        public frm_ubicacion()
        {
            InitializeComponent();
        }

        private void frm_parametro_Load(object sender, EventArgs e)
        {

            List<Object> lista = ParametroTR.ConsultarInt("41,42,15,43,55");
            this.txt_ancho.Text = lista[1].ToString();
            this.txt_alto.Text = lista[2].ToString();
            this.txt_copias.Text = lista[0].ToString();
            this.txt_copias2.Text = lista[3].ToString();
            this.chk_ubicaciones.Checked = (Convert.ToInt32(lista[4]) == 1);
            if (Convert.ToInt32(lista[3]) < 1)
            {
                this.txt_copias2.Enabled = false;
            }
            else
            {
                this.chk_copiarprefactura.Checked = true;
            }

            this.llenarImpresoraPrincipal();
            impresoras = Impresion.impresorasDisponibles();
            List<Ubicacion> ubicaciones = UbicacionTR.listadoUbicaciones();
            int i = 0;
            if (ubicaciones != null)
            {
                foreach (Ubicacion ubicacion in ubicaciones)
                    if (this.impresoras.Find(element => element.Text == ubicacion.impresora) == null) this.impresoras.Add(new ComboboxItem(ubicacion.impresora, ubicacion.impresora));
            }
            if (impresoras != null)
            {
                impresora.DataSource = impresoras;
                impresora.ValueMember = "Value";
                impresora.DisplayMember = "Text";
            }
            if (ubicaciones != null)
            {
                foreach (Ubicacion ubicacion in ubicaciones)
                {
                    this.grw_ubicaciones.Rows.Add();
                    this.grw_ubicaciones["id", i].Value = ubicacion.id;
                    this.grw_ubicaciones["nombre", i].Value = ubicacion.nombre;
                    this.grw_ubicaciones["impresora", i].Value = ubicacion.impresora;
                    i++;
                }
            }

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


        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grw_ubicaciones_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           /* List<ComboboxItem> impresoras = Impresion.impresorasDisponibles();
            DataGridViewComboBoxCell combo = (DataGridViewComboBoxCell)this.grw_ubicaciones["impresora", e.RowIndex];
            combo.Items.Clear();
            combo.DataSource = impresoras;
            combo.ValueMember = "Value";
            combo.DisplayMember = "Text";*/
        }

        private void grw_ubicaciones_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (this.grw_ubicaciones.Columns[e.ColumnIndex].Name == "botonEliminar1")
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    Bitmap bmp = Pos.Properties.Resources.borrar_fila;
                    DataGridViewButtonCell celBoton = this.grw_ubicaciones.Rows[e.RowIndex].Cells["botonEliminar1"] as DataGridViewButtonCell;
                    Icon icoAtomico = Icon.FromHandle(bmp.GetHicon());
                    e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 2, e.CellBounds.Top + 3);
                    this.grw_ubicaciones.Columns[e.ColumnIndex].Width = 21;
                    e.Handled = true;
                }

            }
        }

        private void grw_ubicaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.grw_ubicaciones.Columns[e.ColumnIndex].Name == "botonEliminar1") this.eliminar(e);
        }

        protected void eliminar(DataGridViewCellEventArgs e)
        {
            try
            {
                if(this.grw_ubicaciones.CurrentRow.IsNewRow)return;
                if (Mensaje.confirmacion("¿Desea eliminar la ubicación?"))
                {
                    int idUbicacion = Convert.ToInt32(this.grw_ubicaciones.Rows[e.RowIndex].Cells["id"].Value);
                    String mensaje = "";
                    if (UbicacionTR.eliminarUbicacion(ref mensaje, idUbicacion))
                    {
                        this.grw_ubicaciones.Rows.RemoveAt(e.RowIndex);
                        if (this.grw_ubicaciones.Rows.Count < 1) this.grw_ubicaciones.Rows.Add();
                    }
                    else Mensaje.advertencia(mensaje);
                }
            }catch(Exception error)
            {
                Mensaje.error(error.Message);
            }
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
                ParametroTR.actualizarParametroEntero("imprimirUbicaciones", (this.chk_ubicaciones.Checked) ? 1 : 0);

                List<Ubicacion> insertar = new List<Ubicacion>();
                List<Ubicacion> actualizar = new List<Ubicacion>();
                foreach (DataGridViewRow fila in this.grw_ubicaciones.Rows)
                {
                    if (!General.filaVacia(fila))
                    {
                        Ubicacion ubicacion = new Ubicacion();
                        ubicacion.nombre = fila.Cells["nombre"].Value.ToString();
                        ubicacion.impresora = fila.Cells["impresora"].Value.ToString();
                        ubicacion.estado = "A"; // fila.Cells["impresora"];
                        if (!General.celdaVacia(fila.Cells["id"]))
                        {
                            ubicacion.id = Convert.ToInt32(fila.Cells["id"].Value);
                            actualizar.Add(ubicacion);
                        }
                        else insertar.Add(ubicacion);

                    }
                }
                UbicacionTR.operacionUbicacion(insertar, true);
                UbicacionTR.operacionUbicacion(actualizar, false);
                Mensaje.informacion("Ubicaciones actualizadas satisfactoriamente");
                this.Close();
            }
            catch (Exception error)
            {
                Mensaje.advertencia(error.Message);
            }
        }

        private void chk_copiarprefactura_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk_copiarprefactura.Checked)
            {
                this.txt_copias2.Enabled = true;
                this.txt_copias2.Focus();
            }
            else 
            {
                this.txt_copias2.Enabled = false;
                this.txt_copias2.Text = "0";
            }
        }

    }
}
