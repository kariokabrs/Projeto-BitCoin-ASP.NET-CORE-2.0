using CbWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CbWebApp.DTOs
{
    public class ContratoDTO
    {
        public ContratoDTO(Contrato contrato)
        {
            this.IdContrato = contrato.IdContrato;
            this.NuContrato = contrato.NuContrato;
            this.IdCliente = contrato.IdCliente;
            this.DtEmissao = contrato.DtEmissao;
            this.DtRetorno = contrato.DtRetorno;
            this.NuParcela = contrato.NuParcela;
            this.NuRendimento = contrato.NuRendimento;
            this.DtCadastro = contrato.DtCadastro;
            this.NmRespCadastro = contrato.NmRespCadastro;
            this.FlAtivo = contrato.FlAtivo;
            this.ContratoParcela = contrato.ContratoParcela;
            this.ContratoResponsavel = contrato.ContratoResponsavel;
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
