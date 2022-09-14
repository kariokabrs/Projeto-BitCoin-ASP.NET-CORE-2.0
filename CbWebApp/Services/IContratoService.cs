using CbWebApp.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CbWebApp.Services
{
    public interface IContratoService
    {
        Task<IAsyncEnumerable<ContratoDTO>> ContratoServiceGetAll();
    }
}
