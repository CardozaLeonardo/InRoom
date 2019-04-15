using System;
using Gtk;
namespace Hotel
{
    public partial class frm_reservaciones : Gtk.Window
    {
        public frm_reservaciones() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }
    }
}
