using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TurismoApp.Data;
using TurismoApp.Models;

namespace TurismoApp.Pages.Reservas
{
    public class IndexModel : PageModel
    {
        private readonly AgenciaTurismoContext _context;

        public IndexModel(AgenciaTurismoContext context)
        {
            _context = context;
        }

        public List<Reserva> Reservas { get; set; } = new List<Reserva>();

        public async Task OnGetAsync()
        {
            Reservas = await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.PacoteTuristico)
                .ToListAsync();
        }
    }
}
