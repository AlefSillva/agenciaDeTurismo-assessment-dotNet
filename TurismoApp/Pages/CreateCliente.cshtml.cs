using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TurismoApp.Models;
using TurismoApp.Data;
using System.Threading.Tasks;

namespace TurismoApp.Pages.Clientes
{
    public class CreateClienteModel : PageModel
    {
        private readonly AgenciaTurismoContext _context;

        public CreateClienteModel(AgenciaTurismoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cliente Cliente { get; set; } = new Cliente();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Clientes.Add(Cliente);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
