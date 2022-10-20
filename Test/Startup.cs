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
using Test.Data.Interfase;
using Test.Data.Repository;
using Test.Models.InitializeDB;

namespace Test
{
    public class Startup
    {
        private readonly IConfigurationRoot _confString;
        public Startup(IWebHostEnvironment hostEnv)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("appsettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            });
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews();
            services.AddTransient<ICourse, CourseRepository>();
            services.AddTransient<IAcademicGroup,AcademicGroupRepository>();
            services.AddTransient<ISpeciality,SpecialityRepository>();
            services.AddTransient<ITeacher,TeacherRepository>();
            services.AddTransient<IStudent,StudentRepository>();
            services.AddTransient<IPosition,PositionRepository>();
            //services.AddMvc();
            services.AddSession();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                
            });
        }
    }
    
            
           
            
            
}
