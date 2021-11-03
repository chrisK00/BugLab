using System;

namespace BugLab.Data.Entities
{
    public abstract class AuditableEntity
    {
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}