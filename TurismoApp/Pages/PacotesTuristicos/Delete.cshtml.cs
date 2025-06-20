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
    public class DeleteModel : PageModel
    {
        private readonly TurismoApp.Data.AgenciaTurismoContext _context;

        public DeleteModel(TurismoApp.Data.AgenciaTurismoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PacoteTuristico PacoteTuristico { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacoteturistico = await _context.PacotesTuristicos.FirstOrDefaultAsync(m => m.Id == id);

            if (pacoteturistico is not null)
            {
                PacoteTuristico = pacoteturistico;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacoteturistico = await _context.PacotesTuristicos.FindAsync(id);
            if (pacoteturistico != null)
            {
                PacoteTuristico = pacoteturistico;
                _context.PacotesTuristicos.Remove(PacoteTuristico);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
