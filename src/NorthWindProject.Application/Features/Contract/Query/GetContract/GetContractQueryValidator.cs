using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NorthWind.Core.Enums;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Common.Extensions;

namespace NorthWindProject.Application.Features.Contract.Query.GetContract
{
    public class GetContractQueryValidator : AbstractValidator<GetContractQuery>
    {
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public GetContractQueryValidator(AppDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;

            RuleFor(query => query.ContractId)
                .MustAsync(IsCurrentUserContractOwner)
                .WithMessage("Вы не имеете доступа к этому договору");
        }

        private async Task<bool> IsCurrentUserContractOwner(int contractId, CancellationToken cancellationToken)
        {
            var isCurrentUserAdmin = await _context.IsCurrentUserAdmin(_currentUserService.UserId, cancellationToken);

            if (isCurrentUserAdmin) return true;

            return await _context.Contracts
                .AnyAsync(contract
                    => contract.Id == contractId
                       &&
                       contract.UserId == _currentUserService.UserId, cancellationToken);
        }
    }
}