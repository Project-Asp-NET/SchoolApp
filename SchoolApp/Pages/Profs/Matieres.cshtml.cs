using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolApp.Models;
using SchoolApp.Data;
using Microsoft.EntityFrameworkCore;

namespace SchoolApp.Pages.Profs
{
    public class MatieresModel : PageModel
    {
        public IList<SchoolApp.Models.Note> studentNotes { get; set; }
        public IList<SchoolApp.Models.Etudiant> studentsList { get; set; }
        public IList<SchoolApp.Models.Element> profElements { get; set; }

        public Element element { get; set; }
        public Module module { get; set; }
        public Filliere filliere { get; set; }
        public Note note { get; set; }
        public Etudiant etudiant { get; set; }
        public Prof prof { get; set; }


        private readonly SchoolDBContext _context;

        public MatieresModel(SchoolDBContext context)
        {
            _context = context;
        }
        public void OnGet(string id, string idprof)
        {
            element = (Element) _context.Elements.Where(e => e.IdElem == id).FirstOrDefault();

            profElements = _context.Elements.Where(e => e.IdProf == idprof).ToList();
            ViewData["profElements"] = profElements;
            ViewData["idProf"] = idprof;

            module = (Module)_context.Modules.Where(m => m.IdMod == element.IdMod).FirstOrDefault();
            filliere = (Filliere)_context.Fillieres.Where(f => f.IdFill == module.IdFill).FirstOrDefault();
            
            studentsList = _context.Etudiants.Where(s => s.IdFill == filliere.IdFill).ToList();

            foreach (var student in studentsList)
            {
                note = (Note)_context.Notes.Where(n => n.IdElem == id && n.IdEtud == student.IdEtud).FirstOrDefault();
                student.Notes.Add(note);
            }

            studentNotes = _context.Notes.Where(n => n.IdElem == id).ToList();
            
            
        }

    }
}
