using System.Collections.Generic;

namespace NorthWindProject.Application.Entities.Service
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<DocumentService> DocumentServices { get; set; }
    }
}