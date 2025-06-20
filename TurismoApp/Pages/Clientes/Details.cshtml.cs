using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TurismoApp.Data;
using TurismoApp.Models;

namespace TurismoApp.Pages.Clientes
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly AgenciaTurismoContext _context;

        public DetailsModel(AgenciaTurismoContext context)
        {
            _context = context;
        }

        public Cliente Cliente { get; set; } = default!;

        public List<Reserva> ReservasDoCliente { get; set; } = new List<Reserva>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            
            Cliente? cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null)
                return NotFound();

            Cliente = cliente;

            
            ReservasDoCliente = await _context.Reservas
                .Include(r => r.PacoteTuristico)
                .Where(r => r.ClienteId == id)
                .ToListAsync();

            return Page();
        }
    }
}
