using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pos.Clases;
using Pos.Properties;

namespace Pos.App
{
    public partial class frm_apariencia : Form
    {
        private int MenuPrincipal, subMenu, subMenu1, tituloGrupos, textoBoton, textoMenu, textoSub, textoSub1, textoLeyenda, textoListado;
        private string rutaImagen;
        private bool cambioImagen;
        private bool usarDefecto;

        public frm_apariencia()
        {
            InitializeComponent();
            this.MenuPrincipal = Apariencia.obtenerValor("menuPrincipal");
            this.textoMenu = Apariencia.obtenerValor("textoMenu");
            this.subMenu = Apariencia.obtenerValor("submenu");
            this.textoSub = Apariencia.obtenerValor("textoSub");
            this.subMenu1 = Apariencia.obtenerValor("submenu1");
            this.textoSub1 = Apariencia.obtenerValor("textoSub1");
            this.textoLeyenda = Apariencia.obtenerValor("textoLeyenda");
            this.textoBoton = Apariencia.obtenerValor("textoBoton");
            estadoInicial();
        }

        protected void estadoInicial()
        {
            this.btn_menuPrincipal.BackColor = Color.FromArgb(this.MenuPrincipal);
            this.btn_textoMenu.BackColor = Color.FromArgb(this.textoMenu);
            this.btn_submenu.BackColor = Color.FromArgb(this.subMenu);
            this.btn_textoSub.BackColor = Color.FromArgb(this.textoSub);
            this.btn_submenu1.BackColor = Color.FromArgb(this.subMenu1);
            this.btn_textoSub1.BackColor = Color.FromArgb(this.textoSub1);
            this.btn_textoLeyendas.BackColor = Color.FromArgb(this.textoLeyenda);
            this.btn_textoBoton.BackColor = Color.FromArgb(this.textoBoton);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            this.dlg_color.Color = boton.BackColor;
            //this.dlg_color.AllowFullOpen = true;
            if(this.dlg_color.ShowDialog()== DialogResult.OK)boton.BackColor = this.dlg_color.Color;
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
                this.dlg_imagen.Title = "Buscar Imagen";
                this.dlg_imagen.Filter = "Archivos JPG (*.jpg)|*.jpg";
                this.dlg_imagen.FileName = "";
                if (this.dlg_imagen.ShowDialog() == DialogResult.OK)
                {
                    PictureBox PictureBox1 = new PictureBox();
                    this.pib_imagen.BackgroundImage = new Bitmap(this.dlg_imagen.FileName);
                    this.cambioImagen = true;
                    this.rutaImagen = this.dlg_imagen.FileName;
                }
        }

        protected void setearImagen()
        {
            if (!Apariencia.obtenerValorBool("usarFondo")) this.pib_imagen.BackgroundImage = Resources.logo;
            else
            {
                string archivo = Apariencia.rutaImagen();
                if (!String.IsNullOrEmpty(archivo))
                {
                    Image diskImage = Image.FromFile(archivo);
                    Image memoryImage = new Bitmap(diskImage);
                    this.pib_imagen.BackgroundImage = memoryImage;
                    diskImage.Dispose();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cmb_posicionFondo.SelectedIndex)
            {
                case 0: this.pib_imagen.BackgroundImageLayout = ImageLayout.Center;
                        break;
                case 1: this.pib_imagen.BackgroundImageLayout = ImageLayout.Tile;
                        break;
                case 2: this.pib_imagen.BackgroundImageLayout = ImageLayout.Zoom;
                        break;
                case 3: this.pib_imagen.BackgroundImageLayout = ImageLayout.Stretch;
                        break;
            }
        }

        protected void estiloFondo()
        {
            switch (Apariencia.obtenerValor("estiloFondo"))
            {
                case 0: this.pib_imagen.BackgroundImageLayout = ImageLayout.Center;
                        this.cmb_posicionFondo.SelectedIndex = 0;
                        break;
                case 1: this.pib_imagen.BackgroundImageLayout = ImageLayout.Tile;
                        this.cmb_posicionFondo.SelectedIndex = 1;
                        break;
                case 2: this.pib_imagen.BackgroundImageLayout = ImageLayout.Zoom;
                        this.cmb_posicionFondo.SelectedIndex = 2;
                        break;
                case 3: this.pib_imagen.BackgroundImageLayout = ImageLayout.Stretch;
                        this.cmb_posicionFondo.SelectedIndex = 3;
                        break;
            }
        }

        private void frm_apariencia_Load(object sender, EventArgs e)
        {
            //if (Apariencia.obtenerValorBool("usarFondo"))
            //{
            //    this.button1.Visible = false;
            //    this.button2.Visible = false;
            //}
            this.setearImagen();
            this.estiloFondo();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            Apariencia.setearValor("menuPrincipal",this.btn_menuPrincipal.BackColor.ToArgb());
            Apariencia.setearValor("textoMenu", this.btn_textoMenu.BackColor.ToArgb());
            Apariencia.setearValor("submenu", this.btn_submenu.BackColor.ToArgb());
            Apariencia.setearValor("textoSub", this.btn_textoSub.BackColor.ToArgb());
            Apariencia.setearValor("submenu1", this.btn_submenu1.BackColor.ToArgb());
            Apariencia.setearValor("textoSub1", this.btn_textoSub1.BackColor.ToArgb());
            Apariencia.setearValor("textoLeyenda", this.btn_textoLeyendas.BackColor.ToArgb());
            Apariencia.setearValor("textoBoton", this.btn_textoBoton.BackColor.ToArgb());
            Apariencia.setearValor("estiloFondo", this.cmb_posicionFondo.SelectedIndex);

            if (this.usarDefecto)Apariencia.setearValorBool("usarFondo", false);
            else if (this.cambioImagen) this.guardarImagen();

            frm_menu menu = (frm_menu)this.Owner;
            menu.actualizarColor();
        }

        protected void guardarImagen()
        {
            frm_menu menu = (frm_menu)this.Owner;
            menu.BackgroundImage.Dispose();
            //menu.BackgroundImage = Resources.logo;
            menu.BackgroundImage = null;
            string fileName = "custom_background.jpg";
            string targetPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Contifico";
            if (!System.IO.Directory.Exists(targetPath)) System.IO.Directory.CreateDirectory(targetPath);
            string destFile = System.IO.Path.Combine(targetPath, fileName);

            System.IO.File.Copy(this.rutaImagen, destFile, true);
            Apariencia.setearValorBool("usarFondo", true);
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.pib_imagen.BackgroundImage = Resources.logo;
            this.cmb_posicionFondo.SelectedIndex = 0;
            this.usarDefecto = true;
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {

        }

        private void pib_imagen_Click(object sender, EventArgs e)
        {
            this.dlg_imagen.Title = "Buscar Imagen";
            this.dlg_imagen.Filter = "Archivos JPG (*.jpg)|*.jpg";
            this.dlg_imagen.FileName = "";
            if (this.dlg_imagen.ShowDialog() == DialogResult.OK)
            {
                PictureBox PictureBox1 = new PictureBox();
                this.pib_imagen.BackgroundImage = new Bitmap(this.dlg_imagen.FileName);
                this.cambioImagen = true;
                this.rutaImagen = this.dlg_imagen.FileName;
            }
        }


    }
}
