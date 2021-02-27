using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Models;

namespace SchoolApp.Pages.Eleve
{
    public class NotesModel : PageModel
    {
        private readonly SchoolApp.Data.SchoolDBContext _context;

        public NotesModel(Data.SchoolDBContext context)
        {
            _context = context;

        }
        public IList<Models.Note> Note { get; set; }
        public Etudiant Etudiant { get; set; }
        public Filliere Filliere { get; set; }
        public IList<Models.Validation> Validation { get; set; }
        public void OnGet()
        {
            //HttpContext.Session.SetString("ID", "idetu1");
            String id = HttpContext.Session.GetString("ID");

            Note = _context.Notes.Include(s => s.IdElemNavigation).Where(e => e.IdEtud == id).ToList();

            Validation = _context.Validations.Include(s => s.IdModNavigation).Where(e => e.IdEtud == id).ToList();

            Etudiant = _context.Etudiants.Include(f => f.IdFillNavigation).Single(s => s.IdEtud == id);

            Filliere = _context.Fillieres.Include(f => f.Modules).Single(s => s.IdFill == Etudiant.IdFill);


            ViewData["Elevename"] = Etudiant.Nom + " " + Etudiant.Prenom;
            ViewData["Modules_S1"] = Filliere.Modules.Where(s => s.Semestre == "1").ToList();
            ViewData["Modules_S2"] = Filliere.Modules.Where(s => s.Semestre == "2").ToList();
        }
    }
}
