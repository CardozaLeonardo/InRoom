using System;
namespace Hotel.entidades
{
    public class Tbl_emisorTarjeta
    {
        private int id_emisorTarjeta;
        private String emisor;
        private int estado;

        public Tbl_emisorTarjeta()
        {
        }

        public int Id_emisorTarjeta { get => id_emisorTarjeta; set => id_emisorTarjeta = value; }
        public string Emisor { get => emisor; set => emisor = value; }
        public int Estado { get => estado; set => estado = value; }
    }
}
