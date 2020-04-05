using LanguageTutor.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageTutor.Data
{
    public class LanguageDbContext :DbContext
    {
        public LanguageDbContext(DbContextOptions<LanguageDbContext> dbContext):base(dbContext)
        {

        }
        public DbSet<LanguageText> LanguageText { get; set; }
    }
}
