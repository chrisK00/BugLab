using BugLab.Shared.Enums;
using MediatR;

namespace BugLab.Business.Commands.Bugs
{
    public class AddBugCommand : IRequest<int>
    {
        public AddBugCommand(string title, string description, BugPriority priority, BugStatus status, int typeId, int projectId)
        {
            Title = title;
            Description = description;
            Priority = priority;
            Status = status;
            TypeId = typeId;
            ProjectId = projectId;
        }

        public string Title { get; }
        public string Description { get; }
        public BugPriority Priority { get; }
        public BugStatus Status { get; }
        public int TypeId { get; }
        public int ProjectId { get; }
    }
}
