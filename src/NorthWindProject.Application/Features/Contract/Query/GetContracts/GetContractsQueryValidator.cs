using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Common.Extensions;

namespace NorthWindProject.Application.Features.Contract.Query.GetContracts
{
    public class GetContractsQueryValidator : AbstractValidator<GetContractsQuery>
    {
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public GetContractsQueryValidator(AppDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;

            RuleFor(_ => currentUserService.UserId)
                .MustAsync(IsCurrentUserAdmin);
        }

        private async Task<bool> IsCurrentUserAdmin(int userId, CancellationToken cancellationToken)
            => await _context.IsCurrentUserAdmin(_currentUserService.UserId, cancellationToken);
    }
}