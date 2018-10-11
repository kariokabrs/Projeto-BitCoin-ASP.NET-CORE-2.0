using CbWebApp.Context;
using CbWebApp.Domains;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CbWebApp.Repositories
{
    public class ContratoRepository : IContratoRepository
    {
        private readonly DB_A40F70_cbContext CbContext;
        public ContratoRepository(DB_A40F70_cbContext cbContext)
        {
            CbContext = cbContext;
        }
        public async Task<IAsyncEnumerable<Contrato>> GetAllAsync()
        {
            List<Contrato> listaDeContrato = new List<Contrato>();
            listaDeContrato = await CbContext.Contrato.AsNoTracking().OrderBy(c => c.NuContrato).ToListAsync();
            return listaDeContrato.ToAsyncEnumerable();
        }
    }
}
