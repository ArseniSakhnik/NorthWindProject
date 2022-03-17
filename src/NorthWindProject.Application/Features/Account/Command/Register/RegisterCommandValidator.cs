using FluentValidation;

namespace NorthWindProject.Application.Features.Account.Command.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(command => command.Email)
                .NotEmpty()
                .WithMessage("Введите email")
                .EmailAddress()
                .WithMessage("Введите валидный email");
        }
    }
}