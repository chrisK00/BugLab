using MediatR;

namespace BugLab.Business.Commands.BugTypes
{
    public class UpdateBugTypeCommand : IRequest
    {
        public UpdateBugTypeCommand(int id, string title, string color)
        {
            Id = id;
            Title = title;
            Color = color;
        }

        public int Id { get; }
        public string Title { get; }
        public string Color { get; }
    }
}
