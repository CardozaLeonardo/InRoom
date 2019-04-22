using System;
using Gtk;
using Hotel.datos;
using Hotel.entidades;
using Hotel.negocio;
using System.Collections.Generic;

namespace Hotel
{
    public partial class frm_reservaciones : Gtk.Window
    {
        dtReservacion dtr = new dtReservacion();
        MessageDialog ms = null;
        Tbl_reservacion tbr = new Tbl_reservacion();
        bool columnas = false;
        public frm_reservaciones() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            LlenarTabla();
        }

        public void LlenarTabla()
        {
            twReservaciones.Model = dtr.ListarReservaciones();

            if (!columnas)
            {

                string[] titulos = { "ID", "Número", "Registrado", "Nombres", "Apellidos", "Cédula" , "Habitaciones"};
                for (int i = 0; i < titulos.Length; i++)
                {
                    twReservaciones.AppendColumn(titulos[i], new CellRendererText(), "text", i);
                }

                columnas = true;
            }
        }

        protected void OnTwReservacionesCursorChanged(object sender, EventArgs e)
        {
            TreeSelection seleccion = (sender as TreeView).Selection;
            TreeIter iter;
            TreeModel model;
            if (seleccion.GetSelected(out model, out iter))
            {
                tbr.Id_reservacion = Convert.ToInt32(model.GetValue(iter, 0).ToString());
                tbr.Num_reserv = Convert.ToInt32(model.GetValue(iter, 1).ToString());
                tbr.Fecha = model.GetValue(iter, 2).ToString();

                txtNum.Text = Convert.ToString(tbr.Num_reserv);
                txtFecha.Text = tbr.Fecha;
                txtNombres.Text = model.GetValue(iter, 3).ToString();
                txtApellidos.Text = model.GetValue(iter, 4).ToString();
                txtCedula.Text = model.GetValue(iter, 5).ToString();

            }
        }

        protected void OnBtnBuscarClicked(object sender, EventArgs e)
        {
            if(!txtBuscar.Text.Equals(""))
            {

                twReservaciones.Model = dtr.BuscarReservacion(txtBuscar.Text.Trim());
                
                if(!columnas)
                {
                    string[] titulos = { "ID", "Número", "Registrado", "Nombres", "Apellidos", "Cédula", "Habitaciones" };
                    for (int i = 0; i < titulos.Length; i++)
                    {
                        twReservaciones.AppendColumn(titulos[i], new CellRendererText(), "text", i);
                    }
                    columnas = true;
                }
            }

        }

        protected void OnBtnModificarClicked(object sender, EventArgs e)
        {
            int id = 0;
            id = dtr.GetIdReserv(Convert.ToInt32(txtNum.Text));

            fmr_Reservacion frm = new fmr_Reservacion(id);
            frm.Show();
        }

        protected void OnBtnFinalizarClicked(object sender, EventArgs e)
        {


            if(!txtNum.Text.Equals(""))
            {

                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Question, ButtonsType.YesNo,
                "¿Desea finalizar esta reservación?");
                int valor;
                valor = ms.Run();
                ms.Destroy();

                if (valor == -8)
                {
                    if(dtr.FinalizarReservacion(tbr))
                    {
                        ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok,
                    "¡Reservación finalizada!");
                        ms.Run();
                        ms.Destroy();

                        LlenarTabla();
                    }
                    else
                    {
                        ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok,
                    "Ha ocurrido un error");
                        ms.Run();
                        ms.Destroy();
                    }

                } 
            } //


        }
    }


}
