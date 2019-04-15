using System;
using System.Data;
using MySql.Data.MySqlClient;
using Gtk;
namespace Hotel.datos
{
    public class Conexion
    {
        #region atributos
        private string cadena = String.Empty;
        private MySqlConnection con { get; set; }
        private MySqlCommand sqlcommand { get; set; }
        private IDataReader idr { get; set; }
        #endregion

        #region metodos
        public string CadenaConexion()
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.Server = "localhost";
            sb.UserID = "root";
            sb.Database = "hotel";
            sb.Password = "leo12345";
            return sb.ConnectionString;
        }

        public void AbrirConexion()
        {
            MessageDialog ms = null;
            if (con.State == ConnectionState.Open)
            {
                return;
            }
            else
            {
                con.ConnectionString = cadena;
                try
                {
                    con.Open();
                    //ms = new MessageDialog(null, DialogFlags.Modal,
                    //MessageType.Info, ButtonsType.Ok, "Se abrio la conexion");
                    //ms.Run();
                    //ms.Destroy();

                }
                catch (Exception e)
                {
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, e.Message);

                    ms.Run();
                    ms.Destroy();
                    Console.WriteLine("Error" + e);
                }
            }

        }

        public void CerrarConexion()
        {
            if (con.State == ConnectionState.Closed)
            {
                return;
            }
            else
            {
                con.Close();
            }
        }

        public Int32 Ejecutar(CommandType ct, string consulta)
        {
            int retorno = 0;
            sqlcommand.Connection = con;
            sqlcommand.CommandType = ct;
            sqlcommand.CommandText = consulta;
            try
            {
                retorno = sqlcommand.ExecuteNonQuery();

            }
            catch
            {
                throw;
            }

            return retorno;
        }

        public IDataReader Leer(CommandType ct, string consulta)
        {
            idr = null;
            sqlcommand.Connection = con;
            sqlcommand.CommandType = ct;
            sqlcommand.CommandText = consulta;
            try
            {
                idr = sqlcommand.ExecuteReader();

            }
            catch
            {
                throw;
            }

            return idr;
        }
        #endregion

        #region constructor
        public Conexion()
        {
            cadena = CadenaConexion();
            con = new MySqlConnection();
            sqlcommand = new MySqlCommand();
        }
        #endregion
    }
}
