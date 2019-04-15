using System;
namespace Hotel.entidades
{
    public class Tbl_huesped
    {
        private int id_huesped;
        private String cedula;
        private String nombres;
        private String apellidos;
        private String telefono;
        private String email;


        public Tbl_huesped()
        {
        }

        public int Id_huesped { get => id_huesped; set => id_huesped = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
    }
}
