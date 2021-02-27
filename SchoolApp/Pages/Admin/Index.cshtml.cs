using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolApp.Models;
using SchoolApp.Data;
using Microsoft.AspNetCore.Http;

namespace SchoolApp.Pages.Administrateur
{
    public class IndexModel : PageModel
    {
        private readonly SchoolDBContext _context;

        public IndexModel(SchoolDBContext context)
        {
            _context = context;
        }

        public Models.Admin Admin { get; set; }

        /*public async Task OnGetAsync()
        {
            //Departement = await _context.Departements.ToListAsync();

        }*/
        public void OnGet()
        {
            HttpContext.Session.SetString("IDAdmin", "adm1");

            String id = HttpContext.Session.GetString("IDAdmin");

            Admin = _context.Admins.Single(s =>s.IdAdmin==id);
            ViewData["Adminname"] = Admin.Username;

        }
    }
}
