
// This file has been generated by the GUI designer. Do not modify.
namespace Hotel
{
	public partial class frmOpciones
	{
		private global::Gtk.Fixed fixed3;

		private global::Gtk.Label label3;

		private global::Gtk.Label label5;

		private global::Gtk.Entry txtOpcion;

		private global::Gtk.Button btnGuardar;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gtk.TreeView tvwOpcion;

		private global::Gtk.Button btnModificar;

		private global::Gtk.Button btnCancelar;

		private global::Gtk.Button btnEliminar;

		private global::Gtk.Entry txtBuscar;

		private global::Gtk.Button btnBuscar;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Hotel.frmOpciones
			this.Name = "Hotel.frmOpciones";
			this.Title = global::Mono.Unix.Catalog.GetString("frmOpciones");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child Hotel.frmOpciones.Gtk.Container+ContainerChild
			this.fixed3 = new global::Gtk.Fixed();
			this.fixed3.Name = "fixed3";
			this.fixed3.HasWindow = false;
			// Container child fixed3.Gtk.Fixed+FixedChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Opciones de gestion");
			this.fixed3.Add(this.label3);
			global::Gtk.Fixed.FixedChild w1 = ((global::Gtk.Fixed.FixedChild)(this.fixed3[this.label3]));
			w1.X = 150;
			w1.Y = 19;
			// Container child fixed3.Gtk.Fixed+FixedChild
			this.label5 = new global::Gtk.Label();
			this.label5.Name = "label5";
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString("Opcion:");
			this.fixed3.Add(this.label5);
			global::Gtk.Fixed.FixedChild w2 = ((global::Gtk.Fixed.FixedChild)(this.fixed3[this.label5]));
			w2.X = 40;
			w2.Y = 58;
			// Container child fixed3.Gtk.Fixed+FixedChild
			this.txtOpcion = new global::Gtk.Entry();
			this.txtOpcion.CanFocus = true;
			this.txtOpcion.Name = "txtOpcion";
			this.txtOpcion.IsEditable = true;
			this.txtOpcion.WidthChars = 35;
			this.txtOpcion.InvisibleChar = '•';
			this.fixed3.Add(this.txtOpcion);
			global::Gtk.Fixed.FixedChild w3 = ((global::Gtk.Fixed.FixedChild)(this.fixed3[this.txtOpcion]));
			w3.X = 95;
			w3.Y = 55;
			// Container child fixed3.Gtk.Fixed+FixedChild
			this.btnGuardar = new global::Gtk.Button();
			this.btnGuardar.CanFocus = true;
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.UseUnderline = true;
			this.btnGuardar.Label = global::Mono.Unix.Catalog.GetString("Guardar");
			this.fixed3.Add(this.btnGuardar);
			global::Gtk.Fixed.FixedChild w4 = ((global::Gtk.Fixed.FixedChild)(this.fixed3[this.btnGuardar]));
			w4.X = 40;
			w4.Y = 95;
			// Container child fixed3.Gtk.Fixed+FixedChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.WidthRequest = 380;
			this.GtkScrolledWindow.HeightRequest = 180;
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.tvwOpcion = new global::Gtk.TreeView();
			this.tvwOpcion.CanFocus = true;
			this.tvwOpcion.Name = "tvwOpcion";
			this.GtkScrolledWindow.Add(this.tvwOpcion);
			this.fixed3.Add(this.GtkScrolledWindow);
			global::Gtk.Fixed.FixedChild w6 = ((global::Gtk.Fixed.FixedChild)(this.fixed3[this.GtkScrolledWindow]));
			w6.X = 30;
			w6.Y = 180;
			// Container child fixed3.Gtk.Fixed+FixedChild
			this.btnModificar = new global::Gtk.Button();
			this.btnModificar.CanFocus = true;
			this.btnModificar.Name = "btnModificar";
			this.btnModificar.UseUnderline = true;
			this.btnModificar.Label = global::Mono.Unix.Catalog.GetString("Modificar");
			this.fixed3.Add(this.btnModificar);
			global::Gtk.Fixed.FixedChild w7 = ((global::Gtk.Fixed.FixedChild)(this.fixed3[this.btnModificar]));
			w7.X = 120;
			w7.Y = 95;
			// Container child fixed3.Gtk.Fixed+FixedChild
			this.btnCancelar = new global::Gtk.Button();
			this.btnCancelar.CanFocus = true;
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.UseUnderline = true;
			this.btnCancelar.Label = global::Mono.Unix.Catalog.GetString("Cancelar");
			this.fixed3.Add(this.btnCancelar);
			global::Gtk.Fixed.FixedChild w8 = ((global::Gtk.Fixed.FixedChild)(this.fixed3[this.btnCancelar]));
			w8.X = 210;
			w8.Y = 95;
			// Container child fixed3.Gtk.Fixed+FixedChild
			this.btnEliminar = new global::Gtk.Button();
			this.btnEliminar.CanFocus = true;
			this.btnEliminar.Name = "btnEliminar";
			this.btnEliminar.UseUnderline = true;
			this.btnEliminar.Label = global::Mono.Unix.Catalog.GetString("Eliminar");
			this.fixed3.Add(this.btnEliminar);
			global::Gtk.Fixed.FixedChild w9 = ((global::Gtk.Fixed.FixedChild)(this.fixed3[this.btnEliminar]));
			w9.X = 300;
			w9.Y = 95;
			// Container child fixed3.Gtk.Fixed+FixedChild
			this.txtBuscar = new global::Gtk.Entry();
			this.txtBuscar.CanFocus = true;
			this.txtBuscar.Name = "txtBuscar";
			this.txtBuscar.IsEditable = true;
			this.txtBuscar.WidthChars = 37;
			this.txtBuscar.InvisibleChar = '•';
			this.fixed3.Add(this.txtBuscar);
			global::Gtk.Fixed.FixedChild w10 = ((global::Gtk.Fixed.FixedChild)(this.fixed3[this.txtBuscar]));
			w10.X = 30;
			w10.Y = 135;
			// Container child fixed3.Gtk.Fixed+FixedChild
			this.btnBuscar = new global::Gtk.Button();
			this.btnBuscar.CanFocus = true;
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.UseUnderline = true;
			this.btnBuscar.Label = global::Mono.Unix.Catalog.GetString("Buscar");
			this.fixed3.Add(this.btnBuscar);
			global::Gtk.Fixed.FixedChild w11 = ((global::Gtk.Fixed.FixedChild)(this.fixed3[this.btnBuscar]));
			w11.X = 335;
			w11.Y = 133;
			this.Add(this.fixed3);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 440;
			this.DefaultHeight = 378;
			this.Show();
			this.btnGuardar.Clicked += new global::System.EventHandler(this.OnBtnGuardarClicked);
			this.tvwOpcion.CursorChanged += new global::System.EventHandler(this.OnTvwOpcionCursorChanged);
			this.btnModificar.Clicked += new global::System.EventHandler(this.OnBtnModificarClicked);
			this.btnCancelar.Clicked += new global::System.EventHandler(this.OnBtnCancelarClicked);
			this.btnEliminar.Clicked += new global::System.EventHandler(this.OnBtnEliminarClicked);
			this.btnBuscar.Clicked += new global::System.EventHandler(this.OnBtnBuscarClicked);
		}
	}
}
