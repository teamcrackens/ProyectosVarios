using System.ComponentModel.DataAnnotations;

namespace Sistema.Web2.Models.Usuarios.Usuario
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
