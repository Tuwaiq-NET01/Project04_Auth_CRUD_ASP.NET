using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamApplication.Data;
using ExamApplication.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExamApplication
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
           
            services.AddIdentity<IdentityUser, IdentityRole>(option =>
            {

                option.Password.RequireDigit = false;

                option.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<MyDbContext>();
          

            services.AddDbContext<MyDbContext>();

            services.AddScoped<IQuestionRepo, QuestionsRepo>();
            services.AddScoped<IAnswersRepo, AnswersRepo>();
            services.AddMvc();
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            //app.UseAuthorization();
            app.UseAuthentication();
           
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
