using System.Collections.Generic;
using NorthWindProject.Application.Entities.Service;

namespace NorthWindProject.Application.Features.Purchase.Queries
{
    public class PurchaseFieldsDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ServiceProp> ServiceProps { get; set; }

        public PurchaseFieldsDto(string name, string description, List<ServiceProp> serviceProps)
        {
            Name = name;
            Description = description;
            ServiceProps = serviceProps;
        }
    }
}