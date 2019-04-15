using System;
namespace Hotel.entidades
{
    public class Vw_tarjetas
    {
        private int id_tarjeta;
        private String numeroTarjeta;
        private String nombre_titular;
        private String fecha_expiracion;
        private String tipo_tarjeta;
        private String emisor;
        private int id_factura;

        public Vw_tarjetas()
        {
        }

        public int Id_tarjeta { get => id_tarjeta; set => id_tarjeta = value; }
        public string NumeroTarjeta { get => numeroTarjeta; set => numeroTarjeta = value; }
        public string Nombre_titular { get => nombre_titular; set => nombre_titular = value; }
        public string Fecha_expiracion { get => fecha_expiracion; set => fecha_expiracion = value; }
        public string Tipo_tarjeta { get => tipo_tarjeta; set => tipo_tarjeta = value; }
        public string Emisor { get => emisor; set => emisor = value; }
        public int Id_factura { get => id_factura; set => id_factura = value; }
    }
}
