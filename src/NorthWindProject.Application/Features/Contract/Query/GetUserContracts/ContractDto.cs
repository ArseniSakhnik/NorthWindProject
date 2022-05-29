using NorthWind.Core.Enums;

namespace NorthWindProject.Application.Features.Contract.Query.GetUserContracts
{
    public class ContractDto
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public bool IsConfirmed { get; set; }
        public string PlaceName { get; set; }
        
        public string Created { get; set; }
    }
}