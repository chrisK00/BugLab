using MediatR;

namespace BugLab.Business.Commands.Projects
{
    public class AddProjectCommand : IRequest<int>
    {
        public AddProjectCommand(string userId, string title, string description)
        {
            UserId = userId;
            Title = title;
            Description = description;
        }

        public string UserId { get; }
        public string Title { get; }
        public string Description { get;  }
    }
}
