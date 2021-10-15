namespace NorthWindProject.Application.Entities.Service
{
    public class ServiceProp
    {
        public int ServicePropId { get; set; }
        
        public Service Service { get; set; }
        public int ServiceId { get; set; }
        
        public ServicePropTypeEnum ServiceType { get; set; } 
        public string Value { get; set; }
    }
}