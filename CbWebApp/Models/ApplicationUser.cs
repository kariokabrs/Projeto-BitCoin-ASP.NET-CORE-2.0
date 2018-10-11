using CbWebApp.Domains;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CbWebApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Nome { get; set; }
        public virtual ICollection<Tarefa> Tarefas { get; set; }
    }
}
