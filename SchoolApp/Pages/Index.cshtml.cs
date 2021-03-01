using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SchoolApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly SchoolApp.Data.SchoolDBContext _context;

        public IList<SchoolApp.Models.Etudiant> listeEtudiants { get; set; }
        public IList<SchoolApp.Models.Admin> listeAdmins { get; set; }
        public IList<SchoolApp.Models.Prof> listeProfs { get; set; }
        public SchoolApp.Models.Etudiant etudiant { get; set; }
        public SchoolApp.Models.Admin admin { get; set; }

        public SchoolApp.Models.Prof prof { get; set; }

        public IndexModel(ILogger<IndexModel> logger, SchoolApp.Data.SchoolDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            listeEtudiants = _context.Etudiants.ToList();
            listeProfs = _context.Profs.ToList();
            listeAdmins = _context.Admins.ToList();

            string id = Request.Form["username"];
            string password = Request.Form["password"];

            int temp = 0;
            string url = "";

            foreach(var item in listeEtudiants)
            {
                if (item.IdEtud.Equals(id))
                {
                    if(item.Password.Equals(password))
                    {
                        url = "/Etudiants?id=" + id;
                        return Redirect(url);
                    }
                    else return Redirect("/Error");
                }
            }

            foreach(var item in listeProfs)
            {
                if (item.IdProf.Equals(id))
                {
                    if (item.Password.Equals(password))
                    {
                        url = "/Profs?id=" + id;
                        return Redirect(url);
                    }
                    else return Redirect("/Error");
                }
            }

            foreach(var item in listeAdmins)
            {
                if (item.IdAdmin.Equals(id))
                {
                    if (item.Password.Equals(password))
                    {
                        url = "/Admins?id=" + id;
                        return Redirect(url);
                    }
                    else return Redirect("/Error");
                }
            }

            
        return Redirect("/Error");
        }
    }
}
