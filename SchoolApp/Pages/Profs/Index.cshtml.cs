using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Data;
using SchoolApp.Models;

namespace SchoolApp.Pages.Profs
{
    public class IndexModel : PageModel
    {
        private readonly SchoolApp.Data.SchoolDBContext _context;

        public IList<SchoolApp.Models.Element> profElements { get; set; }

        public Prof Prof;


        public IndexModel(SchoolApp.Data.SchoolDBContext context)
        {
            _context = context;
        }

       

        public void OnGet(string id)
        {
            ViewData["idProf"] = id;
            profElements = _context.Elements.Where(e => e.IdProf == id).ToList();
            ViewData["profElements"] = profElements;

            Prof = (Prof)_context.Profs.Where(p => p.IdProf == id).FirstOrDefault();
        }
    }
}
