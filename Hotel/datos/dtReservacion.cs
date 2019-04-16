﻿using System;
using System.Data;
using Gtk;
using System.Text;
using Hotel.entidades;

// ¿Cómo indentificar el servicio al realizar una reservación?
// Nombre y logo para el programa

namespace Hotel.datos
{
    public class dtReservacion
    {
        Conexion con = new Conexion();
        StringBuilder sb = new StringBuilder();
        MessageDialog ms = null;
        public bool GuardarReservacion(Tbl_reservacion tbr)
        {
            bool guardado = true;
            int x = 0;

            sb.Clear();
            sb.Append("USE `hotel`;");
            sb.Append("INSERT INTO tbl_reservacion (num_reserv, fecha, id_huesped, estado) VALUES");
            sb.Append("(" + tbr.Num_reserv + ",'" + tbr.Fecha + "'," + tbr.Id_factura + "," + 1 + ");");

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

        public bool ExisteNumReserv(Tbl_reservacion tbr)
        {
            bool existe = false;
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE `hotel`;");
            sb.Append("SELECT * FROM tbl_resevacion WHERE num_reserv = " + tbr.Num_reserv + ";");

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
                idr.Close();
                return existe;
                throw;

            }
            finally
            {
                con.CerrarConexion();

            }

        }

        public Int32 GetNumReserv()
        {
            IDataReader idr = null;
            int id = 2;
            sb.Clear();
            sb.Append("Use `hotel`;");
            sb.Append("SELECT max(num_reserv) AS numero FROM vw_reservaciones;");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
               if (idr.Read())
                {
                    id = (Int32)idr["numero"];
                    Console.WriteLine(id);

                }

                idr.Close();
                return id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok,
                "Error: " + e.Message);
                Console.WriteLine("EEEEEEEEEEEEERRR: " + id);
                ms.Run();
                ms.Destroy();
                throw;
            }
            finally
            {
                con.CerrarConexion();
            }

            //return id;
        }

        //public bool ActualizarReservacion(Tbl_reservacion tbr)
        //{
        //    bool actualizado = false;
        //    int x = 0;

        //    sb.Clear();
        //    sb.Append("USE `hotel`;");
        //    sb.Append("UPDATE tbl_reservacion SET num_reserv = " + tbr.Num_reserv + ", fecha = '" + tbr.Fecha
        //    + "', id_factura = " +  tbr.Id_factura + ", estado = " + 2 + ";");
        //}
        public dtReservacion()
        {
        }
    }
}