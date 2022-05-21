using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWindProject.Application.Common.Access;

namespace NorthWindProject.Application.Features.Contract.Command.ConfirmContract
{
    public class ConfirmContractCommand : IRequest
    {
        public int ContractId { get; set; }
        public bool IsConfirmed { get; set; }
    }

    public class ConfirmContractCommandHandler : IRequestHandler<ConfirmContractCommand>
    {
        private readonly AppDbContext _context;

        public ConfirmContractCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(ConfirmContractCommand request, CancellationToken cancellationToken)
        {
            var contract = await _context.Contracts
                .Where(contract => contract.Id == request.ContractId)
                .SingleOrDefaultAsync(cancellationToken);

            contract.IsConfirmed = request.IsConfirmed;

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}