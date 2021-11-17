using MediatR;

namespace BugLab.Business.Commands.Projects
{
    public class DeleteProjectUserCommand : IRequest
    {
        public DeleteProjectUserCommand(int projectId, string userId)
        {
            ProjectId = projectId;
            UserId = userId;
        }

        public int ProjectId { get; }
        public string UserId { get; }
    }
}
