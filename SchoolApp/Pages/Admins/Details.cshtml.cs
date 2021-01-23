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
    public class DetailsModel : PageModel
    {
        private readonly SchoolApp.Data.SchoolDBContext _context;

        public DetailsModel(SchoolApp.Data.SchoolDBContext context)
        {
            _context = context;
        }

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
    }
}
