using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageTutor.Core;
using LanguageTutor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace LanguageTutor.Web.Pages.Language
{
    public class DeleteModel : PageModel
    {
        private readonly ILanguageData languageData;

        public LanguageText LanguageText { get; set; }

        public DeleteModel(ILanguageData languageData)
        {
            this.languageData = languageData;
        }

        public IActionResult OnGet(int id)
        {
            LanguageText = languageData.GetById(id);
            if(LanguageText == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            var languageText = languageData.Delete(id);
            languageData.Commit();

            if(languageText == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{languageText.Text} deleted";
            return RedirectToPage("./ClientLanguages");
        }
    }
}