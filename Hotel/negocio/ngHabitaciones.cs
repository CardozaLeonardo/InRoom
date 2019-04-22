using System;
using Gtk;
using Hotel.datos;
using Hotel.entidades;

namespace Hotel.negocio
{
    public class ngHabitaciones
    {
        dtHabitaciones dth = new dtHabitaciones();
        MessageDialog ms = null;

        public bool ComprobarDisponibilidadHab(Vw_detalleReserv vdr)
        {
            if(dth.VerificarHabDisponible(vdr))
            {
                return true;
            }
            else
            {
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok,
                    "La habitación " + vdr.NumeroHab + " estará ocupada en ese momento \n" +
                    "Presione \"Verificar\" antes de agregar habitación");
                ms.Run();
                ms.Destroy();

                return false;
            }
        }
        public ngHabitaciones()
        {
        }
    }
}
