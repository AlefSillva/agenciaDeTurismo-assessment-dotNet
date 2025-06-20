using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace TurismoApp.Pages.Notas

{
    public class ViewNotesModel : PageModel
    {
        private readonly string _notesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files");

        [BindProperty]
        public string NewNoteText { get; set; } = string.Empty;

        public List<string> NoteFiles { get; set; } = new List<string>();

        public string? SelectedContent { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? FileToRead { get; set; }

        public void OnGet()
        {
            if (!Directory.Exists(_notesPath))
                Directory.CreateDirectory(_notesPath);

            NoteFiles = new List<string>(Directory.GetFiles(_notesPath, "*.txt"));
            for (int i = 0; i < NoteFiles.Count; i++)
            {
                NoteFiles[i] = Path.GetFileName(NoteFiles[i]);
            }

            if (!string.IsNullOrEmpty(FileToRead))
            {
                var filePath = Path.Combine(_notesPath, FileToRead);
                if (System.IO.File.Exists(filePath))
                {
                    SelectedContent = System.IO.File.ReadAllText(filePath);
                }
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!Directory.Exists(_notesPath))
                Directory.CreateDirectory(_notesPath);

            // ----- Criar um nome único para o arquivo -----
            string fileName = $"note_{System.DateTime.Now:yyyyMMdd_HHmmss}.txt";
            string fullPath = Path.Combine(_notesPath, fileName);

            await System.IO.File.WriteAllTextAsync(fullPath, NewNoteText);

            return RedirectToPage();
        }
    }
}
