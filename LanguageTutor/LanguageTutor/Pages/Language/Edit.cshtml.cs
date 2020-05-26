using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageTutor.Core;
using LanguageTutor.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LanguageTutor.Web.Pages.Language
{
    public class EditModel : PageModel
    {
        private readonly ILanguageData languageData;
        private readonly IHtmlHelper htmlHelper;
        private readonly UserManager<LanguageUser> _userManager;

        [BindProperty] // 2 way binding
        public LanguageText LanguageText { get; set; }
        

        public IEnumerable<SelectListItem> Languages { get; set; }
        public EditModel(ILanguageData languageData,IHtmlHelper htmlHelper, UserManager<LanguageUser> userManager)
        {
            this.languageData = languageData;
            this.htmlHelper = htmlHelper;
            _userManager = userManager;
        }
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                LanguageText = languageData.GetById(id.Value);
                ViewData["Title"] = "Edit";
            }
            else {
                ViewData["Title"] = "Add a word/phrase";
                LanguageText = new LanguageText();
                LanguageText.LanguageType = LanguageType.YORUBA;
            }
            
            Languages = htmlHelper.GetEnumSelectList<LanguageType>();
            if (LanguageText == null)
            {

                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public  async Task<IActionResult> OnPost()
        {
            //POST/REDIRECT/GET  PRINCIPLE

            if (LanguageText.LanguageType == LanguageType.NONE)
            {
                Languages = htmlHelper.GetEnumSelectList<LanguageType>();
                ModelState.AddModelError("","Select a Language");
                return Page();
            }

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
                var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
                LanguageText.User = currentUser;
                languageData.Add(LanguageText);
            }
            
            languageData.Commit();
            TempData["Message"] =   "Language Saved";
            return RedirectToPage("./ClientLanguages");
            //return RedirectToPage("./List");
        }
    }
}