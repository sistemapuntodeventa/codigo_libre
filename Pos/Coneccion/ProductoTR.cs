using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pos.Clases;
using MySql.Data.MySqlClient;
using System.Data;
using System.Xml;
using System.Windows.Forms;

namespace Pos.Coneccion
{
    public class ProductoTR
    {

        private Conexion conf;
        private Producto producto;
        //private inventario_unidad unidad;

        public ProductoTR()
        {
            this.conf = new Conexion();
        }

        public ProductoTR(Producto producto)
        {
            this.conf = new Conexion();
            this.producto = producto;
        }


        public Conexion Conf
        {
            get { return conf; }
            set { conf = value; }
        }

        public Producto Producto
        {
            get { return producto; }
            set { producto = value; }
        }

        public bool sincronizarProductos(List<Unidad> unidades, List<Categoria> categorias, List<Producto> productos)
        {
            string lineaConexion = Conexion.lineaConexion;
            MySqlConnection conexion = null;
            MySqlTransaction tran = null;
            MySqlCommand cmd = null;
            bool estado = false;
            try
            {

                conexion = new MySqlConnection(lineaConexion);
                conexion.Open();
                tran = conexion.BeginTransaction();

                cmd = new MySqlCommand("unidad_insertar", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Transaction = tran;
                this.insertarUnidad(cmd, unidades);

                cmd.CommandText = "categoria_insertar";
                this.insertarCategoria(cmd, categorias);

                this.insertarProducto(cmd, productos);

                tran.Commit();
                conexion.Close();
                estado = true;
            }
            catch (Exception e)
            {
                tran.Rollback();
                throw e;
            }
            finally
            {
                conexion.Close();
                if (cmd != null) cmd.Dispose();
            }
            return estado;
        }

        public bool sincronizarProductos(ref string msn, XmlDocument xml, ProgressBar barra)
        {
            string lineaConexion = Conexion.lineaConexion;
            MySqlConnection conexion = null;
            MySqlTransaction tran = null;
            MySqlCommand cmd = null;
            bool estado = false;
            try
            {
                XmlNode raiz = xml.GetElementsByTagName("inventario")[0];
                XmlNodeList listaUnidades = raiz["unidades"].ChildNodes;
                XmlNodeList listaCategorias = raiz["categorias"].ChildNodes;
                XmlNodeList listaProductos = raiz["productos"].ChildNodes;
                int total = listaUnidades.Count + listaCategorias.Count + listaProductos.Count;
                int valorActual = 1;

                conexion = new MySqlConnection(lineaConexion);
                conexion.Open();
                tran = conexion.BeginTransaction();

                cmd = new MySqlCommand("unidad_insertar", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Transaction = tran;
                this.insertarUnidad(cmd, listaUnidades,total, ref valorActual,barra);

                cmd.CommandText = "categoria_insertar";
                this.insertarCategoria(cmd, listaCategorias, total, ref valorActual, barra);

                cmd.CommandText = "producto_inactivar";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "producto_insertar";
                this.insertarProducto(cmd, listaProductos, total, ref valorActual, barra);

                tran.Commit();
                conexion.Close();
                estado = true;
            }
            catch (Exception e)
            {
                tran.Rollback();
                msn = e.Message;
            }
            finally
            {
                conexion.Close();
                if (cmd != null) cmd.Dispose();
            }
            return estado;

        }

        public void insertarUnidad(MySqlCommand cmd, XmlNodeList listaUnidades,int total, ref int actual, ProgressBar barra)
        {
            foreach (XmlElement nodo in listaUnidades)
            {
                cmd.Parameters.AddWithValue("?Idi", Convert.ToInt32(nodo["id_contifico"].InnerText)).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?fecha_creacioni", Convert.ToDateTime(nodo["fecha_creacion"].InnerText)).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?ultimo_cambioi", Convert.ToDateTime(nodo["ultimo_cambio"].InnerText)).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?empresa_idi", Convert.ToInt32(nodo["empresa_id"].InnerText)).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?abreviaturai", nodo["abreviatura"].InnerText).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", nodo["nombre"].InnerText).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?unidadi", Convert.ToBoolean(nodo["uni"].InnerText)).Direction = ParameterDirection.Input;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                if (barra != null)
                {
                    barra.Value = (actual * 100) / total;
                    actual++;
                }
            }
        }

        public void insertarUnidad(MySqlCommand cmd, List<Unidad> unidades)
        {
            foreach (Unidad unidad in unidades)
            {
                cmd.Parameters.AddWithValue("?Idi", unidad.id).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?fecha_creacioni", null).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?ultimo_cambioi", null).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?empresa_idi", Global.idEmpresa).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?abreviaturai", unidad.abreviatura).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", unidad.nombre).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?unidadi", unidad.unidad).Direction = ParameterDirection.Input;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
        }

        public void insertarCategoria(MySqlCommand cmd, XmlNodeList listaCategorias, int total, ref int actual, ProgressBar barra)
        {

            foreach (XmlElement nodo in listaCategorias)
            {
                cmd.Parameters.AddWithValue("?idi", Convert.ToInt32(nodo["id_contifico"].InnerText));
                cmd.Parameters["?idi"].Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?fecha_creacioni", Convert.ToDateTime(nodo["fecha_creacion"].InnerText)).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?ultimo_cambioi", Convert.ToDateTime(nodo["ultimo_cambio"].InnerText)).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?empresa_idi", Convert.ToInt32(nodo["empresa_id"].InnerText)).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", nodo["nombre"].InnerText).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?padre_idi", (!General.esNodoVacio(nodo["padre_id"].InnerText)) ? Convert.ToInt32(nodo["padre_id"].InnerText) : 0).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?codigoi", nodo["codigo"].InnerText).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?tipoi", nodo["tipo"].InnerText).Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                if (barra != null)
                {
                    barra.Value = (actual * 100) / total;
                    actual++;
                }
            }
        }

        public void insertarCategoria(MySqlCommand cmd, List<Categoria> categorias)
        {

            foreach (Categoria categoria in categorias)
            {
                cmd.Parameters.AddWithValue("?idi", categoria.id);
                cmd.Parameters["?idi"].Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?fecha_creacioni", null).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?ultimo_cambioi", null).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?empresa_idi", Global.idEmpresa).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", categoria.nombre).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?padre_idi", categoria.padre_id).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?codigoi", categoria.codigo).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?tipoi", categoria.tipo).Direction = ParameterDirection.Input;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
        }

        public void insertarProducto(MySqlCommand cmd, XmlNodeList listaProductos, int total, ref int actual, ProgressBar barra)
        {
            foreach (XmlElement nodo in listaProductos)
            {
                cmd.Parameters.AddWithValue("?idi", Convert.ToInt32(nodo["id_contifico"].InnerText)).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?empresa_idi", Convert.ToInt32(nodo["empresa_id"].InnerText)).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?codigoi", nodo["codigo"].InnerText).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", (!General.esNodoVacio(nodo["nombre"].InnerText)) ? nodo["nombre"].InnerText : "").Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?descripcioni", nodo["descripcion"].InnerText).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?inventariablei", false).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?unidad_idi", Convert.ToInt32(nodo["unidad_id"].InnerText)).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?porcentaje_icei", (!General.esNodoVacio(nodo["porcentaje_ice"].InnerText)) ? Convert.ToDecimal(nodo["porcentaje_ice"].InnerText) : 0).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?porcentaje_ivai", General.enteroDesdeString(nodo["porcentaje_iva"].InnerText)).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?pvp1i", (!General.esNodoVacio(nodo["pvp1"].InnerText)) ? Convert.ToDecimal(nodo["pvp1"].InnerText) : 0).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cantidadi", (!General.esNodoVacio(nodo["cantidad"].InnerText)) ? Convert.ToDecimal(nodo["cantidad"].InnerText) : 0).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?maneja_seriei", Convert.ToBoolean(nodo["maneja_serie"].InnerText)).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?numero_seriei", "").Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?tipo_retencion_ir_idi", 0).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?minimoi",(!General.esNodoVacio(nodo["minimo"].InnerText)) ? Convert.ToDecimal(nodo["minimo"].InnerText) : 0).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?categoria_idi", Convert.ToInt32(nodo["categoria_id"].InnerText)).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?codigo_proveedori", (!General.esNodoVacio(nodo["codigo_proveedor"].InnerText)) ? nodo["codigo_proveedor"].InnerText : "").Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?pvp2i", (!General.esNodoVacio(nodo["pvp2"].InnerText)) ? Convert.ToDecimal(nodo["pvp2"].InnerText) : 0).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?pvp3i",(!General.esNodoVacio(nodo["pvp3"].InnerText)) ? Convert.ToDecimal(nodo["pvp3"].InnerText) : 0).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?pvp_distribuidori",(!General.esNodoVacio(nodo["pvp_distribuidor"].InnerText)) ? Convert.ToDecimal(nodo["pvp_distribuidor"].InnerText) : 0).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?codigo_barrai", (!General.esNodoVacio(nodo["codigo_barra"].InnerText)) ? nodo["codigo_barra"].InnerText : "").Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?estadoi", nodo["estado"].InnerText).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?pvp_manuali", (!General.esNodoVacio(nodo["pvp_manual"].InnerText)) ? Convert.ToBoolean(nodo["pvp_manual"].InnerText) : false).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?seriadoi", (!General.esNodoVacio(nodo["seriado"].InnerText)) ? Convert.ToBoolean(nodo["seriado"].InnerText) : false).Direction = ParameterDirection.Input;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                if (barra != null)
                {
                    barra.Value = (actual * 100) / total;
                    actual++;
                }
            }
        }

        public void insertarProducto(MySqlCommand cmd, List<Producto> productos)
        {
            foreach (Producto producto in productos)
            {
                cmd.CommandText = "producto_insertar";
                cmd.Parameters.AddWithValue("?idi", producto.id).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?empresa_idi", Global.idEmpresa).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?codigoi", producto.codigo).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", producto.nombre).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?descripcioni", producto.descripcion).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?inventariablei", false).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?unidad_idi", producto.unidad_id).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?porcentaje_icei", 0).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?porcentaje_ivai", producto.porcentaje_iva).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?pvp1i", producto.pvp1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?cantidadi", producto.cantidad_stock).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?maneja_seriei", false).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?numero_seriei", "").Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?tipo_retencion_ir_idi", 0).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?minimoi", producto.minimo).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?categoria_idi", producto.categoria_id).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?codigo_proveedori", "").Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?pvp2i", producto.pvp2).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?pvp3i", producto.pvp3).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?pvp_distribuidori", 0).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?codigo_barrai", producto.codigo_barra).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?estadoi", producto.estado).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?pvp_manuali", producto.pvp_manual).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?seriadoi", producto.seriado).Direction = ParameterDirection.Input;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                if (producto.seriado)
                {
                    this.inactivarSeries(cmd, producto);
                    if (producto.series != null)
                    {
                        foreach (String serie in producto.series)
                        {
                            cmd.CommandText = "producto_serie";
                            cmd.Parameters.AddWithValue("?opcion", 2).Direction = ParameterDirection.Input;
                            cmd.Parameters.AddWithValue("?producto_idi", producto.id).Direction = ParameterDirection.Input;
                            cmd.Parameters.AddWithValue("?seriei", serie).Direction = ParameterDirection.Input;
                            cmd.Parameters.AddWithValue("?idExcluiri", null).Direction = ParameterDirection.Input;
                            cmd.Parameters.AddWithValue("?idFacturai", null).Direction = ParameterDirection.Input;
                            cmd.Parameters.AddWithValue("?filtroi", String.Empty).Direction = ParameterDirection.Input;
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                    }
                }
            }
        }

        public void inactivarSeries(MySqlCommand cmd, Producto producto)
        {
            cmd.CommandText = "producto_serie";
            cmd.Parameters.AddWithValue("?opcion", 3).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?producto_idi", producto.id).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?seriei", null).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?idExcluiri", null).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?idFacturai", null).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("?filtroi", String.Empty).Direction = ParameterDirection.Input;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public DataTable consultarProductos(ref string mensaje, string codigo, string nombre, bool stock, int nRegistros)
        {
            MySqlCommand cmd;
            DataSet datos = null;
            DataTable resultado = null;
            MySqlDataAdapter adapter = null;
            try
            {
                cmd = this.conf.EjecutarSQL("producto_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?codigoi", codigo).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", nombre).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?codigoBarrai", String.Empty).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?stockCeroi", stock).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nRegistros", (nRegistros != -1)?nRegistros:int.MaxValue).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?tipoDocumento", String.Empty).Direction = ParameterDirection.Input;

                cmd.Parameters.Add(new MySqlParameter("?msn", MySqlDbType.VarChar));
                cmd.Parameters["?msn"].Direction = ParameterDirection.Output;

                adapter = new MySqlDataAdapter(cmd);
                datos = new DataSet();
                adapter.Fill(datos, "productos");
                resultado = datos.Tables["productos"];
            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                conf.cerrar();
                if (adapter != null) adapter.Dispose();
            }
            return resultado;
        }

        public DataTable consultarNombreProductos(ref string mensaje, bool stockCero)
        {
            MySqlCommand cmd;
            DataSet datos = null;
            DataTable resultado = null;
            MySqlDataAdapter adapter = null;
            try
            {
                cmd = this.conf.EjecutarSQL("producto_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 3);
                cmd.Parameters["?opcion"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?codigoi", String.Empty);
                cmd.Parameters["?codigoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?nombrei", String.Empty);
                cmd.Parameters["?nombrei"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?codigoBarrai", String.Empty);
                cmd.Parameters["?codigoBarrai"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?stockCeroi", stockCero);
                cmd.Parameters["?stockCeroi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?nRegistros", -1);
                cmd.Parameters["?nRegistros"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?tipoDocumento", String.Empty);
                cmd.Parameters["?tipoDocumento"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add(new MySqlParameter("?msn", MySqlDbType.VarChar));
                cmd.Parameters["?msn"].Direction = ParameterDirection.Output;

                adapter = new MySqlDataAdapter(cmd);
                datos = new DataSet();
                adapter.Fill(datos, "productos");
                resultado = datos.Tables["productos"];
            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                conf.cerrar();
                if (adapter != null) adapter.Dispose();
            }
            return resultado;
        }

        public DataTable consultarCodigoProductos(ref string mensaje, bool stockCero)
        {
            MySqlCommand cmd;
            DataSet datos = null;
            DataTable resultado = null;
            MySqlDataAdapter adapter = null;
            try
            {
                cmd = this.conf.EjecutarSQL("producto_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 4);
                cmd.Parameters["?opcion"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?codigoi", String.Empty);
                cmd.Parameters["?codigoi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?nombrei", String.Empty);
                cmd.Parameters["?nombrei"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?codigoBarrai", String.Empty);
                cmd.Parameters["?codigoBarrai"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?stockCeroi", stockCero);
                cmd.Parameters["?stockCeroi"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?nRegistros", -1);
                cmd.Parameters["?nRegistros"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?tipoDocumento", String.Empty);
                cmd.Parameters["?tipoDocumento"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add(new MySqlParameter("?msn", MySqlDbType.VarChar));
                cmd.Parameters["?msn"].Direction = ParameterDirection.Output;

                adapter = new MySqlDataAdapter(cmd);
                datos = new DataSet();
                adapter.Fill(datos, "productos");
                resultado = datos.Tables["productos"];
            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                conf.cerrar();
                if (adapter != null) adapter.Dispose();
            }
            return resultado;
        }

        public Producto consultarProducto(ref string mensaje, string codigo, string nombre,bool stockEnCero, string tipoDocumento)
        {
            Producto producto = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            try
            {
                cmd = this.Conf.EjecutarSQL("producto_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 2).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?codigoi", codigo).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", nombre).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?codigoBarrai", String.Empty).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?stockCeroi", stockEnCero).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nRegistros", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?tipoDocumento", tipoDocumento).Direction = ParameterDirection.Input;

                cmd.Parameters.Add(new MySqlParameter("?msn", MySqlDbType.VarChar));
                cmd.Parameters["?msn"].Direction = ParameterDirection.Output;

                data = cmd.ExecuteReader();
                if (data.Read())
                {
                    producto = new Producto();
                    producto.id = data.GetInt32("id");
                    producto.codigo = data.GetString("codigo");
                    producto.nombre = data.GetString("nombre");
                    producto.pvp1 = data.GetDecimal("pvp1");
                    producto.porcentaje_iva = data.getInt("porcentaje_iva");
                    //producto.Inventariable = data.GetBoolean("inventariable");
                    producto.unidad = data.GetString("unidad");
                    //producto.Unidad_id = data.GetInt16("idUnidad");
                    producto.pvp2 = data.GetDecimal("pvp2");
                    producto.pvp3 = data.GetDecimal("pvp3");
                    producto.cantidad_stock = data.GetDecimal("cantidad");
                    producto.categoria_id = data.GetInt32("categoria_id");
                    producto.pvp_manual = data.GetBoolean("pvp_manual");
                    producto.seriado = data.GetBoolean("seriado");
                    producto.descripcion = data.getString("descripcion");
                }
                else  mensaje = cmd.Parameters["?msn"].Value.ToString();
            }
            catch (Exception e) { mensaje = e.Message; }
            finally {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                this.conf.cerrar();
            }
            return producto;
        }

        public Producto consultarCodigoBarra(ref string mensaje, string codigoBarra, bool stockEnCero, string tipoDocumento)
        {
            Producto producto = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            try
            {
                cmd = this.Conf.EjecutarSQL("producto_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 2).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?codigoi", String.Empty).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", String.Empty).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?codigoBarrai", codigoBarra).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?stockCeroi", stockEnCero).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nRegistros", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?tipoDocumento", tipoDocumento).Direction = ParameterDirection.Input;
                cmd.Parameters.Add(new MySqlParameter("?msn", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                data = cmd.ExecuteReader();
                if (data.Read())
                {
                    producto = new Producto();
                    producto.id = data.GetInt32("id");
                    producto.codigo = data.GetString("codigo");
                    producto.nombre = data.GetString("nombre");
                    producto.pvp1 = data.GetDecimal("pvp1");
                    producto.porcentaje_iva = data.GetInt32("porcentaje_iva");
                    //producto.Inventariable = data.GetBoolean("inventariable");
                    producto.unidad = data.GetString("unidad");
                    //producto.Unidad_id = data.GetInt16("idUnidad");
                    producto.pvp2 = data.GetDecimal("pvp2");
                    producto.pvp3 = data.GetDecimal("pvp3");
                    producto.cantidad_stock = data.GetDecimal("cantidad");
                    producto.categoria_id = data.GetInt32("categoria_id");
                    producto.pvp_manual = data.GetBoolean("pvp_manual");
                    producto.seriado = data.GetBoolean("seriado");
                    producto.descripcion = data.getString("descripcion");
                }
                else mensaje = cmd.Parameters["?msn"].Value.ToString();
            }
            catch (Exception e) { mensaje = e.Message; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                this.conf.cerrar();
            }
            return producto;
        }

        public static String[] consultarUnidad(int idProducto, string nombre)
        {
            String[] producto = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("producto_consultar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?opcion", 5).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?codigoi", String.Empty).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nombrei", nombre).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?codigoBarrai", String.Empty).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?stockCeroi", -1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?nRegistros", idProducto).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?tipoDocumento", String.Empty).Direction = ParameterDirection.Input;
                cmd.Parameters.Add(new MySqlParameter("?msn", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                data = cmd.ExecuteReader();
                if (data.Read())
                {
                    producto = new String[3];
                    producto[0] = data.getString(0); 
                    producto[1] = data.getString(1);
                    producto[2] = data.getString(2);
                }
            }
            catch (Exception e) { throw e; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                if (con!=null) con.cerrar();
            }
            return producto;
        }

        public static string consultarDescripcion(int idProducto)
        {
            string producto = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion con = null;
            try
            {
                con = new Conexion();
                cmd = con.EjecutarSQL("producto_consultar1");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("?opcion", 1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idProductoi", idProducto).Direction = ParameterDirection.Input;
                data = cmd.ExecuteReader();
                if (data.Read()) producto = data.getString(0);

            }
            catch (Exception e) { throw e; }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                if(con!=null)con.cerrar();
            }
            return producto;
        }

        public static List<KeyValuePair<Int32, String>> consultarSeries(int idProducto, string seriesExcluir, int? idFactura, string filtro)
        {
            List<KeyValuePair<Int32, String>> series = null;
            MySqlCommand cmd = null;
            MySqlDataReader data = null;
            Conexion conf = null;
            try
            {
                conf = new Conexion();
                cmd = conf.EjecutarSQL("producto_serie");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("?opcion", 1).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?producto_idi", idProducto).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?seriei", null).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idExcluiri", seriesExcluir).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?idFacturai", idFactura).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("?filtroi", filtro).Direction = ParameterDirection.Input;

                data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    series = new List<KeyValuePair<Int32, String>>();
                    while (data.Read())
                    {
                        series.Add(new KeyValuePair<Int32,String>(data.getInt("id"), data.getString("serie")));
                    }
                }
            }
            catch (Exception e)
            {
                series = null;
                throw e;
            }
            finally
            {
                if (data != null) data.Dispose();
                if (cmd != null) cmd.Dispose();
                conf.cerrar();
            }
            return series;
        }
    
    }
}
