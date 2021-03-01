using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SchoolApp.Pages
{
    public class User {

        public string username {get;set;}
        public string password { get; set; }

        public string option { get; set; }

    }
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly SchoolApp.Data.SchoolDBContext _context;
        public IndexModel(ILogger<IndexModel> logger, SchoolApp.Data.SchoolDBContext context)
        {
            _logger = logger;
            _context = context;

        }
        [BindProperty]
        public User user { get; set; }

        public void OnGet()
        {

            HttpContext.Session.Clear();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (user != null)
            {

                if (user.option == "Admin")
                {
                    try
                    {
                        Models.Admin Admin = _context.Admins.Single(s => s.Username == user.username && s.Password == user.password);
                        HttpContext.Session.SetString("IDAdmin", Admin.IdAdmin);
                        return Redirect("/Admin");
                    }
                    catch (Exception ex)
                    {
                        return Redirect("/Index");
                    }
                }
                else if (user.option == "Prof")
                {
                    try
                    {
                        Models.Prof Prof = _context.Profs.Single(s => s.IdProf == user.username && s.Password == user.password);
                        HttpContext.Session.SetString("IDProf", Prof.IdProf);
                        return Redirect("/Prof");
                    }
                    catch (Exception ex)
                    {
                        return Redirect("/Index");
                    }

                   

                }
                else if (user.option == "Eleve")
                {
                    try {

                    Models.Etudiant Eleve = _context.Etudiants.Single(s => s.IdEtud == user.username && s.Password == user.password);
                    HttpContext.Session.SetString("IDEleve", Eleve.IdEtud);
                    return Redirect("/Eleve");
                    } catch (Exception ex) {
                        return Redirect("/Index");
                    }
                    

                    
                }
            }
            else
            {
                return Redirect("/Index");
            }

            return RedirectToPage("./Index");
        }
        /*public IActionResult OnPost()
        {
            

            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (user != null)
            {
                
                if (user.option=="Admin") {

                    Models.Admin Admin = _context.Admins.Single(s => s.Username == user.username && s.Password == user.password);

                    if (Admin != null )
                    {
                        HttpContext.Session.SetString("IDAdmin", Admin.IdAdmin);
                        return Redirect("/Admin");
                    }
                    else {
                        return Page();
                    }

                } else if (user.option == "Prof") {

                    Models.Prof Prof = _context.Profs.Single(s => s.IdProf == user.username && s.Password == user.password);

                    if (Prof != null)
                    {
                        HttpContext.Session.SetString("IDProf", Prof.IdProf);
                        return Redirect("/Prof");
                    }
                    else
                    {
                        return Page();
                    }

                } else if (user.option == "Eleve")
                {
                    Models.Etudiant Eleve = _context.Etudiants.Single(s => s.IdEtud == user.username && s.Password == user.password);

                    if (Eleve != null)
                    {
                        HttpContext.Session.SetString("IDEleve", Eleve.IdEtud);
                        return Redirect("/Eleve");
                    }
                    else
                    {
                        return Page();
                    }
                }
            }
            else
            {
                return Redirect("/Index");
            }
        }*/
    }
}
