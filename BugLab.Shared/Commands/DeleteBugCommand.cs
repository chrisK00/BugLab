using MediatR;

namespace BugLab.Shared.Commands
{
    public class DeleteBugCommand : IRequest
    {
        public DeleteBugCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
