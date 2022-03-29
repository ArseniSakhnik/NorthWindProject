using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using Microsoft.VisualBasic.CompilerServices;
using NorthWindProject.Application.Common.Attributes;
using NorthWindProject.Application.Entities.Services;
using NorthWindProject.Application.Entities.Services.BaseService;
using NorthWindProject.Application.Entities.Services.DocumentService;
using NorthWindProject.Application.Entities.User;
using NorthWindProject.Application.Enums;
using NorthWindProject.Application.Features.Purchase.Services.PurchaseService;
using NorthWindProject.Application.Interfaces.DomainEvents;

namespace NorthWindProject.Application.Entities.Purchases.BasePurchase
{
    [NotMapped]
    public abstract class Purchase : IHasDomainEvent
    {
        public int Id { get; set; }

        [DocumentProp("День")]
        public string Day { get; set; }

        [DocumentProp("Месяц")]
        public string Month { get; set; }

        [DocumentProp("Год")]
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

        public static List<DocumentField> GetDocumentFields<T>()
        {
            return typeof(T)
                .GetProperties()
                .Where(propInfo => Attribute.IsDefined(propInfo, typeof(DocumentProp)))
                .Select(propInfo => new
                {
                    PropertyName = propInfo.Name,
                    BookMarkName = propInfo.GetCustomAttributes<DocumentProp>().First().BookMarkName
                })
                .Select(bookMarkInfo => new DocumentField(bookMarkInfo.PropertyName, bookMarkInfo.BookMarkName))
                .ToList();
        }

        [NotMapped] public List<DomainEvent> DomainEvents { get; set; } = new();
    }
}