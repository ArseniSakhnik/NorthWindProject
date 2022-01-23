using NorthWindProject.Application.Enums;
using NorthWindProject.Application.Enums.AssenizatorServiceEnums;

namespace NorthWindProject.Application.Entities.Service
{
    public class FieldTypeService
    {
        public AssenizatorServiceFieldsTypeEnum Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}