using System;
using Gtk;
using Hotel.datos;
using Hotel.entidades;

namespace Hotel.negocio
{
    public class ngEmisorTarjeta
    {
        dtEmisorTarjeta det = new dtEmisorTarjeta();

        public bool ExisteEmisorTarjeta(Tbl_emisorTarjeta tet)
        {

            if (det.ExisteEmisorTarjeta(tet))
            {
                return true;
            }

            return false;
        }
        public ngEmisorTarjeta()
        {
        }
    }
}
