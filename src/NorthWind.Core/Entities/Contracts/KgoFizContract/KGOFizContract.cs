using System.ComponentModel.DataAnnotations.Schema;
using NorthWind.Core.Attributes;
using NorthWind.Core.Entities.Contracts.BaseContract;

namespace NorthWind.Core.Entities.Contracts.KgoFizContract
{
    [Table("KGOFizContract")]
    public class KGOFizContract : FizContract
    {
        [DocumentProp("объем")] public string Volume { get; set; }
        
        [DocumentProp("перегруз")] public string Overload { get; set; }
    }
}