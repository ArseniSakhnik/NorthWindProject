using System.IO;
using Hangfire;
using Hangfire.Common;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NorthWind.API.APIExtensions;
using NorthWindProject.Application.ConfigurationModels;
using NorthWindProject.Application.DependencyInjection;
using NorthWindProject.Application.Middlewares;
using NorthWindProject.Application.Services.BotService;
using NorthWindProject.Application.Services.RecurringJobService;
using VueCliMiddleware;

namespace NorthWind.API
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettingsSection = Configuration.GetSection("AppSettings");

            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();

            services.AddDatabase(appSettings);

            services.AddHttpContextAccessor();
            services.AddApplication();

            services.AddScoped<BotService>();

            services.AddTransient<ExceptionHandlingMiddleware>();


            services.AddControllers();
            
            
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "clientapp/dist";
            });

            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "Test", Version = "v1"}); });

            services.AddHangfire(x => { x.UseMemoryStorage(); });
            services.AddHangfireServer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IRecurringJobManager recurringJobs)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseHsts();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kal"));
            }

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.AddRobots(env);
            app.AddSitemap(env);

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseHangfireDashboard();
            
            if (!env.IsDevelopment()) {
                app.UseSpaStaticFiles();
            }
            
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "wwwroot/ServiceImage")),
                RequestPath = "/ServiceImage"
            });

            app.UseSpa(spa =>
            {
                if (env.IsDevelopment())
                {
                    spa.Options.SourcePath = "clientapp";
                    spa.UseVueCli(npmScript: "serve");
                }
            });

            recurringJobs.AddOrUpdate("failed_request_calls",
                Job.FromExpression<RecurringJobService>(x => x.SendRequestFailedRequestCalls()),
                Cron.Hourly()
            );
        }
    }
}