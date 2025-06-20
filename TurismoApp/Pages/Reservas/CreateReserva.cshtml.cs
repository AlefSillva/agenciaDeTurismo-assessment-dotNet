using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using TurismoApp.Data;
using TurismoApp.Models;
using TurismoApp.Services;
using System.Linq;

namespace TurismoApp.Pages.Reservas
{
    public class CreateReservaModel : PageModel
    {
        private readonly AgenciaTurismoContext _context;
        private readonly ReservaService _reservaService;

        public CreateReservaModel(AgenciaTurismoContext context, ReservaService reservaService)
        {
            _context = context;
            _reservaService = reservaService;
        }

        [BindProperty]
        [Required(ErrorMessage = "O cliente é obrigatório.")]
        public int ClienteId { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "O pacote turístico é obrigatório.")]
        public int PacoteTuristicoId { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "O número de diárias é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O número de diárias deve ser maior que zero.")]
        public int QuantidadeDiarias { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Listar clientes com Nome + Email para evitar confusão
            var clientes = await _context.Clientes
                .Select(c => new
                {
                    c.Id,
                    Display = c.Nome + " - " + c.Email
                })
                .ToListAsync();

            ViewData["ClienteId"] = new SelectList(clientes, "Id", "Display");

            // Pacotes não deletados
            ViewData["PacoteTuristicoId"] = new SelectList(_context.PacotesTuristicos.Where(p => !p.IsDeleted), "Id", "Titulo");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                
                var clientes = await _context.Clientes
                    .Select(c => new
                    {
                        c.Id,
                        Display = c.Nome + " - " + c.Email
                    })
                    .ToListAsync();

                ViewData["ClienteId"] = new SelectList(clientes, "Id", "Display");
                ViewData["PacoteTuristicoId"] = new SelectList(_context.PacotesTuristicos.Where(p => !p.IsDeleted), "Id", "Titulo");

                return Page();
            }

            var cliente = await _context.Clientes.FindAsync(ClienteId);
            var pacote = await _context.PacotesTuristicos.FindAsync(PacoteTuristicoId);

            if (cliente == null || pacote == null)
            {
                ModelState.AddModelError(string.Empty, "Cliente ou Pacote Turístico não encontrado.");

                var clientes = await _context.Clientes
                    .Select(c => new
                    {
                        c.Id,
                        Display = c.Nome + " - " + c.Email
                    })
                    .ToListAsync();

                ViewData["ClienteId"] = new SelectList(clientes, "Id", "Display");
                ViewData["PacoteTuristicoId"] = new SelectList(_context.PacotesTuristicos.Where(p => !p.IsDeleted), "Id", "Titulo");

                return Page();
            }

            bool reservaCriada = await _reservaService.CriarReservaAsync(ClienteId, PacoteTuristicoId, QuantidadeDiarias);

            if (!reservaCriada)
            {
                ModelState.AddModelError(string.Empty, "Não foi possível criar a reserva. Verifique a capacidade máxima do pacote.");

                var clientes = await _context.Clientes
                    .Select(c => new
                    {
                        c.Id,
                        Display = c.Nome + " - " + c.Email
                    })
                    .ToListAsync();

                ViewData["ClienteId"] = new SelectList(clientes, "Id", "Display");
                ViewData["PacoteTuristicoId"] = new SelectList(_context.PacotesTuristicos.Where(p => !p.IsDeleted), "Id", "Titulo");

                return Page();
            }

            return RedirectToPage("/Reservas/Index");
        }
    }
}
