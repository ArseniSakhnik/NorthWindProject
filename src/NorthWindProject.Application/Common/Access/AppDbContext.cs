﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NorthWindProject.Application.Common.Configuration.ConfigurationEntities.Purchase;
using NorthWindProject.Application.Common.Configuration.ConfigurationEntities.Service;
using NorthWindProject.Application.Common.Services;
using NorthWindProject.Application.Entities.Purchase;
using NorthWindProject.Application.Entities.Service;
using NorthWindProject.Application.Entities.Test;
using NorthWindProject.Application.Entities.User;
using NorthWindProject.Application.Interfaces.DomainEvents;

namespace NorthWindProject.Application.Common.Access
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        private readonly DomainEventService _domainEventService;
        
        public DbSet<Test> Tests { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseField> PurchaseFields { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceProp> ServiceProps { get; set; }
        public DbSet<ServiceView> ServiceViews { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options, IPublisher mediator)
            : base(options)
        {
            _domainEventService = new DomainEventService(mediator);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
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
            builder.ApplyConfiguration(new PurchaseConfiguration());
            builder.ApplyConfiguration(new ServiceConfiguration());
            
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<IdentityRole<int>>().HasData(new List<IdentityRole<int>>
            {
                new IdentityRole<int>
                {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                },
                new IdentityRole<int>
                {
                    Id = 2,
                    Name = "Client",
                    NormalizedName = "Client".ToUpper()
                }
            });

            builder.Entity<ApplicationUser>().HasData(new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = 1,
                    UserName = "Admin",
                    NormalizedUserName = "Admin".ToUpper(),
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "admin"),
                    LockoutEnabled = true,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                },
                new ApplicationUser
                {
                    Id = 2,
                    UserName = "Client",
                    NormalizedUserName = "Client".ToUpper(),
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "client"),
                    LockoutEnabled = true,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                },
            });

            builder.Entity<IdentityUserRole<int>>().HasData(new List<IdentityUserRole<int>>
            {
                new IdentityUserRole<int>
                {
                    RoleId = 1,
                    UserId = 1
                },
                new IdentityUserRole<int>
                {
                    RoleId = 2,
                    UserId = 2
                }
            });

            base.OnModelCreating(builder);
        }
    }
}