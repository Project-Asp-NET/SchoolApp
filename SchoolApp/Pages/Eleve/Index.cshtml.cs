using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SchoolApp.Pages.Eleve
{
    public class IndexModel : PageModel
    {
        private readonly SchoolApp.Data.SchoolDBContext _context;

        public IndexModel(SchoolApp.Data.SchoolDBContext context)
        {
            _context = context;
        }

        public Models.Etudiant Etudiant { get; set; }
        [BindProperty]
        public Models.Filliere Filliere { get; set; }

        public List <Models.Module> Modules { get; set; }

        public void OnGet(String id)
        {
            Etudiant = _context.Etudiants.Single(s => s.IdEtud == id);
            Filliere = _context.Fillieres.Include(cat => cat.Modules).Single(s => s.IdFill == Etudiant.IdFill);

        }
    }
}
