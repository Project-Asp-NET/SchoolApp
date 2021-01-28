using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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

        public async Task OnGetAsync()
        {
            Etudiant = await  _context.Etudiants.ToListAsync();
        }/**/
        
    }
}
