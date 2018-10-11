using System.Linq;
using CbWebApp.Domains;

namespace CbWebApp.DTOs
{
    public class TarefaDTO
    {
        public IQueryable<Tarefa> Items { get; set; }
    }
}