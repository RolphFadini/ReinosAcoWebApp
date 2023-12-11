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
        public SelectList MaterialOptionItems { get; set; }

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

        [BindProperty]
        public IList<int> MaterialIds { get; set; }

        public IActionResult OnGet(int id)
        {
            ViewData["Title"] = "Detalhes - Reinos & A�o";

            Armadura = _service.Obter(id);

            MaterialIds = Armadura.Materiais.Select(item => item.MaterialId).ToList();

            if (Armadura == null)
            {
                return NotFound();
            }

            AutenticidadeOptionItems = new SelectList(_service.ObterTodasAutenticidades(),
                                                        nameof(Autenticidade.AutenticidadeId),
                                                        nameof(Autenticidade.Descricao));

            MaterialOptionItems = new SelectList(_service.ObterTodosMateriais(),
                                                    nameof(Material.MaterialId),
                                                    nameof(Material.Descricao));

            return Page();
        }

        public IActionResult OnPost()
        {
            Armadura.Materiais = _service.ObterTodosMateriais()
                                     .Where(item => MaterialIds.Contains(item.MaterialId))
                                     .ToList();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            //altera��o
            _service.Alterar(Armadura);

            _toastNotification.AddSuccessToastMessage("Opera��o realizada com sucesso!");

            return RedirectToPage("/Index");
        }

        public IActionResult OnPostExclusao()
        {
            //exclus�o
            _service.Excluir(Armadura.ArmaduraId);

            _toastNotification.AddSuccessToastMessage("Opera��o realizada com sucesso!");

            return RedirectToPage("/Index");
        }
    }
}
