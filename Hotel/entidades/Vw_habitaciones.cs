using System;
namespace Hotel.entidades
{
    public class Vw_habitaciones
    {
        private int id_habitacion;
        private String numero;
        private String tipoHabitacion;
        private int estado;
        public Vw_habitaciones()
        {
        }

        public int Id_habitacion { get => id_habitacion; set => id_habitacion = value; }
        public string Numero { get => numero; set => numero = value; }
        public string TipoHabitacion { get => tipoHabitacion; set => tipoHabitacion = value; }
        public int Estado { get => estado; set => estado = value; }
    }
}
