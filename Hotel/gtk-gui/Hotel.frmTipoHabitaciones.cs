
// This file has been generated by the GUI designer. Do not modify.
namespace Hotel
{
	public partial class frmTipoHabitaciones
	{
		private global::Gtk.Fixed fixed1;

		private global::Gtk.Label label1;

		private global::Gtk.Label label2;

		private global::Gtk.Entry txtDescripHab;

		private global::Gtk.Button btnGuardar;

		private global::Gtk.Button btnModificar;

		private global::Gtk.Button btnEliminar;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gtk.TreeView tvwTipHabitacion;

		private global::Gtk.Button btnBuscar;

		private global::Gtk.Button btnCancelar;

		private global::Gtk.Entry txtBuscar;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Hotel.frmTipoHabitaciones
			this.Name = "Hotel.frmTipoHabitaciones";
			this.Title = global::Mono.Unix.Catalog.GetString("frmTipoHabitaciones");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child Hotel.frmTipoHabitaciones.Gtk.Container+ContainerChild
			this.fixed1 = new global::Gtk.Fixed();
			this.fixed1.Name = "fixed1";
			this.fixed1.HasWindow = false;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Tipos de Habitaciones");
			this.fixed1.Add(this.label1);
			global::Gtk.Fixed.FixedChild w1 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.label1]));
			w1.X = 126;
			w1.Y = 8;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.label2 = new global::Gtk.Label();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("Descripcion de Habitacion:");
			this.fixed1.Add(this.label2);
			global::Gtk.Fixed.FixedChild w2 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.label2]));
			w2.X = 11;
			w2.Y = 63;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.txtDescripHab = new global::Gtk.Entry();
			this.txtDescripHab.CanFocus = true;
			this.txtDescripHab.Name = "txtDescripHab";
			this.txtDescripHab.IsEditable = true;
			this.txtDescripHab.InvisibleChar = '•';
			this.fixed1.Add(this.txtDescripHab);
			global::Gtk.Fixed.FixedChild w3 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.txtDescripHab]));
			w3.X = 199;
			w3.Y = 60;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.btnGuardar = new global::Gtk.Button();
			this.btnGuardar.CanFocus = true;
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.UseUnderline = true;
			this.btnGuardar.Label = global::Mono.Unix.Catalog.GetString("Guardar");
			this.fixed1.Add(this.btnGuardar);
			global::Gtk.Fixed.FixedChild w4 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.btnGuardar]));
			w4.X = 40;
			w4.Y = 105;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.btnModificar = new global::Gtk.Button();
			this.btnModificar.CanFocus = true;
			this.btnModificar.Name = "btnModificar";
			this.btnModificar.UseUnderline = true;
			this.btnModificar.Label = global::Mono.Unix.Catalog.GetString("Modificar");
			this.fixed1.Add(this.btnModificar);
			global::Gtk.Fixed.FixedChild w5 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.btnModificar]));
			w5.X = 115;
			w5.Y = 105;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.btnEliminar = new global::Gtk.Button();
			this.btnEliminar.CanFocus = true;
			this.btnEliminar.Name = "btnEliminar";
			this.btnEliminar.UseUnderline = true;
			this.btnEliminar.Label = global::Mono.Unix.Catalog.GetString("Eliminar");
			this.fixed1.Add(this.btnEliminar);
			global::Gtk.Fixed.FixedChild w6 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.btnEliminar]));
			w6.X = 280;
			w6.Y = 105;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.WidthRequest = 350;
			this.GtkScrolledWindow.HeightRequest = 300;
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.tvwTipHabitacion = new global::Gtk.TreeView();
			this.tvwTipHabitacion.CanFocus = true;
			this.tvwTipHabitacion.Name = "tvwTipHabitacion";
			this.GtkScrolledWindow.Add(this.tvwTipHabitacion);
			this.fixed1.Add(this.GtkScrolledWindow);
			global::Gtk.Fixed.FixedChild w8 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.GtkScrolledWindow]));
			w8.X = 27;
			w8.Y = 180;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.btnBuscar = new global::Gtk.Button();
			this.btnBuscar.CanFocus = true;
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.UseUnderline = true;
			this.btnBuscar.Label = global::Mono.Unix.Catalog.GetString("Buscar");
			this.fixed1.Add(this.btnBuscar);
			global::Gtk.Fixed.FixedChild w9 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.btnBuscar]));
			w9.X = 304;
			w9.Y = 143;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.btnCancelar = new global::Gtk.Button();
			this.btnCancelar.CanFocus = true;
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.UseUnderline = true;
			this.btnCancelar.Label = global::Mono.Unix.Catalog.GetString("Cancelar");
			this.fixed1.Add(this.btnCancelar);
			global::Gtk.Fixed.FixedChild w10 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.btnCancelar]));
			w10.X = 200;
			w10.Y = 105;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.txtBuscar = new global::Gtk.Entry();
			this.txtBuscar.CanFocus = true;
			this.txtBuscar.Name = "txtBuscar";
			this.txtBuscar.IsEditable = true;
			this.txtBuscar.WidthChars = 32;
			this.txtBuscar.InvisibleChar = '•';
			this.fixed1.Add(this.txtBuscar);
			global::Gtk.Fixed.FixedChild w11 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.txtBuscar]));
			w11.X = 31;
			w11.Y = 145;
			this.Add(this.fixed1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 408;
			this.DefaultHeight = 526;
			this.Show();
			this.btnGuardar.Clicked += new global::System.EventHandler(this.OnBtnGuardarClicked);
			this.btnModificar.Clicked += new global::System.EventHandler(this.OnBtnModificarClicked);
			this.btnEliminar.Clicked += new global::System.EventHandler(this.OnBtnEliminarClicked);
			this.tvwTipHabitacion.CursorChanged += new global::System.EventHandler(this.OnTvwTipHabitacionCursorChanged);
			this.btnBuscar.Clicked += new global::System.EventHandler(this.OnBtnBuscarClicked);
			this.btnCancelar.Clicked += new global::System.EventHandler(this.OnBtnCancelarClicked);
		}
	}
}
