using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageTutor.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LanguageTutor.Web.Pages.Language
{
    public class DetailPageModel : PageModel
    {
        public LanguageText Language { get; set; }
        public void OnGet(int Id)
        {
            Language = new LanguageText();
            Language.Id = Id;
        }
    }
}