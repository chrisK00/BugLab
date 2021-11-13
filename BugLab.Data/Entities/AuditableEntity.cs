using Microsoft.AspNetCore.Identity;
using System;

namespace BugLab.Data.Entities
{
    public abstract class AuditableEntity
    {
        public DateTime Created { get; set; }

        public IdentityUser CreatedBy { get; set; }
        public string CreatedById { get; set; }

        public DateTime? Modified { get; set; }

        public string ModifiedById { get; set; }
        public IdentityUser ModifiedBy { get; set; }
    }
}