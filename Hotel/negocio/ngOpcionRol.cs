using System;
using Gtk;
using Hotel.entidades;
using Hotel.datos;

namespace Hotel.negocio
{
    public class ngOpcionRol
    {
        //Inicializar de forma global
        MessageDialog ms = null;
        dtOpcionRol dtor = new dtOpcionRol();

        #region metodos
        public bool ngGuardarOpcRol(Tbl_rolOption tor)
        {
            bool guardado = false;
            try
            {
                if (dtor.existeOpcRol(tor))
                {
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                        ButtonsType.Ok, "La opcion en el rol ya existe!!! por favor intente con otra.");
                    ms.Run();
                    ms.Destroy();
                    return guardado;
                }
                else
                {
                    guardado = dtor.GuardarOpcRol(tor);
                    if (guardado)
                    {
                        Console.WriteLine("NG: La opcion en el rol se guardo exitosamente!!!");
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

        public ngOpcionRol()
        {
        }
    }
}

