using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pos.Coneccion;
using MySql.Data.MySqlClient;
using Pos.Clases;

namespace Pos.App
{
    public partial class frm_editarUsuario : Form
    {
         
        public frm_editarUsuario()
        {
            InitializeComponent();
 
        }

        private void frm_editarUsuario_Load(object sender, EventArgs e)
        {
            this.llenarGrid("",-1);
        }

        private void grw_empleado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)this.editar(e);
        }

        protected void llenarGrid(string nombre, int idRol)
        {
            this.grw_usuarios.DataBindings.Clear();
            grw_usuarios.Columns.Clear();
            string mensaje = "";
            UsuarioTR tran = new UsuarioTR();
            DataTable datos = tran.consultarUsuarios(ref mensaje, nombre, idRol);
            if (datos != null)
            {
                this.grw_usuarios.DataSource = datos;
                this.grw_usuarios.Columns["id"].Visible = false;
                int ancho = this.grw_usuarios.Width - 40;
                this.grw_usuarios.Columns["Cédula"].Width = Convert.ToInt16(ancho * 0.20);
                this.grw_usuarios.Columns["Empleado"].Width = Convert.ToInt16(ancho * 0.15);
                this.grw_usuarios.Columns["User"].Width = Convert.ToInt16(ancho * 0.25);
                this.grw_usuarios.Columns["Rol"].Width = Convert.ToInt16(ancho * 0.25);
                this.grw_usuarios.Columns["Estado"].Width = Convert.ToInt16(ancho * 0.14);

                DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
                bcol.Width = 20;
                bcol.HeaderText = "";
                bcol.Name = "botonEditar";
                bcol.UseColumnTextForButtonValue = true;
                this.grw_usuarios.Columns.Add(bcol);

                DataGridViewButtonColumn bcol1 = new DataGridViewButtonColumn();
                bcol1.Width = 20;
                bcol1.HeaderText = "";
                bcol1.Name = "botonEliminar";
                bcol1.UseColumnTextForButtonValue = true;
                this.grw_usuarios.Columns.Add(bcol1);
            }
            else Mensaje.error(mensaje);

        }

        public void limpiarDataGrid()
        {
            this.grw_usuarios.DataBindings.Clear();
            grw_usuarios.Columns.Clear();  
        }

        private void grw_empleado_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
 
        }




        protected void editar(DataGridViewCellEventArgs e)
        {
            int codigo = (int)this.grw_usuarios.Rows[e.RowIndex].Cells[0].Value;
            frm_usuario ventanaUser = new frm_usuario(codigo, grw_usuarios.Rows[e.RowIndex]);
            ventanaUser.ShowDialog();
        }

        protected void eliminar(DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("¿Desea Eliminar el Usuario?", "Mensaje del Sistema", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int idUsuario = (int)this.grw_usuarios.Rows[e.RowIndex].Cells[0].Value;
                UsuarioTR tran = new UsuarioTR();
                string mensaje = "";
                if (tran.eliminarUsuario(idUsuario, ref mensaje)) this.grw_usuarios.Rows.RemoveAt(e.RowIndex);
                else MessageBox.Show(mensaje);
            }
        }

  

        private void grw_usuarios_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (this.grw_usuarios.Columns[e.ColumnIndex].Name == "botonEditar")
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    Bitmap bmp = Pos.Properties.Resources.editar_fila;
                    DataGridViewButtonCell celBoton = this.grw_usuarios.Rows[e.RowIndex].Cells["botonEditar"] as DataGridViewButtonCell;

                    Icon icoAtomico = Icon.FromHandle(bmp.GetHicon());
                    e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                    // this.grw_empleado.AutoResizeRow(e.RowIndex);
                    //this.grw_empleado.Rows[e.RowIndex].Height = 20;
                    this.grw_usuarios.Columns[e.ColumnIndex].Width = 20;
                    e.Handled = true;
                }

                if (this.grw_usuarios.Columns[e.ColumnIndex].Name == "botonEliminar")
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    Bitmap bmp = Pos.Properties.Resources.borrar_fila;
                    DataGridViewButtonCell celBoton = this.grw_usuarios.Rows[e.RowIndex].Cells["botonEliminar"] as DataGridViewButtonCell;

                    Icon icoAtomico = Icon.FromHandle(bmp.GetHicon());
                    e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 2, e.CellBounds.Top + 3);

                    // this.grw_empleado.AutoResizeRow(e.RowIndex);
                    //this.grw_empleado.Rows[e.RowIndex].Height = 20;
                    this.grw_usuarios.Columns[e.ColumnIndex].Width = 21;
                    e.Handled = true;
                }

            }
        }

        private void txt_nombre_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void grw_usuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0 && this.grw_usuarios.Columns[e.ColumnIndex].Name == "botonEditar") this.editar(e);
            else if (e.ColumnIndex > 0 && this.grw_usuarios.Columns[e.ColumnIndex].Name == "botonEliminar") this.eliminar(e);
        }

        private void grw_usuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) this.editar(e);
        }

 
    }
}
