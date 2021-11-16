using BugLab.Shared.Enums;
using MediatR;

namespace BugLab.Business.Commands.Bugs
{
    public class UpdateBugCommand : IRequest
    {
        public UpdateBugCommand(int id, string title, string description, BugPriority priority, BugStatus status, int typeId, int projectId)
        {
            Id = id;
            Title = title;
            Description = description;
            Priority = priority;
            Status = status;
            TypeId = typeId;
            ProjectId = projectId;
        }

        public int Id { get; }
        public string Title { get; }
        public string Description { get; }
        public BugPriority Priority { get; }
        public BugStatus Status { get; }
        public int TypeId { get; }
        public int ProjectId { get; }
    }
}
