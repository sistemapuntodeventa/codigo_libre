using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Pos.Clases;
using Pos.Coneccion;
using System.Threading;
using System.IO;
using System.Net;
using System.Collections;


namespace Pos.App
{
    public partial class frm_cargando : Form
    {
        private int idCaja;
        private Hashtable datosCorreo = null;
        private bool soloCorreo = false;
        private Thread backgroundThread;
        private string correo ="";
        private bool sincronizarGuias = false;
        private string mensajeError = "";
        private bool sincronizacionCorrecta = true;

        public frm_cargando()
        {
            InitializeComponent();
        }

        public frm_cargando(int idCaja,Hashtable datos = null, bool soloCorreo = false)
        {
            InitializeComponent();
            this.idCaja = idCaja;
            this.datosCorreo = datos;
            this.soloCorreo = soloCorreo;
            string mensaje ="";
            this.correo = (datos!=null)?ParametroTR.ConsultarStringXNombre(ref mensaje, "destinatarioCorreo"):"";
        }

        public frm_cargando(int idCaja)
        {
            InitializeComponent();
            this.idCaja = idCaja;
        }

        private void frm_cargando_Load(object sender, EventArgs e)
        {
            this.sincronizarGuias = ParametroTR.ConsultarBool("guiaRemision");
            try
            {
                //this.mostrarAvance();
                this.setearIndeterminada(true);
                //this.sincronizando = true;
                this.backgroundThread = new Thread(
                       new ThreadStart(() =>
                       {
                               try
                               {
                                   this.setTextoEstado("Estableciendo conexión...");
                                   if (General.tieneConexionInternet())
                                   {
                                       if (this.datosCorreo != null)
                                       {
                                           this.setTextoEstado("Enviando mail informativo...");
                                           Mail correo = new Mail();
                                           List<object> datosMail = ParametroTR.ConsultarInt("19,24,49");
                                           correo.enviarCorreo(datosMail[0].ToString(), datosMail[1].ToString(), correo.contenidoCierreCaja(this.idCaja,datosMail[2].Equals("1")));
                                           if (this.soloCorreo)
                                           {
                                               if (this.Visible)
                                               {
                                                   Mensaje.informacion("Caja cerrada sastisfactoriamente.");
                                                   this.cerrarFormulario(DialogResult.OK);
                                               }
                                               else Mensaje.mostrarNotificacion("Punto de Venta", "Caja cerrada satisfactoriamente.");
                                           }
                                       }
                                       if (!this.soloCorreo)
                                       {
                                           this.sincronizarPartes();
                                           if (this.sincronizarGuias) this.sincronizarPartesGuias();
                                       }
                                   }
                                   else
                                   {
                                       if (this.Visible)
                                       {
                                           Mensaje.advertencia("Actualmente no posee conexión a internet.");
                                           this.cerrarFormulario(DialogResult.Cancel);
                                       }
                                       else Mensaje.mostrarNotificacion("Error al sincronizar", "Actualmente no posee conexión a internet.");
                                   }

                               }
                               catch (Exception error)
                               {
                                   this.enviarCorreoError(idCaja,error.Message);
                                   Mensaje.error("Error al sincronizar: " + error.Message);
                                   //this.Invoke(new MethodInvoker(delegate { this.textBox1.Text = error.Message; }));
                                   if (this.Visible) this.cerrarFormulario(DialogResult.Cancel);
                               }
                           }

                       //}
                   ));
                backgroundThread.Start();
            }
            catch (Exception error)
            {
                Mensaje.error(error.Message);
            }
        }

        private Boolean ValidarCertificado(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        protected void sincronizarPartes()
        {
            Sincronizacion.actualizarEstadoFacturas(idCaja);
            List<int> cantidad = Sincronizacion.cantidadFacturas(this.idCaja);
            Sincronizacion xml = new Sincronizacion();
            bool errorSincronizar = false;
            bool sincronizoCorrecto = false;
            string errores = "";

            if (cantidad[0] == 0)
            {
                Sincronizacion.actualizarEstadoInternet("C", idCaja);
                if (!this.sincronizarGuias)
                {
                    Mensaje.informacion("No hay facturas por sincronizar en esta caja.");
                    this.cerrarFormulario(DialogResult.OK);
                }
                return;
            }

            for (int i = 0; i < cantidad[2]; i++)
            { 
                /* 0->n°facturas
                 * 1->cantidad a sincronizar
                 * 2->n° veces a sincronizar
                 */
                int inicio = ((i * cantidad[1]) + 1);
                int fin = (inicio + cantidad[1]) - 1;
                if (fin > cantidad[0]) fin = cantidad[0];

                this.setTextoEstado("Recopilando Información : " + inicio  + " a " + fin  + " de " + cantidad[0]);
                XmlDocument documento = xml.generarXmlCierreCaja(this.idCaja, inicio - 1, cantidad[1], (i == cantidad[2] - 1 && !errorSincronizar));
                //System.Threading.Thread.Sleep(1000);
                this.setTextoEstado("Subiendo Ventas: " + inicio  + " a " + fin  + " de " + cantidad[0]);
                //documento.Save(@"c:\xml\cierre" + idCaja + "_" + i + ".xml");
                /*SincronizarVentasService servicio = new SincronizarVentasService();
                servicio.Timeout = 800000;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(ValidarCertificado);
                sincronizar_ventas parametro = new sincronizar_ventas();
                parametro.empresa = Global.idEmpresa;
                parametro.xml_ventas = General.scapeCharacters(documento.InnerXml);
                sincronizar_ventasResponse respuesta = servicio.sincronizar_ventas(parametro);
                string resultado = respuesta.sincronizar_ventasResult;
                XmlDocument resultadoXml = new XmlDocument();
                resultadoXml.LoadXml(resultado);
                XmlNode raiz = resultadoXml.GetElementsByTagName("root")[0];
                bool respuestaXml = Convert.ToBoolean(raiz["respuesta"].InnerText);
                string errorXml = raiz["error"].InnerText;
                if (respuestaXml)
                {
                    Sincronizacion.actualizarEstadoTemp(idCaja, inicio-1, cantidad[1]);
                    sincronizoCorrecto = true;
                }
                else
                {
                    errores += errorXml + "\n";
                    errorSincronizar = true;
                }*/
            }

            if (errorSincronizar && sincronizoCorrecto)
            {
                Sincronizacion.actualizarEstadoFacturas(idCaja);
                Sincronizacion.actualizarEstadoInternet("I", idCaja);
                if (!this.sincronizarGuias)
                {
                    if (this.Visible)
                    {
                        Mensaje.advertencia("Ventas sincronizadas incompletas.\n" + errores);
                        this.cerrarFormulario(DialogResult.Ignore);
                    }
                    else Mensaje.mostrarNotificacion("Sincronización", "Ventas sincronizadas incompletas.");
                }
                else
                {
                    this.sincronizacionCorrecta = false;
                    this.mensajeError = "Ventas sincronizadas incompletas.\n" + errores;
                }
                this.enviarCorreoError(idCaja,errores);
            }
            else if (errorSincronizar)
            {
                string mensajeError = "Ocurrio un error al sincronizar las ventas: \n" + errores;
                if (!this.sincronizarGuias)
                {
                    if (this.Visible)
                    {
                        Mensaje.error(mensajeError);
                        this.cerrarFormulario(DialogResult.Cancel);
                    }
                }
                else
                {
                    this.sincronizacionCorrecta = false;
                    this.mensajeError = mensajeError;
                }
                this.enviarCorreoError(idCaja,errores);
            }
            else if (sincronizoCorrecto)
            {
                Sincronizacion.actualizarEstadoInternet("C", idCaja);
                Sincronizacion.actualizarEstadoFacturas(idCaja);
                if (!this.sincronizarGuias)
                {
                    if (this.Visible)
                    {
                        Mensaje.informacion("Ventas sincronizadas satisfactoriamente.");
                        this.cerrarFormulario(DialogResult.OK);
                    }
                    else Mensaje.mostrarNotificacion("Ventas Sincronizadas", "Las ventas han sido sincronizadas satisfactoriamente");
                }
                else
                {
                    this.sincronizacionCorrecta = true;
                }
            }
            else {
                Mensaje.error("No hubo respuesta del servidor");
                if (this.Visible) this.cerrarFormulario(DialogResult.Cancel);                
            }
        }

        protected void sincronizarPartesGuias()
        {
            Sincronizacion.actualizarEstadoGuias(idCaja);
            List<int> cantidad = Sincronizacion.cantidadGuias(this.idCaja);
            Sincronizacion xml = new Sincronizacion();
            bool errorSincronizar = false;
            bool sincronizoCorrecto = false;
            string errores = "";

            if (cantidad[0] == 0)
            {
                Sincronizacion.actualizarEstadoInternetGuias("C", idCaja);
                if (this.sincronizacionCorrecta)
                {
                    Mensaje.informacion("Ventas sincronizadas satisfactoriamente.");
                }
                else
                {
                    Mensaje.advertencia(this.mensajeError);
                }
                this.cerrarFormulario(DialogResult.OK);
                return;
            }

            for (int i = 0; i < cantidad[2]; i++)
            {
                /* 0->n°facturas
                 * 1->cantidad a sincronizar
                 * 2->n° veces a sincronizar
                 */
                int inicio = ((i * cantidad[1]) + 1);
                int fin = (inicio + cantidad[1]) - 1;
                if (fin > cantidad[0]) fin = cantidad[0];

                this.setTextoEstado("Recopilando Información Guías de Remisión: " + inicio + " a " + fin + " de " + cantidad[0]);
                XmlDocument documento = xml.generarXmlGuias(this.idCaja, inicio - 1, cantidad[1], (i == cantidad[2] - 1 && !errorSincronizar));
                //System.Threading.Thread.Sleep(1000);
                this.setTextoEstado("Subiendo Guías: " + inicio + " a " + fin + " de " + cantidad[0]);
                //documento.Save(@"c:\xml\cierre" + idCaja + "_" + i + ".xml");
                /*SincronizarVentasService servicio = new SincronizarVentasService();
                servicio.Timeout = 800000;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(ValidarCertificado);
                sincronizar_ventas parametro = new sincronizar_ventas();
                parametro.empresa = Global.idEmpresa;
                parametro.xml_ventas = General.scapeCharacters(documento.InnerXml);
                sincronizar_ventasResponse respuesta = servicio.sincronizar_ventas(parametro);
                string resultado = respuesta.sincronizar_ventasResult;
                XmlDocument resultadoXml = new XmlDocument();
                resultadoXml.LoadXml(resultado);
                XmlNode raiz = resultadoXml.GetElementsByTagName("root")[0];
                bool respuestaXml = Convert.ToBoolean(raiz["respuesta"].InnerText);
                string errorXml = raiz["error"].InnerText;
                if (respuestaXml)
                {
                    Sincronizacion.actualizarEstadoTempGuias(idCaja, inicio - 1, cantidad[1]);
                    sincronizoCorrecto = true;
                }
                else
                {
                    errores += errorXml + "\n";
                    errorSincronizar = true;
                }*/
            }

            if (errorSincronizar && sincronizoCorrecto)
            {
                Sincronizacion.actualizarEstadoGuias(idCaja);
                Sincronizacion.actualizarEstadoInternetGuias("I", idCaja);
                if (this.Visible)
                {
                    string mensajeMostrar = "Guías sincronizadas incompletas.\n" + errores;
                    if (this.sincronizacionCorrecta)
                    {
                        Mensaje.advertencia(mensajeMostrar);
                    }
                    else
                    {
                        Mensaje.advertencia(this.mensajeError + "\n" + mensajeMostrar);
                    }
                    this.cerrarFormulario(DialogResult.Ignore);
                }
                else Mensaje.mostrarNotificacion("Sincronización", "Ventas sincronizadas incompletas.");
                this.enviarCorreoError(idCaja, errores);
            }
            else if (errorSincronizar)
            {
                string mensajeMostrar = "Ocurrio un error al sincronizar las guías: \n" + errores;
                if (this.sincronizacionCorrecta)
                {
                    Mensaje.advertencia(mensajeMostrar);
                }
                else
                {
                    Mensaje.advertencia(this.mensajeError + "\n" + mensajeMostrar);
                }
                if (this.Visible) this.cerrarFormulario(DialogResult.Cancel);
                this.enviarCorreoError(idCaja, errores);
            }
            else if (sincronizoCorrecto)
            {
                Sincronizacion.actualizarEstadoInternetGuias("C", idCaja);
                Sincronizacion.actualizarEstadoGuias(idCaja);
                if (this.Visible)
                {
                    string mensajeMostrar = "Guías sincronizadas satisfactoriamente.";
                    if (this.sincronizacionCorrecta)
                    {
                        Mensaje.informacion("Ventas y " + mensajeMostrar);
                    }
                    else
                    {
                        Mensaje.advertencia(this.mensajeError + "\n" + mensajeMostrar);
                    }
                    this.cerrarFormulario(DialogResult.OK);
                }
                else Mensaje.mostrarNotificacion("Ventas Sincronizadas", "Las ventas han sido sincronizado");
            }
            else
            {
                Mensaje.error("No hubo respuesta del servidor");
                if (this.Visible) this.cerrarFormulario(DialogResult.Cancel);
            }
        }

        protected void enviarCorreoError(int idCaja,string mensaje)
        {
            Mail correo = new Mail();
            correo.enviarCorreoError(idCaja,"Empresa:" + Global.idEmpresa + "\n" + mensaje);
        }

        protected void cerrarFormulario(DialogResult resultado)
        {
            this.Invoke(new MethodInvoker(delegate { this.DialogResult = resultado; this.Close(); }));
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

        private void frm_cargando_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.backgroundThread.ThreadState == ThreadState.Running)
            {
                Mensaje.mostrarNotificacion("Sincronización", "La sincronización se seguirá ejecutando de forma oculta.");
                ///frm_sincronizarVentas ventas = (frm_sincronizarVentas)this.Owner;
                //ventas.Close();
                if(this.Owner is frm_sincronizarVentas)this.Owner.Close();
            }
        }
    }
}
