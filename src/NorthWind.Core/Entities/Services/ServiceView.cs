using NorthWind.Core.Enums;

namespace NorthWind.Core.Entities.Services
{
    public class ServiceView
    {
        public ServiceViewEnum Id { get; set; }
        public int ServiceViewSettingsId { get; set; }
        public ServiceViewSettings ServiceViewSettings { get; set; }
    }
}