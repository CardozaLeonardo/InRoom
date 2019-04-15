using System;
using Gtk;
using Hotel.negocio;
using Hotel.entidades;
namespace Hotel
{
    public partial class fmr_login : Gtk.Window
    {
        ngUsuario ngu = new ngUsuario();
        Tbl_user user = new Tbl_user();
        MessageDialog ms = null;

        public fmr_login() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }

        public bool validarCampos()
        {
            if(txt_usuario.Text.Equals("") || txt_clave.Text.Equals(""))
            {
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok,
                "Por favor, ingreso los datos completos");
                ms.Run();
                ms.Destroy();
                return false;
            }
            else
            {
                return true;
            }
        }



        protected void OnBtnIngresarClicked(object sender, EventArgs e)
        {
            user.User = txt_usuario.Text;
            user.Pwd = txt_clave.Text;

            if(validarCampos())
            {

                if (ngu.Autenticar(user))
                {
                    MainWindow mw = new MainWindow();
                    mw.Show();
                    this.Hide();
                }
                else
                {
                    ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok,
                                           "Usuario o contraseña incorrecta");
                    ms.Run();
                    ms.Destroy();
                    
                    txt_clave.Text = "";
                }
            }


        }




    }
}
