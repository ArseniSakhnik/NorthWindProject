using System;
using System.IO;
using Elskom.Generic.Libs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NorthWind.API.Configuration;
using NorthWind.API.Services;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Common.Services;
using NorthWindProject.Application.DependencyInjection;
using NorthWindProject.Application.Entities.Purchases.BasePurchase;
using NorthWindProject.Application.Entities.User;
using NorthWindProject.Application.Features.Purchase.Services.PurchaseService;
using NorthWindProject.Application.Interfaces;
using NorthWindProject.Application.Interfaces.DomainEvents;
using NorthWindProject.Application.Middlewares;

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
            var emailSenderService = Configuration.GetSection("EmailSettings");
            services.Configure<EmailSettings>(emailSenderService);
            var secretSection = Configuration.GetSection("SecretSettings");
            services.Configure<SecretSettings>(secretSection);

            var appSettings = appSettingsSection.Get<AppSettings>();

            var connectionString = appSettings.Connection;
            var mySqlMajor = int.Parse(appSettings.MySqlMajorVersion);
            var mySqlMinor = int.Parse(appSettings.MySqlMinorVersion);
            var mySqlBuild = int.Parse(appSettings.MySqlBuild);
            var mySqlVersion = new MySqlServerVersion(new Version(mySqlMajor, mySqlMinor, mySqlBuild));
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySql(connectionString, mySqlVersion,
                    sql => { sql.MigrationsAssembly("NorthWind.API"); });
            });


            services.AddHttpContextAccessor();
            services.AddApplication();


            services.AddIdentity<ApplicationUser, IdentityRole<int>>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = true;
                    options.SignIn.RequireConfirmedEmail = true;
                    options.Lockout.AllowedForNewUsers = true;
                    options.User.RequireUniqueEmail = true;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();


            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddRazorPages();

            services.AddScoped<IDomainEventService, DomainEventService>();
            services.AddScoped<IEmailSenderService, EmailSenderService>();
            services.AddScoped<IEncryptionService, EncryptionService>();
            services.AddScoped<IPurchaseService, PurchaseService>();
            services.AddTransient<ExceptionHandlingMiddleware>();

            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "Kal", Version = "v1"}); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/Error");
                app.UseHsts();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kal"));
            }

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
            
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "wwwroot/bundles/img")),
                RequestPath = "/img"
            });
            
        }
    }
}