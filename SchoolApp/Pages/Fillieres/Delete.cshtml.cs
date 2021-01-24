using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Data;
using SchoolApp.Models;

namespace SchoolApp.Pages.Fillieres
{
    public class DeleteModel : PageModel
    {
        private readonly SchoolApp.Data.SchoolDBContext _context;

        public DeleteModel(SchoolApp.Data.SchoolDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Filliere Filliere { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Filliere = await _context.Fillieres.FirstOrDefaultAsync(m => m.IdFill == id);

            if (Filliere == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Filliere = await _context.Fillieres.FindAsync(id);

            if (Filliere != null)
            {
                _context.Fillieres.Remove(Filliere);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
