using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWind.Core.Enums;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Common.Extensions;

namespace NorthWindProject.Application.Features.Contract.Query.GetContracts
{
    public class GetContractsQuery : IRequest<ContractAndPageDto>
    {
        public int Page { get; set; }
        public string SearchName { get; set; }
        public ConfirmedType ConfirmedTypeId { get; set; }
    }

    public class GetContractsQueryHandler : IRequestHandler<GetContractsQuery, ContractAndPageDto>
    {
        private readonly AppDbContext _context;

        public GetContractsQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ContractAndPageDto> Handle(GetContractsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Contracts.AsNoTracking();

            if (request.SearchName != null && request.SearchName.Trim().Length > 0)
            {
                query = query
                    .Where(contract =>
                        contract.User.FullName.ToLower().Trim().Contains(request.SearchName.ToLower().Trim())
                        ||
                        contract.PlaceName.ToLower().Trim().Contains(request.SearchName.ToLower().Trim()));
            }

            var contracts = await query
                .Skip((request.Page - 1) * 10)
                .Take(10)
                .OrderByDescending(contract => contract.Created)
                .Select(contract => new ContractDto
                {
                    Id = contract.Id,
                    ServiceName = contract.GetServiceNameAndType(),
                    PlaceName = contract.PlaceName,
                    PhoneNumber = contract.PhoneNumber,
                    Email = contract.Email,
                    Created = contract.Created.ToIsoString(),
                    ClientFullName = contract.User.FullName,
                    IsConfirmed = contract.IsConfirmed
                })
                .ToListAsync(cancellationToken);

            var contractCount = await query.CountAsync(cancellationToken);

            return new ContractAndPageDto
            {
                Contracts = contracts,
                PageCount = (int) Math.Ceiling((decimal) contractCount / 10)
            };
        }
    }
}