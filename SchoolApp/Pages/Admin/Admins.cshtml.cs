using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Models;
using SchoolApp.Data;
using Microsoft.AspNetCore.Http;

namespace SchoolApp.Pages.Admin
{
    public class AdminsModel : PageModel
    {
        private readonly SchoolDBContext _context;

        public AdminsModel(SchoolDBContext context)
        {
            _context = context;
        }

        public IList<SchoolApp.Models.Admin> Admin { get; set; }
        [BindProperty]
        public SchoolApp.Models.Admin addAdmin { get; set; }
        [BindProperty]
        public SchoolApp.Models.Admin Admin1 { get; set; }
        [BindProperty]
        public SchoolApp.Models.Admin deleteAdmin { get; set; }
        public Models.Admin Admin2 { get; private set; }


        /*public async Task OnGetAsync()
{
//Departement = await _context.Departements.ToListAsync();
}*/
        public void OnGet()
        {
            Admin = _context.Admins.ToList();

            HttpContext.Session.SetString("IDAdmin", "adm1");

            String id = HttpContext.Session.GetString("IDAdmin");

            Admin2 = _context.Admins.Single(s => s.IdAdmin == id);
            ViewData["Adminname"] = Admin2.Username;
        }


        public async Task<IActionResult> OnPostAddAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (addAdmin != null)
            {
                _context.Admins.Add(addAdmin);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Admins");
            }
            else {
                return NotFound();
            }
            

        }

        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Admin1!=null) {
                _context.Attach(Admin1).State = EntityState.Modified;
            }
            else {
                return NotFound();
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!isExists(Admin1.IdAdmin))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Admins");
        }
        public async Task<IActionResult> OnPostDeleteAsync()
        {
            

            //deleteAdmin =  _context.Admins.Find(id);

            if (deleteAdmin != null)
            {
                 _context.Admins.Remove(deleteAdmin);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Admins");
        }
        private bool isExists(string id)
        {
            return _context.Admins.Any(e => e.IdAdmin == id);
        }
    }
}
