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

        public bool EliminarDetalleReserv(int id_dt)
        {
            bool eliminado = false;
            int x = 0;

            sb.Clear();
            sb.Append("USE `hotel`;");
            sb.Append("DELETE FROM tbl_detalleReserv WHERE id_detalleReserv = " + id_dt + ";");

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

        public List<Vw_detalleReserv> listarDetallesReserv(int id_reservacion)
        {
            List<Vw_detalleReserv> detList = new List<Vw_detalleReserv>();


            Vw_detalleReserv vdr = null;
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE `hotel`;");
            sb.Append("SELECT * " +
                "FROM vw_detalleReserv WHERE id_reservacion = " + id_reservacion + ";");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());

                while (idr.Read())
                {

                    vdr = new Vw_detalleReserv();
                    vdr.Id_detalleReserv =  Convert.ToInt32(idr[0].ToString());
                    vdr.Id_reservacion = Convert.ToInt32(idr[1].ToString());
                    vdr.Id_habitacion = Convert.ToInt32(idr[2].ToString());
                    vdr.NumeroHab = idr[3].ToString();
                    vdr.Descripcion = idr[4].ToString();
                    vdr.FechaEntrada = idr[5].ToString();
                    vdr.FechaSalida = idr[6].ToString();
                    vdr.HoraEntrada = idr[7].ToString();
                    vdr.HoraSalida = idr[8].ToString();

                    detList.Add(vdr);
                }



                return detList;
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
