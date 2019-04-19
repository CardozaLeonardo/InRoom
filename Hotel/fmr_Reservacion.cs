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
        dtDetalleReserv ddr = new dtDetalleReserv();
        dtReservacion dtr = new dtReservacion();
        Tbl_reservacion tbr = new Tbl_reservacion();
        Vw_reservaciones vr = null;
        int id = 0;
        bool edicion = false;
        Tbl_huesped tbh = new Tbl_huesped();
        MessageDialog ms = null;

        public fmr_Reservacion() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            dtr = new dtReservacion();
            this.txtNum.Text = Convert.ToString(dtr.GetNumReserv() + 1);
            txtFecha.Text = ObtenerFecha();

        }

        public fmr_Reservacion(int id_reservacion) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            dtr = new dtReservacion();

            vr = dtr.ObtenerReservacion(id_reservacion);
            edicion = true;

            txtNum.Text = Convert.ToString(vr.Numero);
            txtFecha.Text = Convert.ToString(vr.Fecha);
            txtNombres.Text = vr.Nombres;
            txtApellidos.Text = vr.Apellidos;
            txtCedula.Text = vr.Cedula;



            //this.txtNum.Text = Convert.ToString(dtr.GetNumReserv() + 1);
            //txtFecha.Text = ObtenerFecha();
            
            CargarTabla(id_reservacion);
        }

        protected void OnBtnAgregarHabClicked(object sender, EventArgs e)
        {
            fmr_detalleReserv detalle = new fmr_detalleReserv(listaHabitaciones, this);
            //detalle.ParentSet(this.);
            //detalle.set
            detalle.Show();
        }

        public void ActualizarDatos()
        {
            //lbHuesped.Text = "Huesped: " + tbh.Cedula;
            txtNombres.Text = tbh.Nombres;
            txtApellidos.Text = tbh.Apellidos;
            txtCedula.Text = tbh.Cedula;
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

            foreach(Tbl_detalleReserv det in listaHabitaciones)
            {
                datos.AppendValues(Convert.ToString(det.Id_habitacion), det.Numero, det.TipoHabitacion,
                det.Fecha_entrada + " " + det.Hora_entrada, det.Fecha_salida + " " + det.Hora_salida);
            }

            twHabitaciones.Model = datos;

            string[] titulos = { "ID", "Numero", "Tipo", "Entrada", "Salida" };
            for (int i = 0; i < titulos.Length; i++)
            {
                twHabitaciones.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
        }

        public void CargarTabla(int id_reservacion)
        {
            List<Vw_detalleReserv> lista = ddr.listarDetallesReserv(id_reservacion);

            ListStore datos = new ListStore(typeof(string), typeof(string), typeof(string),
            typeof(string), typeof(string));

            foreach(Vw_detalleReserv vdr in lista)
            {
                datos.AppendValues(
                vdr.Id_habitacion,
                vdr.NumeroHab,
                vdr.Descripcion,
                vdr.FechaEntrada + " " + 
                vdr.HoraEntrada,
                vdr.FechaSalida + " " +
                vdr.HoraSalida);
            }

            twHabitaciones.Model = datos;

            string[] titulos = { "ID", "Numero", "Tipo", "Entrada", "Salida" };
            for (int i = 0; i < titulos.Length; i++)
            {
                twHabitaciones.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
        }

        protected void OnBtnGuardarClicked(object sender, EventArgs e)
        {
            tbr.Num_reserv = Convert.ToInt32(this.txtNum.Text);
            tbr.Id_huesped = tbh.Id_huesped;


            tbr.Fecha = ObtenerFecha();

            if(!txtCedula.Text.Equals(""))
            {

                if (dtr.GuardarReservacion(tbr))
                {
                    
                    id = dtr.GetIdReserv(tbr.Num_reserv);
                    
                    foreach(Tbl_detalleReserv dres in listaHabitaciones)
                    {
                        dres.Id_reservacion = id;
                    }
                    
                    if (ddr.GuardarDetalleReserv(listaHabitaciones))
                    {
                        ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok,
                                               "¡Reservación guardada!");
                        ms.Run();
                        ms.Destroy();
                        this.Hide();
                    }
                }
                else
                {
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok,
                                           "¡Error al guardar!");
                    ms.Run();
                    ms.Destroy();
                }
            }else
            {
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok,
                                               "Hace falta escoger el huésped");
                ms.Run();
                ms.Destroy();
            }
        }

        public String ObtenerFecha()
        {
            String fecha = "";
            DateTime dt = DateTime.Today;
            fecha += dt.Year.ToString();
            //int dia = dt.Day;

            if(dt.Month < 10)
            {
                fecha += "-0" + dt.Month.ToString();
            }
            else
            {
                fecha += "-" + dt.Month.ToString();
            }


            if (dt.Day < 10) 
            { 
               fecha += "-0" + dt.Day.ToString();

            }
            else
            {
                fecha += "-" + dt.Day;
            }
            return fecha;
        }

        protected void OnBtnRemoverHabClicked(object sender, EventArgs e)
        {
            bool encontrado = false;
            int index = -1;


            ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Question, ButtonsType.YesNo, 
                "¿Desea eliminar esta habitación?");

            int i = ms.Run();
            ms.Destroy();



            if(i == -8)
            {

                if (!txtNumHab.Text.Equals("") )
                {
                    if(!(listaHabitaciones.Count == 0))
                    {
                        ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok,
                                                   "No hay habitaciones");
                        ms.Run();
                        ms.Destroy();
                        return;
                    }

                    foreach (Tbl_detalleReserv tbdr in listaHabitaciones)
                    {
                        if(tbdr.Numero == Convert.ToString(txtNumHab.Text))
                        {
                            encontrado = true;
                            index = listaHabitaciones.IndexOf(tbdr);
                        }
                    }

                    if(encontrado)
                    {
                        listaHabitaciones.RemoveAt(index);
                        CargarTabla();
                    }
                }
            }

        }

        protected void OnBtnCancelarClicked(object sender, EventArgs e)
        {
            this.Hide();
        }

        protected void OnTwHabitacionesCursorChanged(object sender, EventArgs e)
        {
            TreeSelection seleccion = (sender as TreeView).Selection;
            TreeIter iter;
            TreeModel model;
            if (seleccion.GetSelected(out model, out iter))
            {

                txtNumHab.Text = model.GetValue(iter, 1).ToString();

            }
        }
    }
}
