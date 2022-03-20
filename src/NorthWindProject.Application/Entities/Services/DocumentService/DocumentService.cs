using System.Collections.Generic;
using NorthWindProject.Application.Entities.Services.BaseService;

namespace NorthWindProject.Application.Entities.Services.DocumentService
{
    public class DocumentService
    {
        public int Id { get; set; }
        
        public int ServiceId { get; set; }
        public BaseService.BaseService Service { get; set; }
        
        public byte[] Content { get; set; }
        public List<DocumentField> DocumentFields { get; set; }
    }
}