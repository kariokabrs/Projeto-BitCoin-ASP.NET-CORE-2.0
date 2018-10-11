using CbWebApp.DTOs;
using CbWebApp.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CbWebApp.Services
{
    public class ContratoService : IContratoService
    {
        private readonly IContratoRepository ContratoRepository;
        public ContratoService(IContratoRepository contratoRepository)
        {
            ContratoRepository = contratoRepository;
        }

        public async Task<IAsyncEnumerable<ContratoDTO>> ContratoServiceGetAll()
        {
            List<ContratoDTO> listaDeContrato = new List<ContratoDTO>();
            listaDeContrato = await ContratoRepository.GetAllAsync().Result.Select(u => new ContratoDTO(u)).ToList();
            return listaDeContrato.ToAsyncEnumerable();
        }
    }
}
