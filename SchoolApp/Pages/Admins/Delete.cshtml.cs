using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Data;
using SchoolApp.Models;

namespace SchoolApp.Pages.Admins
{
    public class DeleteModel : PageModel
    {
        private readonly SchoolApp.Data.SchoolDBContext _context;

        public DeleteModel(SchoolApp.Data.SchoolDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SchoolApp.Models.Admin Admin { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Admin = await _context.Admins.FirstOrDefaultAsync(m => m.IdAdmin == id);

            if (Admin == null)
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

            Admin = await _context.Admins.FindAsync(id);

            if (Admin != null)
            {
                _context.Admins.Remove(Admin);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
