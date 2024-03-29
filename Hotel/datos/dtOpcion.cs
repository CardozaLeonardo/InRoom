﻿using System;
using System.Data;
using MySql.Data;
using Gtk;
using System.Text;
using Hotel.entidades;
using System.Collections.Generic;

namespace Hotel.datos
{
    public class dtOpcion
    {
        Conexion con = new Conexion();
        MessageDialog ms = null;
        StringBuilder sb = new StringBuilder();

        #region metodos
        public bool GuardarOpcion(Tbl_opcion top)
        {
            bool guardado = false; // bandera
            int x = 0; // variable de control
            sb.Clear();
            sb.Append("INSERT INTO tbl_opcion");
            sb.Append("(opcion, estado)");
            sb.Append(" VALUES('" + top.Opcion + "','" + 1 + "')");
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

        public ListStore ListarOpciones()
        {
            ListStore datos = new ListStore(typeof(string), typeof(string));


            IDataReader dr = null;
            sb.Clear();
            sb.Append("SELECT id_opcion,opcion FROM tbl_opcion WHERE estado<>3;");
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

        public bool existeOpcion(Tbl_opcion top)
        {
            bool existe = false; //bandera
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE hotel;");
            sb.Append("SELECT * FROM tbl_opcion WHERE opcion=" + "'" + top.Opcion + "';");

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

        public Int32 EliminarOpcion(Tbl_opcion top)
        {
            int eliminado;
            sb.Clear();
            sb.Append("UPDATE tbl_opcion SET estado = 3 WHERE id_opcion=" + top.Id_opcion + "");

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

        public bool ActualizarOpcion(Tbl_opcion top)
        {
            bool actualizado = false;
            int x = 0;
            sb.Clear();
            sb.Append("UPDATE tbl_opcion SET opcion = '" + top.Opcion + "',");
            sb.Append("estado = '" + top.Estado + "'");
            sb.Append("WHERE id_opcion = " + top.Id_opcion + ";");

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

        public int getIdOpcion(String opc)
        {
            int existe = 0; //bandera
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE hotel;");
            sb.Append("SELECT id_opcion FROM tbl_opcion WHERE opcion=" + "'" + opc + "';");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                if (idr.Read())
                {
                    existe = (Int32)idr["id_opcion"];
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

        public List<Tbl_opcion> cbxOpcion()
        {
            List<Tbl_opcion> listOpcion = new List<Tbl_opcion>();
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE hotel;");
            sb.Append("SELECT id_opcion,opcion FROM tbl_opcion WHERE estado <> '3';");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    Tbl_opcion top = new Tbl_opcion()
                    //Tbl_usuarios tus = new Tbl_usuarios()
                    {
                        Id_opcion = (Int32)idr["id_opcion"],
                        Opcion = idr["opcion"].ToString(),

                    };
                    listOpcion.Add(top);

                }
                idr.Close();
                return listOpcion;

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

        public dtOpcion()
        {
        }
    }
}
