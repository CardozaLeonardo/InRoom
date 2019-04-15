using System;
namespace Hotel.entidades
{
    public class Tbl_rolOption
    {

        private int id_rolOption;
        private int id_rol;
        private int id_option;


        public Tbl_rolOption()
        {
        }

        public int Id_rolOption { get => id_rolOption; set => id_rolOption = value; }
        public int Id_rol { get => id_rol; set => id_rol = value; }
        public int Id_option { get => id_option; set => id_option = value; }
    }
}
