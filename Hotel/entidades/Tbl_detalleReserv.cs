using System;
namespace Hotel.entidades
{
    public class Tbl_detalleReserv
    {
        private int id_detalleReserv;
        private int id_reservacion;
        private int id_habitacion;
        private String fecha_entrada;
        private String fecha_salida;
        private String hora_entrada;
        private String hora_salida;
        private String tipoHabitacion;
        private String numero;


        public Tbl_detalleReserv()
        {
        }

        public int Id_detalleReserv { get => id_detalleReserv; set => id_detalleReserv = value; }
        public int Id_reservacion { get => id_reservacion; set => id_reservacion = value; }
        public int Id_habitacion { get => id_habitacion; set => id_habitacion = value; }
        public string Fecha_entrada { get => fecha_entrada; set => fecha_entrada = value; }
        public string Fecha_salida { get => fecha_salida; set => fecha_salida = value; }
        public string Hora_entrada { get => hora_entrada; set => hora_entrada = value; }
        public string Hora_salida { get => hora_salida; set => hora_salida = value; }
        public string TipoHabitacion { get => tipoHabitacion; set => tipoHabitacion = value; }
        public string Numero { get => numero; set => numero = value; }
    }
}
