using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReinosAcoWebApp.Data;
using ReinosAcoWebApp.Models;

namespace ReinosAcoWebApp.Pages.Shared.Autenticidades
{
    public class CreateModel : PageModel
    {
        private readonly ReinosAcoWebApp.Data.ArmaduraDbContext _context;

        public CreateModel(ReinosAcoWebApp.Data.ArmaduraDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Autenticidade Autenticidade { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Autenticidade == null || Autenticidade == null)
            {
                return Page();
            }

            _context.Autenticidade.Add(Autenticidade);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
