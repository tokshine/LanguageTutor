using LanguageTutor.Core;
using LanguageTutor.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace LanguageTutor
{
    internal class UserSeeder
    {

        private readonly LanguageDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly UserManager<LanguageUser> _userManager;

        public UserSeeder(LanguageDbContext context,IHostingEnvironment environment,UserManager<LanguageUser> userManager)
        {
            _context = context;
            _hostingEnvironment = environment;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {

            _context.Database.EnsureCreated();


            var user = await _userManager.FindByEmailAsync("ife@adeleke.com");

            //var user = await _userManager.FindByEmailAsync("toks_philip@yahoo.com");


            if (user == null)
            {
                //user = new LanguageUser
                //{

                //    FirstName = "Shina",
                //    LastName = "Shina",
                //    UserName = "toks_philip@yahoo.com",
                //    Email = "toks_philip@yahoo.com"
                //};

                user = new LanguageUser
                {

                    FirstName = "princess",
                    LastName = "ife",
                    UserName = "ife",
                    Email = "ife@adeleke.com"
                };

                var result = await _userManager.CreateAsync(user, "Jersey2010#");



                //user = new LanguageUser
                //{

                //    FirstName = "princess",
                //    LastName = "ife",
                //    UserName = "adeife@adeleke.com",
                //    Email = "adeife@adeleke.com"
                //};

                //var result = await _userManager.CreateAsync(user, "Jersey2010$");



                //var result = await _userManager.CreateAsync(user, "Weekend2003$");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user in seeder");
                }
            }
        }

    }
}