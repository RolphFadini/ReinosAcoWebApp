using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReinosAcoWebApp.Models;
using ReinosAcoWebApp.Services;
using System.Dynamic;

namespace ReinosAcoWebApp.Pages;

public class CreateModel : PageModel
{
    public SelectList AutenticidadeOptionItems { get; set; }
    private IArmaduraService _service;

    public CreateModel(IArmaduraService service) 
    {
        _service = service;
    }

    public void OnGet()
    {
        ViewData["Title"] = "Inclusão";
        
        AutenticidadeOptionItems = new SelectList(_service.ObterTodasAutenticidades(),
                                                    nameof(Autenticidade.AutenticidadeId),
                                                    nameof(Autenticidade.Descricao));
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
}
