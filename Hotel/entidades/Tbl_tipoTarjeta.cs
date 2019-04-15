using System;
namespace Hotel.entidades
{
    public class Tbl_tipoTarjeta
    {
        private int id_tipoTarjeta;
        private String tipo_tarjeta;
        private int estado;



        public Tbl_tipoTarjeta()
        {
        }

        public int Id_tipoTarjeta { get => id_tipoTarjeta; set => id_tipoTarjeta = value; }
        public string Tipo_tarjeta { get => tipo_tarjeta; set => tipo_tarjeta = value; }
        public int Estado { get => estado; set => estado = value; }
    }
}
