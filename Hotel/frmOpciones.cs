using System;
using Gtk;
using Hotel.entidades;
using Hotel.datos;
using Hotel.negocio;

namespace Hotel
{
    public partial class frmOpciones : Gtk.Window
    {
        Tbl_opcion top = new Tbl_opcion();
        dtOpcion dtop = new dtOpcion();
        ngOpcion ngop = new ngOpcion();
        MessageDialog ms = null;

        public frmOpciones() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            tvwOpcion.Model = dtop.ListarOpciones();
            String[] Titulos = { "Id Opcion", "Opcion" };
            for (int i = 0; i < Titulos.Length; i++)
            {
                tvwOpcion.AppendColumn(Titulos[i], new CellRendererText(), "text", i);
            }

        }


        public void limpiarCampos()
        {
            this.txtOpcion.Text = "";
        }

        protected void OnBtnCancelarClicked(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        protected void OnBtnGuardarClicked(object sender, EventArgs e)
        {
            top.Opcion = this.txtOpcion.Text;
            if (top.Opcion.Equals(""))
            {

                ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok, "Debe agregar la opcion de gestion que desea guardar!!!");
                ms.Run();
                ms.Destroy();
            }
            else
            {
                if (ngop.ngGuardarOpcion(top))
                {


                    ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Info, ButtonsType.Ok, "La opcion de gestion fue guardado con exito!!!");
                    ms.Run();
                    ms.Destroy();
                    limpiarCampos();
                    tvwOpcion.Model = dtop.ListarOpciones();
                }
                else
                {
                    limpiarCampos();
                }
            }
        }

        protected void OnTvwOpcionCursorChanged(object sender, EventArgs e)
        {
            TreeSelection seleccion = (sender as TreeView).Selection;
            TreeIter iter;
            TreeModel model;
            if (seleccion.GetSelected(out model, out iter))
            {
                top.Id_opcion = Convert.ToInt32(model.GetValue(iter, 0).ToString());
                this.txtOpcion.Text = model.GetValue(iter, 1).ToString();
            }
        }

        protected void OnBtnEliminarClicked(object sender, EventArgs e)
        {
            int eliminado = 0;
            eliminado = dtop.EliminarOpcion(top);
            if (eliminado != 0)
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                            MessageType.Info, ButtonsType.Ok, "La opcion de gestion fue eliminado con exito!!!");
                ms.Run();
                ms.Destroy();
                limpiarCampos();
                tvwOpcion.Model = dtop.ListarOpciones();
                top.Id_opcion = 0;
            }
            else
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                            MessageType.Error, ButtonsType.Ok, "Debe seleccionar la opcion de gestion primero e intente nuevamente!!!");
                ms.Run();
                ms.Destroy();
            }
        }

        protected void OnBtnModificarClicked(object sender, EventArgs e)
        {
            top.Opcion = this.txtOpcion.Text;
            if (top.Opcion.Equals(""))
            {

                ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok, "Debe ingresar el cambio de la opcion de gestion para modificar!!!");
                ms.Run();
                ms.Destroy();
            }
            else
            {
                top.Estado = 2;

                if (dtop.ActualizarOpcion(top))
                {

                    ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Info, ButtonsType.Ok, "La opcion de gestion fue actualizado con éxito!!!");
                    ms.Run();
                    ms.Destroy();
                    limpiarCampos();
                    tvwOpcion.Model = dtop.ListarOpciones();
                }
                else
                {
                    ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Error, ButtonsType.Ok, "Error selecione la opcion de gestion, revise los datos e intente nuevamente!!!");
                    ms.Run();
                    ms.Destroy();


                }
            }
        }

        protected void OnBtnBuscarClicked(object sender, EventArgs e)
        {
            String busqueda = "";
            busqueda = this.txtBuscar.Text.Trim();
            tvwOpcion.Model = dtop.buscarOpcion(busqueda);
        }
    }
}
