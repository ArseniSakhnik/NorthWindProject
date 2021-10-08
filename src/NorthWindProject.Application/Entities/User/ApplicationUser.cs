using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace NorthWindProject.Application.Entities.User
{
    public class ApplicationUser : IdentityUser<int>
    {
        public List<Purchase.Purchase> Purchases { get; set; } = new List<Purchase.Purchase>();
    }
}