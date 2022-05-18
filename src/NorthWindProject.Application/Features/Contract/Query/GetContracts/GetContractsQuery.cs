using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWindProject.Application.Common.Access;

namespace NorthWindProject.Application.Features.Contract.Query.GetContracts
{
    public class GetContractsQuery : IRequest<IQueryable<ContractDto>>
    {
    }

    public class GetContractsQueryHandler : IRequestHandler<GetContractsQuery, IQueryable<ContractDto>>
    {
        private readonly AppDbContext _context;

        public GetContractsQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        //а как вообще заявка то создается
        public Task<IQueryable<ContractDto>> Handle(GetContractsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_context.Contracts
                .Select(contract => new ContractDto
                {
                    Id = contract.Id,
                    PhoneNumber = contract.User.PhoneNumber,
                    Email = contract.User.Email,
                    Created = contract.Created,
                    ClientFullName = contract.User.FullName,
                }));
        }
    }
}