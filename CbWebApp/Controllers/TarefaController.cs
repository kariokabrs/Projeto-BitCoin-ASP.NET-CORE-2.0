#region Usings
using CbWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
#endregion

namespace CbWebApp.Controllers
{
    [Authorize]
    public class TarefaController : Controller
    {

        //private readonly ITarefaService servico;
        private readonly UserManager<ApplicationUser> userManager;

        //public TarefaController(ITarefaService servicoDi, UserManager<ApplicationUser> userManagerDi)
        //{
        //    servico = servicoDi;
        //    userManager = userManagerDi;
        //}

        //[HttpGet]
        //public async Task<IActionResult> Tarefa()
        //{
        //    ModelState.Clear();

        //    //TarefaDTO dto = new TarefaDTO
        //    //{
        //    //    Items = await servico.ReadAllAsync()
        //    //};

        //    return View(dto);
        //}

        [HttpGet]
        public IActionResult AddTarefa()
        {
            ModelState.Clear();
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> AddTarefa([Bind(nameof(TarefaViewModel.Nome), nameof(TarefaViewModel.Completa))] TarefaViewModel novaTarefa)
        //{
        //    if (await TryUpdateModelAsync<TarefaViewModel>(novaTarefa, "tarefa", s => s.Nome, s => s.Completa))
        //    {
        //        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //        //ApplicationUser user = await userManager.FindByIdAsync(userId);

        //        await servico.AddAsync(novaTarefa, userId);
        //        return RedirectToAction(nameof(Tarefa));
        //    }
        //    else
        //    {
        //        var errorList = (from item in ModelState
        //                         where item.Value.Errors.Any()
        //                         select item.Value.Errors[0].ErrorMessage).ToList();
        //        return View();
        //    }
        //}

        //[HttpGet]
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    Tarefa retorno = await servico.ReadIdAsync(id);

        //    if (retorno == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(retorno);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(Guid id, [Bind(nameof(TarefaViewModel.Id), nameof(TarefaViewModel.Nome), nameof(TarefaViewModel.Completa))] TarefaViewModel editarTarefa)
        //{
        //    if (id != editarTarefa.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //            await servico.EditarAsync(editarTarefa, userId);
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {

        //            throw;
        //        }
        //        return RedirectToAction(nameof(Tarefa));
        //    }
        //    return View(editarTarefa);
        //}
  
        //[HttpGet]
        //public async Task<IActionResult> Delete(Guid? id, bool? saveChangesError = false)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    Tarefa retorno = await servico.ReadIdAsync(id);
        //    if (retorno == null)
        //    {
        //        return NotFound();
        //    }

        //    if (saveChangesError.GetValueOrDefault())
        //    {
        //        ViewData["ErrorMessage"] = "Não foi possível deletar. Contate o administrador.";
        //    }

        //    return View(retorno);
        //}
       
        //[HttpPost, ActionName("Delete")]
        //public async Task<IActionResult> DeleteConfirmed(Guid id, bool? saveChangesError = false)
        //{
        //    Tarefa retorno = await servico.ReadIdAsync(id);

        //    if (retorno == null)
        //    {
        //        return RedirectToAction(nameof(Tarefa));
        //    }

        //    try
        //    {
        //        TarefaViewModel model = new TarefaViewModel()
        //        {
        //            Id = retorno.Id,
        //            Nome = retorno.Nome,
        //            Completa = retorno.Completa
        //        };

        //        await servico.DeletarAsync(model);
        //        return RedirectToAction(nameof(Tarefa));
        //    }
        //    catch (DbUpdateException)
        //    {
        //        return RedirectToAction(nameof(Delete), new { id, saveChangesError = true });
        //    }
        //}
    }
}