using System.Collections.Generic;
using NorthWind.Core.Entities.Contracts.BaseContract;
using NorthWind.Core.Entities.Services.BaseService;
using NorthWind.Core.Enums;

namespace NorthWind.Core.Entities.Services.DocumentService
{
    public class DocumentService
    {
        public int Id { get; set; }

        public ServicesEnum ServiceId { get; set; }
        public Service Service { get; set; }

        public List<Contract> Contracts { get; set; }
        public byte[] Content { get; set; }
        public List<DocumentField> DocumentFields { get; set; }
    }
}