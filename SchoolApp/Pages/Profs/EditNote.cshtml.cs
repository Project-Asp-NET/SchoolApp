using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Data;
using SchoolApp.Models;

namespace SchoolApp.Pages.Profs
{
    public class EditNoteModel : PageModel
    {
        private readonly SchoolDBContext _context;
        public Prof professor { get; set; }
        public IList<SchoolApp.Models.Element> profElements { get; set; }

        public Note noteEtudiant { get; set; }

        public Element element { get; set; }

        [BindProperty]
        public Etudiant etudiant { get; set; }
        public IList<Filliere> filliere { get; set; }
        

        public EditNoteModel(SchoolDBContext context)
        {
            _context = context;
        }

        public void OnGet(string id, string prof,string elem)
        {
            profElements = _context.Elements.Where(e => e.IdProf == prof).ToList();
            ViewData["profElements"] = profElements;

            etudiant = (Etudiant)_context.Etudiants.Where(s => s.IdEtud == id).FirstOrDefault();
            filliere = _context.Fillieres.ToList();
            element = (Element)_context.Elements.Where(m => m.IdElem == elem).FirstOrDefault();

            noteEtudiant = (Note)_context.Notes.Where(n => n.IdElem == elem && n.IdEtud == id).FirstOrDefault();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            noteEtudiant = (Note)_context.Notes.Where(n => n.IdElem == Convert.ToString(Request.Form["elementId"]) && n.IdEtud == Convert.ToString(Request.Form["studentId"])).FirstOrDefault();
            noteEtudiant.NoteAvRatt = Convert.ToDecimal(Request.Form["studentNote"]);
            noteEtudiant.NoteRatt = Convert.ToDecimal(Request.Form["studentNoteRatt"]);

            if (noteEtudiant.NoteRatt != null)
            {
                noteEtudiant.NoteFinal = (decimal?)((double)noteEtudiant.NoteAvRatt * (0.5) + (double)noteEtudiant.NoteRatt * (0.5));
            }

            await _context.SaveChangesAsync();

            string url = "/Profs/Matieres?id="+Request.Form["elementId"]+"&idprof="+Request.Form["profId"];

            return Redirect(url);
        }
    }
}
