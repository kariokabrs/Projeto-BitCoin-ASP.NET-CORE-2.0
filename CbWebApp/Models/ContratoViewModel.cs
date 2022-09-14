using CbWebApp.DTOs;
using System.Collections.Generic;

namespace CbWebApp.Models
{
    public class ContratoViewModel
    {
      public IAsyncEnumerable<ContratoDTO> Contratos { get; set; }
    }
}
