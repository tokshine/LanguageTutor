using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LanguageTutor.Web.Pages.Language
{
   //api client
    public class ClientLanguagesModel : PageModel
    {

        [TempData]
        public string Message { get; set; }
    }
}