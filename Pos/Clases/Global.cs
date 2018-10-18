using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pos.Clases
{
    static class Global
    {
        private static int _logIdUser = -1;
        private static int _idEmpleado = -1;
        private static int _idEmpresa = -1;
        private static int _idRol = -1;
        private static int _cantidadDecimales = -1;
        private static string _impresora = "";
        private static int? _idUsuarioAnular = null;
        private static string _api = null;
        private static bool _verificar = true;

        public static int logIdUser
        {
            get { return _logIdUser; }
            set { _logIdUser = value; }
        }

        public static int? idUsuarioAnular
        {
            get { return _idUsuarioAnular; }
            set { _idUsuarioAnular = value; }
        }

        public static int idEmpresa
        {
            get { return _idEmpresa; }
            set { _idEmpresa = value; }
        }

        public static int idEmpleado
        {
            get { return _idEmpleado; }
            set { _idEmpleado = value; }
        }
        public static int idRol
        {
            get { return _idRol; }
            set { _idRol = value; }
        }

        public static int cantidadDecimales
        {
            get { return _cantidadDecimales; }
            set { _cantidadDecimales = value; }
        }

        public static string nombreImpresora
        { 
            get { return _impresora;}
            set { _impresora = value; }
        }

        public static string api
        {
            get { return _api; }
            set { _api = value; }
        }

  

    }
}
