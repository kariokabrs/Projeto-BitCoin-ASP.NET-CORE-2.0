using System;
using System.Collections.Generic;

namespace CbWebApp.Domains
{
    public partial class ContratoResponsavel
    {
        public int IdContratoResponsavel { get; set; }
        public int IdContrato { get; set; }
        public int IdPdFilial { get; set; }
        public int IdUsuario { get; set; }
        public string NuComissao { get; set; }

        public Contrato IdContratoNavigation { get; set; }
        public PropriedadeDominio IdPdFilialNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
    }
}
