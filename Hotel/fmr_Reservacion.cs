using System;
using System.Data;
using Hotel.datos;
using Gtk;
using Hotel.entidades;
using Hotel.negocio;
using System.Collections.Generic;

namespace Hotel
{
    public partial class fmr_Reservacion : Gtk.Window
    {
        List<Tbl_detalleReserv> listaHabitaciones = new List<Tbl_detalleReserv>();
        dtReservacion dtr;
        
        int id = 0;
        Tbl_huesped tbh = new Tbl_huesped();

        public fmr_Reservacion() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            dtr = new dtReservacion();
            this.txtNum.Text = Convert.ToString(dtr.GetNumReserv() + 1);
        }

        protected void OnBtnAgregarHabClicked(object sender, EventArgs e)
        {
            fmr_detalleReserv detalle = new fmr_detalleReserv(listaHabitaciones);
            //detalle.ParentSet(this.);
            //detalle.set
            detalle.Show();
        }

        public void ActualizarDatos()
        {
            lbHuesped.Text = "Huesped: " + tbh.Cedula;
        }

        protected void OnBtnElegirHuespedClicked(object sender, EventArgs e)
        {
            frm_huespedReserv fhr = new frm_huespedReserv(tbh, this);
            fhr.Show();
        }

        public void CargarTabla()
        {
            ListStore datos = new ListStore(typeof(string), typeof(string), typeof(string),
            typeof(string), typeof(string));

            //twHabitaciones.Model
            string[] titulos = { "ID", "Numero", "Tipo", "Entrada", "Salida" };
            for (int i = 0; i < titulos.Length; i++)
            {
                tvwusuarios.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
        }
    }
}
