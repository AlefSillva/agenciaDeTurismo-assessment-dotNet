using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TurismoApp.Models;
using TurismoApp.Data;
using System.Threading.Tasks;

namespace TurismoApp.Pages.CidadesDestino
{
    public class CreateCidadeDestinoModel : PageModel
    {
        private readonly AgenciaTurismoContext _context;

        public CreateCidadeDestinoModel(AgenciaTurismoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CidadeDestino CidadeDestino { get; set; } = new CidadeDestino();

        public void OnGet()
        {
           
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CidadesDestino.Add(CidadeDestino);
            await _context.SaveChangesAsync();

            
            return RedirectToPage("/CidadesDestino/Index");
        }
    }
}
