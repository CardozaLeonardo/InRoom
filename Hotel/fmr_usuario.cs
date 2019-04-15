using System;
using Gtk;
using Hotel.entidades;
using Hotel.datos;
using Hotel.negocio;
namespace Hotel
{
    public partial class fmr_usuario : Gtk.Window
    {
        dtUsuario dtu = new dtUsuario();
        ngUsuario ngu = new ngUsuario();
        Tbl_user tus = new Tbl_user();


        public fmr_usuario() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();

        }
    }
}
