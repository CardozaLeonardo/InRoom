using System;
using Gtk;
using Hotel.datos;
using Hotel.negocio;
using Hotel.entidades;
//using System.Windows.Forms;

namespace Hotel
{
    public partial class fmr_huespedes : Gtk.Window
    {
        dtHuesped dth = new dtHuesped();
        ngHuesped ngh = new ngHuesped();
        Tbl_huesped thu = new Tbl_huesped();
        MessageDialog ms = null;

        public fmr_huespedes() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            twHuesped.Model = dth.ListarHuespedes();
            string[] titulos = { "ID", "Nombres", "Apellidos", "Cédula", "Telefono", "Email" };
            for (int i = 0; i < titulos.Length; i++)
            {
                twHuesped.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
        }

        public void limpiarCampos()
        {
            this.txt_cedulaH.Text = "";
            this.txt_nombreH.Text = "";
            this.txt_apellidosH.Text = "";
            this.txt_emailH.Text = "";
            this.txt_telefonoH.Text = "";

        }

        public void ValidarLetras(Entry ent)
        {
            string cadena = ent.Text;
            int x;
            for (x = 0; x < cadena.Length; x++)
            {
                if (cadena[x] >= 'A' && cadena[x] <= 'Z' || cadena[x] >= 'a' && cadena[x] <= 'z' || cadena[x] == ' ')
                {
                } //Verifica que el caracter actual sea una letra mayúscula, minúscula o un espacio
                else
                    ent.Text = cadena.Substring(0, cadena.Length - 1); //Si no lo es, lo elimina
            }
        }

        public void ValidarNro(Entry ent)
        { //Valida que sólo sean números
            string cadena = ent.Text;
            int x;
            for (x = 0; x < cadena.Length; x++)
            { //Recorre el string del texto del Entry
                if (cadena[x] >= '0' && cadena[x] <= '9')
                {
                } //Si es un número, no hace nada
                else
                    ent.Text = cadena.Substring(0, cadena.Length - 1); //Si es una letra, la elimina
            }
        }


        protected void OnBtnCancelarHClicked(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        protected void OnBtnGuardarHClicked(object sender, EventArgs e)
        {
            thu.Nombres = this.txt_nombreH.Text;
            thu.Apellidos = this.txt_apellidosH.Text;
            thu.Email = this.txt_emailH.Text;
            thu.Cedula = this.txt_cedulaH.Text;
            thu.Telefono = this.txt_telefonoH.Text;


            if (thu.Nombres.Equals("") || thu.Apellidos.Equals("") || thu.Email.Equals("") || thu.Cedula.Equals("") || thu.Telefono.Equals(""))
            {

                ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok, "Todos los campos son requeridos");
                ms.Run();
                ms.Destroy();
            }
            else
            {
                if (ngh.ngGuardarHuesped(thu))
                {


                    ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Info, ButtonsType.Ok, "El huesped fue guardado con éxito");
                    ms.Run();
                    ms.Destroy();
                    limpiarCampos();
                    twHuesped.Model = dth.ListarHuespedes();
                }
            }

        }

        protected void OnTwHuespedCursorChanged(object sender, EventArgs e)
        {
            TreeSelection seleccion = (sender as TreeView).Selection;
            TreeIter iter;
            TreeModel model;
            if (seleccion.GetSelected(out model, out iter))
            {
                thu.Id_huesped = Convert.ToInt32(model.GetValue(iter, 0).ToString());
                this.txt_nombreH.Text = model.GetValue(iter, 1).ToString();
                this.txt_apellidosH.Text = model.GetValue(iter, 2).ToString();
                this.txt_cedulaH.Text = model.GetValue(iter, 3).ToString();
                this.txt_telefonoH.Text = model.GetValue(iter, 4).ToString();
                this.txt_emailH.Text = model.GetValue(iter, 5).ToString();
            }
        }

        protected void OnBtnEliminarClicked(object sender, EventArgs e)
        {
            int eliminado = 0;
            eliminado = dth.eliminarHuesped(thu);
            if (eliminado != 0)
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                            MessageType.Info, ButtonsType.Ok, "El huesped ha sido removido con exito");
                ms.Run();
                ms.Destroy();
                limpiarCampos();
                twHuesped.Model = dth.ListarHuespedes();
                thu.Id_huesped = 0;
            }
            else
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                            MessageType.Error, ButtonsType.Ok, "Seleccione el huesped e intente nuevamente");
                ms.Run();
                ms.Destroy();
            }
        }

        protected void OnBtnActualizarClicked(object sender, EventArgs e)
        {
            thu.Nombres = this.txt_nombreH.Text;
            thu.Apellidos = this.txt_apellidosH.Text;
            thu.Email = this.txt_emailH.Text;
            thu.Cedula = this.txt_cedulaH.Text;
            thu.Telefono = this.txt_telefonoH.Text;


            if (thu.Nombres.Equals("") || thu.Apellidos.Equals("") || thu.Email.Equals("") || thu.Cedula.Equals("") || thu.Telefono.Equals(""))
            {

                ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok, "Todos los campos son requeridos");
                ms.Run();
                ms.Destroy();
            }
            else
            {

                thu.Estado = 2;
                if (dth.ActualizarHuesped(thu))
                {

                    ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Info, ButtonsType.Ok, "El huesped fue actualizado con éxito");
                    ms.Run();
                    ms.Destroy();
                    limpiarCampos();
                    twHuesped.Model = dth.ListarHuespedes();
                }
                else
                {

                    ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Error, ButtonsType.Ok, "Error, selecione el huesped, revise los datos e intente de nuevo");
                    ms.Run();
                    ms.Destroy();


                }
            }

        }

        protected void OnBtnBuscarClicked(object sender, EventArgs e)
        {
            String busqueda = "";
            busqueda = this.txtbuscar.Text.Trim();
            twHuesped.Model = dth.buscarHuespedes(busqueda);
        }

        protected void OnTxtNombreHChanged(object sender, EventArgs e)
        {
            ValidarLetras(txt_nombreH);
        }

        protected void OnTxtApellidosHChanged(object sender, EventArgs e)
        {
            ValidarLetras(txt_apellidosH);
        }

        protected void OnTxtTelefonoHChanged(object sender, EventArgs e)
        {
            ValidarNro(txt_telefonoH);
        }
    }
}
