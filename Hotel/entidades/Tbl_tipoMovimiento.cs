using System;
namespace Hotel.entidades
{
    public class Tbl_tipoMovimiento
    {
        private int id_tipoMovimiento;
        private String descripcion;

        public Tbl_tipoMovimiento()
        {
        }

        public int Id_tipoMovimiento { get => id_tipoMovimiento; set => id_tipoMovimiento = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
