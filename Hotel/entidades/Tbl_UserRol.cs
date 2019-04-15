using System;
namespace Hotel.entidades
{
    public class Tbl_UserRol
    {

        private int id_userRol;
        private int id_user;
        private int id_rol;


        public Tbl_UserRol()
        {
        }

        public int Id_userRol { get => id_userRol; set => id_userRol = value; }
        public int Id_user { get => id_user; set => id_user = value; }
        public int Id_rol { get => id_rol; set => id_rol = value; }
    }
}
