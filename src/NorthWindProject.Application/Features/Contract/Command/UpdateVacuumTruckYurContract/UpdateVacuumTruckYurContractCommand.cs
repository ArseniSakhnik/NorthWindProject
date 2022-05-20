using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Features.Contract.Command.BaseCreateContract;
using NorthWindProject.Application.Services.ContractService;

namespace NorthWindProject.Application.Features.Contract.Command.UpdateVacuumTruckYurContract
{
    public class UpdateVacuumTruckYurContractCommand : BaseYurContractCommand, IRequest
    {
        public int Id { get; set; }
    }

    public class UpdateVacuumTruckYurContractCommandHandler : IRequestHandler<UpdateVacuumTruckYurContractCommand>
    {
        private readonly AppDbContext _context;
        private readonly IContractService _contractService;

        public UpdateVacuumTruckYurContractCommandHandler(AppDbContext context, IContractService contractService)
        {
            _context = context;
            _contractService = contractService;
        }

        public async Task<Unit> Handle(UpdateVacuumTruckYurContractCommand request, CancellationToken cancellationToken)
        {
            var yurContract = await _context.VacuumTruckYurContracts
                .Where(contract => contract.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            _contractService.FillContract(request, yurContract);
            _contractService.FillYurContract(request, yurContract);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}