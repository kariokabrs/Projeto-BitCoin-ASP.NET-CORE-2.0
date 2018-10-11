using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CbWebApp.Controllers
{
  /// <summary>
  /// Controller do sistema principal
  /// </summary>
    [Authorize]
    public class SistemaController : Controller
    {
        public IActionResult Contrato()
        {
            ViewData["Message"] = "Contratos";
            return View();
        }

        public IActionResult Relatorio()
        {
            ViewData["Message"] = "Relatórios";
            return View();
        }

        public IActionResult Parametrizacao()
        {
            ViewData["Message"] = "Parametrização";
            return View();
        }

        public IActionResult Lembrete()
        {
            ViewData["Message"] = "Lembrete";
            return View();
        }

    }
}