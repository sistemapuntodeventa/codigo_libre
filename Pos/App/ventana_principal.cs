using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pos.Clases;
using Pos.Coneccion;
using System.Net;
using System.IO;
using TestLib;
using System.Xml;
using Pos.App.Reportes;
using System.Threading;
using System.Net.Sockets;
using RestSharp;
using RestSharp.Deserializers;


namespace Pos.App
{
    public partial class frm_menu : Form
    {

       frm_factura frmFactura;
       FormWindowState winEstadoFactura;
       private Thread backgroundThread;
       private Thread backgroundSocket;
       private Thread backgroundActivity;
       

       public frm_menu()
       {
           InitializeComponent();
       }
       
       public void actualizarColor()
       {
           Apariencia.colorDeMenu(this.menu_principal);
           Apariencia.imagenFormulario(this);
           Apariencia.colorBotones(new List<Button> { this.btn_caja, this.btn_facturar, this.btn_cerrar, this.btn_salir, this.btn_guia });
       }

       public void setThread(Thread hilo)
       {
           this.backgroundActivity = hilo;
           this.backgroundActivity.IsBackground = true;
           this.backgroundActivity.Start();
       }

       private void frm_menu_Load(object sender, EventArgs e)
       {
           string msn = "";
            if (!EmpresaTR.llenarDatosGlobales(ref msn))
            {
                Mensaje.advertencia(msn);
                Global.nombreImpresora = "Generic / Text Only";
                Global.cantidadDecimales = 2;
            }
            if (Global.idRol != 1) this.tsm_editar.Visible = false;
            List<ItemMenu> items = MenuTR.consultarItemsXRol(Global.idRol);
            bool usarGuia = ParametroTR.ConsultarBool("guiaRemision");
            if (usarGuia)
            {
                this.flp_botones.Left -= this.btn_guia.Width / 2; 
                this.btn_guia.Show();
            }
            this.procesarMenu(0, null, items);
            this.actualizarColor();
            this.abrirSocket();

            if (ParametroTR.ConsultarSincronizacionContinua("") == 1)
                this.verificarSincronizacionContinua();
            else
                this.verificarSincronizacion();

            

            
        }

       protected void verificarSincronizacionContinua(int idCaja = -1) {
           this.backgroundThread = new Thread(
               new ThreadStart(() =>
               {
                   string mensaje = "";
                   
                   int valor = (idCaja == -1)?ParametroTR.consultarIntXNombre("sincronizarOculta"):1;
                   string mensajeOmitir = (idCaja == -1)?ParametroTR.ConsultarStringXNombre(ref mensaje, "mensajeOmitir"):"";
                   bool sincronizarGuias = ParametroTR.ConsultarBool("guiaRemision");
                   if (valor == 1)
                   {
                       Sincronizacion sincronizacion = new Sincronizacion();
                       try
                       {
                           bool estado = false;
                           while (estado == false)
                           {
                           ParametroTR.actualizarParametroEntero("sincronizarManual", 0);
                           sincronizacion.setTextoCotrol(this.sba_estado, "Verificado sus cajas pendientes...");
                           List<int> cajas = null;
                           if (idCaja == -1) cajas = sincronizacion.cajasPendientes();
                           else
                           {
                               cajas = new List<int>();
                               cajas.Add(idCaja);
                           }
                           estado = true;
                           if (cajas != null)
                           {
                               foreach (int caja in cajas)
                               {
                                   try
                                   {
                                       bool resultado = sincronizacion.sincronizarPartes(caja, this.sba_estado, mensajeOmitir);
                                       bool resultadoGuias = true;
                                       if (sincronizarGuias)
                                       {
                                           resultadoGuias = sincronizacion.sincronizarPartesGuias(caja, this.sba_estado, mensajeOmitir);
                                       }
                                       estado = estado && resultado && resultadoGuias;
                                   }
                                   catch (Exception e)
                                   {
                                       Mail correo = new Mail();
                                       correo.enviarCorreoError(caja, "Error al tratar de sincronizar:" + e.Message);
                                       estado = false;
                                       string a = "";
                                         
                                   }
                               }
                               sincronizacion.setTextoCotrol(this.sba_estado, (estado) ? "Ventas sincronizadas satisfactoriamente." : "Error al sincronizar ventas, se reintentará nuevamente.");
                               
                           }
                           else sincronizacion.setTextoCotrol(this.sba_estado, "Sincronización al día.");
                          
                       }   
                           
                       }
                       catch (Exception e)
                       {
                           sincronizacion.setTextoCotrol(this.sba_estado, "No se pudo verificar el estado de sincronización ");
                           Mail correo = new Mail();
                           correo.enviarCorreoError(0, "Error al sincronizar cajas:" + e.Message);
                       }
                       finally
                       {
                           ParametroTR.actualizarParametroEntero("sincronizarManual", 1);
                       }
                   }
               }));
           this.backgroundThread.IsBackground = true;
           backgroundThread.Start();
           
          
       }


       protected void verificarSincronizacion(int idCaja = -1)
       {
           this.backgroundThread = new Thread(
               new ThreadStart(() =>
               {
                   string mensaje = "";

                   int valor = (idCaja == -1) ? ParametroTR.consultarIntXNombre("sincronizarOculta") : 1;
                   string mensajeOmitir = (idCaja == -1) ? ParametroTR.ConsultarStringXNombre(ref mensaje, "mensajeOmitir") : "";
                   bool sincronizarGuias = ParametroTR.ConsultarBool("guiaRemision");
                   if (valor == 1)
                   {
                       Sincronizacion sincronizacion = new Sincronizacion();
                       try
                       {
                           
                          
                               ParametroTR.actualizarParametroEntero("sincronizarManual", 0);
                               sincronizacion.setTextoCotrol(this.sba_estado, "Verificado sus cajas pendientes...");
                               List<int> cajas = null;
                               if (idCaja == -1) cajas = sincronizacion.cajasPendientes();
                               else
                               {
                                   cajas = new List<int>();
                                   cajas.Add(idCaja);
                               }
                               bool estado = true;
                               if (cajas != null)
                               {
                                   foreach (int caja in cajas)
                                   {
                                       try
                                       {
                                           bool resultado = sincronizacion.sincronizarPartes(caja, this.sba_estado, mensajeOmitir);
                                           bool resultadoGuias = true;
                                           if (sincronizarGuias)
                                           {
                                               resultadoGuias = sincronizacion.sincronizarPartesGuias(caja, this.sba_estado, mensajeOmitir);
                                           }
                                           estado = estado && resultado && resultadoGuias;
                                       }
                                       catch (Exception e)
                                       {
                                           Mail correo = new Mail();
                                           correo.enviarCorreoError(caja, "Error al tratar de sincronizar:" + e.Message);
                                           estado = false;
                                           string a = "";

                                       }
                                   }
                                   sincronizacion.setTextoCotrol(this.sba_estado, (estado) ? "Ventas sincronizadas satisfactoriamente." : "Error al sincronizar ventas, favor comuniquelo a soporte@contifico.com .");

                               }
                               else sincronizacion.setTextoCotrol(this.sba_estado, "Sincronización al día.");
           

                       }
                       catch (Exception e)
                       {
                           sincronizacion.setTextoCotrol(this.sba_estado, "No se pudo verificar el estado de sincronización ");
                           Mail correo = new Mail();
                           correo.enviarCorreoError(0, "Error al sincronizar cajas:" + e.Message);
                       }
                       finally
                       {
                           ParametroTR.actualizarParametroEntero("sincronizarManual", 1);
                       }
                   }
               }));
           this.backgroundThread.IsBackground = true;
           backgroundThread.Start();


       }

       protected void abrirSocket()
       {
           this.backgroundSocket = new Thread(
               new ThreadStart(() =>
               {
                   try
                   {
                       int idCaja = 0;
                       do
                       {
                           byte[] ByRec;
                           Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                           IPEndPoint direccion = new IPEndPoint(IPAddress.Any, 3236);
                           socket.Bind(direccion);
                           socket.Listen(1);
                           Socket Escuchar = socket.Accept();
                           ByRec = new byte[1024];
                           int a = Escuchar.Receive(ByRec, 0, ByRec.Length, 0);
                           Array.Resize(ref ByRec, a);
                           idCaja = Convert.ToInt32(Encoding.Default.GetString(ByRec));
                           this.verificarSincronizacion(idCaja);
                           socket.Close();
                       } while (idCaja != -1);
                   }
                   catch (Exception){}
               }));
           this.backgroundSocket.IsBackground = true;
           backgroundSocket.Start();
       }

       private void procesarMenu(int idPadre, ToolStripMenuItem padre, List<ItemMenu> lista)
       {
           if (lista == null) return;
           List<ItemMenu> hijos = lista.FindAll(element => element.idPadre == idPadre);
           if (hijos == null) return;
           foreach (ItemMenu hijo in hijos)
           {
               ToolStripMenuItem nodoHijo = new ToolStripMenuItem();
               nodoHijo.Name = "n" + hijo.id;
               nodoHijo.Text = hijo.nombreItem;
               if (padre != null) padre.DropDownItems.Add(nodoHijo);
               else this.menu_principal.Items.Add(nodoHijo);
               this.procesarMenu(hijo.id, nodoHijo, lista);
               nodoHijo.Click += elemento_Click;
               lista.Remove(hijo);
           }
       }

       private void elemento_Click(object sender, EventArgs e)
       {
          


           this.abrirFormulario(Convert.ToInt32(((ToolStripMenuItem)sender).Name.Substring(1)));

          
       }

       protected void abrirFormulario(int indice)
       {
           Form formulario = null;
           switch (indice)
           {
               case 11: formulario = new frm_empleado();
                   break;
               case 12: formulario = new frm_empleadoListado();
                   break;
               case 13: formulario = new frm_usuario();
                   break;
               case 14: formulario = new frm_editarUsuario();
                   break;
               case 15: formulario = new frm_Cliente();
                   break;
               case 16: formulario = new frm_clienteListado();
                   break;
               case 17: formulario = new frm_autorizacion();

                   if (verificarCambioAutorizacion() == true)

                       formulario = null;                  
                   
                   break;
               case 18: formulario = new frm_autorizacionListado();
                        if (verificarCambioAutorizacion() == true)

                       formulario = null;   

                   break;
               case 19: formulario = new frm_establecimiento();
                   break;
               case 20: formulario = new frm_establecimientoListado();
                   break;
               case 21: formulario = new frm_configuracionPos();

                          if (verificarCambioConfiguracion() == true)

                            formulario = null;
                   break;
               case 22: formulario = new frm_editarPos();

                           if (verificarCambioConfiguracion2() == true)

                             formulario = null;
                   break;
               case 23: formulario = new frm_sincronizarPersonas();
                   break;
               case 24: formulario = new frm_sincronizarProducto();
                   break;
               case 25: formulario = new frm_sincronizarVentas();
                   break;
               case 26: formulario = new frm_apariencia();
                   break;
               case 27: formulario = new frm_permisos();;
                   break;
               case 35: formulario = new frm_reporteProducto();
                   break;
               case 36: formulario = new frm_reporteVentas();
                   break;
               case 28: formulario = new frm_adicional();
                   break;
               case 31: formulario = new frm_promocion();
                   break;
               case 32: formulario = new frm__buscarPromocion();
                   break;
               case 37: formulario = new frm_promocionCombo();
                   break;
               case 38: formulario = new frm_parametro();
                   break;
               case 39: formulario = new frm_reporteSaldos();
                   break;
               case 41: formulario = new frm_ubicacion();
                   break;
               case 42: formulario = new frm_ubicacionProducto();
                   break;
               case 43: formulario = new frm_guiaRemision();
                   break;
           }
           if (formulario != null) formulario.ShowDialog(this);
       }

        private void frm_menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(this.backgroundActivity!=null)this.backgroundActivity.Join();
            frm_login.User = new Usuario();
            Application.Exit();
        }            


        private void crearToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            frm_usuario user = new frm_usuario();
            user.ShowDialog();
        }

        private void btn_caja_Click(object sender, EventArgs e)
        {
            int idConf=-1;
            if ((idConf = ConfiguracionPosTR.idConfPredeterminada()) == -1)
            {
                Mensaje.advertencia("Debe configurar el Punto de venta para abrir caja.");
            }
            else
            {
                frm_abrir_cerrar aperturar = new frm_abrir_cerrar(idConf,"abrir");
                aperturar.ShowDialog(this);
            }
        }


        private void btn_factura_Click(object sender, EventArgs e)
        {
            string msn = "";
            if (this.frmFactura == null)
            {
                if (this.comprobarImpresora())
                {
                    this.frmFactura = new frm_factura();
                    int estado = ParametroTR.consultarIntXNombre("formularioFacturaEstado");
                    int pendientes = ParametroTR.consultarIntXNombre("mostrarPendientes");
                    winEstadoFactura = (estado == 1) ? FormWindowState.Maximized : FormWindowState.Normal;
                    this.frmFactura.WindowState = winEstadoFactura;
                    if (pendientes == 1) this.frmFactura.mostrarPendientes();
                    this.frmFactura.ShowDialog(this);
                }
            }
            else
            {
                this.frmFactura.WindowState = FormWindowState.Normal;
            }
        }

        public void limpiarFactura()
        {
            this.frmFactura = null;
        }

        protected bool comprobarImpresora()
        {
          
            if (Impresion.IsPrinterOnline(Global.nombreImpresora)) return true;
            int opcion = Mensaje.tresbotones("La impresora no se encuentra disponible.");
            if (opcion == 1)//anular
            {
                return false;
            }
            else if (opcion == 2)//reintentar
            {
                return this.comprobarImpresora();
            }
            else//omitir
            {
                return true;
            }
            
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void btn_cerrar_Click_1(object sender, EventArgs e)
        {
            string msn = "";
            int idConf = -1;
            if ((idConf = ConfiguracionPosTR.idConfPredeterminada()) == -1)
            {
                if (String.IsNullOrEmpty(msn)) Mensaje.advertencia("No ha configurado un punto de venta.");
                else Mensaje.error(msn);
            }
            else
            {
                CajaTR tranCaja = new CajaTR();
                if (tranCaja.existeCajaActiva(idConf, ref msn))
                {
                    frm_abrir_cerrar aperturar = new frm_abrir_cerrar(idConf, "cerrar");
                    aperturar.ShowDialog();
                }
                else {
                    if (String.IsNullOrEmpty(msn)) Mensaje.advertencia("No ha abierto caja.");
                    else Mensaje.error(msn);
                }
            }
        }

        private void tsm_editar_Click(object sender, EventArgs e)
        {
            frm_permisoMenu permisos = new frm_permisoMenu();
            permisos.ShowDialog();
        }

        private void sincronizarProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_sincronizarProducto productos = new frm_sincronizarProducto();
            productos.ShowDialog(this);
        }

        private void sincronizarPersonasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_sincronizarPersonas personas = new frm_sincronizarPersonas();
            personas.ShowDialog(this);
        }

        private void frm_menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void sba_estado_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btn_guia_Click_1(object sender, EventArgs e)
        {
            frm_guiaRemision guia = new frm_guiaRemision();
            guia.ShowDialog();
        }


        private bool verificarCambioAutorizacion()
        {
          
         int id_conf = ConfiguracionPosTR.idConfPredeterminada();
         String tipo = "A";
         if( CajaTR.verEstadoCaja(id_conf, tipo) != null)
             {
                 Mensaje.advertencia("Una caja está abierta, favor cierre caja para ingresar/editar una nueva autorización.");
                 return true;                
             }
                 return false;
         
        }


        private bool verificarCambioConfiguracion()
        {

            int id_conf = ConfiguracionPosTR.idConfPredeterminada();
            String tipo2 = "A";
            if (CajaTR.verEstadoCaja(id_conf, tipo2) != null)
            {
                Mensaje.advertencia("Una caja está abierta, favor cierre caja para ingresar una nueva Configuración POS.");
                return true;
            }
            return false;

        }

        private bool verificarCambioConfiguracion2()
        {

            int id_conf = ConfiguracionPosTR.idConfPredeterminada();
            String tipo3 = "A";
            if (CajaTR.verEstadoCaja(id_conf, tipo3) != null)
            {
                Mensaje.advertencia("Una caja está abierta, favor cierre caja para editar una nueva Configuración POS.");
                return true;
            }
            return false;

        }

    }
}