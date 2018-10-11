using System;
using System.Collections.Generic;

namespace CbWebApp.Domains
{
    public partial class Contrato
    {
        public Contrato()
        {
            ContratoParcela = new HashSet<ContratoParcela>();
            ContratoResponsavel = new HashSet<ContratoResponsavel>();
        }

        public int IdContrato { get; set; }
        public string NuContrato { get; set; }
        public int IdCliente { get; set; }
        public DateTime DtEmissao { get; set; }
        public DateTime? DtRetorno { get; set; }
        public decimal VlContrato { get; set; }
        public int NuParcela { get; set; }
        public string NuRendimento { get; set; }
        public DateTime DtCadastro { get; set; }
        public string NmRespCadastro { get; set; }
        public bool? FlAtivo { get; set; }

        public ICollection<ContratoParcela> ContratoParcela { get; set; }
        public ICollection<ContratoResponsavel> ContratoResponsavel { get; set; }
    }
}
