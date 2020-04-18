using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageTutor.Core;
using LanguageTutor.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LanguageTutor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //configuring identity

            services.AddIdentity<LanguageUser, IdentityRole>(
                //you set password policy here
                cfg => { cfg.User.RequireUniqueEmail = true;
                    //cfg.Password.RequireDigit = true;
                    //cfg.Password.RequiredLength = 9;
                }).AddEntityFrameworkStores<LanguageDbContext>();

            services.AddDbContextPool<LanguageDbContext>(o =>

                o.UseSqlServer(Configuration.GetConnectionString("LanguageDB"))         
            );

            services.AddTransient<UserSeeder>();

            services.AddScoped<ILanguageData, SqlLanguageData>();//services are scoped to a particular http request

          //  services.AddSingleton<ILanguageData, InMemoryILanguageData>();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseNodeModules(env);
            app.UseAuthentication();
            //app.UseAuthorization(); works in asp.net core 3.0
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
