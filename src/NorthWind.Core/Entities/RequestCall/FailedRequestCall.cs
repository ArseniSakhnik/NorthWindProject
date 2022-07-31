using NorthWind.Core.Entities.Common;

namespace NorthWind.Core.Entities.RequestCall
{
    public class FailedRequestCall
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Comment { get; set; }
    }
}