using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWind.Core.Enums;
using NorthWindProject.Application.Common.Access;

namespace NorthWindProject.Application.Features.ServiceView.Query.GetServiceImage
{
    public class GetServiceImageQuery : IRequest<string>
    {
        public ServiceViewEnum ServiceViewId { get; set; }
    }

    public class GetServiceImageQueryHandler : IRequestHandler<GetServiceImageQuery, string>
    {
        private readonly AppDbContext _context;

        public GetServiceImageQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(GetServiceImageQuery request, CancellationToken cancellationToken)
        {
            return await _context.ServiceViewSettings
                .Where(settings => settings.ServiceViewId == request.ServiceViewId)
                .Select(settings => settings.MainImageName)
                .SingleOrDefaultAsync(cancellationToken);
        }
    }
}