
using System;
namespace Hotel.entidades
{
    public class Tbl_hotel
    {

        private int id_hotel;
        private String nombre;
        private String direccion;
        private String telefono;
        private String website;
        private String pieDeImprenta;
        private String RUC;


        public Tbl_hotel()
        {
        }

        public int Id_hotel { get => id_hotel; set => id_hotel = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Website { get => website; set => website = value; }
        public string PieDeImprenta { get => pieDeImprenta; set => pieDeImprenta = value; }
        public string RUC1 { get => RUC; set => RUC = value; }
    }
}
