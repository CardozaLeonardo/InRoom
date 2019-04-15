using System;
using Gtk;
using Hotel.entidades;
using Hotel.datos;

namespace Hotel.negocio
{
    public class ngUsuario
    {

        #region metodos
        public bool ngGuardarUser(Tbl_user tus)
        {
            MessageDialog ms = null;
            bool guardado = false;

            try
            {
                //bool existe = false;
                dtUsuario dtus = new dtUsuario();
                //existe = ;

                if(dtus.existeUser(tus))
                {
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, "El usuario ya existe!");
                    ms.Run();
                    ms.Destroy();
                    return guardado;
                }
                if (dtus.existeEmail(tus))
                {
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, "El correo ya existe!");
                    ms.Run();
                    ms.Destroy();
                    return guardado;
                }
                else
                {
                    guardado = dtus.GuardarUsuario(tus);
                    if(guardado)
                    {
                        Console.WriteLine("NG: EL usuario se guardo exitosamente");
                        return guardado;
                    }
                    else
                    {

                        return guardado;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("NG: Error: " + e.Message);
                Console.WriteLine("NG: Error: " + e.StackTrace);
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, "Por favor, verifique los datos nuevamente");
                ms.Run();
                ms.Destroy();
                Console.WriteLine("NG: ERROR, NO SE PUEDE GUARDAR");
                throw;
            }
        }

        public bool Autenticar(Tbl_user tus)
        {

            dtUsuario dtu = new dtUsuario();

            if(dtu.ComprobarCredenciales(tus))
            {
                return true;
            }

            return false;
        }
        #endregion
        public ngUsuario()
        {
        }
    }
}
