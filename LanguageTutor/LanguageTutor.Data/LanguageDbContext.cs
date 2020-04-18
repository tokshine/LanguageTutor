using LanguageTutor.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageTutor.Data
{
    //public class LanguageDbContext :DbContext
    //{
    //    public LanguageDbContext(DbContextOptions<LanguageDbContext> dbContext):base(dbContext)
    //    {

    //    }
    //    public DbSet<LanguageText> LanguageText { get; set; }
    //}

    //To get an authenticated user to use this application use IdentityDbContext instead DbContext
    //Watch video Building a Web App with ASP.NET Core, MVC, Entity Framework Core, Bootstrap, and Angular
    //for identitydbcontext ,install microsoft.aspnetcore.identity.entityframeworkcore
    public class LanguageDbContext : IdentityDbContext<LanguageUser>
    {
        public LanguageDbContext(DbContextOptions<LanguageDbContext> dbContext) : base(dbContext)
        {

        }
        public DbSet<LanguageText> LanguageText { get; set; }
    }

  
}
