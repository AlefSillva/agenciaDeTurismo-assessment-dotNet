﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TurismoApp.Data;
using TurismoApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace TurismoApp.Pages.Clientes
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly TurismoApp.Data.AgenciaTurismoContext _context;

        public CreateModel(TurismoApp.Data.AgenciaTurismoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Cliente Cliente { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Clientes.Add(Cliente);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
