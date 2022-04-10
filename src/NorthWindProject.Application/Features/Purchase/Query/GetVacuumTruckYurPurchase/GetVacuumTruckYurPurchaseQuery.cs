using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.Access;

namespace NorthWindProject.Application.Features.Purchase.Query.GetVacuumTruckYurPurchase
{
    public class GetVacuumTruckYurPurchaseQuery : IRequest<VacuumTruckYurPurchaseDto>
    {
        public int PurchaseId { get; set; }
    }

    public class
        GetVacuumTruckYurPurchaseQueryHandler : IRequestHandler<GetVacuumTruckYurPurchaseQuery,
            VacuumTruckYurPurchaseDto>
    {
        private readonly AppDbContext _context;
        private readonly IEncryptionService _encryptionService;

        public GetVacuumTruckYurPurchaseQueryHandler(AppDbContext context, IEncryptionService encryptionService)
        {
            _context = context;
            _encryptionService = encryptionService;
        }

        public async Task<VacuumTruckYurPurchaseDto> Handle(GetVacuumTruckYurPurchaseQuery request,
            CancellationToken cancellationToken)
        {
            var purchase = await _context.YurVacuumTruckPurchases
                .SingleOrDefaultAsync(purchase => purchase.Id == request.PurchaseId, cancellationToken);

            purchase.DecryptObject(_encryptionService);

            return new VacuumTruckYurPurchaseDto
            {
                ClientShortName = purchase.ClientShortName,
                PersonalNameEntrepreneur = purchase.PersonalNameEntrepreneur,
                ActsOnBasis = purchase.ActsOnBasis,
                TerritoryAddress = purchase.TerritoryAddress,
                Price = purchase.Price,
                OGRN = purchase.OGRN,
                INN = purchase.INN,
                KPP = purchase.KPP,
                LegalAddress = purchase.LegalAddress,
                PhoneNumber = purchase.PhoneNumber,
            };
        }
    }
}