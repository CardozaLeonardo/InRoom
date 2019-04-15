using System;
namespace Hotel.entidades
{
    public class Vw_productos
    {
        private int id_producto;
        private String descripcion;
        private float precio;
        private int impuesto;
        private String tipoProducto;
        public Vw_productos()
        {
        }

        public int Id_producto { get => id_producto; set => id_producto = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public float Precio { get => precio; set => precio = value; }
        public int Impuesto { get => impuesto; set => impuesto = value; }
        public string TipoProducto { get => tipoProducto; set => tipoProducto = value; }
    }
}
