using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Common.Extensions;

namespace NorthWindProject.Application.Features.Contract.Query.GetUserContracts
{
    public class GetUserContractsQuery : IRequest<IList<ContractDto>>
    {
    }

    public class GetUserContractsQueryHandler : IRequestHandler<GetUserContractsQuery, IList<ContractDto>>
    {
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public GetUserContractsQueryHandler(AppDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<IList<ContractDto>> Handle(GetUserContractsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Contracts.AsQueryable();

            return await query
                .Where(contract => contract.UserId == _currentUserService.UserId)
                .Select(contract => new ContractDto
                {
                    Id = contract.Id,
                    ServiceName = contract.Service.ServiceView.Title,
                    PlaceName = contract.PlaceName
                })
                .ToListAsync(cancellationToken);
        }
    }
}