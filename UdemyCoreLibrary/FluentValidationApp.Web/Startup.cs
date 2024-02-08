using FluentValidation.AspNetCore;
using FluentValidationApp.Web.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationApp.Web
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
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings"]);
            });

            //services.AddSingleton<IValidator<Customer>, CustomerValidator>(); 
            //Hepsi i�in ayr� ayr� pek tercih edilmiyor, zor yol .

            services.AddControllersWithViews().AddFluentValidation(options=>
            {
                options.RegisterValidatorsFromAssemblyContaining<Startup>();
            });
            //Bu y�ntem, Startup s�n�f�n�n bulundu�u derlemedeki do�rulay�c� s�n�flar�n� bulur ve bunlar� FluentValidation'a kaydeder. B�ylece, do�rulama kurallar�n�z otomatik olarak kullan�labilir hale gelir ve ASP.NET Core controller'lar�nda veya di�er yerlerde bu kurallar�n uygulanmas� sa�lan�r.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
