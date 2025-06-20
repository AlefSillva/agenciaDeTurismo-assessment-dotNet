using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TurismoApp.Data;
using TurismoApp.Models;

namespace TurismoApp.Pages.PacotesTuristicos
{
    public class IndexModel : PageModel
    {
        private readonly TurismoApp.Data.AgenciaTurismoContext _context;

        public IndexModel(TurismoApp.Data.AgenciaTurismoContext context)
        {
            _context = context;
        }

        public IList<PacoteTuristico> PacoteTuristico { get;set; } = default!;

        public async Task OnGetAsync()
        {
            PacoteTuristico = await _context.PacotesTuristicos
                                           .Where(p => !p.IsDeleted)
                                           .ToListAsync();
        }

    }
}
