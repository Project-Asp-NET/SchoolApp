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
    public class ModuleModel : PageModel
    {

        private readonly SchoolApp.Data.SchoolDBContext _context;

        public ModuleModel(SchoolApp.Data.SchoolDBContext context)
        {
            _context = context;

        }

        public Models.Etudiant Etudiant { get; set; }
        [BindProperty]
        public Models.Filliere Filliere { get; set; }

        public List<Models.Module> Modules { get; set; }

        public Models.Module Module { get; set; }

        public void OnGet(String idmod)
        {
            //HttpContext.Session.SetString("ID", "idetu2");

            String id = HttpContext.Session.GetString("ID");

            Etudiant = _context.Etudiants.Include(f => f.IdFillNavigation).Include(e => e.Notes).Single(s => s.IdEtud == id);

            Filliere = _context.Fillieres.Include(f => f.Modules).Single(s => s.IdFill == Etudiant.IdFill);
            
            Module = _context.Modules.Include(f => f.Elements).Single(s => s.IdMod == idmod);

            ViewData["Elevename"] = Etudiant.Nom + " " + Etudiant.Prenom;

            ViewData["Modules_S1"] = Filliere.Modules.Where(s => s.Semestre == "1").ToList();
            ViewData["Modules_S2"] = Filliere.Modules.Where(s => s.Semestre == "2").ToList();
        }
    }
}
