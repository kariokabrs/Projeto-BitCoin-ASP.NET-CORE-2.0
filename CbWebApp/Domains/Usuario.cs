using System;
using System.Collections.Generic;

namespace CbWebApp.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            BancoUsuario = new HashSet<BancoUsuario>();
            ContratoResponsavel = new HashSet<ContratoResponsavel>();
            FilialUsuario = new HashSet<FilialUsuario>();
            LembreteEnvolvido = new HashSet<LembreteEnvolvido>();
            LembreteIdClienteNavigation = new HashSet<Lembrete>();
            LembreteIdRespCadastroNavigation = new HashSet<Lembrete>();
        }

        public int IdUsuario { get; set; }
        public int IdPdTipoUsuario { get; set; }
        public string NmUsuario { get; set; }
        public string NuCpfCnpj { get; set; }
        public string NuRg { get; set; }
        public string NmOrgaoRg { get; set; }
        public string NuTelFixo { get; set; }
        public string NuTelCelular { get; set; }
        public string NuCep { get; set; }
        public string NmUf { get; set; }
        public string NmMunicipio { get; set; }
        public string NmBairro { get; set; }
        public string NmLogradouro { get; set; }
        public string NuLogradouro { get; set; }
        public string NuLogradouroComp { get; set; }
        public string NmProfissao { get; set; }
        public DateTime? DtNascimento { get; set; }
        public bool FlAlerta { get; set; }
        public DateTime DtCadastro { get; set; }
        public string NmRespCadastro { get; set; }
        public bool? FlAtivo { get; set; }

        public PropriedadeDominio IdPdTipoUsuarioNavigation { get; set; }
        public ICollection<BancoUsuario> BancoUsuario { get; set; }
        public ICollection<ContratoResponsavel> ContratoResponsavel { get; set; }
        public ICollection<FilialUsuario> FilialUsuario { get; set; }
        public ICollection<LembreteEnvolvido> LembreteEnvolvido { get; set; }
        public ICollection<Lembrete> LembreteIdClienteNavigation { get; set; }
        public ICollection<Lembrete> LembreteIdRespCadastroNavigation { get; set; }
    }
}
