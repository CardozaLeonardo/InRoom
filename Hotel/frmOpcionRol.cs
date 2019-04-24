using System;
using Gtk;
using System.Collections.Generic;
using Hotel.entidades;
using Hotel.datos;
using Hotel.negocio;
namespace Hotel
{
    public partial class frmOpcionRol : Gtk.Window
    {
        Tbl_opcion top = new Tbl_opcion();
        Tbl_rol tr = new Tbl_rol();
        Tbl_rolOption tro = new Tbl_rolOption();
        dtRol dtr = new dtRol();
        dtOpcionRol dtopcr = new dtOpcionRol();
        dtOpcion dtop = new dtOpcion();
        ngOpcionRol ngOpcR = new ngOpcionRol();
        MessageDialog ms = null;
        public frmOpcionRol() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            //LLENAMOS LOS COMBOBOX
            llenarComboOpcion();
            llenarComboRol();
            //POSICIONAMOS EL COMBO EN LA POSICION 0
            limpiarCombos();

            //LLENAMOS EL TREEVIEW
            this.tvwOpcRol.Model = dtopcr.ListarOpcionRol();
            string[] titulos = { "IdRol", "Rol", "IdOpcion", "Opcion" };
            for (int i = 0; i < titulos.Length; i++)
            {
                this.tvwOpcRol.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
        }

        public void llenarComboRol()
        {

            List<Tbl_rol> listarRol = new List<Tbl_rol>();
            listarRol = dtr.cbxRol();

            cbxRol.InsertText(0, "Seleccione...");

            foreach (Tbl_rol trol in listarRol)
            {
                cbxRol.InsertText(trol.Id_rol, trol.Rol);
            }

        }

        public void llenarComboOpcion()
        {

            List<Tbl_opcion> listaOpcion = new List<Tbl_opcion>();
            listaOpcion = dtop.cbxOpcion();

            this.cbxOpcion.InsertText(0, "Seleccione...");

            foreach (Tbl_opcion topc in listaOpcion)
            {
                this.cbxOpcion.InsertText(topc.Id_opcion, topc.Opcion);
            }

        }
        public void limpiarCombos()
        {
            //POSICIONAMOS EL COMBO EN LA POSICION 0
            this.cbxRol.Active = 0;
            this.cbxOpcion.Active = 0;
        }

        protected void OnBtnAsigOpcRolClicked(object sender, EventArgs e)
        {
            if (this.cbxOpcion.Active == 0 || this.cbxRol.Active == 0)
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Error, ButtonsType.Ok, "Todos los campos son requeridos!!!");
                ms.Run();
                ms.Destroy();
            }
            else
            {

                tro.Id_option = dtop.getIdOpcion(this.cbxOpcion.ActiveText);
                tro.Id_rol = dtr.getIdRol(this.cbxRol.ActiveText);
                if (ngOpcR.ngGuardarOpcRol(tro))
                {
                    ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok, "Se asignó la opcion con exito!!!");
                    ms.Run();
                    ms.Destroy();
                    limpiarCombos();
                    this.tvwOpcRol.Model = dtopcr.ListarOpcionRol();
                }
                else
                {
                    limpiarCombos();
                }
            }
        }

        protected void OnTvwOpcRolCursorChanged(object sender, EventArgs e)
        {
            TreeSelection seleccion = (sender as TreeView).Selection;
            TreeIter iter;
            TreeModel model;
            if (seleccion.GetSelected(out model, out iter))
            {
                int i = 1;//Contador
                while (true)//Ciclo sea infinito
                {
                    this.cbxRol.Active = i;
                    if (this.cbxRol.ActiveText == model.GetValue(iter, 1).ToString())
                    {
                        break;
                    }
                    i++;
                }
                i = 1;//Contador
                while (true)//Cilco sea infinito
                {
                    this.cbxOpcion.Active = i;
                    if (this.cbxOpcion.ActiveText == model.GetValue(iter, 3).ToString())
                    {
                        break;
                    }
                    i++;
                }

            }
        }

        protected void OnBtnElOpcRolClicked(object sender, EventArgs e)
        {
            if (this.cbxOpcion.Active == 0 || this.cbxRol.Active == 0)
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Error, ButtonsType.Ok, "Todos los campos son requeridos!!!");
                ms.Run();
                ms.Destroy();
            }
            else
            {
                tro.Id_option = dtop.getIdOpcion(this.cbxOpcion.ActiveText);
                tro.Id_rol = dtr.getIdRol(this.cbxRol.ActiveText);

                if (dtopcr.DelOpcRol(tro) > 0)
                {

                    ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok, "Se elimino la opcion del rol");
                    ms.Run();
                    ms.Destroy();
                    limpiarCombos();
                    this.tvwOpcRol.Model = dtopcr.ListarOpcionRol();
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

        protected void OnBtnBuscarClicked(object sender, EventArgs e)
        {
            String busqueda = "";
            busqueda = this.txtBuscar.Text.Trim();
            tvwOpcRol.Model = dtopcr.BuscarOpcRol(busqueda);
        }
    }
}