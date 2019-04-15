using System;
namespace Hotel.entidades
{
    public class Vw_users
    {
        private int id_user;
        private String user;
        private String nombres;
        private String apellidos;
        private String email;
        private String rol;
        public Vw_users()
        {
        }

        public int Id_user { get => id_user; set => id_user = value; }
        public string User { get => user; set => user = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Email { get => email; set => email = value; }
        public string Rol { get => rol; set => rol = value; }
    }
}
