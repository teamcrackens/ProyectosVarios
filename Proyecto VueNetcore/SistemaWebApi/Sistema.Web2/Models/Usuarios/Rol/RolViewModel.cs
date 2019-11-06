﻿using System.ComponentModel.DataAnnotations;

namespace Sistema.Web2.Models.Usuarios.Rol
{
    public class RolViewModel
    {
        public int idrol { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public bool condicion { get; set; }
    }
}
