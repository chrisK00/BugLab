using MediatR;

namespace BugLab.Business.Commands.BugTypes
{
    public class DeleteBugTypeCommand : IRequest
    {
        public DeleteBugTypeCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
