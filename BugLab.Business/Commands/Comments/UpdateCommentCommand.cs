using MediatR;

namespace BugLab.Business.Commands.Comments
{
    public class UpdateCommentCommand : IRequest
    {
        public UpdateCommentCommand(int id, int bugId, string text)
        {
            Id = id;
            BugId = bugId;
            Text = text;
        }

        public int BugId { get; }
        public int Id { get; }
        public string Text { get; }
    }
}