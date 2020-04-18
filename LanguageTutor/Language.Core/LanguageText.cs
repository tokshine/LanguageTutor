using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace LanguageTutor.Core
{

    public enum LanguageType{

        NONE,
        FRENCH,
        ENGLISH,
        YORUBA,
        SPANISH,
        URHOBO
    }
    public class LanguageText
    {
       public int Id { get; set; }

        [Required,StringLength(80)]
       public string Text { get; set; }

        [Required, StringLength(255)]
        public string EnglishTranslation { get; set; }

        public string Pronunciation { get; set; }

        public string Usecases { get; set; }

        public LanguageType LanguageType { get; set; }

        public LanguageUser User { get; set; }

    }
    public class LanguageUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
