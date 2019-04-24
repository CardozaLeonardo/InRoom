using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using Gtk;
using Hotel.entidades;

namespace Hotel.datos
{
    public class dtRolUser
    {
        Conexion con = new Conexion();
        MessageDialog ms = null;
        StringBuilder sb = new StringBuilder();

        #region metodos
        public ListStore ListarUserRol()
        {
            ListStore datos = new ListStore(typeof(string),
                typeof(string), typeof(string), typeof(string), typeof(string), typeof(string));


            IDataReader dr = null;
            sb.Clear();
            sb.Append("SELECT id_user,user,nombres,apellidos,id_rol,rol FROM VwUserRol WHERE estado<>3;");
            try
            {
                con.AbrirConexion();
                dr = con.Leer(CommandType.Text, sb.ToString());
                while (dr.Read())
                {
                    datos.AppendValues(dr[0].ToString(), dr[1].ToString(),
                        dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
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

        public bool GuardarUserRol(Tbl_UserRol tur)
        {
            bool guardado = false; //bandera
            int x = 0; //variable de control
            sb.Clear();
            sb.Append("USE Seguridad;");
            sb.Append("INSERT INTO tbl_UserRol");
            sb.Append("(id_user, id_rol)");
            sb.Append(" VALUES('" + tur.Id_user + "','" + tur.Id_rol + "');");
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


        public Int32 delRolUser(Tbl_UserRol tur)
        {
            int eliminado;
            sb.Clear();
            sb.Append("USE Seguridad;");
            sb.Append("DELETE FROM tbl_UserRol WHERE id_user=" + tur.Id_user + " ");
            sb.Append("AND id_rol=" + tur.Id_rol + ";");

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

        public bool existeUserRol(Tbl_UserRol tur)
        {
            bool existe = false; //bandera
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE Seguridad;");
            sb.Append("SELECT * FROM tbl_UserRol WHERE id_user=" + tur.Id_user + " ");
            sb.Append("AND id_rol=" + tur.Id_rol + ";");

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

        #endregion
        public dtRolUser()
        {
        }
    }
}
