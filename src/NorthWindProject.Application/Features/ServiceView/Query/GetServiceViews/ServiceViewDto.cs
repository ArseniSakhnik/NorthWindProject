using NorthWind.Core.Enums;

namespace NorthWindProject.Application.Features.ServiceView.Query.GetServiceViews
{
    public class ServiceViewDto
    {
        public ServiceEnum Id { get; set; }
        public string Title { get; set; }

        public string MainImageName { get; set; }
    }
}