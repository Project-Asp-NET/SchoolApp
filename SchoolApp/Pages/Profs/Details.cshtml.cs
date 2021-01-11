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
    public class DetailsModel : PageModel
    {
        private readonly SchoolApp.Data.SchoolDBContext _context;

        public DetailsModel(SchoolApp.Data.SchoolDBContext context)
        {
            _context = context;
        }

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
    }
}
