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

        //public ListStore ListarHuespedes()
        //{
        //    ListStore datos = new ListStore(typeof(string),
        //        typeof(string), typeof(string), typeof(string), typeof(string), typeof(string));


        //    IDataReader dr = null;
        //    sb.Clear();
        //    sb.Append("USE `hotel`;");
        //    sb.Append("SELECT * FROM tbl_huesped WHERE estado <> 3;");
        //    try
        //    {
        //        con.AbrirConexion();
        //        dr = con.Leer(CommandType.Text, sb.ToString());
        //        while (dr.Read())
        //        {
        //            datos.AppendValues(dr[0].ToString(), dr[1].ToString(),
        //                dr[2].ToString(), dr[3].ToString(), dr[4].ToString(),
        //                dr[5].ToString());

        //            //dr.Close();
        //        }//fin de while
        //        return datos;
        //    }
        //    catch (Exception e)
        //    {
        //        ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
        //            ButtonsType.Ok, e.Message);
        //        ms.Run();
        //        ms.Destroy();
        //        throw;
        //    }
        //    finally
        //    {
        //        dr.Close();
        //        con.CerrarConexion();
        //    }
        //}

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

        public Int32 GetIdHuesped(String cedula)
        {
            IDataReader dr = null;
            int id = 0;
            sb.Clear();
            sb.Append("USE `hotel`;");
            sb.Append("SELECT id_huesped FROM tbl_huesped WHERE cedula = '" + cedula + "';");
            try
            {
                con.AbrirConexion();
                dr = con.Leer(CommandType.Text, sb.ToString());
                while (dr.Read())
                {
                    id = Convert.ToInt32(dr[0].ToString());

                    //dr.Close();
                }//fin de while
                return id;
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

        public bool GuardarHuesped(Tbl_huesped thu)
        {
            bool guardado = false;
            int x = 0;
            sb.Append("INSERT INTO tbl_huesped");
            sb.Append("(cedula, nombres, apellidos, telefono, email, estado)");
            sb.Append("Values('" + thu.Cedula + "','" + thu.Nombres + "','" + thu.Apellidos + "','" + thu.Telefono + "','" + thu.Email + "','" + 1 + "')");
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

        public ListStore ListarHuespedes()
        {
            ListStore datos = new ListStore(typeof(string),
                typeof(string), typeof(string), typeof(string), typeof(string), typeof(string));
            sb.Clear();
            IDataReader dr = null;
            sb.Append("SELECT id_huesped,nombres,apellidos,cedula,telefono,email FROM tbl_huesped where estado <> 3");
            try
            {
                con.AbrirConexion();
                dr = con.Leer(CommandType.Text, sb.ToString());
                while (dr.Read())
                {
                    datos.AppendValues(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(),
                    dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
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

        public bool existeHuesped(Tbl_huesped thu)
        {
            bool existe = false;
            IDataReader idr = null;
            sb.Append("USE `hotel`;");
            sb.Append("SELECT * FROM tbl_huesped WHERE cedula = " + "'" + thu.Cedula + "';");

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
                throw;
            }
            finally
            {
                con.CerrarConexion();
            }
        }

        public bool existeEmail(Tbl_huesped thu)
        {
            bool existe = false;
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE `hotel`;");
            sb.Append("SELECT * FROM tbl_huesped WHERE email = " + "'" + thu.Email + "';");

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
                throw;
            }
            finally
            {
                con.CerrarConexion();
            }
        }



        public int eliminarHuesped(Tbl_huesped thu)
        {
            //ACLARAR AQUI
            int eliminado;
            sb.Clear();
            sb.Append("USE `hotel`;");
            sb.Append("UPDATE tbl_huesped SET estado = 3 WHERE id_huesped = " + thu.Id_huesped + "");

            try
            {
                con.AbrirConexion();
                eliminado = con.Ejecutar(CommandType.Text, sb.ToString());
                Console.WriteLine(eliminado);
                Console.WriteLine(sb.ToString());

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
        }

        public bool ActualizarHuesped(Tbl_huesped thu)
        {
            bool actualizado = false;
            int x = 0;
            sb.Clear();
            sb.Append("UPDATE tbl_huesped SET nombres = '" + thu.Nombres + "',");
            sb.Append("cedula = '" + thu.Cedula + "',");
            sb.Append("apellidos = '" + thu.Apellidos + "',");
            sb.Append("telefono = '" + thu.Telefono + "',");
            sb.Append("email = '" + thu.Email + "',");
            sb.Append("estado = " + 2 + " ");
            sb.Append("WHERE id_huesped = " + thu.Id_huesped + ";");

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

        }

        public ListStore buscarHuespedes(String cadena)
        {
            ListStore datos = new ListStore(typeof(string),
                typeof(string), typeof(string), typeof(string), typeof(string), typeof(string));
            IDataReader dr = null;
            sb.Clear();
            sb.Append("USE hotel;");
            sb.Append("SELECT id_huesped,nombres,apellidos,cedula,telefono, email FROM tbl_huesped ");
            sb.Append("WHERE (estado <>3) ");
            sb.Append("AND (nombres like '%" + cadena + "%' ");
            sb.Append("OR apellidos like '%" + cadena + "%' ");
            sb.Append("OR cedula like '%" + cadena + "%' ");
            sb.Append("OR email like '%" + cadena + "%'); ");
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

        public dtHuesped()
        {
        }
    }
}
