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
        MessageDialog ms = null;
        StringBuilder sb = new StringBuilder();

        #region metodos
        public bool GuardarTipoTarjeta(Tbl_tipoTarjeta ttar)
        {
            bool guardado = false;
            int x = 0;

            sb.Clear();
            sb.Append("USE `hotel`;");
            sb.Append("INSERT INTO tbl_tipoTarjeta");
            sb.Append("(id_tipoTarjeta, tipo_tarjeta)");
            sb.Append("Values('" + ttar.Id_tipoTarjeta + ttar.Tipo_tarjeta + "', " + 1 + ");");
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

        public List<Tbl_tipoTarjeta> ListaTipoTarjeta()
        {
            List<Tbl_tipoTarjeta> listTipoTar = new List<Tbl_tipoTarjeta>();
            IDataReader idr = null;
            sb.Clear();
            sb.Append("Use `hotel`;");
            sb.Append("SELECT id_tipoTarjeta,tipo_tarjeta FROM tbl_tipoTarjeta;");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    Tbl_tipoTarjeta ttar = new Tbl_tipoTarjeta()
                    {
                        Id_tipoTarjeta = (Int32)idr["id_tipoTarjeta"],
                        Tipo_tarjeta = idr["tipo_tarjeta"].ToString(),
                    };

                    listTipoTar.Add(ttar);

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

        public int getIdTipoTarjeta(String tipoTarjeta)
        {
            int existe = 0; //bandera
            IDataReader idr = null;
            sb.Clear();
            sb.Append("USE hotel;");
            sb.Append("SELECT id_tipoTarjeta FROM tbl_tipoTarjeta WHERE tipo_tarjeta=" + "'" + tipoTarjeta + "';");

            try
            {
                con.AbrirConexion();
                idr = con.Leer(CommandType.Text, sb.ToString());
                if (idr.Read())
                {
                    existe = (Int32)idr["id_tipoTarjeta"];
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

        #endregion

        public dtTipoTarjeta()
        {
        }
    }
}
