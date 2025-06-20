using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TurismoApp.Data;
using TurismoApp.Models;
using System.Threading.Tasks;

namespace TurismoApp.Pages.CidadesDestino
{
    public class CidadeDestinoDetailsModel : PageModel
    {
        private readonly AgenciaTurismoContext _context;

        public CidadeDestinoDetailsModel(AgenciaTurismoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CidadeDestino? CidadeDestino { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            CidadeDestino = await _context.CidadesDestino.FindAsync(id); 

            if (CidadeDestino == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
