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
    public class AbsencesModel : PageModel
    {
        private readonly SchoolDBContext _context;

        public AbsencesModel(SchoolDBContext context)
        {
            _context = context;
        }

        public IList<SchoolApp.Models.Absence> Absence { get; set; }
        public Models.Admin Admin { get; private set; }

        public void OnGet()
        {
            Absence = _context.Absences.ToList();


            String id = HttpContext.Session.GetString("IDAdmin");

            Admin = _context.Admins.Single(s => s.IdAdmin == id);
            ViewData["Adminname"] = Admin.Username;
        }
    }
}
