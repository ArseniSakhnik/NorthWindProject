using System;

namespace NorthWind.Core.Entities.Metadata
{
    public abstract class AuditableEntity
    {
        public int CreatedByUserId { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastModifiedBy { get; set; }
    }
}