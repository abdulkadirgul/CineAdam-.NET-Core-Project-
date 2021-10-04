using Common;
using DataAccess.Context;
using DataAccess.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Service.IRepository;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            //Repository ba��ml�l�klar� burada dahil edilecek. services.AddTransient<IGenreRepository,GenreRepository>();

            services.AddDbContext<MovieContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("WebUI")));
            services.AddIdentity<AppUser, IdentityRole>(x =>
            {
                x.Password.RequiredLength = 4;
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequireDigit = false;
                x.Password.RequireLowercase = false;
                x.Password.RequireUppercase = false;
            }).AddErrorDescriber<CustomPasswordValidation>().AddEntityFrameworkStores<MovieContext>();

            //cookie i�lemleri
            services.ConfigureApplicationCookie(x =>
            {
                x.LoginPath = new PathString("/Home/Login");
                x.Cookie = new CookieBuilder
                {
                    Name = "NetCoreIdentityCookie"
                };
                x.SlidingExpiration = true;
                x.ExpireTimeSpan = TimeSpan.FromMinutes(1);
            });


            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<ISaloonRepository, SaloonRepository>();
            services.AddTransient<IWeekRepository, WeekRepository>();
            services.AddTransient<ISessionRepository, SessionRepository>();


            services.AddControllersWithViews();

            services.AddControllersWithViews();
           
        }

       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
        
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"node_modules")),
            //    RequestPath = new PathString("/vendor")
            //});

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{Controller=Home}/{Action=Index}/{id?}"
        );
                endpoints.MapControllerRoute(
            name: "account",
            pattern: "{Controller=Account}/{Action=Profile}/{Name}"
        );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
