using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWind.Core.Entities.Car;
using NorthWind.Core.Entities.RequestCall;
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

        public DbSet<Car> Cars { get; set; }
        public DbSet<ServiceView> ServiceViews { get; set; }
        public DbSet<FailedRequestCall> FailedRequestCalls { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            var assemblyWithConfigurations = GetType().Assembly;
            builder.ApplyConfigurationsFromAssembly(assemblyWithConfigurations);


            base.OnModelCreating(builder);
        }
    }
}