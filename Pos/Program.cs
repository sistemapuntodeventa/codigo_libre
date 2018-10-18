using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Pos.App;
using Pos.App.Reportes;
using System.Threading;
using System.Drawing;
using Pos.Clases;
using Pos.Coneccion;

namespace Pos
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            /*Global.cantidadDecimales = 2;
            Global.idEmpleado = 1;
            Global.idEmpresa = 150;
            Global.idRol = 1;
            Global.nombreImpresora = "";*/

            using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    Mensaje.advertencia("Actualmente existe un punto de venta abierto, no se puede poseer dos abiertos.");
                    return;
                }
                //Application.Run(new frm_configuracionPos());
                Application.Run(new frm_login());
                //Application.Run(new frm_guiaRemision());
            }

        }

        private static string appGuid = "c0a76b5a-12ab-45c5-b9d9-d693faa6e7b9";

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Program.enviarError("<strong>Error:</strong>:" + e.Exception.Message + "\n <strong>Stack:</strong>" + e.Exception.StackTrace);
            Mensaje.error(e.Exception.Message);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception error = (e.ExceptionObject as Exception);
            Program.enviarError("<strong>Error:</strong>:" + error.Message + "\n <strong>Stack:</strong>" + error.StackTrace);
            Mensaje.error(error.Message);
        }

       

        private static void enviarError(string mensaje)
        {

            Thread backgroundThread = new Thread(
                     new ThreadStart(() =>
                     {
                         try
                         {
                             string targetPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Contifico";
                             string fileName = "lastError.jpg";
                             if (!System.IO.Directory.Exists(targetPath)) System.IO.Directory.CreateDirectory(targetPath);
                             string destFile = System.IO.Path.Combine(targetPath, fileName);

                             Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                             Graphics graphics = Graphics.FromImage(printscreen as Image);
                             graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
                             printscreen.Save(destFile, System.Drawing.Imaging.ImageFormat.Jpeg);
                             Mail mail = new Mail();
                             string empresa = EmpresaTR.obtenerNombreEmpresa();
                             mail.enviarError("Error en " + empresa + " (" + Global.idEmpresa + ")", mensaje, destFile);
                         }catch(Exception){}
                     }));
            backgroundThread.Start();
        
        }
    }
}
