namespace NorthWindProject.Application.Features.Contract.Command.BaseCreateContract
{
    public abstract class BaseCreateContractCommand
    {
        public string PhoneNumber { get; set; }
        public string PlaceName { get; set; }
        public string Email { get; set; }
    }
}