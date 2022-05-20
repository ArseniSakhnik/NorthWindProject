using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Features.Contract.Command.BaseCreateContract;
using NorthWindProject.Application.Services.ContractService;

namespace NorthWindProject.Application.Features.Contract.Command.UpdateKgoYurContract
{
    public class UpdateKgoYurContractCommand: BaseYurContractCommand, IRequest
    {
        public int Id { get; set; }
        public string Volume { get; set; }
        public string Overload { get; set; }
    }
    
    public class UpdateKgoYurContractCommandHandler : IRequestHandler<UpdateKgoYurContractCommand>
    {
        private readonly AppDbContext _context;
        private readonly IContractService _contractService;

        public UpdateKgoYurContractCommandHandler(AppDbContext context, IContractService contractService)
        {
            _context = context;
            _contractService = contractService;
        }

        public async Task<Unit> Handle(UpdateKgoYurContractCommand request, CancellationToken cancellationToken)
        {
            var kgoYurContract = await _context.KGOYurContracts
                .Where(contract => contract.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);
            
            _contractService.FillContract(request, kgoYurContract);
            _contractService.FillYurContract(request, kgoYurContract);

            kgoYurContract.Volume = request.Volume;
            kgoYurContract.Overload = request.Overload;

            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}