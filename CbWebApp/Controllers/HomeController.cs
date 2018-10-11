using CbWebApp.Models;
using CbWebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CbWebApp.Controllers
{
    /// <summary>
    /// Controller da página inicial
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IContratoService ContratoSerivce;

        public HomeController(IContratoService contratoSerivce)
        {
            ContratoSerivce = contratoSerivce;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View(nameof(PaginaInicial));
            }
        }

        [Authorize]
        [Route("")]
        [HttpGet]
        public ViewResult PaginaInicial()
        {
            return View();
         }

        [Authorize]
        [HttpGet]
        public IActionResult Contratos(string id)
        {
            if (ModelState.IsValid)
            {
                return ViewComponent("Contrato");
                //return PartialView("_Pagamentos");
            }
            return PartialView("_Pagamentos");
        }

        [Authorize]
        [HttpGet]
        public PartialViewResult Pagamentos(string id)
        {
            if (ModelState.IsValid)
            {
                return PartialView("_Pagamentos");
            }
            return PartialView("_Pagamentos");
        }

        [Authorize]
        [HttpGet]
        public PartialViewResult Lembretes(string id)
        {
            if (ModelState.IsValid)
            {
                return PartialView("_Pagamentos");
            }
            return PartialView("_Pagamentos");
        }

        [Authorize]
        [HttpGet]
        public PartialViewResult Aniversariantes(string id)
        {
            if (ModelState.IsValid)
            {
                return PartialView("_Pagamentos");
            }
            return PartialView("_Pagamentos");
        }

        [AllowAnonymous]
        public ViewResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
