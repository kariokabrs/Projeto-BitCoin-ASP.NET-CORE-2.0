﻿using CbWebApp.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CbWebApp.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "O nome é requerido")]
        [Display(Name = "Usuario")]
        [StringLength(100, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caractere", MinimumLength = 5)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é requerido")]
        [EmailDnsValidation(ErrorMessage = "O email não é um válido DNS")]
        [EmailAddress(ErrorMessage = "O email não é válido")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é requerida")]
        [StringLength(100, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caractere", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmação da senha")]
        [Compare("Password", ErrorMessage = "A senha e a confirmação da senha não são iguais.")]
        public string ConfirmPassword { get; set; }

        public string Roles { get; set; }
        public List<SelectListItem> RolesList { get; set; }
    }
}

