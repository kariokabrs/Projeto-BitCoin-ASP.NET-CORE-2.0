using System;
using System.Collections.Generic;

namespace CbWebApp.Domains
{
    public partial class Lembrete
    {
        public Lembrete()
        {
            LembreteEnvolvido = new HashSet<LembreteEnvolvido>();
        }

        public int IdLembrete { get; set; }
        public DateTime DtCadastro { get; set; }
        public DateTime? DtLembrete { get; set; }
        public int IdRespCadastro { get; set; }
        public int? IdCliente { get; set; }
        public string DsLembrete { get; set; }

        public Usuario IdClienteNavigation { get; set; }
        public Usuario IdRespCadastroNavigation { get; set; }
        public ICollection<LembreteEnvolvido> LembreteEnvolvido { get; set; }
    }
}
