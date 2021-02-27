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
    public class AddAbsenceModel : PageModel
    {
        public IList<SchoolApp.Models.Element> profElements { get; set; }
        public Absence absence { get; set; }

        private readonly SchoolDBContext _context;

        public AddAbsenceModel(SchoolDBContext context)
        {
            _context = context;
        }
        public void OnGet(string id, string prof, string elem)
        {
            profElements = _context.Elements.Where(e => e.IdProf == prof).ToList();
            ViewData["profElements"] = profElements;
            ViewData["idEtud"] = id;
            ViewData["idElem"] = elem;
            ViewData["idProf"] = prof;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            absence = new Absence();

            absence.IdEtud = Request.Form["studentId"];
            absence.IdElem = Request.Form["elemId"];
            absence.DateAbs = Convert.ToDateTime(Request.Form["dateAbs"]);

            if (Request.Form["isJustif"] == "Tue")
                absence.IsJustif = true;
            else absence.IsJustif = false;

            if (Request.Form["Justif"] == "")
                absence.Justification = "";
            else absence.Justification = Request.Form["Justif"];

            _context.Absences.Add(absence);
            await _context.SaveChangesAsync();

            string url = "/Profs/Absence?id=" + Request.Form["studentId"] + "&prof=" + Request.Form["profId"] + "&elem=" + Request.Form["elemId"];

            return Redirect(url);
        }
    }
}
