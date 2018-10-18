using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pos.Clases
{
    public class Usuario
    {
        private int idtbl_usuario;
        private string user;
        private string password;
        private int id_rol;
        private string nombre_rol;
        private int id_empleado;
        private string nombre_empleado;
        private string cedula_Empleado;
        private bool estado;

        public Usuario()
        {
            this.idtbl_usuario = 0;
            this.user = "";
            this.password = "";
            this.estado = true;
        }

        public int Idtbl_usuario
        {
            get { return idtbl_usuario; }
            set { idtbl_usuario = value; }
        }

        public int Id_Rol {
            get { return id_rol; }
            set { id_rol = value; }
        }

        public string Nombre_Rol
        {
            get { return nombre_rol; }
            set { nombre_rol = value; }
        }

        public int Id_Empleado
        {
            get { return id_empleado; }
            set { id_empleado = value; }
        }

        public string Nombre_Empleado
        {
            get { return nombre_empleado; }
            set { nombre_empleado = value; }
        }

        public string Cedula_Empleado
        {
            get { return cedula_Empleado; }
            set { cedula_Empleado = value; }
        }

        public string User
        {
            get { return user; }
            set { user = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }
    }
        
}
