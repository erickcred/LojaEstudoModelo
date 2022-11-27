using System.ComponentModel.DataAnnotations;

namespace ECommerce.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-mail deve ser preenchido!")]
        [EmailAddress(ErrorMessage = "Usuário ou senha Invalidos!")]
        [Display(Name = "E-mail")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Senha deve ser preenchido!")]
        [EmailAddress(ErrorMessage = "Usuário ou senha Invalidos!")]
        public String Senha { get; set; }

    }
}