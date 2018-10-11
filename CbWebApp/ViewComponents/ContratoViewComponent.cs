using CbWebApp.Context;
using CbWebApp.Models;
using CbWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CbWebApp.ViewComponents
{
    public class ContratoViewComponent : ViewComponent
    {
        private readonly DB_A40F70_cbContext CbContext;
        private readonly IContratoService ContratoSerivce;

        public ContratoViewComponent(DB_A40F70_cbContext cbContext, IContratoService contratoSerivce)
        {
            CbContext = cbContext;
            ContratoSerivce = contratoSerivce;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ContratoViewModel listaContrato = new ContratoViewModel
            {
                Contratos = await ContratoSerivce.ContratoServiceGetAll()
            };
             return View(listaContrato);
        }
     }
}
