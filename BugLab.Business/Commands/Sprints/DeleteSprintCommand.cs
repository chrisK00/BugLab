using MediatR;

namespace BugLab.Business.Commands.Sprints
{
    public class DeleteSprintCommand : IRequest
    {
        public DeleteSprintCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
