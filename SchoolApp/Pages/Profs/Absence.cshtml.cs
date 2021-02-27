using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolApp.Data;
using SchoolApp.Models;

namespace SchoolApp.Pages.Profs
{
    public class AbsenceModel : PageModel
    {
        public IList<SchoolApp.Models.Element> profElements { get; set; }

        public IList<SchoolApp.Models.Absence> listeAbsences { get; set; }

        public IList<SchoolApp.Models.Absence> listeAbsEtudiant { get; set; }

        public Etudiant etudiant { get; set; }
        public Element element { get; set; }

        private readonly SchoolDBContext _context;

        public AbsenceModel(SchoolDBContext context)
        {
            _context = context;
        }
        public void OnGet(string id, string prof, string elem)
        {
            profElements = _context.Elements.Where(e => e.IdProf == prof).ToList();
            ViewData["profElements"] = profElements;
            ViewData["idProf"] = prof;
            ViewData["idEtud"] = id;
            ViewData["idElem"] = elem;

            etudiant = _context.Etudiants.Where(e => e.IdEtud == id).FirstOrDefault();
            element = _context.Elements.Where(e => e.IdElem == elem).FirstOrDefault();

            listeAbsences = _context.Absences.ToList();
            listeAbsEtudiant = new List<SchoolApp.Models.Absence>();

            foreach (var abs in listeAbsences)
            {
                if (abs.IdElem.Equals(elem) && abs.IdEtud.Equals(id))
                    listeAbsEtudiant.Add(abs);
            }
        }
    }
}
