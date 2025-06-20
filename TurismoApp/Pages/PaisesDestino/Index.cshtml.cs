using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TurismoApp.Data;
using TurismoApp.Models;

namespace TurismoApp.Pages.PaisesDestino
{
    public class IndexModel : PageModel
    {
        private readonly AgenciaTurismoContext _context;

        public IndexModel(AgenciaTurismoContext context)
        {
            _context = context;
        }

        public List<PaisDestino> PaisesDestino { get; set; } = new List<PaisDestino>();

        public async Task OnGetAsync()
        {
            PaisesDestino = await _context.PaisesDestino.ToListAsync();
        }
    }
}
