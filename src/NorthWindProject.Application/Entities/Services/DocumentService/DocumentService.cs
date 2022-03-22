using System.Collections.Generic;
using NorthWindProject.Application.Entities.Services.BaseService;
using NorthWindProject.Application.Enums;

namespace NorthWindProject.Application.Entities.Services.DocumentService
{
    public class DocumentService
    {
        public int Id { get; set; }
        
        public ServicesEnum ServiceId { get; set; }
        public Service Service { get; set; }
        
        public List<BasePurchase> Purchases { get; set; }
        public byte[] Content { get; set; }
        public List<DocumentField> DocumentFields { get; set; }
    }
}