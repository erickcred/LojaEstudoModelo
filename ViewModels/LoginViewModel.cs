using System.ComponentModel.DataAnnotations;
using ECommerce.Data;
using ECommerce.Models;

namespace ECommerce.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-mail deve ser preenchido!")]
        [EmailAddress(ErrorMessage = "O E-mail digitado não parece ser valido!")]
        [Display(Name = "E-mail")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Usuário ou senha Invalidos!")]
        public String Senha { get; set; }

        public Cliente ValidaLogin(ECommerceContext _context, LoginViewModel model)
        {
            try
            {
                var cliente = _context.Clientes.FirstOrDefault(x => x.Email == model.Email);
                if (cliente.Senha == model.Senha)
                    return cliente;
                return null;
            } catch (NullReferenceException error)
            {
                return null;
            }
        }
    }
}