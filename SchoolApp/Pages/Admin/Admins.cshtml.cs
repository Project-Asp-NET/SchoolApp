using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Models;

namespace SchoolApp.Pages.Admin
{
    public class AdminsModel : PageModel
    {
        private readonly SchoolApp.Data.SchoolDBContext _context;

        public AdminsModel(SchoolApp.Data.SchoolDBContext context)
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
        /*public async Task OnGetAsync()
        {
            //Departement = await _context.Departements.ToListAsync();
        }*/
        public void OnGet()
        {
            Admin = _context.Admins.ToList();
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
                if (!AdminExists(Admin1.IdAdmin))
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
        private bool AdminExists(string id)
        {
            return _context.Admins.Any(e => e.IdAdmin == id);
        }
    }
}
