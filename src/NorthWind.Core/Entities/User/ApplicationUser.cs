using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using NorthWind.Core.Entities.Purchases.BasePurchase;

namespace NorthWind.Core.Entities.User
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public List<Purchase> Purchases { get; set; } = new();

        public ApplicationUser GetUser()
        {
            return this;
        }
        

        public string FullName
        {
            get => $"{Surname} {Name} {MiddleName}";
        }

        public string FullNameShort
        {
            get => $"{Surname} {Name[..1]} {MiddleName[..1]}";
        }
    }
}