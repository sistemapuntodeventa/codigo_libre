using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Pos.Coneccion;
using Pos.Clases;
using System.Threading;
using RestSharp;
using RestSharp.Deserializers;

namespace Pos.App
{
    public partial class frm_sincronizarPersonas : Form
    {
        private bool sincronizando = false;
        private Thread backgroundThread;
        private int idBodegaProductos = 0;
        

        public frm_sincronizarPersonas()
        {
            this.idBodegaProductos = EmpresaTR.obtenerIdBodegaProductos();
            InitializeComponent();
        }

  

        protected void mostrarAvance()
        {
            this.lbl_estado.Visible = true;
            this.pro_avance.Visible = true;
            this.lbl_estado.Text = "";
        }

        protected void ocultarAvance()
        {
            this.lbl_estado.Visible = false;
            this.pro_avance.Visible = false;
        }

        protected void ocultarAvanceHilo()
        {
            this.lbl_estado.BeginInvoke(
                    new Action(() =>
                    {
                        this.lbl_estado.Visible = false;
                    }));
            this.pro_avance.BeginInvoke(
                   new Action(() =>
                   {
                       this.pro_avance.Visible = false;
                       this.pro_avance.Style = ProgressBarStyle.Blocks;
                       this.pro_avance.MarqueeAnimationSpeed = 0;
                       
                   }));
        }

        private void btn_usb_Click(object sender, EventArgs e)
        {

            DialogResult result = this.dlg_abrir.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string archivo = this.dlg_abrir.FileName;
                if (validarArchivo(archivo))
                {
                    this.mostrarAvance();
                    XmlDocument xml = new XmlDocument();
                    xml.Load(@archivo);
                    this.sincronizarPersonas(xml, this.pro_avance);
                    this.ocultarAvance();
                }
                else
                {
                    Mensaje.advertencia("El archivo seleccionado no es un XML");
                }
            }
        }

        protected void sincronizarPersonas(XmlDocument xml, ProgressBar barra)
        {
            PersonaTR tran = new PersonaTR();
            string mensaje = "";
            if (tran.sincronizarPersona(ref mensaje, xml, barra))
            {
                Mensaje.informacion("Personas sincronizadas satisfactoriamente.");
                this.Close();
            }
            else Mensaje.advertencia("No se pudo sincronizar las personas. \n" + mensaje);
        }

        public bool validarArchivo(string ruta)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ProhibitDtd = false;
            settings.ValidationType = ValidationType.DTD;
            XmlReader reader = XmlReader.Create(ruta, settings);
            try
            {
                while (reader.Read()) ;
                return true;
            }
            catch (XmlException)
            {
                return false;
            }
        }

        public void setTextoEstado(string texto)
        {
            this.lbl_estado.BeginInvoke(
                    new Action(() =>
                    {
                        this.lbl_estado.Text = texto;
                    }));
        }

        public void setearIndeterminada(bool estado)
        {
            this.pro_avance.BeginInvoke(
                new Action(() =>
                {
                    if (estado)
                    {
                        this.pro_avance.Style = ProgressBarStyle.Marquee;
                        this.pro_avance.MarqueeAnimationSpeed = 50;
                    }
                    else
                    {
                        this.pro_avance.Style = ProgressBarStyle.Blocks;
                        this.pro_avance.MarqueeAnimationSpeed = 0;
                    }
                }
            ));
        }

        private Boolean ValidarCertificado(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public void btn_internet_Click(object sender, EventArgs e)
        {
            if (sincronizando)
            {
                Mensaje.advertencia("Actualmente se encuentra sincronizando las personas.");
                return;
            }
            if (!Mensaje.confirmacion("Desea empezar la sincronización?\nEsto puede tardar unos minutos.")) return;
            try
            {
                this.mostrarAvance();
                this.setearIndeterminada(true);
                this.sincronizando = true;
                this.backgroundThread = new Thread(
                       new ThreadStart(() =>
                       {
                           try
                           {
                               string api = Global.api;
                               this.setTextoEstado("Estableciendo conexión...");
                               var client = new RestClient("");
                               client.Timeout = 800000;
                               var request = new RestRequest("", Method.POST);
                               request.AddParameter("api", api);
                               IRestResponse response = client.Execute(request);
                               JsonDeserializer deserial = new JsonDeserializer();
                               var parametros = deserial.Deserialize<Dictionary<string, int>>(response);

                               int factorb = parametros["factor"];
                               int cantidad = parametros["cantidad"];
                               List<Persona> personas = new List<Persona>();
                               
                               for (int i = 1; i <= parametros["paginas"]; i++)
                               {
                                   int inicio = 1 + ((i - 1) * factorb);
                                   int fin = (i * factorb) > cantidad ? cantidad : (i * factorb);
                                   this.setTextoEstado("Recibiendo personas " + inicio + " a " + fin + " de " + cantidad);
                                   var request_personas = new RestRequest("pos/sincronizar/personas/{id}/", Method.POST);
                                   request_personas.RequestFormat = DataFormat.Json;
                                   request_personas.AddParameter("api", api);
                                   request_personas.AddParameter("pagina", i);
                                   if (this.idBodegaProductos != 0) request_personas.AddParameter("idBodega", this.idBodegaProductos);
                                   request_personas.AddUrlSegment("id", parametros["id"].ToString());
                                   var response_personas = client.Execute(request_personas);
                                   List<Dictionary<String, String>> personasTemp = deserial.Deserialize<List<Dictionary<String, String>>>(response_personas);
                                   foreach (Dictionary<String, String> diccionario in personasTemp)
                                   { 
                                       personas.Add(Persona.generar(diccionario));
                                   }
                               }

                               this.setTextoEstado("Guardando información de Personas recibidas...");
                               PersonaTR tran = new PersonaTR();
                               tran.SincronizarPersona(personas);

                               this.setTextoEstado("Actualizando estado...");
                               var request_fin = new RestRequest("pos/sincronizar/personas/{id}/fin/", Method.POST);
                               request_fin.RequestFormat = DataFormat.Json;
                               request_fin.AddParameter("api", api);
                               request_fin.AddUrlSegment("id", parametros["id"].ToString());
                               client.Execute(request_fin);

                               this.sincronizando = false;
                               Mensaje.informacion("Personas sincronizadas satisfactoriamente.");
                               this.ocultarAvanceHilo();
                               this.cerrar();

                           }
                           catch (Exception error)
                           {
                               Mensaje.error(error.Message);
                               this.sincronizando = false;
                               this.cerrar();
                           }
                       }
                   ));
                backgroundThread.Start();

            }
            catch (Exception error)
            {
                Mensaje.error(error.Message);
            }

        }

        private void frm_sincronizarPersonas_Load(object sender, EventArgs e)
        {
            if (!General.tieneConexionInternet()) this.btn_internet.Enabled = false;
            this.ocultarAvance();
        }

        private void frm_sincronizarPersonas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.sincronizando)
            {
                if (Mensaje.confirmacion("Seguro que desea salir? Esto cancelará la sincronización en curso."))
                {
                    this.backgroundThread.Abort();
                }
                else e.Cancel = true;    
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void cerrar()
        {
            this.BeginInvoke(
                    new Action(() =>
                    {
                        this.Close();
                    }));
        }

        

      

    }


}
