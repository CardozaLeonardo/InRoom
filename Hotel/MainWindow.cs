﻿using System;
using Gtk;
using Hotel;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void OnSalirActionActivated(object sender, EventArgs e)
    {
        Application.Quit();
    }

    protected void OnHabitacionesActionActivated(object sender, EventArgs e)
    {
        //fmrGestionHabitaciones hab = new fmrGestionHabitaciones();
        //hab.Show();

        //frmGestionHabitaciones fgh = new frmGestionHabitaciones();
        //fgh.Show();
    }

    protected void OnNuevaReservacinActionActivated(object sender, EventArgs e)
    {
        fmr_Reservacion res = new fmr_Reservacion();
        res.Show();
    }

    protected void OnUsuariosAction1Activated(object sender, EventArgs e)
    {
        fmr_usuario user = new fmr_usuario();
        user.Show();
    }

    //protected void OnTarjetasActionActivated(object sender, EventArgs e)
    //{
    //    fmr_tarjetas tar = new fmr_tarjetas();
    //    tar.Show();
    //}

    protected void OnHuespedesActionActivated(object sender, EventArgs e)
    {
        fmr_huespedes huesped = new fmr_huespedes();
        huesped.Show();
    }

    protected void OnCerrarSesinActionActivated(object sender, EventArgs e)
    {
        fmr_login login = new fmr_login();
        login.Show();
        this.Hide();
    }

    protected void OnEmisoresActionActivated(object sender, EventArgs e)
    {
        //frm_EmisorTarjeta fet = new frm_EmisorTarjeta();
        //fet.Show();
    }

    protected void OnRegistroActionActivated(object sender, EventArgs e)
    {
        frm_reservaciones frm = new frm_reservaciones();
        frm.Show();
    }

    protected void OnAsignarOpcinARolActionActivated(object sender, EventArgs e)
    {
        frmOpcionRol form = new frmOpcionRol();
        form.Show();
    }

    protected void OnGestinDeOpcionesActionActivated(object sender, EventArgs e)
    {
        frmOpciones opciones = new frmOpciones();
        opciones.Show();
    }

    protected void OnGestinRolesActionActivated(object sender, EventArgs e)
    {
        frmRoles fmrs = new frmRoles();
        fmrs.Show();
    }

    protected void OnTipoDeHabitacionesActionActivated(object sender, EventArgs e)
    {
        frmTipoHabitaciones fth = new frmTipoHabitaciones();
        fth.Show();
    }

    protected void OnTarjetasAction1Activated(object sender, EventArgs e)
    {
        fmr_tarjetas fmt = new fmr_tarjetas();
        fmt.Show();
    }

    protected void OnAsignarRolAUsuarioActionActivated(object sender, EventArgs e)
    {
        frmUserRol fur = new frmUserRol();
        fur.Show();
    }
}
