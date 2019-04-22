using System;
using Gtk;
using Hotel.datos;
using Hotel.entidades;
using System.Collections.Generic;

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

        public bool ComprobarDisponibilidadHab(List<Vw_detalleReserv> list)
        {
            bool valido = true;

            foreach(Vw_detalleReserv vdr in list)
            {
                if(vdr.Indicador)
                {
                    if(!dth.VerificarHabDisponible(vdr))
                    {
                        ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok,
                    "La habitación " + vdr.NumeroHab + " estará ocupada en ese momento \n" +
                    "Registro cancelado.");
                        ms.Run();
                        ms.Destroy();

                        valido = false;
                        return false;
                    }
                }
            }

            return valido;
        }
        public ngHabitaciones()
        {
        }
    }
}
