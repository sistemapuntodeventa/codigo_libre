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
    public partial class frm_permisoMenu : Form
    {
        List<Rol> roles = null;
        List<object[]> checkboxes = null;
        bool hizoCambio = false;

        public frm_permisoMenu()
        {
            InitializeComponent();
        }
        
        private void frm_permisoMenu_Load(object sender, EventArgs e)
        {

            //object menu = Activator.CreateInstance(null, "Pos.App.frm_menu");
            //((Form)menu).Show();
            this.trv_menu.AfterSelect -= trv_menu_AfterSelect;
            roles = new List<Rol>();
            roles.Add(new Rol() { Idrol_usuario = 1, Nombre = "Administrador", Estado = true });
            roles.Add(new Rol() { Idrol_usuario = 2, Nombre = "Cajero", Estado = true });
            checkboxes = new List<object[]>();
            int xInicial = 205;
            int yInicial = 38;
            foreach (Rol rol in this.roles)
            {
                CheckBox check = new CheckBox();
                check.Name = rol.Nombre;
                check.Text = rol.Nombre;
                check.CheckedChanged += check_CheckedChanged;
                check.Location = new Point(xInicial, yInicial);
                yInicial += 22;
                this.Controls.Add(check);
                object[] objeto = new object[2];
                objeto[0] = rol.Idrol_usuario;
                objeto[1] = check;
                this.checkboxes.Add(objeto);
            }


            List<ItemMenu> lista = MenuTR.consultarItems();
            this.procesarMenu(0, null, lista);
            this.trv_menu.AfterSelect += trv_menu_AfterSelect;
        }

        private void procesarMenu(int idPadre, TreeNode padre, List<ItemMenu> lista)
        {
            List<ItemMenu> hijos = lista.FindAll(element => element.idPadre == idPadre);
            if (hijos == null) return;
            foreach (ItemMenu hijo in hijos)
            { 
                TreeNode nodoHijo = new TreeNode();
                nodoHijo.Name = "n" + hijo.id;
                nodoHijo.Text = hijo.nombreItem;
                if (padre != null) padre.Nodes.Add(nodoHijo);
                else this.trv_menu.Nodes.Add(nodoHijo);
                this.procesarMenu(hijo.id, nodoHijo, lista);
                lista.Remove(hijo);
            }
        }

        private void trv_menu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.lbl_item.Text = this.trv_menu.SelectedNode.FullPath;
            this.limpiarCheck();
            List<int> roles = MenuTR.consultarPermisos(Convert.ToInt32(this.trv_menu.SelectedNode.Name.Substring(1)));
            if (roles != null)
            {
                foreach (int idRol in roles)
                {
                    Object[] objeto = this.checkboxes.Find(element => Convert.ToInt32(element[0]) == idRol);
                    CheckBox check = (CheckBox)objeto[1];
                    check.CheckedChanged -= check_CheckedChanged;
                    check.Checked = true;
                    check.CheckedChanged += check_CheckedChanged;
                }
            }
            this.hizoCambio = false;
        }

        protected void guardarEstado()
        {
            if (this.trv_menu.SelectedNode == null || !this.hizoCambio) return;
            List<int> seleccionados = new List<int>();
            foreach (object[] objeto in this.checkboxes)
            {
                CheckBox check = (CheckBox)objeto[1];
                if (check.Checked) seleccionados.Add(Convert.ToInt32(objeto[0]));
            }
            MenuTR.actualizar(Convert.ToInt32(this.trv_menu.SelectedNode.Name.Substring(1)), seleccionados);
        }

        protected void limpiarCheck()
        {
            foreach (object[] objeto in this.checkboxes) ((CheckBox)objeto[1]).Checked = false;
        }

        private void trv_menu_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            this.guardarEstado();
        }

        private void frm_permisoMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.guardarEstado();
        }

        private void check_CheckedChanged(object sender, EventArgs e)
        {
            this.hizoCambio = true;
        }
    }
}
