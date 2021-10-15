using System.Collections.Generic;

namespace NorthWindProject.Application.Entities.Service
{
    public class Service
    {
        public int ServiceId { get; set; }

        public int ServiceViewId { get; set; }
        public ServiceView ServiceView { get; set; }
        
        public List<ServiceProp> ServiceProps = new();
    }
}