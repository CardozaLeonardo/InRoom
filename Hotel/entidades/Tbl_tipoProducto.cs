using System;
namespace Hotel.entidades
{
    public class Tbl_tipoProducto
    {
        private int id_tipoProducto;
        private String tipoProductos;


        public Tbl_tipoProducto()
        {
        }

        public int Id_tipoProducto { get => id_tipoProducto; set => id_tipoProducto = value; }
        public string TipoProductos { get => tipoProductos; set => tipoProductos = value; }
    }
}
