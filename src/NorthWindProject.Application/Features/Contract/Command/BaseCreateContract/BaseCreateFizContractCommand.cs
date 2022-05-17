namespace NorthWindProject.Application.Features.Contract.Command.BaseCreateContract
{
    public abstract class BaseCreateFizContractCommand : BaseCreateContractCommand
    {
        public string IndividualFullName { get; set; }
    }
}