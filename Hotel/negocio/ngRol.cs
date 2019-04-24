using System;
using Gtk;
using Hotel.entidades;
using Hotel.datos;

namespace Hotel.negocio
{
    public class ngRol
    {
        //Inicializar de forma global
        MessageDialog ms = null;
        dtRol dtr = new dtRol();

        #region metodos
        public bool ngGuardarRol(Tbl_rol tr)
        {
            bool guardado = false;
            try
            {
                if (dtr.existeRol(tr))
                {
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                        ButtonsType.Ok, "El rol ya existe!!! por favor intente con otro rol.");
                    ms.Run();
                    ms.Destroy();
                    return guardado;
                }
                else
                {
                    guardado = dtr.GuardarRol(tr);
                    if (guardado)
                    {
                        Console.WriteLine("NG: El rol se guardo exitosamente!!!");
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
        public ngRol()
        {
        }
    }
}
