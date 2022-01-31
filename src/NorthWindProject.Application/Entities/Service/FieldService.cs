using NorthWindProject.Application.Enums;
using NorthWindProject.Application.Enums.VacuumTruckServiceEnums;

namespace NorthWindProject.Application.Entities.Service
{
    public class FieldService
    {
        public int Id { get; set; }

        public VacuumTruckServiceFieldsTypeEnum FieldTypeId { get; set; }
        
        public int DocumentServiceId { get; set; }
        public DocumentService DocumentService { get; set; }
        
        public string BookMarkName { get; set; }
    }
}