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
    public class IndexModel : PageModel
    {
        private readonly SchoolApp.Data.SchoolDBContext _context;

        public IndexModel(SchoolApp.Data.SchoolDBContext context)
        {
            _context = context;
        }

        public IList<Admin> Admin { get;set; }

        public async Task OnGetAsync()
        {
            Admin = await _context.Admins.ToListAsync();
        }
    }
}
