using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TurismoApp.Data;
using TurismoApp.Models;
using System.Threading.Tasks;

namespace TurismoApp.Pages.Cidades
{
    public class CidadeDestinoDetailsModel : PageModel
    {
        private readonly AgenciaTurismoContext _context;

        public CidadeDestinoDetailsModel(AgenciaTurismoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CidadeDestino? Cidade { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Cidade = await _context.CidadesDestino.FindAsync(id);

            if (Cidade == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
