﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LanguageTutor.Core;
using LanguageTutor.Data;

namespace LanguageTutor.Web.Pages.L1
{
    public class DeleteModel : PageModel
    {
        private readonly LanguageTutor.Data.LanguageDbContext _context;

        public DeleteModel(LanguageTutor.Data.LanguageDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LanguageText LanguageText { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LanguageText = await _context.LanguageText.FirstOrDefaultAsync(m => m.Id == id);

            if (LanguageText == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LanguageText = await _context.LanguageText.FindAsync(id);

            if (LanguageText != null)
            {
                _context.LanguageText.Remove(LanguageText);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
