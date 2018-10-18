using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pos.Clases;
using Pos.Coneccion;

namespace Pos.App
{
    public partial class frm_loginPermiso : Form
    {
        public Usuario user = null;
        public frm_loginPermiso()
        {
            InitializeComponent();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_entrar_Click(object sender, EventArgs e)
        {
            validarUsuario();
        }

        public bool validarIngreso()
        {
            if (String.IsNullOrEmpty(this.txt_usuario.Text))
            {
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

        protected void validarUsuario()
        {
            try
            {
                if (validarIngreso())
                {
                    Usuario usuario = UsuarioTR.consultarUsuario(this.txt_usuario.Text.Trim(), General.encriptar(this.txt_password.Text));
                    if (usuario != null)
                    {
                        if (usuario.Id_Rol == 1)
                        {
                            this.user = usuario;
                            if (this.chk_recordar.Checked) Global.idUsuarioAnular = usuario.Idtbl_usuario;
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            Mensaje.advertencia("No tiene permisos para realizar esta acción");
                        }
                    }
                    else Mensaje.advertencia("No se encontro el usuario.");
                }
            }
            catch (Exception e)
            {
                Mensaje.error(e.Message);
            }
        }

        private void frm_loginPermiso_Load(object sender, EventArgs e)
        {

        }

        private void txt_usuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                validarUsuario();
            }
        }
    }
}
