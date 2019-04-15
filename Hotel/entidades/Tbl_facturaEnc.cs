using System;
namespace Hotel.entidades
{
    public class Tbl_facturaEnc
    {
        private int id_factura;
        private int id_hotel;
        private int numero_factura;
        private String fecha;
        private int id_user;
        private int id_reservacion;
        private int id_huesped;
        private String identificacion;
        private float subtotal;
        private float impuesto;
        private float descuento;
        private float total;


        public Tbl_facturaEnc()
        {
        }

        public int Id_factura { get => id_factura; set => id_factura = value; }
        public int Id_hotel { get => id_hotel; set => id_hotel = value; }
        public int Numero_factura { get => numero_factura; set => numero_factura = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public int Id_user { get => id_user; set => id_user = value; }
        public int Id_huesped { get => id_huesped; set => id_huesped = value; }
        public float Subtotal { get => subtotal; set => subtotal = value; }
        public float Impuesto { get => impuesto; set => impuesto = value; }
        public float Descuento { get => descuento; set => descuento = value; }
        public float Total { get => total; set => total = value; }
        public int Id_reservacion { get => id_reservacion; set => id_reservacion = value; }
        public string Identificacion { get => identificacion; set => identificacion = value; }
    }
}
