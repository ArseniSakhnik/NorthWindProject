using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using NorthWindProject.Application.Entities.User;

namespace NorthWindProject.Application.Entities.Services.BaseService
{
    [NotMapped]
    public abstract class BasePurchase
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
    }
}