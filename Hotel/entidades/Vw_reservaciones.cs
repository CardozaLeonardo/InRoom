using System;
namespace Hotel.entidades
{
    public class Vw_reservaciones
    {

        private int id_reservaciones;
        private int numero;
        private String fecha;
        private String nombres;
        private String apellidos;
        private String cedula;
        private int habitaciones;

        public Vw_reservaciones()
        {
        }

        public int Id_reservaciones { get => id_reservaciones; set => id_reservaciones = value; }
        public int Numero { get => numero; set => numero = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public int Habitaciones { get => habitaciones; set => habitaciones = value; }
    }
}
