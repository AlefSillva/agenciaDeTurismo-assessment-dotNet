using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TurismoApp.Data;
using TurismoApp.Models;

namespace TurismoApp.Pages.PacotesTuristicos
{
    public class EditModel : PageModel
    {
        private readonly TurismoApp.Data.AgenciaTurismoContext _context;

        public EditModel(TurismoApp.Data.AgenciaTurismoContext context)
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
            if (pacoteturistico == null)
            {
                return NotFound();
            }

            PacoteTuristico = pacoteturistico;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var pacoteExistente = await _context.PacotesTuristicos.FindAsync(PacoteTuristico.Id);

            if (pacoteExistente == null)
            {
                return NotFound();
            }

            // Atualizar apenas os campos editáveis
            pacoteExistente.Titulo = PacoteTuristico.Titulo;
            pacoteExistente.DataInicio = PacoteTuristico.DataInicio;
            pacoteExistente.CapacidadeMaxima = PacoteTuristico.CapacidadeMaxima;
            pacoteExistente.Preco = PacoteTuristico.Preco;
            // NÃO altera IsDeleted aqui — mantido como controle interno

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private bool PacoteTuristicoExists(int id)
        {
            return _context.PacotesTuristicos.Any(e => e.Id == id);
        }
    }
}
