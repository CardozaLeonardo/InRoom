using System;
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
            sb.Append("(" + tbr.Num_reserv + ",'" + tbr.Fecha + "'," + tbr.Id_huesped + "," + 1 + ");");

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

        public Int32 GetIdReserv(int num)
        {
            IDataReader idr = null;
            int id = 2;
            sb.Clear();
            sb.Append("Use `hotel`;");
            sb.Append("SELECT id_reservacion FROM tbl_reservacion WHERE num_reserv = " + num + ";");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                if (idr.Read())
                {
                    id = (Int32)idr["id_reservacion"];
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
        }

        public bool FinalizarReservacion(Tbl_reservacion tbr)
        {
            bool eliminado = true;
            int x = 0;

            sb.Clear();
            sb.Append("USE `hotel`;");
            sb.Append("UPDATE tbl_reservacion SET estado = 3 WHERE id_reservacion = " + tbr.Id_reservacion + ";");

            try
            {
                con.AbrirConexion();
                x = con.Ejecutar(CommandType.Text, sb.ToString());

                if (x > 0)
                {
                    eliminado = true;
                }

                return eliminado;
            }
            catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok,
                "Ha ocurrido un error eliminar guardar el registro");
                ms.Run();
                ms.Destroy();
                throw;
            }
            finally
            {
                con.CerrarConexion();
            }
        }

        public bool ActualizarReservacion(Tbl_reservacion tbr)
        {
            bool actualizado = true;
            int x = 0;

            sb.Clear();
            sb.Append("USE `hotel`;");
            sb.Append("UPDATE tbl_reservacion SET num_reserv = " + tbr.Num_reserv + ", id_huesped = " + tbr.Id_huesped
            + ", fecha = '" + tbr.Fecha + "', estado = 2 WHERE id_reservacion = " + tbr.Id_reservacion + ";");

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
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok,
                "Ha ocurrido un error eliminar guardar el registro");
                ms.Run();
                ms.Destroy();
                throw;
            }
            finally
            {
                con.CerrarConexion();
            }
        }

        public ListStore ListarReservaciones()
        {
            ListStore datos = new ListStore(typeof(string),
                typeof(string), typeof(string), typeof(string), typeof(string), typeof(string),
                typeof(string));


            IDataReader dr = null;
            sb.Clear();
            sb.Append("USE `hotel`;");
            sb.Append("SELECT * FROM vw_reservaciones;");
            try
            {
                con.AbrirConexion();
                dr = con.Leer(CommandType.Text, sb.ToString());
                while (dr.Read())
                {
                    datos.AppendValues(dr[0].ToString(), dr[1].ToString(),
                        dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
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


        public ListStore ListarReservaciones(int id_reservacion)
        {
            ListStore datos = new ListStore(typeof(string),
                typeof(string), typeof(string), typeof(string), typeof(string), typeof(string),
                typeof(string));


            IDataReader dr = null;
            sb.Clear();
            sb.Append("USE `hotel`;");
            sb.Append("SELECT * FROM vw_reservaciones WHERE id_reservacion = " + id_reservacion + ";");
            try
            {
                con.AbrirConexion();
                dr = con.Leer(CommandType.Text, sb.ToString());
                while (dr.Read())
                {
                    datos.AppendValues(dr[0].ToString(), dr[1].ToString(),
                        dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
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

        public ListStore BuscarReservacion(String cadena)
        {
            ListStore datos = new ListStore(typeof(string),
                typeof(string), typeof(string), typeof(string), typeof(string), typeof(string),
                typeof(string));


            IDataReader dr = null;
            sb.Clear();
            sb.Append("USE `hotel`;");
            sb.Append("SELECT * FROM vw_reservaciones WHERE");
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
                        dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
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

        public Vw_reservaciones ObtenerReservacion(int id_reservacion)
        {
            IDataReader dr = null;
            Vw_reservaciones wr = new Vw_reservaciones();
            sb.Clear();
            sb.Append("SELECT * FROM vw_reservaciones WHERE id_reservacion = " + id_reservacion + ";");
            try
            {
                con.AbrirConexion();
                dr = con.Leer(CommandType.Text, sb.ToString());
                if (dr.Read())
                {


                    wr.Id_reservaciones = Convert.ToInt32(dr[0].ToString());
                    wr.Numero = Convert.ToInt32(dr[1].ToString());
                    wr.Fecha = dr[2].ToString();
                    wr.Nombres = dr[3].ToString();
                    wr.Apellidos = dr[4].ToString();
                    wr.Cedula = dr[5].ToString();
                    wr.Habitaciones = Convert.ToInt32(dr[6].ToString());
                    //dr.Close();
                }//fin de while
                return wr;
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
        public dtReservacion()
        {
        }
    }
}
