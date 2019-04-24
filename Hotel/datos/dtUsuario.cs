using System;
using System.Data;
using MySql.Data;
using Gtk;
using System.Text;
using Hotel.entidades;
//using Hotel.datos;
using System.Collections.Generic;

namespace Hotel.datos
{
    public class dtUsuario
    {
        Conexion con = new Conexion();
        StringBuilder sb = new StringBuilder();
        MessageDialog ms = null;
        #region metodos
        public bool GuardarUsuario(Tbl_user tus)
        {
            bool guardado = false;
            int x = 0;
            sb.Append("INSERT INTO tbl_user");
            sb.Append("(user,pwd, nombres, apellidos, email, pwd_temp, estado)");
            sb.Append("Values('" + tus.User + "','" + tus.Pwd + "','" + tus.Nombres + "','" + tus.Apellidos + "','" + tus.Email + "','" + tus.Pwd_temp + "','" + 1 + "')");
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

        public ListStore ListarUsuarios()
        {
            ListStore datos = new ListStore(typeof(string),
                typeof(string), typeof(string), typeof(string), typeof(string));
            sb.Clear();
            IDataReader dr = null;
            sb.Append("SELECT id_user,user,nombres,apellidos,email FROM tbl_user where estado <> 3");
            try
            {
                con.AbrirConexion();
                dr = con.Leer(CommandType.Text, sb.ToString());
                while (dr.Read())
                {
                    datos.AppendValues(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(),
                    dr[3].ToString(), dr[4].ToString());
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

        public bool existeUser(Tbl_user tus)
        {
            bool existe = false;
            IDataReader idr = null;
            sb.Append("USE `hotel`;");
            sb.Append("SELECT * FROM tbl_user WHERE user = " + "'" + tus.User + "';");

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

        public int getIdUser(String user)
        {
            int existe = 0; //bandera
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE hotel;");
            sb.Append("SELECT id_user FROM tbl_user WHERE user=" + "'" + user + "';");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                if (idr.Read())
                {
                    existe = (Int32)idr["id_user"];
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

        public bool existeEmail(Tbl_user tus)
        {
            bool existe = false;
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE `hotel`;");
            sb.Append("SELECT * FROM tbl_user WHERE email = " + "'" + tus.Email + "';");

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

        public Int32 eliminarUser(Tbl_user tus)
        {
            int eliminado;
            sb.Clear();
            sb.Append("USE `hotel`;");
            sb.Append("UPDATE tbl_user SET estado = 3 WHERE id_user = " + tus.Id_user + "");

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

        public bool ActualizarUser(Tbl_user tus)
        {
            bool actualizado = false;
            int x = 0;
            sb.Clear();
            sb.Append("UPDATE tbl_user SET user = '" + tus.User + "',");
            sb.Append("pwd = '" + tus.Pwd + "',");
            sb.Append("nombres = '" + tus.Nombres + "',");
            sb.Append("apellidos = '" + tus.Apellidos + "',");
            sb.Append("email = '" + tus.Email + "',");
            sb.Append("estado = '" + tus.Estado + "'");
            sb.Append("WHERE id_user = " + tus.Id_user + ";");

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

        }

        public ListStore buscarUsuarios(String cadena)
        {
            ListStore datos = new ListStore(typeof(string),
                typeof(string), typeof(string), typeof(string), typeof(string));
            IDataReader dr = null;
            sb.Clear();
            sb.Append("USE hotel;");
            sb.Append("SELECT id_user,user,nombres,apellidos,email FROM tbl_user ");
            sb.Append("WHERE (estado <>3) ");
            sb.Append("AND (user like '%" + cadena + "%' ");
            sb.Append("OR nombres like '%" + cadena + "%' ");
            sb.Append("OR apellidos like '%" + cadena + "%'); ");
            try
            {
                con.AbrirConexion();
                dr = con.Leer(CommandType.Text, sb.ToString());
                while (dr.Read())
                {
                    datos.AppendValues(dr[0].ToString(), dr[1].ToString(),
                        dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
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



        public List<Tbl_user> cbxUsuarios()
        {
            List<Tbl_user> listUser = new List<Tbl_user>();
            IDataReader idr = null;
            sb.Clear();
            sb.Append("Use `hotel`;");
            sb.Append("SELECT id_user, user FROM tbl_user WHERE estado <> '3';");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    Tbl_user tus = new Tbl_user()
                    {
                        Id_user = (Int32)idr["id_user"],
                        User = idr["user"].ToString(),
                    };

                    listUser.Add(tus);

                }

                idr.Close();
                return listUser;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                con.CerrarConexion();
            }

            return listUser;
        }

        public bool ComprobarCredenciales(Tbl_user tus)
        {
            bool valido = false;
            IDataReader idr = null;
            //StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append("USE `hotel`;");
            sb.Append("SELECT * FROM tbl_user WHERE (estado <> 3) AND ((user = '" + tus.User + "' OR email ='" + tus.User+"') and pwd = '"
            + tus.Pwd + "');");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());

                if(idr.Read())
                {
                    valido = true;
                }

                return valido;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                idr.Close();
                return valido;
                throw;

            }
            finally
            {
                con.CerrarConexion();

            }


        }

        public bool VerificarPermiso(Tbl_user tus, String rol)
        {
            bool acceder = false;
            IDataReader idr = null;
            //StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append("USE `hotel`;");
            sb.Append("SELECT * FROM vw_usuarios WHERE id_user = " + tus.Id_user + " AND rol = '" + rol + "';");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());

                if (idr.Read())
                {
                    acceder = true;
                }

                return acceder;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                idr.Close();
                return acceder;
                throw;

            }
            finally
            {
                con.CerrarConexion();

            }


        }

        #endregion
        public dtUsuario()
        {
        }
    }
}