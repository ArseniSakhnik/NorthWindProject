using System.Collections.Generic;

namespace NorthWindProject.Application.Features.Contract.Query.GetContracts
{
    public class ContractAndPageDto
    {
        public IList<ContractDto> Contracts { get; set; }
        public int PageCount { get; set; }
    }
}