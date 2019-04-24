using System;
using Gtk;
using Hotel.entidades;
using Hotel.datos;
namespace Hotel.negocio
{
    public class ngTipoHabitacion
    {
        //Inicializar de forma global
        MessageDialog ms = null;
        dtTipoHabitacciones dth = new dtTipoHabitacciones();

        #region metodos
        public bool ngGuardarTipoHabitacion(Tbl_tipoHabitacion tph)
        {
            bool guardado = false;
            try
            {
                if (dth.existeTipHabitacion(tph))
                {
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                        ButtonsType.Ok, "El tipo de habitacion ya existe!!! por favor intente con otro.");
                    ms.Run();
                    ms.Destroy();
                    return guardado;
                }
                else
                {
                    guardado = dth.GuardarTipHabitacion(tph);
                    if (guardado)
                    {
                        Console.WriteLine("NG: El tipo de habitacion se guardo exitosamente!!!");
                        return guardado;
                    }
                    else
                    {
                        ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                        ButtonsType.Ok, "Por favor verifique sus datos e intente nuevamente!!!");
                        ms.Run();
                        ms.Destroy();
                        Console.WriteLine("NG: ERROR AL GUARDAR, VERIFICAR EL METODO");
                        return guardado;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("NG: ERROR=" + e.Message);
                Console.WriteLine("NG: ERROR=" + e.StackTrace);
                throw;
                //return guardado;
            }

        }
        #endregion

        public ngTipoHabitacion()
        {
        }
    }
}
