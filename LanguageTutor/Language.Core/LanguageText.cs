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

    }
}
