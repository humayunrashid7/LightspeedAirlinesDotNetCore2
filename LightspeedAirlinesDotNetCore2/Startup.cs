using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LightspeedAirlinesDotNetCore2.Filters;
using LightspeedAirlinesDotNetCore2.Infrastructure;
using LightspeedAirlinesDotNetCore2.Models;
using LightspeedAirlinesDotNetCore2.Services;
using LightspeedAirlinesDotNetCore2.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSwag.AspNetCore;

namespace LightspeedAirlinesDotNetCore2
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
            // This is the basic info about the airline stored in "appsetting.json".
            services.Configure<AirlineInfo>(Configuration.GetSection("Info"));

            // Implement the Services, AddScoped is used because we cant one instance for each separate request
            services.AddScoped<IAircraftService, AircraftService>();
            services.AddScoped<IAirportService, AirportService>();

            // Use an in memory database for development
            // TODO: Swap out for a real database in production
            services.AddDbContext<AirlineApiDbContext>(
                options => options.UseInMemoryDatabase("airlinedb"));

            // Use Sql Server Database
//            const string connectionString = "Server=DESKTOP-DAN8Q8O;Database=AirlineDbTest;Trusted_Connection=True;";
//            services.AddDbContext<AirlineApiDbContext>(
//                options => options.UseSqlServer(connectionString));

            services
                .AddMvc(options =>
                {
                    // Filter for Exception Handlings that returns Exceptions in JSON Format
                    options.Filters.Add<JsonExceptionFilter>();

                    // Filter for Always requiring Https, No Redirection allowed
                    options.Filters.Add<RequireHttpsOrCloseAttribute>();
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddRouting(options => options.LowercaseUrls = true);

            // Api Versioning: Add Nuget Package 'Microsoft.AspNetCore.Mvc.Versioning'
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ApiVersionReader = new MediaTypeApiVersionReader();
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
            });

            // Add Automapper Service (NuGet pkg: Automapper.Extensions.Microsoft.DependencyInjection)
            services.AddAutoMapper(
                options => options.AddProfile<MappingProfile>());

            // Add CORS Policy
            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyApp", 
                    policy => policy.AllowAnyOrigin());
            });

            // Add Http Clients for 3rd Party APIs
            services.AddHttpClient<SingaporeClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerUi3WithApiExplorer(options =>
                {
                    options.GeneratorSettings.DefaultPropertyNameHandling =
                        NJsonSchema.PropertyNameHandling.CamelCase;
                });
            }
            else
            {
                app.UseHsts();
            }

            // Redirection is not required as as RequireHttpsOrCloseAttribute filter is added to the Filters list above.
            // app.UseHttpsRedirection();

            app.UseStatusCodePages();
            app.UseCors("AllowMyApp");
            app.UseMvc();
        }
    }
}
