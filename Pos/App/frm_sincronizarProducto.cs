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
using System.Xml;
using Pos.Clases;
using Pos.com.contifico.pos;
using System.Threading;
using RestSharp;
using RestSharp.Deserializers;

namespace Pos.App
{
    public partial class frm_sincronizarProducto : Form
    {
        private int idBodegaProductos = 0;
        private bool sincronizando = false;
        private Thread backgroundThread;

        public frm_sincronizarProducto()
        {
            this.idBodegaProductos = EmpresaTR.obtenerIdBodegaProductos();
            InitializeComponent();
        }

        protected void ocultarAvance()
        {
            this.lbl_estado.Visible = false;
            this.pro_avance.Visible = false;
        }

        protected void ocultarAvanceHilo()
        {
            this.lbl_estado.BeginInvoke(
                    new Action(() =>{
                        this.lbl_estado.Visible = false;
                    }));   
             this.pro_avance.BeginInvoke(
                    new Action(() =>{
                        this.pro_avance.Visible = false;
                        this.pro_avance.Style = ProgressBarStyle.Blocks;
                        this.pro_avance.MarqueeAnimationSpeed = 0;
                    }));
        }

        protected void mostrarAvance()
        {
            this.lbl_estado.Visible = true;
            this.pro_avance.Visible = true;
            this.lbl_estado.Text = "";
        }

        private void frm_sincronizacion_Load(object sender, EventArgs e)
        {
            if(!General.tieneConexionInternet())this.btn_internet.Enabled = false;
            this.ocultarAvance();
        }

       /* private void sincronizacionCompleta(object sender, sincronizar_productosCompletedEventArgs e)
        {
            Mensaje.advertencia("termino");  
        }*/

        private Boolean ValidarCertificado(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        private void btn_internet_Click(object sender, EventArgs e)
        {
            if (sincronizando)
            {
                Mensaje.advertencia("Actualmente se encuentra sincronizando los productos.");
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

                                this.setTextoEstado("Recibiendo unidades...");
                                var request_unidades = new RestRequest("pos/sincronizar/unidades/", Method.POST);
                                request_unidades.RequestFormat = DataFormat.Json;
                                request_unidades.AddParameter("api", api);
                                var response_unidades = client.Execute(request_unidades);
                                List<Unidad> unidades = deserial.Deserialize<List<Unidad>>(response_unidades);

                                this.setTextoEstado("Recibiendo categorias...");
                                var request_categorias = new RestRequest("pos/sincronizar/categorias/", Method.POST);
                                request_categorias.RequestFormat = DataFormat.Json;
                                request_categorias.AddParameter("api", api);
                                var response_categorias = client.Execute(request_categorias);
                                List<Categoria> categorias = deserial.Deserialize<List<Categoria>>(response_categorias);

                                int factor = parametros["factor"];
                                int cantidad = parametros["cantidad"];
                                List<Producto> productos = new List<Producto>();
                                for (int i = 1; i <= parametros["paginas"]; i++)
                                {
                                    int inicio = 1 + ((i - 1) * factor);
                                    int fin = (i * factor) > cantidad? cantidad:(i*factor);
                                    this.setTextoEstado("Recibiendo productos " + inicio + " a " + fin +" de " + cantidad);
                                    var request_productos = new RestRequest("pos/sincronizar/productos/{id}/", Method.POST);
                                    request_productos.RequestFormat = DataFormat.Json;
                                    request_productos.AddParameter("api", api);
                                    request_productos.AddParameter("pagina", i);
                                    if (this.idBodegaProductos != 0)request_productos.AddParameter("idBodega", this.idBodegaProductos);
                                    request_productos.AddUrlSegment("id", parametros["id"].ToString());
                                    var response_productos = client.Execute(request_productos);
                                    /*List<Producto> temp = deserial.Deserialize<List<Producto>>(response_productos);
                                    productos.AddRange(temp);*/
                                    List<Dictionary<String, String>> productosTemp = deserial.Deserialize<List<Dictionary<String, String>>>(response_productos);
                                    foreach (Dictionary<String, String> diccionario in productosTemp)
                                    {
                                        productos.Add(Producto.generar(diccionario));
                                    }
                                }

                                this.setTextoEstado("Guardando información de Productos...");
                                ProductoTR tran = new ProductoTR();
                                tran.sincronizarProductos(unidades, categorias, productos);

                                this.setTextoEstado("Actualizando estado...");
                                var request_fin = new RestRequest("pos/sincronizar/productos/{id}/fin/", Method.POST);
                                request_fin.RequestFormat = DataFormat.Json;
                                request_fin.AddParameter("api", api);
                                request_fin.AddUrlSegment("id", parametros["id"].ToString());
                                client.Execute(request_fin);
                                
                                this.sincronizando = false;
                                Mensaje.informacion("Productos sincronizados satisfactoriamente.");
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

        public void cerrar()
        {
            this.BeginInvoke(
                    new Action(() =>
                    {
                        this.Close();
                    }));
        }

        public void setTextoEstado(string texto)
        {
            this.lbl_estado.BeginInvoke(
                    new Action(() =>{
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

        //protected void empezarBarra()
        //{
        //    this.pro_avance.MarqueeAnimationSpeed = 50;
        //    this.pro_avance.Style = ProgressBarStyle.Marquee;

           
        //}

        //protected void detenerBarra()
        //{
        //    this.pro_avance.MarqueeAnimationSpeed = 0;
        //    this.pro_avance.Style = ProgressBarStyle.Continuous; 
   
        //}

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
                    this.sincronizarProductos(xml, this.pro_avance);
                    this.ocultarAvance();
                }
                else
                {
                    Mensaje.advertencia("El archivo seleccionado no es un XML");
                }
            }
        }

        protected void sincronizarProductos(XmlDocument xml,ProgressBar barra)
        {
            ProductoTR tran = new ProductoTR();
            string mensaje = "";
            if (tran.sincronizarProductos(ref mensaje, xml, barra))
            {
                Mensaje.informacion("Productos sincronizados satisfactoriamente.");
                this.Close();
            }
            else Mensaje.advertencia("No se pudo sincronizar los productos. \n" + mensaje);

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

        private void lbl_estado_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void sincro_producto_FormClosing(object sender, FormClosingEventArgs e)
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

    }
}
