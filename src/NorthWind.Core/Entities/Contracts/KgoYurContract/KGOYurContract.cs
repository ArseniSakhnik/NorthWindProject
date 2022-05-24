using System.ComponentModel.DataAnnotations.Schema;
using NorthWind.Core.Attributes;
using NorthWind.Core.Entities.Contracts.BaseContract;
using NorthWind.Core.Enums;
using NorthWind.Core.Interfaces;

namespace NorthWind.Core.Entities.Contracts.KgoYurContract
{
    [Table("KGOYurContract")]
    public class KGOYurContract : YurContract
    {
        [DocumentProp("объем")] public string Volume { get; set; }
        
        [DocumentProp("перегруз")] public string Overload { get; set; }
    }
}