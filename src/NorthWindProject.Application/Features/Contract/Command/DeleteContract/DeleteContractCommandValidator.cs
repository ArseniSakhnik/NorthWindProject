using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.Access;

namespace NorthWindProject.Application.Features.Contract.Command.DeleteContract
{
    public class DeleteContractCommandValidator : AbstractValidator<DeleteContractCommand>
    {
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public DeleteContractCommandValidator(AppDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;

            RuleFor(command => command.Id)
                .MustAsync(IsCurrentUserContractOwner)
                .WithMessage("Вы не можете удалять данный договор");
        }

        private async Task<bool> IsCurrentUserContractOwner(int contractId, CancellationToken cancellationToken)
            => await _context.Contracts
                .AnyAsync(contract => contract.Id == contractId
                                      &&
                                      contract.UserId == _currentUserService.UserId,
                    cancellationToken);
    }
}