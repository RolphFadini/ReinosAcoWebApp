using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReinosAcoWebApp.Data;
using ReinosAcoWebApp.Models;

namespace ReinosAcoWebApp.Pages.Shared.Autenticidades
{
    public class DetailsModel : PageModel
    {
        private readonly ReinosAcoWebApp.Data.ArmaduraDbContext _context;

        public DetailsModel(ReinosAcoWebApp.Data.ArmaduraDbContext context)
        {
            _context = context;
        }

      public Autenticidade Autenticidade { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Autenticidade == null)
            {
                return NotFound();
            }

            var autenticidade = await _context.Autenticidade.FirstOrDefaultAsync(m => m.AutenticidadeId == id);
            if (autenticidade == null)
            {
                return NotFound();
            }
            else 
            {
                Autenticidade = autenticidade;
            }
            return Page();
        }
    }
}
