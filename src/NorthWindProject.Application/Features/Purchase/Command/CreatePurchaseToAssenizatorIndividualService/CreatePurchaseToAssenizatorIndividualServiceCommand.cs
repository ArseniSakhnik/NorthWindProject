using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Interfaces;

namespace NorthWindProject.Application.Features.Purchase.Command.CreatePurchaseToAssenizatorIndividualService
{
    public class CreatePurchaseToAssenizatorIndividualServiceCommand : IRequest
    {
    }

    public class
        CreatePurchaseToAssenizatorIndividualServiceCommandHandler 
        : IRequestHandler<CreatePurchaseToAssenizatorIndividualServiceCommand>
    {
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public CreatePurchaseToAssenizatorIndividualServiceCommandHandler(AppDbContext context,
            ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public Task<Unit> Handle(CreatePurchaseToAssenizatorIndividualServiceCommand request,
            CancellationToken cancellationToken)
        {
            return null;
        }
    }
}