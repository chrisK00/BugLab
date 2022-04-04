using BugLab.Shared.Enums;
using MediatR;

namespace BugLab.Business.Commands.Bugs
{
    public class UpdateBugCommand : IRequest
    {
        public UpdateBugCommand(int id, string title, string description, BugPriority priority, BugStatus status,
            int typeId, string assignedToId, int? sprintId, bool partialUpdate = false)
        {
            Id = id;
            Title = title;
            Description = description;
            Priority = priority;
            Status = status;
            TypeId = typeId;
            AssignedToId = assignedToId;
            SprintId = sprintId;
            PartialUpdate = partialUpdate;
            AssignedToId = string.IsNullOrWhiteSpace(assignedToId) ? null : assignedToId;
        }

        public int Id { get; }
        public string Title { get; }
        public string Description { get; }
        public BugPriority Priority { get; }
        public BugStatus Status { get; }
        public int TypeId { get; }
        public string AssignedToId { get; }
        public int? SprintId { get; set; }
        public bool PartialUpdate { get; }
    }
}
