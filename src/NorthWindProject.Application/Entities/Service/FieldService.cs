using NorthWindProject.Application.Enums;

namespace NorthWindProject.Application.Entities.Service
{
    public class FieldService
    {
        public int Id { get; set; }

        public int DocumentServiceId { get; set; }
        public DocumentService DocumentService { get; set; }

        public FieldServiceTypeEnum FieldTypeId { get; set; }
        public FieldTypeService FieldType { get; set; }
        
        public string BookMarkName { get; set; }
        
        public int FillingNumber { get; set; }
        public bool IsRequired { get; set; } = false;
        
        public int? FieldServiceLinkId { get; set; }
        public FieldService FieldServiceLink { get; set; }
    }
}