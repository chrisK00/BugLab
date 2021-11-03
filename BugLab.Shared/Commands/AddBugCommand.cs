using BugLab.Shared.Enums;
using MediatR;

namespace BugLab.Shared.Commands
{
    public class AddBugCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public BugPriority Priority { get; set; }
        public BugStatus Status { get; set; }
    }
}
