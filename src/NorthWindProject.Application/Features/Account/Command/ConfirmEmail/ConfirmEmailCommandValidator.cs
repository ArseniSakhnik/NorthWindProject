using FluentValidation;

namespace NorthWindProject.Application.Features.Account.Command.ConfirmEmailAndPurchases
{
    public class ConfirmEmailCommandValidator : AbstractValidator<ConfirmEmailCommand>
    {
        public ConfirmEmailCommandValidator()
        {
            RuleFor(command => command)
                .Must(command => command.UserId != null && command.Code != null)
                .WithMessage("Произошла ошибка");
        }
    }
}