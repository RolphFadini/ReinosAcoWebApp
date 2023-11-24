using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReinosAcoWebApp.Models;
using ReinosAcoWebApp.Services;
using System.Dynamic;

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

            TempData["TempMensagemSucesso"] = true;

            return RedirectToPage("/Index");  
        }

        public void OnGet()
        {
            ViewData["Title"] = "Inclusão";
        }
    }
}
