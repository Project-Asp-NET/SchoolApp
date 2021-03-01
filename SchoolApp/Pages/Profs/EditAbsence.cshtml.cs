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
    public class EditAbsenceModel : PageModel
    {
        public IList<SchoolApp.Models.Element> profElements { get; set; }
        public Element element { get; set; }

        [BindProperty]
        public Etudiant etudiant { get; set; }
        public IList<Filliere> filliere { get; set; }
        public Absence absence { get; set; }

        private readonly SchoolDBContext _context;

        public EditAbsenceModel(SchoolDBContext context)
        {
            _context = context;
        }
        public void OnGet(string id, string prof, string elem)
        {
            profElements = _context.Elements.Where(e => e.IdProf == prof).ToList();
            ViewData["profElements"] = profElements;
            ViewData["idProf"] = prof;

            etudiant = (Etudiant)_context.Etudiants.Where(s => s.IdEtud == id).FirstOrDefault();
            filliere = _context.Fillieres.ToList();
            element = (Element)_context.Elements.Where(m => m.IdElem == elem).FirstOrDefault();

            absence = (Absence)_context.Absences.Where(a => a.IdEtud == id && a.IdElem == elem).FirstOrDefault();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            absence = (Absence)_context.Absences.Where(a => a.IdElem == Convert.ToString(Request.Form["elementId"]) && a.IdEtud == Convert.ToString(Request.Form["studentId"])).FirstOrDefault();

            absence.DateAbs = Convert.ToDateTime(Request.Form["dateAbsence"]);

            if (Convert.ToString(Request.Form["isJustif"]) == "True")
                absence.IsJustif = true;
            else absence.IsJustif = false;

            absence.Justification = Convert.ToString(Request.Form["Justif"]);

            await _context.SaveChangesAsync();

            string url = "/Profs/Absence?id=" + Request.Form["studentId"] + "&prof=" + Request.Form["profId"] + "&elem=" + Request.Form["elementId"];

            return Redirect(url);
        }
    }
}
