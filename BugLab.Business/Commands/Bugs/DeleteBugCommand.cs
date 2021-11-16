using MediatR;

namespace BugLab.Business.Commands.Bugs
{
    public class DeleteBugCommand : IRequest
    {
        public DeleteBugCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
