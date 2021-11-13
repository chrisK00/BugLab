using BugLab.Shared.Enums;
using MediatR;

namespace BugLab.Shared.Commands
{
    public class UpdateBugCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public BugPriority Priority { get; set; }
        public BugStatus Status { get; set; }
        public int ProjectId { get; set; }
    }
}
