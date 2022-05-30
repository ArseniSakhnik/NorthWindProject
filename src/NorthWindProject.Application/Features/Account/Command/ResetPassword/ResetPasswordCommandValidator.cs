using System.Data;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NorthWindProject.Application.Common.Access;

namespace NorthWindProject.Application.Features.Account.Command.ResetPassword
{
    public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
    {
        private readonly AppDbContext _context;

        public ResetPasswordCommandValidator(AppDbContext context)
        {
            _context = context;

            RuleFor(command => command.Email)
                .MustAsync(DoesUserExist)
                .WithMessage("Пользователь с таким email не существует");
        }

        private async Task<bool> DoesUserExist(string email, CancellationToken cancellationToken)
        {
            return await _context.Users
                .AnyAsync(user
                    => user.Email == email, cancellationToken);
        }
    }
}