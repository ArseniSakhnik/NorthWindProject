using System;

namespace NorthWindProject.Core.Entities
{
    public abstract class Metadata
    {
        public DateTime TimeCreated { get; set; } = new DateTime();
        public ApplicationUser UserCreated { get; set; }
    }
}