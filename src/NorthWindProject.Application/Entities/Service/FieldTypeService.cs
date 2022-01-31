using NorthWindProject.Application.Enums;
using NorthWindProject.Application.Enums.VacuumTruckServiceEnums;

namespace NorthWindProject.Application.Entities.Service
{
    public class FieldTypeService
    {
        public VacuumTruckServiceFieldsTypeEnum Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}