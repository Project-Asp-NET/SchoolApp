using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        public void OnGet()
        {
           // HttpContext.Session.SetString("ID", "idetu1");

            String id = HttpContext.Session.GetString("IDEleve");

            Etudiant = _context.Etudiants.Include(f => f.IdFillNavigation).Single(s => s.IdEtud == id);

            Filliere = _context.Fillieres.Include(f => f.Modules).Single(s => s.IdFill == Etudiant.IdFill);

            ViewData["Elevename"] = Etudiant.Nom + " " + Etudiant.Prenom;
            ViewData["Modules_S1"] = Filliere.Modules.Where(s => s.Semestre=="1").ToList();
            ViewData["Modules_S2"] = Filliere.Modules.Where(s => s.Semestre == "2").ToList();

        }

        public async Task<IActionResult> onPostLogoutAsync()
        {
            HttpContext.Session.Clear();

            return Redirect("/Index");

        }
    }
}
