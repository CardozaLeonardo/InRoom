using System;
using Gtk;
using Hotel.entidades;
using Hotel.datos;

namespace Hotel.negocio
{
    public class ngTarjeta
    {
        #region metodos
        public bool ngGuardarTarjeta(Tbl_tarjeta ttar)
        {
            MessageDialog ms = null;
            bool guardado = false;
            try
            {
                //bool existe = false;
                dtTarjeta dttar = new dtTarjeta();
                //existe = dtus.existeUser(tus);

                //ttar = tabla tarjeta
                //dttar = datos tabla tarjeta

                guardado = dttar.GuardarTarjeta(ttar);
                if (guardado)
                {
                    Console.WriteLine("NG: Tarjeta ingresada correctamente");
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
            catch (Exception e)
            {
                Console.WriteLine("NG: ERROR=" + e.Message);
                Console.WriteLine("NG: ERROR=" + e.StackTrace);
                throw;
            }

        }

        #endregion
        public ngTarjeta()
        {
        }
    }
}

