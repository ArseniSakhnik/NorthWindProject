using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using NorthWind.API.Models;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Common.Extensions;
using NorthWindProject.Application.Entities.User;
using NorthWindProject.Application.Interfaces.DomainEvents;

namespace NorthWindProject.Application.Features.Account.Command.AuthomaticCreateAccount
{
    public class AutomaticCreateAccountCommand : IRequest
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Entities.Purchase.Purchase Purchase { get; set; }
        public string ServiceName { get; set; }
    }

    public class AutomaticCreateAccountCommandHandler : IRequestHandler<AutomaticCreateAccountCommand>
    {
        private readonly AppDbContext _context;
        private readonly IEmailSenderService _emailSenderService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMediator _mediator;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AutomaticCreateAccountCommandHandler(
            UserManager<ApplicationUser> userManager,
            IEmailSenderService emailSenderService,
            SignInManager<ApplicationUser> signInManager,
            IHttpContextAccessor httpContextAccessor,
            AppDbContext context,
            IMediator mediator)
        {
            _userManager = userManager;
            _emailSenderService = emailSenderService;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(AutomaticCreateAccountCommand request, CancellationToken cancellationToken)
        {
            var password = StringExtensions.GetRandomString(7);

            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                var registerRequest = _httpContextAccessor.HttpContext.Request;
                var callbackUrl =
                    $"{StringExtensions.GetCallbackUrl(registerRequest)}/confirm-purchase?userId={user.Id}&code={code}";

                await _userManager.AddToRoleAsync(user, RolesEnum.Client.ToString());
                await _signInManager.SignInAsync(user, false);

                user.Purchases.Add(request.Purchase);
                await _context.SaveChangesAsync(cancellationToken);

                _emailSenderService.SendEmailAsync(new EmailBodyModel
                {
                    ToEmail = request.Email,
                    Username = "Здравствуйте!",
                    Subject = "Подтверждение аккаунта",
                    HtmlBody =
                        $"<div>Подтвердите заявки, перейдя по ссылке: <a href='{callbackUrl}'>Подтверждение регистрации</a></div>"
                });
            }

            return Unit.Value;
        }
    }
}