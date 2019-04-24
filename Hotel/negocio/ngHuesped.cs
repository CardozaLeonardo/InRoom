using System;
using Gtk;
using Hotel.entidades;
using Hotel.datos;

namespace Hotel.negocio
{
    public class ngHuesped
    {
        #region metodos
        public bool ngGuardarHuesped(Tbl_huesped thu)
        {
            MessageDialog ms = null;
            bool guardado = false;
            try
            {
                //bool existe = false;
                dtHuesped dthu = new dtHuesped();
                //existe = dtus.existeUser(tus);
                if (dthu.existeHuesped(thu))
                {
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                        ButtonsType.Ok, "El Huesped ingresado ya existe");
                    ms.Run();
                    ms.Destroy();
                    return guardado;
                }
                if (dthu.existeEmail(thu))
                {
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                        ButtonsType.Ok, "El correo electrónico ingresado ya existe");
                    ms.Run();
                    ms.Destroy();
                    return guardado;
                }
                else
                {
                    guardado = dthu.GuardarHuesped(thu);
                    if (guardado)
                    {
                        Console.WriteLine("NG: El Huesped se guardo exitosamente");
                        return guardado;
                    }
                    else
                    {
                        ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                        ButtonsType.Ok, "Por favor verifique sus datos e intente nuevamente");
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

        public ngHuesped()
        {
        }
    }
}
