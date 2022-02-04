using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWind.API.Models;
using NorthWindProject.Application.Common.Extensions;
using NorthWindProject.Application.Features.Account.Command.Register;

namespace NorthWindProject.Application.Features.Account.Command.AuthomaticCreateAccount
{
    public class AutomaticCreateAccountCommand : IRequest
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        
        public List<FileModel> FilesToConfirm { get; set; }
    }

    public class AutomaticCreateAccountCommandHandler : IRequestHandler<AutomaticCreateAccountCommand>
    {
        private readonly IMediator _mediator;

        public AutomaticCreateAccountCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Unit> Handle(AutomaticCreateAccountCommand request, CancellationToken cancellationToken)
        {
            var password = StringExtensions.GetRandomString(7);

            await _mediator.Send(new RegisterCommand
            {
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Password = password,
                ConfirmPassword = password,
                FilesToConfirm = request.FilesToConfirm
            }, cancellationToken);
            
            return Unit.Value;
        }
    }
}