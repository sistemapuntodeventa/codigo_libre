using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pos.Clases
{
    class Mensaje
    {
        private static string titulo = "Mensaje del sistema";


        public static bool confirmacion(string pregunta)
        { 
            if(MessageBox.Show(pregunta,titulo, MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes) return true;
            return false;
        }
        public static void informacion(string Mensaje)
        {
            MessageBox.Show(Mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void advertencia(string Mensaje)
        {
            MessageBox.Show(Mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void faltaCampo(string Mensaje)
        {
            MessageBox.Show(Mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void error(string Mensaje)
        {
            MessageBox.Show(Mensaje,titulo,MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        public static int tresbotones(string Mensaje)
        {
            return ((int)MessageBox.Show(Mensaje,titulo, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)) -2;
            
        }

        public static void mostrarNotificacion(string titulo, string texto)
        {
            NotifyIcon iconoNotificacion = new NotifyIcon();
            iconoNotificacion.Visible = true;
            iconoNotificacion.Icon = System.Drawing.SystemIcons.Information;
            iconoNotificacion.BalloonTipTitle = titulo;
            iconoNotificacion.BalloonTipText = texto;
            iconoNotificacion.BalloonTipIcon = ToolTipIcon.Info;
            iconoNotificacion.ShowBalloonTip(8000);
        }
    }
}
