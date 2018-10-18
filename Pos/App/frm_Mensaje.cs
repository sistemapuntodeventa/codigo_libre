using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pos.App
{
    public partial class frm_Mensaje : Form
    {
        public frm_Mensaje()
        {
            InitializeComponent();
        }

        public frm_Mensaje(string pregunta, List<string> contenido)
        {
            InitializeComponent();
            this.lbl_pregunta.Text = pregunta;
            foreach (string texto in contenido) this.lsb_contenido.Items.Add(texto);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void frm_Mensaje_Load(object sender, EventArgs e)
        {
            this.imagen.BackgroundImage = SystemIcons.Question.ToBitmap();
        }
    }
}
