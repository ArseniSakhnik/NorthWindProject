using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Features.Contract.Query.BaseDto;
using NorthWindProject.Application.Services.ContractService;

namespace NorthWindProject.Application.Features.Contract.Query.GetContract
{
    public class GetContractQuery : IRequest<BaseContractDto>
    {
        public int ContractId { get; set; }
    }

    public class GetContractQueryHandler : IRequestHandler<GetContractQuery, BaseContractDto>
    {
        private readonly IContractService _contractService;

        public GetContractQueryHandler(IContractService contractService)
        {
            _contractService = contractService;
        }

        public async Task<BaseContractDto> Handle(GetContractQuery request, CancellationToken cancellationToken)
            => await _contractService.GetContract(request.ContractId, cancellationToken);
    }
}