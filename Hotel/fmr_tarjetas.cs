using System;
using Gtk;
using System.Collections.Generic;
using Hotel.datos;
using Hotel.entidades;
using Hotel.negocio;
namespace Hotel
{
    public partial class fmr_tarjetas : Gtk.Window
    {
        dtTarjeta dtT = new dtTarjeta();
        ngTarjeta ngTar = new ngTarjeta();
        Tbl_tarjeta ttar = new Tbl_tarjeta();
        Tbl_tipoTarjeta ttarj = new Tbl_tipoTarjeta();
        Tbl_emisorTarjeta tetarj = new Tbl_emisorTarjeta();
        dtEmisorTarjeta dtetarj = new dtEmisorTarjeta();
        dtTipoTarjeta dtTipoTarj = new dtTipoTarjeta();
        MessageDialog ms = null;

        public fmr_tarjetas() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();

            //LLENAMOS LOS COMBOBOX
            llenarComboEmisor();
            llenarComboTipoTArjeta();
            //POSICIONAMOS EL COMBO EN LA POSICION 0
            limpiarCombos();


            twTarjetas.Model = dtT.ListarTarjetas();
            string[] titulos = { "ID", "Nombres del propitario", "Numero de Tarjeta", "Emisor de Tarjeta", "Tipo de Tarjeta" };
            for (int i = 0; i < titulos.Length; i++)
            {
                twTarjetas.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }
        }

        public void llenarComboEmisor()
        {

            List<Tbl_emisorTarjeta> listarEmisor = new List<Tbl_emisorTarjeta>();
            listarEmisor = dtetarj.ListaEmisorTarjeta();

            cbxEmisorTarj.InsertText(0, "Seleccione...");

            foreach (Tbl_emisorTarjeta tetarj in listarEmisor)
            {
                cbxEmisorTarj.InsertText(tetarj.Id_emisorTarjeta, tetarj.Emisor);
            }

        }

        public void llenarComboTipoTArjeta()
        {

            List<Tbl_tipoTarjeta> listaTipoTarjeta = new List<Tbl_tipoTarjeta>();
            listaTipoTarjeta = dtTipoTarj.ListaTipoTarjeta();

            this.cbxTipoTarj.InsertText(0, "Seleccione...");

            foreach (Tbl_tipoTarjeta ttipoTarj in listaTipoTarjeta)
            {
                cbxTipoTarj.InsertText(ttipoTarj.Id_tipoTarjeta, ttipoTarj.Tipo_tarjeta);
            }

        }

        public void limpiarCombos()
        {
            //POSICIONAMOS EL COMBO EN LA POSICION 0
            this.cbxEmisorTarj.Active = 0;
            this.cbxTipoTarj.Active = 0;
        }


        public void limpiarCampos()
        {
            this.txt_nombresPT.Text = "";
            this.txt_numeroT.Text = "";
            this.txt_FechaExp.Text = "";


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



        protected void OnBtnCancelarTarjClicked(object sender, EventArgs e)
        {
            limpiarCampos();
            limpiarCombos();
        }
        protected void OnBtnGuardarTarjClicked(object sender, EventArgs e)
        {
            ttar.Nombre_titular = this.txt_nombresPT.Text;
            ttar.NumeroTarjeta = this.txt_numeroT.Text;
            ttar.Fecha_expiracion = this.txt_FechaExp.Text;
            ttar.Id_emisorTarjeta = this.cbxEmisorTarj.Active;
            ttar.Id_tipoTarjeta = this.cbxTipoTarj.Active;


            if (ttar.Nombre_titular.Equals("") || ttar.NumeroTarjeta.Equals("") || ttar.Fecha_expiracion.Equals("") || this.cbxEmisorTarj.Active == 0 || this.cbxTipoTarj.Active == 0)
            {

                ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok, "Todos los campos son requeridos");
                ms.Run();
                ms.Destroy();
            }
            else
            {
                if (ngTar.ngGuardarTarjeta(ttar))
                {


                    ms = new MessageDialog(null, DialogFlags.Modal,
                        MessageType.Info, ButtonsType.Ok, "Tarjeta agregada correctamente");
                    ms.Run();
                    ms.Destroy();
                    limpiarCampos();
                    limpiarCombos();
                    twTarjetas.Model = dtT.ListarTarjetas();
                }
            }

        }


        protected void OnBtnCancelarClicked(object sender, EventArgs e)
        {
            this.Hide();
        }

        protected void OnTwTarjetasCursorChanged(object sender, EventArgs e)
        {
            TreeSelection seleccion = (sender as TreeView).Selection;
            TreeIter iter;
            TreeModel model;

            if (seleccion.GetSelected(out model, out iter))
            {
                ttar.Id_tarjeta = Convert.ToInt32(model.GetValue(iter, 0).ToString());

                this.txt_nombresPT.Text = model.GetValue(iter, 1).ToString();
                this.txt_numeroT.Text = model.GetValue(iter, 2).ToString();
                this.txt_FechaExp.Text = model.GetValue(iter, 3).ToString();
                //ttar.Id_emisorTarjeta = Convert.ToInt32(model.GetValue(iter, 4).ToString());
                this.cbxEmisorTarj.Active = Convert.ToInt32(model.GetValue(iter, 4).ToString());
                ttar.Id_tipoTarjeta = Convert.ToInt32(model.GetValue(iter, 5).ToString());
            }
        }

        protected void OnBtnSeleccionarFEClicked(object sender, EventArgs e)
        {
            txt_FechaExp.Text = calen.Year.ToString() + "-" + calen.Month.ToString() + "-"
            + calen.Day.ToString();
        }

        protected void OnBtnBuscarClicked(object sender, EventArgs e)
        {
            String busqueda = "";
            busqueda = this.txtbuscar.Text.Trim();
            twTarjetas.Model = dtT.buscarTarjeta(busqueda);
        }

        protected void OnTxtNombresPTChanged(object sender, EventArgs e)
        {
            ValidarLetras(txt_nombresPT);
        }

        protected void OnTxtNumeroTChanged(object sender, EventArgs e)
        {
            ValidarNro(txt_numeroT);
        }
    }
}
