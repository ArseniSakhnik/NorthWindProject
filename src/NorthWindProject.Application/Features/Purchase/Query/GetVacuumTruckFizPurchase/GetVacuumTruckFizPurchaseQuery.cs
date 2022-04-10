using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.Access;

namespace NorthWindProject.Application.Features.Purchase.Query.GetVacuumTruckFizPurchase
{
    public class GetVacuumTruckFizPurchaseQuery : IRequest<VacuumTruckFizPurchaseDto>
    {
        public int PurchaseId { get; set; }
    }

    public class
        GetVacuumTruckFizPurchaseQueryHandler : IRequestHandler<GetVacuumTruckFizPurchaseQuery,
            VacuumTruckFizPurchaseDto>
    {
        private readonly AppDbContext _context;
        private readonly IEncryptionService _encryptionService;

        public GetVacuumTruckFizPurchaseQueryHandler(AppDbContext context, IEncryptionService encryptionService)
        {
            _context = context;
            _encryptionService = encryptionService;
        }

        public async Task<VacuumTruckFizPurchaseDto> Handle(GetVacuumTruckFizPurchaseQuery request,
            CancellationToken cancellationToken)
        {
            var purchase = await _context.FizVacuumTruckPurchases
                .Where(purchase => purchase.Id == request.PurchaseId)
                .SingleOrDefaultAsync(cancellationToken);

            purchase.EncryptObject(_encryptionService);

            return new VacuumTruckFizPurchaseDto
            {
                PassportSerialNumber = purchase.PassportSerialNumber,
                PassportId = purchase.PassportId,
                PassportIssued = purchase.PassportIssued,
                PassportIssueDate = purchase.PassportIssueDate,
                DivisionCode = purchase.DivisionCode,
                RegistrationAddress = purchase.RegistrationAddress,
                TerritoryAddress = purchase.TerritoryAddress,
                Price = purchase.Price
            };
        }
    }
}