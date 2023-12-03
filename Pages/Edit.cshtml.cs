using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using ReinosAcoWebApp.Models;
using ReinosAcoWebApp.Services;

namespace ReinosAcoWebApp.Pages
{
    public class EditModel : PageModel
    {
        public SelectList AutenticidadeOptionItems { get; set; }
        private IArmaduraService _service;
        private IToastNotification _toastNotification { get; set; } 

        public EditModel(IArmaduraService service,
                         IToastNotification toastNotification)
        {
            _service = service;
            _toastNotification = toastNotification;
        }

        [BindProperty]
        public Armadura Armadura { get; set; }

        public IActionResult OnGet(int id)
        {
            ViewData["Title"] = "Detalhes - Reinos & Aço";

            Armadura = _service.Obter(id);

            if (Armadura == null)
            {
                return NotFound();
            }

            AutenticidadeOptionItems = new SelectList(_service.ObterTodasAutenticidades(),
                                                        nameof(Autenticidade.AutenticidadeId),
                                                        nameof(Autenticidade.Descricao));

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //alteração
            _service.Alterar(Armadura);

            _toastNotification.AddSuccessToastMessage("Operação realizada com sucesso!");

            return RedirectToPage("/Index");
        }

        public IActionResult OnPostExclusao()
        {
            //exclusão
            _service.Excluir(Armadura.ArmaduraId);

            _toastNotification.AddSuccessToastMessage("Operação realizada com sucesso!");

            return RedirectToPage("/Index");
        }
    }
}
