using System.ComponentModel.DataAnnotations;

namespace SamStore.Identidade.API.Models
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Password { get; set; }
    }
}
