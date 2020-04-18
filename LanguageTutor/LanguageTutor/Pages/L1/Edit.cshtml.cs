using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LanguageTutor.Core;
using LanguageTutor.Data;

namespace LanguageTutor.Web.Pages.L1
{
    public class EditModel : PageModel
    {
        private readonly LanguageTutor.Data.LanguageDbContext _context;
       
        public EditModel(LanguageTutor.Data.LanguageDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            _context.Attach(LanguageText).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanguageTextExists(LanguageText.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LanguageTextExists(int id)
        {
            return _context.LanguageText.Any(e => e.Id == id);
        }
    }
}
