using System.Dynamic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Features.Contract.Query.BaseDto;
using NorthWindProject.Application.Services.ContractService;

namespace NorthWindProject.Application.Features.Contract.Query.GetContract
{
    public class GetContractQuery : IRequest<ExpandoObject>
    {
        public int ContractId { get; set; }
    }

    public class GetContractQueryHandler : IRequestHandler<GetContractQuery, ExpandoObject>
    {
        private readonly IContractService _contractService;

        public GetContractQueryHandler(IContractService contractService)
        {
            _contractService = contractService;
        }

        public async Task<ExpandoObject> Handle(GetContractQuery request, CancellationToken cancellationToken)
            => await _contractService.GetContract(request.ContractId, cancellationToken);
    }
}