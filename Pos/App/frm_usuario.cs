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
    public partial class frm_usuario : Form
    {
        private int idUsuario;
        private int idEmpleado;
        private bool estadoGuardar = true;
        public DataGridViewRow fila;

        public frm_usuario()
        {
            InitializeComponent();
        }

        public frm_usuario(int idUsuario, DataGridViewRow fila)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.fila = fila;
            this.estadoGuardar = false;
            this.btn_buscar.Visible = false;
            this.btn_agregarEmpleado.Visible = false;
            this.txt_cedula.Enabled = false;
            //this.activarEstadoActualizar();
        }

        public void setEmpleado(int idEmpleado, string nombre, string cedula)
        {
            this.idEmpleado = idEmpleado;
            this.txt_cedula.Text = cedula;
            //this.txt_nombre.Text = nombre;
            this.buscarUsuarioXCedula(cedula);
            this.txt_usuario.Focus();
        }

        public void setCedula(string cedula)
        {
            this.txt_cedula.Text = cedula;
            this.buscarUsuarioXCedula(cedula);
        }

        private void frm_usuario_Load(object sender, EventArgs e)
        {
            this.llenarComboEstado();
            this.llenarComboRoles();
            if (!estadoGuardar) buscarUsuarioXId(this.idUsuario);
        }

        protected void llenarComboRoles()
        {
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("1", "Administrador"));
            data.Add(new KeyValuePair<string, string>("2", "Cajero"));
            cmb_rol.DataSource = new BindingSource(data, null);
            cmb_rol.DisplayMember = "Value";
            cmb_rol.ValueMember = "Key";
            this.cmb_rol.SelectedIndex = -1;
        }

        protected void llenarComboEstado()
        {
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("1", "Activo"));
            data.Add(new KeyValuePair<string, string>("0", "Inactivo"));
            cmb_estado.DataSource = new BindingSource(data, null);
            cmb_estado.DisplayMember = "Value";
            cmb_estado.ValueMember = "Key";
            this.cmb_estado.SelectedIndex = 0;
            
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!validar()) return;
            Usuario usuario = new Usuario();

            usuario.Idtbl_usuario = this.idUsuario;
            usuario.Id_Empleado = this.idEmpleado;
            usuario.User = txt_usuario.Text;
            usuario.Password = General.encriptar(txt_password.Text);
            usuario.Id_Rol = int.Parse(cmb_rol.SelectedValue.ToString());
            usuario.Estado = (cmb_estado.SelectedValue.ToString() == "1") ? true : false;
            UsuarioTR tran = new UsuarioTR(usuario);
            string msn = "";
            if (estadoGuardar && tran.insertarUsuario(ref msn)) //guardar
            {
                Mensaje.informacion("Usuario ingresado con éxito.");
                this.limpiar();
                txt_cedula.Focus();
            }
            else if (!estadoGuardar && tran.actualizarUsuario(ref msn))
            {
                Mensaje.informacion("Usuario actualizado con éxito.");
                if (this.fila != null) pasarDatos();
                this.limpiar();
                txt_cedula.Focus();
            }
            else Mensaje.advertencia(msn);    
        }

        protected void pasarDatos()
        {
            this.fila.Cells["Empleado"].Value = this.txt_nombre.Text;
            this.fila.Cells["User"].Value = this.txt_usuario.Text;
            this.fila.Cells["Rol"].Value = this.cmb_rol.Text;
            this.fila.Cells["Estado"].Value = this.cmb_estado.Text;
            this.Close();
        }

        protected Boolean validar()
        {
            if (this.txt_cedula.Text.Trim().Length < 1)
            {
                Mensaje.faltaCampo("Debe seleccionar un empleado.");
                txt_cedula.Focus();
                return false;
            }
            if (this.txt_nombre.Text.Trim().Length < 1)
            {
                Mensaje.faltaCampo("Debe seleccionar un empleado.");
                txt_nombre.Focus();
                return false;
            }
            if (this.txt_usuario.Text.Trim().Length < 1)
            {
                Mensaje.faltaCampo("Debe ingresar el campo usuario.");
                txt_usuario.Focus();
                return false;
            }
            if (this.txt_password.Text.Trim().Length < 1)
            {
                Mensaje.faltaCampo("Debe ingresar el campo password.");
                txt_password.Focus();
                return false;
            }
            if (this.cmb_rol.SelectedIndex == -1)
            {
                Mensaje.faltaCampo("Debe seleccionar el rol");
                cmb_rol.Focus();
                return false;
            }
            if (this.cmb_estado.Text.Trim().Length < 1)
            {
                Mensaje.faltaCampo("Debe ingresar seleccionar un estado.");
                cmb_estado.Focus();
                return false;
            }
            return true;
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }

        protected void limpiar()
        {
            if (fila == null) this.txt_cedula.Clear();
            if (fila == null) this.txt_nombre.Clear();
            this.txt_usuario.Clear();
            this.txt_password.Clear();
            this.cmb_rol.SelectedIndex = -1;
            this.cmb_estado.SelectedIndex = -1;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            frm_buscar_empleado frmUsuario = new frm_buscar_empleado();
            DialogResult dr = frmUsuario.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                this.setEmpleado(frmUsuario.idEmpleado, frmUsuario.nombre, frmUsuario.cedula);
            }
        }

        private void btn_crear_Click(object sender, EventArgs e)
        {
            frm_empleado empleado = new frm_empleado();
            empleado.Owner = this;
            empleado.ShowDialog();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_cedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.txt_cedula.Text.Trim().Length < 1)
                {
                    Mensaje.advertencia("Debe ingresar el campo cédula");
                    return;
                }
                this.buscarUsuarioXCedula(txt_cedula.Text);
               /// this.buscarEmpleado(txt_cedula.Text);
            }
            General.soloNumeros(e);
        }

        protected void buscarUsuarioXCedula(string cedula)
        {
            String mensaje = "";
            UsuarioTR tran = new UsuarioTR();
            Usuario usuario = tran.buscarXCedula(cedula, ref mensaje);
            if (usuario != null)
            {
                llenarDatos(usuario);
                this.activarEstadoActualizar();
            }
            else
            {
                if (String.IsNullOrEmpty(mensaje)) this.buscarEmpleado(cedula);
                else Mensaje.error(mensaje);
            } 
        }

        protected void buscarUsuarioXId(int idUsuario)
        {
            String mensaje = "";
            UsuarioTR tran = new UsuarioTR();
            Usuario usuario = tran.buscarXId(idUsuario, ref mensaje);
            if (usuario != null)
            {
                this.txt_cedula.Text = usuario.Cedula_Empleado;
                llenarDatos(usuario);  
                this.activarEstadoActualizar();
            }
            else
            {
                if (String.IsNullOrEmpty(mensaje))Mensaje.advertencia("No se encontró el usuario");
                else Mensaje.error(mensaje);
            }
        }

        protected void llenarDatos(Usuario usuario)
        {
            this.idEmpleado = usuario.Id_Empleado;
            this.idUsuario = usuario.Idtbl_usuario;
            this.txt_nombre.Text = usuario.Nombre_Empleado;
            this.txt_usuario.Text = usuario.User;
            this.txt_password.Text = General.desencriptar(usuario.Password);
            this.cmb_rol.SelectedValue = usuario.Id_Rol.ToString();
            this.cmb_estado.SelectedIndex = (usuario.Estado) ? 0 : 1;
        }

        protected void activarEstadoActualizar()
        {
            this.btn_guardar.Text = "Actualizar";
            this.estadoGuardar = false;
        }

        protected void buscarEmpleado(string cedula)
        {
            try
            {
                Persona persona = EmpleadoTR.buscarXCedula(cedula);
                if (persona != null)
                {
                    this.txt_nombre.Text = persona.razon_social;
                    this.idEmpleado = persona.id;
                }
                else
                {
                    Mensaje.advertencia("No se encontró el empleado.");
                }
            }
            catch (Exception e)
            {
                Mensaje.error(e.Message);
            }
        }

        private void txt_cedula_TextChanged(object sender, EventArgs e)
        {
            if (estadoGuardar == false) activarEstadoGuardar();
        }

        protected void activarEstadoGuardar()
        {
            this.btn_guardar.Text = "Guardar";
            this.estadoGuardar = true;
            this.txt_nombre.Clear();
            this.txt_usuario.Clear();
            this.txt_password.Clear();
            this.cmb_rol.SelectedIndex = -1;
            this.cmb_estado.SelectedIndex = -1;
        }

    }
}
