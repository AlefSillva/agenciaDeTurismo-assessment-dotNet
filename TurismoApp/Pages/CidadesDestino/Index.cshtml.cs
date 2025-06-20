using Microsoft.AspNetCore.Mvc.RazorPages;
using TurismoApp.Data;
using TurismoApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TurismoApp.Pages.CidadesDestino
{
    public class IndexModel : PageModel
    {
        private readonly AgenciaTurismoContext _context;

        public IndexModel(AgenciaTurismoContext context)
        {
            _context = context;
        }

        public IList<CidadeDestino> Cidades { get; set; } = new List<CidadeDestino>();

        public async Task OnGetAsync()
        {
            Cidades = await _context.CidadesDestino.ToListAsync();
        }
    }
}
