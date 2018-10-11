using System;
using System.Collections.Generic;

namespace CbWebApp.Domains
{
    public partial class Documento
    {
        public int IdDocumento { get; set; }
        public int IdPdTipoDocumento { get; set; }
        public string NmOrigem { get; set; }
        public int IdOrigem { get; set; }
        public string NmDocumento { get; set; }
        public string NmExtensao { get; set; }
        public string NuTamanho { get; set; }
        public string DsDocumento { get; set; }
        public DateTime DtCadastro { get; set; }
        public string NmRespCadastro { get; set; }

        public PropriedadeDominio IdPdTipoDocumentoNavigation { get; set; }
    }
}
