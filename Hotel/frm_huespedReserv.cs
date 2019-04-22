using System;
using Gtk;
using Hotel.datos;
using Hotel.entidades;
using Hotel.negocio;
using System.Collections.Generic;

namespace Hotel
{
    public partial class frm_huespedReserv : Gtk.Window
    {
        dtHuesped dth = new dtHuesped();
        MessageDialog ms = null;
        Tbl_huesped tbh = null;
        fmr_Reservacion form = null;
        bool columnas = false;

        public frm_huespedReserv() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }

        public frm_huespedReserv(Tbl_huesped huesped, fmr_Reservacion fmr) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            tbh = huesped;
            form = fmr;
        }

        protected void OnBtnBuscarClicked(object sender, EventArgs e)
        {
            if(!this.txtBuscar.Text.Equals(""))
            {
                CargarTabla(this.txtBuscar.Text.Trim());

            }
        }

        public void CargarTabla(String busqueda)
        {
            twHuesped.Model = dth.BuscarHuesped(busqueda);

            if (!columnas)
            {

                string[] titulos = { "ID", "Cédula",  "Nombres", "Apellidos", "Telefono", "Email" };
                for (int i = 0; i < titulos.Length; i++)
                {
                    twHuesped.AppendColumn(titulos[i], new CellRendererText(), "text", i);
                }

                columnas = true;
            }
        }

        protected void OnBtnAgregarClicked(object sender, EventArgs e)
        {
            if(!txtCedula.Text.Equals(""))
            {
                form.ActualizarDatos();

                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok,
                "¡Huésped agregado!");
                ms.Run();
                ms.Destroy();

                this.Hide();
            }


        }

        protected void OnTwHuespedCursorChanged(object sender, EventArgs e)
        {
            TreeSelection seleccion = (sender as TreeView).Selection;
            TreeIter iter;
            TreeModel model;
            if (seleccion.GetSelected(out model, out iter))
            {
                tbh.Id_huesped = Convert.ToInt32(model.GetValue(iter, 0).ToString());
                tbh.Cedula = model.GetValue(iter, 1).ToString();
                tbh.Nombres = model.GetValue(iter, 2).ToString();
                tbh.Apellidos = model.GetValue(iter, 3).ToString();
                tbh.Telefono = model.GetValue(iter, 4).ToString();
                tbh.Email = model.GetValue(iter, 5).ToString();

                txtNombres.Text = tbh.Nombres;
                txtApellidos.Text = tbh.Apellidos;
                txtCedula.Text = tbh.Cedula;

                //tus.Id_user = Convert.ToInt32(model.GetValue(iter, 0).ToString());
                //this.txtusuario.Text = model.GetValue(iter, 1).ToString();
                //this.txtnombres.Text = model.GetValue(iter, 2).ToString();
                //this.txtapellidos.Text = model.GetValue(iter, 3).ToString();
                //this.txtemail.Text = model.GetValue(iter, 4).ToString();
            }
        }

        protected void OnBtnCancelarClicked(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
