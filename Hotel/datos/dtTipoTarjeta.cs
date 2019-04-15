using System;
using System.Data;
using Gtk;
using System.Text;
using Hotel.entidades;
using Hotel.datos;
using System.Collections.Generic;

namespace Hotel.datos
{

    public class dtTipoTarjeta
    {
        Conexion con = new Conexion();
        StringBuilder sb = new StringBuilder();
        MessageDialog ms = null;

        public bool GuardarTipoTarjeta(Tbl_tipoTarjeta ttt)
        {
            bool guardado = false;
            int x = 0;

            sb.Clear();
            sb.Append("USE `hotel`;");
            sb.Append("INSERT INTO tbl_tipoTarjeta");
            sb.Append("(tipo_tarjeta, estado)");
            sb.Append("Values('" + ttt.Tipo_tarjeta + "', " + 1 + ");");
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

        public List<Tbl_tipoTarjeta> ListarTipoTarjeta()
        {
            List<Tbl_tipoTarjeta> listTipoTar = new List<Tbl_tipoTarjeta>();
            IDataReader idr = null;
            sb.Clear();
            sb.Append("Use `hotel`;");
            sb.Append("SELECT id_tipoTarjeta, tipo_tarjeta WHERE tbl_tipoTarjeta estado <> '3';");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    Tbl_tipoTarjeta ttt = new Tbl_tipoTarjeta()
                    {
                        Id_tipoTarjeta = (Int32)idr["id_tipoTarjeta"],
                        Tipo_tarjeta = idr["tipo_tarjeta"].ToString(),
                    };

                    listTipoTar.Add(ttt);

                }

                idr.Close();
                return listTipoTar;
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

            return listTipoTar;
        }

        public bool ActualizarTipoTarjeta(Tbl_tipoTarjeta ttt)
        {
            bool actualizado = false;
            int x = 0;
            sb.Clear();
            sb.Append("USE `hotel`;");
            sb.Append("UPDATE tbl_tipoTarjeta SET tipo_tarjeta = '" + ttt.Tipo_tarjeta + "', estado = 2 WHERE " +
            	"id_tipoTarjeta = "  + ttt.Id_tipoTarjeta + ";");

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

        public int EliminarTipoTarjeta(Tbl_tipoTarjeta ttt)
        {
            int eliminado;
            sb.Clear();
            sb.Append("USE `hotel`;");
            sb.Append("UPDATE tbl_tipoTarjeta SET estado = 3 WHERE id_tipoTarjeta = " + ttt.Id_tipoTarjeta + ";");

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
        }

        public bool existeTipoTarjeta(Tbl_tipoTarjeta ttt)
        {
            bool existe = false;
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE `Hotel`;");
            sb.Append("SELECT * FROM tbl_tipoTarjeta WHERE tipo_tarjeta = '" + ttt.Tipo_tarjeta + "';");

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


        public dtTipoTarjeta()
        {
        }
    }
}
