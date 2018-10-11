using CbWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CbWebApp.Services
{
    public interface IContratoService
    {
        Task<IEnumerable<Contrato>> GetAllAsync();
    }
}
