using FluentValidation;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.ShareValidators;
using NorthWindProject.Application.Features.Contract.Command.BaseContractValidator;

namespace NorthWindProject.Application.Features.Contract.Command.CreateVacuumTruckYurContract
{
    public class
        CreateVacuumTruckYurContractCommandValidator : AbstractValidator<CreateVacuumTruckYurContractCommand>
    {
        public CreateVacuumTruckYurContractCommandValidator(ICurrentUserService currentUserService)
        {
            RuleFor(command => command)
                .SetValidator(new BaseCreateYurContractCommandValidator(currentUserService));
        }
    }
}