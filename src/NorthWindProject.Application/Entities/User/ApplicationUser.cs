using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace NorthWindProject.Application.Entities.User
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public List<Purchase.Purchase> Purchases { get; set; }
    }
}