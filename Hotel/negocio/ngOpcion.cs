using System;
using Gtk;
using Hotel.entidades;
using Hotel.datos;
namespace Hotel.negocio
{
    public class ngOpcion
    {
        //Inicializar de forma global
        MessageDialog ms = null;
        dtOpcion dtop = new dtOpcion();

        #region metodos
        public bool ngGuardarOpcion(Tbl_opcion top)
        {
            bool guardado = false;
            try
            {
                if (dtop.existeOpcion(top))
                {
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                        ButtonsType.Ok, "La opcion de gestion ya existe!!! por favor intente con otra.");
                    ms.Run();
                    ms.Destroy();
                    return guardado;
                }
                else
                {
                    guardado = dtop.GuardarOpcion(top);
                    if (guardado)
                    {
                        Console.WriteLine("NG: La opcion de gestion se guardo exitosamente!!!");
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

        public ngOpcion()
        {
        }
    }
}
