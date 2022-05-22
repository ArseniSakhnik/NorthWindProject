using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Common.ShareValidators;

namespace NorthWindProject.Application.Features.Account.Command.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        private readonly AppDbContext _context;

        public RegisterCommandValidator(AppDbContext context)
        {
            _context = context;

            RuleFor(command => command.Email)
                .NotEmpty()
                .WithMessage("Введите email")
                .EmailAddress()
                .WithMessage("Введите валидный email")
                .MustAsync(IsEmailUnique)
                .WithMessage("Пользователь с таким Email уже зарегестрирован");

            RuleFor(command => command.Name)
                .SetValidator(new StringValidator());

            RuleFor(command => command.Surname)
                .SetValidator(new StringValidator());

            RuleFor(command => command.MiddleName)
                .SetValidator(new StringValidator());

            RuleFor(command => command.Email)
                .SetValidator(new StringValidator());

            RuleFor(command => command.PhoneNumber)
                .SetValidator(new StringValidator());
        }

        private async Task<bool> IsEmailUnique(string email, CancellationToken cancellationToken)
        {
            return !await _context.Users
                .AnyAsync(user => user.Email == email, cancellationToken);
        }
    }
}