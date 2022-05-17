using System.Collections.Generic;
using NorthWind.Core.Entities.Contracts.BaseContract;
using NorthWind.Core.Enums;

namespace NorthWind.Core.Entities.Services
{
    public class Service
    {
        public ServicesEnum Id { get; set; }
        public List<Contract> Contracts { get; set; }

        public ServiceViewEnum ServiceViewId { get; set; }
        public ServiceView ServiceView { get; set; }
        public List<DocumentService.DocumentService> DocumentServices { get; set; }
    }
}