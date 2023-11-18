using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ReinosAcoWebApp.Pages;

public class PrivacyModel : PageModel
{
    public void OnGet()
    {
        ViewData["Title"] = "Política de Privacidade - Reinos & Aço";
    }
}