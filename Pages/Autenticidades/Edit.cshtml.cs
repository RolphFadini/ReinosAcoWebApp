using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReinosAcoWebApp.Data;
using ReinosAcoWebApp.Models;

namespace ReinosAcoWebApp.Pages.Shared.Autenticidades
{
    public class EditModel : PageModel
    {
        private readonly ReinosAcoWebApp.Data.ArmaduraDbContext _context;

        public EditModel(ReinosAcoWebApp.Data.ArmaduraDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Autenticidade Autenticidade { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Autenticidade == null)
            {
                return NotFound();
            }

            var autenticidade =  await _context.Autenticidade.FirstOrDefaultAsync(m => m.AutenticidadeId == id);
            if (autenticidade == null)
            {
                return NotFound();
            }
            Autenticidade = autenticidade;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Autenticidade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutenticidadeExists(Autenticidade.AutenticidadeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AutenticidadeExists(int id)
        {
          return (_context.Autenticidade?.Any(e => e.AutenticidadeId == id)).GetValueOrDefault();
        }
    }
}
