using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Features.Contract.Command.BaseCreateContract;
using NorthWindProject.Application.Services.ContractService;

namespace NorthWindProject.Application.Features.Contract.Command.UpdateVacuumTruckFizContract
{
    public class UpdateVacuumTruckFizContractCommand : BaseFizContractCommand, IRequest
    {
        public int Id { get; set; }
    }

    public class UpdateVacuumTruckFizContractCommandHandler : IRequestHandler<UpdateVacuumTruckFizContractCommand>
    {
        private readonly AppDbContext _context;
        private readonly IContractService _contractService;

        public UpdateVacuumTruckFizContractCommandHandler(AppDbContext context, IContractService contractService)
        {
            _context = context;
            _contractService = contractService;
        }

        public async Task<Unit> Handle(UpdateVacuumTruckFizContractCommand request, CancellationToken cancellationToken)
        {
            var fizContract = await _context.VacuumTruckFizContracts
                .Where(contract => contract.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            _contractService.FillContract(request, fizContract);
            _contractService.FillFizContract(request, fizContract);

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}