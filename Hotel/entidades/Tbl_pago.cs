using System;
namespace Hotel.entidades
{
    public class Tbl_pago
    {
        private int id_pago;
        private int id_tipoPago;
        private int id_tarjeta;
        private int id_factura;


        public Tbl_pago()
        {
        }

        public int Id_pago { get => id_pago; set => id_pago = value; }
        public int Id_tipoPago { get => id_tipoPago; set => id_tipoPago = value; }
        public int Id_tarjeta { get => id_tarjeta; set => id_tarjeta = value; }
        public int Id_factura { get => id_factura; set => id_factura = value; }
    }
}
