using System.Collections.Generic;

namespace NorthWindProject.Application.Entities.Service
{
    public class Service
    {
        public int Id { get; set; }
        
        public List<FieldService> FieldServices { get; set; }
        public List<DocumentService> DocumentServices { get; set; }
    }
}