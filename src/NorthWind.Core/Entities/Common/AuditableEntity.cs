using System;

namespace NorthWind.Core.Entities.Common
{
    public class AuditableEntity
    {
        public int? CreatedByUserId { get; set; }
        public string CreatedByUsername { get; set; }
        public DateTime Created { get; set; }
        public int? LasModifiedById { get; set; }
        public string LastModifiedByUsername { get; set; }
        public DateTime? LastModified { get; set; }
    }
}