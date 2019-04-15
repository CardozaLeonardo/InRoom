using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using Gtk;
using Hotel.entidades;
namespace Hotel.datos
{
    public class dtHabitaciones
    {
        Conexion con = new Conexion();
        MessageDialog ms = null;
        StringBuilder sb = new StringBuilder();

        #region metodos
        public ListStore ListarHabitaciones()
        {
            ListStore datos = new ListStore(typeof(string),
                typeof(string), typeof(string));


            IDataReader dr = null;
            sb.Clear();
            sb.Append("SELECT id_habitacion,numero,descripcion FROM vw_habitaciones;");
            try
            {
                con.AbrirConexion();
                dr = con.Leer(CommandType.Text, sb.ToString());
                while (dr.Read())
                {
                    datos.AppendValues(dr[0].ToString(), dr[1].ToString(),
                        dr[2].ToString());
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

        public bool GuardarHabitacion(Tbl_habitacion thb)
        {
            bool guardado = false; //bandera
            int x = 0; //variable de control
            sb.Clear();
            sb.Append("USE hotel;");
            sb.Append("INSERT INTO tbl_habitacion");
            sb.Append("(numero, id_tipoHabitacion, estado)");
            sb.Append(" VALUES('" + thb.Numero + "','" + thb.Id_tipoHabitacion + "','" + 1 + "')");
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

        public Int32 DelHabitacion(Tbl_habitacion thb)
        {
            int eliminado;
            sb.Clear();
            sb.Append("USE hotel;");
            sb.Append("DELETE FROM tbl_habitacion WHERE id_tipoHabitacion=" + thb.Id_tipoHabitacion + ";");

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

        public bool existeHabitacion(Tbl_habitacion thb)
        {
            bool existe = false; //bandera
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE hotel;");
            sb.Append("SELECT * FROM tbl_habitacion WHERE numero=" + "'" + thb.Numero + "';");
            //sb.Append("AND id_tipoHabitacion=" + thb.Id_tipoHabitacion + ";");

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

        public ListStore BuscarHabitacion(String cadena)
        {
            ListStore datos = new ListStore(typeof(string), typeof(string), typeof(string));
            IDataReader dr = null;
            sb.Clear();
            sb.Append("USE hotel;");
            sb.Append("SELECT id_habitacion,numero,descripcion FROM VwHabitaciones ");
            sb.Append("WHERE (estado <>3) ");
            sb.Append("AND (numero like '%" + cadena + "%' ");
            sb.Append("OR descripcion like '%" + cadena + "%'); "); ;//Busca lo que coincida con la busqueda y los % son para especificar que no importa si hay algo antes o despues
            try
            {
                con.AbrirConexion();
                dr = con.Leer(CommandType.Text, sb.ToString());
                while (dr.Read())
                {
                    datos.AppendValues(dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
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
        }

        public ListStore ListarHabitacionesDisponibles(Tbl_detalleReserv tdr)
        {
            ListStore datos = new ListStore(typeof(string), typeof(string), typeof(string));
            IDataReader dr = null;
            sb.Clear();
            sb.Append("USE `hotel`;");
            sb.Append("SELECT h.id_habitacion, h.numero, h.descripcion FROM vw_habitaciones h LEFT JOIN "+
"tbl_detalleReserv d ON h.id_habitacion = d.id_habitacion WHERE NOT(concat('" +tdr.Fecha_entrada + "', ' ', '"+ tdr.Hora_entrada+":00')"+
"< concat(d.fecha_salida, ' ', d.hora_salida) AND concat('"+ tdr.Fecha_salida + "', ' ', '" + tdr.Hora_salida+ ":00') > concat(d.fecha_entrada, ' ', d.hora_entrada))"+
"OR NOT(SELECT EXISTS(SELECT * FROM tbl_detalleReserv d INNER JOIN tbl_reservacion r ON d.id_reservacion =" +
"r.id_reservacion WHERE r.estado <> 3 AND d.id_habitacion = h.id_habitacion));");

            try
            {
                con.AbrirConexion();
                dr = con.Leer(CommandType.Text, sb.ToString());
                while (dr.Read())
                {
                    datos.AppendValues(dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
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
            //return datos;
        }

        //fin del metodo
        #endregion

        public dtHabitaciones()
        {
        }
    }
}

