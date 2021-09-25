using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NorthWindProject.Core.Entities;

namespace NorthWindProject.Application.Common.Access
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
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