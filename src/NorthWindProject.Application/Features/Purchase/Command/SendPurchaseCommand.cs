using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Common.Exceptions;
using NorthWindProject.Application.Entities.User;
using NorthWindProject.Application.Features.Account.Command.Register;
using NorthWindProject.Application.Interfaces;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace NorthWindProject.Application.Features.Purchase.Command
{
    public class SendPurchaseCommand : IRequest<string>
    {
        public int ServiceId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class SendPurchaseCommandHandler : IRequestHandler<SendPurchaseCommand, string>
    {
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMediator _mediator;

        public SendPurchaseCommandHandler(AppDbContext context,
            ICurrentUserService currentUserService, IMediator mediator)
        {
            _context = context;
            _currentUserService = currentUserService;
            _mediator = mediator;
        }

        public async Task<string> Handle(SendPurchaseCommand request, CancellationToken cancellationToken)
        {
            var applicationUser = await _context.Users
                .Where(user => user.Email == request.Email)
                .FirstOrDefaultAsync(cancellationToken);

            var succsessMessage = "";

            if (applicationUser is null)
            {
                var password = RandomString(5);
                var login = request.Email;


                var registerResult = await _mediator.Send(new RegisterCommand
                {
                    Username = request.Email,
                    Password = request.Password,
                    ConfirmPassword = request.Password
                });

                if (!registerResult.Succeeded)
                {
                    
                }
            }

            return succsessMessage;
        }


        private string RandomString(int length)
        {
            var random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}