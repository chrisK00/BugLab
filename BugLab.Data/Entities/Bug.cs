using BugLab.Shared.Enums;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BugLab.Data.Entities
{
    public class Bug : AuditableEntity
    {
        public int Id { get; init; }
        public string Title { get; set; }
        public string Description { get; set; }
        public BugPriority Priority { get; set; }
        public BugStatus Status { get; set; }

        public int ProjectId { get; init; }
        public Project Project { get; private set; }

        public int BugTypeId { get; set; }
        public BugType BugType { get; private set; }

        public string AssignedToId { get; set; }
        public IdentityUser AssignedTo { get; private set; }

        public Sprint Sprint { get; private set; }
        public int? SprintId { get; set; }

        public ICollection<Comment> Comments { get; init; } = new List<Comment>();
    }
}
