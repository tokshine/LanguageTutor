using LanguageTutor.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LanguageTutor.Data
{
    public interface ILanguageData
    {
        IEnumerable<LanguageText> GetAll();

        LanguageText GetById(int id);

        LanguageText Update(LanguageText updatedLanguageText);

        LanguageText Add(LanguageText newLanguageText);

        int Commit();
    }

    public class InMemoryILanguageData : ILanguageData
    {
       readonly List<LanguageText> languageTexts;
        public InMemoryILanguageData()
        {
            languageTexts = new List<LanguageText>()
            {
                new LanguageText { Id=1,LanguageType=LanguageType.FRENCH,Text="Bonjour",EnglishTranslation = "Morning",Pronunciation="Morning",Usecases = "In the morning"},
                new LanguageText { Id=2,LanguageType=LanguageType.YORUBA,Text="Kaaro",EnglishTranslation = "Morning",Pronunciation="Kaaro",Usecases = "Ekaaro"},
            };
        }

        public IEnumerable<LanguageText> GetAll()
        {
            return from l in languageTexts
                   orderby l.Text
                   select l;

           
        }

        public LanguageText GetById(int id)
        {
            //return languageTexts.Find(x => x.Id == id);

            return languageTexts.SingleOrDefault(x => x.Id == id);
        }

        public LanguageText Update(LanguageText updatedLanguageText)
        {
            var languageText = languageTexts.SingleOrDefault(x => x.Id == updatedLanguageText.Id);
            if (languageText != null)
            {


            }

            return languageText;
        }

        public LanguageText Add(LanguageText newLanguageText)
        {
            languageTexts.Add(newLanguageText);
            newLanguageText.Id = languageTexts.Max(l => l.Id) + 1;
            return newLanguageText;
        }

        //transactional sake
        public int Commit()
        {
            return 0;
        }
    }

}
