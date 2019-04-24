using System;
using System.Data;
//using MySql.Data;
using Gtk;
using System.Text;
using Hotel.entidades;
using System.Collections.Generic;

namespace Hotel.datos
{
    public class dtTipoHabitacciones
    {
        Conexion con = new Conexion();
        MessageDialog ms = null;
        StringBuilder sb = new StringBuilder();

        #region metodos
        public bool GuardarTipHabitacion(Tbl_tipoHabitacion tph)
        {
            bool guardado = false; // bandera
            int x = 0; // variable de control
            sb.Clear();
            sb.Append("INSERT INTO tbl_tipoHabitacion");
            sb.Append("(descripcion, estado)");
            sb.Append(" VALUES('" + tph.Descripcion + "','" + 1 + "')");
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

        public ListStore ListarTipHabitacion()
        {
            ListStore datos = new ListStore(typeof(string), typeof(string));


            IDataReader dr = null;
            sb.Clear();
            sb.Append("SELECT id_tipoHabitacion,descripcion FROM tbl_tipoHabitacion WHERE estado<>3;");
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

        public bool existeTipHabitacion(Tbl_tipoHabitacion tph)
        {
            bool existe = false; //bandera
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE hotel;");
            sb.Append("SELECT * FROM tbl_tipoHabitacion WHERE descripcion=" + "'" + tph.Descripcion + "';");

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

        public Int32 EliminarTipHabitacion(Tbl_tipoHabitacion tph)
        {
            int eliminado;
            sb.Clear();
            sb.Append("UPDATE tbl_tipoHabitacion SET estado = 3 WHERE id_tipoHabitacion=" + tph.Id_tipoHabitacion + "");

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

        public bool ActualizarTipHabitacion(Tbl_tipoHabitacion tph)
        {
            bool actualizado = false;
            int x = 0;
            sb.Clear();
            sb.Append("UPDATE tbl_tipoHabitacion SET descripcion = '" + tph.Descripcion + "',");
            sb.Append("estado = '" + tph.Estado + "'");
            sb.Append("WHERE id_tipoHabitacion = " + tph.Id_tipoHabitacion + ";");

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


        public ListStore buscarTipHabitacion(String cadena)
        {
            ListStore datos = new ListStore(typeof(string), typeof(string));
            IDataReader dr = null;
            sb.Clear();
            sb.Append("USE hotel;");
            sb.Append("SELECT id_tipoHabitacion,descripcion FROM tbl_tipoHabitacion ");
            sb.Append("WHERE (estado <>3) ");
            sb.Append("AND (descripcion like '%" + cadena + "%'); ");//Busca lo que coincida con la busqueda y los % son para especificar que no importa si hay algo antes o despues
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

        public int getIdTipHab(String des)
        {
            int existe = 0; //bandera
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE hotel;");
            sb.Append("SELECT id_tipoHabitacion FROM tbl_tipoHabitacion WHERE descripcion=" + "'" + des + "';");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                if (idr.Read())
                {
                    existe = (Int32)idr["id_tipoHabitacion"];
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

        public List<Tbl_tipoHabitacion> cbxtipoHabitacion()
        {
            List<Tbl_tipoHabitacion> listTipHab = new List<Tbl_tipoHabitacion>();
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE hotel;");
            sb.Append("SELECT id_tipoHabitacion,descripcion FROM tbl_tipoHabitacion WHERE estado <> '3';");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    Tbl_tipoHabitacion tth = new Tbl_tipoHabitacion()
                    //Tbl_usuarios tus = new Tbl_usuarios()
                    {
                        Id_tipoHabitacion = (Int32)idr["id_tipoHabitacion"],
                        Descripcion = idr["descripcion"].ToString(),

                    };
                    listTipHab.Add(tth);

                }
                idr.Close();
                return listTipHab;

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

        public dtTipoHabitacciones()
        {
        }
    }
}
