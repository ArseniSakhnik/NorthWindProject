using FluentValidation;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.ShareValidators;
using NorthWindProject.Application.Features.Contract.Command.BaseContractValidator;

namespace NorthWindProject.Application.Features.Contract.Command.CreateKgoYurContract
{
    public class CreateKgoYurContractCommandValidator : AbstractValidator<KgoYurContractCommand>
    {
        public CreateKgoYurContractCommandValidator(ICurrentUserService currentUserService)
        {
            RuleFor(command => command.Overload)
                .SetValidator(new StringValidator());

            RuleFor(command => command.Volume)
                .SetValidator(new StringValidator());

            RuleFor(command => command)
                .SetValidator(new BaseCreateYurContractCommandValidator(currentUserService));
        }
    }
}