using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolApp.Data;

namespace SchoolApp.Pages.Administrateur
{
    public class ValidationsModel : PageModel
    {
        private readonly SchoolDBContext _context;

        public ValidationsModel(SchoolDBContext context)
        {
            _context = context;
        }

        public IList<SchoolApp.Models.Validation> Val { get; set; }
        public Models.Admin Admin2 { get; private set; }

        public void OnGet()
        {
            Val = _context.Validations.ToList();


            String id = HttpContext.Session.GetString("IDAdmin");

            Admin2 = _context.Admins.Single(s => s.IdAdmin == id);
            ViewData["Adminname"] = Admin2.Username;
        }
    }
}
