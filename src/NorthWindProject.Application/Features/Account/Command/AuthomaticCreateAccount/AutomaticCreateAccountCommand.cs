using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using NorthWind.API.Models;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Entities.User;
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
            var password = CreatePassword(7);

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

        private static string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            
            var res = new StringBuilder();
            var rnd = new Random();
            
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }

            return res.ToString();
        }
    }
}