using MediatR;

namespace BugLab.Shared.Commands
{
    public class AddCommentCommand : IRequest
    {
        public string Text { get; set; }
        public int BugId { get; set; }
    }
}
