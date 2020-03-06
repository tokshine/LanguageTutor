using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageTutor.Core;
using LanguageTutor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LanguageTutor.Web.Pages.Language
{
    public class EditModel : PageModel
    {
        private readonly ILanguageData languageData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty] // 2 way binding
        public LanguageText LanguageText { get; set; }
        

        public IEnumerable<SelectListItem> Languages { get; set; }
        public EditModel(ILanguageData languageData,IHtmlHelper htmlHelper)
        {
            this.languageData = languageData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                LanguageText = languageData.GetById(id.Value);
            }
            else {

                LanguageText = new LanguageText();
            }
            
            Languages = htmlHelper.GetEnumSelectList<LanguageType>();
            if (LanguageText == null)
            {

                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            //POST-GET-REDIRECT  not sure it is not called post redirect get
            if (!ModelState.IsValid)
            {
                Languages = htmlHelper.GetEnumSelectList<LanguageType>();

                return Page();

            }

            if (LanguageText.Id > 0)
            {
                languageData.Update(LanguageText);
            }
            else {
                languageData.Add(LanguageText);
            }
            
            languageData.Commit();
            return RedirectToPage("./List",new  { FeedMessage = "Language Saved"});
        }
    }
}