namespace NorthWindProject.Application.Features.Contract.Command.BaseCreateContract
{
    public abstract class BaseFizContractCommand : BaseContractCommand
    {
        public string IndividualFullName { get; set; }
    }
}