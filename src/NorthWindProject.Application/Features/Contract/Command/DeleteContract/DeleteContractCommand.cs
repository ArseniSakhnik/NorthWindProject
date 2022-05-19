using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWindProject.Application.Common.Access;

namespace NorthWindProject.Application.Features.Contract.Command.DeleteContract
{
    public class DeleteContractCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteContractCommandHandler : IRequestHandler<DeleteContractCommand>
    {
        private readonly AppDbContext _context;

        public DeleteContractCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteContractCommand request, CancellationToken cancellationToken)
        {
            var contract = await _context.Contracts
                .Where(contract => contract.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            _context.Contracts.Remove(contract);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}