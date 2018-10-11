using System;
using System.Collections.Generic;

namespace CbWebApp.Domains
{
    public partial class Propriedade
    {
        public Propriedade()
        {
            PropriedadeDominio = new HashSet<PropriedadeDominio>();
        }

        public int IdPropriedade { get; set; }
        public string NmPropriedade { get; set; }
        public bool? FlAtivo { get; set; }
        public bool? FlEditavel { get; set; }
        public DateTime DtCadastro { get; set; }

        public ICollection<PropriedadeDominio> PropriedadeDominio { get; set; }
    }
}
