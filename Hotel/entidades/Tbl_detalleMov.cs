using System;
namespace Hotel.entidades
{
    public class Tbl_detalleMov
    {
        private int id_detalleMov;
        private int id_movimiento;
        private int id_producto;
        private int cant_inical;
        private int cant_nueva;
        private int stock;

        public Tbl_detalleMov()
        {
        }

        public int Id_detalleMov { get => id_detalleMov; set => id_detalleMov = value; }
        public int Id_movimiento { get => id_movimiento; set => id_movimiento = value; }
        public int Id_producto { get => id_producto; set => id_producto = value; }
        public int Cant_inical { get => cant_inical; set => cant_inical = value; }
        public int Cant_nueva { get => cant_nueva; set => cant_nueva = value; }
        public int Stock { get => stock; set => stock = value; }
    }
}
