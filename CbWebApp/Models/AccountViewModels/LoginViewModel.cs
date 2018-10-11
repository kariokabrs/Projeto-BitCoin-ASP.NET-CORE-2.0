using System.ComponentModel.DataAnnotations;

namespace CbWebApp.Models.AccountViewModels
{
    public class LoginViewModel
    {

        //[Required]
        //[Display(Name = "Usuario")]
        //public string Username { get; set; }
        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage ="A senha é obrigatória")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Lembrar?")]
        public bool RememberMe { get; set; }
    }
}
