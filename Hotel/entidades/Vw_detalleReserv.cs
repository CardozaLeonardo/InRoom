using System;
namespace Hotel.entidades
{
    public class Vw_detalleReserv
    {
        private int id_detalleReserv;
        private int id_reservacion;
        private int id_habitacion;
        private String numeroHab;
        private String descripcion;
        private String fechaEntrada;
        private String fechaSalida;
        private String horaEntrada;
        private String horaSalida;
        private bool indicador = false;

        public Vw_detalleReserv()
        {
        }

        public int Id_detalleReserv { get => id_detalleReserv; set => id_detalleReserv = value; }
        public int Id_reservacion { get => id_reservacion; set => id_reservacion = value; }
        public int Id_habitacion { get => id_habitacion; set => id_habitacion = value; }
        public string NumeroHab { get => numeroHab; set => numeroHab = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string FechaEntrada { get => fechaEntrada; set => fechaEntrada = value; }
        public string FechaSalida { get => fechaSalida; set => fechaSalida = value; }
        public string HoraEntrada { get => horaEntrada; set => horaEntrada = value; }
        public string HoraSalida { get => horaSalida; set => horaSalida = value; }
        public bool Indicador { get => indicador; set => indicador = value; }
    }
}
