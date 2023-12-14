using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReinosAcoWebApp.Data;
using ReinosAcoWebApp.Models;

namespace ReinosAcoWebApp.Pages.Materiais
{
    public class IndexModel : PageModel
    {
        private readonly ReinosAcoWebApp.Data.ArmaduraDbContext _context;

        public IndexModel(ReinosAcoWebApp.Data.ArmaduraDbContext context)
        {
            _context = context;
        }

        public IList<Material> Material { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Material != null)
            {
                Material = await _context.Material.ToListAsync();
            }
        }
    }
}
