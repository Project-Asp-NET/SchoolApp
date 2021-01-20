﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Data;
using SchoolApp.Models;

namespace SchoolApp.Pages.Elements
{
    public class DetailsModel : PageModel
    {
        private readonly SchoolApp.Data.SchoolDBContext _context;

        public DetailsModel(SchoolApp.Data.SchoolDBContext context)
        {
            _context = context;
        }

        public Element Element { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Element = await _context.Elements.FirstOrDefaultAsync(m => m.IdElem == id);

            if (Element == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
