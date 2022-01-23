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

            RuleFor(command => new {Password = command.Password, ConfirmPassword = command.ConfirmPassword})
                .Must(passwords => passwords.Password == passwords.ConfirmPassword)
                .WithMessage("Проверьте правильно пароля и подтверждения пароля");
        }
    }
}