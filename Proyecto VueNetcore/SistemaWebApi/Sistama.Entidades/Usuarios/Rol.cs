﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Entidades.Usuarios
{
    public class Rol
    {
            public int idrol { get; set; }
            [Required]
            [StringLength(30, MinimumLength = 3, ErrorMessage = "el nombre no debe tener mas de 30 caracteres, ni menos de 3 caracteres.")]
            public string nombre { get; set; }
            [StringLength(256)]
            public string descripcion { get; set; }
            public bool condicion { get; set; }
            public ICollection<Usuario> Usuarios { get; set; }
    }
}
