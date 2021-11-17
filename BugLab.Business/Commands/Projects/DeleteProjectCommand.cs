using MediatR;

namespace BugLab.Business.Commands.Projects
{
    public class DeleteProjectCommand : IRequest
    {
        public DeleteProjectCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
