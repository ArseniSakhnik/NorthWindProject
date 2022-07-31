using System;
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
        
        public static void AddEmailSenderService(this IServiceCollection services, AppSettings appSettings) {}
    }
}