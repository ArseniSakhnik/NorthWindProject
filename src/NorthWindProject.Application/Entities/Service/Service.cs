using NorthWindProject.Application.Entities.DocumentTemplate;

namespace NorthWindProject.Application.Entities.Service
{
    public class Service
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int DocumentId { get; set; }
        public Document Document { get; set; }
        
        // public int ServiceViewId { get; set; }
        // public ServiceView ServiceView { get; set; }
    }
}