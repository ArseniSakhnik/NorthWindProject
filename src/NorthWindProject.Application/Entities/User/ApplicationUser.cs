using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using NorthWindProject.Application.Entities.Services.BaseService;

namespace NorthWindProject.Application.Entities.User
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public List<BasePurchase> Purchases { get; set; } = new();
    }
}