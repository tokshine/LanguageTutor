using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LanguageTutor.Core;
using LanguageTutor.Data;

namespace LanguageTutor.Web.Pages.L1
{
    public class CreateModel : PageModel
    {
        private readonly LanguageTutor.Data.LanguageDbContext _context;

        public CreateModel(LanguageTutor.Data.LanguageDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public LanguageText LanguageText { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.LanguageText.Add(LanguageText);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}