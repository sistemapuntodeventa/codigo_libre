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
    public partial class frm_autorizacion : Form
    {
        private int idAutorizacion;
        private bool estadoGuardar = true;
        public DataGridViewRow fila;

        public frm_autorizacion()
        {
            InitializeComponent();
        }

        public frm_autorizacion(int idAutorizacion, DataGridViewRow fila)
        {
            InitializeComponent();
            this.idAutorizacion = idAutorizacion;
            this.fila = fila;
            this.estadoGuardar = false;

        }

        private void frm_autorizacion_Load(object sender, EventArgs e)
        {
            this.cargarEstablecimientos();
            if (!estadoGuardar) this.buscarAutorizacion(idAutorizacion);
        }

        protected void buscarAutorizacion(int idAutorizacion)
        {
            String mensaje = "";
            AutorizacionTR tran = new AutorizacionTR();
            Autorizacion autorizacion = tran.buscarXId(idAutorizacion, ref mensaje);
            if (autorizacion != null)
            {
                llenarCampos(autorizacion);
                this.idAutorizacion = autorizacion.Idtbl_autorizacion;
                activarEstadoActualizar();

            }
            else
            {
                if (String.IsNullOrEmpty(mensaje)) Mensaje.advertencia("No se encontró la autorización.");
                else Mensaje.error(mensaje);
            }
        }

        protected void llenarCampos(Autorizacion autorizacion)
        {
            this.txt_autorizacion.Text = autorizacion.NumeroAutorizacion;
            this.txt_fin.Text = autorizacion.SecuenciaFin;
            this.txt_inicio.Text = autorizacion.SecuenciaInicio;
            this.cmb_establecimiento.SelectedValue = autorizacion.Id_Establecimiento;
            this.dtp_fechaVencimiento.Value = autorizacion.FechaVencimiento;
        }

        protected void cargarEstablecimientos() {
            string msn = "";
            EstablecimientoTR tran = new EstablecimientoTR();
            DataTable datos = tran.consultarEstablecimiento(ref msn);
            if (datos != null)
            {
                this.cmb_establecimiento.DataSource = datos;
                this.cmb_establecimiento.ValueMember = "id";
                this.cmb_establecimiento.DisplayMember = "nombre";
            }
            else Mensaje.error(msn);

            this.cmb_establecimiento.Focus();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                Autorizacion autorizacion = new Autorizacion();
                autorizacion.Idtbl_autorizacion = this.idAutorizacion;
                autorizacion.Id_Establecimiento = (int)this.cmb_establecimiento.SelectedValue;
                autorizacion.NumeroAutorizacion = this.txt_autorizacion.Text;
                autorizacion.SecuenciaInicio = this.txt_inicio.Text;
                autorizacion.SecuenciaFin = this.txt_fin.Text;
                autorizacion.FechaVencimiento = this.dtp_fechaVencimiento.Value;
                autorizacion.Estado = true;
                String mensaje = "";
                AutorizacionTR tran = new AutorizacionTR(autorizacion);
                if (estadoGuardar && tran.insertarAutorizacion(ref mensaje))
                {
                    Mensaje.informacion("Autorización ingresada con éxito");
                    this.limpiar();
                    this.cmb_establecimiento.Focus();
                }
                else if (!estadoGuardar && tran.actualizarAutorizacion(ref mensaje))
                {
                    Mensaje.informacion("Autorización actualizada con éxito.");
                    if (this.fila != null) pasarDatos();
                    this.limpiar();
                    cmb_establecimiento.Focus();
                }
                else Mensaje.error(mensaje);
            }

        }

        protected void pasarDatos()
        {
            this.fila.Cells["Nombre"].Value = this.cmb_establecimiento.Text;
            this.fila.Cells["Autorización"].Value = this.txt_autorizacion.Text;
            this.fila.Cells["Vence"].Value = this.dtp_fechaVencimiento.Value;
            this.fila.Cells["Inicio"].Value = this.txt_inicio.Text;
            this.fila.Cells["Fin"].Value = this.txt_fin.Text;
            this.Close();
        }

        public bool validar()
        {
            if (this.cmb_establecimiento.SelectedIndex == -1)
            {
                Mensaje.faltaCampo("Debe seleccionar un establecimiento.");
                cmb_establecimiento.Focus();
                return false;
            } 
            if (this.txt_autorizacion.Text.Trim().Length < 1)
            {
                Mensaje.faltaCampo("Debe ingresar el campo autorización.");
                txt_autorizacion.Focus();
                return false;
            }
            if (this.txt_inicio.Text.Trim().Length < 1)
            {
                Mensaje.faltaCampo("Debe ingresar el campo Secuencia Inicio.");
                txt_autorizacion.Focus();
                return false;
            }
            if (this.txt_fin.Text.Trim().Length < 1)
            {
                Mensaje.faltaCampo("Debe ingresar el campo Secuencia Fin.");
                txt_autorizacion.Focus();
                return false;
            }

            if (Convert.ToInt64(txt_inicio.Text) >= Convert.ToInt64(txt_fin.Text))
            {
                Mensaje.faltaCampo("La secuencia final debe ser mayor a la inicial.");
                txt_fin.Focus();
                return false;
            }

            return true;
        }

        private void txt_autorizacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar) < 48 && e.KeyChar != 8 && e.KeyChar != 44 && e.KeyChar != 13) || e.KeyChar > 57)
            { e.Handled = true; }
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            this.txt_autorizacion.Text = "";
            this.btn_guardar.Enabled = true;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_limpiar_Click_1(object sender, EventArgs e)
        {
            this.limpiar();
        }

        protected void limpiar() {
            this.cmb_establecimiento.SelectedIndex = -1;
            this.txt_autorizacion.Clear();
            this.txt_fin.Clear();
            this.txt_inicio.Clear();
            this.dtp_fechaVencimiento.Value = DateTime.Now;
        }

        private void txt_autorizacion_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            General.soloNumeros(e);
        }

        private void txt_inicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.soloNumeros(e);
        }

        private void txt_fin_KeyPress(object sender, KeyPressEventArgs e)
        {
            General.soloNumeros(e);
        }


        protected void activarEstadoActualizar()
        {
            this.btn_guardar.Text = "Actualizar";
        }

        private void cmb_establecimiento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
