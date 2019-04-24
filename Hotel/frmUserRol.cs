using System;
using Gtk;
using System.Collections.Generic;
using Hotel.entidades;
using Hotel.datos;
namespace Hotel
{
    public partial class frmUserRol : Gtk.Window
    {
        Tbl_user tus = new Tbl_user();
        Tbl_rol tr = new Tbl_rol();
        Tbl_UserRol tur = new Tbl_UserRol();
        dtUsuario dtus = new dtUsuario();
        dtRol dtr = new dtRol();
        dtRolUser dtru = new dtRolUser();
        MessageDialog ms = null;

        public frmUserRol() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();

            //LLENAMOS LOS COMBOBOX
            llenarComboUser();
            //llenarComboRol();
            //POSICIONAMOS EL COMBO EN LA POSICION 0
            limpiarCombos();

            //LLENAMOS EL TREEVIEW
            this.tvwUserRol.Model = dtru.ListarUserRol();
            string[] titulos = { "IdUser", "User", "Nombres", "Apellidos", "IdRol", "Rol" };
            for (int i = 0; i < titulos.Length; i++)
            {
                this.tvwUserRol.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }

        }

        public void llenarComboUser()
        {

            List<Tbl_user> listarUsuarios = new List<Tbl_user>();
            listarUsuarios = dtus.cbxUsuarios();

            cbxUser.InsertText(0, "Seleccione...");

            foreach (Tbl_user tuser in listarUsuarios)
            {
                cbxUser.InsertText(tuser.Id_user, tuser.User);
            }

        }

        public void llenarComboRol()
        {

            List<Tbl_rol> listaRoles = new List<Tbl_rol>();
            listaRoles = dtr.cbxRol();

            this.cbxRol.InsertText(0, "Seleccione...");

            foreach (Tbl_rol trol in listaRoles)
            {
                this.cbxRol.InsertText(trol.Id_rol, trol.Rol);
            }

        }
        public void limpiarCombos()
        {
            //POSICIONAMOS EL COMBO EN LA POSICION 0
            this.cbxUser.Active = 0;
            this.cbxRol.Active = 0;
        }

        protected void OnBtnAsignarClicked(object sender, EventArgs e)
        {
            if (this.cbxUser.Active == 0 || this.cbxRol.Active == 0)
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Error, ButtonsType.Ok, "Todos los campos son requeridos!!!");
                ms.Run();
                ms.Destroy();
            }
            else
            {

                tur.Id_user = dtus.getIdUser(this.cbxUser.ActiveText);
                tur.Id_rol = dtr.getIdRol(this.cbxRol.ActiveText);
                if (dtru.existeUserRol(tur))
                {

                    ms = new MessageDialog(null, DialogFlags.Modal,
                           MessageType.Error, ButtonsType.Ok, "El rol ya está asignado a este usuario!!!");
                    ms.Run();
                    ms.Destroy();

                }
                else
                {
                    if (dtru.GuardarUserRol(tur))
                    {

                        ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Info, ButtonsType.Ok, "Se asignó el rol con exito!!!");
                        ms.Run();
                        ms.Destroy();
                        limpiarCombos();
                        this.tvwUserRol.Model = dtru.ListarUserRol();
                    }
                    else
                    {

                        ms = new MessageDialog(null, DialogFlags.Modal,
                            MessageType.Error, ButtonsType.Ok, "Selecciones los datos e intente nuevamente!!!");
                        ms.Run();
                        ms.Destroy();

                    }
                }


            }

        }

        protected void OnTvwUserRolCursorChanged(object sender, EventArgs e)
        {

            TreeSelection seleccion = (sender as TreeView).Selection;
            TreeIter iter;
            TreeModel model;
            if (seleccion.GetSelected(out model, out iter))
            {
                int i = 1; // contador // se usa para recorrer las posiciones del cbx
                while (true)
                {
                    this.cbxUser.Active = i;
                    if (this.cbxUser.ActiveText == model.GetValue(iter, 1).ToString())
                    {
                        break;
                    }
                    i++;
                }

                i = 1;
                while (true)
                {
                    this.cbxRol.Active = i;
                    if (this.cbxRol.ActiveText == model.GetValue(iter, 5).ToString())
                    {
                        break;
                    }
                    i++;
                }

            }
        }

        protected void OnBtnEliminarClicked(object sender, EventArgs e)
        {

            tur.Id_user = dtus.getIdUser(this.cbxUser.ActiveText);
            tur.Id_rol = dtr.getIdRol(this.cbxRol.ActiveText);

            if (dtru.delRolUser(tur) > 0)
            {

                ms = new MessageDialog(null, DialogFlags.Modal,
                MessageType.Info, ButtonsType.Ok, "Se eliminó el rol del usuario!!!");
                ms.Run();
                ms.Destroy();
                limpiarCombos();
                this.tvwUserRol.Model = dtru.ListarUserRol();
            }

            else
            {

                ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok, "Selecciones los datos e intente nuevamente!!!");
                ms.Run();
                ms.Destroy();

            }

        }

    }
}