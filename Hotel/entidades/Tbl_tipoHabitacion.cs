using System;
namespace Hotel.entidades
{
    public class Tbl_tipoHabitacion
    {
        private int id_tipoHabitacion;
        private String descripcion;
        private int estado;

        public Tbl_tipoHabitacion()
        {
        }

        public int Id_tipoHabitacion { get => id_tipoHabitacion; set => id_tipoHabitacion = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Estado { get => estado; set => estado = value; }
    }
}
