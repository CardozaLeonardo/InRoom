using System;
namespace Hotel.entidades
{
    public class Tbl_producto
    {
        private int id_producto;
        private String descripcion;
        private float costo;
        private float impuesto;
        private int id_tipoProducto;
        private String marca;
        private float precio;
        private String fecha_vencimiento;
        private String codigoBarra;
        private int estado;



        public Tbl_producto()
        {
        }

        public int Id_producto { get => id_producto; set => id_producto = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public float Precio { get => precio; set => precio = value; }
        public int Id_tipoProducto { get => id_tipoProducto; set => id_tipoProducto = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Fecha_vencimiento { get => fecha_vencimiento; set => fecha_vencimiento = value; }
        public int Estado { get => estado; set => estado = value; }
        public float Costo { get => costo; set => costo = value; }
        public float Impuesto { get => impuesto; set => impuesto = value; }
        public string CodigoBarra { get => codigoBarra; set => codigoBarra = value; }
    }
}
