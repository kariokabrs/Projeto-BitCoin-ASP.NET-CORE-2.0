using System;
using System.Collections.Generic;

namespace CbWebApp.Domains
{
    public partial class ContratoParcela
    {
        public int IdContratoParcela { get; set; }
        public int IdContrato { get; set; }
        public int NuParcela { get; set; }
        public decimal VlRendimento { get; set; }
        public decimal VlComissao { get; set; }
        public DateTime DtPagamento { get; set; }
        public bool FlReaplicar { get; set; }

        public Contrato IdContratoNavigation { get; set; }
    }
}
