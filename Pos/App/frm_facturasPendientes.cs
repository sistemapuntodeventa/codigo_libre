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
    public partial class frm_facturasPendientes : Form
    {

        private int y = 12;
        private int x = 5;
        private List<Control> botones;
        private int adicionalPendiente;

        public frm_facturasPendientes(int adicionalPendiente)
        {
            InitializeComponent();
            botones = new List<Control>();
            this.adicionalPendiente = adicionalPendiente;
        }

        private void frm_facturasPendientes_Load(object sender, EventArgs e)
        {
            int posX = ParametroTR.consultarIntXNombre("formularioPendientesX");
            int posY = ParametroTR.consultarIntXNombre("formularioPendientesY");
            if (posX != -1 && posY != -1)
            {
                this.Left = posX;
                this.Top = posY;
            }

            
            List<object[]> facturas = FacturaCabeceraTR.consultarFacturasPendientes(this.adicionalPendiente);
            if (facturas != null)
            {
                foreach (object[] dato in facturas) this.agregarPendiente(dato[0].ToString(), dato[1].ToString());
            }
        }

        public void agregarPendiente(string id, string nombre)
        {
            Button boton = new Button();
            boton.Text = nombre;
            boton.Width = 45;
            boton.Height = 25;
            boton.Left = x;
            boton.Top = y;
            y += 28;
            boton.Name = "b" + id.ToString();
            boton.Click += button1_Click;
            botones.Add(boton);
            boton.FlatStyle = FlatStyle.Flat;
            //boton.BackColor = Color.Gray;
            this.Controls.Add(boton);
        }

        public void modificarPendiente(string id, string nombre)
        {
            Control control = this.botones.Find(element => element.Name == ("b" + id.ToString()));
            if (control != null)((Button)control).Text = nombre;
        }

        public void removerPendiente(string id)
        { 
            //Control control  = this.Controls["b" + id];
            //if (control != null)this.Controls.Remove(control);

            Control boton = null;
            bool modificar = false;
            foreach (Control control in botones)
            {
                if (modificar) control.Top -= 28;
                else if (control.Name == "b" + id)
                {
                    this.Controls.Remove(control);
                    boton = control;
                    modificar = true;
                }

            }
            if (boton != null)
            {
                y -= 28;
                botones.Remove(boton);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idFactura = Convert.ToInt32(((Button)sender).Name.Substring(1));
            //((frm_factura)this.Owner).Focus();
            ((frm_factura)this.Owner).setIdFactura(idFactura,true);

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void frm_facturasPendientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            ParametroTR.actualizarParametroEntero("formularioPendientesX", this.Left);
            ParametroTR.actualizarParametroEntero("formularioPendientesY", this.Top);
        }
    }
}
