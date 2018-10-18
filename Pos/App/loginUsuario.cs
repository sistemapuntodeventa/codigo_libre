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

namespace Pos.App
{
    public partial class frm_login : Form
    {
        static Usuario user;
        static Empresa empresa;          
        
        public frm_login()
        {
            InitializeComponent();
            user = new Usuario();
            empresa = new Empresa();
        }

        internal static Usuario User
        {
            get { return frm_login.user; }
            set { frm_login.user = value; }
        }

        public static Empresa Empresa
        {
            get { return frm_login.empresa; }
            set { frm_login.empresa = value; }
        }    

        private void btn_entrar_Click(object sender, EventArgs e)
        {
            entrar();
        }

        protected void entrar() {

            if (validarIngreso())
            {
                string msn = "";
                UsuarioTR tran = new UsuarioTR();
                if (tran.esUsuarioValido(ref msn, this.txt_usuario.Text.Trim(), General.encriptar(this.txt_password.Text)))
                {
                    frm_menu menu = new frm_menu();
                    menu.Show();
                    this.Hide();
                }
                else if (String.IsNullOrEmpty(msn)) Mensaje.error("No se encontro el usuario.");
                else Mensaje.error(msn);
            }
        }

        public bool validarIngreso()
        {
            if (String.IsNullOrEmpty(this.txt_usuario.Text)){
                Mensaje.advertencia("Ingrese el Usuario");
                this.txt_usuario.Select();
                return false;
            }
            if (String.IsNullOrEmpty(this.txt_password.Text))
            {
                Mensaje.advertencia("Ingrese el Password");
                this.txt_password.Select();
                return false;
            } 
            return true;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frm_login_Load(object sender, EventArgs e)
        {
            //Mensaje.advertencia(General.encriptar("admin"));
            EmpresaTR tran = new EmpresaTR();
            string msn = "";
            int idEmpresa = tran.obtenerIdEmpresa(ref msn);
            if (String.IsNullOrEmpty(msn))
            {
                if (idEmpresa != -1) Global.idEmpresa = idEmpresa;
                else {
                    frm_empresa empresa = new frm_empresa();
                    empresa.ShowDialog();
                }
            }
            else Mensaje.error(msn);
        }

        private void txt_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                entrar();
            }
        }      
        
    }
}
