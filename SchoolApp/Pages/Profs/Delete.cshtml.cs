using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Data;
using SchoolApp.Models;

namespace SchoolApp.Pages.Profs
{
    public class DeleteModel : PageModel
    {
        private readonly SchoolApp.Data.SchoolDBContext _context;

        public DeleteModel(SchoolApp.Data.SchoolDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Prof Prof { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Prof = await _context.Profs.FirstOrDefaultAsync(m => m.IdProf == id);

            if (Prof == null)
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

            Prof = await _context.Profs.FindAsync(id);

            if (Prof != null)
            {
                _context.Profs.Remove(Prof);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
