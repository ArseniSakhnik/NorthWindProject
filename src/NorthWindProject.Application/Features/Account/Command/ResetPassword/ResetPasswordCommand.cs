using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NorthWind.Core.Entities.User;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Common.Interfaces.DomainEvents;
using NorthWindProject.Application.Common.Models;

namespace NorthWindProject.Application.Features.Account.Command.ResetPassword
{
    public class ResetPasswordCommand : IRequest
    {
        public string Email { get; set; }
    }

    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _context;
        private readonly IEmailSenderService _emailSenderService;

        public ResetPasswordCommandHandler(UserManager<ApplicationUser> userManager, AppDbContext context,
            IEmailSenderService emailSenderService)
        {
            _userManager = userManager;
            _context = context;
            _emailSenderService = emailSenderService;
        }

        public async Task<Unit> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .Where(user => user.Email.ToLower().Trim() == request.Email.ToLower().Trim())
                .SingleOrDefaultAsync(cancellationToken);

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var newPassword = CreatePassword();

            await _userManager.ResetPasswordAsync(user, code, newPassword);

            _emailSenderService.SendEmailAsync(new EmailBodyModel
            {
                ToEmail = user.Email,
                Username = "Здравствуйте!",
                Subject = "Изменение пароля",
                HtmlBody =
                    $"<div>Ваш пароль: {newPassword}</div>"
            });
            
            return Unit.Value;
        }

        private static string CreatePassword()
        {
            var rnd = new Random();

            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            var res = new StringBuilder();

            var length = rnd.Next(7, 10);

            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }

            return res.ToString();
        }
    }
}