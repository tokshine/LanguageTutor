using System;
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
    public class IndexModel : PageModel
    {
        private readonly LanguageTutor.Data.LanguageDbContext _context;

        public IndexModel(LanguageTutor.Data.LanguageDbContext context)
        {
            _context = context;
        }

        public IList<LanguageText> LanguageText { get;set; }

        public async Task OnGetAsync()
        {
            LanguageText = await _context.LanguageText.ToListAsync();
        }
    }
}
