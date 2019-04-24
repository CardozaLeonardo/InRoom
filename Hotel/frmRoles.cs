using System;
using Gtk;
using Hotel.entidades;
using Hotel.datos;
using Hotel.negocio;

namespace Hotel
{
    public partial class frmRoles : Gtk.Window
    {
        Tbl_rol tr = new Tbl_rol();
        dtRol dtr = new dtRol();
        ngRol ngr = new ngRol();
        MessageDialog ms = null;

        public frmRoles() :
            base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            tvwRoles.Model = dtr.ListarRoles();
            String[] Titulos = { "Id Rol", "Rol" };
            for (int i = 0; i < Titulos.Length; i++)
            {
                tvwRoles.AppendColumn(Titulos[i], new CellRendererText(), "text", i);
            }
        }

        public void limpiarCampos()
        {
            this.txtRol.Text = "";
        }

        protected void OnBtnCancelarClicked(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        protected void OnBtnGuardarClicked(object sender, EventArgs e)
        {
            tr.Rol = this.txtRol.Text;
            if (tr.Rol.Equals(""))
            {

                ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok, "Debe agregar el rol que desea guardar!!!");
                ms.Run();
                ms.Destroy();
            }
            else
            {
                if (ngr.ngGuardarRol(tr))
                {


                    ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Info, ButtonsType.Ok, "El rol fue guardado con exito!!!");
                    ms.Run();
                    ms.Destroy();
                    limpiarCampos();
                    tvwRoles.Model = dtr.ListarRoles();
                }
                else
                {
                    limpiarCampos();
                }
            }

        }

        protected void OnTvwRolesCursorChanged(object sender, EventArgs e)
        {
            TreeSelection seleccion = (sender as TreeView).Selection;
            TreeIter iter;
            TreeModel model;
            if (seleccion.GetSelected(out model, out iter))
            {
                tr.Id_rol = Convert.ToInt32(model.GetValue(iter, 0).ToString());
                this.txtRol.Text = model.GetValue(iter, 1).ToString();
            }
        }

        protected void OnBtnEliminarClicked(object sender, EventArgs e)
        {
            int eliminado = 0;
            eliminado = dtr.EliminarRol(tr);
            if (eliminado != 0)
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                            MessageType.Info, ButtonsType.Ok, "El rol fue eliminado con exito!!!");
                ms.Run();
                ms.Destroy();
                limpiarCampos();
                tvwRoles.Model = dtr.ListarRoles();
                tr.Id_rol = 0;
            }
            else
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                            MessageType.Error, ButtonsType.Ok, "Debe seleccionar el rol primero e intente nuevamente!!!");
                ms.Run();
                ms.Destroy();
            }
        }

        protected void OnBtnModificarClicked(object sender, EventArgs e)
        {
            tr.Rol = this.txtRol.Text;
            if (tr.Rol.Equals(""))
            {

                ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok, "Debe ingresar el campo del rol para modificar!!!");
                ms.Run();
                ms.Destroy();
            }
            else
            {
                tr.Estado = 2;

                if (dtr.ActualizarRol(tr))
                {

                    ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Info, ButtonsType.Ok, "El rol fue actualizado con éxito!!!");
                    ms.Run();
                    ms.Destroy();
                    limpiarCampos();
                    tvwRoles.Model = dtr.ListarRoles();
                }
                else
                {
                    ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Error, ButtonsType.Ok, "Error selecione el rol, revise los datos e intente nuevamente!!!");
                    ms.Run();
                    ms.Destroy();


                }
            }
        }

        protected void OnBtnBuscarClicked(object sender, EventArgs e)
        {
            String busqueda = "";
            busqueda = this.txtBuscarRol.Text.Trim();
            tvwRoles.Model = dtr.buscarRol(busqueda);
        }
    }
}
