using System.Collections.Generic;

namespace NorthWindProject.Application.Entities.Service
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int? ServiceViewId { get; set; }
        public ServiceView ServiceView { get; set; }
        
        public List<ServiceProp> ServiceProps { get; set; }

        public Service(string name, string description, List<ServiceProp> serviceProps)
        {
            Name = name;
            Description = description;
            ServiceProps = serviceProps;
        }

        public Service() {}
    }
}