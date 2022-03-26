using NorthWindProject.Application.Enums;

namespace NorthWindProject.Application.Entities.Services
{
    public class ServiceViewSettings
    {
        public int Id { get; set; }
        
        public ServiceViewEnum ServiceViewId { get; set; }
        public ServiceView ServiceView { get; set; }
        
        public string Title { get; set; }
        public string MainImageName { get; set; }
    }
}