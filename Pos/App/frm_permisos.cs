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
    public partial class frm_permisos : Form
    {
        public frm_permisos()
        {
            InitializeComponent();
        }

        private void frm_permisos_Load(object sender, EventArgs e)
        {
            this.aVueltoCheque.Visible = false;
            this.aVueltoCredito.Visible = false;
            this.aSeleccionarVendedor.Visible = false;

            this.cVueltoCheque.Visible = false;
            this.cVueltoCredito.Visible = false;
            this.cSeleccionarVendedor.Visible = false;
            //this.SetBalloonTip();
            string mensaje = "";
            Permiso permiso = PermisoTR.consultar(ref mensaje, 1);
            if (permiso != null)
            {
                this.aDna.Checked = permiso.dna;
                this.aDescuento.Checked = permiso.descuento;
                this.aVueltoCheque.Checked = permiso.vueltoCheque;
                this.aVueltoCredito.Checked = permiso.vueltoCredito;
                this.aNotaCredito.Checked = permiso.notaCredito;
                this.aSeleccionarVendedor.Checked = permiso.SeleccionarVendedor;
                this.aPropina.Checked = permiso.Propina;
                this.aAnularFactura.Checked = permiso.anularFactura;
                //this.aPendientes.Checked = permiso.Pendientes;
                permiso = PermisoTR.consultar(ref mensaje, 2);
                if (permiso != null)
                {
                    this.cDna.Checked = permiso.dna;
                    this.cDescuento.Checked = permiso.descuento;
                    this.cVueltoCheque.Checked = permiso.vueltoCheque;
                    this.cVueltoCredito.Checked = permiso.vueltoCredito;
                    this.cNotaCredito.Checked = permiso.notaCredito;
                    this.cSeleccionarVendedor.Checked = permiso.SeleccionarVendedor;
                    this.cPropina.Checked = permiso.Propina;
                    this.cAnularFactura.Checked = permiso.anularFactura;
                    ///this.cPendientes.Checked = permiso.Pendientes;
                }
                else Mensaje.error(mensaje);
            }
            else Mensaje.error(mensaje);
           
        }

        private void SetBalloonTip()
        {
            iconoNotificacion.Visible = true;
            iconoNotificacion.Icon = SystemIcons.Exclamation;
            iconoNotificacion.BalloonTipTitle = "Balloon Tip Title";
            iconoNotificacion.BalloonTipText = "Balloon Tip Text.";
            iconoNotificacion.BalloonTipIcon = ToolTipIcon.Error;
            iconoNotificacion.ShowBalloonTip(30000); 
        }

        private void frm_permisos_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            Permiso permiso = new Permiso();
            permiso.dna = this.aDna.Checked;
            permiso.descuento = this.aDescuento.Checked;
            permiso.vueltoCheque = this.aVueltoCheque.Checked;
            permiso.vueltoCredito = this.aVueltoCredito.Checked;
            permiso.notaCredito = this.aNotaCredito.Checked;
            permiso.SeleccionarVendedor = this.aSeleccionarVendedor.Checked;
            permiso.Propina = this.aPropina.Checked;
            permiso.Pendientes = false;
            permiso.anularFactura = this.aAnularFactura.Checked;
            PermisoTR tran = new PermisoTR(permiso);
            if (tran.actualizar(ref mensaje, 1))
            {
                tran.refrescar();
                permiso.dna = this.cDna.Checked;
                permiso.descuento = this.cDescuento.Checked;
                permiso.vueltoCheque = this.cVueltoCheque.Checked;
                permiso.vueltoCredito = this.cVueltoCredito.Checked;
                permiso.notaCredito = this.cNotaCredito.Checked;
                permiso.SeleccionarVendedor = this.cSeleccionarVendedor.Checked;
                permiso.Propina = this.cPropina.Checked;
                permiso.anularFactura = this.cAnularFactura.Checked;
                permiso.Pendientes = false;
                if (tran.actualizar(ref mensaje, 2)) Mensaje.informacion("Permisos actualizados correctamente.");
                else Mensaje.error(mensaje);
            }
            else Mensaje.error(mensaje);
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
