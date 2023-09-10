using System.ComponentModel.DataAnnotations;

namespace SamStore.Authentication.API.Models
{
    public record LoginDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Password { get; set; }
    }
}
