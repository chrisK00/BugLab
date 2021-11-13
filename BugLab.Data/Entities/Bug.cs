using BugLab.Shared.Enums;
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
        public Project Project { get; init; }

        public ICollection<Comment> Comments { get; init; } = new List<Comment>();
    }
}
