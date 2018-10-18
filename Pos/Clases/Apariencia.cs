using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using Pos.Properties;
using Pos.App;

namespace Pos.Clases
{
    class Apariencia
    {

        public static void colorDeMenu(MenuStrip menu)
        {
            Settings config = new Settings();
            int cMenu = obtenerValor("menuPrincipal");
            int cSub = obtenerValor("submenu");
            int cSub1 = obtenerValor("submenu1");
            int cTextoMenu = obtenerValor("textoMenu");
            int cTextoSub = obtenerValor("textoSub");
            int cTextoSub1 = obtenerValor("textoSub1");

            menu.BackColor = Color.FromArgb(cMenu);
            menu.ForeColor = Color.FromArgb(cTextoMenu);
            foreach(ToolStripMenuItem item in menu.Items)
            {
                item.ForeColor = Color.FromArgb(cTextoMenu);
                if (item.HasDropDownItems)
                {
                    foreach (ToolStripMenuItem sub in item.DropDownItems)
                    {
                        sub.BackColor = Color.FromArgb(cSub);
                        sub.ForeColor = Color.FromArgb(cTextoSub);
                        if (sub.HasDropDownItems)
                        {
                            foreach (ToolStripMenuItem sub1 in sub.DropDownItems)
                            {
                                sub1.BackColor = Color.FromArgb(cSub1);
                                sub1.ForeColor = Color.FromArgb(cTextoSub1);
                            }
                        }
                    }
                }

            }
        }

        public static void colorBotones(List<Button> botones)
        {
            int cTextoBoton = obtenerValor("textoBoton");
            foreach (Button boton in botones)
            {
                boton.ForeColor = Color.FromArgb(cTextoBoton);
            }
        }

        public static string rutaDatos()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Contifico";
        }

        public static string rutaImagen()
        {
            string archivo = System.IO.Path.Combine(rutaDatos(), "custom_background.jpg");
            if (!System.IO.File.Exists(archivo)) archivo = "";
            return archivo;
        }

        public static void imagenFormulario(Form formulario)
        {
            if (!Apariencia.obtenerValorBool("usarFondo")) formulario.BackgroundImage = Resources.logo;
            else
            {
                string archivo = rutaImagen();
                if (!String.IsNullOrEmpty(archivo))
                {
                    Image diskImage = Image.FromFile(archivo);
                    Image memoryImage = new Bitmap(diskImage);
                    formulario.BackgroundImage = memoryImage;
                    diskImage.Dispose(); // Releases the lock
                    //memoryImage.Dispose();
                }
            }
            estiloFondo(formulario);
        }

        public static void estiloFondo(Form formulario)
        {
            switch (obtenerValor("estiloFondo"))
            {
                case 0: formulario.BackgroundImageLayout = ImageLayout.Center;
                    break;
                case 1: formulario.BackgroundImageLayout = ImageLayout.Tile;
                    break;
                case 2: formulario.BackgroundImageLayout = ImageLayout.Zoom;
                    break;
                case 3: formulario.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
            }
        }

        public static void colorFormulario(Control.ControlCollection controles)
        {
            int cTextoLabel = obtenerValor("textoLeyenda");
            int cTextoBoton = obtenerValor("textoBoton");

            foreach (Control control in controles)
            {
                if (control is Label)
                {
                    Label leyenda = (Label)control;
                    leyenda.ForeColor = Color.FromArgb(cTextoLabel);
                }
                else if (control is Button)
                {
                    Button boton = (Button)control;
                    boton.ForeColor = Color.FromArgb(cTextoBoton);
                }
                else if (control is GroupBox)
                {
                    colorFormulario(((GroupBox)control).Controls);
                }
            }
        }


        public static int obtenerValor(string parametro)
        {
            return Convert.ToInt32(Settings.Default[parametro]);
        }

        public static int obtenerValor(string parametro,Settings config)
        {
            return Convert.ToInt32(config[parametro]);
        }

        public static bool obtenerValorBool(string parametro)
        {
            return Convert.ToBoolean(Settings.Default[parametro]);
        }

        public static void setearValor(string parametro, int valor)
        {
            Settings.Default[parametro] = valor;
            Settings.Default.Save();
        }

        public static void setearValorBool(string parametro, bool valor)
        {
            Settings.Default[parametro] = valor;
            Settings.Default.Save();
        }
    }
}
