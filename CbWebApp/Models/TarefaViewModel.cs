using System;
using System.ComponentModel.DataAnnotations;

namespace CbWebApp.Models
{
    public class TarefaViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome {get; set;}

        public bool Completa { get; set; }
    }
}
