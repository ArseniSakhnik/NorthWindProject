using System.Collections.Generic;

namespace NorthWindProject.Application.Entities.Service
{
    public class DocumentService
    {
        public int Id { get; set; }
        
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        
        public List<FieldService> FieldServices { get; set; }

        public bool IsForLegalEntity { get; set; } = false;
        public string Name { get; set; }
        public byte[] Content { get; set; }
    }
}