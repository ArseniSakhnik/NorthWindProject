using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using Microsoft.VisualBasic.CompilerServices;
using NorthWindProject.Application.Entities.Services;
using NorthWindProject.Application.Entities.Services.DocumentService;
using NorthWindProject.Application.Entities.User;
using NorthWindProject.Application.Enums;
using NorthWindProject.Application.Interfaces.DomainEvents;

namespace NorthWindProject.Application.Entities.Purchases.BasePurchase
{
    [NotMapped]
    public abstract class Purchase : IHasDomainEvent
    {
        public int Id { get; set; }
        
        //(День)
        public string Day { get; set; }

        //(Месяц)
        public string Month { get; set; }

        //(Год)
        public string Year { get; set; }

        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        public ServicesEnum ServiceId { get; set; }
        public Service Service { get; set; }

        public int DocumentServiceId { get; set; }
        public DocumentService DocumentService { get; set; }

        public IDictionary<string, string> GetNameAndValuesDictionary
        {
            get
            {
                var type = GetType();
                return type
                    .GetProperties()
                    .Where(prop => prop.PropertyType == string.Empty.GetType())
                    .ToDictionary(prop => prop.Name.ToLower(),
                        prop => prop.GetValue(this, null) is null
                            ? ""
                            : prop.GetValue(this, null)?.ToString());
            }
        }

        [NotMapped] public List<DomainEvent> DomainEvents { get; set; } = new();
    }
}