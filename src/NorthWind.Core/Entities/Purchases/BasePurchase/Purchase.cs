using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using NorthWind.Core.Attributes;
using NorthWind.Core.Entities.Common;
using NorthWind.Core.Entities.Services;
using NorthWind.Core.Entities.Services.BaseService;
using NorthWind.Core.Entities.Services.DocumentService;
using NorthWind.Core.Entities.User;
using NorthWind.Core.Enums;
using NorthWind.Core.Interfaces;

namespace NorthWind.Core.Entities.Purchases.BasePurchase
{
    [NotMapped]
    public abstract class Purchase : AuditableEntity, IHasDomainEvent
    {
        public int Id { get; set; }

        [DocumentProp("день")] public string Day { get; set; }

        [DocumentProp("месяц")] public string Month { get; set; }

        [DocumentProp("год")] public string Year { get; set; }

        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        public ServicesEnum ServiceId { get; set; }
        public Service Service { get; set; }

        public int DocumentServiceId { get; set; }
        public DocumentService DocumentService { get; set; }
        
        [NotMapped] public List<DomainEvent> DomainEvents { get; set; } = new();

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

        public static List<DocumentField> GetDocumentFields<T>()
        {
            return typeof(T)
                .GetProperties()
                .Where(propInfo => Attribute.IsDefined(propInfo, typeof(DocumentProp)))
                .Select(propInfo => new
                {
                    PropertyName = propInfo.Name, propInfo.GetCustomAttributes<DocumentProp>().First().BookMarkName
                })
                .Select(bookMarkInfo => new DocumentField(bookMarkInfo.PropertyName, bookMarkInfo.BookMarkName))
                .ToList();
        }
    }
}