using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolApp.Models;
using SchoolApp.Data;

namespace SchoolApp.Pages.Profs
{
    public class AbsencesModel : PageModel
    { 
        public IList<SchoolApp.Models.Element> profElements { get; set; }
        public IList<SchoolApp.Models.Etudiant> studentsList { get; set; }
        public IList<Absence> listeAbsences { get; set; }
        public Element element { get; set; }
        public Module module { get; set; }
        public Filliere filliere { get; set; }

        public int nbr_abs;
        public int nbr_abs_just;
        private readonly SchoolDBContext _context;


        public AbsencesModel(SchoolDBContext context)
        {
            _context = context;
        }

        public void OnGet(string id, string idprof)
        {
            profElements = _context.Elements.Where(e => e.IdProf == idprof).ToList();
            ViewData["profElements"] = profElements;

            element = (Element)_context.Elements.Where(e => e.IdElem == id).FirstOrDefault();
            module = (Module)_context.Modules.Where(m => m.IdMod == element.IdMod).FirstOrDefault();
            filliere = (Filliere)_context.Fillieres.Where(f => f.IdFill == module.IdFill).FirstOrDefault();
            studentsList = _context.Etudiants.Where(s => s.IdFill == filliere.IdFill).ToList();
            //listeAbsences = _context.Absences.Where(a => a.IdElem == id).ToList();

            

        }
    }
}
