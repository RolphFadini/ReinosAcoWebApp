using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using ReinosAcoWebApp.Models;
using ReinosAcoWebApp.Services;
using System.Dynamic;

namespace ReinosAcoWebApp.Pages;

public class CreateModel : PageModel
{
    public SelectList AutenticidadeOptionItems { get; set; }
    private IArmaduraService _service;
    private IToastNotification _toastNotification { get; set; }

    public CreateModel(IArmaduraService service,
                       IToastNotification toastNotification) 
    {
        _service = service;
        _toastNotification = toastNotification;
    }

    public void OnGet()
    {
        ViewData["Title"] = "Inclus�o";
        
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

        //inclus�o
        _service.Incluir(Armadura);

        _toastNotification.AddSuccessToastMessage("Opera��o realizada com sucesso!");

        return RedirectToPage("/Index");  
    }
}
