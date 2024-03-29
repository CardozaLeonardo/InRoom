
// This file has been generated by the GUI designer. Do not modify.
namespace Hotel
{
	public partial class fmr_detalleReserv
	{
		private global::Gtk.Fixed fixed3;

		private global::Gtk.Entry txt_fechaEntrada;

		private global::Gtk.Button btn_fijarEntrada;

		private global::Gtk.Label label4;

		private global::Gtk.SpinButton entrada_minuto;

		private global::Gtk.SpinButton entrada_hora;

		private global::Gtk.Label label8;

		private global::Gtk.Label label5;

		private global::Gtk.Entry txt_fechaSalida;

		private global::Gtk.Button btn_fijarSalida;

		private global::Gtk.Label label7;

		private global::Gtk.SpinButton salida_hora;

		private global::Gtk.SpinButton salida_minuto;

		private global::Gtk.Label label6;

		private global::Gtk.Button btn_aceptar;

		private global::Gtk.Button btn_cancelar;

		private global::Gtk.Calendar calen;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gtk.TreeView twHabitaciones;

		private global::Gtk.Button btnVerificar;

		private global::Gtk.Label lbl;

		private global::Gtk.Entry txtHab;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Hotel.fmr_detalleReserv
			this.Name = "Hotel.fmr_detalleReserv";
			this.Title = global::Mono.Unix.Catalog.GetString("fmr_detalleReserv");
			this.WindowPosition = ((global::Gtk.WindowPosition)(1));
			this.Modal = true;
			this.Gravity = ((global::Gdk.Gravity)(5));
			// Container child Hotel.fmr_detalleReserv.Gtk.Container+ContainerChild
			this.fixed3 = new global::Gtk.Fixed();
			this.fixed3.Name = "fixed3";
			this.fixed3.HasWindow = false;
			// Container child fixed3.Gtk.Fixed+FixedChild
			this.txt_fechaEntrada = new global::Gtk.Entry();
			this.txt_fechaEntrada.WidthRequest = 180;
			this.txt_fechaEntrada.CanFocus = true;
			this.txt_fechaEntrada.Name = "txt_fechaEntrada";
			this.txt_fechaEntrada.IsEditable = false;
			this.txt_fechaEntrada.InvisibleChar = '•';
			this.fixed3.Add(this.txt_fechaEntrada);
			global::Gtk.Fixed.FixedChild w1 = ((global::Gtk.Fixed.FixedChild)(this.fixed3[this.txt_fechaEntrada]));
			w1.X = 463;
			w1.Y = 306;
			// Container child fixed3.Gtk.Fixed+FixedChild
			this.btn_fijarEntrada = new global::Gtk.Button();
			this.btn_fijarEntrada.CanFocus = true;
			this.btn_fijarEntrada.Name = "btn_fijarEntrada";
			this.btn_fijarEntrada.UseUnderline = true;
			this.btn_fijarEntrada.Label = global::Mono.Unix.Catalog.GetString("Establecer");
			this.fixed3.Add(this.btn_fijarEntrada);
			global::Gtk.Fixed.FixedChild w2 = ((global::Gtk.Fixed.FixedChild)(this.fixed3[this.btn_fijarEntrada]));
			w2.X = 665;
			w2.Y = 304;
			// Container child fixed3.Gtk.Fixed+FixedChild
			this.label4 = new global::Gtk.Label();
			this.label4.Name = "label4";
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("Entrada");
			this.fixed3.Add(this.label4);
			global::Gtk.Fixed.FixedChild w3 = ((global::Gtk.Fixed.FixedChild)(this.fixed3[this.label4]));
			w3.X = 463;
			w3.Y = 283;
			// Container child fixed3.Gtk.Fixed+FixedChild
			this.entrada_minuto = new global::Gtk.SpinButton(0D, 59D, 1D);
			this.entrada_minuto.CanFocus = true;
			this.entrada_minuto.Name = "entrada_minuto";
			this.entrada_minuto.Adjustment.PageIncrement = 10D;
			this.entrada_minuto.ClimbRate = 1D;
			this.entrada_minuto.Numeric = true;
			this.entrada_minuto.Value = 11D;
			this.fixed3.Add(this.entrada_minuto);
			global::Gtk.Fixed.FixedChild w4 = ((global::Gtk.Fixed.FixedChild)(this.fixed3[this.entrada_minuto]));
			w4.X = 592;
			w4.Y = 345;
			// Container child fixed3.Gtk.Fixed+FixedChild
			this.entrada_hora = new global::Gtk.SpinButton(0D, 23D, 1D);
			this.entrada_hora.CanFocus = true;
			this.entrada_hora.Name = "entrada_hora";
			this.entrada_hora.Adjustment.PageIncrement = 10D;
			this.entrada_hora.ClimbRate = 1D;
			this.entrada_hora.Numeric = true;
			this.entrada_hora.Value = 23D;
			this.fixed3.Add(this.entrada_hora);
			global::Gtk.Fixed.FixedChild w5 = ((global::Gtk.Fixed.FixedChild)(this.fixed3[this.entrada_hora]));
			w5.X = 525;
			w5.Y = 346;
			// Container child fixed3.Gtk.Fixed+FixedChild
			this.label8 = new global::Gtk.Label();
			this.label8.Name = "label8";
			this.label8.LabelProp = global::Mono.Unix.Catalog.GetString("Hora");
			this.fixed3.Add(this.label8);
			global::Gtk.Fixed.FixedChild w6 = ((global::Gtk.Fixed.FixedChild)(this.fixed3[this.label8]));
			w6.X = 468;
			w6.Y = 351;
			// Container child fixed3.Gtk.Fixed+FixedChild
			this.label5 = new global::Gtk.Label();
			this.label5.Name = "label5";
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString("Salida");
			this.fixed3.Add(this.label5);
			global::Gtk.Fixed.FixedChild w7 = ((global::Gtk.Fixed.FixedChild)(this.fixed3[this.label5]));
			w7.X = 464;
			w7.Y = 408;
			// Container child fixed3.Gtk.Fixed+FixedChild
			this.txt_fechaSalida = new global::Gtk.Entry();
			this.txt_fechaSalida.WidthRequest = 180;
			this.txt_fechaSalida.CanFocus = true;
			this.txt_fechaSalida.Name = "txt_fechaSalida";
			this.txt_fechaSalida.IsEditable = false;
			this.txt_fechaSalida.InvisibleChar = '•';
			this.fixed3.Add(this.txt_fechaSalida);
			global::Gtk.Fixed.FixedChild w8 = ((global::Gtk.Fixed.FixedChild)(this.fixed3[this.txt_fechaSalida]));
			w8.X = 465;
			w8.Y = 434;
			// Container child fixed3.Gtk.Fixed+FixedChild
			this.btn_fijarSalida = new global::Gtk.Button();
			this.btn_fijarSalida.CanFocus = true;
			this.btn_fijarSalida.Name = "btn_fijarSalida";
			this.btn_fijarSalida.UseUnderline = true;
			this.btn_fijarSalida.Label = global::Mono.Unix.Catalog.GetString("Establecer");
			this.fixed3.Add(this.btn_fijarSalida);
			global::Gtk.Fixed.FixedChild w9 = ((global::Gtk.Fixed.FixedChild)(this.fixed3[this.btn_fijarSalida]));
			w9.X = 670;
			w9.Y = 433;
			// Container child fixed3.Gtk.Fixed+FixedChild
			this.label7 = new global::Gtk.Label();
			this.label7.Name = "label7";
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString("Hora");
			this.fixed3.Add(this.label7);
			global::Gtk.Fixed.FixedChild w10 = ((global::Gtk.Fixed.FixedChild)(this.fixed3[this.label7]));
			w10.X = 471;
			w10.Y = 475;
			// Container child fixed3.Gtk.Fixed+FixedChild
			this.salida_hora = new global::Gtk.SpinButton(0D, 23D, 1D);
			this.salida_hora.CanFocus = true;
			this.salida_hora.Name = "salida_hora";
			this.salida_hora.Adjustment.PageIncrement = 10D;
			this.salida_hora.ClimbRate = 1D;
			this.salida_hora.Numeric = true;
			this.fixed3.Add(this.salida_hora);
			global::Gtk.Fixed.FixedChild w11 = ((global::Gtk.Fixed.FixedChild)(this.fixed3[this.salida_hora]));
			w11.X = 527;
			w11.Y = 471;
			// Container child fixed3.Gtk.Fixed+FixedChild
			this.salida_minuto = new global::Gtk.SpinButton(0D, 59D, 1D);
			this.salida_minuto.CanFocus = true;
			this.salida_minuto.Name = "salida_minuto";
			this.salida_minuto.Adjustment.PageIncrement = 10D;
			this.salida_minuto.ClimbRate = 1D;
			this.salida_minuto.Numeric = true;
			this.fixed3.Add(this.salida_minuto);
			global::Gtk.Fixed.FixedChild w12 = ((global::Gtk.Fixed.FixedChild)(this.fixed3[this.salida_minuto]));
			w12.X = 595;
			w12.Y = 473;
			// Container child fixed3.Gtk.Fixed+FixedChild
			this.label6 = new global::Gtk.Label();
			this.label6.Name = "label6";
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString("DETALLE DE RESERVACION");
			this.fixed3.Add(this.label6);
			global::Gtk.Fixed.FixedChild w13 = ((global::Gtk.Fixed.FixedChild)(this.fixed3[this.label6]));
			w13.X = 328;
			w13.Y = 17;
			// Container child fixed3.Gtk.Fixed+FixedChild
			this.btn_aceptar = new global::Gtk.Button();
			this.btn_aceptar.WidthRequest = 120;
			this.btn_aceptar.HeightRequest = 30;
			this.btn_aceptar.CanFocus = true;
			this.btn_aceptar.Name = "btn_aceptar";
			this.btn_aceptar.UseUnderline = true;
			this.btn_aceptar.Label = global::Mono.Unix.Catalog.GetString("Agregar");
			this.fixed3.Add(this.btn_aceptar);
			global::Gtk.Fixed.FixedChild w14 = ((global::Gtk.Fixed.FixedChild)(this.fixed3[this.btn_aceptar]));
			w14.X = 468;
			w14.Y = 534;
			// Container child fixed3.Gtk.Fixed+FixedChild
			this.btn_cancelar = new global::Gtk.Button();
			this.btn_cancelar.WidthRequest = 120;
			this.btn_cancelar.HeightRequest = 30;
			this.btn_cancelar.CanFocus = true;
			this.btn_cancelar.Name = "btn_cancelar";
			this.btn_cancelar.UseUnderline = true;
			this.btn_cancelar.Label = global::Mono.Unix.Catalog.GetString("Cancelar");
			this.fixed3.Add(this.btn_cancelar);
			global::Gtk.Fixed.FixedChild w15 = ((global::Gtk.Fixed.FixedChild)(this.fixed3[this.btn_cancelar]));
			w15.X = 612;
			w15.Y = 535;
			// Container child fixed3.Gtk.Fixed+FixedChild
			this.calen = new global::Gtk.Calendar();
			this.calen.CanFocus = true;
			this.calen.Name = "calen";
			this.calen.DisplayOptions = ((global::Gtk.CalendarDisplayOptions)(35));
			this.fixed3.Add(this.calen);
			global::Gtk.Fixed.FixedChild w16 = ((global::Gtk.Fixed.FixedChild)(this.fixed3[this.calen]));
			w16.X = 462;
			w16.Y = 69;
			// Container child fixed3.Gtk.Fixed+FixedChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.twHabitaciones = new global::Gtk.TreeView();
			this.twHabitaciones.WidthRequest = 350;
			this.twHabitaciones.HeightRequest = 360;
			this.twHabitaciones.CanFocus = true;
			this.twHabitaciones.Name = "twHabitaciones";
			this.GtkScrolledWindow.Add(this.twHabitaciones);
			this.fixed3.Add(this.GtkScrolledWindow);
			global::Gtk.Fixed.FixedChild w18 = ((global::Gtk.Fixed.FixedChild)(this.fixed3[this.GtkScrolledWindow]));
			w18.X = 34;
			w18.Y = 142;
			// Container child fixed3.Gtk.Fixed+FixedChild
			this.btnVerificar = new global::Gtk.Button();
			this.btnVerificar.WidthRequest = 150;
			this.btnVerificar.HeightRequest = 35;
			this.btnVerificar.CanFocus = true;
			this.btnVerificar.Name = "btnVerificar";
			this.btnVerificar.UseUnderline = true;
			this.btnVerificar.Label = global::Mono.Unix.Catalog.GetString("Verificar");
			this.fixed3.Add(this.btnVerificar);
			global::Gtk.Fixed.FixedChild w19 = ((global::Gtk.Fixed.FixedChild)(this.fixed3[this.btnVerificar]));
			w19.X = 128;
			w19.Y = 533;
			// Container child fixed3.Gtk.Fixed+FixedChild
			this.lbl = new global::Gtk.Label();
			this.lbl.Name = "lbl";
			this.lbl.LabelProp = global::Mono.Unix.Catalog.GetString("Habitación:");
			this.fixed3.Add(this.lbl);
			global::Gtk.Fixed.FixedChild w20 = ((global::Gtk.Fixed.FixedChild)(this.fixed3[this.lbl]));
			w20.X = 37;
			w20.Y = 87;
			// Container child fixed3.Gtk.Fixed+FixedChild
			this.txtHab = new global::Gtk.Entry();
			this.txtHab.CanFocus = true;
			this.txtHab.Name = "txtHab";
			this.txtHab.IsEditable = false;
			this.txtHab.InvisibleChar = '•';
			this.fixed3.Add(this.txtHab);
			global::Gtk.Fixed.FixedChild w21 = ((global::Gtk.Fixed.FixedChild)(this.fixed3[this.txtHab]));
			w21.X = 121;
			w21.Y = 83;
			this.Add(this.fixed3);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 811;
			this.DefaultHeight = 596;
			this.Show();
			this.btn_fijarEntrada.Clicked += new global::System.EventHandler(this.OnBtnFijarEntradaClicked);
			this.btn_fijarSalida.Clicked += new global::System.EventHandler(this.OnBtnFijarSalidaClicked);
			this.btn_aceptar.Clicked += new global::System.EventHandler(this.OnBtnAceptarClicked);
			this.btn_cancelar.Clicked += new global::System.EventHandler(this.OnBtnCancelarClicked);
			this.twHabitaciones.CursorChanged += new global::System.EventHandler(this.OnTwHabitacionesCursorChanged);
			this.btnVerificar.Clicked += new global::System.EventHandler(this.OnBtnVerificarClicked);
		}
	}
}
