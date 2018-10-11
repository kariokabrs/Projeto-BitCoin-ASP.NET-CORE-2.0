using System;
using System.Collections.Generic;

namespace CbWebApp.Domains
{
    public partial class BancoUsuario
    {
        public int IdBancoUsuario { get; set; }
        public int IdUsuario { get; set; }
        public int IdPdBanco { get; set; }
        public string NuAgencia { get; set; }
        public string NuAgenciaDigito { get; set; }
        public string NuConta { get; set; }
        public string NuContaDigito { get; set; }

        public PropriedadeDominio IdPdBancoNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
    }
}
