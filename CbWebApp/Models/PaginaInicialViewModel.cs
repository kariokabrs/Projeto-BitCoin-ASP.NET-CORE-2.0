using System.ComponentModel.DataAnnotations;

namespace CbWebApp.Models
{
    public class PaginaInicialViewModel
    {
        [EnumDataType(typeof(FiltroDias))]
        public FiltroDias FiltroDias { get; set; }
    }

    public enum FiltroDias
    {
        Hoje = 1,
        Semanal = 7,
        Quinzenal = 15,
        Mensal = 30,
        Bimestral = 60,
        Trimestral = 90
    };
}
