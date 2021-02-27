using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Data;
using SchoolApp.Models;

namespace SchoolApp.Pages.Administrateur
{
    public class ProfsModel : PageModel
    {
        private readonly SchoolDBContext _context;
        

        public ProfsModel(SchoolDBContext context)
        {
            _context = context;
        }

        public IList<Models.Filliere> Filliere { get; set; }
        [BindProperty]
        public IList<Models.Prof> Prof { get; set; }
        public IList<Models.Departement> Departement { get; set; }
        public Models.Admin Admin2 { get; private set; }
        [BindProperty]
        public Prof deleteProf { get;  set; }
        [BindProperty]
        public Prof editProf { get;  set; }
        [BindProperty]
        public Prof addProf { get; set; }
        public void OnGet()
        {
            Prof = _context.Profs.Include(s=> s.Elements).Include(s => s.IdDepNavigation).ToList();

            Filliere = _context.Fillieres.ToList();
            HttpContext.Session.SetString("IDAdmin", "adm1");

            String id = HttpContext.Session.GetString("IDAdmin");

            Admin2 = _context.Admins.Single(s => s.IdAdmin == id);
            ViewData["Adminname"] = Admin2.Username;
            Departement = _context.Departements.ToList();
        }

        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (editProf != null)
            {
                _context.Attach(editProf).State = EntityState.Modified;
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
                if (!isExists(editProf.IdProf))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Profs");
        }
        public async Task<IActionResult> OnPostDeleteAsync()
        {


            //deleteAdmin =  _context.Admins.Find(id);

            if (deleteProf != null)
            {
                _context.Profs.Remove(deleteProf);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Profs");
        }
        public async Task<IActionResult> OnPostAddAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Profs.Add(addProf);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Profs");
        }
        private bool isExists(string id)
        {
            return _context.Profs.Any(e => e.IdProf == id);
        }
    }
}
