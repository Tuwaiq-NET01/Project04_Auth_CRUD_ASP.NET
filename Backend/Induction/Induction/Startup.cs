using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Induction.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Reflection;
using System.IO;
using Induction.Models;
using Induction.Repositories;
using Microsoft.OpenApi.Models;
using Induction.Helpers;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Induction
{
    public class Startup
    {
        private string[] ALLOWED_ORIGINS = new string[] {"http://localhost:3000","https://dazzling-lamarr-86f006.netlify.app/"};

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false)
                    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                    .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddCors();
            //services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer("Server=.;Database=Induction;Trusted_Connection=True;"));
             services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Induction API",
                    Description = "API Serves the need of the induction app"
          
                });
                
               
                    
                    
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });


            services.AddScoped<IMotavationRepository, MotivationRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IFlashCardRepository, FlashCardRepository>();
            services.AddScoped<IChapterRepository, ChapterRepository>();
            services.AddScoped<IChapterChunkRepository, ChapterChunkRepository>();
            services.AddScoped<IQuotesRepository, QuoteRepository>();
            services.AddScoped<IFactRepository, FactRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IJwtService, JwtService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1"); c.RoutePrefix = string.Empty; });

            /*app.UseHttpsRedirection();
            app.UseStaticFiles();*/

            app.UseRouting();

            app.UseCors(options => options
            .AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed(origin => true) // allow any origin
            .AllowCredentials()
            );

            /*app.UseAuthorization();*/

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}