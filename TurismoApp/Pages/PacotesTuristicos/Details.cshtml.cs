using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TurismoApp.Data;
using TurismoApp.Models;

namespace TurismoApp.Pages.PacotesTuristicos
{
    public class DetailsModel : PageModel
    {
        private readonly AgenciaTurismoContext _context;

        public DetailsModel(AgenciaTurismoContext context)
        {
            _context = context;
        }

        public PacoteTuristico PacoteTuristico { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            
            var pacoteturistico = await _context.PacotesTuristicos
                .Where(p => !p.IsDeleted)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (pacoteturistico == null)
                return NotFound();

            PacoteTuristico = pacoteturistico;

            return Page();
        }
    }
}
