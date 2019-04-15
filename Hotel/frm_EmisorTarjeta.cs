using System;
using Hotel.entidades;
using Hotel.negocio;
using Hotel.datos;
using Gtk;
using System.Collections.Generic;

namespace Hotel
{
    public partial class frm_EmisorTarjeta : Gtk.Window
    {
        MessageDialog ms = null;
        dtEmisorTarjeta det = new dtEmisorTarjeta();
        ngEmisorTarjeta net = new ngEmisorTarjeta();
        Tbl_emisorTarjeta tet = null;
        bool edicion = false;
        public frm_EmisorTarjeta() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            listarEmisores();
        }

        public void listarEmisores()
        {
            List<Tbl_emisorTarjeta> listarEmisor = new List<Tbl_emisorTarjeta>();

            listarEmisor = det.ListaEmisorTarjeta();

            cbxEmisores.InsertText(0, "Seleccione...");


            foreach (Tbl_emisorTarjeta teet in listarEmisor)
            {
                cbxEmisores.InsertText(teet.Id_emisorTarjeta ,teet.Emisor);
            }
        }

        protected void OnBtnAgregarClicked(object sender, EventArgs e)
        {
            if (edicion)
            {
                tet = new Tbl_emisorTarjeta();
                tet.Emisor = txtEmisor.Text;

                //if()

                if (net.ExisteEmisorTarjeta(tet))
                {
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok,
                                               "Ya existe este emisor");
                    ms.Run();
                    ms.Destroy();

                }
                else
                {


                    if (det.ActualizarEmisorTarjeta(tet, cbxEmisores.ActiveText))
                    {
                        ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok,
                                               "Guardado exitosamente");
                        ms.Run();
                        ms.Destroy();
                    }
                    else
                    {
                        ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok,
                                               "Error al actualizar");
                        ms.Run();
                        ms.Destroy();
                    }
                }

            }
            else
            {

                if (txtEmisor.Text.Equals(""))
                {
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok,
                                           "Ingrese datos, por favor");
                    ms.Run();
                    ms.Destroy();
                }
                else
                {
                    tet = new Tbl_emisorTarjeta();
                    tet.Emisor = txtEmisor.Text;
                    
                    if(net.ExisteEmisorTarjeta(tet))
                    {
                        ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok,
                                               "Ya existe este emisor");
                        ms.Run();
                        ms.Destroy();
                    }
                    else
                    {
                        if(det.GuardarEmisorTarjeta(tet))
                        {
                            ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok,
                                                   "Guardado exitosamente");
                            ms.Run();
                            ms.Destroy();
                        }
                        else
                        {
                            ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok,
                                                   "Error al guardar");
                            ms.Run();
                            ms.Destroy();
                        }
                        
                        
                    }
            }
            }

            edicion = false;
            txtEmisor.Text = "";
            cbxEmisores.Clear();
            listarEmisores();
        }

        protected void OnBtnEditarClicked(object sender, EventArgs e)
        {
            if(!(cbxEmisores.Active == 0))
            {
                edicion = true;
                txtEmisor.Text = cbxEmisores.ActiveText;

            }
        }

        protected void OnBtnEliminarClicked(object sender, EventArgs e)
        {
            if (!(cbxEmisores.Active == 0))
            {

                tet = new Tbl_emisorTarjeta();
                tet.Emisor = cbxEmisores.ActiveText;

                if (det.EliminarEmisorTarjeta(tet))
                {
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok,
                                           "ELiminado exitosamente");
                    ms.Run();
                    ms.Destroy();
                }
                else
                {
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok,
                                           "Error al eliminar");
                    ms.Run();
                    ms.Destroy();
                }
            }
        }
    }
}
