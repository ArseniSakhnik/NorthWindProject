using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.ConfigurationModels;

namespace NorthWind.API.APIExtensions
{
    public static class APIExtensions
    {
        public static void AddDatabase(this IServiceCollection services, AppSettings appSettings)
        {
            var connectionString = appSettings.Connection;
            var mySqlMajor = int.Parse(appSettings.MySqlMajorVersion);
            var mySqlMinor = int.Parse(appSettings.MySqlMinorVersion);
            var mySqlBuild = int.Parse(appSettings.MySqlBuild);
            var isMariaDb = appSettings.IsMariaDb;
            
            if (isMariaDb)
            {
                var mySqlVersion = new MariaDbServerVersion(new Version(mySqlMajor, mySqlMinor, mySqlBuild));
                services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseMySql(connectionString, mySqlVersion,
                        sql => { sql.MigrationsAssembly("NorthWind.API"); });
                });
            }
            else
            {
                var mySqlVersion = new MySqlServerVersion(new Version(mySqlMajor, mySqlMinor, mySqlBuild));
                services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseMySql(connectionString, mySqlVersion,
                        sql => { sql.MigrationsAssembly("NorthWind.API"); });
                });
            }
        }

        public static void AddRobots(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                if (context.Request.Path.StartsWithSegments("/robots.txt"))
                {
                    var robotsTxtPath = Path.Combine(env.ContentRootPath, "wwwroot/seo/robots.txt");
                    var output = await File.ReadAllTextAsync(robotsTxtPath);
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync(output);
                }
                else
                {
                    await next();
                }
            });
        }

        public static void AddSitemap(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                if (context.Request.Path.StartsWithSegments("/sitemap.xml"))
                {
                    var sitemapPath = Path.Combine(env.ContentRootPath, "wwwroot/seo/sitemap.xml");
                    var output = await File.ReadAllTextAsync(sitemapPath);
                    context.Response.ContentType = "application/xml";
                    await context.Response.WriteAsync(output);
                }
                else
                {
                    await next();
                }
            });
        }
    }
}