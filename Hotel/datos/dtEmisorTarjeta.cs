using System;
using System.Data;
using Gtk;
using System.Text;
using Hotel.entidades;
using Hotel.datos;
using System.Collections.Generic;

namespace Hotel.datos
{
    public class dtEmisorTarjeta
    {
        Conexion con = new Conexion();
        StringBuilder sb = new StringBuilder();
        MessageDialog ms = null;

        public bool GuardarEmisorTarjeta(Tbl_emisorTarjeta tet)
        {
            bool guardado = false;
            int x = 0;

            sb.Clear();
            sb.Append("USE `hotel`;");
            sb.Append("INSERT INTO tbl_emisorTarjeta");
            sb.Append("(emisor, estado)");
            sb.Append("Values('" + tet.Emisor + "', " + 1 + ");");
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

        public List<Tbl_emisorTarjeta> ListaEmisorTarjeta()
        {
            List<Tbl_emisorTarjeta> listEmisorTar = new List<Tbl_emisorTarjeta>();
            IDataReader idr = null;
            sb.Clear();
            sb.Append("Use `hotel`;");
            sb.Append("SELECT id_emisorTarjeta, emisor FROM tbl_emisorTarjeta WHERE estado <> '3';");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    Tbl_emisorTarjeta tet = new Tbl_emisorTarjeta()
                    {
                        Id_emisorTarjeta = (Int32)idr["id_emisorTarjeta"],
                        Emisor = idr["emisor"].ToString(),
                    };

                    listEmisorTar.Add(tet);

                }

                idr.Close();
                return listEmisorTar;
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

            return listEmisorTar;
        }

        public bool ActualizarEmisorTarjeta(Tbl_emisorTarjeta tet, String anterior)
        {
            bool actualizado = false;
            int x = 0;
            sb.Clear();
            sb.Append("USE `hotel`;");
            sb.Append("UPDATE tbl_emisorTarjeta SET emisor = '" + tet.Emisor + "', estado = 2 WHERE emisor = '" 
            + anterior + "';");

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

        public bool EliminarEmisorTarjeta(Tbl_emisorTarjeta tet)
        {
            int x = 0;
            bool eliminado = false;
            sb.Clear();
            sb.Append("USE `hotel`;");
            sb.Append("UPDATE tbl_emisorTarjeta SET estado = 3 WHERE emisor = '" + tet.Emisor + "';");

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

        public bool ExisteEmisorTarjeta(Tbl_emisorTarjeta tet)
        {
            bool existe = false;
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE `hotel`;");
            sb.Append("SELECT * FROM tbl_emisorTarjeta WHERE emisor = '" + tet.Emisor + "';");

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
        public dtEmisorTarjeta()
        {
        }
    }
}
