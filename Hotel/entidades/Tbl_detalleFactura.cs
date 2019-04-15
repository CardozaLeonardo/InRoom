using System;
namespace Hotel.entidades
{
    public class Tbl_detalleFactura
    {
        private int id_detalleFactura;
        private int id_producto;
        private int id_factura;
        private String descripcion;
        private int cantidad;
        private float precio;
        private float subtotal;


        public Tbl_detalleFactura()
        {
        }

        public int Id_detalleFactura { get => id_detalleFactura; set => id_detalleFactura = value; }
        public int Id_producto { get => id_producto; set => id_producto = value; }
        public int Id_factura { get => id_factura; set => id_factura = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public float Precio { get => precio; set => precio = value; }
        public float Subtotal { get => subtotal; set => subtotal = value; }
    }
}
