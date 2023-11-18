using Microsoft.AspNetCore.Mvc.RazorPages;
using ReinosAcoWebApp.Models;
using ReinosAcoWebApp.Services;

namespace ReinosAcoWebApp.Pages;

public class IndexModel : PageModel
{
    private IArmaduraService _service;

    public IndexModel(IArmaduraService service)
    {
        _service = service;
    }

    public IList<Armadura> ListaArmadura { get; private set; }

    public void OnGet()
    {
        ViewData["Title"] = "Reinos & Aço";

        ListaArmadura = _service.ObterTodos();
    }
}