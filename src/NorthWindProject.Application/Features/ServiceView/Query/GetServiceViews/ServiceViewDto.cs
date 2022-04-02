using NorthWind.Core.Enums;

namespace NorthWindProject.Application.Features.ServiceView.Query.GetServiceViews
{
    public class ServiceViewDto
    {
        public ServiceViewEnum Id { get; set; }
        public string Title { get; set; }
        public string FizServiceRoute { get; set; }
        public string YurServiceRoute { get; set; }

        public string MainImageName { get; set; }
    }
}