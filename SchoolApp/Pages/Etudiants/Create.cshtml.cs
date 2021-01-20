using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Data;
using SchoolApp.Models;

namespace SchoolApp.Pages.Etudiants
{
    public class CreateModel : PageModel
    {
        private SchoolApp.Data.SchoolDBContext _context;

        public CreateModel(SchoolApp.Data.SchoolDBContext context)
        {
            _context = context;
            
        }

        public IActionResult OnGet()
        {
            Filliere = _context.Fillieres.ToList();
            return Page();
        }

        [BindProperty]
        public Etudiant Etudiant { get; set; }
        public IList<Filliere> Filliere { get; set; }


        
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Etudiants.Add(Etudiant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }/**/
    }

}
