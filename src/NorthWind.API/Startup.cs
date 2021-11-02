using System;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using NorthWind.API.Models;
using NorthWind.API.Services;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Common.Exceptions;
using NorthWindProject.Application.Common.Services;
using NorthWindProject.Application.DependencyInjection;
using NorthWindProject.Application.Entities.User;
using NorthWindProject.Application.Interfaces;
using NorthWindProject.Application.Interfaces.DomainEvents;
using NorthWindProject.Application.Middlewares;
using VueCliMiddleware;

namespace NorthWind.API
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
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();

            var connectionString = appSettings.Connection;
            var mySqlVersion = new MySqlServerVersion(new Version(8, 0, 26));
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySql(connectionString, mySqlVersion,
                    sql => { sql.MigrationsAssembly("NorthWind.API"); });
            });


            services.AddApplication();
            services.AddIdentity<ApplicationUser, IdentityRole<int>>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
            }).AddEntityFrameworkStores<AppDbContext>();

            services.AddHttpContextAccessor();

            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddRazorPages();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "clientapp";
            });

            services.AddScoped<IDomainEventService, DomainEventService>();
            services.AddTransient<ExceptionHandlingMiddleware>();
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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            
            app.UseRouting();
            app.UseHttpsRedirection();
            // app.UseStaticFiles();
            app.UseSpaStaticFiles();
            
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = env.IsDevelopment() ? "clientapp" : "dist";

                if (env.IsDevelopment())
                {
                    spa.UseVueCli(npmScript: "serve");
                }
            });
        }
    }
}