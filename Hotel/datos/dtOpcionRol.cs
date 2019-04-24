using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using Gtk;
using Hotel.entidades;
namespace Hotel.datos
{
    public class dtOpcionRol
    {
        Conexion con = new Conexion();
        MessageDialog ms = null;
        StringBuilder sb = new StringBuilder();

        #region metodos
        public ListStore ListarOpcionRol()
        {
            ListStore datos = new ListStore(typeof(string),
                typeof(string), typeof(string), typeof(string));


            IDataReader dr = null;
            sb.Clear();
            sb.Append("SELECT id_rol,rol,id_opcion,opcion FROM VwRolOption WHERE estado<>3;");
            try
            {
                con.AbrirConexion();
                dr = con.Leer(CommandType.Text, sb.ToString());
                while (dr.Read())
                {
                    datos.AppendValues(dr[0].ToString(), dr[1].ToString(),
                        dr[2].ToString(), dr[3].ToString());
                    //dr.Close();
                }//fin de while
                return datos;
            }
            catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
                throw;
            }
            finally
            {
                dr.Close();
                con.CerrarConexion();
            }
        }//fin del metodo

        public bool GuardarOpcRol(Tbl_rolOption tro)
        {
            bool guardado = false; //bandera
            int x = 0; //variable de control
            sb.Clear();
            sb.Append("USE hotel;");
            sb.Append("INSERT INTO tbl_RolOption");
            sb.Append("(id_rol, id_opcion)");
            sb.Append(" VALUES('" + tro.Id_rol + "','" + tro.Id_option + "');");
            try
            {
                con.AbrirConexion();
                x = con.Ejecutar(CommandType.Text, sb.ToString());

                if (x > 0)
                {
                    guardado = true;
                    /* ms = new MessageDialog(null,DialogFlags.Modal,
                     MessageType.Info,ButtonsType.Ok,"Se guardo el usuario con exito!!!");
                     ms.Run();
                     ms.Destroy();*/
                }
                return guardado;
            }
            catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
                Console.WriteLine("ERROR: " + e.Message);
                Console.WriteLine("ERROR: " + e.StackTrace);
                throw;
            }
            finally
            {
                con.CerrarConexion();
            }

        }//fin del metodo

        public Int32 DelOpcRol(Tbl_rolOption tro)
        {
            int eliminado;
            sb.Clear();
            sb.Append("USE hotel;");
            sb.Append("DELETE FROM tbl_RolOption WHERE id_rol=" + tro.Id_rol + " ");
            sb.Append("AND id_opcion=" + tro.Id_option + ";");

            try
            {
                con.AbrirConexion();
                eliminado = con.Ejecutar(CommandType.Text, sb.ToString());
                return eliminado;
            }
            catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
                throw;
            }
            finally
            {
                con.CerrarConexion();
            }

        }//fin del metodo

        public bool existeOpcRol(Tbl_rolOption tro)
        {
            bool existe = false; //bandera
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE hotel;");
            sb.Append("SELECT * FROM tbl_RolOption WHERE id_rol=" + tro.Id_rol + " ");
            sb.Append("AND id_opcion=" + tro.Id_option + ";");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                if (idr.Read())
                {
                    existe = true;
                }
                return existe;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                throw;
            }
            finally
            {
                idr.Close();
                con.CerrarConexion();
            }
        }//fin del metodo
        public ListStore buscarOpcion(String cadena)
        {
            ListStore datos = new ListStore(typeof(string), typeof(string));
            IDataReader dr = null;
            sb.Clear();
            sb.Append("USE hotel;");
            sb.Append("SELECT id_opcion,opcion FROM tbl_opcion ");
            sb.Append("WHERE (estado <>3) ");
            sb.Append("AND (opcion like '%" + cadena + "%'); ");//Busca lo que coincida con la busqueda y los % son para especificar que no importa si hay algo antes o despues
            try
            {
                con.AbrirConexion();
                dr = con.Leer(CommandType.Text, sb.ToString());
                while (dr.Read())
                {
                    datos.AppendValues(dr[0].ToString(), dr[1].ToString());
                    //dr.Close();
                }//fin de while
                return datos;
            }
            catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
                Console.WriteLine("Error: " + e.Message);
                Console.WriteLine("Error: " + e.StackTrace);
                throw;
            }
            finally
            {
                dr.Close();
                con.CerrarConexion();
            }
        }//fin del metodo

        public ListStore BuscarOpcRol(String cadena)
        {
            ListStore datos = new ListStore(typeof(string), typeof(string), typeof(string), typeof(string));
            IDataReader dr = null;
            sb.Clear();
            sb.Append("USE hotel;");
            sb.Append("SELECT id_rol,rol,id_opcion,opcion FROM VwRolOption ");
            sb.Append("WHERE (estado <>3) ");
            sb.Append("AND (rol like '%" + cadena + "%' ");
            sb.Append("OR opcion like '%" + cadena + "%'); "); ;//Busca lo que coincida con la busqueda y los % son para especificar que no importa si hay algo antes o despues
            try
            {
                con.AbrirConexion();
                dr = con.Leer(CommandType.Text, sb.ToString());
                while (dr.Read())
                {
                    datos.AppendValues(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                    //dr.Close();
                }//fin de while
                return datos;
            }
            catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
                Console.WriteLine("Error: " + e.Message);
                Console.WriteLine("Error: " + e.StackTrace);
                throw;
            }
            finally
            {
                dr.Close();
                con.CerrarConexion();
            }
        }//fin del metodo
        #endregion

        public dtOpcionRol()
        {
        }
    }
}