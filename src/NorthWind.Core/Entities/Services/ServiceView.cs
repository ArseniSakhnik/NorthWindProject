using NorthWind.Core.Enums;

namespace NorthWind.Core.Entities.Services
{
    public class ServiceView
    {
        public ServiceViewEnum Id { get; set; }

        public ServicesEnum? FizServiceId { get; set; }
        public Service FizService { get; set; }

        public ServicesEnum? YurServiceId { get; set; }
        public Service YurService { get; set; }

        public int ServiceViewSettingsId { get; set; }
        public ServiceViewSettings ServiceViewSettings { get; set; }
    }
}