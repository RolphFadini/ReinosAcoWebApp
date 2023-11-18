using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReinosAcoWebApp.Models;
using ReinosAcoWebApp.Services;

namespace ReinosAcoWebApp.Pages
{
    public class CreateModel : PageModel
    {
        private IArmaduraService _service;

        public CreateModel(IArmaduraService service) 
        {
            _service = service;
        }

        [BindProperty]
        public Armadura Armadura { get; set; }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            //inclusão
            _service.Incluir(Armadura);

            return RedirectToPage("/Index");  
        }
    }
}
