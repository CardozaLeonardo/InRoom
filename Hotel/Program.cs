using System;
using Hotel.datos;
using Gtk;

namespace Hotel
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Application.Init();
            //MainWindow win = new MainWindow();
            //win.Show();
            fmr_login login = new fmr_login();
            login.Show();
            Conexion con = new Conexion();
            con.AbrirConexion();
            Application.Run();
        }
    }
}
