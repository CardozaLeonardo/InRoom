
using System;
namespace Hotel.entidades
{
    public class Tbl_reservacion
    {

        private int id_reservacion;
        private int num_reserv;
        private String fecha;
        private int  id_factura;
        private int estado;
        private int id_huesped;
        public Tbl_reservacion()
        {
        }

        public int Id_reservacion { get => id_reservacion; set => id_reservacion = value; }
        public int Num_reserv { get => num_reserv; set => num_reserv = value; }
        public int Estado { get => estado; set => estado = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public int Id_factura { get => id_factura; set => id_factura = value; }
        public int Id_huesped { get => id_huesped; set => id_huesped = value; }
    }
}
