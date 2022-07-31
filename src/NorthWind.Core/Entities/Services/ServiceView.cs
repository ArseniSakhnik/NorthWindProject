using NorthWind.Core.Enums;

namespace NorthWind.Core.Entities.Services
{
    public class ServiceView
    {
        public ServiceEnum ServiceId { get; set; }
        public string Title { get; set; }
        public string MainImageName { get; set; }
    }
}