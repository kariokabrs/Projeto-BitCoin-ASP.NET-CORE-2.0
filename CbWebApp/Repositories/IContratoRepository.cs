using CbWebApp.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CbWebApp.Repositories
{
    public interface IContratoRepository
    {
        Task<IAsyncEnumerable<Contrato>> GetAllAsync();
    }
}
