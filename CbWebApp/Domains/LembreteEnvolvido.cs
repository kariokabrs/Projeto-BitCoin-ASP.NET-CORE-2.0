using System;
using System.Collections.Generic;

namespace CbWebApp.Domains
{
    public partial class LembreteEnvolvido
    {
        public int IdLembreteEnvolvido { get; set; }
        public int IdLembrete { get; set; }
        public int IdUsuario { get; set; }

        public Lembrete IdLembreteNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
    }
}
