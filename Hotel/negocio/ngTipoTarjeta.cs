﻿using System;
using Gtk;
using Hotel.entidades;
using Hotel.datos;
namespace Hotel.negocio
{
    public class ngTipoTarjeta
    {
        #region metodos
        public bool ngGuardarTipoTarj(Tbl_tipoTarjeta tTipotarj)
        {
            MessageDialog ms = null;
            bool guardado = false;
            try
            {
                //bool existe = false;
                dtTipoTarjeta dtTipotarj = new dtTipoTarjeta();
                //existe = dtus.existeUser(tus);

                //ttar = tabla tarjeta
                //dttar = datos tabla tarjeta

                guardado = dtTipotarj.GuardarTipoTarjeta(tTipotarj);
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

        public ngTipoTarjeta()
        {
        }
    }
}
