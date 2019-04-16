
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;

	private global::Gtk.Action propertiesAction;

	private global::Gtk.Action floppyAction;

	private global::Gtk.Action OpcionesAction;

	private global::Gtk.Action GestinAction;

	private global::Gtk.Action UsuariosAction;

	private global::Gtk.Action ReservacionesAction;

	private global::Gtk.Action CerrarSesinAction;

	private global::Gtk.Action SalirAction;

	private global::Gtk.Action HuespedesAction;

	private global::Gtk.Action ProductosAction;

	private global::Gtk.Action HabitacionesAction;

	private global::Gtk.Action NuevaReservacinAction;

	private global::Gtk.Action UsuariosAction1;

	private global::Gtk.Action RolesAction;

	private global::Gtk.Action OpcionesAction1;

	private global::Gtk.Action TarjetasAction;

	private global::Gtk.Action EmisoresAction;

	private global::Gtk.Fixed fixed1;

	private global::Gtk.MenuBar menubar1;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup("Default");
		this.propertiesAction = new global::Gtk.Action("propertiesAction", null, null, "gtk-properties");
		w1.Add(this.propertiesAction, null);
		this.floppyAction = new global::Gtk.Action("floppyAction", null, null, "gtk-floppy");
		w1.Add(this.floppyAction, null);
		this.OpcionesAction = new global::Gtk.Action("OpcionesAction", global::Mono.Unix.Catalog.GetString("Opciones"), null, null);
		this.OpcionesAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Opciones");
		w1.Add(this.OpcionesAction, null);
		this.GestinAction = new global::Gtk.Action("GestinAction", global::Mono.Unix.Catalog.GetString("Gestión"), null, null);
		this.GestinAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Gestión");
		w1.Add(this.GestinAction, null);
		this.UsuariosAction = new global::Gtk.Action("UsuariosAction", global::Mono.Unix.Catalog.GetString("Usuarios"), null, null);
		this.UsuariosAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Usuarios");
		w1.Add(this.UsuariosAction, null);
		this.ReservacionesAction = new global::Gtk.Action("ReservacionesAction", global::Mono.Unix.Catalog.GetString("Reservaciones"), null, null);
		this.ReservacionesAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Reservaciones");
		w1.Add(this.ReservacionesAction, null);
		this.CerrarSesinAction = new global::Gtk.Action("CerrarSesinAction", global::Mono.Unix.Catalog.GetString("Cerrar Sesión"), null, null);
		this.CerrarSesinAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Cerrar Sesión");
		w1.Add(this.CerrarSesinAction, null);
		this.SalirAction = new global::Gtk.Action("SalirAction", global::Mono.Unix.Catalog.GetString("Salir"), null, null);
		this.SalirAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Salir");
		w1.Add(this.SalirAction, null);
		this.HuespedesAction = new global::Gtk.Action("HuespedesAction", global::Mono.Unix.Catalog.GetString("Huespedes"), null, null);
		this.HuespedesAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Huéspedes");
		w1.Add(this.HuespedesAction, null);
		this.ProductosAction = new global::Gtk.Action("ProductosAction", global::Mono.Unix.Catalog.GetString("Productos"), null, null);
		this.ProductosAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Productos");
		w1.Add(this.ProductosAction, null);
		this.HabitacionesAction = new global::Gtk.Action("HabitacionesAction", global::Mono.Unix.Catalog.GetString("Habitaciones"), null, null);
		this.HabitacionesAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Habitaciones");
		w1.Add(this.HabitacionesAction, null);
		this.NuevaReservacinAction = new global::Gtk.Action("NuevaReservacinAction", global::Mono.Unix.Catalog.GetString("Nueva Reservación"), null, null);
		this.NuevaReservacinAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Nueva Reservación");
		w1.Add(this.NuevaReservacinAction, null);
		this.UsuariosAction1 = new global::Gtk.Action("UsuariosAction1", global::Mono.Unix.Catalog.GetString("Usuarios"), null, null);
		this.UsuariosAction1.ShortLabel = global::Mono.Unix.Catalog.GetString("Usuarios");
		w1.Add(this.UsuariosAction1, null);
		this.RolesAction = new global::Gtk.Action("RolesAction", global::Mono.Unix.Catalog.GetString("Roles"), null, null);
		this.RolesAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Roles");
		w1.Add(this.RolesAction, null);
		this.OpcionesAction1 = new global::Gtk.Action("OpcionesAction1", global::Mono.Unix.Catalog.GetString("Opciones"), null, null);
		this.OpcionesAction1.ShortLabel = global::Mono.Unix.Catalog.GetString("Opciones");
		w1.Add(this.OpcionesAction1, null);
		this.TarjetasAction = new global::Gtk.Action("TarjetasAction", global::Mono.Unix.Catalog.GetString("Tarjetas"), null, null);
		this.TarjetasAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Tarjetas");
		w1.Add(this.TarjetasAction, null);
		this.EmisoresAction = new global::Gtk.Action("EmisoresAction", global::Mono.Unix.Catalog.GetString("Emisores"), null, null);
		this.EmisoresAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Emisores");
		w1.Add(this.EmisoresAction, null);
		this.UIManager.InsertActionGroup(w1, 0);
		this.AddAccelGroup(this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("InRoom - Inicio");
		this.WindowPosition = ((global::Gtk.WindowPosition)(1));
		this.DefaultWidth = 1000;
		this.DefaultHeight = 600;
		this.Gravity = ((global::Gdk.Gravity)(5));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.fixed1 = new global::Gtk.Fixed();
		this.fixed1.Name = "fixed1";
		this.fixed1.HasWindow = false;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.UIManager.AddUiFromString(@"<ui><menubar name='menubar1'><menu name='OpcionesAction' action='OpcionesAction'><menuitem name='CerrarSesinAction' action='CerrarSesinAction'/><menuitem name='SalirAction' action='SalirAction'/></menu><menu name='GestinAction' action='GestinAction'><menuitem name='HuespedesAction' action='HuespedesAction'/><menuitem name='ProductosAction' action='ProductosAction'/><menuitem name='HabitacionesAction' action='HabitacionesAction'/><menu name='TarjetasAction' action='TarjetasAction'><menuitem name='EmisoresAction' action='EmisoresAction'/></menu></menu><menu name='UsuariosAction' action='UsuariosAction'><menuitem name='UsuariosAction1' action='UsuariosAction1'/><menuitem name='RolesAction' action='RolesAction'/><menuitem name='OpcionesAction1' action='OpcionesAction1'/></menu><menu name='ReservacionesAction' action='ReservacionesAction'><menuitem name='NuevaReservacinAction' action='NuevaReservacinAction'/></menu></menubar></ui>");
		this.menubar1 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget("/menubar1")));
		this.menubar1.Name = "menubar1";
		this.fixed1.Add(this.menubar1);
		global::Gtk.Fixed.FixedChild w2 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.menubar1]));
		w2.X = 2;
		w2.Y = 3;
		this.Add(this.fixed1);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.Show();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
		this.CerrarSesinAction.Activated += new global::System.EventHandler(this.OnCerrarSesinActionActivated);
		this.SalirAction.Activated += new global::System.EventHandler(this.OnSalirActionActivated);
		this.HuespedesAction.Activated += new global::System.EventHandler(this.OnHuespedesActionActivated);
		this.HabitacionesAction.Activated += new global::System.EventHandler(this.OnHabitacionesActionActivated);
		this.NuevaReservacinAction.Activated += new global::System.EventHandler(this.OnNuevaReservacinActionActivated);
		this.UsuariosAction1.Activated += new global::System.EventHandler(this.OnUsuariosAction1Activated);
		this.EmisoresAction.Activated += new global::System.EventHandler(this.OnEmisoresActionActivated);
	}
}