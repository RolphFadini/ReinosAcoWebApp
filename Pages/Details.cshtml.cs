using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using ReinosAcoWebApp.Models;
using ReinosAcoWebApp.Services;

namespace ReinosAcoWebApp.Pages
{
    public class DetailsModel : PageModel
    {
        private IArmaduraService _service;

        public DetailsModel(IArmaduraService service)
        {
            _service = service;
        }

        public Armadura Armadura { get; private set; }

        public IActionResult OnGet(int id)
        {
            ViewData["Title"] = "Detalhes - Reinos & Aço";

            Armadura = _service.Obter(id);

            if(Armadura == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
