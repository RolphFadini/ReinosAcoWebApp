using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ReinosAcoWebApp.Pages;

public class AboutUsModel : PageModel
{
    public void OnGet()
    {
        ViewData["Title"] = "Quem Somos - Reinos & A�o";
    }
}
