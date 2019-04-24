using System;
using System.Data;
//using MySql.Data;
using Gtk;
using System.Text;
using Hotel.entidades;
using System.Collections.Generic;

namespace Hotel.datos
{
    public class dtRol
    {
        Conexion con = new Conexion();
        MessageDialog ms = null;
        StringBuilder sb = new StringBuilder();

        #region metodos
        public bool GuardarRol(Tbl_rol tr)
        {
            bool guardado = false; // bandera
            int x = 0; // variable de control
            sb.Clear();
            sb.Append("INSERT INTO tbl_rol");
            sb.Append("(rol, estado)");
            sb.Append(" VALUES('" + tr.Rol + "','" + 1 + "')");
            try
            {
                con.AbrirConexion();
                x = con.Ejecutar(CommandType.Text, sb.ToString());
                //ms = new MessageDialog(null,DialogFlags.Modal,
                //  MessageType.Info,ButtonsType.Ok,"Se guarda la categoria con existo!!!");
                //ms.Run();
                //ms.Destroy();
                if (x > 0)
                {
                    guardado = true;
                }
                return guardado;
            }
            catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
                Console.WriteLine("DT: ERROR=" + e.Message);
                Console.WriteLine("DT: ERROR=" + e.StackTrace);
                throw;
            }
            finally
            {
                con.CerrarConexion();
            }

        }//fin del metodo

        public ListStore ListarRoles()
        {
            ListStore datos = new ListStore(typeof(string), typeof(string));


            IDataReader dr = null;
            sb.Clear();
            sb.Append("SELECT id_rol,rol FROM tbl_rol WHERE estado<>3;");
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
                throw;
            }
            finally
            {
                dr.Close();
                con.CerrarConexion();
            }
        }//fin del metodo

        public bool existeRol(Tbl_rol tr)
        {
            bool existe = false; //bandera
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE hotel;");
            sb.Append("SELECT * FROM tbl_rol WHERE rol=" + "'" + tr.Rol + "';");

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

        public Int32 EliminarRol(Tbl_rol tr)
        {
            int eliminado;
            sb.Clear();
            sb.Append("UPDATE tbl_rol SET estado = 3 WHERE id_rol=" + tr.Id_rol + "");

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

        public bool ActualizarRol(Tbl_rol tr)
        {
            bool actualizado = false;
            int x = 0;
            sb.Clear();
            sb.Append("UPDATE tbl_rol SET rol = '" + tr.Rol + "',");
            sb.Append("estado = '" + tr.Estado + "'");
            sb.Append("WHERE id_rol = " + tr.Id_rol + ";");

            try
            {
                con.AbrirConexion();
                x = con.Ejecutar(CommandType.Text, sb.ToString());

                if (x > 0)
                {
                    actualizado = true;
                }
                //actualizado = cone.Ejecutar(CommandType.Text,sb.ToString());
                return actualizado;
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


        public ListStore buscarRol(String cadena)
        {
            ListStore datos = new ListStore(typeof(string), typeof(string));
            IDataReader dr = null;
            sb.Clear();
            sb.Append("USE hotel;");
            sb.Append("SELECT id_rol,rol FROM tbl_rol ");
            sb.Append("WHERE (estado <>3) ");
            sb.Append("AND (rol like '%" + cadena + "%'); ");//Busca lo que coincida con la busqueda y los % son para especificar que no importa si hay algo antes o despues
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

        public int getIdRol(String rol)
        {
            int existe = 0; //bandera
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE hotel;");
            sb.Append("SELECT id_rol FROM tbl_rol WHERE rol=" + "'" + rol + "';");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                if (idr.Read())
                {
                    existe = (Int32)idr["id_rol"];
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

        public List<Tbl_rol> cbxRol()
        {
            List<Tbl_rol> listRol = new List<Tbl_rol>();
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE hotel;");
            sb.Append("SELECT id_rol,rol FROM tbl_rol WHERE estado <> '3';");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    Tbl_rol tr = new Tbl_rol()
                    //Tbl_usuarios tus = new Tbl_usuarios()
                    {
                        Id_rol = (Int32)idr["id_rol"],
                        Rol = idr["rol"].ToString(),

                    };
                    listRol.Add(tr);

                }
                idr.Close();
                return listRol;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                throw;
            }
            finally
            {
                con.CerrarConexion();
            }
        }//fin del metodo

        #endregion

        public dtRol()
        {
        }
    }
}