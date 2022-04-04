using MediatR;

namespace BugLab.Business.Commands.Sprints
{
    public class AddSprintCommand : IRequest<int>
    {
        public AddSprintCommand(int projectId, string title)
        {
            ProjectId = projectId;
            Title = title;
        }

        public int ProjectId { get; }
        public string Title { get; }
    }
}
