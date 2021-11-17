using MediatR;

namespace BugLab.Business.Commands.BugTypes
{
    public class AddBugTypeCommand : IRequest<int>
    {
        public AddBugTypeCommand(int projectId, string color, string title)
        {
            ProjectId = projectId;
            Color = color;
            Title = title;
        }

        public int ProjectId { get; }
        public string Color { get; }
        public string Title { get; }
    }
}
