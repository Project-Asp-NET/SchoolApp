﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolApp.Data;
using SchoolApp.Models;

namespace SchoolApp.Pages.Profs
{
    public class CreateModel : PageModel
    {
        private readonly SchoolApp.Data.SchoolDBContext _context;

        public CreateModel(SchoolApp.Data.SchoolDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Prof Prof { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Profs.Add(Prof);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
