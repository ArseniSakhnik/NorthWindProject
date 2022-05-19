using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWindProject.Application.Common.Access;

namespace NorthWindProject.Application.Features.Contract.Query.GetContracts
{
    public class GetContractsQuery : IRequest<IList<ContractDto>>
    {
    }

    public class GetContractsQueryHandler : IRequestHandler<GetContractsQuery, IList<ContractDto>>
    {
        private readonly AppDbContext _context;

        public GetContractsQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        //а как вообще заявка то создается
        public async Task<IList<ContractDto>> Handle(GetContractsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Contracts
                .Select(contract => new ContractDto
                {
                    Id = contract.Id,
                    PhoneNumber = contract.User.PhoneNumber,
                    Email = contract.User.Email,
                    Created = contract.Created,
                    ClientFullName = contract.User.FullName,
                })
                .ToListAsync(cancellationToken);
        }
    }
}