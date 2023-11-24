using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReinosAcoWebApp.Models;
using ReinosAcoWebApp.Services;

namespace ReinosAcoWebApp.Pages
{
    public class EditModel : PageModel
    {
        private IArmaduraService _service;

        public EditModel(IArmaduraService service)
        {
            _service = service;
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

            TempData["TempMensagemSucesso"] = true;

            return RedirectToPage("/Index");
        }

        public IActionResult OnPostExclusao()
        {
            //exclusão
            _service.Excluir(Armadura.ArmaduraId);

            TempData["TempMensagemSucesso"] = true;

            return RedirectToPage("/Index");
        }
    }
}
