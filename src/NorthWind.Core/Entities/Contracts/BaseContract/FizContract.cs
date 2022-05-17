using NorthWind.Core.Attributes;
using NorthWind.Core.Interfaces;

namespace NorthWind.Core.Entities.Contracts.BaseContract
{
    public abstract class FizContract : Contract
    {
        [DocumentProp("физическоелицополностью")]
        public string IndividualFullName { get; set; }
    }
}