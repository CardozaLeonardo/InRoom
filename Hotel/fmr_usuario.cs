using System;
using Gtk;
using Hotel.datos;
using Hotel.negocio;
using Hotel.entidades;

namespace Hotel
{
    public partial class fmr_usuario : Gtk.Window
    {
        dtUsuario dtu = new dtUsuario();
        ngUsuario ngu = new ngUsuario();
        Tbl_user tus = new Tbl_user();
        MessageDialog ms = null;


        public fmr_usuario() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            twUsuario.Model = dtu.ListarUsuarios();
            string[] titulos = { "ID", "Usuario", "Nombres", "Apellidos", "Email" };
            for (int i = 0; i < titulos.Length; i++)
            {
                twUsuario.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
        }

        public void limpiarCampos()
        {
            this.txt_user.Text = "";
            this.txt_nombres.Text = "";
            this.txt_apellidos.Text = "";
            this.txt_email.Text = "";
            this.txt_contraseña.Text = "";
            this.txt_repContraseña.Text = "";
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

        protected void OnBtnCancelarClicked(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        protected void OnBtnGuardarClicked(object sender, EventArgs e)
        {
            tus.Nombres = this.txt_nombres.Text;
            tus.Apellidos = this.txt_apellidos.Text;
            tus.Email = this.txt_email.Text;
            tus.User = this.txt_user.Text;



            if (this.txt_contraseña.Text.Trim().Equals(this.txt_repContraseña.Text.Trim()))
            {
                tus.Pwd = this.txt_contraseña.Text;
                if (tus.Nombres.Equals("") || tus.Apellidos.Equals("") || tus.Email.Equals("") || tus.Pwd.Equals("") || tus.User.Equals(""))
                {

                    ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Error, ButtonsType.Ok, "Todos los campos son requeridos");
                    ms.Run();
                    ms.Destroy();
                }
                else
                {

                    if (ngu.ngGuardarUser(tus))
                    {


                        ms = new MessageDialog(null, DialogFlags.Modal,
                            MessageType.Info, ButtonsType.Ok, "El usuario fue guardado con éxito");
                        ms.Run();
                        ms.Destroy();
                        limpiarCampos();
                        twUsuario.Model = dtu.ListarUsuarios();
                    }
                }
            }
            else
            {

                ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Warning, ButtonsType.Ok, "Las contraseñas deben ser iguales");
                ms.Run();
                ms.Destroy();
            }
        }



        protected void OnTwUsuarioCursorChanged(object sender, EventArgs e)
        {
            TreeSelection seleccion = (sender as TreeView).Selection;
            TreeIter iter;
            TreeModel model;
            if (seleccion.GetSelected(out model, out iter))
            {
                tus.Id_user = Convert.ToInt32(model.GetValue(iter, 0).ToString());
                this.txt_user.Text = model.GetValue(iter, 1).ToString();
                this.txt_nombres.Text = model.GetValue(iter, 2).ToString();
                this.txt_apellidos.Text = model.GetValue(iter, 3).ToString();
                this.txt_email.Text = model.GetValue(iter, 4).ToString();
            }

        }
        protected void OnBtnEliminarClicked(object sender, EventArgs e)
        {
            int eliminado = 0;
            eliminado = dtu.eliminarUser(tus);
            if (eliminado != 0)
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                            MessageType.Info, ButtonsType.Ok, "El usuario ha sido eliminado con exito");
                ms.Run();
                ms.Destroy();
                limpiarCampos();
                twUsuario.Model = dtu.ListarUsuarios();
                tus.Id_user = 0;
            }
            else
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                            MessageType.Error, ButtonsType.Ok, "Seleccione el usuario e intente nuevamente");
                ms.Run();
                ms.Destroy();
            }
        }

        protected void OnBtnActualizarClicked(object sender, EventArgs e)
        {
            tus.Nombres = this.txt_nombres.Text;
            tus.Apellidos = this.txt_apellidos.Text;
            tus.Email = this.txt_email.Text;
            tus.User = this.txt_user.Text;

            if (this.txt_contraseña.Text.Trim().Equals(this.txt_repContraseña.Text.Trim()))
            {
                tus.Pwd = this.txt_contraseña.Text;
                if (tus.Nombres.Equals("") || tus.Apellidos.Equals("") || tus.Email.Equals("") || tus.Pwd.Equals("") || tus.User.Equals(""))
                {

                    ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Error, ButtonsType.Ok, "Todos los campos son requeridos");
                    ms.Run();
                    ms.Destroy();
                }
                else
                {
                    tus.Estado = 2;

                    if (dtu.ActualizarUser(tus))
                    {

                        ms = new MessageDialog(null, DialogFlags.Modal,
                            MessageType.Info, ButtonsType.Ok, "El usuario fue actualizado con éxito");
                        ms.Run();
                        ms.Destroy();
                        limpiarCampos();
                        twUsuario.Model = dtu.ListarUsuarios();
                    }
                    else
                    {

                        ms = new MessageDialog(null, DialogFlags.Modal,
                            MessageType.Error, ButtonsType.Ok, "Error selecione el usuario, revise los datos e intente de nuevo");
                        ms.Run();
                        ms.Destroy();


                    }
                }
            }
            else
            {

                ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Warning, ButtonsType.Ok, "Las contraseñas deben coincidir");
                ms.Run();
                ms.Destroy();
            }
        }

        protected void OnBtnBuscarClicked(object sender, EventArgs e)
        {
            String busqueda = "";
            busqueda = this.txtbuscar.Text.Trim();
            twUsuario.Model = dtu.buscarUsuarios(busqueda);
        }

        protected void OnTxtNombresChanged(object sender, EventArgs e)
        {
            ValidarLetras(txt_nombres);
        }

        protected void OnTxtApellidosChanged(object sender, EventArgs e)
        {
            ValidarLetras(txt_apellidos);
        }




    }
}
