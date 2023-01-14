using System.ComponentModel.DataAnnotations;

namespace SamStore.Identidade.API.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(40, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
