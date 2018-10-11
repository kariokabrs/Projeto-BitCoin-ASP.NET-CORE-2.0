using System.ComponentModel.DataAnnotations;

namespace CbWebApp.Models.AccountViewModels
{
    public class LoginWith2faViewModel
    {
        [Required]
        [StringLength(7, ErrorMessage = "O {0} deve ter ao menos {2} e no máximo {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Authenticator code")]
        public string TwoFactorCode { get; set; }

        [Display(Name = "Lembrar este equipamento")]
        public bool RememberMachine { get; set; }

        public bool RememberMe { get; set; }
    }
}
