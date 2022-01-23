using FluentValidation;

namespace NorthWindProject.Application.Features.Account.Command.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(command => command.Email)
                .NotEmpty()
                .WithMessage("Введите email")
                .EmailAddress()
                .WithMessage("Введите корректный email");
        }
    }
}