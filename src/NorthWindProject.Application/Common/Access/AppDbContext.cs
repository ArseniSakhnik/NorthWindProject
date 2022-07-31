using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWind.Core.Entities.Car;
using NorthWind.Core.Entities.Services;
using NorthWind.Core.Interfaces;

namespace NorthWindProject.Application.Common.Access
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }

        #region AppCommon

        public DbSet<Car> Cars { get; set; }

        #endregion

        #region Service

        public DbSet<ServiceView> ServiceViews { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var assemblyWithConfigurations = GetType().Assembly;
            builder.ApplyConfigurationsFromAssembly(assemblyWithConfigurations);


            base.OnModelCreating(builder);
        }
    }
}