using System;
using Gtk;
using Hotel.datos;
using Hotel.entidades;
using Hotel.negocio;
using System.Collections.Generic;

namespace Hotel
{
    public partial class fmr_detalleReserv : Gtk.Window
    {
        dtHabitaciones dth = new dtHabitaciones();
        List<Vw_detalleReserv> lista = null;
        Vw_detalleReserv tbr = new Vw_detalleReserv();
        MessageDialog ms = null;
        fmr_Reservacion form = null;
        dtDetalleReserv dtr = new dtDetalleReserv();
        bool edicion = false;


        public fmr_detalleReserv() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            LlenarTabla();

        }


        public fmr_detalleReserv(Vw_detalleReserv vdr, fmr_Reservacion frm) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            //LlenarTabla();
            tbr = vdr;
            edicion = true;
            form = frm;

        }


        public fmr_detalleReserv(List<Vw_detalleReserv> list, fmr_Reservacion frm) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            lista = list;
            form = frm;

            //LlenarTabla();
        }

        protected void OnBtnFijarEntradaClicked(object sender, EventArgs e)
        {
            //String year = "";
            String mes = "";
            String dia = "";

            int month = calen.Month;
            month++;

            //if (calen.Year < 10)
            //{
            //    year = "0" + calen.Year.ToString();
            //}

            if (month < 10)
            {
                //mes =  calen.Month.ToString();
                mes = "0" + Convert.ToString(month);
            }
            else
            {
                mes = Convert.ToString(month);
            }

            if (calen.Day < 10)
            {
                dia = "0" + calen.Day.ToString();
            }
            else
            {
                dia = calen.Day.ToString();
            }


            txt_fechaEntrada.Text = calen.Year.ToString() + "-" + mes + "-"
            + dia;
        }

        protected void OnBtnFijarSalidaClicked(object sender, EventArgs e)
        {
            //int dia = Convert.ToInt32(salida_hora.Text);
            //int mes = Convert.ToInt32(salida_minuto.Text);
            String year ="";
            String mes ="";
            String dia ="";

            int month = calen.Month;
            month++;

            //if (calen.Year < 10)
            //{
            //    year = "0" + calen.Year.ToString();
            //}

            if (month < 10)
            {
                //mes =  calen.Month.ToString();
                mes = "0" + Convert.ToString(month);
            }
            else
            {
                mes = Convert.ToString(month);
            }

            if (calen.Day < 10)
            {
                dia = "0" + calen.Day.ToString();
            }
            else
            {
                dia = calen.Day.ToString();
            }



            txt_fechaSalida.Text = calen.Year.ToString() + "-" + mes + "-"
            + dia;
        }

        protected void OnBtnCancelarClicked(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void LlenarTabla()
        {
            twHabitaciones.Model = dth.ListarHabitaciones();
            string[] titulos = { "ID", "Numero", "Tipo" };
            for (int i = 0; i < titulos.Length; i++)
            {
                twHabitaciones.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
        }

        public void LlenarTabla(ListStore lista)
        {
            twHabitaciones.Model = lista;
            string[] titulos = { "ID", "Numero", "Tipo" };
            for (int i = 0; i < titulos.Length; i++)
            {
                twHabitaciones.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
        }

        protected void OnBtnVerificarClicked(object sender, EventArgs e)
        {
            tbr = new Vw_detalleReserv();

            int hora_salida = Convert.ToInt32(salida_hora.Text);
            int minuto_salida = Convert.ToInt32(salida_minuto.Text);
            int hora_entrada = Convert.ToInt32(entrada_hora.Text);
            int minuto_entrada = Convert.ToInt32(entrada_minuto.Text);
            String hora_s;
            String minuto_s;
            String hora_e;
            String minuto_e;

            if(!ValidarEleccion())
            {
                return;
            }

            if (hora_salida < 10)
            {
                hora_s = "0" + salida_hora.Text;
            }
            else
            {
                hora_s = salida_hora.Text;
            }

            if (minuto_salida < 10)
            {
                minuto_s = "0" + salida_minuto.Text;
            }
            else
            {
                minuto_s = salida_minuto.Text;
            }



            if (hora_entrada < 10)
            {
                hora_e = "0" + entrada_hora.Text;
            }
            else
            {
                hora_e = entrada_hora.Text;
            }

            if (minuto_entrada < 10)
            {
                minuto_e = "0" + entrada_minuto.Text;
            }
            else
            {
                minuto_e = entrada_minuto.Text;
            }

            tbr.FechaEntrada = txt_fechaEntrada.Text;
            tbr.FechaSalida = txt_fechaSalida.Text;
            tbr.HoraEntrada = hora_e + ":" + minuto_e;
            tbr.HoraSalida = hora_s + ":" + minuto_s;

            //ListStore lista = dth.ListarHabitacionesDisponibles(tdr);

            //LlenarTabla(lista);


            twHabitaciones.Model = dth.ListarHabitacionesDisponibles(tbr);
            string[] titulos = { "ID", "Numero", "Tipo" };
            for (int i = 0; i < titulos.Length; i++)
            {
                twHabitaciones.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
        }

        public bool ValidarEleccion()
        {
            if(this.txt_fechaEntrada.Text.Equals("") || this.txt_fechaSalida.Text.Equals(""))
            {
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok,
                "Por favor, inserte valores");
                ms.Run();
                ms.Destroy();
                return false;
            }

            String entrada = txt_fechaEntrada.Text;
            String salida = txt_fechaSalida.Text;
            String[] entrada_parts = entrada.Split('-');
            String[] salida_parts = salida.Split('-');

            int year = Convert.ToInt32(entrada_parts[0]);
            int mes = Convert.ToInt32(entrada_parts[1]);
            int dia = Convert.ToInt32(entrada_parts[2]);
            int hora = Convert.ToInt32(entrada_hora.Text);
            int minutos = Convert.ToInt32(entrada_minuto.Text);

            DateTime hoy = DateTime.Today;
            DateTime ent = new DateTime(year, mes, dia, hora, minutos, 0);

            year = Convert.ToInt32(salida_parts[0]);
            mes = Convert.ToInt32(salida_parts[1]);
            dia = Convert.ToInt32(salida_parts[2]);
            hora = Convert.ToInt32(salida_hora.Text);
            minutos = Convert.ToInt32(salida_minuto.Text);

            DateTime sal = new DateTime(year, mes, dia, hora, minutos, 0);

            if((ent < hoy) || (sal<hoy))
            {
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok,
                "Elija la fecha correctamente, ya pasó esa fecha");
                ms.Run();
                ms.Destroy();
                return false;
            }

            if((ent == sal) || (sal < ent))
            {
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok,
                "Las fecha en salida no puede ser anterior o igual a la fecha de entrada");
                ms.Run();
                ms.Destroy();
                return false;
            }

            return true;
        }

        protected void OnTwHabitacionesCursorChanged(object sender, EventArgs e)
        {
            tbr = new Vw_detalleReserv();
            TreeSelection seleccion = (sender as TreeView).Selection;
            TreeIter iter;
            TreeModel model;

            if (seleccion.GetSelected(out model, out iter))
            {
                tbr.Id_habitacion = Convert.ToInt32(model.GetValue(iter, 0).ToString());
                tbr.NumeroHab = model.GetValue(iter, 1).ToString();
                tbr.Descripcion = model.GetValue(iter, 2).ToString();
                txtHab.Text = tbr.NumeroHab;
            }
        }

        protected void OnBtnAceptarClicked(object sender, EventArgs e)
        {
            if(!txtHab.Text.Equals(""))
            {
                int hora_salida = Convert.ToInt32(salida_hora.Text);
                int minuto_salida = Convert.ToInt32(salida_minuto.Text);
                int hora_entrada = Convert.ToInt32(entrada_hora.Text);
                int minuto_entrada = Convert.ToInt32(entrada_minuto.Text);
                String hora_s;
                String minuto_s;
                String hora_e;
                String minuto_e;

                if (!ValidarEleccion())
                {
                    return;
                }

                if (hora_salida < 10)
                {
                    hora_s = "0" + salida_hora.Text;
                }
                else
                {
                    hora_s = salida_hora.Text;
                }

                if (minuto_salida < 10)
                {
                    minuto_s = "0" + salida_minuto.Text;
                }
                else
                {
                    minuto_s = salida_minuto.Text;
                }



                if (hora_entrada < 10)
                {
                    hora_e = "0" + entrada_hora.Text;
                }
                else
                {
                    hora_e = entrada_hora.Text;
                }

                if (minuto_entrada < 10)
                {
                    minuto_e = "0" + entrada_minuto.Text;
                }
                else
                {
                    minuto_e = entrada_minuto.Text;
                }

                tbr.FechaEntrada = txt_fechaEntrada.Text;
                tbr.FechaSalida = txt_fechaSalida.Text;
                tbr.HoraEntrada = hora_e + ":" + minuto_e;
                tbr.HoraSalida = hora_s + ":" + minuto_s;

                tbr.Indicador = true;

                lista.Add(tbr);
                form.CargarTabla();
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok,
                "¡Habitación agregada!");
                ms.Run();
                ms.Destroy();
                this.Hide();
            }
        }
    }
}
