using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Data;

namespace SchoolApp.Pages.Administrateur
{
    public class FillieresModel : PageModel
    {
        private readonly SchoolDBContext _context;

        public FillieresModel(SchoolDBContext context)
        {
            _context = context;
        }

        public IList<SchoolApp.Models.Filliere> Fill { get; set; }
        public IList<Models.Prof> Prof { get; set; }
        public Models.Admin Admin2 { get; private set; }

        public void OnGet()
        {
            Fill = _context.Fillieres.Include(s => s.Etudiants).Include(s=>s.IdProfNavigation).Include(s => s.Modules).ToList();
            Prof = _context.Profs.ToList();

            String id = HttpContext.Session.GetString("IDAdmin");

            Admin2 = _context.Admins.Single(s => s.IdAdmin == id);
            ViewData["Adminname"] = Admin2.Username;
        }
    }
}
