using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWindProject.Application.Common.Access;

namespace NorthWindProject.Application.Features.ServiceView.Query.GetServiceViews
{
    public class GetServiceViewsQuery : IRequest<IList<ServiceViewDto>>
    {
    }

    public class
        GetServiceViewsQueryHandler : IRequestHandler<GetServiceViewsQuery, IList<ServiceViewDto>>
    {
        private readonly AppDbContext _context;

        public GetServiceViewsQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IList<ServiceViewDto>> Handle(GetServiceViewsQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.ServiceViews
                .Select(view => new ServiceViewDto
                {
                    Id = view.ServiceId,
                    MainImageName = view.MainImageName,
                    Title = view.Title,
                })
                .ToListAsync(cancellationToken);
        }
    }
}