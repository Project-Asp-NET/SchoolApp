using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        public IList<Filliere> Filliere { get; set; }
        public IList<Etudiant> Etudiant { get; set; }
        [BindProperty]
        public SchoolApp.Models.Etudiant addEtud { get; set; }
        [BindProperty]
        public SchoolApp.Models.Etudiant editEtud { get; set; }
        [BindProperty]
        public SchoolApp.Models.Etudiant deleteEtud { get; set; }
        public Models.Admin Admin2 { get; private set; }

        public async Task OnGetAsync()
        {
            Etudiant = await  _context.Etudiants.ToListAsync();
            Filliere = _context.Fillieres.ToList();

            HttpContext.Session.SetString("IDAdmin", "adm1");

            String id = HttpContext.Session.GetString("IDAdmin");

            Admin2 = _context.Admins.Single(s => s.IdAdmin == id);
            ViewData["Adminname"] = Admin2.Username;
        }/**/
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (editEtud != null)
            {
                _context.Attach(editEtud).State = EntityState.Modified;
            }
            else
            {
                return NotFound();
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!isExists(editEtud.IdEtud))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Etudiants");
        }
        public async Task<IActionResult> OnPostDeleteAsync()
        {


            //deleteAdmin =  _context.Admins.Find(id);

            if (deleteEtud != null)
            {
                _context.Etudiants.Remove(deleteEtud);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Etudiants");
        }
        public async Task<IActionResult> OnPostAddAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Etudiants.Add(addEtud);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Etudiants");
        }
        private bool isExists(string id)
        {
            return _context.Etudiants.Any(e => e.IdEtud == id);
        }
    }
}
