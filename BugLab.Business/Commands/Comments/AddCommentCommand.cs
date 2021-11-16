using MediatR;

namespace BugLab.Business.Commands.Comments
{
    public class AddCommentCommand : IRequest
    {
        public AddCommentCommand(int bugId, string text)
        {
            BugId = bugId;
            Text = text;
        }

        public int BugId { get; }
        public string Text { get; }
    }
}
