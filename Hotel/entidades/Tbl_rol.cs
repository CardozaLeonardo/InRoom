using System;
namespace Hotel.entidades
{
    public class Tbl_rol
    {
        private int id_rol;
        private String rol;
        private int estado;


        public Tbl_rol()
        {
        }

        public int Id_rol { get => id_rol; set => id_rol = value; }
        public string Rol { get => rol; set => rol = value; }
        public int Estado { get => estado; set => estado = value; }
    }
}
