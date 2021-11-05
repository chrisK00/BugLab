using MediatR;

namespace BugLab.Shared.Commands
{
    public class AddProjectCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
