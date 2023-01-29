using System.ComponentModel.DataAnnotations;

namespace SamStore.Identidade.API.Models
{
    public class RegisterUserDTO
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [EmailAddress(ErrorMessage = "O campo {0} está inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(40, ErrorMessage = "{0} must have between {2} and {1} characters", MinimumLength = 6)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password mismatched")]
        public string RepeatPassword { get; set; }
    }
}
