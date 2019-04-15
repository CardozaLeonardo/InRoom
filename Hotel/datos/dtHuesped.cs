using System;
using System.Data;
using Gtk;
using System.Text;
using Hotel.entidades;
using Hotel.datos;
using System.Collections.Generic;

namespace Hotel.datos
{
    public class dtHuesped
    {
        Conexion con = new Conexion();
        StringBuilder sb = new StringBuilder();
        MessageDialog ms = null;

        public ListStore ListarHuespedes()
        {
            ListStore datos = new ListStore(typeof(string),
                typeof(string), typeof(string), typeof(string), typeof(string), typeof(string));


            IDataReader dr = null;
            sb.Clear();
            sb.Append("USE `hotel`;");
            sb.Append("SELECT * FROM tbl_huesped WHERE estado <> 3;");
            try
            {
                con.AbrirConexion();
                dr = con.Leer(CommandType.Text, sb.ToString());
                while (dr.Read())
                {
                    datos.AppendValues(dr[0].ToString(), dr[1].ToString(),
                        dr[2].ToString(), dr[3].ToString(), dr[4].ToString(),
                        dr[5].ToString());

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
        }

        public ListStore BuscarHuesped(String cadena)
        {
            ListStore datos = new ListStore(typeof(string),
                typeof(string), typeof(string), typeof(string), typeof(string), typeof(string));


            IDataReader dr = null;
            sb.Clear();
            sb.Append("USE `hotel`;");
            sb.Append("SELECT * FROM tbl_huesped WHERE (estado <> 3) AND ");
            sb.Append("(cedula like '%" + cadena + "%' ");
            sb.Append(" OR nombres like '%" + cadena + "%' ");
            sb.Append(" OR apellidos like '%" + cadena + "%' );");
            try
            {
                con.AbrirConexion();
                dr = con.Leer(CommandType.Text, sb.ToString());
                while (dr.Read())
                {
                    datos.AppendValues(dr[0].ToString(), dr[1].ToString(),
                        dr[2].ToString(), dr[3].ToString(), dr[4].ToString(),
                        dr[5].ToString());

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
        }

        public dtHuesped()
        {
        }
    }
}
