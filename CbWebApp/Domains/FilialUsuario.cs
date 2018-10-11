using System;
using System.Collections.Generic;

namespace CbWebApp.Domains
{
    public partial class FilialUsuario
    {
        public int IdFilialUsuario { get; set; }
        public int IdUsuario { get; set; }
        public int IdPdFilial { get; set; }

        public PropriedadeDominio IdPdFilialNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
    }
}
