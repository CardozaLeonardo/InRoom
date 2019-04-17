using System;
using System.Data;
using MySql.Data;
using Gtk;
using System.Text;
using Hotel.entidades;
//using Hotel.datos;

namespace Hotel.datos
{
    public class dtUsuario
    {
        Conexion con = new Conexion();

        #region metodos
        public bool GuardarUsuario(Tbl_user tus)
        {
            bool guardado = false;
            int x = 0;
            MessageDialog ms = null;
            StringBuilder sb = new StringBuilder();
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
            StringBuilder sb = new StringBuilder();
            MessageDialog ms = null;
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
            StringBuilder sb = new StringBuilder();
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

        public bool existeEmail(Tbl_user tus)
        {
            bool existe = false;
            IDataReader idr = null;
            StringBuilder sb = new StringBuilder();
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

        public int eliminarUser(Tbl_user tus)
        {
            int eliminado;
            //IDataReader idr = null;
            StringBuilder sb = new StringBuilder();
            MessageDialog ms = null;
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

        public bool ComprobarCredenciales(Tbl_user tus)
        {
            bool valido = false;
            IDataReader idr = null;
            StringBuilder sb = new StringBuilder();
            //sb.Append("USE `Hotel`;");
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
            StringBuilder sb = new StringBuilder();
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