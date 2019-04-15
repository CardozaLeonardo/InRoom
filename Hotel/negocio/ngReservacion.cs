using System;
using Hotel.datos;
using Hotel.entidades;
using Gtk;

namespace Hotel.negocio
{
    public class ngReservacion
    {

        dtReservacion dtr = new dtReservacion();
        public bool VerificarNumReserv(Tbl_reservacion tbr)
        {
            bool existe = false;

            while (!existe)
            {
                if(dtr.ExisteNumReserv(tbr))
                {
                    tbr.Num_reserv++;
                }
                else
                {
                    if(dtr.GuardarReservacion(tbr))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return existe;
        }
        public ngReservacion()
        {
        }
    }
}
