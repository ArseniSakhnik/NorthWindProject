namespace NorthWindProject.Application.Entities.Service
{
    public class PermissibleValue
    {
        public int ServicePropId { get; set; }
        public ServiceProp ServiceProp { get; set; }
        public int PermissibleValueId { get; set; }
        public string Value { get; set; }
    }
}