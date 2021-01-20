using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Classes;
using SchoolApp.Data;
using SchoolApp.Models;

namespace SchoolApp.Pages.Admins
{
    public class IndexModel : PageModel
    {
        private readonly SchoolApp.Data.SchoolDBContext _context;

        public IndexModel(SchoolApp.Data.SchoolDBContext context)
        {
            _context = context;
        }

        public PaginatedList<Admin> Admin { get;set; }
        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public async Task OnGetAsync(string sortOrder,string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            CurrentFilter = searchString;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            IQueryable<Admin> AdminSort = from s in _context.Admins
                                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                AdminSort = AdminSort.Where(s => s.Username.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    AdminSort = AdminSort.OrderByDescending(s => s.Username);
                    break;

                default:
                    AdminSort = AdminSort.OrderBy(s => s.Username);
                    break;
            }
            int pageSize = 2;
            Admin = await PaginatedList<Admin>.CreateAsync(
                AdminSort.AsNoTracking(), pageIndex ?? 1, pageSize);
            

        }
    }
}
