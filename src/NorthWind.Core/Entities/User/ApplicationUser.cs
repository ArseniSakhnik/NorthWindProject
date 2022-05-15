using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using NorthWind.Core.Entities.Contracts.BaseContract;

namespace NorthWind.Core.Entities.User
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public List<Contract> Contracts { get; set; } = new();

        public List<Purchase.Purchase> Purchases { get; set; } = new();

        public string FullName => $"{Surname} {Name} {MiddleName}";

        public string FullNameShort => $"{Surname} {Name[..1]} {MiddleName[..1]}";

        public ApplicationUser GetUser()
        {
            return this;
        }
    }
}