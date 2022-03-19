using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NorthWindProject.Application.Common.Access;

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
        }

        private async Task<bool> IsEmailUnique(string email, CancellationToken cancellationToken)
        {
            return !await _context.Users
                .AnyAsync(user => user.Email == email, cancellationToken);
        }
    }
}