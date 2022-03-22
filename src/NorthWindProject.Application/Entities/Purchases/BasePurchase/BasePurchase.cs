using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using NorthWindProject.Application.Entities.Services;
using NorthWindProject.Application.Entities.User;
using NorthWindProject.Application.Interfaces.DomainEvents;

namespace NorthWindProject.Application.Entities.Purchases.BasePurchase
{
    [NotMapped]
    public abstract class BasePurchase : IHasDomainEvent
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public IDictionary<string, string> GetNameAndValuesDictionary
        {
            get => GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .ToDictionary(prop => prop.Name,
                    prop => prop.GetValue(this, null) is null
                        ? ""
                        : prop.GetValue(this, null)?.ToString());
        }

        public List<DomainEvent> DomainEvents { get; set; } = new();
    }
}