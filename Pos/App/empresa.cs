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

namespace Pos.App
{
    public partial class frm_empresa : Form
    {
        public static Empresa datos;
        public frm_empresa()
        {
            InitializeComponent();
            datos = new Empresa();
        }

        private void txt_soloNumeros(object sender, KeyPressEventArgs e)
        {
            General.soloNumeros(e);
        }


        private void btn_registrar_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                string archivo = this.txt_archivo.Text;
                xml.Load(@archivo);
                XmlNode raiz = xml.FirstChild;
                Empresa empresa = new Empresa();
                empresa.Idtbl_empresa = Convert.ToInt32(raiz["empresa_id"].InnerText);
                empresa.Ruc = raiz["ruc"].InnerText;
                empresa.Bodega = Convert.ToInt32(raiz["bodega_id"].InnerText);
                empresa.Razon_social = raiz["razon_social"].InnerText;
                empresa.Telefonos = raiz["telefonos"].InnerText;
                empresa.Direccion = raiz["direccion"].InnerText;
                empresa.NumeroDecimales = Convert.ToInt32(raiz["numero_decimales"].InnerText);
                empresa.IdConsumidorFinal = Convert.ToInt32(raiz["consumidor_final_id"].InnerText);
                empresa.ClaveGenerada = raiz["clave_generada"].InnerText;
                empresa.IdCaja = Convert.ToInt32(raiz["cuenta_caja_id"].InnerText);
                EmpresaTR tran = new EmpresaTR(empresa);
                string mensaje = "";
                if (tran.insertarEmpresa(ref mensaje))
                {
                    Mensaje.informacion("Empresa almacenada con éxito.");
                    this.Close();
                }
                else Mensaje.error(mensaje);
            }
            catch (Exception error)
            {
                Mensaje.advertencia(error.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = this.dlg_abrir.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.txt_archivo.Text = this.dlg_abrir.FileName;
            }
        }       
    }
}
