using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TurismoApp.Data;
using TurismoApp.Models;
using System.Threading.Tasks;

namespace TurismoApp.Pages.PaisesDestino
{
    public class CreatePaisDestinoModel : PageModel
    {
        private readonly AgenciaTurismoContext _context;

        public CreatePaisDestinoModel(AgenciaTurismoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PaisDestino PaisDestino { get; set; } = new PaisDestino();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PaisesDestino.Add(PaisDestino);
            await _context.SaveChangesAsync();

            return RedirectToPage("/PaisesDestino/Index");
        }
    }
}
