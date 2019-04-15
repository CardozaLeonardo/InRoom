using System;
using Gtk;
using Hotel.datos;
using Hotel.entidades;

namespace Hotel.negocio
{

    public class ngTipoTarjeta
    {
        dtTipoTarjeta dtt = new dtTipoTarjeta();

        public bool ExisteTipoTarjeta(Tbl_tipoTarjeta ttt)
        {

            if (dtt.existeTipoTarjeta(ttt))
            {
                return true;
            }

            return false;
        }


        public ngTipoTarjeta()
        {
        }
    }
}
