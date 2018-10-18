using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pos.Clases;
using Pos.Coneccion;

namespace Pos.App
{
    public partial class frm_guiaRemisionDefecto : Form
    {
        public frm_guiaRemisionDefecto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private GuiaRemision tomarDatos()
        { 
            GuiaRemision remision = new GuiaRemision();
            return remision;
           /* remision.venta = this.cbl_motivos.GetItemChecked(0);
            remision.compra = this.cbl_motivos.GetItemChecked(1);
            remision.transformacion = this.cbl_motivos.GetItemChecked(2);
            remision.consignacion = this.cbl_motivos.GetItemChecked(3);
            remision.trasladoEntreEstablecimientos = this.cbl_motivos.GetItemChecked(4);
            remision.trasladoEmisorItinerante = this.cbl_motivos.GetItemChecked(5);
            remision.devolucion = this.cbl_motivos.GetItemChecked(6);
            remision.importacion = this.cbl_motivos.GetItemChecked(7);
            remision.exportacion = this.cbl_motivos.GetItemChecked(8);
            remision.otros = this.cbl_motivos.GetItemChecked(9);
            remision.puntoDePartida = this.txt_puntoPartida.Text;
            remision.ciudadPartida = this.txt_ciudadPartida.Text;
            remision.nombreEncargado = this.txt_nombreEncargado.Text;
            remision.cedulaEncargado = this.txt_cedulaEncargado.Text;
            remision.placaEncargado = this.txt_placaEncargado.Text;
            remision.detalle = new List<String[]>();
            return remision;*/
        }

        private void frm_guiaRemisionDefecto_Load(object sender, EventArgs e)
        {
            GuiaRemision guia = GuiaRemisionTR.consultarXId(0);
            if (guia != null)
            {
                /*this.cbl_motivos.SetItemChecked(0, guia.venta);
                this.cbl_motivos.SetItemChecked(1, guia.compra);
                this.cbl_motivos.SetItemChecked(2, guia.transformacion);
                this.cbl_motivos.SetItemChecked(3, guia.consignacion);
                this.cbl_motivos.SetItemChecked(4, guia.trasladoEntreEstablecimientos);
                this.cbl_motivos.SetItemChecked(5, guia.trasladoEmisorItinerante);
                this.cbl_motivos.SetItemChecked(6, guia.devolucion);
                this.cbl_motivos.SetItemChecked(7, guia.importacion);
                this.cbl_motivos.SetItemChecked(8, guia.exportacion);
                this.cbl_motivos.SetItemChecked(9, guia.otros);
                this.txt_puntoPartida.Text = guia.puntoDePartida;
                this.txt_ciudadPartida.Text = guia.ciudadPartida;
                this.txt_nombreEncargado.Text = guia.nombreEncargado;
                this.txt_cedulaEncargado.Text = guia.cedulaEncargado;
                this.txt_placaEncargado.Text = guia.placaEncargado;*/
            }
        }

        private void frm_guiaRemisionDefecto_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                GuiaRemision guia = this.tomarDatos();
                GuiaRemisionTR tran = new GuiaRemisionTR(guia);
                tran.actualizarGuia();
            }
            catch (Exception error)
            {
                Mensaje.error(error.Message);
            }
        }


    }
}
