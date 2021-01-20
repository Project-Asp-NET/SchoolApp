using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Data;
using SchoolApp.Models;

namespace SchoolApp.Pages.Fillieres
{
    public class EditModel : PageModel
    {
        private readonly SchoolApp.Data.SchoolDBContext _context;

        public EditModel(SchoolApp.Data.SchoolDBContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Filliere).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilliereExists(Filliere.IdFill))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FilliereExists(string id)
        {
            return _context.Fillieres.Any(e => e.IdFill == id);
        }
    }
}
