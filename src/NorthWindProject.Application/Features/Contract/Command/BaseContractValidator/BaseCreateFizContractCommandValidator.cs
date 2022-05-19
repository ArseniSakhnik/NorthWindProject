using FluentValidation;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.ShareValidators;
using NorthWindProject.Application.Features.Contract.Command.BaseCreateContract;

namespace NorthWindProject.Application.Features.Contract.Command.BaseContractValidator
{
    public class BaseCreateFizContractCommandValidator : AbstractValidator<BaseCreateFizContractCommand>
    {
        public BaseCreateFizContractCommandValidator(ICurrentUserService currentUserService)
        {
            RuleFor(command => command.IndividualFullName)
                .SetValidator(new StringValidator());

            RuleFor(command => command)
                .SetValidator(new BaseCreateContractCommandValidator(currentUserService));
        }
    }
}