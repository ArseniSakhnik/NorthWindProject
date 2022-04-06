using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NorthWind.Core.Entities.Purchases.BasePurchase;
using NorthWind.Core.Entities.Purchases.KgoPurchase;
using NorthWind.Core.Entities.Purchases.VacuumTruckPurchaseFiz;
using NorthWind.Core.Entities.Purchases.VacuumTruckPurchaseYur;
using NorthWind.Core.Entities.Services;
using NorthWind.Core.Entities.Services.Files;
using NorthWind.Core.Entities.Test;
using NorthWind.Core.Enums;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.Services;
using NorthWindProject.Application.Common.UserModel;

namespace NorthWindProject.Application.Common.Access
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        private readonly DomainEventService _domainEventService;

        public AppDbContext(DbContextOptions<AppDbContext> options, IPublisher mediator)
            : base(options)
        {
            _domainEventService = new DomainEventService(mediator);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            var events = GetDomainEvents().ToList();
            await DispatchEventAsync(events);

            return result;
        }


        private IEnumerable<DomainEvent> GetDomainEvents()
        {
            var domainEventEntity = ChangeTracker
                .Entries<IHasDomainEvent>()
                .Select(x => x.Entity.DomainEvents)
                .SelectMany(x => x)
                .Where(domainEvent => !domainEvent.IsPublished);
            return domainEventEntity;
        }

        private async Task DispatchEventAsync(IList<DomainEvent> eventsToDispatch)
        {
            while (eventsToDispatch.Any())
            {
                var domainEventEntity = eventsToDispatch.First();
                domainEventEntity.IsPublished = true;
                await _domainEventService.Publish(domainEventEntity);
                eventsToDispatch.RemoveAt(0);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            var assemblyWithConfigurations = GetType().Assembly; //get whatever assembly you want
            builder.ApplyConfigurationsFromAssembly(assemblyWithConfigurations);

            builder.Entity<IdentityRole<int>>().HasData(new List<IdentityRole<int>>
            {
                new()
                {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                },
                new()
                {
                    Id = 2,
                    Name = "Client",
                    NormalizedName = "Client".ToUpper()
                }
            });

            builder.Entity<ApplicationUser>().HasData(new List<ApplicationUser>
            {
                new()
                {
                    Id = 1,
                    Name = "Admin",
                    Surname = "Admin",
                    MiddleName = "Admin",
                    UserName = "Admin",
                    Email = "Admin@admin.ru",
                    NormalizedUserName = "Admin".ToUpper(),
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "admin"),
                    LockoutEnabled = true,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                }
            });

            builder.Entity<IdentityUserRole<int>>().HasData(new List<IdentityUserRole<int>>
            {
                new()
                {
                    RoleId = 1,
                    UserId = 1
                }
            });
            

            base.OnModelCreating(builder);
        }

        #region Service

        public DbSet<ServiceView> ServiceViews { get; set; }

        public DbSet<ServiceViewSettings> ServiceViewSettings { get; set; }
        public DbSet<Service> Services { get; set; }

        #endregion

        #region Purchase

        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<VacuumTruckFizPurchase> FizVacuumTruckPurchases { get; set; }
        public DbSet<VacuumTruckYurPurchase> YurVacuumTruckPurchases { get; set; }
        public DbSet<KGOPurchase> KgoPurchases { get; set; }

        #endregion

        #region Test

        public DbSet<ServiceFile> ServiceFiles { get; set; }
        public DbSet<Test> Tests { get; set; }

        #endregion
    }
}