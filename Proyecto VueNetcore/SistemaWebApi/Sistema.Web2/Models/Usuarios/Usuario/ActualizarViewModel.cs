﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Web2.Models.Usuarios.Usuario
{
    public class ActualizarViewModel
    {
        [Required]
        public int idusuario { get; set; }
        [Required]
        public int idrol { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "el nombre no debe tener mas de 100 caracteres, ni menos de 3 caracteres.")]
        public string nombre { get; set; }
        public string tipo_documento { get; set; }
        public string num_documento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        public bool act_password { get; set; }
    }
}
