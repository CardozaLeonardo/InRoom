using System;
using System.Data;
using MySql.Data;
using Gtk;
using System.Text;
using Hotel.entidades;
using System.Collections.Generic;

namespace Hotel.datos
{
    public class dtTarjeta
    {
        Conexion con = new Conexion();
        MessageDialog ms = null;
        StringBuilder sb = new StringBuilder();

        #region métodos
        public bool GuardarTarjeta(Tbl_tarjeta ttar)
        {
            bool guardado = false;
            int x = 0;
            sb.Append("INSERT INTO tbl_tarjeta");
            sb.Append("(nombre_titular,numeroTarjeta, fecha_expiracion, id_emisorTarjeta, id_tipoTarjeta, estado)");
            sb.Append("Values('" + ttar.Nombre_titular + "','" + ttar.NumeroTarjeta + "','" + ttar.Fecha_expiracion + "','" + ttar.Id_emisorTarjeta + "','" + ttar.Id_tipoTarjeta + "','" + 1 + "')");
            /*
            sb.Append("INSER INTO tbl_emisorTarjeta");
            sb.Append("(id_emisorTarjeta)");
            sb.Append("Values('" + ttar.Id_emisorTarjeta + "')");

            sb.Append("INSERT INTO tbl_tipoTarjeta");
            sb.Append("(id_tipoTarjeta");
            sb.Append("Values('" + ttar.Id_tipoTarjeta + "')");*/

            try
            {
                con.AbrirConexion();
                x = con.Ejecutar(CommandType.Text, sb.ToString());

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
                throw;
            }
            finally
            {
                con.CerrarConexion();
            }
        }


        public ListStore ListarTarjetas()
        {
            ListStore datos = new ListStore(typeof(string),
                typeof(string), typeof(string), typeof(string), typeof(string), typeof(string));
            sb.Clear();
            IDataReader dr = null;
            //SELECT id_tarjeta, nombre_titular, numeroTarjeta, id_emisorTarjeta, id_tipoTarjeta FROM tbl_tarjeta
            sb.Append("select  id_tarjeta, nombre_titular, numeroTarjeta, tbl_emisorTarjeta.emisor, tbl_tipoTarjeta.tipo_tarjeta ");
            sb.Append("from tbl_tarjeta INNER JOIN tbl_emisorTarjeta ON tbl_emisorTarjeta.id_emisorTarjeta = tbl_tarjeta.id_emisorTarjeta ");
            sb.Append("INNER JOIN tbl_tipoTarjeta ON tbl_tipoTarjeta.id_tipoTarjeta = tbl_tarjeta.id_tipoTarjeta where estado <> 3;");
            try
            {
                con.AbrirConexion();
                dr = con.Leer(CommandType.Text, sb.ToString());
                while (dr.Read())
                {
                    datos.AppendValues(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
                }

                return datos;
            }
            catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                MessageType.Error, ButtonsType.Ok, e.Message);
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



        public ListStore buscarTarjeta(String cadena)
        {
            ListStore datos = new ListStore(typeof(string),
                typeof(string), typeof(string), typeof(string));
            sb.Clear();
            IDataReader dr = null;
            sb.Append("USE `hotel`;");
            sb.Append("SELECT id_tarjeta,nombre_titular,numeroTarjeta,id_emisorTarjeta, id_tipoTarjeta FROM tbl_tarjeta");
            sb.Append(" WHERE (estado <> 3) ");
            sb.Append("AND (nombre_titular like '%" + cadena + "%' ");
            sb.Append("OR numeroTarjeta like '%" + cadena + "%'); ");

            try
            {
                con.AbrirConexion();
                dr = con.Leer(CommandType.Text, sb.ToString());
                while (dr.Read())
                {
                    datos.AppendValues(dr[0].ToString(), dr[1].ToString(),
                     dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
                }

                return datos;
            }
            catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                MessageType.Error, ButtonsType.Ok, e.Message);
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

        public int getIdTarjeta(String cedula)
        {
            int existe = 0; //bandera
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE hotel;");
            sb.Append("SELECT id_tarjeta FROM tbl_tarjeta WHERE cedula=" + "'" + cedula + "';");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                if (idr.Read())
                {
                    existe = (Int32)idr["id_tarjeta"];
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
        public dtTarjeta()
        {
        }
    }
}
