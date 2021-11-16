using MediatR;

namespace BugLab.Shared.Requests.Projects
{
    public class AddProjectRequest : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
