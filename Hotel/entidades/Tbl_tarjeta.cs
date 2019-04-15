using System;
namespace Hotel.entidades
{
    public class Tbl_tarjeta
    {
        private int id_tarjeta;
        private String numeroTarjeta;
        private String nombre_titular;
        private String fecha_expiracion;
        private int id_emisorTarjeta;
        private int id_tipoTarjeta;
        private int id_factura;

        public Tbl_tarjeta()
        {
        }

        public int Id_tarjeta { get => id_tarjeta; set => id_tarjeta = value; }
        public string NumeroTarjeta { get => numeroTarjeta; set => numeroTarjeta = value; }
        public string Nombre_titular { get => nombre_titular; set => nombre_titular = value; }
        public string Fecha_expiracion { get => fecha_expiracion; set => fecha_expiracion = value; }
        public int Id_emisorTarjeta { get => id_emisorTarjeta; set => id_emisorTarjeta = value; }
        public int Id_tipoTarjeta { get => id_tipoTarjeta; set => id_tipoTarjeta = value; }
        public int Id_factura { get => id_factura; set => id_factura = value; }
    }
}
