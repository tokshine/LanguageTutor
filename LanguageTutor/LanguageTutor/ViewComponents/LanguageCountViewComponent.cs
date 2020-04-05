using LanguageTutor.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageTutor.Web.ViewComponents
{
    public class LanguageCountViewComponent
         : ViewComponent
    {
        private readonly ILanguageData languageData;

        public LanguageCountViewComponent(ILanguageData languageData)
        {
            this.languageData = languageData;
        }

        public IViewComponentResult Invoke()
        {
            var count = languageData.GetCountOfLanguageTexts();
            return View(count);
        }

    }
}
