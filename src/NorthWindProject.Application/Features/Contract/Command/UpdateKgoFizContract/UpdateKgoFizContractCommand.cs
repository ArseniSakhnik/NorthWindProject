using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Features.Contract.Command.BaseCreateContract;
using NorthWindProject.Application.Services.ContractService;

namespace NorthWindProject.Application.Features.Contract.Command.UpdateKgoFizContract
{
    public class UpdateKgoFizContractCommand : BaseFizContractCommand, IRequest
    {
        public int Id { get; set; }
        public string Volume { get; set; }
        public string Overload { get; set; }
    }
    
    public class UpdateKgoFizContractCommandHandler : IRequestHandler<UpdateKgoFizContractCommand>
    {
        private readonly AppDbContext _context;
        private readonly IContractService _contractService;

        public UpdateKgoFizContractCommandHandler(AppDbContext context, IContractService contractService)
        {
            _context = context;
            _contractService = contractService;
        }

        public async Task<Unit> Handle(UpdateKgoFizContractCommand request, CancellationToken cancellationToken)
        {
            var kgoFizContract = await _context.KGOFizContracts
                .Where(contract => contract.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);
            
            _contractService.FillContract(request, kgoFizContract);
            _contractService.FillFizContract(request, kgoFizContract);

            kgoFizContract.Volume = request.Volume;
            kgoFizContract.Overload = request.Overload;

            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}