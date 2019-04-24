using System;
using Gtk;
using Hotel.entidades;
using Hotel.datos;
using Hotel.negocio;
namespace Hotel
{
    public partial class frmTipoHabitaciones : Gtk.Window
    {
        Tbl_tipoHabitacion tph = new Tbl_tipoHabitacion();
        dtTipoHabitacciones dth = new dtTipoHabitacciones();
        ngTipoHabitacion ngh = new ngTipoHabitacion();
        MessageDialog ms = null;

        public frmTipoHabitaciones() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            tvwTipHabitacion.Model = dth.ListarTipHabitacion();
            String[] Titulos = { "Id Tipo Habitacion", "Descripcion" };
            for (int i = 0; i < Titulos.Length; i++)
            {
                tvwTipHabitacion.AppendColumn(Titulos[i], new CellRendererText(), "text", i);
            }
        }

        public void limpiarCampos()
        {
            this.txtDescripHab.Text = "";
        }

        protected void OnBtnCancelarClicked(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        protected void OnBtnGuardarClicked(object sender, EventArgs e)
        {
            tph.Descripcion = this.txtDescripHab.Text;
            if (tph.Descripcion.Equals(""))
            {

                ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok, "Debe agregar la descripcion que desea guardar!!!");
                ms.Run();
                ms.Destroy();
            }
            else
            {
                if (ngh.ngGuardarTipoHabitacion(tph))
                {


                    ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Info, ButtonsType.Ok, "El tipo de Habitacion fue guardado con exito!!!");
                    ms.Run();
                    ms.Destroy();
                    limpiarCampos();
                    tvwTipHabitacion.Model = dth.ListarTipHabitacion();
                }
                else
                {
                    limpiarCampos();
                }
            }
        }

        protected void OnTvwTipHabitacionCursorChanged(object sender, EventArgs e)
        {
            TreeSelection seleccion = (sender as TreeView).Selection;
            TreeIter iter;
            TreeModel model;
            if (seleccion.GetSelected(out model, out iter))
            {
                tph.Id_tipoHabitacion = Convert.ToInt32(model.GetValue(iter, 0).ToString());
                this.txtDescripHab.Text = model.GetValue(iter, 1).ToString();
            }
        }

        protected void OnBtnEliminarClicked(object sender, EventArgs e)
        {
            int eliminado = 0;
            eliminado = dth.EliminarTipHabitacion(tph);
            if (eliminado != 0)
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                            MessageType.Info, ButtonsType.Ok, "El tipo de Habitacion fue eliminado con exito!!!");
                ms.Run();
                ms.Destroy();
                limpiarCampos();
                tvwTipHabitacion.Model = dth.ListarTipHabitacion();
                tph.Id_tipoHabitacion = 0;
            }
            else
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                            MessageType.Error, ButtonsType.Ok, "Debe seleccionar el tipo de habitacion primero e intente nuevamente!!!");
                ms.Run();
                ms.Destroy();
            }
        }

        protected void OnBtnModificarClicked(object sender, EventArgs e)
        {
            tph.Descripcion = this.txtDescripHab.Text;
            if (tph.Descripcion.Equals(""))
            {

                ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok, "Debe ingresar la descripcion para modificar!!!");
                ms.Run();
                ms.Destroy();
            }
            else
            {
                tph.Estado = 2;

                if (dth.ActualizarTipHabitacion(tph))
                {

                    ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Info, ButtonsType.Ok, "El tipo de habitaci[on fue actualizado con éxito!!!");
                    ms.Run();
                    ms.Destroy();
                    limpiarCampos();
                    tvwTipHabitacion.Model = dth.ListarTipHabitacion();
                }
                else
                {
                    ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Error, ButtonsType.Ok, "Error selecione el tipo de habitacion, revise los datos e intente nuevamente!!!");
                    ms.Run();
                    ms.Destroy();


                }
            }
        }

        protected void OnBtnBuscarClicked(object sender, EventArgs e)
        {
            String busqueda = "";
            busqueda = this.txtBuscar.Text.Trim();
            tvwTipHabitacion.Model = dth.buscarTipHabitacion(busqueda);
        }
    }
}

