using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Features.Account.Command.AuthomaticCreateAccount;
using NorthWindProject.Application.Features.Purchase.Command.BaseCreatePurchase;
using NorthWindProject.Application.Features.Purchase.Events.SendConfirmPurchaseEmailEvent;

namespace NorthWindProject.Application.Features.Purchase.Services.PurchaseService
{
    public interface IPurchaseService
    {
        Task<PurchaseCreateResponseDto> CreateService<TData>(
            string serviceName,
            TData data,
            Func<TData, CancellationToken, Task<Entities.Purchase.Purchase>> createPurchase,
            CancellationToken cancellationToken) where TData : BaseCreatePurchaseCommand;
    }

    public class PurchaseService : IPurchaseService
    {
        private readonly IMediator _mediator;
        private readonly AppDbContext _context;

        public PurchaseService(IMediator mediator, AppDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<PurchaseCreateResponseDto> CreateService<TData>(
            string serviceName,
            TData data,
            Func<TData, CancellationToken, Task<Entities.Purchase.Purchase>> createPurchase,
            CancellationToken cancellationToken) where TData : BaseCreatePurchaseCommand
        {
            var userByEmailQuery = _context.Users
                .Include(user => user.Purchases)
                .Where(user => user.Email == data.Email)
                .AsQueryable();

            var userByEmail = await userByEmailQuery
                .SingleOrDefaultAsync(cancellationToken);

            var purchase = await createPurchase(data, cancellationToken);
            var response = new PurchaseCreateResponseDto();

            if (userByEmail is null)
            {
                await _mediator.Send(new AutomaticCreateAccountCommand
                {
                    Email = data.Email,
                    PhoneNumber = data.PhoneNumber,
                    ServiceName = serviceName,
                    Purchase = purchase,
                    Name = data.Name,
                    Surname = data.Surname,
                    MiddleName = data.MiddleName
                }, cancellationToken);

                response.Message +=
                    $"Аккаунт был создан. Пожалуйста, подтвердите аккаунт по вашему адресу ${data.Email}\n";
            }
            else
            {
                purchase.DomainEvents.Add(new SendConfirmPurchaseEmailEvent(purchase)
                {
                    Email = userByEmail.Email,
                    ServiceName = serviceName
                });

                userByEmail.Purchases.Add(purchase);
                response.Message += "Подтвердите ваши заявки на электронной почте.";
            }

            await _context.SaveChangesAsync(cancellationToken);
            return response;
        }
    }
}