using System;
using System.Collections.Generic;

namespace CbWebApp.Domains
{
    public partial class PropriedadeDominio
    {
        public PropriedadeDominio()
        {
            BancoUsuario = new HashSet<BancoUsuario>();
            ContratoResponsavel = new HashSet<ContratoResponsavel>();
            Documento = new HashSet<Documento>();
            FilialUsuario = new HashSet<FilialUsuario>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdPropriedadeDominio { get; set; }
        public int IdPropriedade { get; set; }
        public string NmPropriedadeDominio { get; set; }
        public bool? FlAtivo { get; set; }
        public DateTime DtCadastro { get; set; }
        public string NmRespCadastro { get; set; }

        public Propriedade IdPropriedadeNavigation { get; set; }
        public ICollection<BancoUsuario> BancoUsuario { get; set; }
        public ICollection<ContratoResponsavel> ContratoResponsavel { get; set; }
        public ICollection<Documento> Documento { get; set; }
        public ICollection<FilialUsuario> FilialUsuario { get; set; }
        public ICollection<Usuario> Usuario { get; set; }
    }
}
