using LanguageTutor.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LanguageTutor.Data
{
    public interface ILanguageData
    {
        IEnumerable<LanguageText> GetAll(string optionalstr = "");

        LanguageText GetById(int id);

        LanguageText Update(LanguageText updatedLanguageText);

        LanguageText Add(LanguageText newLanguageText);

        LanguageText Delete(int id);
        int GetCountOfLanguageTexts();
        int Commit();
    }

    public class SqlLanguageData : ILanguageData
    {
        private readonly LanguageDbContext db;
        public SqlLanguageData(LanguageDbContext dbContext)
        {
            db = dbContext;
        }


        public int GetCountOfLanguageTexts()
        {
            return db.LanguageText.Count();
        }

        public LanguageText Add(LanguageText newLanguageText)
        {
            db.Add(newLanguageText);
            return newLanguageText;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public LanguageText Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                db.LanguageText.Remove(item);
            }
            return item;
        }

        public IEnumerable<LanguageText> GetAll(string name)
        {
          
                var query = from item in db.LanguageText
                            where item.Text.StartsWith(name)
                            || string.IsNullOrEmpty(name)
                            orderby item.Text
                            select item;

            return query;
        }

        public LanguageText GetById(int id)
        {
            var item = db.LanguageText.Find(id);
            return item;
        }

        public LanguageText Update(LanguageText updatedLanguageText)
        {
            var entity = db.LanguageText.Attach(updatedLanguageText);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return updatedLanguageText;

        }
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

        public IEnumerable<LanguageText> GetAll(string name)
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

        public int GetCountOfLanguageTexts()
        {
            return languageTexts.Count();
        }

        public LanguageText Delete(int id)
        {
            var item = languageTexts.FirstOrDefault(x => x.Id == id);
            if (item!=null)
            {
                languageTexts.Remove(item);
            }
            return item;
        }
    }

}
