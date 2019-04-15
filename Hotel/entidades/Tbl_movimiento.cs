using System;
namespace Hotel.entidades
{
    public class Tbl_movimiento
    {
        private int id_movimiento;
        private int id_tipoMovimiento;


        public Tbl_movimiento()
        {
        }

        public int Id_movimiento { get => id_movimiento; set => id_movimiento = value; }
        public int Id_tipoMovimiento { get => id_tipoMovimiento; set => id_tipoMovimiento = value; }
    }
}
