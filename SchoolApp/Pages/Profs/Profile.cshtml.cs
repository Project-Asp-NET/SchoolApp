using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolApp.Data;
using SchoolApp.Models;

namespace SchoolApp.Pages.Profs
{
    public class ProfileModel : PageModel
    {
        public IList<SchoolApp.Models.Element> profElements { get; set; }

        public Prof Prof { get; set; }

        private readonly SchoolDBContext _context;

        public ProfileModel(SchoolDBContext context)
        {
            _context = context;
        }
        public void OnGet(string idprof)
        {
            profElements = _context.Elements.Where(e => e.IdProf == idprof).ToList();
            ViewData["profElements"] = profElements;
            ViewData["idProf"] = idprof;

            Prof = (Prof)_context.Profs.Where(p => p.IdProf == idprof).FirstOrDefault();
        }
    }
}
