using FluentValidation;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Common.ShareValidators;
using NorthWindProject.Application.Features.Contract.Command.BaseCreateContract;

namespace NorthWindProject.Application.Features.Contract.Command.BaseContractValidator
{
    public class BaseCreateContractCommandValidator : AbstractValidator<BaseCreateContractCommand>
    {
        public BaseCreateContractCommandValidator(ICurrentUserService currentUserService)
        {

            RuleFor(_ => currentUserService.UserId)
                .Must(userId => userId != 0)
                .WithMessage("Для создания контракта необходимо аутентифицироваться");

            RuleFor(command => command.Email)
                .NotEmpty()
                .WithMessage("Введите Email")
                .EmailAddress()
                .WithMessage("Введите корректный Email");

            RuleFor(command => command.Email)
                .SetValidator(new StringValidator());

            RuleFor(command => command.PhoneNumber)
                .SetValidator(new StringValidator());

            RuleFor(command => command.PlaceName)
                .SetValidator(new StringValidator());
        }
    }
}