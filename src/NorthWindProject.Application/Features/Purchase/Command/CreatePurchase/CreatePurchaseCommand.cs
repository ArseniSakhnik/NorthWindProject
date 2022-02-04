using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWind.API.Models;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Features.Account.Command.AuthomaticCreateAccount;
using NorthWindProject.Application.Features.ExportDocument.Query;
using NorthWindProject.Application.Features.Purchase.Command.BaseCreatePurchase;
using NorthWindProject.Application.Features.Purchase.Events.SendConfirmPurchaseEmailEvent;

namespace NorthWindProject.Application.Features.Purchase.Command.CreatePurchase
{
    public class CreatePurchaseCommand<TData> : IRequest<PurchaseCreateResponseDto>
        where TData : BaseCreatePurchaseCommand
    {
        public TData Data { get; set; }
        public Func<TData, CancellationToken, Task<Entities.Purchase.Purchase>> CreatePurchase { get; set; }
        public string ServiceName { get; set; }
    }

    public class
        CreatePurchaseCommandHandle<TData> : IRequestHandler<CreatePurchaseCommand<TData>, PurchaseCreateResponseDto>
        where TData : BaseCreatePurchaseCommand
    {
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;

        public CreatePurchaseCommandHandle(AppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<PurchaseCreateResponseDto> Handle(CreatePurchaseCommand<TData> request,
            CancellationToken cancellationToken)
        {
            var userByEmailQuery = _context.Users
                .Include(user => user.Purchases)
                .Where(user => user.Email == request.Data.Email)
                .AsQueryable();

            var userByEmail = await userByEmailQuery
                .SingleOrDefaultAsync(cancellationToken);

            var purchase = await request.CreatePurchase(request.Data, cancellationToken);
            var response = new PurchaseCreateResponseDto();

            if (userByEmail is null)
            {
                var fileToConfirm =
                    await _mediator.Send(new ExportPurchaseQuery(request.ServiceName, purchase), cancellationToken);

                await _mediator.Send(new AutomaticCreateAccountCommand
                {
                    Email = request.Data.Email,
                    PhoneNumber = request.Data.PhoneNumber,
                    FilesToConfirm = new List<FileModel> {fileToConfirm}
                }, cancellationToken);

                userByEmail = await userByEmailQuery.SingleOrDefaultAsync(cancellationToken);

                response.Message +=
                    $"Аккаунт был создан. Пожалуйста, подтвердите аккаунт по вашему адресу ${request.Data.Email}\n";
            }
            else
            {
                purchase.DomainEvents.Add(new SendConfirmPurchaseEmailEvent
                {
                    Email = userByEmail.Email,
                    PurchaseId = purchase.Id
                });
                
                response.Message += "Подтвердите ваши заявки на электронной почте.";
            }
            
            userByEmail.Purchases.Add(purchase);
            await _context.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}