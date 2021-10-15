namespace NorthWindProject.Application.Entities.Service
{
    public class ServiceView
    {
        public int ServiceViewId { get; set; }
        
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}