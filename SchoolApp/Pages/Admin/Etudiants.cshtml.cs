using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolApp.Models;

namespace SchoolApp.Pages.Administrateur
{
    public class EtudiantsModel : PageModel
    {
        private readonly SchoolApp.Data.SchoolDBContext _context;

        public EtudiantsModel(SchoolApp.Data.SchoolDBContext context)
        {
            _context = context;
        }

        public IList<Etudiant> Etudiant { get; set; }

        /*public async Task OnGetAsync()
        {
            //Departement = await _context.Departements.ToListAsync();
        }*/
        public void OnGet()
        {
            Etudiant = _context.Etudiants.ToList();
        }
    }
}
