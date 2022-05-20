using FluentValidation;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.ShareValidators;
using NorthWindProject.Application.Features.Contract.Command.BaseCreateContract;

namespace NorthWindProject.Application.Features.Contract.Command.BaseContractValidator
{
    public class BaseCreateYurContractCommandValidator : AbstractValidator<BaseYurContractCommand>
    {
        public BaseCreateYurContractCommandValidator(ICurrentUserService currentUserService)
        {
            RuleFor(command => command.INN)
                .SetValidator(new StringValidator());

            RuleFor(command => command.KPP)
                .SetValidator(new StringValidator());

            RuleFor(command => command.OGRN)
                .SetValidator(new StringValidator());

            RuleFor(command => command.OKPO)
                .SetValidator(new StringValidator());

            RuleFor(command => command.YurAddress)
                .SetValidator(new StringValidator());

            RuleFor(command => command.CustomerShortName)
                .SetValidator(new StringValidator());

            RuleFor(command => command.IEShortName)
                .SetValidator(new StringValidator());

            RuleFor(command => command.OperatesOnBasis)
                .SetValidator(new StringValidator());

            RuleFor(command => command)
                .SetValidator(new BaseCreateContractCommandValidator(currentUserService));
        }
    }
}