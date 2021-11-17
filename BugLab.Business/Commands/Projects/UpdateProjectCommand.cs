using MediatR;

namespace BugLab.Business.Commands.Projects
{
    public class UpdateProjectCommand : IRequest
    {
        public UpdateProjectCommand(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }

        public int Id { get; }
        public string Title { get; }
        public string Description { get; }
    }
}
