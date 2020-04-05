using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageTutor.Core;
using LanguageTutor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace LanguageTutor.Pages.Language
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration configuration;
        private readonly ILanguageData languageData;

        [BindProperty(SupportsGet = true)]//binding enable for a get operation
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, ILanguageData languageData)
        {
            configuration = config;
            this.languageData = languageData;
        }
        public string Message { get; set; }

        [TempData]
        public string FeedMessage { get; set; }
        public IEnumerable<LanguageText> languageTexts { get; set; }
        public void OnGet(string searchTerm)
        {
            Message = configuration["Message"];
            languageTexts = languageData.GetAll(SearchTerm);

        }
    }

    
}