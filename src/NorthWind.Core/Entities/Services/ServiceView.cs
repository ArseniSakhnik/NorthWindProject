using NorthWind.Core.Enums;

namespace NorthWind.Core.Entities.Services
{
    public class ServiceView
    {
        public ServiceEnum ServiceId { get; set; }
        public Service Service { get; set; }
        public string Title { get; set; }
        public string MainImageName { get; set; }
    }
}