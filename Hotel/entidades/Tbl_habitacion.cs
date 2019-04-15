using System;
namespace Hotel.entidades
{
    public class Tbl_habitacion
    {
        private int id_habitacion;
        private String numero;
        private int id_tipoHabitacion;
        private int estado;

        public Tbl_habitacion()
        {
        }

        public int Id_habitacion { get => id_habitacion; set => id_habitacion = value; }
        public string Numero { get => numero; set => numero = value; }
        public int Id_tipoHabitacion { get => id_tipoHabitacion; set => id_tipoHabitacion = value; }
        public int Estado { get => estado; set => estado = value; }
    }
}
