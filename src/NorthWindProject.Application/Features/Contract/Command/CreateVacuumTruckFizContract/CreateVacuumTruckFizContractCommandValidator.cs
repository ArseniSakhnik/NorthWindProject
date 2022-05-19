using FluentValidation;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Features.Contract.Command.BaseContractValidator;

namespace NorthWindProject.Application.Features.Contract.Command.CreateVacuumTruckFizContract
{
    public class CreateVacuumTruckFizContractCommandValidator
        : AbstractValidator<CreateVacuumTruckFizContractCommand>
    {
        public CreateVacuumTruckFizContractCommandValidator(ICurrentUserService currentUserService)
        {
            RuleFor(command => command)
                .SetValidator(new BaseCreateFizContractCommandValidator(currentUserService));
        }
    }
}