
// This file has been generated by the GUI designer. Do not modify.
namespace Hotel
{
	public partial class frmOpcionRol
	{
		private global::Gtk.Fixed fixed1;

		private global::Gtk.Label l;

		private global::Gtk.Label label2;

		private global::Gtk.ComboBox cbxRol;

		private global::Gtk.Label label3;

		private global::Gtk.ComboBox cbxOpcion;

		private global::Gtk.Entry txtBuscar;

		private global::Gtk.Button btnElOpcRol;

		private global::Gtk.Button btnAsigOpcRol;

		private global::Gtk.Button btnBuscar;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gtk.TreeView tvwOpcRol;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Hotel.frmOpcionRol
			this.Name = "Hotel.frmOpcionRol";
			this.Title = global::Mono.Unix.Catalog.GetString("frmOpcionRol");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child Hotel.frmOpcionRol.Gtk.Container+ContainerChild
			this.fixed1 = new global::Gtk.Fixed();
			this.fixed1.Name = "fixed1";
			this.fixed1.HasWindow = false;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.l = new global::Gtk.Label();
			this.l.Name = "l";
			this.l.LabelProp = global::Mono.Unix.Catalog.GetString("Acreditaciones de Opciones a los Roles de Usuarios");
			this.fixed1.Add(this.l);
			global::Gtk.Fixed.FixedChild w1 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.l]));
			w1.X = 108;
			w1.Y = 22;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.label2 = new global::Gtk.Label();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("Rol:");
			this.fixed1.Add(this.label2);
			global::Gtk.Fixed.FixedChild w2 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.label2]));
			w2.X = 23;
			w2.Y = 75;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.cbxRol = global::Gtk.ComboBox.NewText();
			this.cbxRol.WidthRequest = 200;
			this.cbxRol.Name = "cbxRol";
			this.fixed1.Add(this.cbxRol);
			global::Gtk.Fixed.FixedChild w3 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.cbxRol]));
			w3.X = 56;
			w3.Y = 68;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Opcion:");
			this.fixed1.Add(this.label3);
			global::Gtk.Fixed.FixedChild w4 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.label3]));
			w4.X = 275;
			w4.Y = 75;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.cbxOpcion = global::Gtk.ComboBox.NewText();
			this.cbxOpcion.WidthRequest = 200;
			this.cbxOpcion.Name = "cbxOpcion";
			this.fixed1.Add(this.cbxOpcion);
			global::Gtk.Fixed.FixedChild w5 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.cbxOpcion]));
			w5.X = 330;
			w5.Y = 68;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.txtBuscar = new global::Gtk.Entry();
			this.txtBuscar.CanFocus = true;
			this.txtBuscar.Name = "txtBuscar";
			this.txtBuscar.IsEditable = true;
			this.txtBuscar.WidthChars = 50;
			this.txtBuscar.InvisibleChar = '•';
			this.fixed1.Add(this.txtBuscar);
			global::Gtk.Fixed.FixedChild w6 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.txtBuscar]));
			w6.X = 30;
			w6.Y = 160;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.btnElOpcRol = new global::Gtk.Button();
			this.btnElOpcRol.CanFocus = true;
			this.btnElOpcRol.Name = "btnElOpcRol";
			this.btnElOpcRol.UseUnderline = true;
			this.btnElOpcRol.Label = global::Mono.Unix.Catalog.GetString("Eliminar Opcion al Rol");
			this.fixed1.Add(this.btnElOpcRol);
			global::Gtk.Fixed.FixedChild w7 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.btnElOpcRol]));
			w7.X = 100;
			w7.Y = 120;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.btnAsigOpcRol = new global::Gtk.Button();
			this.btnAsigOpcRol.CanFocus = true;
			this.btnAsigOpcRol.Name = "btnAsigOpcRol";
			this.btnAsigOpcRol.UseUnderline = true;
			this.btnAsigOpcRol.Label = global::Mono.Unix.Catalog.GetString("Asignar Opcion al Rol");
			this.fixed1.Add(this.btnAsigOpcRol);
			global::Gtk.Fixed.FixedChild w8 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.btnAsigOpcRol]));
			w8.X = 310;
			w8.Y = 120;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.btnBuscar = new global::Gtk.Button();
			this.btnBuscar.CanFocus = true;
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.UseUnderline = true;
			this.btnBuscar.Label = global::Mono.Unix.Catalog.GetString("Buscar");
			this.fixed1.Add(this.btnBuscar);
			global::Gtk.Fixed.FixedChild w9 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.btnBuscar]));
			w9.X = 446;
			w9.Y = 158;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.WidthRequest = 520;
			this.GtkScrolledWindow.HeightRequest = 200;
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.tvwOpcRol = new global::Gtk.TreeView();
			this.tvwOpcRol.CanFocus = true;
			this.tvwOpcRol.Name = "tvwOpcRol";
			this.GtkScrolledWindow.Add(this.tvwOpcRol);
			this.fixed1.Add(this.GtkScrolledWindow);
			global::Gtk.Fixed.FixedChild w11 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.GtkScrolledWindow]));
			w11.X = 30;
			w11.Y = 203;
			this.Add(this.fixed1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 572;
			this.DefaultHeight = 429;
			this.Show();
			this.btnElOpcRol.Clicked += new global::System.EventHandler(this.OnBtnElOpcRolClicked);
			this.btnAsigOpcRol.Clicked += new global::System.EventHandler(this.OnBtnAsigOpcRolClicked);
			this.btnBuscar.Clicked += new global::System.EventHandler(this.OnBtnBuscarClicked);
			this.tvwOpcRol.CursorChanged += new global::System.EventHandler(this.OnTvwOpcRolCursorChanged);
		}
	}
}
