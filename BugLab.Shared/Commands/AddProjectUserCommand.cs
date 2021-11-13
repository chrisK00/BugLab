using MediatR;

namespace BugLab.Shared.Commands
{
    public class AddProjectUserCommand : IRequest
    {
        public int ProjectId { get; set; }
        public string UserId { get; set; }
    }
}
