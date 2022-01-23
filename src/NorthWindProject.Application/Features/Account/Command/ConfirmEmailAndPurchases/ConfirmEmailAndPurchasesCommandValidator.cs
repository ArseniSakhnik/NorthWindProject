using FluentValidation;

namespace NorthWindProject.Application.Features.Account.Command.ConfirmEmailAndPurchases
{
    public class ConfirmEmailAndPurchasesCommandValidator : AbstractValidator<ConfirmEmailAndPurchasesCommand>
    {
        public ConfirmEmailAndPurchasesCommandValidator()
        {
            RuleFor(command => command)
                .Must(command => command.UserId != null && command.Code != null)
                .WithMessage("Произошла ошибка");
        }
    }
}