using System;
using System.Data;
using MySql.Data;
using Gtk;
using System.Text;
using Hotel.entidades;
using System.Collections.Generic;

namespace Hotel.datos
{
    public class dtDetalleReserv
    {
        Conexion con = new Conexion();
        MessageDialog ms = null;
        StringBuilder sb = new StringBuilder();

        public bool GuardarDetalleReserv(List<Tbl_detalleReserv> lista)
        {
            bool guardado = false;
            int x = 0;

            sb.Clear();
            sb.Append("USE `hotel`;");

            foreach(Tbl_detalleReserv tdr in lista)
            {
                sb.Append("INSERT INTO tbl_detalleReserv (id_reservacion, id_habitacion, fecha_entrada" +
                ", fecha_salida, hora_entrada, hora_salida) VALUES(" + tdr.Id_reservacion + "," + tdr.Id_habitacion + ",'"
                + tdr.Fecha_entrada + "','" + tdr.Fecha_salida + "','" + tdr.Hora_entrada + "','" + tdr.Hora_salida + "');");
            }


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
            catch(Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok,
                "Ha ocurrido un error intenda guardar el registro");
                ms.Run();
                ms.Destroy();
                throw;
            }
            finally
            {
                con.CerrarConexion();
            }

        }

        public bool EliminarDetalleReserv(Tbl_detalleReserv tdr)
        {
            bool eliminado = false;
            int x = 0;

            sb.Clear();
            sb.Append("USE `hotel`;");
            sb.Append("DELETE FROM tbl_detalleReserv WHERE id_detalleReserv = " + tdr.Id_detalleReserv + ";");

            try
            {
                con.AbrirConexion();
                x = con.Ejecutar(CommandType.Text, sb.ToString());

                if(x > 0)
                {
                    eliminado = true;
                }

                return eliminado;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                throw;
            }
            finally
            {
                con.CerrarConexion();
            }

        }

        public bool actualizarDetalleReserv(Tbl_detalleReserv tdr)
        {
            bool actualizado = false;
            int x = 0;
            sb.Clear();
            sb.Append("USE `hotel`;");
            sb.Append("UPDATE tbl_detalleReserv SET fecha_entrada = '" + tdr.Fecha_entrada + "', fecha_salida ='" + tdr.Fecha_salida +
            "', hora_entrada = '" + tdr.Hora_entrada + "', hora_salida = '" + tdr.Hora_salida + "';");

            try
            {
                con.AbrirConexion();
                x = con.Ejecutar(CommandType.Text, sb.ToString());

                if (x > 0)
                {
                    actualizado = true;
                }

                return actualizado;
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
        }

        public ListStore listarDetallesReserv(Tbl_detalleReserv tdr)
        {
            ListStore datos = new ListStore(typeof(string),
                typeof(string), typeof(string), typeof(string), typeof(string));
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE `hotel`;");
            sb.Append("SELECT h.numero, d.fecha_entrada, d.fecha_salida, d.hora_entrada, d.hora salida " +
            	"FROM tbl_detalleReserv d INNER JOIN tbl_habitacion h ON d.id_habitacion = h.id_habitacion;");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());

                while (idr.Read())
                {
                    datos.AppendValues(idr[0].ToString(), idr[1].ToString(), idr[2].ToString(),
                    idr[3].ToString(), idr[4].ToString());


                }

                return datos;
            }
            catch(Exception e)
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


        }



        public dtDetalleReserv()
        {
        }
    }
}
