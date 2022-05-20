namespace NorthWindProject.Application.Features.Contract.Command.BaseCreateContract
{
    public abstract class BaseYurContractCommand : BaseContractCommand
    {
        public string INN { get; set; }
        public string KPP { get; set; }
        public string OGRN { get; set; }
        public string OKPO { get; set; }
        public string YurAddress { get; set; }
        public string CustomerShortName { get; set; }
        public string IEShortName { get; set; }
        public string OperatesOnBasis { get; set; }
    }
}