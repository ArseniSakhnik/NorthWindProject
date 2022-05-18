using System.Collections.Generic;
using NorthWind.Core.Entities.Contracts.BaseContract;
using NorthWind.Core.Enums;

namespace NorthWind.Core.Entities.Services
{
    public class Service
    {
        public ServiceEnum Id { get; set; }
        public List<Contract> Contracts { get; set; } = new();
        public ServiceEnum ServiceViewId { get; set; }
        public ServiceView ServiceView { get; set; }
        public List<DocumentService.DocumentService> DocumentServices { get; set; } = new();
    }
}