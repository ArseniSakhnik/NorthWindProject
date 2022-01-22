using NorthWindProject.Application.Enums;

namespace NorthWindProject.Application.Entities.Service
{
    public class FieldService
    {
        public int Id { get; set; }
        
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        
        public int FieldTypeId { get; set; }
        public FieldTypeService FieldType { get; set; }
        
        public string BookMarkName { get; set; }
        public string Value { get; set; }
    }
}