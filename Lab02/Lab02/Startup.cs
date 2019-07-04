using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab02.Models;
using Lab02.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Lab02
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
            services.AddDbContext<BooksContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("BooksConnection"));
            });
            services.AddTransient<IBooksService, DataBooksService>(); // ef-core version
            services.AddSwaggerGen(options =>
            {
                // options.IncludeXmlComments("../docs/BooksServiceSample.xml");
                options.SwaggerDoc("v1", new Info
                {
                    Title = "Books Service API",
                    Version = "v1",
                    Description = "Sample service for a Web API workshop",
                    Contact = new Contact { Name = "Andreas Bachmaier", Url = "http://www.bachmaier.cc" },
                    License = new License { Name = "Apache v2 License" }
                });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Books Services"));

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
